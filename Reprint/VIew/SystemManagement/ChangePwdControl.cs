using System;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Reprint
{
    public partial class ChangePwdControl : UserControl
    {
        private string _originalUserName;

        public ChangePwdControl(string currentUserName)
        {
            InitializeComponent();
            _originalUserName = currentUserName;
            lblUserName.Text = _originalUserName;

            CenterContentPanel();
            this.SizeChanged += (s, args) => CenterContentPanel();
        }

        private void CenterContentPanel()
        {
            panel1.Left = (this.Width - panel1.Left) / 2;
            panel1.Top = (this.Height - panel1.Height) / 2;
;        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string oldPwd = txtOldPassword.Text.Trim();
            string newPwd = txtNewPassword.Text.Trim();
            string confirmPwd = txtConfirmPassword.Text.Trim();

            if (string.IsNullOrEmpty(oldPwd) || string.IsNullOrEmpty(newPwd) || string.IsNullOrEmpty(confirmPwd))
            {
                MessageBox.Show("请填写所有字段！");
                return;
            }

            if (newPwd != confirmPwd)
            {
                MessageBox.Show("新密码与确认密码不一致！");
                return;
            }

            if (oldPwd == newPwd) { 
                MessageBox.Show("新密码不能与原密码相同！");
                return;
            }

            if (newPwd.Length < 6 || newPwd.Length > 20) { 
                MessageBox.Show("新密码长度应在6到20个字符之间！");
                return;
            }

            using (var db = new ReprintEntities())
            {
                var user = db.User.FirstOrDefault(u => u.UserName == _originalUserName);
                if (user == null)
                {
                    MessageBox.Show("用户不存在！");
                    return;
                }
                if (user.Password != oldPwd)
                {
                    MessageBox.Show("原密码不正确！");
                    return;
                }

                user.Password = newPwd;
                db.SaveChanges();
                MessageBox.Show("密码修改成功！");
                txtOldPassword.Clear();
                txtNewPassword.Clear();
                txtConfirmPassword.Clear();
            }
        }
    }
}
