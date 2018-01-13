using SqlLibrary;
using SqlLibrary.DataStructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CFUSystem
{
    public partial class FrmModifyPassword : Form
    {
        public UserInfo User { get; set; }

        public FrmModifyPassword()
        {
            InitializeComponent();
        }

        private void LblOk_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                string oPassword = TxtBoxOldPassword.Text;
                string nPassword = TxtBoxNewPassword.Text;
                string nqPassword = TxtBoxNewPasswordQuery.Text;

                if (oPassword.Equals(this.User.Password))
                {
                    if (nPassword.Equals(nqPassword))
                    {
                        int suc = TableUsersManage.ModifyPassword(this.User.Name, nPassword);
                        if (suc > 0)
                        {
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show(this, "修改密码失败！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        TxtBoxNewPassword.Focus();
                        MessageBox.Show(this, "新密码不一致！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    TxtBoxOldPassword.Focus();
                    MessageBox.Show(this, "原密码错误！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
