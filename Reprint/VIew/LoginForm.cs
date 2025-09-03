using System;
using System.Windows.Forms;

namespace Reprint.VIew
{
    public partial class LoginForm : Form
    {
        public string UserName { get; private set; }// 添加UserName属性以便外部访问
        public LoginForm()
        {
            InitializeComponent();

            // 设置窗口最大化
            this.WindowState = FormWindowState.Maximized;
            // 禁止用户调整窗口大小
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            // 禁止最大化和最小化按钮
            this.MaximizeBox = false;
            this.MinimizeBox = true;

            var loginControl = new LoginControl();
            loginControl.Dock = DockStyle.Fill;
            this.Controls.Add(loginControl);

            loginControl.LoginSuccess += (s, e) =>
            {
                this.UserName = loginControl.textUserName.Text.Trim(); // 获取登录的用户名
                this.DialogResult = DialogResult.OK;
                this.Close();
            };
        }
    }
}
