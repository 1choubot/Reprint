using System.Threading;
using System.Windows.Media.Animation;

namespace Reprint.VIew
{
    partial class MainUserControl
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
            this.txtSystenTime = new System.Windows.Forms.Label();
            this.txtUserInfo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTestManager = new System.Windows.Forms.Button();
            this.btnSystemManager = new System.Windows.Forms.Button();
            this.btnSealManager = new System.Windows.Forms.Button();
            this.btnExitSystem = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.panel1.Controls.Add(this.txtSystenTime);
            this.panel1.Controls.Add(this.txtUserInfo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1200, 80);
            this.panel1.TabIndex = 0;
            // 
            // txtSystenTime
            // 
            this.txtSystenTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSystenTime.AutoSize = true;
            this.txtSystenTime.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.txtSystenTime.ForeColor = System.Drawing.Color.White;
            this.txtSystenTime.Location = new System.Drawing.Point(950, 20);
            this.txtSystenTime.Name = "txtSystenTime";
            this.txtSystenTime.Size = new System.Drawing.Size(59, 22);
            this.txtSystenTime.TabIndex = 3;
            this.txtSystenTime.Text = "label4";
            // 
            // txtUserInfo
            // 
            this.txtUserInfo.AutoSize = true;
            this.txtUserInfo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.txtUserInfo.ForeColor = System.Drawing.Color.White;
            this.txtUserInfo.Location = new System.Drawing.Point(200, 20);
            this.txtUserInfo.Name = "txtUserInfo";
            this.txtUserInfo.Size = new System.Drawing.Size(59, 22);
            this.txtUserInfo.TabIndex = 2;
            this.txtUserInfo.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(30, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "欢迎使用复刻系统";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(701, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "平衡轴多功能测试台";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.flowLayoutPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 80);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1200, 64);
            this.panel2.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flowLayoutPanel1.Controls.Add(this.btnTestManager);
            this.flowLayoutPanel1.Controls.Add(this.btnSystemManager);
            this.flowLayoutPanel1.Controls.Add(this.btnSealManager);
            this.flowLayoutPanel1.Controls.Add(this.btnExitSystem);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(20, 10, 0, 10);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1200, 64);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnTestManager
            // 
            this.btnTestManager.Location = new System.Drawing.Point(23, 13);
            this.btnTestManager.Name = "btnTestManager";
            this.btnTestManager.Size = new System.Drawing.Size(120, 36);
            this.btnTestManager.TabIndex = 0;
            this.btnTestManager.Text = "试验管理";
            this.btnTestManager.UseVisualStyleBackColor = true;
            this.btnTestManager.Click += new System.EventHandler(this.btnTestManager_Click);
            // 
            // btnSystemManager
            // 
            this.btnSystemManager.Location = new System.Drawing.Point(149, 13);
            this.btnSystemManager.Name = "btnSystemManager";
            this.btnSystemManager.Size = new System.Drawing.Size(120, 36);
            this.btnSystemManager.TabIndex = 0;
            this.btnSystemManager.Text = "系统管理";
            this.btnSystemManager.UseVisualStyleBackColor = true;
            this.btnSystemManager.Click += new System.EventHandler(this.btnSystemManager_Click);
            // 
            // btnSealManager
            // 
            this.btnSealManager.Location = new System.Drawing.Point(275, 13);
            this.btnSealManager.Name = "btnSealManager";
            this.btnSealManager.Size = new System.Drawing.Size(120, 36);
            this.btnSealManager.TabIndex = 0;
            this.btnSealManager.Text = "数据管理";
            this.btnSealManager.UseVisualStyleBackColor = true;
            // 
            // btnExitSystem
            // 
            this.btnExitSystem.Location = new System.Drawing.Point(401, 13);
            this.btnExitSystem.Name = "btnExitSystem";
            this.btnExitSystem.Size = new System.Drawing.Size(120, 36);
            this.btnExitSystem.TabIndex = 0;
            this.btnExitSystem.Text = "退出系统";
            this.btnExitSystem.UseVisualStyleBackColor = true;
            this.btnExitSystem.Click += new System.EventHandler(this.btnExitSystem_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 144);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1200, 624);
            this.panel3.TabIndex = 2;
            // 
            // MainUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "MainUserControl";
            this.Size = new System.Drawing.Size(1200, 768);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtSystenTime;
        private System.Windows.Forms.Label txtUserInfo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnExitSystem;
        private System.Windows.Forms.Button btnSealManager;
        private System.Windows.Forms.Button btnSystemManager;
        private System.Windows.Forms.Button btnTestManager;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
