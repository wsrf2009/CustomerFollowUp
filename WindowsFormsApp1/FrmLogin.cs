using CFUManageSystem.Tools;
using SqlLibrary;
using System;
using System.Drawing;
using System.Windows.Forms;
using SystemLibrary;

namespace WindowsFormsApp1
{
    public partial class FrmLogin : Form
    {
        public string UserName { get; set; }

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

                bool userIsExist = CFUSystem.QueryUserName(userName);
                if (!userIsExist)
                {
                    txtBoxErrMessage.Visible = true;
                    txtBoxErrMessage.Text = "用户不存在";
                    txtBoxUserName.Focus();
                    Cursor.Current = Cursors.Default;
                    return;
                }

                string password = txtBoxPassword.Text.Trim();
                bool isRememberPassword = ckBoxRememberPassword.Checked;

                Console.WriteLine("userName:" + userName + " password:" + password + " isRememberPassword:" + isRememberPassword);

                bool loginResult = CFUSystem.Login(userName, password);

                Console.WriteLine("loginResult:" + loginResult);

                if (loginResult)
                {
                    if (isRememberPassword)
                    {
                        AppConfigHelper.SetConfigValue(userName, password);
                    }

                    string mac = SystemInfo.GetMac();
                    string lanIp = SystemInfo.GetLanIp();
                    //string wanIp = SystemInfo.GetWanIp();
                    //string wanIp = "";
                    string datetime = DateTime.Now.ToString();
                    string hostName = SystemInfo.GetHostName();
                    string sysUserName = SystemInfo.GetUserName();

                    Console.WriteLine("username:" + userName + "mac:" + mac + " LanIp:" + lanIp + " hostName:" + hostName + " datetime:" + datetime);

                    CFUSystem.AddLoginLog(userName, datetime, mac, lanIp, hostName, sysUserName);
                    CFUSystem.ModifyLastLoginLog(userName, datetime, mac, lanIp, hostName, sysUserName);

                    this.UserName = userName;
                    this.DialogResult = DialogResult.OK;

                    this.Close();
                }
                else
                {
                    txtBoxErrMessage.Visible = true;
                    txtBoxErrMessage.Text = "密码错误";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
                Console.WriteLine(ex.Message);
            }
        }
    }
}
