namespace Reprint
{
    partial class TestControl
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
            this.btnReadTestInfo = new System.Windows.Forms.Button();
            this.btnAddTestInfo = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtTestName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTestCode = new System.Windows.Forms.TextBox();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnInsertTest = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSetLongTime = new System.Windows.Forms.TextBox();
            this.txtTestType = new System.Windows.Forms.ComboBox();
            this.txtSetRunSpeed = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvStation = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnReflush = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStartTest = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtLoopLenShow = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtLoopLenSet = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtShowKeepTime = new System.Windows.Forms.TextBox();
            this.testState = new System.Windows.Forms.ListBox();
            this.displayControl1 = new Reprint.DisplayControl();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStation)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnReadTestInfo);
            this.panel1.Controls.Add(this.btnAddTestInfo);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtUserName);
            this.panel1.Controls.Add(this.txtTestName);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtTestCode);
            this.panel1.Controls.Add(this.txtTime);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(802, 111);
            this.panel1.TabIndex = 0;
            // 
            // btnReadTestInfo
            // 
            this.btnReadTestInfo.Location = new System.Drawing.Point(692, 49);
            this.btnReadTestInfo.Name = "btnReadTestInfo";
            this.btnReadTestInfo.Size = new System.Drawing.Size(75, 23);
            this.btnReadTestInfo.TabIndex = 121;
            this.btnReadTestInfo.Text = "提取";
            this.btnReadTestInfo.UseVisualStyleBackColor = true;
            // 
            // btnAddTestInfo
            // 
            this.btnAddTestInfo.Location = new System.Drawing.Point(584, 49);
            this.btnAddTestInfo.Name = "btnAddTestInfo";
            this.btnAddTestInfo.Size = new System.Drawing.Size(75, 23);
            this.btnAddTestInfo.TabIndex = 121;
            this.btnAddTestInfo.Text = "新增";
            this.btnAddTestInfo.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label10.Location = new System.Drawing.Point(40, 66);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 21);
            this.label10.TabIndex = 117;
            this.label10.Text = "试验人员";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label3.Location = new System.Drawing.Point(20, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 21);
            this.label3.TabIndex = 113;
            this.label3.Text = "试验轴代号";
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.txtUserName.Location = new System.Drawing.Point(116, 62);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(176, 26);
            this.txtUserName.TabIndex = 118;
            // 
            // txtTestName
            // 
            this.txtTestName.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.txtTestName.Location = new System.Drawing.Point(116, 27);
            this.txtTestName.Name = "txtTestName";
            this.txtTestName.Size = new System.Drawing.Size(176, 26);
            this.txtTestName.TabIndex = 114;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label4.Location = new System.Drawing.Point(325, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 21);
            this.label4.TabIndex = 115;
            this.label4.Text = "流水号";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label6.Location = new System.Drawing.Point(319, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 21);
            this.label6.TabIndex = 119;
            this.label6.Text = "日     期";
            // 
            // txtTestCode
            // 
            this.txtTestCode.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.txtTestCode.Location = new System.Drawing.Point(391, 28);
            this.txtTestCode.Name = "txtTestCode";
            this.txtTestCode.Size = new System.Drawing.Size(176, 26);
            this.txtTestCode.TabIndex = 116;
            // 
            // txtTime
            // 
            this.txtTime.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.txtTime.Location = new System.Drawing.Point(391, 63);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(176, 26);
            this.txtTime.TabIndex = 120;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnInsertTest);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtSetLongTime);
            this.panel2.Controls.Add(this.txtTestType);
            this.panel2.Controls.Add(this.txtSetRunSpeed);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(0, 117);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(802, 100);
            this.panel2.TabIndex = 1;
            // 
            // btnInsertTest
            // 
            this.btnInsertTest.Location = new System.Drawing.Point(674, 33);
            this.btnInsertTest.Name = "btnInsertTest";
            this.btnInsertTest.Size = new System.Drawing.Size(75, 23);
            this.btnInsertTest.TabIndex = 127;
            this.btnInsertTest.Text = "保存";
            this.btnInsertTest.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label2.Location = new System.Drawing.Point(20, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 21);
            this.label2.TabIndex = 123;
            this.label2.Text = "试验类型";
            // 
            // txtSetLongTime
            // 
            this.txtSetLongTime.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txtSetLongTime.Location = new System.Drawing.Point(555, 30);
            this.txtSetLongTime.Name = "txtSetLongTime";
            this.txtSetLongTime.Size = new System.Drawing.Size(67, 29);
            this.txtSetLongTime.TabIndex = 124;
            this.txtSetLongTime.Text = "0";
            // 
            // txtTestType
            // 
            this.txtTestType.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txtTestType.FormattingEnabled = true;
            this.txtTestType.Items.AddRange(new object[] {
            "转速检测",
            "角度测试",
            "磨合",
            "冷驱动耐久",
            "高温高速耐久"});
            this.txtTestType.Location = new System.Drawing.Point(100, 30);
            this.txtTestType.Name = "txtTestType";
            this.txtTestType.Size = new System.Drawing.Size(116, 29);
            this.txtTestType.TabIndex = 126;
            // 
            // txtSetRunSpeed
            // 
            this.txtSetRunSpeed.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txtSetRunSpeed.Location = new System.Drawing.Point(352, 30);
            this.txtSetRunSpeed.Name = "txtSetRunSpeed";
            this.txtSetRunSpeed.Size = new System.Drawing.Size(89, 29);
            this.txtSetRunSpeed.TabIndex = 122;
            this.txtSetRunSpeed.Text = "100";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label1.Location = new System.Drawing.Point(231, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 21);
            this.label1.TabIndex = 121;
            this.label1.Text = "运行转速(rpm)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label5.Location = new System.Drawing.Point(458, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 21);
            this.label5.TabIndex = 125;
            this.label5.Text = "持续时段(s)";
            // 
            // dgvStation
            // 
            this.dgvStation.BackgroundColor = System.Drawing.Color.White;
            this.dgvStation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewButtonColumn1,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dgvStation.Location = new System.Drawing.Point(0, 224);
            this.dgvStation.Margin = new System.Windows.Forms.Padding(4);
            this.dgvStation.Name = "dgvStation";
            this.dgvStation.ReadOnly = true;
            this.dgvStation.RowHeadersWidth = 51;
            this.dgvStation.RowTemplate.Height = 23;
            this.dgvStation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvStation.Size = new System.Drawing.Size(781, 632);
            this.dgvStation.TabIndex = 114;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "编号";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 66;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "试验类型";
            this.dataGridViewTextBoxColumn7.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 84;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.FillWeight = 131.7595F;
            this.dataGridViewTextBoxColumn6.HeaderText = "运行转速(rpm）";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 120;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "持续时段(s)";
            this.dataGridViewTextBoxColumn8.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 120;
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.HeaderText = "";
            this.dataGridViewButtonColumn1.MinimumWidth = 6;
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.ReadOnly = true;
            this.dataGridViewButtonColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewButtonColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewButtonColumn1.Width = 90;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 90;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 90;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 90;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.btnReflush);
            this.panel4.Controls.Add(this.btnStop);
            this.panel4.Controls.Add(this.btnStartTest);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.txtLoopLenShow);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.txtLoopLenSet);
            this.panel4.Controls.Add(this.label15);
            this.panel4.Controls.Add(this.txtShowKeepTime);
            this.panel4.Location = new System.Drawing.Point(780, 587);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(391, 270);
            this.panel4.TabIndex = 116;
            // 
            // btnReflush
            // 
            this.btnReflush.Location = new System.Drawing.Point(290, 29);
            this.btnReflush.Name = "btnReflush";
            this.btnReflush.Size = new System.Drawing.Size(75, 23);
            this.btnReflush.TabIndex = 117;
            this.btnReflush.Text = "刷新";
            this.btnReflush.UseVisualStyleBackColor = true;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(165, 29);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 117;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            // 
            // btnStartTest
            // 
            this.btnStartTest.Location = new System.Drawing.Point(36, 29);
            this.btnStartTest.Name = "btnStartTest";
            this.btnStartTest.Size = new System.Drawing.Size(75, 23);
            this.btnStartTest.TabIndex = 117;
            this.btnStartTest.Text = "启动";
            this.btnStartTest.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label12.Location = new System.Drawing.Point(79, 117);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(106, 21);
            this.label12.TabIndex = 116;
            this.label12.Text = "循环运行状态";
            // 
            // txtLoopLenShow
            // 
            this.txtLoopLenShow.BackColor = System.Drawing.Color.Black;
            this.txtLoopLenShow.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txtLoopLenShow.ForeColor = System.Drawing.Color.Aqua;
            this.txtLoopLenShow.Location = new System.Drawing.Point(191, 114);
            this.txtLoopLenShow.Name = "txtLoopLenShow";
            this.txtLoopLenShow.ReadOnly = true;
            this.txtLoopLenShow.Size = new System.Drawing.Size(71, 29);
            this.txtLoopLenShow.TabIndex = 115;
            this.txtLoopLenShow.Text = "1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(79, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 21);
            this.label7.TabIndex = 112;
            this.label7.Text = "循环次数设定";
            // 
            // txtLoopLenSet
            // 
            this.txtLoopLenSet.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txtLoopLenSet.Location = new System.Drawing.Point(191, 70);
            this.txtLoopLenSet.Name = "txtLoopLenSet";
            this.txtLoopLenSet.Size = new System.Drawing.Size(71, 29);
            this.txtLoopLenSet.TabIndex = 111;
            this.txtLoopLenSet.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label15.Location = new System.Drawing.Point(92, 161);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(93, 21);
            this.label15.TabIndex = 114;
            this.label15.Text = "持续时段(S)";
            // 
            // txtShowKeepTime
            // 
            this.txtShowKeepTime.BackColor = System.Drawing.Color.Black;
            this.txtShowKeepTime.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txtShowKeepTime.ForeColor = System.Drawing.Color.Aqua;
            this.txtShowKeepTime.Location = new System.Drawing.Point(191, 158);
            this.txtShowKeepTime.Name = "txtShowKeepTime";
            this.txtShowKeepTime.ReadOnly = true;
            this.txtShowKeepTime.Size = new System.Drawing.Size(71, 29);
            this.txtShowKeepTime.TabIndex = 113;
            this.txtShowKeepTime.Text = "25.3";
            // 
            // testState
            // 
            this.testState.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.testState.FormattingEnabled = true;
            this.testState.ItemHeight = 19;
            this.testState.Location = new System.Drawing.Point(1178, 587);
            this.testState.Margin = new System.Windows.Forms.Padding(4);
            this.testState.Name = "testState";
            this.testState.Size = new System.Drawing.Size(687, 270);
            this.testState.TabIndex = 117;
            // 
            // displayControl1
            // 
            this.displayControl1.Location = new System.Drawing.Point(780, 0);
            this.displayControl1.Name = "displayControl1";
            this.displayControl1.Size = new System.Drawing.Size(1103, 589);
            this.displayControl1.TabIndex = 118;
            // 
            // TestControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.displayControl1);
            this.Controls.Add(this.testState);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.dgvStation);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "TestControl";
            this.Size = new System.Drawing.Size(1869, 856);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStation)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            // 事件绑定，建议放在 InitializeComponent() 方法最后
            this.btnAddTestInfo.Click += new System.EventHandler(this.btnAddTestInfo_Click);
            this.btnReadTestInfo.Click += new System.EventHandler(this.btnReadTestInfo_Click);
            this.btnInsertTest.Click += new System.EventHandler(this.btnInsertTest_Click);
            this.btnReflush.Click += new System.EventHandler(this.btnReflush_Click);
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            this.btnStartTest.Click += new System.EventHandler(this.btnStartTest_Click);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnReadTestInfo;
        private System.Windows.Forms.Button btnAddTestInfo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtTestName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTestCode;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSetLongTime;
        private System.Windows.Forms.ComboBox txtTestType;
        private System.Windows.Forms.TextBox txtSetRunSpeed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnInsertTest;
        private System.Windows.Forms.DataGridView dgvStation;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn Column3;
        private System.Windows.Forms.DataGridViewButtonColumn Column4;
        private System.Windows.Forms.DataGridViewButtonColumn Column5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtLoopLenShow;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtLoopLenSet;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtShowKeepTime;
        private System.Windows.Forms.Button btnReflush;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStartTest;
        private System.Windows.Forms.ListBox testState;
        private DisplayControl displayControl1;
    }
}
