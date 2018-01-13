using CFUSystem;
using SqlLibrary;
using SqlLibrary.DataStructure;
using System;
using System.Data;
using System.Windows.Forms;

namespace CFUSystem
{
    public partial class FrmMain : Form
    {
        public UserInfo User { get; set; }
        public string UserName { get; set; }
        public int LoginLogId { get; set; }
        private DataSet dataSet { get; set; }
        private LoginState LoginState { get; set; }

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            try
            {
                Login();

                //LoadAllCustomer(this.UserName);

                ToolStripMenuItem tsmiAdd = CreateAddCustomerInfoMenuItem();
                contextMenuStrip1.Items.Add(tsmiAdd);

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

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (LoginState.Login == this.LoginState)
            {
                TableUsersManage.ModifyUserLogoutById(DateTime.Now.ToLocalTime().ToString(), this.LoginLogId);
            }
        }

        private void LoadAllCustomer(string username)
        {
            DataGridViewCustomerInfo.ClearSelection();

            dataSet = TableCustomerManage.QueryCustomerInfoBySeller(this.UserName);
            DataGridViewCustomerInfo.DataSource = dataSet.Tables["TB_CustomerInfo"]; //dataSet;
            FormatDataGridView(DataGridViewCustomerInfo);
        }

        private void FormatDataGridView(DataGridView grid)
        {
            if (grid.Columns.Count > 1)
            {
                int i = 0;

                var col = grid.Columns["Id"];
                col.Visible = false;

                col = grid.Columns["ArchivingTime"];
                col.HeaderText = "建档时间";
                col.Width = 100;
                col.ReadOnly = true;
                col.DisplayIndex = i++;

                col = grid.Columns["Sort"];
                col.Visible = false;

                col = grid.Columns["CompanyName"];
                col.HeaderText = "公司名称";
                col.Width = 100;
                col.DisplayIndex = i++;

                col = grid.Columns["Website"];
                col.HeaderText = "网址";
                col.Width = 100;
                col.DisplayIndex = i++;

                col = grid.Columns["Address"];
                col.HeaderText = "地址";
                col.Width = 100;
                col.DisplayIndex = i++;

                col = grid.Columns["Country"];
                col.HeaderText = "国家";
                col.Width = 100;
                col.DisplayIndex = i++;

                col = grid.Columns["BusinessScope"];
                col.Visible = false;

                col = grid.Columns["Type"];
                col.Visible = false;

                col = grid.Columns["Demand"];
                col.Visible = false;

                col = grid.Columns["Contacts"];
                col.HeaderText = "联系人";
                col.Width = 100;
                col.DisplayIndex = i++;

                col = grid.Columns["Email"];
                col.HeaderText = "邮箱";
                col.Width = 100;
                col.DisplayIndex = i++;

                col = grid.Columns["Telephone"];
                col.Visible = false;

                col = grid.Columns["FAX"];
                col.Visible = false;

                col = grid.Columns["Skype"];
                col.Visible = false;

                col = grid.Columns["MSN"];
                col.Visible = false;

                col = grid.Columns["Facebook"];
                col.Visible = false;

                col = grid.Columns["Linkin"];
                col.Visible = false;

                col = grid.Columns["Whatsapp"];
                col.Visible = false;

                col = grid.Columns["Twiter"];
                col.Visible = false;

                col = grid.Columns["Mobile"];
                col.Visible = false;

                col = grid.Columns["ComeFrom"];
                col.HeaderText = "来源";
                col.Width = 100;
                col.DisplayIndex = i++;

                col = grid.Columns["BelongsTo"];
                col.Visible = false;

                col = grid.Columns["Remarks"];
                col.Visible = false;

                col = grid.Columns["Modify"];
                col.HeaderText = "修改日期";
                col.Width = 100;
                col.Visible = false;
                col.DisplayIndex = i++;

                col = grid.Columns["LastFollowUpTime"];
                col.HeaderText = "最后跟进时间";
                col.Width = 100;
                col.DisplayIndex = i++;

                col = grid.Columns["LastFollowUpBriefing"];
                col.HeaderText = "最后跟进摘要";
                col.Width = 150;
                col.DisplayIndex = i++;

                col = grid.Columns["LastFollowUpState"];
                col.HeaderText = "最后跟进状态";
                col.Width = 100;
                col.DisplayIndex = i++;
            }
        }

        private void DataGridViewCustomerInfo_SelectionChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridViewCustomerInfo_Click(object sender, EventArgs e)
        {

        }

