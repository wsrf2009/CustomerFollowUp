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
    }
}
