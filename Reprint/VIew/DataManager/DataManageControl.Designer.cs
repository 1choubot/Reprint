namespace Reprint
{
    partial class DataManageControl
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTestCode = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTestName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.dgvStation = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.displayControl1 = new Reprint.DisplayControl();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtShowSpeed = new System.Windows.Forms.TextBox();
            this.dtpOverTime = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtState = new System.Windows.Forms.ListBox();
            this.btnReadTestInfo = new System.Windows.Forms.Button();
            this.btnSelectData = new System.Windows.Forms.Button();
            this.btnReadData = new System.Windows.Forms.Button();
            this.btnStartShow = new System.Windows.Forms.Button();
            this.btnStopShow = new System.Windows.Forms.Button();
            this.btnImportData = new System.Windows.Forms.Button();
            this.btnImportDgv = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStation)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnReadTestInfo);
            this.panel1.Controls.Add(this.txtTime);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtUserName);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txtTestCode);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txtTestName);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Location = new System.Drawing.Point(3, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(797, 88);
            this.panel1.TabIndex = 1;
            // 
            // txtTime
            // 
            this.txtTime.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.txtTime.Location = new System.Drawing.Point(397, 46);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(176, 26);
            this.txtTime.TabIndex = 24;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label7.Location = new System.Drawing.Point(325, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 21);
            this.label7.TabIndex = 23;
            this.label7.Text = "日     期";
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.txtUserName.Location = new System.Drawing.Point(113, 47);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(176, 26);
            this.txtUserName.TabIndex = 22;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label10.Location = new System.Drawing.Point(38, 51);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 21);
            this.label10.TabIndex = 21;
            this.label10.Text = "试验人员";
            // 
            // txtTestCode
            // 
            this.txtTestCode.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.txtTestCode.Location = new System.Drawing.Point(397, 11);
            this.txtTestCode.Name = "txtTestCode";
            this.txtTestCode.Size = new System.Drawing.Size(176, 26);
            this.txtTestCode.TabIndex = 19;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(331, 14);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 21);
            this.label11.TabIndex = 18;
            this.label11.Text = "流水号";
            // 
            // txtTestName
            // 
            this.txtTestName.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.txtTestName.Location = new System.Drawing.Point(113, 12);
            this.txtTestName.Name = "txtTestName";
            this.txtTestName.Size = new System.Drawing.Size(176, 26);
            this.txtTestName.TabIndex = 17;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label12.Location = new System.Drawing.Point(23, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(90, 21);
            this.label12.TabIndex = 16;
            this.label12.Text = "平衡轴代号";
            // 
            // dgvStation
            // 
            this.dgvStation.BackgroundColor = System.Drawing.Color.White;
            this.dgvStation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column3,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn8});
            this.dgvStation.Location = new System.Drawing.Point(3, 94);
            this.dgvStation.Name = "dgvStation";
            this.dgvStation.ReadOnly = true;
            this.dgvStation.RowHeadersWidth = 51;
            this.dgvStation.RowTemplate.Height = 23;
            this.dgvStation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvStation.Size = new System.Drawing.Size(795, 685);
            this.dgvStation.TabIndex = 87;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "编号";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 147;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "试验类型";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 200;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.FillWeight = 131.7595F;
            this.dataGridViewTextBoxColumn6.HeaderText = "运行转速(rpm）";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 200;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "持续时段(m)";
            this.dataGridViewTextBoxColumn8.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 200;
            // 
            // displayControl1
            // 
            this.displayControl1.Location = new System.Drawing.Point(795, 0);
            this.displayControl1.Name = "displayControl1";
            this.displayControl1.Size = new System.Drawing.Size(1102, 584);
            this.displayControl1.TabIndex = 88;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.btnImportDgv);
            this.panel4.Controls.Add(this.btnImportData);
            this.panel4.Controls.Add(this.btnStopShow);
            this.panel4.Controls.Add(this.btnStartShow);
            this.panel4.Controls.Add(this.btnReadData);
            this.panel4.Controls.Add(this.btnSelectData);
            this.panel4.Controls.Add(this.dtpStartTime);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.txtShowSpeed);
            this.panel4.Controls.Add(this.dtpOverTime);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Location = new System.Drawing.Point(795, 597);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(720, 182);
            this.panel4.TabIndex = 89;
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartTime.Location = new System.Drawing.Point(104, 57);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.Size = new System.Drawing.Size(170, 21);
            this.dtpStartTime.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label1.Location = new System.Drawing.Point(29, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 21);
            this.label1.TabIndex = 22;
            this.label1.Text = "起始时间";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label2.Location = new System.Drawing.Point(279, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 21);
            this.label2.TabIndex = 23;
            this.label2.Text = "结束时间";
            // 
            // txtShowSpeed
            // 
            this.txtShowSpeed.Location = new System.Drawing.Point(628, 57);
            this.txtShowSpeed.Name = "txtShowSpeed";
            this.txtShowSpeed.Size = new System.Drawing.Size(71, 21);
            this.txtShowSpeed.TabIndex = 27;
            this.txtShowSpeed.Text = "100";
            // 
            // dtpOverTime
            // 
            this.dtpOverTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpOverTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOverTime.Location = new System.Drawing.Point(353, 57);
            this.dtpOverTime.Name = "dtpOverTime";
            this.dtpOverTime.Size = new System.Drawing.Size(163, 21);
            this.dtpOverTime.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label3.Location = new System.Drawing.Point(525, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 21);
            this.label3.TabIndex = 26;
            this.label3.Text = "回放速度(ms)";
            // 
            // txtState
            // 
            this.txtState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtState.Font = new System.Drawing.Font("微软雅黑", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtState.FormattingEnabled = true;
            this.txtState.ItemHeight = 20;
            this.txtState.Location = new System.Drawing.Point(1519, 597);
            this.txtState.Margin = new System.Windows.Forms.Padding(4);
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(378, 182);
            this.txtState.TabIndex = 90;
            // 
            // btnReadTestInfo
            // 
            this.btnReadTestInfo.Location = new System.Drawing.Point(632, 32);
            this.btnReadTestInfo.Name = "btnReadTestInfo";
            this.btnReadTestInfo.Size = new System.Drawing.Size(75, 23);
            this.btnReadTestInfo.TabIndex = 25;
            this.btnReadTestInfo.Text = "提取";
            this.btnReadTestInfo.UseVisualStyleBackColor = true;
            this.btnReadTestInfo.Click += new System.EventHandler(this.btnReadTestInfo_Click);
            // 
            // btnSelectData
            // 
            this.btnSelectData.Location = new System.Drawing.Point(48, 113);
            this.btnSelectData.Name = "btnSelectData";
            this.btnSelectData.Size = new System.Drawing.Size(75, 23);
            this.btnSelectData.TabIndex = 25;
            this.btnSelectData.Text = "查询实验";
            this.btnSelectData.UseVisualStyleBackColor = true;
            this.btnSelectData.Click += new System.EventHandler(this.btnSelectData_Click);
            // 
            // btnReadData
            // 
            this.btnReadData.Location = new System.Drawing.Point(177, 113);
            this.btnReadData.Name = "btnReadData";
            this.btnReadData.Size = new System.Drawing.Size(75, 23);
            this.btnReadData.TabIndex = 25;
            this.btnReadData.Text = "提取数据";
            this.btnReadData.UseVisualStyleBackColor = true;
            this.btnReadData.Click += new System.EventHandler(this.btnReadData_Click);
            // 
            // btnStartShow
            // 
            this.btnStartShow.Location = new System.Drawing.Point(296, 113);
            this.btnStartShow.Name = "btnStartShow";
            this.btnStartShow.Size = new System.Drawing.Size(75, 23);
            this.btnStartShow.TabIndex = 25;
            this.btnStartShow.Text = "开始回放";
            this.btnStartShow.UseVisualStyleBackColor = true;
            this.btnStartShow.Click += new System.EventHandler(this.btnStartShow_Click);
            // 
            // btnStopShow
            // 
            this.btnStopShow.Location = new System.Drawing.Point(404, 113);
            this.btnStopShow.Name = "btnStopShow";
            this.btnStopShow.Size = new System.Drawing.Size(75, 23);
            this.btnStopShow.TabIndex = 25;
            this.btnStopShow.Text = "停止回放";
            this.btnStopShow.UseVisualStyleBackColor = true;
            this.btnStopShow.Click += new System.EventHandler(this.btnStopShow_Click);
            // 
            // btnImportData
            // 
            this.btnImportData.Location = new System.Drawing.Point(510, 113);
            this.btnImportData.Name = "btnImportData";
            this.btnImportData.Size = new System.Drawing.Size(75, 23);
            this.btnImportData.TabIndex = 25;
            this.btnImportData.Text = "图片导出";
            this.btnImportData.UseVisualStyleBackColor = true;
            this.btnImportData.Click += new System.EventHandler(this.btnImportData_Click);
            // 
            // btnImportDgv
            // 
            this.btnImportDgv.Location = new System.Drawing.Point(611, 113);
            this.btnImportDgv.Name = "btnImportDgv";
            this.btnImportDgv.Size = new System.Drawing.Size(75, 23);
            this.btnImportDgv.TabIndex = 25;
            this.btnImportDgv.Text = "Excel导出";
            this.btnImportDgv.UseVisualStyleBackColor = true;
            this.btnImportDgv.Click += new System.EventHandler(this.btnImportDgv_Click);
            // 
            // DataManageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtState);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.displayControl1);
            this.Controls.Add(this.dgvStation);
            this.Controls.Add(this.panel1);
            this.Name = "DataManageControl";
            this.Size = new System.Drawing.Size(1897, 785);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStation)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtTestCode;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtTestName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView dgvStation;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DisplayControl displayControl1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtShowSpeed;
        private System.Windows.Forms.DateTimePicker dtpOverTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox txtState;
        private System.Windows.Forms.Button btnReadTestInfo;
        private System.Windows.Forms.Button btnImportDgv;
        private System.Windows.Forms.Button btnImportData;
        private System.Windows.Forms.Button btnStopShow;
        private System.Windows.Forms.Button btnStartShow;
        private System.Windows.Forms.Button btnReadData;
        private System.Windows.Forms.Button btnSelectData;
    }
}
