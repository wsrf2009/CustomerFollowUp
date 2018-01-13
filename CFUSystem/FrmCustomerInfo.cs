using SqlLibrary;
using SqlLibrary.DataStructure;
using System;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CFUSystem
{
    public partial class FrmCustomerInfo : Form
    {
        public WorkingState WorkingState { get; set; }

        private CustomerInfo _Customer;
        public CustomerInfo Customer
        {
            get
            {
                if (null == _Customer)
                {
                    _Customer = new CustomerInfo();
                }

                return _Customer;
            }
            set { _Customer = value; }
        }
        public string Seller { get; set; }

        public FrmCustomerInfo()
        {
            InitializeComponent();
        }

        private void FrmCustomerInfo_Load(object sender, EventArgs e)
        {
            try
            {
                ComboBoxSort.SelectedIndex = 0;
                //ComboBoxState.SelectedIndex = 0;

                if (WorkingState.Add == this.WorkingState)
                {
                    tabControl1.TabPages.Remove(tabPage2);

                    TxtBoxBelongsTo.Text = this.Seller;

                    SetCustomerInfoWorkingState(WorkingState.Add);
                }
                else if (WorkingState.Modify == this.WorkingState)
                {
                    DTPArchiving.Value = Convert.ToDateTime(this.Customer.ArchivingTime);
                    ComboBoxSort.Text = this.Customer.Sort;
                    TxtBoxContacts.Text = this.Customer.Contacts;
                    TxtBoxEmail.Text = this.Customer.Email;
                    TxtBoxCompanyName.Text = this.Customer.CompanyName;
                    TxtBoxWebsite.Text = this.Customer.Website;
                    TxtBoxCountry.Text = this.Customer.Country;
                    TxtBoxAddress.Text = this.Customer.Address;
                    TxtBoxBusinessScope.Text = this.Customer.BusinessScope;
                    TxtBoxType.Text = this.Customer.Type;
                    TxtBoxDemand.Text = this.Customer.Demand;
                    TxtBoxTelephone.Text = this.Customer.Telephone;
                    TxtBoxFax.Text = this.Customer.FAX;
                    TxtBoxMobile.Text = this.Customer.Mobile;
                    TxtBoxMSN.Text = this.Customer.MSN;
                    TxtBoxSkype.Text = this.Customer.Skype;
                    TxtBoxLinkin.Text = this.Customer.Linkin;
                    TxtBoxWhatsApp.Text = this.Customer.Whatsapp;
                    TxtBoxTwiter.Text = this.Customer.Twiter;
                    TxtBoxFacebook.Text = this.Customer.Facebook;
                    TxtBoxComeFrom.Text = this.Customer.ComeFrom;
                    TxtBoxBelongsTo.Text = this.Customer.BelongsTo;
                    TxtBoxRemarks.Text = this.Customer.Remarks;

                    LoadAllLogs(this.Customer.Id);

                    SetCustomerInfoWorkingState(WorkingState.Modify);
                }

                ToolStripMenuItem tsmiAdd = CreateAddFollowUpLogMenuItem();
                contextMenuStrip1.Items.Add(tsmiAdd);

                ToolStripSeparator tss = new ToolStripSeparator();
                contextMenuStrip1.Items.Add(tss);

                ToolStripMenuItem tsmiRefresh = CreateRefreshFollowUpLogMenuItem();
                contextMenuStrip1.Items.Add(tsmiRefresh);

                //BtnLogSave.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DTPArchiving_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                string cur = DTPArchiving.Value.ToLocalTime().ToString();
                if (WorkingState.Modify == this.WorkingState)
                {
                    if (this.Customer.ArchivingTime.Equals(cur))
                    {
                        BtnInfoSave.Enabled = false;
                    }
                    else
                    {
                        BtnInfoSave.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ComboBoxSort_TextUpdate(object sender, EventArgs e)
        {
            try
            {
                string cur = ComboBoxSort.Text;
                if (WorkingState.Modify == this.WorkingState)
                {
                    if (this.Customer.Sort.Equals(cur))
                    {
                        BtnInfoSave.Enabled = false;
                    }
                    else
                    {
                        BtnInfoSave.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtBoxContacts_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string cur = TxtBoxContacts.Text;
                if (cur.Contains("'"))
                {
                    MessageBox.Show(this, "含有非法字符 \"'\" !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    TxtBoxContacts.Focus();
                }
                else if (WorkingState.Modify == this.WorkingState)
                {
                    if (this.Customer.Contacts.Equals(cur))
                    {
                        BtnInfoSave.Enabled = false;
                    }
                    else
                    {
                        BtnInfoSave.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtBoxEmail_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Regex regex = new Regex("^\\s*([A-Za-z0-9_-]+(\\.\\w+)*@(\\w+\\.)+\\w{2,5})\\s*$");
                if (regex.IsMatch(TxtBoxEmail.Text))
                {
                    if (WorkingState.Add == this.WorkingState)
                    {
                        BtnInfoSave.Enabled = true;
                    }
                    else if (WorkingState.Modify == this.WorkingState)
                    {
                        BtnInfoSave.Enabled = true;
                    }

                    return;
                }

                if (WorkingState.Add == this.WorkingState)
                {
                    BtnInfoSave.Enabled = false;
                }
                else if (WorkingState.Modify == this.WorkingState)
                {
                    BtnInfoSave.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void TxtBoxCompanyName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string cur = TxtBoxCompanyName.Text;
                if (cur.Contains("'"))
                {
                    MessageBox.Show(this, "含有非法字符 \"'\" !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    TxtBoxCompanyName.Focus();
                }
                else if (WorkingState.Modify == this.WorkingState)
                {
                    if (this.Customer.CompanyName.Equals(cur))
                    {
                        BtnInfoSave.Enabled = false;
                    }
                    else
                    {
                        BtnInfoSave.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtBoxWebsite_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string cur = TxtBoxWebsite.Text;
                if (cur.Contains("'"))
                {
                    MessageBox.Show(this, "含有非法字符 \"'\" !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    TxtBoxWebsite.Focus();
                }
                else if (WorkingState.Modify == this.WorkingState)
                {
                    if (this.Customer.Website.Equals(cur))
                    {
                        BtnInfoSave.Enabled = false;
                    }
                    else
                    {
                        BtnInfoSave.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtBoxCountry_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string cur = TxtBoxCountry.Text;
                if (cur.Contains("'"))
                {
                    MessageBox.Show(this, "含有非法字符 \"'\" !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    TxtBoxCountry.Focus();
                }
                else if (WorkingState.Modify == this.WorkingState)
                {
                    if (this.Customer.Country.Equals(cur))
                    {
                        BtnInfoSave.Enabled = false;
                    }
                    else
                    {
                        BtnInfoSave.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtBoxAddress_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string cur = TxtBoxAddress.Text;
                if (cur.Contains("'"))
                {
                    MessageBox.Show(this, "含有非法字符 \"'\" !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    TxtBoxAddress.Focus();
                }
                else if (WorkingState.Modify == this.WorkingState)
                {
                    if (this.Customer.Address.Equals(cur))
                    {
                        BtnInfoSave.Enabled = false;
                    }
                    else
                    {
                        BtnInfoSave.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtBoxBusinessScope_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string cur = TxtBoxBusinessScope.Text;
                if (cur.Contains("'"))
                {
                    MessageBox.Show(this, "含有非法字符 \"'\" !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    TxtBoxBusinessScope.Focus();
                }
                else if (WorkingState.Modify == this.WorkingState)
                {
                    if (this.Customer.BusinessScope.Equals(cur))
                    {
                        BtnInfoSave.Enabled = false;
                    }
                    else
                    {
                        BtnInfoSave.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtBoxType_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string cur = TxtBoxType.Text;
                if (cur.Contains("'"))
                {
                    MessageBox.Show(this, "含有非法字符 \"'\" !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    TxtBoxType.Focus();
                }
                else if (WorkingState.Modify == this.WorkingState)
                {
                    if (this.Customer.Type.Equals(cur))
                    {
                        BtnInfoSave.Enabled = false;
                    }
                    else
                    {
                        BtnInfoSave.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtBoxDemand_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string cur = TxtBoxDemand.Text;
                if (cur.Contains("'"))
                {
                    MessageBox.Show(this, "含有非法字符 \"'\" !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    TxtBoxDemand.Focus();
                }
                else if (WorkingState.Modify == this.WorkingState)
                {
                    if (this.Customer.Demand.Equals(cur))
                    {
                        BtnInfoSave.Enabled = false;
                    }
                    else
                    {
                        BtnInfoSave.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtBoxTelephone_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string cur = TxtBoxTelephone.Text;
                if (cur.Contains("'"))
                {
                    MessageBox.Show(this, "含有非法字符 \"'\" !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    TxtBoxTelephone.Focus();
                }
                else if (WorkingState.Modify == this.WorkingState)
                {
                    if (this.Customer.Telephone.Equals(cur))
                    {
                        BtnInfoSave.Enabled = false;
                    }
                    else
                    {
                        BtnInfoSave.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtBoxFax_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string cur = TxtBoxFax.Text;
                if (cur.Contains("'"))
                {
                    MessageBox.Show(this, "含有非法字符 \"'\" !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    TxtBoxFax.Focus();
                }
                else if (WorkingState.Modify == this.WorkingState)
                {
                    if (this.Customer.FAX.Equals(cur))
                    {
                        BtnInfoSave.Enabled = false;
                    }
                    else
                    {
                        BtnInfoSave.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtBoxMobile_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string cur = TxtBoxMobile.Text;
                if (cur.Contains("'"))
                {
                    MessageBox.Show(this, "含有非法字符 \"'\" !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    TxtBoxMobile.Focus();
                }
                else if (WorkingState.Modify == this.WorkingState)
                {
                    if (this.Customer.Mobile.Equals(cur))
                    {
                        BtnInfoSave.Enabled = false;
                    }
                    else
                    {
                        BtnInfoSave.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtBoxMSN_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string cur = TxtBoxMSN.Text;
                if (cur.Contains("'"))
                {
                    MessageBox.Show(this, "含有非法字符 \"'\" !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    TxtBoxMSN.Focus();
                }
                else if (WorkingState.Modify == this.WorkingState)
                {
                    if (this.Customer.MSN.Equals(cur))
                    {
                        BtnInfoSave.Enabled = false;
                    }
                    else
                    {
                        BtnInfoSave.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtBoxSkype_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string cur = TxtBoxSkype.Text;
                if (cur.Contains("'"))
                {
                    MessageBox.Show(this, "含有非法字符 \"'\" !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    TxtBoxSkype.Focus();
                }
                else if (WorkingState.Modify == this.WorkingState)
                {
                    if (this.Customer.Skype.Equals(cur))
                    {
                        BtnInfoSave.Enabled = false;
                    }
                    else
                    {
                        BtnInfoSave.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtBoxLinkin_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string cur = TxtBoxLinkin.Text;
                if (cur.Contains("'"))
                {
                    MessageBox.Show(this, "含有非法字符 \"'\" !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    TxtBoxLinkin.Focus();
                }
                else if (WorkingState.Modify == this.WorkingState)
                {
                    if (this.Customer.Linkin.Equals(cur))
                    {
                        BtnInfoSave.Enabled = false;
                    }
                    else
                    {
                        BtnInfoSave.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtBoxWhatsApp_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string cur = TxtBoxWhatsApp.Text;
                if (cur.Contains("'"))
                {
                    MessageBox.Show(this, "含有非法字符 \"'\" !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    TxtBoxWhatsApp.Focus();
                }
                else if (WorkingState.Modify == this.WorkingState)
                {
                    if (this.Customer.Whatsapp.Equals(cur))
                    {
                        BtnInfoSave.Enabled = false;
                    }
                    else
                    {
                        BtnInfoSave.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtBoxTwiter_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string cur = TxtBoxTwiter.Text;
                if (cur.Contains("'"))
                {
                    MessageBox.Show(this, "含有非法字符 \"'\" !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    TxtBoxTwiter.Focus();
                }
                else if (WorkingState.Modify == this.WorkingState)
                {
                    if (this.Customer.Twiter.Equals(cur))
                    {
                        BtnInfoSave.Enabled = false;
                    }
                    else
                    {
                        BtnInfoSave.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtBoxFacebook_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string cur = TxtBoxFacebook.Text;
                if (cur.Contains("'"))
                {
                    MessageBox.Show(this, "含有非法字符 \"'\" !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    TxtBoxFacebook.Focus();
                }
                else if (WorkingState.Modify == this.WorkingState)
                {
                    if (this.Customer.Facebook.Equals(cur))
                    {
                        BtnInfoSave.Enabled = false;
                    }
                    else
                    {
                        BtnInfoSave.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtBoxComeFrom_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string cur = TxtBoxComeFrom.Text;
                if (cur.Contains("'"))
                {
                    MessageBox.Show(this, "含有非法字符 \"'\" !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    TxtBoxComeFrom.Focus();
                }
                else if (WorkingState.Modify == this.WorkingState)
                {
                    if (this.Customer.ComeFrom.Equals(cur))
                    {
                        BtnInfoSave.Enabled = false;
                    }
                    else
                    {
                        BtnInfoSave.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtBoxBelongsTo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string cur = TxtBoxBelongsTo.Text;
                if (cur.Contains("'"))
                {
                    MessageBox.Show(this, "含有非法字符 \"'\" !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    TxtBoxBelongsTo.Focus();
                }
                else if (WorkingState.Modify == this.WorkingState)
                {
                    if (this.Customer.BelongsTo.Equals(cur))
                    {
                        BtnInfoSave.Enabled = false;
                    }
                    else
                    {
                        BtnInfoSave.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtBoxRemarks_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string cur = TxtBoxRemarks.Text;
                if (cur.Contains("'"))
                {
                    MessageBox.Show(this, "含有非法字符 \"'\" !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    TxtBoxRemarks.Focus();
                }
                else if (WorkingState.Modify == this.WorkingState)
                {
                    if (this.Customer.Remarks.Equals(cur))
                    {
                        BtnInfoSave.Enabled = false;
                    }
                    else
                    {
                        BtnInfoSave.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnInfoSave_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                string email = this.Customer.Email = TxtBoxEmail.Text.Trim();
                string archivingDate = this.Customer.ArchivingTime = DTPArchiving.Value.ToString();
                string sort = this.Customer.Sort = ComboBoxSort.Text.Trim();
                string contacts = this.Customer.Contacts = TxtBoxContacts.Text.Trim();
                string company = this.Customer.CompanyName = TxtBoxCompanyName.Text.Trim();
                string website = this.Customer.Website = TxtBoxWebsite.Text.Trim();
                string country = this.Customer.Country = TxtBoxCountry.Text.Trim();
                string address = this.Customer.Address = TxtBoxAddress.Text.Trim();
                string scope = this.Customer.BusinessScope = TxtBoxBusinessScope.Text.Trim();
                string type = this.Customer.Type = TxtBoxType.Text.Trim();
                string demand = this.Customer.Demand = TxtBoxDemand.Text.Trim();
                string telephone = this.Customer.Telephone = TxtBoxTelephone.Text.Trim();
                string fax = this.Customer.FAX = TxtBoxFax.Text.Trim();
                string mobile = this.Customer.Mobile = TxtBoxMobile.Text.Trim();
                string msn = this.Customer.MSN = TxtBoxMSN.Text.Trim();
                string skype = this.Customer.Skype = TxtBoxSkype.Text.Trim();
                string linkin = this.Customer.Linkin = TxtBoxLinkin.Text.Trim();
                string whatsapp = this.Customer.Whatsapp = TxtBoxWhatsApp.Text.Trim();
                string twiter = this.Customer.Twiter = TxtBoxTwiter.Text.Trim();
                string facebook = this.Customer.Facebook = TxtBoxFacebook.Text.Trim();
                string comefrom = this.Customer.ComeFrom = TxtBoxComeFrom.Text.Trim();
                string belongsto = this.Customer.BelongsTo = TxtBoxBelongsTo.Text.Trim();
                string remarks = this.Customer.Remarks = TxtBoxRemarks.Text.Trim();
                string modify = this.Customer.Modify = DateTime.Now.ToLocalTime().ToString();
                string futime = this.Customer.LastFollowUpTime = "";
                string fubriefing = this.Customer.LastFollowUpBriefing = "";
                string fustate = this.Customer.LastFollowUpState = "";

                if (WorkingState.Add == this.WorkingState)
                {
                    int identity = TableCustomerManage.AddCustomerReturnIdentity(archivingDate, sort,
                        contacts, email,
                        company, website,
                        country, address,
                        scope, type, demand,
                        telephone, fax, mobile, msn, skype, linkin, whatsapp, twiter, facebook,
                        comefrom, belongsto,
                        remarks,
                        modify,
                        futime, fubriefing, fustate);
                    if (identity > 0)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Customer.Id = identity;
                        SetCustomerInfoWorkingState(WorkingState.Modify);

                        DialogResult result = MessageBox.Show(this, "添加客户信息成功！您想要 【是】 继续添加客户跟进日志，【否】 关闭客户信息界面，【取消】 什么也不做", this.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                        if (DialogResult.Yes == result)
                        {
                            tabControl1.TabPages.Add(tabPage2);
                            tabControl1.SelectedTab = tabPage2;
                        }
                        else if (DialogResult.No == result)
                        {
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else if (DialogResult.Cancel == result)
                        {
                            tabControl1.TabPages.Add(tabPage2);
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "添加客户信息不成功！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (WorkingState.Modify == this.WorkingState)
                {
                    int num = TableCustomerManage.ModifyCustomerInfoById(this.Customer.Id,
                        sort,
                        contacts, email,
                        company, website,
                        country, address,
                        scope, type, demand,
                        telephone, fax, mobile, msn, skype, linkin, whatsapp, twiter, facebook,
                        comefrom,
                        remarks, modify);
                    if (num > 0)
                    {
                        this.DialogResult = DialogResult.OK;
                        DialogResult result = MessageBox.Show(this, "更新客户信息成功！您想要 【是】 继续添加客户跟进日志，【否】 关闭客户信息界面，【取消】 什么也不做", this.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                        if (DialogResult.OK == result)
                        {
                            tabControl1.SelectedTab = tabPage2;
                        }
                        else if (DialogResult.No == result)
                        {
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else if (DialogResult.Cancel == result)
                        {

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Cursor.Current = Cursors.Default;
        }

        private void SetCustomerInfoWorkingState(WorkingState state)
        {
            this.WorkingState = state;

            if (WorkingState.Add == state)
            {
                DTPArchiving.Enabled = true;

                BtnInfoSave.Text = "添加";
                BtnInfoSave.Enabled = false;
            }
            else if (WorkingState.Modify == state)
            {
                DTPArchiving.Enabled = false;

                BtnInfoSave.Text = "更新";
                BtnInfoSave.Enabled = false;
            }
        }

        private void DataGridViewFollowUpLogs_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int count = DataGridViewFollowUpLogs.SelectedRows.Count;

                contextMenuStrip1.Items.Clear();

                ToolStripMenuItem tsmiAdd = CreateAddFollowUpLogMenuItem();
                contextMenuStrip1.Items.Add(tsmiAdd);

                if (count > 0)
                {
                    if (1 == count)
                    {
                        ToolStripMenuItem tsmiEdit = CreateEditFollowUpLogMenuItem();
                        contextMenuStrip1.Items.Add(tsmiEdit);
                    }

                    ToolStripMenuItem tsmiDelete = CreateDeleteFollowUpLogMenuItem();
                    contextMenuStrip1.Items.Add(tsmiDelete);
                }

                ToolStripSeparator tss = new ToolStripSeparator();
                contextMenuStrip1.Items.Add(tss);

                ToolStripMenuItem tsmiRefresh = CreateRefreshFollowUpLogMenuItem();
                contextMenuStrip1.Items.Add(tsmiRefresh);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridViewFollowUpLogs_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            try
            {
                ////显示在HeaderCell上
                //for (int i = 0; i < this.DataGridViewFollowUpLogs.Rows.Count; i++)
                //{
                //    DataGridViewRow r = this.DataGridViewFollowUpLogs.Rows[i];
                //    r.HeaderCell.Value = string.Format("{0}", i + 1);
                //}
                //this.DataGridViewFollowUpLogs.Refresh();
                e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private ToolStripMenuItem CreateAddFollowUpLogMenuItem()
        {
            ToolStripMenuItem tsmiAdd = new ToolStripMenuItem();
            tsmiAdd.Text = "新增";
            tsmiAdd.Click += TsmiAdd_Click;

            return tsmiAdd;
        }

        private ToolStripMenuItem CreateEditFollowUpLogMenuItem()
        {
            ToolStripMenuItem tsmiEdit = new ToolStripMenuItem();
            tsmiEdit.Text = "编辑";
            tsmiEdit.Click += TsmiEdit_Click;

            return tsmiEdit;
        }

        private ToolStripMenuItem CreateDeleteFollowUpLogMenuItem()
        {
            ToolStripMenuItem tsmiDelete = new ToolStripMenuItem();
            tsmiDelete.Text = "删除";
            tsmiDelete.Click += TsmiDelete_Click;

            return tsmiDelete;
        }

        private ToolStripMenuItem CreateRefreshFollowUpLogMenuItem()
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
                FrmFollowUpLog frmFollowUpLog = new FrmFollowUpLog()
                {
                    FollowUpWorkingState = WorkingState.Add,
                    Customer = this.Customer
                };
                DialogResult result = frmFollowUpLog.ShowDialog(this);
                if (DialogResult.OK == result)
                {
                    LoadAllLogs(this.Customer.Id);
                    this.DialogResult = DialogResult.OK;
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
                DataRow dataRow = (DataGridViewFollowUpLogs.SelectedRows[0].DataBoundItem as DataRowView).Row;
                var item = dataRow.ToExpression<CustomerFollowUpLog>();
                if (null != item)
                {
                    var log = item(dataRow);
                    if (null != log)
                    {
                        FrmFollowUpLog frmFollowUpLog = new FrmFollowUpLog()
                        {
                            FollowUpWorkingState = WorkingState.Modify,
                            Customer = this.Customer,
                            FollowUpLog = log,
                        };
                        DialogResult result = frmFollowUpLog.ShowDialog(this);
                        if(DialogResult.OK == result)
                        {
                            LoadAllLogs(this.Customer.Id);
                            this.DialogResult = DialogResult.OK;
                        }
                    }
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
                DialogResult dialogResult = MessageBox.Show(this, "您确定要删除所选跟进记录吗，删除后将不可恢复？", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (DialogResult.Yes == dialogResult)
                {
                    int count = DataGridViewFollowUpLogs.SelectedRows.Count;
                    for (int i = 0; i < count; i++)
                    {
                        var row = DataGridViewFollowUpLogs.SelectedRows[i];
                        object objId = row.Cells["Id"].Value;
                        int id = Convert.ToInt32(objId);
                        int result = TableCustomerManage.DeleteFollowUpLogById(id);
                        if (result <= 0)
                        {
                            string email = row.Cells["Email"].Value.ToString();
                            MessageBox.Show(this, "删除客户 " + email + " 跟进记录失败！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    LoadAllLogs(this.Customer.Id);

                    this.DialogResult = DialogResult.OK;
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
            LoadAllLogs(this.Customer.Id);
        }

        private void LoadAllLogs(int CustomerId)
        {
            DataGridViewFollowUpLogs.ClearSelection();

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

                col = grid.Columns["Time"];
                col.HeaderText = "日期";
                col.Width = 100;
                col.ReadOnly = true;
                col.DisplayIndex = i++;

                col = grid.Columns["State"];
                col.HeaderText = "状态";
                col.Width = 100;
                col.ReadOnly = true;
                col.DisplayIndex = i++;

                col = grid.Columns["Briefing"];
                col.HeaderText = "摘要";
                col.Width = 350;
                col.ReadOnly = true;
                col.DisplayIndex = i++;

                col = grid.Columns["Content"];
                col.HeaderText = "详细内容";
                col.Width = 500;
                col.DisplayIndex = i++;

                col = grid.Columns["Modify"];
                col.Visible = false;

                col = grid.Columns["BelongsTo"];
                col.Visible = false;

                col = grid.Columns["CustomerInfoID"];
                col.Visible = false;
            }
        }
    }
}
