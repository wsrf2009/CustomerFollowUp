namespace CFUSystem
{
    partial class LoginLogs
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnLastPage = new System.Windows.Forms.Button();
            this.BtnNextPage = new System.Windows.Forms.Button();
            this.BtnPrePage = new System.Windows.Forms.Button();
            this.BtnFirstPage = new System.Windows.Forms.Button();
            this.LblCurPage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.Size = new System.Drawing.Size(958, 535);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dataGridView1_RowStateChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(964, 611);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 11;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel2.Controls.Add(this.BtnLastPage, 9, 0);
            this.tableLayoutPanel2.Controls.Add(this.BtnNextPage, 7, 0);
            this.tableLayoutPanel2.Controls.Add(this.BtnPrePage, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.BtnFirstPage, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.LblCurPage, 5, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 551);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(964, 50);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // BtnLastPage
            // 
            this.BtnLastPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnLastPage.Location = new System.Drawing.Point(804, 0);
            this.BtnLastPage.Margin = new System.Windows.Forms.Padding(0);
            this.BtnLastPage.Name = "BtnLastPage";
            this.BtnLastPage.Size = new System.Drawing.Size(150, 50);
            this.BtnLastPage.TabIndex = 0;
            this.BtnLastPage.Text = "最后一页";
            this.BtnLastPage.UseVisualStyleBackColor = true;
            this.BtnLastPage.Click += new System.EventHandler(this.BtnLastPage_Click);
            // 
            // BtnNextPage
            // 
            this.BtnNextPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnNextPage.Location = new System.Drawing.Point(644, 0);
            this.BtnNextPage.Margin = new System.Windows.Forms.Padding(0);
            this.BtnNextPage.Name = "BtnNextPage";
            this.BtnNextPage.Size = new System.Drawing.Size(150, 50);
            this.BtnNextPage.TabIndex = 1;
            this.BtnNextPage.Text = "下一页";
            this.BtnNextPage.UseVisualStyleBackColor = true;
            this.BtnNextPage.Click += new System.EventHandler(this.BtnNextPage_Click);
            // 
            // BtnPrePage
            // 
            this.BtnPrePage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnPrePage.Location = new System.Drawing.Point(324, 0);
            this.BtnPrePage.Margin = new System.Windows.Forms.Padding(0);
            this.BtnPrePage.Name = "BtnPrePage";
            this.BtnPrePage.Size = new System.Drawing.Size(150, 50);
            this.BtnPrePage.TabIndex = 2;
            this.BtnPrePage.Text = "上一页";
            this.BtnPrePage.UseVisualStyleBackColor = true;
            this.BtnPrePage.Click += new System.EventHandler(this.BtnPrePage_Click);
            // 
            // BtnFirstPage
            // 
            this.BtnFirstPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnFirstPage.Location = new System.Drawing.Point(164, 0);
            this.BtnFirstPage.Margin = new System.Windows.Forms.Padding(0);
            this.BtnFirstPage.Name = "BtnFirstPage";
            this.BtnFirstPage.Size = new System.Drawing.Size(150, 50);
            this.BtnFirstPage.TabIndex = 3;
            this.BtnFirstPage.Text = "第一页";
            this.BtnFirstPage.UseVisualStyleBackColor = true;
            this.BtnFirstPage.Click += new System.EventHandler(this.BtnFirstPage_Click);
            // 
            // LblCurPage
            // 
            this.LblCurPage.AutoSize = true;
            this.LblCurPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblCurPage.Location = new System.Drawing.Point(489, 5);
            this.LblCurPage.Margin = new System.Windows.Forms.Padding(5);
            this.LblCurPage.Name = "LblCurPage";
            this.LblCurPage.Size = new System.Drawing.Size(140, 40);
            this.LblCurPage.TabIndex = 4;
            this.LblCurPage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LoginLogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "LoginLogs";
            this.Size = new System.Drawing.Size(964, 611);
            this.Load += new System.EventHandler(this.LoginLogs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button BtnLastPage;
        private System.Windows.Forms.Button BtnNextPage;
        private System.Windows.Forms.Button BtnPrePage;
        private System.Windows.Forms.Button BtnFirstPage;
        private System.Windows.Forms.Label LblCurPage;
    }
}
