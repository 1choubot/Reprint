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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                using (var db = new ReprintEntities()) {
                    var users = db.User.ToList();
                    MessageBox.Show("数据库连接成功！用户数量：" + users.Count);
                }
            }
            catch (Exception ex) {
                MessageBox.Show("数据库连接失败 \n" + ex.Message);
            }
        }
    }
}
