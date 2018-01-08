namespace WindowsFormsApp1
{
    partial class FrmLogin
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtBoxUserName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBoxPassword = new System.Windows.Forms.TextBox();
            this.ckBoxRememberPassword = new System.Windows.Forms.CheckBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtBoxErrMessage = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtBoxUserName
            // 
            this.txtBoxUserName.Location = new System.Drawing.Point(149, 83);
            this.txtBoxUserName.Name = "txtBoxUserName";
            this.txtBoxUserName.Size = new System.Drawing.Size(209, 28);
            this.txtBoxUserName.TabIndex = 0;
            this.txtBoxUserName.TextChanged += new System.EventHandler(this.txtBoxUserName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(63, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "用户名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "密码：";
            // 
            // txtBoxPassword
            // 
            this.txtBoxPassword.Location = new System.Drawing.Point(149, 134);
            this.txtBoxPassword.Name = "txtBoxPassword";
            this.txtBoxPassword.PasswordChar = '*';
            this.txtBoxPassword.Size = new System.Drawing.Size(209, 28);
            this.txtBoxPassword.TabIndex = 3;
            this.txtBoxPassword.UseSystemPasswordChar = true;
            // 
            // ckBoxRememberPassword
            // 
            this.ckBoxRememberPassword.AutoSize = true;
            this.ckBoxRememberPassword.Location = new System.Drawing.Point(376, 141);
            this.ckBoxRememberPassword.Name = "ckBoxRememberPassword";
            this.ckBoxRememberPassword.Size = new System.Drawing.Size(88, 22);
            this.ckBoxRememberPassword.TabIndex = 4;
            this.ckBoxRememberPassword.Text = "记住我";
            this.ckBoxRememberPassword.UseVisualStyleBackColor = true;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(149, 195);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(209, 47);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "登录";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtBoxErrMessage
            // 
            this.txtBoxErrMessage.ForeColor = System.Drawing.Color.Red;
            this.txtBoxErrMessage.Location = new System.Drawing.Point(12, 263);
            this.txtBoxErrMessage.Name = "txtBoxErrMessage";
            this.txtBoxErrMessage.Size = new System.Drawing.Size(464, 28);
            this.txtBoxErrMessage.TabIndex = 6;
            this.txtBoxErrMessage.Visible = false;
            // 
            // FrmLogin
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 309);
            this.Controls.Add(this.txtBoxErrMessage);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.ckBoxRememberPassword);
            this.Controls.Add(this.txtBoxPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBoxUserName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmLogin";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "客户跟进系统登录";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxUserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBoxPassword;
        private System.Windows.Forms.CheckBox ckBoxRememberPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtBoxErrMessage;
    }
}

