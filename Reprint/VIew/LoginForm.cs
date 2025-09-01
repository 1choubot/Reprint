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
