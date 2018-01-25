using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SqlLibrary.DataStructure;
using SqlLibrary;

namespace CFUSystem
{
    public partial class AccountInfo : UserControl
    {
        public UserInfo User { get; set; }

        public AccountInfo()
        {
            InitializeComponent();
        }

        private void AccountInfo_Load(object sender, EventArgs e)
        {
            try
            {
                if (null != this.User)
                {
                    TxtBoxUserName.Text = this.User.Name;
                    TxtBoxPassword.Text = this.User.Password;
                    TxtBoxNickName.Text = this.User.Nickname;
                    TxtBoxLastLoginTime.Text = this.User.LastLogin;
                    TxtBoxLastLoginIp.Text = this.User.LastLoginLanIp;
                    TxtBoxLastLoginMac.Text = this.User.LastLoginMac;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LblModify_Click(object sender, EventArgs e)
        {
            try
            {
                FrmModifyPassword frmModifyPassword = new FrmModifyPassword
                {
                    User = this.User
                };
                DialogResult dialogResult = frmModifyPassword.ShowDialog(this);
                if (DialogResult.OK == dialogResult)
                {
                    var frm = this.FindForm() as FrmAccountManager;
                    if (null != frm)
                    {
                        frm.ModifyPasswordSuccess();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LblModifyNickname_Click(object sender, EventArgs e)
        {
            if (LblModifyNickname.Text.Equals("修改"))
            {
                TxtBoxNickName.Enabled = true;
                LblModifyNickname.Text = "确定";
            }
            else if (LblModifyNickname.Text.Equals("确定"))
            {
                string nickname = TxtBoxNickName.Text.Trim();
                if (nickname.Contains("'"))
                {
                    MessageBox.Show(this, "含有非法字符 \"'\" !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    TxtBoxNickName.Focus();
                    return;
                }
                else
                {
                    TxtBoxNickName.Enabled = false;
                    LblModifyNickname.Text = "修改";

                    TableUsersManage.ModifyNicknameByUserId(this.User.Id, nickname);
                }
            }
        }
    }
}
