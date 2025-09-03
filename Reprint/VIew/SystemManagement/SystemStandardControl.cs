using Reprint;
using Reprint.Module;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsSoftwear.Module;

namespace Reprint
{
    public partial class SystemStandardControl : UserControl
    {
        private CommonBLL commonBll = new CommonBLL();
        private PLCCom modbusTcp = new PLCCom();
        private SystemStanderd systemStanderd = new SystemStanderd();
        private Thread displayThread;
        private bool isStarten = false;
        private bool displayThreadRunning = false;
        public SystemStandardControl()
        {
            InitializeComponent();
            this.Load += SystemStandardControl_Load;
            btnStart.Click += btnStart_Click;
            btnWrite.Click += btnWrite_Click;
            txtAimSpeed.TextChanged += txtAimSpeed_TextChanged;
            txtScreeSpeed.TextChanged += txtScreeSpeed_TextChanged;
            txtImportTorque.TextChanged += txtImportTorque_TextChanged;
        }

        //输入校验
        private void SystemStandardControl_Load(object sender, EventArgs e)
        {
            txtAimSpeed.KeyPress += commonBll.InputInt_KeyPress;
            txtScreeSpeed.KeyPress += commonBll.InputInt_KeyPress;
            txtTorque.KeyPress += commonBll.InputFloat_KeyPress;

            var systemStandards = commonBll.sdEntities.SystemStanderd.ToList();
            if (systemStandards.Count <= 0)
            {
                systemStanderd = new SystemStanderd() { Id = 0, Offset = 0.0 };
            }
            else
            {
                systemStanderd = systemStandards[0];
            }

            CenterContentPanel();
            this.SizeChanged += (s, args) => CenterContentPanel();
        }

        private void CenterContentPanel()
        {
            panel1.Left = (this.Width - panel1.Width) / 2;
            panel1.Top = (this.Height - panel1.Height) / 2;
;        }

        //参数范围限制
        private void txtAimSpeed_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtAimSpeed.Text, out int value) && value > 200)
            {
                MessageBox.Show("转速最高限定200");
                txtAimSpeed.Text = "200";
            }
        }

        private void txtScreeSpeed_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtScreeSpeed.Text, out int value) && value > 20)
            {
                MessageBox.Show("加速度最高限定20");
                txtScreeSpeed.Text = "20";
            }
        }

        private void txtImportTorque_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtImportTorque.Text, out int value) && value > 280)
            {
                MessageBox.Show("输入转速最高限定280");
                txtImportTorque.Text = "280";
            }
        }

        //启动/停止设备
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!isStarten)
            {
                modbusTcp.Start();
                if (displayThread == null)
                {
                    displayThreadRunning = true;
                    displayThread = new Thread(Display);
                    displayThread.IsBackground = true;
                    displayThread.Start();
                }
                modbusTcp.Send(10003, Convert.ToDouble(txtAimSpeed.Text));
                ShowState("转速" + txtAimSpeed.Text + "写入");
                modbusTcp.Send(10004, Convert.ToDouble(txtScreeSpeed.Text));
                ShowState("加速度" + txtScreeSpeed.Text + "写入");
                modbusTcp.Send(10005, 1);
                ShowState("运行启动");
                btnStart.Text = "停止";
                isStarten = true;
            }
            else
            {
                modbusTcp.Send(10005, 0);
                modbusTcp.Stop();
                displayThreadRunning = false;
                displayThreadRunning = false;
                if (displayThread != null)
                {
                    displayThread.Join(100); // 等待线程结束
                    displayThread = null;
                }
                ShowState("运行停止");
                btnStart.Text = "启动";
                isStarten = false;
            }
        }

        protected override void Dispose(bool disposing)
        {
            // 线程安全退出
            displayThreadRunning = false;
            if (displayThread != null)
            {
                displayThread.Join(100);
                displayThread = null;
            }

            // 保留 Designer 自动生成的资源释放
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        //状态显示
        private void ShowState(string stateStr)
        {
            richTextBox1.Text += commonBll.GetNowTimeStrsSmall() + "/" + stateStr + "\n";
        }

        //实时数据刷新线程
        private void Display()
        {
            while (displayThreadRunning)
            {
                if (!this.IsDisposed && !this.Disposing)
                {
                    this.Invoke((EventHandler)(delegate
                    {
                        if (modbusTcp != null && modbusTcp.comConnected)
                        {
                            // 刷新界面数据
                        }
                    }));
                }
                Thread.Sleep(50);
            }
        }

        //保定参数保存
        private void btnWrite_Click(object sender, EventArgs e)
        {
            double offset = Convert.ToDouble(txtImportTorque.Text) - Convert.ToDouble(txtTorque.Text);
            if (systemStanderd != null)
            {
                systemStanderd.Offset = offset;
                commonBll.sdEntities.SystemStanderd.AddOrUpdate(systemStanderd);
            }
            else
            {
                systemStanderd = new SystemStanderd() { Offset = offset };
                commonBll.sdEntities.SystemStanderd.Add(systemStanderd);
            }
            commonBll.sdEntities.SaveChanges();
            MessageBox.Show("标记成功");
        }

        

    }
}
