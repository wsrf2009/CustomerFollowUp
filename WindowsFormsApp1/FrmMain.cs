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

        public FrmMain()
        {
            InitializeComponent();

            //DataGridViewCustomerInfo.AutoGenerateColumns = false;
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

        private void BtnAddCustomerInfo_Click(object sender, EventArgs e)
        {
            FrmCustomerInfo frmCustomerInfo = new FrmCustomerInfo();
            DialogResult dialogResult = frmCustomerInfo.ShowDialog(this);
            if (DialogResult.OK == dialogResult)
            {

            }
        }
    }
}
