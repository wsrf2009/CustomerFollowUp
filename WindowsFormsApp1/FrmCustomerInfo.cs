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

namespace CFUManageSystem
{
    public partial class FrmCustomerInfo : Form
    {
        public FrmCustomerInfo()
        {
            InitializeComponent();
        }

        private void FrmCustomerInfo_Load(object sender, EventArgs e)
        {
            //ComboBoxState.Items.AddRange(new string[] { "询价未回", "多次互动", "已成交" });
        }

        private void BtnLogOk_Click(object sender, EventArgs e)
        {
            string email = TxtBoxEmail.Text.Trim();
            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show(this, "邮箱地址不能为空", "客户信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtBoxEmail.Focus();
                return;
            }

            string company = TxtBoxCompanyName.Text;
            int number = Convert.ToInt32(NumUpDownNumber.Value);
            string datetime = DTPDate.Value.ToLocalTime().ToString();
            string state = ComboBoxState.Text;
            string briefing = TxtBoxBriefing.Text;
            string content = RichTxtBoxContent.Text;
            string modify = DateTime.Now.ToLocalTime().ToString();

            CFUSystem.AddFollowUpLog(email, company, 
                number, datetime, state, 
                briefing, content,
                modify);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {

        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            try
            {
                string email = TxtBoxEmail.Text.Trim();
                if (string.IsNullOrWhiteSpace(email))
                {
                    MessageBox.Show(this, "邮箱地址不能为空", "客户信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtBoxEmail.Focus();
                    return;
                }

                string archivingDate = DTPArchiving.Value.ToLocalTime().ToString();
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

                CFUSystem.AddCustomer(archivingDate,
                    contacts, email,
                    company, website,
                    country, address,
                    scope, type, demand,
                    telephone, fax, mobile, msn, skype, linkin, whatsapp, twiter, facebook,
                    comefrom, belongsto,
                    remarks, datetime);
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        
    }
}
