using SqlLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace CFUManageSystem
{
    public partial class FrmMain : Form
    {
        public string UserName { get; set; }
        //private List<object> SelectedCustomerIds { get; set; }

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            try
            {
                FrmLogin frmLogin = new FrmLogin();
                frmLogin.ShowDialog(this);
                if (DialogResult.OK != frmLogin.DialogResult)
                {
                    this.Close();
                    return;
                }
                this.UserName = frmLogin.UserName;

                LblUserName.Text = UserName;

                DataSet dataSet = CFUSystem.QueryCustomerInfoBySellerName(this.UserName);
                DataGridViewCustomerInfo.DataSource = dataSet;
                DataGridViewCustomerInfo.DataMember = "TB_CustomerInfo";
                FormatDataGridView(DataGridViewCustomerInfo);

                //this.SelectedCustomerIds = new List<object>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
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
                col.HeaderText = "地址";
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
                col.HeaderText = "最后跟踪时间";
                col.Width = 100;
                col.DisplayIndex = i++;

                col = grid.Columns["LastFollowUpBriefing"];
                col.HeaderText = "最后跟踪简报";
                col.Width = 150;
                col.DisplayIndex = i++;

                col = grid.Columns["LastFollowUpState"];
                col.HeaderText = "最后跟踪状态";
                col.Width = 100;
                col.DisplayIndex = i++;
            }
        }

        private void DataGridViewCustomerInfo_SelectionChanged(object sender, EventArgs e)
        {
            int count = DataGridViewCustomerInfo.SelectedRows.Count;

            contextMenuStrip1.Items.Clear();

            ToolStripMenuItem tsmiAdd = new ToolStripMenuItem();
            tsmiAdd.Text = "新增客户信息";
            tsmiAdd.Click += TsmiAdd_Click;
            contextMenuStrip1.Items.Add(tsmiAdd);

            if (count > 0)
            {
                if (1 == count)
                {
                    ToolStripMenuItem tsmiEdit = new ToolStripMenuItem();
                    tsmiEdit.Text = "编辑";
                    tsmiEdit.Click += TsmiEdit_Click;
                    contextMenuStrip1.Items.Add(tsmiEdit);
                }

                ToolStripMenuItem tsmiDelete = new ToolStripMenuItem();
                tsmiDelete.Text = "删除";
                tsmiDelete.Click += TsmiDelete_Click;
                contextMenuStrip1.Items.Add(tsmiDelete);
            }
        }

        private void TsmiAdd_Click(object sender, EventArgs e)
        {
            FrmCustomerInfo frmCustomerInfo = new FrmCustomerInfo();
            frmCustomerInfo.WorkingState = WorkingState.Add;
            frmCustomerInfo.Seller = this.UserName;
            DialogResult dialogResult = frmCustomerInfo.ShowDialog(this);
            if (DialogResult.OK == dialogResult)
            {

            }
        }

        private void TsmiEdit_Click(object sender, EventArgs e)
        {
            try
            {
                object objId = DataGridViewCustomerInfo.SelectedRows[0].Cells["Id"];
                int id = Convert.ToInt32(objId);
                FrmCustomerInfo frmCustomerInfo = new FrmCustomerInfo
                {
                    WorkingState = WorkingState.Modify,
                    CustomerId = id,
                    Seller = this.UserName
                };
                DialogResult dialogResult = frmCustomerInfo.ShowDialog(this);
                if (DialogResult.OK == dialogResult)
                {

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

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
