namespace Reprint
{
    partial class SystemManageControl
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("报警设置");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("自定义通道");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("系统标定");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("系统调试");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("添加用户");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("修改密码");
            this.panel1 = new System.Windows.Forms.Panel();
            this.SyetemMaintenanceTreeView = new System.Windows.Forms.TreeView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.SyetemMaintenanceTreeView);
            this.panel1.Location = new System.Drawing.Point(0, -6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 691);
            this.panel1.TabIndex = 0;
            // 
            // SyetemMaintenanceTreeView
            // 
            this.SyetemMaintenanceTreeView.Location = new System.Drawing.Point(0, 6);
            this.SyetemMaintenanceTreeView.Name = "SyetemMaintenanceTreeView";
            treeNode1.Name = "节点0";
            treeNode1.Text = "报警设置";
            treeNode2.Name = "节点1";
            treeNode2.Text = "自定义通道";
            treeNode3.Name = "节点2";
            treeNode3.Text = "系统标定";
            treeNode4.Name = "节点3";
            treeNode4.Text = "系统调试";
            treeNode5.Name = "节点4";
            treeNode5.Text = "添加用户";
            treeNode6.Name = "节点5";
            treeNode6.Text = "修改密码";
            this.SyetemMaintenanceTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6});
            this.SyetemMaintenanceTreeView.Size = new System.Drawing.Size(237, 701);
            this.SyetemMaintenanceTreeView.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(233, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1155, 710);
            this.panel2.TabIndex = 1;
            // 
            // SystemManageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "SystemManageControl";
            this.Size = new System.Drawing.Size(1388, 713);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView SyetemMaintenanceTreeView;
        private System.Windows.Forms.Panel panel2;
    }
}
