using HslCommunication;
using HslCommunication.Profinet.Siemens;
using Reprint.Module;
using Reprint.VIew;
using System;
using System.Net.NetworkInformation;
using System.Threading;
using System.Windows.Forms;

namespace Reprint
{
    public partial class SystemTestControl : UserControl
    {
        private CommonBLL commonBll = new CommonBLL();
        private int DisplayTimeCount = 1000;
        private Thread displayThread = null;
        private Thread read200Thread = null;
        private Thread read1200Thread = null;
        private SiemensS7Net siemens200TcpNet = new SiemensS7Net(SiemensPLCS.S200Smart);
        private SiemensS7Net siemens1200TcpNet = new SiemensS7Net(SiemensPLCS.S1200);
        private OperateResult<short[]> read200Arry = new OperateResult<short[]>();
        private OperateResult<float[]> read1200Arry = new OperateResult<float[]>();
        private short[] read200Data;
        private float[] read1200Data = new float[12];
        private OperateResult connect200State;
        private OperateResult connect1200State = new OperateResult();
        private ushort dataLen = 39;
        public MainUserControl mainUserControl;

        public SystemTestControl(MainUserControl mainUserControl_)
        {
            InitializeComponent();
            mainUserControl = mainUserControl_;
            this.Load += SystemTestControl_Load;
            // 事件绑定（如有其它控件事件请在此补充）
            btnConnect200.Click += btnConnect200_Click;
            btnDisconnect200.Click += btnDisconnect200_Click;
            btnConnect1200.Click += btnConnect1200_Click;
            btnDisconnect1200.Click += btnDisconnect1200_Click;
            btnPLCHeatMotorOpen.Click += btnPLCHeatMotorOpen_Click;
            btnPLCHeatMotorClose.Click += btnPLCHeatMotorClose_Click;
            btnPLCBearMotorOpen.Click += btnPLCBearMotorOpen_Click;
            btnPLCBearMotorClose.Click += btnPLCBearMotorClose_Click;
            btnPLCCoolOpen.Click += btnPLCCoolOpen_Click;
            btnPLCCoolClose.Click += btnPLCCoolClose_Click;
            btnPLCHeatOpen.Click += btnPLCHeatOpen_Click;
            btnPLCHeatClose.Click += btnPLCHeatClose_Click;
            btnWriteSetRunSpeed.Click += btnWriteSetRunSpeed_Click;
            btnMotorEnble.Click += btnMotorEnble_Click;
            btnMotorStart.Click += btnMotorStart_Click;
            btnMotorStop.Click += btnMotorStop_Click;
            txtMASetRunSpeed.TextChanged += txtMASetRunSpeed_TextChanged;
            txtSetStepSpeed.TextChanged += txtSetStepSpeed_TextChanged;
        }

        private void SystemTestControl_Load(object sender, EventArgs e)
        {
            foreach (Control ctrl in panel3.Controls)
            {
                if (ctrl is TextBox)
                {
                    if (ctrl.Name == "txtMASetRunSpeed")
                        ctrl.KeyPress += commonBll.InputIntOrNeg_KeyPress;
                    else
                        ctrl.KeyPress += commonBll.InputInt_KeyPress;
                }
            }

        }

        private void ShowState(string stateStr)
        {
            txtState.Items.Insert(0, commonBll.GetNowTimeStrsSmall() + ":" + stateStr);
        }

        private void display()
        {
            while (true)
            {
                if (IsDisposed || Disposing) break;
                this.Invoke((EventHandler)(delegate
                {
                    // 200PLC数据显示
                    if (read200Data != null)
                    {
                        string bstr1 = Convert.ToString(read200Data[0], 2);
                        bstr1 = commonBll.AppendFrontStr(bstr1, "0", 16);
                        bstr1 = commonBll.Reverse1(bstr1);
                        txtPLCEstop.Text = bstr1.Substring(8, 1) == "0" ? "是" : "否";
                        txtPLCRomate.Text = bstr1.Substring(10, 1) == "1" ? "远程" : "本地";

                        string bstr2 = Convert.ToString(read200Data[17], 2);
                        bstr2 = commonBll.AppendFrontStr(bstr2, "0", 16);
                        bstr2 = commonBll.Reverse1(bstr2);
                        txtPLCHeater.Text = bstr2.Substring(9, 1) == "0" ? "关" : "开";
                        txtPLCHeaterMotor.Text = bstr2.Substring(10, 1) == "0" ? "关" : "开";
                        txtPLCCoolMotor.Text = bstr2.Substring(11, 1) == "0" ? "关" : "开";

                        txtPLCHeatTemp1.Text = Math.Round((double)read200Data[5] / 10, 1).ToString();
                        txtPLCHeatTemp2.Text = Math.Round((double)read200Data[6] / 10, 1).ToString();
                        txtPLCLubeTemp.Text = Math.Round((double)read200Data[7] / 10, 1).ToString();
                        txtMianBearTemp.Text = Math.Round((double)read200Data[8] / 10, 1).ToString();
                        txtPLCBearTemp.Text = Math.Round((double)read200Data[9] / 10, 1).ToString();
                        txtPLCRoomTemp.Text = Math.Round((double)read200Data[10] / 10, 1).ToString();
                    }

                    // 1200PLC数据显示
                    if (read1200Data != null)
                    {
                        txtMotorRunSpeed.Text = Math.Round(read1200Data[0], 0).ToString();
                        txtMotorTemp.Text = Math.Round(read1200Data[2], 1).ToString();
                        txtMotorSetSpeed.Text = Math.Round(read1200Data[3], 0).ToString();
                        txtMotorSetStepSpeed.Text = Math.Round(read1200Data[4], 1).ToString();
                        txtMotorFaultState.Text = Math.Round(read1200Data[7], 0).ToString();
                        btnMotorEnbleY.Text = read1200Data[8] > 0 ? "是" : "否";
                    }
                }));
                Thread.Sleep(DisplayTimeCount);
            }
        }

