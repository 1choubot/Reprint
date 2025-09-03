using System;
using System.Drawing;
using System.Windows.Forms;

namespace Reprint.VIew
{
    public partial class MainUserControl : UserControl
    {
        private Timer timer;
        private string currentUserName; // 字段：保存当前用户名
        public bool testIsStart = false;//系统状态
        public User userinfo = new User();

        public MainUserControl()
        {
            InitializeComponent();

            // 顶部美化
            panel1.BackColor = Color.FromArgb(45, 62, 80);
            label2.ForeColor = Color.White;
            label1.ForeColor = Color.White;
            txtUserInfo.ForeColor = Color.White;
            txtUserInfo.Font = new Font("微软雅黑", 12, FontStyle.Bold);
            txtSystenTime.ForeColor = Color.White;
            txtSystenTime.Font = new Font("微软雅黑", 12, FontStyle.Bold);
            //label1控件居中
            this.Load += MainUserControl_Load;
            this.panel1.SizeChanged += Panel1_SizeChanged;
            //退出系统
            btnExitSystem.Click += btnExitSystem_Click;
            //系统管理
            btnSystemManager.Click += btnSystemManager_Click;

            // 按钮美化
            foreach (var btn in new[] { btnTestManager, btnSystemManager, btnSealManager, btnExitSystem })
            {
                btn.BackColor = Color.LightSkyBlue;
                btn.FlatStyle = FlatStyle.Flat;
                btn.Font = new Font("微软雅黑", 11, FontStyle.Bold);
                btn.Width = 120;
                btn.Height = 36;
                btn.Margin = new Padding(10, 10, 10, 10);
            }

            panel2.BackColor = Color.WhiteSmoke;
            panel3.BackColor = Color.White;

            // 时间刷新
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += (s, e) =>
            {
                txtSystenTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); 
            };
            timer.Start();
        }

        
        //label1控件居中
        private void Panel1_SizeChanged(object sender, EventArgs e)
        {
            CenterLael1();
        }

        private void MainUserControl_Load(object sender, EventArgs e)
        {
            CenterLael1();
        }

        private void CenterLael1()
        {
            label1.Left = (panel1.Width - label1.Width) / 2;
        }

        public void SetUserInfo(string userName)
        {
            currentUserName = userName; // 保存当前用户名
            txtUserInfo.Text = $"欢迎，{userName}！";
        }

        //退出系统按钮事件
        private void btnExitSystem_Click(object sender, EventArgs e)
        {
            //获取主窗体并关闭
            var mainForm = this.FindForm();
            if (mainForm != null) {
                mainForm.Close();
            }
        }

        //系统管理按钮事件
        private void btnSystemManager_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            var systemManagerControl = new SystemManageControl(currentUserName);
            systemManagerControl.Dock = DockStyle.Fill;
            panel3.Controls.Add(systemManagerControl);
        }

        //试验管理按钮事件
        private void btnTestManager_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            var testControl = new TestControl(  userinfo,this);
            testControl.Dock = DockStyle.Fill;
            panel3.Controls.Add(testControl);
        }

        //数据管理按钮事件
        private void btnSealManager_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            var dataManageControl = new DataManageControl();
            dataManageControl.Dock = DockStyle.Fill;
            panel3.Controls.Add(dataManageControl);
        }
    }
}
