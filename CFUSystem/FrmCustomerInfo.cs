﻿using SqlLibrary;
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
        public UserInfo User { get; set; }

        public FrmCustomerInfo()
        {
            InitializeComponent();
        }

        private void FrmCustomerInfo_Load(object sender, EventArgs e)
        {
            try
            {
                ComboBoxSort.SelectedIndex = 0;

                if (WorkingState.Add == this.WorkingState)
                {
                    tabControl1.TabPages.Remove(tabPage2);
                    SetCustomerInfoWorkingState(WorkingState.Add);

                    BtnInfoSave.Enabled = false;
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
                    ComboBoxBusinessScope.Text = this.Customer.BusinessScope;
                    ComboBoxType.Text = this.Customer.Type;
                    TxtBoxDemand.Text = this.Customer.Demand;
                    TxtBoxTelephone.Text = this.Customer.Telephone;
                    TxtBoxFax.Text = this.Customer.FAX;
                    TxtBoxMobile.Text = this.Customer.Mobile;
                    TxtBoxWechat.Text = this.Customer.Wechat;
                    TxtBoxSkype.Text = this.Customer.Skype;
                    TxtBoxLinkin.Text = this.Customer.Linkin;
                    TxtBoxWhatsApp.Text = this.Customer.Whatsapp;
                    TxtBoxTwiter.Text = this.Customer.Twiter;
                    TxtBoxFacebook.Text = this.Customer.Facebook;
                    ComboBoxComeFrom.Text = this.Customer.ComeFrom;
                    TxtBoxUsedBrands.Text = this.Customer.UsedBrands;
                    TxtBoxDecisionMaker.Text = this.Customer.DecisionMaker;
                    ComboBoxNewProductRecommendReactionAcuity.Text = this.Customer.NewProductRecommendReactionAcuity;
                    TxtBoxReligion.Text = this.Customer.Religion;
                    ComboBoxCharacterTraits.Text = this.Customer.CharacterTraits;
                    ComboBoxAmountStratification.Text = this.Customer.AmountStratification;
                    TxtBoxNormalCommunication.Text = this.Customer.NormalCommunication;
                    TxtBoxNormalPayment.Text = this.Customer.NormalPayment;
                    ComboBoxCustomerSize.Text = this.Customer.CustomerSize;
                    ComboBoxDeliveryTimeSensitivity.Text = this.Customer.DeliveryTimeSensitivity;
                    ComboBoxLoyalty.Text = this.Customer.Loyalty;
                    TxtBoxProductFactors.Text = this.Customer.ProductFactors;
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
                //string cur = DTPArchiving.Value.ToLocalTime().ToString();
                //if (WorkingState.Modify == this.WorkingState)
                //{
                //    if (this.Customer.ArchivingTime.Equals(cur))
                //    {
                //        BtnInfoSave.Enabled = false;
                //    }
                //    else
                //    {
                //        BtnInfoSave.Enabled = true;
                //    }
                //}
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
                //string cur = ComboBoxSort.Text;
                //if (WorkingState.Modify == this.WorkingState)
                //{
                //    if (this.Customer.Sort.Equals(cur))
                //    {
                //        BtnInfoSave.Enabled = false;
                //    }
                //    else
                //    {
                //        BtnInfoSave.Enabled = true;
                //    }
                //}
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
                //else if (WorkingState.Modify == this.WorkingState)
                //{
                //    if (this.Customer.Contacts.Equals(cur))
                //    {
                //        BtnInfoSave.Enabled = false;
                //    }
                //    else
                //    {
                //        BtnInfoSave.Enabled = true;
                //    }
                //}
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
                string cur = TxtBoxEmail.Text;
                //if (string.IsNullOrWhiteSpace(cur))
                //{
                //    BtnInfoSave.Enabled = false;
                //}
                //else
                //{
                if (cur.Contains("'"))
                {
                    MessageBox.Show(this, "含有非法字符 \"'\" !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    TxtBoxEmail.Focus();
                    //BtnInfoSave.Enabled = false;
                }
                //else
                //{
                //BtnInfoSave.Enabled = true;
                //}
                //}
                //else if (WorkingState.Modify == this.WorkingState)
                //{
                //    if (this.Customer.CompanyName.Equals(cur))
                //    {
                //        BtnInfoSave.Enabled = false;
                //    }
                //    else
                //    {
                //        BtnInfoSave.Enabled = true;
                //    }
                //}
                if (string.IsNullOrWhiteSpace(cur) || string.IsNullOrWhiteSpace(TxtBoxCompanyName.Text.Trim()))
                {
                    BtnInfoSave.Enabled = false;
                }
                else
                {
                    BtnInfoSave.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //try
            //{
            //Regex regex = new Regex("^\\s*([A-Za-z0-9_-]+(\\.\\w+)*@(\\w+\\.)+\\w{2,5})\\s*$");
            //if (regex.IsMatch(TxtBoxEmail.Text))
            //{
            //    if (WorkingState.Add == this.WorkingState)
            //    {
            //        BtnInfoSave.Enabled = true;
            //    }
            //    else if (WorkingState.Modify == this.WorkingState)
            //    {
            //        BtnInfoSave.Enabled = true;
            //    }
            //    return;
            //}

            //    if (WorkingState.Add == this.WorkingState)
            //    {
            //        BtnInfoSave.Enabled = false;
            //    }
            //    else if (WorkingState.Modify == this.WorkingState)
            //    {
            //        BtnInfoSave.Enabled = false;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void TxtBoxCompanyName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string cur = TxtBoxCompanyName.Text;
                //if (string.IsNullOrWhiteSpace(cur))
                //{
                //    BtnInfoSave.Enabled = false;
                //}
                //else
                //{
                if (cur.Contains("'"))
                {
                    MessageBox.Show(this, "含有非法字符 \"'\" !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    TxtBoxCompanyName.Focus();
                }
                //else if (WorkingState.Modify == this.WorkingState)
                //{
                //    if (this.Customer.CompanyName.Equals(cur))
                //    {
                //        BtnInfoSave.Enabled = false;
                //    }
                //    else
                //    {
                //        BtnInfoSave.Enabled = true;
                //    }
                //}
                //}

                if (string.IsNullOrWhiteSpace(cur) || string.IsNullOrWhiteSpace(TxtBoxEmail.Text.Trim()))
                {
                    BtnInfoSave.Enabled = false;
                }
                else
                {
                    BtnInfoSave.Enabled = true;
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
                //else if (WorkingState.Modify == this.WorkingState)
                //{
                //    if (this.Customer.Website.Equals(cur))
                //    {
                //        BtnInfoSave.Enabled = false;
                //    }
                //    else
                //    {
                //        BtnInfoSave.Enabled = true;
                //    }
                //}
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
                //else if (WorkingState.Modify == this.WorkingState)
                //{
                //    if (this.Customer.Country.Equals(cur))
                //    {
                //        BtnInfoSave.Enabled = false;
                //    }
                //    else
                //    {
                //        BtnInfoSave.Enabled = true;
                //    }
                //}
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
                //else if (WorkingState.Modify == this.WorkingState)
                //{
                //    if (this.Customer.Address.Equals(cur))
                //    {
                //        BtnInfoSave.Enabled = false;
                //    }
                //    else
                //    {
                //        BtnInfoSave.Enabled = true;
                //    }
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ComboBoxBusinessScope_TextUpdate(object sender, EventArgs e)
        {
            try
            {
                string cur = ComboBoxBusinessScope.Text;
                if (cur.Contains("'"))
                {
                    MessageBox.Show(this, "含有非法字符 \"'\" !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    ComboBoxBusinessScope.Focus();
                }
                //else if (WorkingState.Modify == this.WorkingState)
                //{
                //    if (this.Customer.BusinessScope.Equals(cur))
                //    {
                //        BtnInfoSave.Enabled = false;
                //    }
                //    else
                //    {
                //        BtnInfoSave.Enabled = true;
                //    }
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ComboBoxType_TextUpdate(object sender, EventArgs e)
        {
            try
            {
                string cur = ComboBoxType.Text;
                if (cur.Contains("'"))
                {
                    MessageBox.Show(this, "含有非法字符 \"'\" !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    ComboBoxType.Focus();
                }
                //else if (WorkingState.Modify == this.WorkingState)
                //{
                //    if (this.Customer.Type.Equals(cur))
                //    {
                //        BtnInfoSave.Enabled = false;
                //    }
                //    else
                //    {
                //        BtnInfoSave.Enabled = true;
                //    }
                //}
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
                //else if (WorkingState.Modify == this.WorkingState)
                //{
                //    if (this.Customer.Demand.Equals(cur))
                //    {
                //        BtnInfoSave.Enabled = false;
                //    }
                //    else
                //    {
                //        BtnInfoSave.Enabled = true;
                //    }
                //}
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
                //else if (WorkingState.Modify == this.WorkingState)
                //{
                //    if (this.Customer.Telephone.Equals(cur))
                //    {
                //        BtnInfoSave.Enabled = false;
                //    }
                //    else
                //    {
                //        BtnInfoSave.Enabled = true;
                //    }
                //}
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
                //else if (WorkingState.Modify == this.WorkingState)
                //{
                //    if (this.Customer.FAX.Equals(cur))
                //    {
                //        BtnInfoSave.Enabled = false;
                //    }
                //    else
                //    {
                //        BtnInfoSave.Enabled = true;
                //    }
                //}
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
                //else if (WorkingState.Modify == this.WorkingState)
                //{
                //    if (this.Customer.Mobile.Equals(cur))
                //    {
                //        BtnInfoSave.Enabled = false;
                //    }
                //    else
                //    {
                //        BtnInfoSave.Enabled = true;
                //    }
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtBoxWechat_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string cur = TxtBoxWechat.Text;
                if (cur.Contains("'"))
                {
                    MessageBox.Show(this, "含有非法字符 \"'\" !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    TxtBoxWechat.Focus();
                }
                //else if (WorkingState.Modify == this.WorkingState)
                //{
                //    if (this.Customer.MSN.Equals(cur))
                //    {
                //        BtnInfoSave.Enabled = false;
                //    }
                //    else
                //    {
                //        BtnInfoSave.Enabled = true;
                //    }
                //}
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
                //else if (WorkingState.Modify == this.WorkingState)
                //{
                //    if (this.Customer.Skype.Equals(cur))
                //    {
                //        BtnInfoSave.Enabled = false;
                //    }
                //    else
                //    {
                //        BtnInfoSave.Enabled = true;
                //    }
                //}
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
                //else if (WorkingState.Modify == this.WorkingState)
                //{
                //    if (this.Customer.Linkin.Equals(cur))
                //    {
                //        BtnInfoSave.Enabled = false;
                //    }
                //    else
                //    {
                //        BtnInfoSave.Enabled = true;
                //    }
                //}
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
                //else if (WorkingState.Modify == this.WorkingState)
                //{
                //    if (this.Customer.Whatsapp.Equals(cur))
                //    {
                //        BtnInfoSave.Enabled = false;
                //    }
                //    else
                //    {
                //        BtnInfoSave.Enabled = true;
                //    }
                //}
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
                //else if (WorkingState.Modify == this.WorkingState)
                //{
                //    if (this.Customer.Twiter.Equals(cur))
                //    {
                //        BtnInfoSave.Enabled = false;
                //    }
                //    else
                //    {
                //        BtnInfoSave.Enabled = true;
                //    }
                //}
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
                //else if (WorkingState.Modify == this.WorkingState)
                //{
                //    if (this.Customer.Facebook.Equals(cur))
                //    {
                //        BtnInfoSave.Enabled = false;
                //    }
                //    else
                //    {
                //        BtnInfoSave.Enabled = true;
                //    }
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ComboBoxComeFrom_TextUpdate(object sender, EventArgs e)
        {
            try
            {
                string cur = ComboBoxComeFrom.Text;
                if (cur.Contains("'"))
                {
                    MessageBox.Show(this, "含有非法字符 \"'\" !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    ComboBoxComeFrom.Focus();
                }
                //else if (WorkingState.Modify == this.WorkingState)
                //{
                //    if (this.Customer.ComeFrom.Equals(cur))
                //    {
                //        BtnInfoSave.Enabled = false;
                //    }
                //    else
                //    {
                //        BtnInfoSave.Enabled = true;
                //    }
                //}
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
                //else if (WorkingState.Modify == this.WorkingState)
                //{
                //    if (this.Customer.Remarks.Equals(cur))
                //    {
                //        BtnInfoSave.Enabled = false;
                //    }
                //    else
                //    {
                //        BtnInfoSave.Enabled = true;
                //    }
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ComboBoxCustomerSize_TextUpdate(object sender, EventArgs e)
        {
            try
            {
                string cur = ComboBoxCustomerSize.Text;
                if (cur.Contains("'"))
                {
                    MessageBox.Show(this, "含有非法字符 \"'\" !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    ComboBoxCustomerSize.Focus();
                }
                //else if (WorkingState.Modify == this.WorkingState)
                //{
                //    if (this.Customer.CustomerSize.Equals(cur))
                //    {
                //        BtnInfoSave.Enabled = false;
                //    }
                //    else
                //    {
                //        BtnInfoSave.Enabled = true;
                //    }
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ComboBoxAmountStratification_TextUpdate(object sender, EventArgs e)
        {
            try
            {
                string cur = ComboBoxAmountStratification.Text;
                if (cur.Contains("'"))
                {
                    MessageBox.Show(this, "含有非法字符 \"'\" !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    ComboBoxAmountStratification.Focus();
                }
                //else if (WorkingState.Modify == this.WorkingState)
                //{
                //    if (this.Customer.AmountStratification.Equals(cur))
                //    {
                //        BtnInfoSave.Enabled = false;
                //    }
                //    else
                //    {
                //        BtnInfoSave.Enabled = true;
                //    }
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtBoxUsedBrands_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string cur = TxtBoxUsedBrands.Text;
                if (cur.Contains("'"))
                {
                    MessageBox.Show(this, "含有非法字符 \"'\" !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    TxtBoxUsedBrands.Focus();
                }
                //else if (WorkingState.Modify == this.WorkingState)
                //{
                //    if (this.Customer.UsedBrands.Equals(cur))
                //    {
                //        BtnInfoSave.Enabled = false;
                //    }
                //    else
                //    {
                //        BtnInfoSave.Enabled = true;
                //    }
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtBoxReligion_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string cur = TxtBoxReligion.Text;
                if (cur.Contains("'"))
                {
                    MessageBox.Show(this, "含有非法字符 \"'\" !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    TxtBoxReligion.Focus();
                }
                //else if (WorkingState.Modify == this.WorkingState)
                //{
                //    if (this.Customer.Religion.Equals(cur))
                //    {
                //        BtnInfoSave.Enabled = false;
                //    }
                //    else
                //    {
                //        BtnInfoSave.Enabled = true;
                //    }
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ComboBoxCharacterTraits_TextUpdate(object sender, EventArgs e)
        {
            try
            {
                string cur = ComboBoxCharacterTraits.Text;
                if (cur.Contains("'"))
                {
                    MessageBox.Show(this, "含有非法字符 \"'\" !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    ComboBoxCharacterTraits.Focus();
                }
                //else if (WorkingState.Modify == this.WorkingState)
                //{
                //    if (this.Customer.CharacterTraits.Equals(cur))
                //    {
                //        BtnInfoSave.Enabled = false;
                //    }
                //    else
                //    {
                //        BtnInfoSave.Enabled = true;
                //    }
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtBoxNormalCommunication_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string cur = TxtBoxNormalCommunication.Text;
                if (cur.Contains("'"))
                {
                    MessageBox.Show(this, "含有非法字符 \"'\" !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    TxtBoxNormalCommunication.Focus();
                }
                //else if (WorkingState.Modify == this.WorkingState)
                //{
                //    if (this.Customer.NormalCommunication.Equals(cur))
                //    {
                //        BtnInfoSave.Enabled = false;
                //    }
                //    else
                //    {
                //        BtnInfoSave.Enabled = true;
                //    }
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtBoxNormalPayment_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string cur = TxtBoxNormalPayment.Text;
                if (cur.Contains("'"))
                {
                    MessageBox.Show(this, "含有非法字符 \"'\" !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    TxtBoxNormalPayment.Focus();
                }
                //else if (WorkingState.Modify == this.WorkingState)
                //{
                //    if (this.Customer.NormalPayment.Equals(cur))
                //    {
                //        BtnInfoSave.Enabled = false;
                //    }
                //    else
                //    {
                //        BtnInfoSave.Enabled = true;
                //    }
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ComboBoxDeliveryTimeSensitivity_TextUpdate(object sender, EventArgs e)
        {
            try
            {
                string cur = ComboBoxDeliveryTimeSensitivity.Text;
                if (cur.Contains("'"))
                {
                    MessageBox.Show(this, "含有非法字符 \"'\" !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    ComboBoxDeliveryTimeSensitivity.Focus();
                }
                //else if (WorkingState.Modify == this.WorkingState)
                //{
                //    if (this.Customer.DeliveryTimeSensitivity.Equals(cur))
                //    {
                //        BtnInfoSave.Enabled = false;
                //    }
                //    else
                //    {
                //        BtnInfoSave.Enabled = true;
                //    }
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ComboBoxNewProductRecommendReactionAcuity_TextUpdate(object sender, EventArgs e)
        {
            try
            {
                string cur = ComboBoxNewProductRecommendReactionAcuity.Text;
                if (cur.Contains("'"))
                {
                    MessageBox.Show(this, "含有非法字符 \"'\" !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    ComboBoxNewProductRecommendReactionAcuity.Focus();
                }
                //else if (WorkingState.Modify == this.WorkingState)
                //{
                //    if (this.Customer.NewProductRecommendReactionAcuity.Equals(cur))
                //    {
                //        BtnInfoSave.Enabled = false;
                //    }
                //    else
                //    {
                //        BtnInfoSave.Enabled = true;
                //    }
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtBoxProductFactors_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string cur = TxtBoxProductFactors.Text;
                if (cur.Contains("'"))
                {
                    MessageBox.Show(this, "含有非法字符 \"'\" !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    TxtBoxProductFactors.Focus();
                }
                //else if (WorkingState.Modify == this.WorkingState)
                //{
                //    if (this.Customer.ProductFactors.Equals(cur))
                //    {
                //        BtnInfoSave.Enabled = false;
                //    }
                //    else
                //    {
                //        BtnInfoSave.Enabled = true;
                //    }
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtBoxDecisionMaker_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string cur = TxtBoxDecisionMaker.Text;
                if (cur.Contains("'"))
                {
                    MessageBox.Show(this, "含有非法字符 \"'\" !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    TxtBoxDecisionMaker.Focus();
                }
                //else if (WorkingState.Modify == this.WorkingState)
                //{
                //    if (this.Customer.DecisionMaker.Equals(cur))
                //    {
                //        BtnInfoSave.Enabled = false;
                //    }
                //    else
                //    {
                //        BtnInfoSave.Enabled = true;
                //    }
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ComboBoxLoyalty_TextUpdate(object sender, EventArgs e)
        {
            try
            {
                string cur = ComboBoxLoyalty.Text;
                if (cur.Contains("'"))
                {
                    MessageBox.Show(this, "含有非法字符 \"'\" !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    ComboBoxLoyalty.Focus();
                }
                //else if (WorkingState.Modify == this.WorkingState)
                //{
                //    if (this.Customer.Loyalty.Equals(cur))
                //    {
                //        BtnInfoSave.Enabled = false;
                //    }
                //    else
                //    {
                //        BtnInfoSave.Enabled = true;
                //    }
                //}
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
                string scope = this.Customer.BusinessScope = ComboBoxBusinessScope.Text.Trim();
                string type = this.Customer.Type = ComboBoxType.Text.Trim();
                string demand = this.Customer.Demand = TxtBoxDemand.Text.Trim();
                string telephone = this.Customer.Telephone = TxtBoxTelephone.Text.Trim();
                string fax = this.Customer.FAX = TxtBoxFax.Text.Trim();
                string mobile = this.Customer.Mobile = TxtBoxMobile.Text.Trim();
                string wechat = this.Customer.Wechat = TxtBoxWechat.Text.Trim();
                string skype = this.Customer.Skype = TxtBoxSkype.Text.Trim();
                string linkin = this.Customer.Linkin = TxtBoxLinkin.Text.Trim();
                string whatsapp = this.Customer.Whatsapp = TxtBoxWhatsApp.Text.Trim();
                string twiter = this.Customer.Twiter = TxtBoxTwiter.Text.Trim();
                string facebook = this.Customer.Facebook = TxtBoxFacebook.Text.Trim();
                string comefrom = this.Customer.ComeFrom = ComboBoxComeFrom.Text.Trim();
                string usedBrands = this.Customer.UsedBrands = TxtBoxUsedBrands.Text.Trim();
                string decisionMaker = this.Customer.DecisionMaker = TxtBoxDecisionMaker.Text.Trim();
                string reactionAcuity = this.Customer.NewProductRecommendReactionAcuity = ComboBoxNewProductRecommendReactionAcuity.Text.Trim();
                string religion = this.Customer.Religion = TxtBoxReligion.Text.Trim();
                string charaterTraits = this.Customer.CharacterTraits = ComboBoxCharacterTraits.Text.Trim();
                string amountStratification = this.Customer.AmountStratification = ComboBoxAmountStratification.Text.Trim();
                string normalCommunication = this.Customer.NormalCommunication = TxtBoxNormalCommunication.Text.Trim();
                string normalPayment = this.Customer.NormalPayment = TxtBoxNormalPayment.Text.Trim();
                string customerSize = this.Customer.CustomerSize = ComboBoxCustomerSize.Text.Trim();
                string deliveryTimeSensitivity = this.Customer.DeliveryTimeSensitivity = ComboBoxDeliveryTimeSensitivity.Text.Trim();
                string loyalty = this.Customer.Loyalty = ComboBoxLoyalty.Text.Trim();
                string productFactors = this.Customer.ProductFactors = TxtBoxProductFactors.Text.Trim();
                //string belongsto = this.Customer.BelongsTo = TxtBoxLoyalty.Text.Trim();
                string remarks = this.Customer.Remarks = TxtBoxRemarks.Text.Trim();
                string modify = this.Customer.Modify = DateTime.Now.ToLocalTime().ToString();
                string futime = this.Customer.LastFollowUpTime = "";
                string fubriefing = this.Customer.LastFollowUpBriefing = "";
                string fustate = this.Customer.LastFollowUpState = "";

                if (WorkingState.Add == this.WorkingState)
                {
                    bool isExist = IsCustomerExist(company);
                    if(isExist)
                    {

                    }
                    else
                    {
                        int identity = TableCustomerManage.AddCustomerReturnIdentity(archivingDate, email, this.User.Name);
                        if (identity > 0)
                        {
                            //this.DialogResult = DialogResult.OK;
                            this.Customer.Id = identity;

                            int num = TableCustomerManage.ModifyCustomerInfoById(this.Customer.Id,
                            sort,
                            contacts, email,
                            company, website,
                            country, address,
                            scope, type, demand,
                            telephone, fax, mobile, "", wechat, skype, linkin, whatsapp, twiter, facebook,
                            comefrom,
                            usedBrands, decisionMaker, reactionAcuity, religion, charaterTraits, amountStratification,
                            normalCommunication, normalPayment, customerSize, deliveryTimeSensitivity, loyalty, productFactors,
                            remarks, modify);

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
                }
                else if (WorkingState.Modify == this.WorkingState)
                {
                    int num = TableCustomerManage.ModifyCustomerInfoById(this.Customer.Id,
                        sort,
                        contacts, email,
                        company, website,
                        country, address,
                        scope, type, demand,
                        telephone, fax, mobile, "", wechat, skype, linkin, whatsapp, twiter, facebook,
                        comefrom,
                        usedBrands, decisionMaker, reactionAcuity, religion, charaterTraits, amountStratification,
                        normalCommunication, normalPayment, customerSize, deliveryTimeSensitivity, loyalty, productFactors,
                        remarks, modify);
                    if (num > 0)
                    {
                        //this.DialogResult = DialogResult.OK;
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
                //BtnInfoSave.Enabled = false;
            }
            else if (WorkingState.Modify == state)
            {
                DTPArchiving.Enabled = false;
                TxtBoxCompanyName.Enabled = false;
                LblCompanyVerify.Visible = false;
                LblCompanyNameStatus.Visible = false;

                BtnInfoSave.Text = "更新";
                //BtnInfoSave.Enabled = false;
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

        private void DataGridViewFollowUpLogs_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dataGridViewRow = DataGridViewFollowUpLogs.Rows[e.RowIndex];
                EditDataGridViewRow(dataGridViewRow);
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
                    //this.DialogResult = DialogResult.OK;
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
                DataGridViewRow row = DataGridViewFollowUpLogs.SelectedRows[0];
                EditDataGridViewRow(row);
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

                    //this.DialogResult = DialogResult.OK;
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

            DataTable dataTable = TableCustomerManage.QueryFollowUpLogsByCustomerId(CustomerId);
            DataGridViewFollowUpLogs.DataSource = dataTable;
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

        private bool IsCustomerExist(string company)
        {
            bool isExist = false;

            DataTable dataTable = TableCustomerManage.QueryCustomerByCompanyName(company);
            if ((null != dataTable) && (dataTable.Rows.Count > 0))
            {
                DataRow dataRow = dataTable.Rows[0];
                var item = dataRow.ToExpression<CustomerInfo>();
                CustomerInfo customer = item(dataRow);
                MessageBox.Show(this, "该客户已被 " + customer.BelongsTo + " 录入！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);

                isExist = true;
            }

            return isExist;
        }

        private void EditDataGridViewRow(DataGridViewRow row)
        {
            DataRow dataRow = (row.DataBoundItem as DataRowView).Row;
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
                    if (DialogResult.OK == result)
                    {
                        LoadAllLogs(this.Customer.Id);
                    }
                }
            }
        }

        private void LblCompanyVerify_Click(object sender, EventArgs e)
        {
            try
            {
                string company = TxtBoxCompanyName.Text.Trim();
                if (IsCustomerExist(company))
                {
                    LblCompanyNameStatus.Text = "不可用";
                    LblCompanyNameStatus.ForeColor = Color.Red;
                }
                else
                {
                    LblCompanyNameStatus.Text = "可用";
                    LblCompanyNameStatus.ForeColor = Color.Green;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
