using SqlLibrary;
using SqlLibrary.DataStructure;
using System;
using System.Data;
using System.Windows.Forms;

namespace CFUSystem
{
    public partial class FrmUser : Form
    {
        public WorkingState WorkingState { get; set; }
        public UserInfo User { get; set; }

        public FrmUser()
        {
            InitializeComponent();
        }

        private void FrmAddUser_Load(object sender, EventArgs e)
        {
            this.ComboBoxPrivilege.Items.AddRange(PrivilegeLevel.ToArray());

            if (WorkingState.Add == this.WorkingState)
            {
                this.Text = "添加";
                this.ComboBoxPrivilege.SelectedIndex = 0;
            }
            else if (WorkingState.Modify == this.WorkingState)
            {
                this.Text = "修改";
                this.TxtBoxUserName.Text = this.User.Name;
                this.TxtBoxUserName.Enabled = false;
                this.TxtBoxPassword.Text = this.User.Password;
                this.TxtBoxNickname.Text = this.User.Nickname;
                this.ComboBoxPrivilege.Text = this.User.Privilege;
            }
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                string name = TxtBoxUserName.Text.Trim();
                if (name.Contains("'"))
                {
                    MessageBox.Show(this, "含有非法字符 \"'\" !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    TxtBoxUserName.Focus();
                    return;
                }
                if (WorkingState.Add == this.WorkingState)
                {
                    DataTable dataTable = TableUsersManage.QueryUserName(name);
                    if (dataTable.Rows.Count > 0)
                    {
                        MessageBox.Show(this, "已存在相同的用户名！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        TxtBoxUserName.Focus();
                        return;
                    }
                }

                string password = TxtBoxPassword.Text.Trim();
                if (password.Contains("'"))
                {
                    MessageBox.Show(this, "含有非法字符 \"'\" !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    TxtBoxPassword.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show(this, "密码不能为空！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    TxtBoxPassword.Focus();
                    return;
                }

                string nickname = TxtBoxNickname.Text.Trim();
                if (nickname.Contains("'"))
                {
                    MessageBox.Show(this, "含有非法字符 \"'\" !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    TxtBoxNickname.Focus();
                    return;
                }

                string privilege = ComboBoxPrivilege.Text;
                if (WorkingState.Add == this.WorkingState)
                {
                    int identity = TableUsersManage.AddUserAndReturnIdentity(name, password, privilege, nickname, DateTime.Now.ToLocalTime().ToString());
                    if (identity > 0)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(this, "添加用户失败！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (WorkingState.Modify == this.WorkingState)
                {
                    int suc = TableUsersManage.ModifyUserByUserName(name, password, privilege, nickname);
                    if (suc > 0)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(this, "修改用户失败！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Cursor.Current = Cursors.Default;
        }
    }
}
