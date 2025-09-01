using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reprint.VIew
{
    public partial class LoginControl : UserControl
    {
        public event EventHandler LoginSuccess;

        public LoginControl()
        {
            InitializeComponent();
            this.Resize += (s, e) =>
            {
                panel1.Left = (this.Width - panel1.Width) / 2;
                panel1.Top = (this.Height - panel1.Height) / 2;
            };
            // 初始化时也居中
            panel1.Left = (this.Width - panel1.Width) / 2;
            panel1.Top = (this.Height - panel1.Height) / 2;

            //记住账号密码
            textUserName.Text = Properties.Settings.Default.LastUserName;
            textPassword.Text = Properties.Settings.Default.LastPassword;

            this.Load += LoginControl_Load;
        }

        private void LoginControl_Load(object sender, EventArgs e)
        {
            textUserName.Focus();
        }

        //登录按钮
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = textUserName.Text.Trim();
            string password = textPassword.Text.Trim();

            if (string.IsNullOrEmpty(username)) {
                MessageBox.Show("用户名不能为空!");
                return;
            }
            if (string.IsNullOrEmpty(password)) {
                MessageBox.Show("密码不能为空！");
                return;
            }

            using (var db = new ReprintEntities()) {
                var user = db.User.FirstOrDefault(u =>u.UserName == username);
                if (user == null) { 
                    MessageBox.Show("用户不存在！");
                    return;
                }
                if (user.Password != password) { 
                    MessageBox.Show("密码错误！");
                    return;
                }

                //登录成功，保存账号密码
                Properties.Settings.Default.LastUserName = username;
                Properties.Settings.Default.LastPassword = password;
                Properties.Settings.Default.Save();

                MessageBox.Show("登录成功！");
                LoginSuccess?.Invoke(this, EventArgs.Empty);
            }
        }

        //重置按钮
        private void btnReset_Click(object sender, EventArgs e)
        {
            textPassword.Text = "";
            textUserName.Text = "";
            textUserName.Focus();
        }

       
    }
}
