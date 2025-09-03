using Reprint.VIew;
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
    public partial class SystemManageControl : UserControl
    {
        private string _currentUserName;
        private MainUserControl mainUserControl;

        public SystemManageControl(string currentUserName)
        {
            InitializeComponent();

            // 美化TreeView
            SyetemMaintenanceTreeView.BackColor = Color.FromArgb(240, 243, 250);
            SyetemMaintenanceTreeView.ForeColor = Color.FromArgb(45, 62, 80);
            SyetemMaintenanceTreeView.Font = new Font("微软雅黑", 11, FontStyle.Bold);
            SyetemMaintenanceTreeView.BorderStyle = BorderStyle.None;
            SyetemMaintenanceTreeView.ItemHeight = 32;
            SyetemMaintenanceTreeView.HideSelection = false;
            SyetemMaintenanceTreeView.FullRowSelect = true;

            // 美化panel2
            panel2.BackColor = Color.White;
            panel2.Padding = new Padding(20);

            // 美化主背景
            this.BackColor = Color.FromArgb(245, 247, 252);

            // 美化按钮（假设有按钮控件）
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.BackColor = Color.LightSkyBlue;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.Font = new Font("微软雅黑", 11, FontStyle.Bold);
                    btn.ForeColor = Color.White;
                    btn.Height = 40;
                    btn.Width = 140;
                    btn.Margin = new Padding(10, 10, 10, 10);
                }
            }

            SyetemMaintenanceTreeView.AfterSelect += SystemMaintenanceTreeView_AfterSelect;
            _currentUserName = currentUserName;
            SyetemMaintenanceTreeView.AfterSelect += SystemMaintenanceTreeView_AfterSelect;

            mainUserControl = new MainUserControl();
        }

        private void SystemMaintenanceTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text == "添加用户")
            {
                panel2.Controls.Clear();
                var userInfoControl = new UserInfoControl(_currentUserName);//传递当前用户名;
                userInfoControl.Dock = DockStyle.Fill;
                panel2.Controls.Add(userInfoControl);
            }
            else if (e.Node.Text == "修改密码")
            {
                panel2.Controls.Clear();
                var changePwdControl = new ChangePwdControl(_currentUserName);
                changePwdControl.Dock = DockStyle.Fill;
                panel2.Controls.Add(changePwdControl);
            }
            else if (e.Node.Text == "报警设置")
            {
                panel2.Controls.Clear();
                var alarmSetControl = new AlarmSetControl();
                alarmSetControl.Dock = DockStyle.Fill;
                panel2.Controls.Add(alarmSetControl);

            }
            else if (e.Node.Text == "自定义通道")
            {
                panel2.Controls.Clear();
                var defineChannelControl = new DefineChannelControl();
                defineChannelControl.Dock = DockStyle.Fill;
                panel2.Controls.Add(defineChannelControl);
            }
            else if (e.Node.Text == "系统标定")
            {
                panel2.Controls.Clear();
                var systemStandardControl = new SystemStandardControl();
                systemStandardControl.Dock = DockStyle.Fill;
                panel2.Controls.Add(systemStandardControl);
            }
            else if (e.Node.Text == "系统调试") {
                panel2.Controls.Clear();
                var systemTestControl = new SystemTestControl(mainUserControl);
                systemTestControl.Dock = DockStyle.Fill;
                panel2.Controls.Add(systemTestControl);
            }
        }
    }
}