        private void DataGridViewCustomerInfo_DoubleClick(object sender, EventArgs e)
        {
            try { }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridViewCustomerInfo_MouseClick(object sender, MouseEventArgs e)
        {
            try { }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridViewCustomerInfo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try { }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridViewCustomerInfo_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                int rowIndex = e.RowIndex;
                int count = DataGridViewCustomerInfo.SelectedRows.Count;

                contextMenuStrip1.Items.Clear();

                ToolStripMenuItem tsmiAdd = CreateAddCustomerInfoMenuItem();
                contextMenuStrip1.Items.Add(tsmiAdd);

                if (count > 0)
                {
                    bool contains = DataGridViewCustomerInfo.SelectedRows.Contains(DataGridViewCustomerInfo.Rows[rowIndex]);
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
                        DataGridViewCustomerInfo.ClearSelection();
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

        private void DataGridViewCustomerInfo_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                //int rowIndex = e.RowIndex;
                //int count = DataGridViewCustomerInfo.SelectedRows.Count;
                //if (count > 0)
                //{
                //    var row = DataGridViewCustomerInfo.Rows[rowIndex];
                //    bool contains = DataGridViewCustomerInfo.SelectedRows.Contains(row);
                //    if (contains)
                //    {
                //        EditDataGridViewRow(row);
                //    }
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridViewCustomerInfo_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            try
            {
                ////显示在HeaderCell上
                //for (int i = 0; i < this.DataGridViewCustomerInfo.Rows.Count; i++)
                //{
                //    DataGridViewRow r = this.DataGridViewCustomerInfo.Rows[i];
                //    r.HeaderCell.Value = string.Format("{0}", i + 1);
                //}
                //this.DataGridViewCustomerInfo.Refresh();
                e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private ToolStripMenuItem CreateAddCustomerInfoMenuItem()
        {
            ToolStripMenuItem tsmiAdd = new ToolStripMenuItem();
            tsmiAdd.Text = "新增客户信息";
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
                FrmCustomerInfo frmCustomerInfo = new FrmCustomerInfo
                {
                    WorkingState = WorkingState.Add,
                    Seller = this.UserName
                };
                DialogResult dialogResult = frmCustomerInfo.ShowDialog(this);
                if (DialogResult.OK == dialogResult)
                {
                    LoadAllCustomer(this.UserName);
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
                EditDataGridViewRow(DataGridViewCustomerInfo.SelectedRows[0]);
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
                DialogResult dialogResult = MessageBox.Show(this, "您确定要删除所选客户信息吗，删除后将不可恢复？", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (DialogResult.Yes == dialogResult)
                {
                    int count = DataGridViewCustomerInfo.SelectedRows.Count;
                    for (int i = 0; i < count; i++)
                    {
                        var row = DataGridViewCustomerInfo.SelectedRows[i];
                        object objId = row.Cells["Id"].Value;
                        int id = Convert.ToInt32(objId);
                        int result = TableCustomerManage.DeleteCustomerById(id);
                        if (result <= 0)
                        {
                            string email = row.Cells["Email"].Value.ToString();
                            MessageBox.Show(this, "删除客户 " + email + " 信息失败！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    LoadAllCustomer(this.UserName);
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
            LoadAllCustomer(this.UserName);
        }

        private void EditDataGridViewRow(DataGridViewRow row)
        {
            DataRow dataRow = (row.DataBoundItem as DataRowView).Row;
            var item = dataRow.ToExpression<CustomerInfo>();
            //Console.WriteLine("item:" + item);
            FrmCustomerInfo frmCustomerInfo = new FrmCustomerInfo
            {
                WorkingState = WorkingState.Modify,
                Customer = item(dataRow),
                Seller = this.UserName
            };
            DialogResult dialogResult = frmCustomerInfo.ShowDialog(this);
            if (DialogResult.OK == dialogResult)
            {
                LoadAllCustomer(this.UserName);
            }
        }

        private void LblUserName_Click(object sender, EventArgs e)
        {

        }

        private void BtnAccountManage_Click(object sender, EventArgs e)
        {
            FrmAccountManager frmAccountManager = new FrmAccountManager
            {
                UserName = this.UserName
            };
            DialogResult dialogResult = frmAccountManager.ShowDialog(this);
            if(DialogResult.No == dialogResult)
            {
                if (LoginState.Login == this.LoginState)
                {
                    TableUsersManage.ModifyUserLogoutById(DateTime.Now.ToLocalTime().ToString(), this.LoginLogId);
                    SetLoginState(LoginState.Logout);
                }
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            try
            {
                if (LoginState.Login == this.LoginState)
                {
                    DialogResult dialogResult = MessageBox.Show(this, "您确定要退出当前账户 " + this.UserName + " ?", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (DialogResult.OK == dialogResult)
                    {
                        TableUsersManage.ModifyUserLogoutById(DateTime.Now.ToLocalTime().ToString(), this.LoginLogId);
                        SetLoginState(LoginState.Logout);
                    }
                    else
                    {

                    }
                }
                else if (LoginState.Logout == this.LoginState)
                {
                    Login();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetLoginState(LoginState state)
        {
            this.LoginState = state;
            if (LoginState.Login == state)
            {
                label1.Visible = true;
                LblUserName.Text = this.UserName;
                this.BtnAccountManage.Visible = true;
                this.BtnExit.Text = "退出";
            }
            else
            {
                this.UserName = "";
                label1.Visible = false;
                LblUserName.Text = "";
                this.BtnAccountManage.Visible = false;
                this.BtnExit.Text = "登录";

                DataTable dt = (DataTable)this.DataGridViewCustomerInfo.DataSource;
                dt.Rows.Clear();
                this.DataGridViewCustomerInfo.DataSource = dt;
            }
        }

        private void Login()
        {
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.ShowDialog(this);
            if (DialogResult.OK != frmLogin.DialogResult)
            {
                this.Close();
                return;
            }

            this.User = frmLogin.User;
            this.UserName = frmLogin.UserName;
            this.LoginLogId = frmLogin.LoginLogId;

            SetLoginState(LoginState.Login);

            LoadAllCustomer(this.UserName);
        }
    }
}
