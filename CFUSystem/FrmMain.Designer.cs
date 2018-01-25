using System;
using System.Windows.Forms;

namespace CFUSystem
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.LblUserName = new System.Windows.Forms.Label();
            this.BtnAccountManage = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            this.ComboBoxSeller = new System.Windows.Forms.ComboBox();
            this.DataGridViewCustomerInfo = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnLastPage = new System.Windows.Forms.Button();
            this.BtnNextPage = new System.Windows.Forms.Button();
            this.BtnPrePage = new System.Windows.Forms.Button();
            this.BtnFirstPage = new System.Windows.Forms.Button();
            this.BtnAddCustomer = new System.Windows.Forms.Button();
            this.LblCurPage = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewCustomerInfo)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.DataGridViewCustomerInfo, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1245, 629);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 9;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.LblUserName, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.BtnAccountManage, 5, 1);
            this.tableLayoutPanel2.Controls.Add(this.BtnExit, 7, 1);
            this.tableLayoutPanel2.Controls.Add(this.ComboBoxSeller, 3, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(1, 1);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1243, 50);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(26, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 11, 5, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "你好，";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // LblUserName
            // 
            this.LblUserName.AutoSize = true;
            this.LblUserName.Dock = System.Windows.Forms.DockStyle.Left;
            this.LblUserName.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblUserName.ForeColor = System.Drawing.Color.DodgerBlue;
            this.LblUserName.Location = new System.Drawing.Point(105, 16);
            this.LblUserName.Margin = new System.Windows.Forms.Padding(5, 11, 5, 5);
            this.LblUserName.Name = "LblUserName";
            this.LblUserName.Size = new System.Drawing.Size(75, 24);
            this.LblUserName.TabIndex = 1;
            this.LblUserName.Text = "label2";
            this.LblUserName.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // BtnAccountManage
            // 
            this.BtnAccountManage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnAccountManage.Location = new System.Drawing.Point(943, 5);
            this.BtnAccountManage.Margin = new System.Windows.Forms.Padding(0);
            this.BtnAccountManage.Name = "BtnAccountManage";
            this.BtnAccountManage.Size = new System.Drawing.Size(130, 40);
            this.BtnAccountManage.TabIndex = 3;
            this.BtnAccountManage.Text = "账号管理";
            this.BtnAccountManage.UseVisualStyleBackColor = true;
            this.BtnAccountManage.Click += new System.EventHandler(this.BtnAccountManage_Click);
            // 
            // BtnExit
            // 
            this.BtnExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnExit.Location = new System.Drawing.Point(1093, 5);
            this.BtnExit.Margin = new System.Windows.Forms.Padding(0);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(130, 40);
            this.BtnExit.TabIndex = 4;
            this.BtnExit.Text = "退出";
            this.BtnExit.UseVisualStyleBackColor = true;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // ComboBoxSeller
            // 
            this.ComboBoxSeller.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ComboBoxSeller.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxSeller.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ComboBoxSeller.FormattingEnabled = true;
            this.ComboBoxSeller.Location = new System.Drawing.Point(626, 12);
            this.ComboBoxSeller.Name = "ComboBoxSeller";
            this.ComboBoxSeller.Size = new System.Drawing.Size(294, 30);
            this.ComboBoxSeller.TabIndex = 5;
            this.ComboBoxSeller.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSeller_SelectedIndexChanged);
            // 
            // DataGridViewCustomerInfo
            // 
            this.DataGridViewCustomerInfo.AllowUserToAddRows = false;
            this.DataGridViewCustomerInfo.AllowUserToOrderColumns = true;
            this.DataGridViewCustomerInfo.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.DataGridViewCustomerInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewCustomerInfo.ContextMenuStrip = this.contextMenuStrip1;
            this.DataGridViewCustomerInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridViewCustomerInfo.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.DataGridViewCustomerInfo.Location = new System.Drawing.Point(6, 62);
            this.DataGridViewCustomerInfo.Margin = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.DataGridViewCustomerInfo.Name = "DataGridViewCustomerInfo";
            this.DataGridViewCustomerInfo.ReadOnly = true;
            this.DataGridViewCustomerInfo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.DataGridViewCustomerInfo.RowTemplate.Height = 30;
            this.DataGridViewCustomerInfo.Size = new System.Drawing.Size(1233, 485);
            this.DataGridViewCustomerInfo.TabIndex = 2;
            this.DataGridViewCustomerInfo.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridViewCustomerInfo_CellMouseClick);
            this.DataGridViewCustomerInfo.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridViewCustomerInfo_CellMouseDoubleClick);
            this.DataGridViewCustomerInfo.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.DataGridViewCustomerInfo_RowStateChanged);
            this.DataGridViewCustomerInfo.SelectionChanged += new System.EventHandler(this.DataGridViewCustomerInfo_SelectionChanged);
            this.DataGridViewCustomerInfo.Click += new System.EventHandler(this.DataGridViewCustomerInfo_Click);
            this.DataGridViewCustomerInfo.DoubleClick += new System.EventHandler(this.DataGridViewCustomerInfo_DoubleClick);
            this.DataGridViewCustomerInfo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DataGridViewCustomerInfo_MouseClick);
            this.DataGridViewCustomerInfo.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DataGridViewCustomerInfo_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 14;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel3.Controls.Add(this.BtnLastPage, 12, 1);
            this.tableLayoutPanel3.Controls.Add(this.BtnNextPage, 10, 1);
            this.tableLayoutPanel3.Controls.Add(this.BtnPrePage, 6, 1);
            this.tableLayoutPanel3.Controls.Add(this.BtnFirstPage, 4, 1);
            this.tableLayoutPanel3.Controls.Add(this.BtnAddCustomer, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.LblCurPage, 8, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(1, 558);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1243, 70);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // BtnLastPage
            // 
            this.BtnLastPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnLastPage.Location = new System.Drawing.Point(1083, 10);
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
            this.BtnNextPage.Location = new System.Drawing.Point(913, 10);
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
            this.BtnPrePage.Location = new System.Drawing.Point(573, 10);
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
            this.BtnFirstPage.Location = new System.Drawing.Point(403, 10);
            this.BtnFirstPage.Margin = new System.Windows.Forms.Padding(0);
            this.BtnFirstPage.Name = "BtnFirstPage";
            this.BtnFirstPage.Size = new System.Drawing.Size(150, 50);
            this.BtnFirstPage.TabIndex = 3;
            this.BtnFirstPage.Text = "第一页";
            this.BtnFirstPage.UseVisualStyleBackColor = true;
            this.BtnFirstPage.Click += new System.EventHandler(this.BtnFirstPage_Click);
            // 
            // BtnAddCustomer
            // 
            this.BtnAddCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnAddCustomer.Location = new System.Drawing.Point(10, 10);
            this.BtnAddCustomer.Margin = new System.Windows.Forms.Padding(0);
            this.BtnAddCustomer.Name = "BtnAddCustomer";
            this.BtnAddCustomer.Size = new System.Drawing.Size(150, 50);
            this.BtnAddCustomer.TabIndex = 4;
            this.BtnAddCustomer.Text = "添加客户";
            this.BtnAddCustomer.UseVisualStyleBackColor = true;
            this.BtnAddCustomer.Click += new System.EventHandler(this.BtnAddCustomer_Click);
            // 
            // LblCurPage
            // 
            this.LblCurPage.AutoSize = true;
            this.LblCurPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblCurPage.Location = new System.Drawing.Point(748, 15);
            this.LblCurPage.Margin = new System.Windows.Forms.Padding(5);
            this.LblCurPage.Name = "LblCurPage";
            this.LblCurPage.Size = new System.Drawing.Size(140, 40);
            this.LblCurPage.TabIndex = 5;
            this.LblCurPage.Text = "label2";
            this.LblCurPage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1245, 629);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.Text = "客户跟进系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewCustomerInfo)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblUserName;
        private System.Windows.Forms.DataGridView DataGridViewCustomerInfo;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private TableLayoutPanel tableLayoutPanel2;
        private Button BtnAccountManage;
        private Button BtnExit;
        private TableLayoutPanel tableLayoutPanel3;
        private Button BtnLastPage;
        private Button BtnNextPage;
        private Button BtnPrePage;
        private Button BtnFirstPage;
        private Button BtnAddCustomer;
        private Label LblCurPage;
        private ComboBox ComboBoxSeller;
    }
}