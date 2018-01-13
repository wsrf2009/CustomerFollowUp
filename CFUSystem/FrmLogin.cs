using CFUSystem.Tools;
using SqlLibrary;
using SqlLibrary.DataStructure;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SystemLibrary;

namespace CFUSystem
{
    public partial class FrmLogin : Form
    {
        public UserInfo User { get; set; }
        public string UserName { get; set; }
        public LoginLog LoginLog { get; set; }
        public int LoginLogId { get; set; }

        public FrmLogin()
        {
            InitializeComponent();

            ckBoxRememberPassword.Checked = SettingsHelper.GetRememberPassword();

            txtBoxErrMessage.ReadOnly = true;
            txtBoxErrMessage.ForeColor = Color.Red;
            txtBoxErrMessage.BackColor = Color.White;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            txtBoxErrMessage.Visible = false;

            try
            {
                string userName = txtBoxUserName.Text.Trim();
                if (string.IsNullOrWhiteSpace(userName))
                {
                    txtBoxErrMessage.Visible = true;
                    txtBoxErrMessage.Text = "用户名不能为空";
                    txtBoxUserName.Focus();
                    Cursor.Current = Cursors.Default;
                    return;
                }

                DataTable dataTable = TableUsersManage.QueryUserName(userName);
                if (dataTable.Rows.Count <= 0)
                {
                    txtBoxErrMessage.Visible = true;
                    txtBoxErrMessage.Text = "用户不存在";
                    txtBoxUserName.Focus();
                    Cursor.Current = Cursors.Default;
                    return;
                }

                string password = txtBoxPassword.Text.Trim();
                bool isRememberPassword = ckBoxRememberPassword.Checked;
                DataRow dataRow = dataTable.Rows[0];
                var item = dataRow.ToExpression<UserInfo>();
                this.User = item(dataRow);
                if(this.User.Password.Equals(password))
                {
                    if (isRememberPassword)
                    {
                        AppConfigHelper.SetConfigValue(userName, password);
                    }

                    string mac = SystemInfo.GetMac();
                    string lanIp = SystemInfo.GetLanIp();
                    //string wanIp = SystemInfo.GetWanIp();
                    //string wanIp = "";
                    string datetime = DateTime.Now.ToLocalTime().ToString();
                    string hostName = SystemInfo.GetHostName();
                    string sysUserName = SystemInfo.GetUserName();

                    this.LoginLogId = TableUsersManage.AddUserLoginLogAndReturnIdentity(userName, datetime, mac, lanIp, hostName, sysUserName, this.User.Id);
                    if (this.LoginLogId >= 0)
                    {
                        //int suc = TableUsersManage.ModifyUserLastLoginLogByUserName(userName, datetime, mac, lanIp, hostName, sysUserName);
                        //if (suc > 0)
                        //{
                            this.UserName = userName;
                            this.DialogResult = DialogResult.OK;

                            this.Close();
                        //}
                        //else
                        //{
                        //    MessageBox.Show(this, "服务器连接错误！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //}
                    }
                    else
                    {
                        MessageBox.Show(this, "服务器连接错误！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    txtBoxErrMessage.Visible = true;
                    txtBoxErrMessage.Text = "密码错误";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Cursor.Current = Cursors.Default;
        }

        private void txtBoxUserName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (ckBoxRememberPassword.Checked)
                {
                    string userName = txtBoxUserName.Text.Trim();
                    string password = AppConfigHelper.GetConfigValue(userName);

                    txtBoxPassword.Text = password;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
