using SqlLibrary;
using SqlLibrary.DataStructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CFUSystem
{
    public partial class FrmFollowUpLog : Form
    {
        public WorkingState FollowUpWorkingState { get; set; }
        private CustomerFollowUpLog _FollowUpLog;
        public CustomerFollowUpLog FollowUpLog
        {
            get
            {
                if (null == _FollowUpLog)
                {
                    _FollowUpLog = new CustomerFollowUpLog();
                }
                return _FollowUpLog;
            }
            set { _FollowUpLog = value; }
        }
        public CustomerInfo Customer { get; set; }

        public FrmFollowUpLog()
        {
            InitializeComponent();
        }

        private void FrmFollowUpLog_Load(object sender, EventArgs e)
        {
            ComboBoxState.SelectedIndex = 0;

            if (WorkingState.Add == this.FollowUpWorkingState)
            {
                SetFollowUpWorkingState(WorkingState.Add);
            }
            else if (WorkingState.Modify == this.FollowUpWorkingState)
            {
                NumUpDownNumber.Value = this.FollowUpLog.Number;
                DTPDate.Value = Convert.ToDateTime(this.FollowUpLog.Time);
                ComboBoxState.Text = this.FollowUpLog.State;
                TxtBoxBriefing.Text = this.FollowUpLog.Briefing;
                RichTxtBoxContent.Text = this.FollowUpLog.Content;

                SetFollowUpWorkingState(WorkingState.Modify);
            }
        }

        private void NumUpDownNumber_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                int cur = Convert.ToInt32(NumUpDownNumber.Value);
                if (WorkingState.Modify == this.FollowUpWorkingState)
                {
                    if (this.FollowUpLog.Number.Equals(cur))
                    {
                        BtnLogSave.Enabled = false;
                    }
                    else
                    {
                        BtnLogSave.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DTPDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                string cur = DTPDate.Value.ToLocalTime().ToString();
                if (WorkingState.Modify == this.FollowUpWorkingState)
                {
                    if (this.FollowUpLog.Time.Equals(cur))
                    {
                        BtnLogSave.Enabled = false;
                    }
                    else
                    {
                        BtnLogSave.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ComboBoxState_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string cur = ComboBoxState.Text;
                if (WorkingState.Modify == this.FollowUpWorkingState)
                {
                    if (this.FollowUpLog.State.Equals(cur))
                    {
                        BtnLogSave.Enabled = false;
                    }
                    else
                    {
                        BtnLogSave.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtBoxBriefing_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string cur = TxtBoxBriefing.Text;
                if (string.IsNullOrWhiteSpace(cur))
                {
                    BtnLogSave.Enabled = false;
                }
                else
                {
                    if (cur.Contains("'"))
                    {
                        MessageBox.Show(this, "含有非法字符 \"'\" !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        TxtBoxBriefing.Focus();
                    }
                    else if (WorkingState.Modify == this.FollowUpWorkingState)
                    {
                        if (this.FollowUpLog.Briefing.Equals(cur))
                        {
                            BtnLogSave.Enabled = false;
                        }
                        else
                        {
                            BtnLogSave.Enabled = true;
                        }
                    }
                    else if (WorkingState.Add == this.FollowUpWorkingState)
                    {
                        BtnLogSave.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RichTxtBoxContent_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string cur = RichTxtBoxContent.Text;
                if (cur.Contains("'"))
                {
                    MessageBox.Show(this, "含有非法字符 \"'\" !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    RichTxtBoxContent.Focus();
                }
                else if (WorkingState.Modify == this.FollowUpWorkingState)
                {
                    if (this.FollowUpLog.Content.Equals(cur))
                    {
                        BtnLogSave.Enabled = false;
                    }
                    else
                    {
                        BtnLogSave.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnLogSave_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                string email = this.FollowUpLog.Email = this.Customer.Email; // TxtBoxEmail.Text.Trim();
                string company = this.FollowUpLog.CompanyName = this.Customer.CompanyName; // TxtBoxCompanyName.Text.Trim();
                int number = this.FollowUpLog.Number = Convert.ToInt32(NumUpDownNumber.Value);
                string datetime = this.FollowUpLog.Time = DTPDate.Value.ToLocalTime().ToString();
                string state = this.FollowUpLog.State = ComboBoxState.Text.Trim();
                string briefing = this.FollowUpLog.Briefing = TxtBoxBriefing.Text.Trim();
                string content = this.FollowUpLog.Content = RichTxtBoxContent.Text.Trim();
                string modify = this.FollowUpLog.Modify = DateTime.Now.ToLocalTime().ToString();
                string seller = this.FollowUpLog.BelongsTo = this.Customer.BelongsTo;

                if (WorkingState.Add == this.FollowUpWorkingState)
                {
                    int identity = TableCustomerManage.AddFollowUpLogReturnIdentity(email, company, this.Customer.Id,
                        number, datetime, state,
                        briefing, content,
                        modify, seller);
                    if (identity > 0)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else if (WorkingState.Modify == this.FollowUpWorkingState)
                {
                    int num = TableCustomerManage.ModifyFollowUpLogById(this.FollowUpLog.Id,
                        email, company, this.Customer.Id,
                        number, state,
                        briefing, content,
                        modify, seller);
                    if (num > 0)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Cursor.Current = Cursors.Default;
        }

        private void SetFollowUpWorkingState(WorkingState state)
        {
            tableLayoutPanel11.Enabled = true;
            this.FollowUpWorkingState = state;

            if (WorkingState.Add == state)
            {
                DTPDate.Enabled = true;
                ComboBoxState.SelectedIndex = 0;
                TxtBoxBriefing.Text = "";
                RichTxtBoxContent.Text = "";

                BtnLogSave.Text = "添加";
                BtnLogSave.Enabled = false;
                BtnLogSave.Visible = true;
            }
            else
            {
                DTPDate.Enabled = false;

                BtnLogSave.Text = "更新";
                BtnLogSave.Enabled = false;
                BtnLogSave.Visible = true;
            }
        }
    }
}
