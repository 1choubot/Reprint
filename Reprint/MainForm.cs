using System;
using System.Windows.Forms;

namespace Reprint
{
    public partial class MainForm : Form
    {
        public MainForm(string userName)
        {
            InitializeComponent();

            this.Text = "案例复刻主界面";
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new System.Drawing.Size(1200, 800);

            var mainUserControl = new VIew.MainUserControl();
            mainUserControl.Dock = DockStyle.Fill;
            mainUserControl.SetUserInfo(userName); // 传递用户名
            this.Controls.Add(mainUserControl);
        }
    }
}
