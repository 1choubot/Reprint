namespace Reprint
{
    partial class ReadTestInfoForm
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
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductCode1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnProductGoto = new System.Windows.Forms.Button();
            this.txtProductSetPage = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtProductPageIndex = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtProductAllPage = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.testDataGrid = new System.Windows.Forms.DataGridView();
            this.btnSearchTest = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.testDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "时间";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "流水号";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "变速器编号";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // ProductCode1
            // 
            this.ProductCode1.HeaderText = "实验人员";
            this.ProductCode1.MinimumWidth = 6;
            this.ProductCode1.Name = "ProductCode1";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(460, 586);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(22, 14);
            this.label13.TabIndex = 32;
            this.label13.Text = "页";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.btnProductGoto);
            this.groupBox2.Controls.Add(this.txtProductSetPage);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.txtProductPageIndex);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.txtProductAllPage);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.testDataGrid);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(815, 617);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // btnProductGoto
            // 
            this.btnProductGoto.Font = new System.Drawing.Font("黑体", 9F);
            this.btnProductGoto.Location = new System.Drawing.Point(614, 582);
            this.btnProductGoto.Name = "btnProductGoto";
            this.btnProductGoto.Size = new System.Drawing.Size(71, 23);
            this.btnProductGoto.TabIndex = 35;
            this.btnProductGoto.Text = "跳转";
            this.btnProductGoto.UseVisualStyleBackColor = true;
            this.btnProductGoto.Click += new System.EventHandler(this.btnProductGoto_Click);
            // 
            // txtProductSetPage
            // 
            this.txtProductSetPage.BackColor = System.Drawing.Color.White;
            this.txtProductSetPage.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtProductSetPage.Location = new System.Drawing.Point(499, 583);
            this.txtProductSetPage.Name = "txtProductSetPage";
            this.txtProductSetPage.Size = new System.Drawing.Size(100, 23);
            this.txtProductSetPage.TabIndex = 34;
            this.txtProductSetPage.Text = "0";
            this.txtProductSetPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(118, 586);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(37, 14);
            this.label16.TabIndex = 28;
            this.label16.Text = "总共";
            // 
            // txtProductPageIndex
            // 
            this.txtProductPageIndex.BackColor = System.Drawing.Color.White;
            this.txtProductPageIndex.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtProductPageIndex.Location = new System.Drawing.Point(352, 584);
            this.txtProductPageIndex.Name = "txtProductPageIndex";
            this.txtProductPageIndex.ReadOnly = true;
            this.txtProductPageIndex.Size = new System.Drawing.Size(100, 23);
            this.txtProductPageIndex.TabIndex = 33;
            this.txtProductPageIndex.Text = "0";
            this.txtProductPageIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(268, 586);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(22, 14);
            this.label15.TabIndex = 29;
            this.label15.Text = "页";
            // 
            // txtProductAllPage
            // 
            this.txtProductAllPage.BackColor = System.Drawing.Color.White;
            this.txtProductAllPage.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtProductAllPage.Location = new System.Drawing.Point(163, 582);
            this.txtProductAllPage.Name = "txtProductAllPage";
            this.txtProductAllPage.ReadOnly = true;
            this.txtProductAllPage.Size = new System.Drawing.Size(100, 23);
            this.txtProductAllPage.TabIndex = 30;
            this.txtProductAllPage.Text = "0";
            this.txtProductAllPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(310, 588);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(37, 14);
            this.label14.TabIndex = 31;
            this.label14.Text = "当前";
            // 
            // testDataGrid
            // 
            this.testDataGrid.AllowUserToAddRows = false;
            this.testDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.testDataGrid.BackgroundColor = System.Drawing.Color.White;
            this.testDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.testDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.ProductCode1,
            this.dataGridViewTextBoxColumn4});
            this.testDataGrid.Location = new System.Drawing.Point(2, 29);
            this.testDataGrid.Margin = new System.Windows.Forms.Padding(2);
            this.testDataGrid.Name = "testDataGrid";
            this.testDataGrid.RowHeadersWidth = 51;
            this.testDataGrid.RowTemplate.Height = 27;
            this.testDataGrid.Size = new System.Drawing.Size(812, 539);
            this.testDataGrid.TabIndex = 20;
            // 
            // btnSearchTest
            // 
            this.btnSearchTest.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearchTest.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearchTest.Location = new System.Drawing.Point(538, 14);
            this.btnSearchTest.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearchTest.Name = "btnSearchTest";
            this.btnSearchTest.Size = new System.Drawing.Size(71, 23);
            this.btnSearchTest.TabIndex = 55;
            this.btnSearchTest.Text = "搜索";
            this.btnSearchTest.UseVisualStyleBackColor = true;
            this.btnSearchTest.Click += new System.EventHandler(this.btnSearchTest_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(322, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 59;
            this.label2.Text = "结束日期";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(173, 18);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(124, 21);
            this.dateTimePicker1.TabIndex = 58;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(115, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 57;
            this.label1.Text = "起始日期";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(380, 15);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(124, 21);
            this.dateTimePicker2.TabIndex = 60;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(815, 654);
            this.splitContainer1.SplitterDistance = 34;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnSelect);
            this.groupBox1.Controls.Add(this.btnSearchTest);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(815, 34);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btnSelect
            // 
            this.btnSelect.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSelect.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelect.Location = new System.Drawing.Point(631, 14);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(2);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(71, 23);
            this.btnSelect.TabIndex = 56;
            this.btnSelect.Text = "提取";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // ReadTestInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 654);
            this.Controls.Add(this.splitContainer1);
            this.Name = "ReadTestInfoForm";
            this.Text = "ReadTestInfoForm";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.testDataGrid)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductCode1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.Button btnProductGoto;
        public System.Windows.Forms.TextBox txtProductSetPage;
        private System.Windows.Forms.Label label16;
        public System.Windows.Forms.TextBox txtProductPageIndex;
        private System.Windows.Forms.Label label15;
        public System.Windows.Forms.TextBox txtProductAllPage;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.DataGridView testDataGrid;
        public System.Windows.Forms.Button btnSearchTest;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Button btnSelect;
    }
}