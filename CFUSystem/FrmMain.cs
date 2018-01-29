using SqlLibrary;
using SqlLibrary.DataStructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace CFUSystem
{
    public partial class FrmMain : Form
    {
        private const int PageSize = 50;
        private const string AllUsers = "所有";

        public UserInfo User { get; set; }
        public string UserName { get; set; }
        public int LoginLogId { get; set; }
        private DataSet dataSet { get; set; }
        private LoginState LoginState { get; set; }
        private int TotalNumber { get; set; }
        private int TotalPageNumber { get; set; }
        private int PageNumber { get; set; }
        private List<UserInfo> Users { get; set; }

        public FrmMain()
        {
            InitializeComponent();

            this.Text = this.Text + " - v" + Application.ProductVersion;

            this.Users = new List<UserInfo>();
            //this.PageNumber = 1;

            //LoadAllUsers();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            try
            {
                //LoadAllUsers();

                if(Login())
                {
                    //LoadAllUsers();

                    LoadCustomerInPage(1);

                    ToolStripMenuItem tsmiAdd = CreateAddCustomerInfoMenuItem();
                    contextMenuStrip1.Items.Add(tsmiAdd);

                    ToolStripSeparator tss = new ToolStripSeparator();
                    contextMenuStrip1.Items.Add(tss);

                    ToolStripMenuItem tsmiRefresh = CreateRefreshCustomerInfoMenuItem();
                    contextMenuStrip1.Items.Add(tsmiRefresh);
                }
                else
                {
                    this.Close();
                }
                
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

        private void LoadCustomerInPage(int page)
        {
            if (page < 1)
            {
                this.PageNumber = 1;
            }
            else if (page > this.TotalPageNumber)
            {
                this.PageNumber = this.TotalPageNumber;
            }
            else
            {
                this.PageNumber = page;
            }

            DataGridViewCustomerInfo.ClearSelection();

            DataTable dataTable = new DataTable();
            if (this.UserName.Equals(AllUsers))
            {
                dataTable = TableCustomerManage.QueryCustomerByPage(this.PageNumber, PageSize);
            }
            else
            {
                dataTable = TableCustomerManage.QueryCustomerByUserNameAndPage(this.UserName, this.PageNumber, PageSize);
            }

            DataGridViewCustomerInfo.DataSource = dataTable;
            FormatDataGridView(DataGridViewCustomerInfo);

            LblCurPage.Text = this.PageNumber + "/" + this.TotalPageNumber;
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

                col = grid.Columns["Wechat"];
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

                col = grid.Columns["Demand"];
                col.HeaderText = "需求";
                col.Width = 100;
                col.DisplayIndex = i++;

                col = grid.Columns["Loyalty"];
                col.HeaderText = "忠诚度";
                col.Width = 100;
                col.DisplayIndex = i++;

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

                col = grid.Columns["BelongsTo"];
                col.HeaderText = "客户归属";
                col.Width = 120;
                col.DisplayIndex = i++;

                col = grid.Columns["UsedBrands"];
                col.Visible = false;

                col = grid.Columns["DecisionMaker"];
                col.Visible = false;

                col = grid.Columns["NewProductRecommendReactionAcuity"];
                col.Visible = false;

                col = grid.Columns["Religion"];
                col.Visible = false;

                col = grid.Columns["CharacterTraits"];
                col.Visible = false;

                col = grid.Columns["AmountStratification"];
                col.Visible = false;

                col = grid.Columns["NormalCommunication"];
                col.Visible = false;

                col = grid.Columns["NormalPayment"];
                col.Visible = false;

                col = grid.Columns["CustomerSize"];
                col.Visible = false;

                col = grid.Columns["DeliveryTimeSensitivity"];
                col.Visible = false;

                col = grid.Columns["ProductFactors"];
                col.Visible = false;
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
                DataGridViewRow dataGridViewRow = DataGridViewCustomerInfo.Rows[e.RowIndex];
                EditDataGridViewRow(dataGridViewRow);
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
                e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1 + ((this.PageNumber - 1) * PageSize));
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAccountManage_Click(object sender, EventArgs e)
        {
            FrmAccountManager frmAccountManager = new FrmAccountManager
            {
                //UserName = this.UserName
                User = this.User,
            };
            DialogResult dialogResult = frmAccountManager.ShowDialog(this);
            if (DialogResult.No == dialogResult)
            {
                if (LoginState.Login == this.LoginState)
                {
                    TableUsersManage.ModifyUserLogoutById(DateTime.Now.ToLocalTime().ToString(), this.LoginLogId);
                    SetLoginState(LoginState.Logout);
                }
            }

            DataTable dataTable = TableUsersManage.QueryUserByUserId(this.User.Id);
            DataRow dataRow = dataTable.Rows[0];
            var item = dataRow.ToExpression<UserInfo>();
            this.User = item(dataRow);
            this.LblUserName.Text = this.User.Nickname;
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            try
            {
                if (LoginState.Login == this.LoginState)
                {
                    DialogResult dialogResult = MessageBox.Show(this, "您确定要退出当前账户 " + this.User.Name + " ?", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
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

        private void BtnAddCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                AddCustomer();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnFirstPage_Click(object sender, EventArgs e)
        {
            try
            {
                LoadCustomerInPage(1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnPrePage_Click(object sender, EventArgs e)
        {
            try
            {
                LoadCustomerInPage(--this.PageNumber);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnNextPage_Click(object sender, EventArgs e)
        {
            try
            {
                LoadCustomerInPage(++this.PageNumber);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnLastPage_Click(object sender, EventArgs e)
        {
            try
            {
                LoadCustomerInPage(this.TotalPageNumber);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ComboBoxSeller_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.UserName = ComboBoxSeller.Text;
                RefreshCustomer();
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
                AddCustomer();
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

                    LoadCustomerInPage(this.PageNumber);
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
            LoadCustomerInPage(this.PageNumber);
        }

        private void AddCustomer()
        {
            FrmCustomerInfo frmCustomerInfo = new FrmCustomerInfo
            {
                WorkingState = WorkingState.Add,
                //Seller = this.UserName
                User = this.User,
            };
            DialogResult dialogResult = frmCustomerInfo.ShowDialog(this);
            //if (DialogResult.OK == dialogResult)
            //{
            RefreshCustomer();
                LoadCustomerInPage(this.PageNumber);
            //}
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
                //Seller = this.UserName
                User = this.User,
            };
            DialogResult dialogResult = frmCustomerInfo.ShowDialog(this);
            if (DialogResult.OK == dialogResult)
            {
                LoadCustomerInPage(this.PageNumber);
            }
        }

        private void SetLoginState(LoginState state)
        {
            this.LoginState = state;
            if (LoginState.Login == state)
            {
                label1.Visible = true;
                LblUserName.Text = this.User.Nickname;
                this.BtnAccountManage.Visible = true;
                this.BtnExit.Text = "退出";
                //this.ComboBoxSeller.Enabled = true;
                this.tableLayoutPanel3.Enabled = true;
            }
            else
            {
                this.UserName = "";
                label1.Visible = false;
                LblUserName.Text = "";
                this.ComboBoxSeller.Visible = false;
                this.BtnAccountManage.Visible = false;
                this.BtnExit.Text = "登录";
                //this.ComboBoxSeller.Enabled = false;
                this.tableLayoutPanel3.Enabled = false;

                DataTable dt = (DataTable)this.DataGridViewCustomerInfo.DataSource;
                dt.Rows.Clear();
                this.DataGridViewCustomerInfo.DataSource = dt;
            }


        }

        private bool Login()
        {
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.ShowDialog(this);
            if (DialogResult.OK != frmLogin.DialogResult)
            {
                this.Close();
                return false;
            }

            LoadAllUsers();

            this.User = frmLogin.User;
            this.UserName = frmLogin.UserName;
            this.LoginLogId = frmLogin.LoginLogId;
            this.ComboBoxSeller.Text = this.UserName;

            if (PrivilegeLevel.Administrative == this.User.Privilege)
            {
                this.ComboBoxSeller.Visible = true;
            }
            else
            {
                this.ComboBoxSeller.Visible = false;
            }

            SetLoginState(LoginState.Login);

            RefreshCustomer();

            return true;
        }

        private void LoadAllUsers()
        {
            this.Users.Clear();
            this.ComboBoxSeller.Items.Clear();

            this.ComboBoxSeller.Items.Add(AllUsers);

            DataTable dataTable = TableUsersManage.QueryAllUsers();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                var item = dataRow.ToExpression<UserInfo>();
                UserInfo user = item(dataRow);
                this.Users.Add(user);

                this.ComboBoxSeller.Items.Add(user.Name);
            }

            this.ComboBoxSeller.Text = AllUsers;
            this.UserName = AllUsers;

            RefreshCustomer();
        }

        private void RefreshCustomer()
        {
            if (this.UserName.Equals(AllUsers))
            {
                this.TotalNumber = TableCustomerManage.QueryAllCustomerNumber();
            }
            else
            {
                this.TotalNumber = TableCustomerManage.QueryCustomerNumberByUserName(this.User.Name);
            }
            this.TotalPageNumber = this.TotalNumber % PageSize == 0 ? this.TotalNumber / PageSize : this.TotalNumber / PageSize + 1;

            LoadCustomerInPage(1);
        }
    }
}
