using System;
using System.Data;
using System.Windows.Forms;
using SqlLibrary;
using SqlLibrary.DataStructure;

namespace CFUSystem
{
    public partial class AccountList : UserControl
    {
        public AccountList()
        {
            InitializeComponent();
        }

        private void AccountList_Load(object sender, EventArgs e)
        {
            LoadAllUser();

            ToolStripMenuItem tsmiAdd = CreateAddCustomerInfoMenuItem();
            contextMenuStrip1.Items.Add(tsmiAdd);

            ToolStripSeparator tss = new ToolStripSeparator();
            contextMenuStrip1.Items.Add(tss);

            ToolStripMenuItem tsmiRefresh = CreateRefreshCustomerInfoMenuItem();
            contextMenuStrip1.Items.Add(tsmiRefresh);
        }

        private void FormatDataGridView(DataGridView grid)
        {
            if (grid.Columns.Count > 0)
            {
                int i = 0;
                var col = grid.Columns["Id"];
                col.Visible = false;

                col = grid.Columns["Name"];
                col.HeaderText = "用户名";
                col.Width = 100;
                col.DisplayIndex = i++;

                col = grid.Columns["Password"];
                col.Visible = false;

                col = grid.Columns["Portrait"];
                col.Visible = false;

                col = grid.Columns["Privilege"];
                col.HeaderText = "权限";
                col.Width = 100;
                col.DisplayIndex = i++;

                col = grid.Columns["Nickname"];
                col.Visible = false;

                col = grid.Columns["RegisTime"];
                col.Visible = false;

                col = grid.Columns["LastLogin"];
                col.HeaderText = "最后登录";
                col.Width = 100;
                col.DisplayIndex = i++;

                col = grid.Columns["LastLoginLanIp"];
                col.HeaderText = "最后登录IP";
                col.Width = 100;
                col.DisplayIndex = i++;

                col = grid.Columns["LastLogout"];
                //col.HeaderText = "最后退出";
                //col.Width = 100;
                //col.DisplayIndex = i++;
                col.Visible = false;

                col = grid.Columns["LastLoginWanIp"];
                col.Visible = false;

                col = grid.Columns["LastLoginMac"];
                col.HeaderText = "最后登录MAC";
                col.Width = 120;
                col.DisplayIndex = i++;

                col = grid.Columns["LastLoginHostName"];
                col.HeaderText = "最后登录主机名";
                col.Width = 150;
                col.DisplayIndex = i++;

                col = grid.Columns["LastLoginUserName"];
                col.HeaderText = "最后登录主机用户名";
                col.Width = 100;
                col.DisplayIndex = i++;
            }
        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            try
            {
                ////显示在HeaderCell上
                //for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
                //{
                //    DataGridViewRow r = this.dataGridView1.Rows[i];
                //    r.HeaderCell.Value = string.Format("{0}", i + 1);
                //}
                //this.dataGridView1.Refresh();
                e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                int rowIndex = e.RowIndex;
                int count = dataGridView1.SelectedRows.Count;

                contextMenuStrip1.Items.Clear();

                ToolStripMenuItem tsmiAdd = CreateAddCustomerInfoMenuItem();
                contextMenuStrip1.Items.Add(tsmiAdd);

                if (count > 0)
                {
                    bool contains = dataGridView1.SelectedRows.Contains(dataGridView1.Rows[rowIndex]);
                    if (contains)
                    {
                        if (1 == count)
                        {
                            ToolStripMenuItem tsmiEdit = CreateEditCustomerInfoMenuItem();
                            contextMenuStrip1.Items.Add(tsmiEdit);
                        }

                        ToolStripMenuItem tsmiDelete = CreateDeleteCustomerInfoMenuItem();
                        contextMenuStrip1.Items.Add(tsmiDelete);
                    }
                    else
                    {
                        dataGridView1.ClearSelection();
                    }
                }

                ToolStripSeparator tss = new ToolStripSeparator();
                contextMenuStrip1.Items.Add(tss);

                ToolStripMenuItem tsmiRefresh = CreateRefreshCustomerInfoMenuItem();
                contextMenuStrip1.Items.Add(tsmiRefresh);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private ToolStripMenuItem CreateAddCustomerInfoMenuItem()
        {
            ToolStripMenuItem tsmiAdd = new ToolStripMenuItem();
            tsmiAdd.Text = "添加账户";
            tsmiAdd.Click += TsmiAdd_Click;

            return tsmiAdd;
        }

        private ToolStripMenuItem CreateEditCustomerInfoMenuItem()
        {
            ToolStripMenuItem tsmiEdit = new ToolStripMenuItem();
            tsmiEdit.Text = "编辑";
            tsmiEdit.Click += TsmiEdit_Click;

            return tsmiEdit;
        }

        private ToolStripMenuItem CreateDeleteCustomerInfoMenuItem()
        {
            ToolStripMenuItem tsmiDelete = new ToolStripMenuItem();
            tsmiDelete.Text = "删除";
            tsmiDelete.Click += TsmiDelete_Click;

            return tsmiDelete;
        }

        private ToolStripMenuItem CreateRefreshCustomerInfoMenuItem()
        {
            ToolStripMenuItem tsmiRefresh = new ToolStripMenuItem();
            tsmiRefresh.Text = "刷新";
            tsmiRefresh.Click += TsmiRefresh_Click;

            return tsmiRefresh;
        }

        private void TsmiAdd_Click(object sender, EventArgs e)
        {
            try
            {
                FrmUser frmUser = new FrmUser
                {
                    WorkingState = WorkingState.Add,
                };
                DialogResult dialogResult = frmUser.ShowDialog(this);
                if(DialogResult.OK == dialogResult)
                {
                    LoadAllUser();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TsmiEdit_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow dataRow = (dataGridView1.SelectedRows[0].DataBoundItem as DataRowView).Row;
                var item = dataRow.ToExpression<UserInfo>();
                FrmUser frmUser = new FrmUser
                {
                    User = item(dataRow),
                    WorkingState = WorkingState.Modify,
                };
                DialogResult dialogResult = frmUser.ShowDialog(this);
                if(DialogResult.OK == dialogResult)
                {
                    LoadAllUser();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TsmiDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show(this, "您确定要删除所选账户信息吗，删除后将不可恢复？", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (DialogResult.Yes == dialogResult)
                {
                    int count = dataGridView1.SelectedRows.Count;
                    for (int i = 0; i < count; i++)
                    {
                        var row = dataGridView1.SelectedRows[i];
                        string username = row.Cells["Name"].Value.ToString();
                        int result = TableUsersManage.DeleteUserByUserName(username);
                        if (result <= 0)
                        {
                            MessageBox.Show(this, "删除账户 " + username + " 失败！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    LoadAllUser();
                }
                else if (DialogResult.No == dialogResult)
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TsmiRefresh_Click(object sender, EventArgs e)
        {
            LoadAllUser();
        }

        private void LoadAllUser()
        {
            DataTable dataTable = TableUsersManage.QueryAllUsers();
            this.dataGridView1.DataSource = dataTable;
            FormatDataGridView(this.dataGridView1);
        }
    }
}
