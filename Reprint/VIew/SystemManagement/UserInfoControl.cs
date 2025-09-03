using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reprint
{
    public partial class UserInfoControl : UserControl
    {

        public UserInfoControl(string currentUserName ="")
        {
            InitializeComponent();

            //显示当前用户名
            txtUserName.Text = currentUserName;
            //注册按钮事件
            btnAdd.Click += btnAdd_Click;
            /* //注册删除按钮事件
             btnDel.Click += btnDel_Click;*/
            //设置DataGridView允许单元格选中
            dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridView1.MultiSelect = false;

            //加载用户类型
            using (var db = new ReprintEntities())
            {
                var types = db.UserType.Select(t => t.TypeName).ToList();
                cmbType.DataSource = types;

                //绑定用户列表
                var users = db.User
                    .Select(u => new
                    {
                        用户姓名 = u.UserName,
                        用户类型 = u.UserType.TypeName
                    })
                    .ToList();

                dataGridView1.DataSource = users;
            }

            // 居中内容Panel
            CenterContentPanel();
            this.SizeChanged += (s, args) => CenterContentPanel();
        }

        private void CenterContentPanel()
        {
            if (panel1 != null)
            {
                panel1.Left = (this.Width - panel1.Width) / 2;
                panel1.Top = (this.Height - panel1.Height) / 2;
            }
        }

        //添加用户
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text.Trim();
            string typeName = cmbType.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(userName)) { 
                MessageBox.Show("用户名不能为空！");
                return;
            }
            if (string.IsNullOrEmpty(typeName)) { 
                MessageBox.Show("请选择用户类型！");
                return;
            }

            using (var db = new ReprintEntities()) {
                //获取对应的TypeId
                var userType = db.UserType.FirstOrDefault(t => t.TypeName == typeName);
                if (userType == null) {
                    MessageBox.Show("用户类型不存在!");
                    return;
                }
                //检查用户名是否已存在
                if (db.User.Any(u => u.UserName == userName)) { 
                    MessageBox.Show("用户名已存在！");
                    return;
                }
                //添加新用户
                var newUser = new User
                {
                    UserName = userName,
                    TypeId = userType.TypeId,
                    Password = "123456"
                };

                db.User.Add(newUser);
                db.SaveChanges();
                MessageBox.Show("用户添加成功！");

                //刷新用户列表
                var users = db.User
                    .Select(u => new
                    {
                        用户姓名 = u.UserName,
                        用户类型 = u.UserType.TypeName
                    })
                    .ToList();
                dataGridView1.DataSource = users;
            }
        }

        //删除用户
        private void btnDel_Click(object sender, EventArgs e)
        {
            // 检查是否有选中单元格
            if (dataGridView1.CurrentCell == null)
            {
                MessageBox.Show("请先选择要删除的用户！");
                return;
            }

            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            var row = dataGridView1.Rows[rowIndex];
            string userName = row.Cells["用户姓名"].Value?.ToString();

            if (string.IsNullOrEmpty(userName))
            {
                MessageBox.Show("未能获取到用户信息!");
                return;
            }

            var result = MessageBox.Show($"确定删除用户{userName}吗？", "确认删除", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
            {
                return;
            }

            using (var db = new ReprintEntities())
            {
                var user = db.User.FirstOrDefault(u => u.UserName == userName);
                if (user == null)
                {
                    MessageBox.Show("用户不存在或已被删除！");
                    return;
                }
                db.User.Remove(user);
                db.SaveChanges();
                MessageBox.Show("用户删除成功！");

                //刷新用户列表
                var users = db.User
                    .Select(u => new
                    {
                        用户姓名 = u.UserName,
                        用户类型 = u.UserType.TypeName
                    })
                    .ToList();
                dataGridView1.DataSource = users;
            }
        }
    }
}
