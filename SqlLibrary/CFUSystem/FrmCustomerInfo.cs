using SqlLibrary;
using System;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CFUManageSystem
{
    public partial class FrmCustomerInfo : Form
    {
        public WorkingState WorkingState { get; set; }

        public string Seller { get; set; }
        public string Email { get; set; }
        public int CustomerId { get; set; }

        public FrmCustomerInfo()
        {
            InitializeComponent();
        }

        private void FrmCustomerInfo_Load(object sender, EventArgs e)
        {
            ComboBoxSort.SelectedIndex = 0;
            ComboBoxState.SelectedIndex = 0;

            if (WorkingState.Add == this.WorkingState)
            {
                tabControl1.SizeMode = TabSizeMode.Fixed;
                tabControl1.ItemSize = new Size(0, 1);
                tabControl1.TabPages.Remove(tabPage2);

                BtnPrevious.Visible = false;
                BtnNext.Enabled = false;
                BtnFinish.Visible = false;
            }
            else if (WorkingState.Modify == this.WorkingState)
            {
                BtnPrevious.Visible = false;
                BtnNext.Visible = false;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            this.Close();
        }

        private void BtnPrevious_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.TabPages.Add(tabPage1);
            tabControl1.SelectedTab = tabPage1;

            BtnPrevious.Visible = false;
            BtnNext.Visible = true;
            BtnFinish.Visible = false;
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabPage1);
            tabControl1.TabPages.Add(tabPage2);
            tabControl1.SelectedTab = tabPage2;

            BtnPrevious.Visible = true;
            BtnNext.Visible = false;

            if (!string.IsNullOrWhiteSpace(TxtBoxBriefing.Text))
            {
                BtnFinish.Visible = true;
            }
        }

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                string email = TxtBoxEmail.Text.Trim();
                string archivingDate = DTPArchiving.Value.ToLocalTime().ToString();
                string sort = ComboBoxSort.Text;
                string contacts = TxtBoxContacts.Text;
                string company = TxtBoxCompanyName.Text;
                string website = TxtBoxWebsite.Text;
                string country = TxtBoxCountry.Text;
                string address = TxtBoxAddress.Text;
                string scope = TxtBoxBusinessScope.Text;
                string type = TxtBoxType.Text;
                string demand = TxtBoxDemand.Text;
                string telephone = TxtBoxTelephone.Text;
                string fax = TxtBoxFax.Text;
                string mobile = TxtBoxMobile.Text;
                string msn = TxtBoxMSN.Text;
                string skype = TxtBoxSkype.Text;
                string linkin = TxtBoxLinkin.Text;
                string whatsapp = TxtBoxWhatsApp.Text;
                string twiter = TxtBoxTwiter.Text;
                string facebook = TxtBoxFacebook.Text;
                string comefrom = TxtBoxComeFrom.Text;
                string belongsto = TxtBoxBelongsTo.Text;
                string remarks = TxtBoxRemarks.Text;
                string datetime = DateTime.Now.ToLocalTime().ToString();

                if (WorkingState.Add == this.WorkingState)
                {
                    int identity = CFUSystem.AddCustomerReturnIdentity(archivingDate, sort,
                        contacts, email,
                        company, website,
                        country, address,
                        scope, type, demand,
                        telephone, fax, mobile, msn, skype, linkin, whatsapp, twiter, facebook,
                        comefrom, belongsto,
                        remarks, datetime);
                    if (identity > 0)
                    {
                        this.CustomerId = identity;
                        bool result = AddFollowUpLog(identity);
                        if (result)
                        {
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                }
                else if (WorkingState.Modify == this.WorkingState)
                {

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private bool AddFollowUpLog(int customerId)
        {
            bool result = false;

            try
            {
                string email = TxtBoxEmail.Text.Trim();
                string company = TxtBoxCompanyName.Text;
                int number = Convert.ToInt32(NumUpDownNumber.Value);
                string datetime = DTPDate.Value.ToLocalTime().ToString();
                string state = ComboBoxState.Text;
                string briefing = TxtBoxBriefing.Text;
                string content = RichTxtBoxContent.Text;
                string modify = DateTime.Now.ToLocalTime().ToString();

                result = CFUSystem.AddFollowUpLog(email, company, customerId,
                    number, datetime, state,
                    briefing, content,
                    modify, this.Seller);
                if (result)
                {
                    LoadAllLogs(customerId);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        private void LoadAllLogs(int CustomerId)
        {
            //DataSet dataSet = CFUSystem.QueryCustomerFollowUpLogsByEmail(this.Email);
            DataSet dataSet = TableCustomerManage.QueryFollowUpLogsByCustomerId(CustomerId);
            DataGridViewFollowUpLogs.DataSource = dataSet;
            DataGridViewFollowUpLogs.DataMember = "TB_CustomerFollowUpLogs";
            FormatDataGridView(DataGridViewFollowUpLogs);
        }

        private void FormatDataGridView(DataGridView grid)
        {
            if (grid.Columns.Count > 1)
            {
                int i = 0;

                var col = grid.Columns["Id"];
                col.Visible = false;

                col = grid.Columns["CompanyName"];
                col.Visible = false;

                col = grid.Columns["Email"];
                col.Visible = false;

                col = grid.Columns["Number"];
                col.HeaderText = "次数";
                col.Width = 100;
                col.ReadOnly = true;
                col.DisplayIndex = i++;

                col = grid.Columns["State"];
                col.HeaderText = "状态";
                col.Width = 100;
                col.ReadOnly = true;
                col.DisplayIndex = i++;

                col = grid.Columns["Time"];
                col.HeaderText = "时间";
                col.Width = 100;
                col.ReadOnly = true;
                col.DisplayIndex = i++;

                col = grid.Columns["Briefing"];
                col.HeaderText = "摘要";
                col.Width = 400;
                col.ReadOnly = true;
                col.DisplayIndex = i++;

                col = grid.Columns["Content"];
                col.Visible = false;

                col = grid.Columns["Modify"];
                col.Visible = false;

                col = grid.Columns["BelongsTo"];
                col.Visible = false;
            }
        }

        private void TxtBoxEmail_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TxtBoxEmail.Text)) {
                Regex regex = new Regex("^\\s*([A-Za-z0-9_-]+(\\.\\w+)*@(\\w+\\.)+\\w{2,5})\\s*$");
                if (regex.IsMatch(TxtBoxEmail.Text))
                {
                    if (WorkingState.Add == this.WorkingState)
                    {
                        BtnNext.Enabled = true;
                        BtnFinish.Enabled = true;
                    }
                    else if (WorkingState.Modify == this.WorkingState)
                    {
                        BtnFinish.Enabled = true;
                    }

                    return;
                }
            }

            if (WorkingState.Add == this.WorkingState)
            {
                BtnNext.Enabled = false;
                BtnFinish.Enabled = false;
            }
            else if (WorkingState.Modify == this.WorkingState)
            {
                BtnFinish.Enabled = false;
            }
        }

        private void TxtBoxBriefing_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtBoxBriefing.Text))
            {
                BtnFinish.Enabled = false;
            }
            else
            {
                BtnFinish.Enabled = true;
            }
        }
    }
}
