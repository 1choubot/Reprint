namespace Reprint
{
    partial class SystemStandardControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
    /*    protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }*/

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTorque = new System.Windows.Forms.Label();
            this.txtAimSpeed = new System.Windows.Forms.TextBox();
            this.txtScreeSpeed = new System.Windows.Forms.TextBox();
            this.txtImportTorque = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnWrite = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.richTextBox1);
            this.panel1.Controls.Add(this.btnWrite);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Controls.Add(this.txtImportTorque);
            this.panel1.Controls.Add(this.txtScreeSpeed);
            this.panel1.Controls.Add(this.txtAimSpeed);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtTorque);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(204, 94);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(693, 386);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(318, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "系统标定";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "速度设定";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(318, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "加速度设定";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 201);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "采集转速(rpm)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(300, 201);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "输入转速(rpm)";
            // 
            // txtTorque
            // 
            this.txtTorque.AutoSize = true;
            this.txtTorque.Location = new System.Drawing.Point(177, 201);
            this.txtTorque.Name = "txtTorque";
            this.txtTorque.Size = new System.Drawing.Size(23, 12);
            this.txtTorque.TabIndex = 0;
            this.txtTorque.Text = "100";
            // 
            // txtAimSpeed
            // 
            this.txtAimSpeed.Location = new System.Drawing.Point(144, 112);
            this.txtAimSpeed.Name = "txtAimSpeed";
            this.txtAimSpeed.Size = new System.Drawing.Size(100, 21);
            this.txtAimSpeed.TabIndex = 1;
            // 
            // txtScreeSpeed
            // 
            this.txtScreeSpeed.Location = new System.Drawing.Point(416, 112);
            this.txtScreeSpeed.Name = "txtScreeSpeed";
            this.txtScreeSpeed.Size = new System.Drawing.Size(100, 21);
            this.txtScreeSpeed.TabIndex = 1;
            // 
            // txtImportTorque
            // 
            this.txtImportTorque.Location = new System.Drawing.Point(416, 198);
            this.txtImportTorque.Name = "txtImportTorque";
            this.txtImportTorque.Size = new System.Drawing.Size(100, 21);
            this.txtImportTorque.TabIndex = 1;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(566, 110);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "启动";
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // btnWrite
            // 
            this.btnWrite.Location = new System.Drawing.Point(566, 196);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(75, 23);
            this.btnWrite.TabIndex = 2;
            this.btnWrite.Text = "标定";
            this.btnWrite.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(3, 239);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(687, 144);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // SystemStandardControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "SystemStandardControl";
            this.Size = new System.Drawing.Size(1118, 567);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnWrite;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtImportTorque;
        private System.Windows.Forms.TextBox txtScreeSpeed;
        private System.Windows.Forms.TextBox txtAimSpeed;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label txtTorque;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
