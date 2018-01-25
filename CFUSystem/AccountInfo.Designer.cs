namespace CFUSystem
{
    partial class AccountInfo
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtBoxUserName = new System.Windows.Forms.TextBox();
            this.TxtBoxPassword = new System.Windows.Forms.TextBox();
            this.TxtBoxLastLoginIp = new System.Windows.Forms.TextBox();
            this.TxtBoxLastLoginTime = new System.Windows.Forms.TextBox();
            this.TxtBoxLastLoginMac = new System.Windows.Forms.TextBox();
            this.LblModify = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtBoxNickName = new System.Windows.Forms.TextBox();
            this.LblModifyNickname = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label4, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.TxtBoxUserName, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.TxtBoxPassword, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.TxtBoxLastLoginIp, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.TxtBoxLastLoginTime, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.TxtBoxLastLoginMac, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.LblModify, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.TxtBoxNickName, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.LblModifyNickname, 3, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(600, 250);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Location = new System.Drawing.Point(44, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 11, 5, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "账户名:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Location = new System.Drawing.Point(44, 77);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 11, 5, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "密码:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label3.Location = new System.Drawing.Point(44, 227);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 11, 5, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 18);
            this.label3.TabIndex = 10;
            this.label3.Text = "最后登录IP:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label4.Location = new System.Drawing.Point(44, 177);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 11, 5, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "最后登录时间：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label5.Location = new System.Drawing.Point(44, 277);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 11, 5, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 18);
            this.label5.TabIndex = 5;
            this.label5.Text = "最后登录MAC：";
            // 
            // TxtBoxUserName
            // 
            this.TxtBoxUserName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TxtBoxUserName.Enabled = false;
            this.TxtBoxUserName.Location = new System.Drawing.Point(192, 19);
            this.TxtBoxUserName.Name = "TxtBoxUserName";
            this.TxtBoxUserName.Size = new System.Drawing.Size(306, 28);
            this.TxtBoxUserName.TabIndex = 1;
            // 
            // TxtBoxPassword
            // 
            this.TxtBoxPassword.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TxtBoxPassword.Enabled = false;
            this.TxtBoxPassword.Location = new System.Drawing.Point(192, 69);
            this.TxtBoxPassword.Name = "TxtBoxPassword";
            this.TxtBoxPassword.Size = new System.Drawing.Size(306, 28);
            this.TxtBoxPassword.TabIndex = 3;
            this.TxtBoxPassword.UseSystemPasswordChar = true;
            // 
            // TxtBoxLastLoginIp
            // 
            this.TxtBoxLastLoginIp.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TxtBoxLastLoginIp.Enabled = false;
            this.TxtBoxLastLoginIp.Location = new System.Drawing.Point(192, 219);
            this.TxtBoxLastLoginIp.Name = "TxtBoxLastLoginIp";
            this.TxtBoxLastLoginIp.Size = new System.Drawing.Size(306, 28);
            this.TxtBoxLastLoginIp.TabIndex = 11;
            // 
            // TxtBoxLastLoginTime
            // 
            this.TxtBoxLastLoginTime.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TxtBoxLastLoginTime.Enabled = false;
            this.TxtBoxLastLoginTime.Location = new System.Drawing.Point(192, 169);
            this.TxtBoxLastLoginTime.Name = "TxtBoxLastLoginTime";
            this.TxtBoxLastLoginTime.Size = new System.Drawing.Size(306, 28);
            this.TxtBoxLastLoginTime.TabIndex = 9;
            // 
            // TxtBoxLastLoginMac
            // 
            this.TxtBoxLastLoginMac.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TxtBoxLastLoginMac.Enabled = false;
            this.TxtBoxLastLoginMac.Location = new System.Drawing.Point(192, 269);
            this.TxtBoxLastLoginMac.Name = "TxtBoxLastLoginMac";
            this.TxtBoxLastLoginMac.Size = new System.Drawing.Size(306, 28);
            this.TxtBoxLastLoginMac.TabIndex = 10;
            // 
            // LblModify
            // 
            this.LblModify.AutoSize = true;
            this.LblModify.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LblModify.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.LblModify.Location = new System.Drawing.Point(506, 77);
            this.LblModify.Margin = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.LblModify.Name = "LblModify";
            this.LblModify.Size = new System.Drawing.Size(50, 18);
            this.LblModify.TabIndex = 4;
            this.LblModify.Text = "修改";
            this.LblModify.Click += new System.EventHandler(this.LblModify_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label6.Location = new System.Drawing.Point(44, 127);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 11, 5, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(140, 18);
            this.label6.TabIndex = 5;
            this.label6.Text = "昵称：";
            // 
            // TxtBoxNickName
            // 
            this.TxtBoxNickName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TxtBoxNickName.Enabled = false;
            this.TxtBoxNickName.Location = new System.Drawing.Point(192, 119);
            this.TxtBoxNickName.Name = "TxtBoxNickName";
            this.TxtBoxNickName.Size = new System.Drawing.Size(306, 28);
            this.TxtBoxNickName.TabIndex = 6;
            // 
            // LblModifyNickname
            // 
            this.LblModifyNickname.AutoSize = true;
            this.LblModifyNickname.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LblModifyNickname.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.LblModifyNickname.Location = new System.Drawing.Point(506, 127);
            this.LblModifyNickname.Margin = new System.Windows.Forms.Padding(5);
            this.LblModifyNickname.Name = "LblModifyNickname";
            this.LblModifyNickname.Size = new System.Drawing.Size(50, 18);
            this.LblModifyNickname.TabIndex = 7;
            this.LblModifyNickname.Text = "修改";
            this.LblModifyNickname.Click += new System.EventHandler(this.LblModifyNickname_Click);
            // 
            // AccountInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "AccountInfo";
            this.Size = new System.Drawing.Size(600, 484);
            this.Load += new System.EventHandler(this.AccountInfo_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtBoxUserName;
        private System.Windows.Forms.TextBox TxtBoxPassword;
        private System.Windows.Forms.TextBox TxtBoxLastLoginIp;
        private System.Windows.Forms.TextBox TxtBoxLastLoginTime;
        private System.Windows.Forms.TextBox TxtBoxLastLoginMac;
        private System.Windows.Forms.Label LblModify;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtBoxNickName;
        private System.Windows.Forms.Label LblModifyNickname;
    }
}
