using System;
using System.Windows.Forms;

namespace Reprint
{
    public partial class MainForm : Form
    {
        public MainForm(string userName)
        {
            InitializeComponent();

            // 设置窗口最大化且不可调整大小
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = true;

            // 美化窗体
            this.BackColor = System.Drawing.Color.FromArgb(45, 62, 80); // 深色背景

            this.Text = "复刻案例";

            // 创建并挂载 MainUserControl
            var mainUserControl = new VIew.MainUserControl();
            mainUserControl.Dock = DockStyle.Fill;
            mainUserControl.SetUserInfo(userName); // 传递用户名
            this.Controls.Add(mainUserControl);
        }
    }
}
