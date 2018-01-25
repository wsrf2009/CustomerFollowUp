using SqlLibrary.DataStructure;
using System;
using System.Windows.Forms;

namespace CFUSystem
{
    public partial class FrmAccountManager : Form
    {
        public string UserName { get; set; }
        public UserInfo User { get; set; }

        public FrmAccountManager()
        {
            InitializeComponent();
        }

        private void FrmAccountManager_Load(object sender, EventArgs e)
        {
            try
            {
                //DataTable dataTable = TableUsersManage.QueryUserName(this.UserName);
                //DataRow dataRow = dataTable.Rows[0];
                //var item = dataRow.ToExpression<UserInfo>();
                //this.User = item(dataRow);

                if (PrivilegeLevel.Administrative != this.User.Privilege)
                {
                    foreach (TreeNode node in treeView1.Nodes)
                    {
                        if ("Manage" == node.Name)
                        {
                            node.Remove();
                        }
                    }
                }

                AccountInfo_Click();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ModifyPasswordSuccess()
        {
            MessageBox.Show(this, "密码修改成功，需要重新登录！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                var v = this.treeView1.GetNodeAt(e.X, e.Y);
                var node = v as TreeNode;
                if (null != node)
                {
                    if ("AccountInfo" == node.Name)
                    {
                        AccountInfo_Click();
                    }
                    else if ("LoginLogs" == node.Name)
                    {
                        LoginLogs_Click();
                    }
                    else if ("Manage" == node.Name)
                    {

                    }
                    else if ("AllAccountList" == node.Name)
                    {
                        AllUsers_Click();
                    }
                    else if ("AllLoginLogs" == node.Name)
                    {
                        AllLoginLogs_Click();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;
        }

        private void AccountInfo_Click()
        {
            AccountInfo accountInfo = new AccountInfo
            {
                Dock = DockStyle.Fill,
                User = this.User,
            };
            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(accountInfo);
        }

        private void LoginLogs_Click()
        {
            LoginLogs loginLogs = new LoginLogs
            {
                Dock = DockStyle.Fill,
                LoadAllUsers = false,
                UserName = this.User.Name,
            };
            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(loginLogs);
        }

        private void AllUsers_Click()
        {
            AccountList accountList = new AccountList
            {
                Dock = DockStyle.Fill,
            };
            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(accountList);
        }

        private void AllLoginLogs_Click()
        {
            LoginLogs loginLogs = new LoginLogs
            {
                Dock = DockStyle.Fill,
                LoadAllUsers = true,
            };
            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(loginLogs);
        }
    }
}
