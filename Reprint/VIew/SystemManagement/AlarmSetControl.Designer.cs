namespace Reprint
{
    partial class AlarmSetControl
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
            this.dgvAlarm = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumnModify = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewButtonColumnDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtStopValue = new System.Windows.Forms.TextBox();
            this.txtAlarmValue = new System.Windows.Forms.TextBox();
            this.cmbDataName = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlarm)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvAlarm);
            this.panel1.Controls.Add(this.txtUnit);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.txtStopValue);
            this.panel1.Controls.Add(this.txtAlarmValue);
            this.panel1.Controls.Add(this.cmbDataName);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(158, 91);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(691, 536);
            this.panel1.TabIndex = 0;
            // 
            // dgvAlarm
            // 
            this.dgvAlarm.AllowUserToAddRows = false;
            this.dgvAlarm.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvAlarm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlarm.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewButtonColumnModify,
            this.dataGridViewButtonColumnDelete});
            this.dgvAlarm.Location = new System.Drawing.Point(3, 224);
            this.dgvAlarm.Name = "dgvAlarm";
            this.dgvAlarm.RowTemplate.Height = 23;
            this.dgvAlarm.Size = new System.Drawing.Size(685, 309);
            this.dgvAlarm.TabIndex = 6;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "变量名";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "报警值";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "停机值";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "单位";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewButtonColumnModify
            // 
            this.dataGridViewButtonColumnModify.HeaderText = "";
            this.dataGridViewButtonColumnModify.Name = "dataGridViewButtonColumnModify";
            this.dataGridViewButtonColumnModify.Text = "修改";
            this.dataGridViewButtonColumnModify.UseColumnTextForButtonValue = true;
            // 
            // dataGridViewButtonColumnDelete
            // 
            this.dataGridViewButtonColumnDelete.HeaderText = "";
            this.dataGridViewButtonColumnDelete.Name = "dataGridViewButtonColumnDelete";
            this.dataGridViewButtonColumnDelete.Text = "删除";
            this.dataGridViewButtonColumnDelete.UseColumnTextForButtonValue = true;
            // 
            // txtUnit
            // 
            this.txtUnit.Location = new System.Drawing.Point(424, 93);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(121, 21);
            this.txtUnit.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(570, 130);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // txtStopValue
            // 
            this.txtStopValue.Location = new System.Drawing.Point(424, 168);
            this.txtStopValue.Name = "txtStopValue";
            this.txtStopValue.Size = new System.Drawing.Size(121, 21);
            this.txtStopValue.TabIndex = 3;
            // 
            // txtAlarmValue
            // 
            this.txtAlarmValue.Location = new System.Drawing.Point(167, 168);
            this.txtAlarmValue.Name = "txtAlarmValue";
            this.txtAlarmValue.Size = new System.Drawing.Size(121, 21);
            this.txtAlarmValue.TabIndex = 3;
            // 
            // cmbDataName
            // 
            this.cmbDataName.FormattingEnabled = true;
            this.cmbDataName.Location = new System.Drawing.Point(167, 94);
            this.cmbDataName.Name = "cmbDataName";
            this.cmbDataName.Size = new System.Drawing.Size(121, 20);
            this.cmbDataName.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(360, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "停机值";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(88, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "报警值";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(372, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "单位";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(100, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "变量";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(328, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "报警设置";
            // 
            // AlarmSetControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "AlarmSetControl";
            this.Size = new System.Drawing.Size(1048, 675);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlarm)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvAlarm;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtStopValue;
        private System.Windows.Forms.TextBox txtAlarmValue;
        private System.Windows.Forms.ComboBox cmbDataName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumnModify;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumnDelete;
    }
}
