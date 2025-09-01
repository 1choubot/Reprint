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
        public SystemManageControl(string currentUserName)
        {
            InitializeComponent();

            SyetemMaintenanceTreeView.AfterSelect += SystemMaintenanceTreeView_AfterSelect;
            _currentUserName = currentUserName;
            SyetemMaintenanceTreeView.AfterSelect += SystemMaintenanceTreeView_AfterSelect;
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
            else if (e.Node.Text == "报警设置") {
                panel2.Controls.Clear();
                var alarmSetControl = new AlarmSetControl();
                alarmSetControl.Dock = DockStyle.Fill;
                panel2.Controls.Add(alarmSetControl);

            }
        }
    }
}
