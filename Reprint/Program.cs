using Reprint.VIew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reprint
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            while (true)
            {
                string userName = ""; // 登录成功后获取
                using (var loginForm = new VIew.LoginForm())
                {
                    if (loginForm.ShowDialog() == DialogResult.OK)
                    {
                        userName = loginForm.UserName; // 需要在LoginForm里暴露UserName属性
                        using (var mainForm = new MainForm(userName))
                        {
                            Application.Run(new MainForm(userName));
                        }
                    }
                    else {
                        //登录窗体取消或关闭，退出程序
                        break;
                    }
                }
            }   
        }
    }
}
