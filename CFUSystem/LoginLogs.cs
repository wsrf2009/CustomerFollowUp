using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SqlLibrary;

namespace CFUSystem
{
    public partial class LoginLogs : UserControl
    {
        private const int PageSize = 50;

        public bool LoadAllUsers { get; set; }
        public string UserName { get; set; }
        private int TotalCount { get; set; }
        private int TotalPageNumber { get; set; }
        private int PageNumber { get; set; }

        public LoginLogs()
        {
            InitializeComponent();
        }

        private void LoginLogs_Load(object sender, EventArgs e)
        {
            try
            {
                if (LoadAllUsers)
                {
                    this.TotalCount = TableUsersManage.QueryAllLoginLogsNumber();
                    //this.TotalPageNumber = this.TotalCount % PageSize == 0 ? this.TotalCount / PageSize : this.TotalCount / PageSize + 1;
                    //this.PageNumber = 1;

                    //DataTable dataTable = TableUsersManage.QueryAllLoginLogs();
                    //this.dataGridView1.DataSource = dataTable;
                    //FormatDataGridView(this.dataGridView1);
                }
                else if (!string.IsNullOrWhiteSpace(this.UserName))
                {
                    this.TotalCount = TableUsersManage.QueryLoginLogsNumberByUserName(this.UserName);

                    //DataTable dataTable = TableUsersManage.QueryLoginLogsByUserName(this.UserName);
                    //this.dataGridView1.DataSource = dataTable;
                    //FormatDataGridView(this.dataGridView1);
                }

                this.TotalPageNumber = this.TotalCount % PageSize == 0 ? this.TotalCount / PageSize : this.TotalCount / PageSize + 1;
                this.PageNumber = 1;
                LoadLoginLogsInPage(this.PageNumber);

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

                col = grid.Columns["Login"];
                col.HeaderText = "登陆时间";
                col.Width = 120;
                col.DisplayIndex = i++;

                col = grid.Columns["LoginLanIp"];
                col.HeaderText = "登录IP";
                col.Width = 150;
                col.DisplayIndex = i++;

                col = grid.Columns["LoginWanIp"];
                col.Visible = false;

                col = grid.Columns["LoginMAC"];
                col.HeaderText = "登录MAC";
                col.Width = 150;
                col.DisplayIndex = i++;

                col = grid.Columns["LoginHostName"];
                if (LoadAllUsers)
                {
                    col.HeaderText = "登录主机名";
                    col.Width = 180;
                    col.DisplayIndex = i++;
                }
                else
                {
                    col.Visible = false;
                }

                col = grid.Columns["LoginUserName"];
                if (LoadAllUsers)
                {
                    col.HeaderText = "主机用户名";
                    col.Width = 180;
                    col.DisplayIndex = i++;
                }
                else
                {
                    col.Visible = false;
                }

                col = grid.Columns["Logout"];
                if (LoadAllUsers)
                {
                    col.HeaderText = "退出时间";
                    col.Width = 150;
                    col.DisplayIndex = i++;
                }
                else
                {
                    col.Visible = false;
                }

                col = grid.Columns["Uid"];
                col.Visible = false;
            }
        }

        private void LoadLoginLogsInPage(int page)
        {
            DataTable dataTable = new DataTable();

            if (LoadAllUsers)
            {
                dataTable = TableUsersManage.QueryAllLoginLogsByPage(page, PageSize);
            }
            else if (!string.IsNullOrWhiteSpace(this.UserName))
            {
                dataTable = TableUsersManage.QueryLoginLogsByUserNameAndPage(this.UserName, page, PageSize);
            }

            this.dataGridView1.DataSource = dataTable;
            FormatDataGridView(this.dataGridView1);

            LblCurPage.Text = this.PageNumber + "/" + this.TotalPageNumber;
        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            try
            {
                e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1 + ((this.PageNumber -1) * PageSize));
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnFirstPage_Click(object sender, EventArgs e)
        {
            this.PageNumber = 1;
            LoadLoginLogsInPage(this.PageNumber);
        }

        private void BtnPrePage_Click(object sender, EventArgs e)
        {
            this.PageNumber--;
            if (this.PageNumber < 1) this.PageNumber = 1;
            LoadLoginLogsInPage(this.PageNumber);
        }

        private void BtnNextPage_Click(object sender, EventArgs e)
        {
            this.PageNumber++;
            if (this.PageNumber > this.TotalPageNumber) this.PageNumber = this.TotalPageNumber;
            LoadLoginLogsInPage(this.PageNumber);
        }

        private void BtnLastPage_Click(object sender, EventArgs e)
        {
            this.PageNumber = this.TotalPageNumber;
            LoadLoginLogsInPage(this.PageNumber);
        }
    }
}