        private void btnConnect200_Click(object sender, EventArgs e)
        {
            if (connect200State != null && connect200State.IsSuccess) return;
            read200Data = new short[dataLen];
            if (!System.Net.IPAddress.TryParse(txt200PLCIP.Text, out _))
            {
                ShowState("Ip地址输入不正确！");
                return;
            }
            connect200();
        }

        private void connect200()
        {
            siemens200TcpNet.IpAddress = txt200PLCIP.Text;
            try
            {
                connect200State = siemens200TcpNet.ConnectServer();
                if (connect200State.IsSuccess)
                {
                    if (read200Thread == null)
                    {
                        read200Thread = new Thread(read200);
                        read200Thread.IsBackground = true;
                        read200Thread.Start();
                    }
                    if (displayThread == null)
                    {
                        displayThread = new Thread(display);
                        displayThread.IsBackground = true;
                        displayThread.Start();
                    }
                    ShowState("200PLC连接成功！");
                }
                else
                {
                    ShowState("200PLC连接失败！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void read200()
        {
            while (true)
            {
                if (IsDisposed || Disposing) break;
                if (connect200State.IsSuccess)
                {
                    read200Arry = siemens200TcpNet.ReadInt16("V0", dataLen);
                    if (read200Arry.Content != null)
                    {
                        for (int i = 0; i < dataLen; i++)
                            read200Data[i] = read200Arry.Content[i];
                    }
                }
                else
                {
                    connect200();
                }
                Thread.Sleep(DisplayTimeCount);
            }
        }

        private void btnDisconnect200_Click(object sender, EventArgs e)
        {
            if (read200Thread != null)
            {
                read200Thread.Abort();
                read200Thread = null;
            }
            if (read1200Thread == null && displayThread != null)
            {
                displayThread.Abort();
                displayThread = null;
            }
            ShowState("200PLC连接断开！");
        }

        private void btnPLCHeatMotorOpen_Click(object sender, EventArgs e)
        {
            if (connect200State == null || !connect200State.IsSuccess)
            {
                MessageBox.Show("通信未连接", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            siemens200TcpNet.Write("V4.2", true);
        }

        private void btnPLCHeatMotorClose_Click(object sender, EventArgs e)
        {
            if (connect200State == null || !connect200State.IsSuccess)
            {
                MessageBox.Show("通信未连接", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            siemens200TcpNet.Write("V4.2", false);
        }

        private void btnPLCBearMotorOpen_Click(object sender, EventArgs e)
        {
            if (connect200State == null || !connect200State.IsSuccess)
            {
                MessageBox.Show("通信未连接", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            siemens200TcpNet.Write("V5.5", true);
        }

        private void btnPLCBearMotorClose_Click(object sender, EventArgs e)
        {
            if (connect200State == null || !connect200State.IsSuccess)
            {
                MessageBox.Show("通信未连接", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            siemens200TcpNet.Write("V5.5", false);
        }

        private void btnPLCCoolOpen_Click(object sender, EventArgs e)
        {
            if (connect200State == null || !connect200State.IsSuccess)
            {
                MessageBox.Show("通信未连接", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            siemens200TcpNet.Write("V6.3", true);
        }

        private void btnPLCCoolClose_Click(object sender, EventArgs e)
        {
            if (connect200State == null || !connect200State.IsSuccess)
            {
                MessageBox.Show("通信未连接", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            siemens200TcpNet.Write("V6.3", false);
        }

        private void btnPLCHeatOpen_Click(object sender, EventArgs e)
        {
            if (connect200State == null || !connect200State.IsSuccess)
            {
                MessageBox.Show("通信未连接", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            siemens200TcpNet.Write("V4.1", true);
        }

        private void btnPLCHeatClose_Click(object sender, EventArgs e)
        {
            if (connect200State == null || !connect200State.IsSuccess)
            {
                MessageBox.Show("通信未连接", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            siemens200TcpNet.Write("V4.1", false);
        }

        private void btnConnect1200_Click(object sender, EventArgs e)
        {
            if (connect1200State != null && connect1200State.IsSuccess) return;
            if (!System.Net.IPAddress.TryParse(txtMAIP.Text, out _))
            {
                ShowState("Ip地址输入不正确！");
                return;
            }
            connect1200();
        }

        private void connect1200()
        {
            siemens1200TcpNet.IpAddress = txtMAIP.Text;
            try
            {
                connect1200State = siemens1200TcpNet.ConnectServer();
                if (connect1200State.IsSuccess)
                {
                    if (read1200Thread == null)
                    {
                        read1200Thread = new Thread(read1200);
                        read1200Thread.IsBackground = true;
                        read1200Thread.Start();
                    }
                    if (displayThread == null)
                    {
                        displayThread = new Thread(display);
                        displayThread.IsBackground = true;
                        displayThread.Start();
                    }
                    ShowState("1200PLC连接成功！");
                }
                else
                {
                    ShowState("1200PLC连接失败！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void read1200()
        {
            while (true)
            {
                if (IsDisposed || Disposing) break;
                if (connect1200State.IsSuccess)
                {
                    read1200Arry = siemens1200TcpNet.ReadFloat("M800", 12);
                    if (read1200Arry.Content != null)
                    {
                        for (int i = 0; i < 12; i++)
                            read1200Data[i] = read1200Arry.Content[i];
                    }
                }
                else
                {
                    connect1200();
                }
                Thread.Sleep(DisplayTimeCount);
            }
        }

        private void btnDisconnect1200_Click(object sender, EventArgs e)
        {
            if (read1200Thread != null)
            {
                read1200Thread.Abort();
                read1200Thread = null;
            }
            if (read200Thread == null && displayThread != null)
            {
                displayThread.Abort();
                displayThread = null;
            }
            ShowState("1200PLC连接断开！");
        }

        private void txtMASetRunSpeed_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtMASetRunSpeed.Text, out int value))
            {
                if (value > 7500)
                {
                    MessageBox.Show("转速最高限定7500", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMASetRunSpeed.Text = "7500";
                }
                if (value < -7500)
                {
                    MessageBox.Show("转速最低限定-7500", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMASetRunSpeed.Text = "-7500";
                }
            }
        }

        private void btnWriteSetRunSpeed_Click(object sender, EventArgs e)
        {
            if (connect1200State == null || !connect1200State.IsSuccess)
            {
                MessageBox.Show("通信未连接", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            siemens1200TcpNet.Write("M812", float.Parse(txtMASetRunSpeed.Text));
            siemens1200TcpNet.Write("M816", float.Parse(txtSetStepSpeed.Text));
        }

        private void txtSetStepSpeed_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtSetStepSpeed.Text, out int value))
            {
                if (value > 120)
                {
                    MessageBox.Show("升降速率最高限定120", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSetStepSpeed.Text = "120";
                }
                if (value < 0)
                {
                    MessageBox.Show("升降速率最低限定80", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSetStepSpeed.Text = "80";
                }
            }
        }

        private void btnMotorEnble_Click(object sender, EventArgs e)
        {
            if (connect1200State == null || !connect1200State.IsSuccess)
            {
                MessageBox.Show("通信未连接", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (read1200Data[8] > 0)
                siemens1200TcpNet.Write("M1000.0", false);
            else
                siemens1200TcpNet.Write("M1000.0", true);
        }

        private void btnMotorStart_Click(object sender, EventArgs e)
        {
            if (connect1200State == null || !connect1200State.IsSuccess)
            {
                MessageBox.Show("通信未连接", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            siemens1200TcpNet.Write("M1000.1", true);
            siemens1200TcpNet.Write("M1000.1", false);
            mainUserControl.testIsStart = true;
        }

        private void btnMotorStop_Click(object sender, EventArgs e)
        {
            if (connect1200State == null || !connect1200State.IsSuccess)
            {
                MessageBox.Show("通信未连接", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            siemens1200TcpNet.Write("M1000.2", true);
            siemens1200TcpNet.Write("M1000.2", false);
            mainUserControl.testIsStart = false;
        }

        protected override void Dispose(bool disposing)
        {
            // 线程安全退出
            if (read200Thread != null)
            {
                read200Thread.Abort();
                read200Thread = null;
            }
            if (read1200Thread != null)
            {
                read1200Thread.Abort();
                read1200Thread = null;
            }
            if (displayThread != null)
            {
                displayThread.Abort();
                displayThread = null;
            }
            // 调用 Designer 自动生成的资源释放
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}