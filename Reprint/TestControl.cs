using HslCommunication;
using HslCommunication.Profinet.Siemens;
using Reprint.Module;
using Reprint.VIew;
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

namespace Reprint
{
    public partial class TestControl : UserControl
    {
        //说明：存储和显示，面对的是数据模型，只跟试验功能有关，
        //在启动的时候，初始化定义后，通信读取各自的缓存，解析各自的缓存数据到数据模型即OK

        /// <summary>
        /// 公共操作类
        /// </summary>
        CommonBLL commonBll = new CommonBLL();

        /// <summary>
        /// 登录用户
        /// </summary>
        private User userInfo;

        /// <summary>
        /// 说明：存储和显示，面对的是数据模型，只跟试验功能有关，
        /// 在启动的时候，初始化定义后，通信读取各自的缓存，解析各自的缓存数据到数据模型即OK
        /// </summary>
        private string[] dataModule = new string[27];

        /// <summary>
        /// 实验启动标识
        /// </summary>
        private bool testIsStart = false;

        public MainUserControl mainUserControl;
        #region Method
        List<AlarmData> realAlarmDatas = new List<AlarmData>();

        public TestControl(User userInfo_, MainUserControl mainUserControl_)
        {
            userInfo = userInfo_;
            mainUserControl = mainUserControl_;
            InitializeComponent();

            InitializeAlarm();

        }

        private void StartTestControl_Load(object sender, EventArgs e)
        {
            displayData.ComState = StateStr.否;
            displayData.StartState = StateStr.否;
            displayData.EstopState = StateStr.否;
            displayData.AlarmState = StateStr.否;

            displayData.MotorSpeed = 0;
            displayData.MotorTemp = 0;
            displayData.LubeTemp = 0;
            displayData.MainBearTemp = 0;
            displayData.BearTemp = 0;
            displayData.HeatTemp = 0;
            displayData.RoomTemp = 0;
            displayData.ARTReadData = new string[16];
            displayData.ARTReadName = new string[16];
            for (int i = 0; i < 16; i++)
            {
                displayData.ARTReadName[i] = "未定义" + (i + 1).ToString();
                displayData.ARTReadData[i] = "0";
            }

            txtSetRunSpeed.KeyPress += commonBll.InputIntOrNeg_KeyPress;
            // txtHighTemp.KeyPress += commonBll.InputFloatOrNeg_KeyPress;
            // txtLowTemp.KeyPress += commonBll.InputFloatOrNeg_KeyPress;
            txtSetLongTime.KeyPress += commonBll.InputIntOrNeg_KeyPress;
            // txtActiveTime.KeyPress += commonBll.InputIntOrNeg_KeyPress;
            txtLoopLenSet.KeyPress += commonBll.InputInt_KeyPress;
            InitializeDefineChannel();
        }

        /// <summary>
        /// 初始化报警数据
        /// </summary>
        private void InitializeAlarm()
        {
            realAlarmDatas.Clear();
            realAlarmDatas.Add(new AlarmData() { AlarmNum = 0, AlarmContent = "PLC通信异常", AlarmIsOn = false });
            realAlarmDatas.Add(new AlarmData() { AlarmNum = 1, AlarmContent = "ART通信异常", AlarmIsOn = false });
            realAlarmDatas.Add(new AlarmData() { AlarmNum = 2, AlarmContent = "急停", AlarmIsOn = false });
            realAlarmDatas.Add(new AlarmData() { AlarmNum = 3, AlarmContent = "变频器报警", AlarmIsOn = false });
            realAlarmDatas.Add(new AlarmData() { AlarmNum = 4, AlarmContent = "加热器温度传感器断线", AlarmIsOn = false });
            realAlarmDatas.Add(new AlarmData() { AlarmNum = 5, AlarmContent = "加热器报警温度传感器断线", AlarmIsOn = false });
            realAlarmDatas.Add(new AlarmData() { AlarmNum = 6, AlarmContent = "润滑油温度传感器断线", AlarmIsOn = false });
            realAlarmDatas.Add(new AlarmData() { AlarmNum = 7, AlarmContent = "主轴温度传感器断线", AlarmIsOn = false });
            realAlarmDatas.Add(new AlarmData() { AlarmNum = 8, AlarmContent = "环境仓温度传感器断线", AlarmIsOn = false });
            realAlarmDatas.Add(new AlarmData() { AlarmNum = 9, AlarmContent = "电机超速报警", AlarmIsOn = false });
            realAlarmDatas.Add(new AlarmData() { AlarmNum = 10, AlarmContent = "电机超速停机", AlarmIsOn = false });
            realAlarmDatas.Add(new AlarmData() { AlarmNum = 11, AlarmContent = "电机超温报警", AlarmIsOn = false });
            realAlarmDatas.Add(new AlarmData() { AlarmNum = 12, AlarmContent = "电机超温停机", AlarmIsOn = false });
            realAlarmDatas.Add(new AlarmData() { AlarmNum = 13, AlarmContent = "主轴超温报警", AlarmIsOn = false });
            realAlarmDatas.Add(new AlarmData() { AlarmNum = 14, AlarmContent = "主轴超温停机", AlarmIsOn = false });
            realAlarmDatas.Add(new AlarmData() { AlarmNum = 15, AlarmContent = "加热器超温报警", AlarmIsOn = false });
            realAlarmDatas.Add(new AlarmData() { AlarmNum = 16, AlarmContent = "加热器超温停机", AlarmIsOn = false });

        }

        #region 操作试验

        /// <summary>
        /// 当前实际操作的试验对象
        /// </summary>
        public TestInfo realTestInfo = null;

        /// <summary>
        /// 当前显示的试验工况
        /// </summary>
        private List<WorkStation> displayWorkStations = new List<WorkStation>();
        /// <summary>
        /// 当前选择的尚未进入试验流程的试验工况
        /// </summary>
        private List<WorkStation> selectWorkStations = new List<WorkStation>();

        /// <summary>
        /// 新增试验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddTestInfo_Click(object sender, EventArgs e)
        {
            if (testIsStart)
            {
                MessageBox.Show("试验正在运行，不能操作试验信息", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            TestInfo testInfo = new TestInfo()
            {
                TestCode = txtTestCode.Text.Trim(),
                TestName = txtTestName.Text.Trim(),
                TestType = txtTestType.Text.Trim(),
                UserName = userInfo.UserName,
                Time = commonBll.CreatTimeStr()
            };
            if (string.IsNullOrEmpty(testInfo.TestName))
            {
                MessageBox.Show("试验名称不能为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(testInfo.TestCode))
            {
                MessageBox.Show("试验编号不能为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (commonBll.sdEntities.TestInfo.Where(a => a.TestCode == testInfo.TestCode).ToList().Count > 0)
            {
                MessageBox.Show("试验编号已经存在", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            testInfo.Time = commonBll.CreatTimeStr();
            commonBll.sdEntities.TestInfo.Add(testInfo);
            commonBll.sdEntities.SaveChanges();
            realTestInfo = testInfo;
            DisplayTestInfo();
        }

        /// <summary>
        /// 显示试验信息
        /// </summary>
        /// <param name="testInfo"></param>
        private void DisplayTestInfo()
        {
            if (realTestInfo == null)
            {
                return;
            }
            txtTestCode.Text = realTestInfo.TestCode;
            txtTestName.Text = realTestInfo.TestName;
            txtTime.Text = realTestInfo.Time;
            txtUserName.Text = realTestInfo.UserName;
            DisplayTestWorkStation();
        }

        /// <summary>
        /// 显示试验工况
        /// </summary>
        /// <param name="testInfo"></param>
        private void DisplayTestWorkStation()
        {
            //if (realTestInfo == null)
            //{
            //    return;
            //}
            //displayWorkStations = commonBll.sdEntities.WorkStation.Where(a => a.TestCode == realTestInfo.TestCode).ToList();
            //dgvStation.Rows.Clear();
            //if (displayWorkStations.Count > 0)
            //{
            //    List<WorkStation> compWorkStations = displayWorkStations.OrderBy(a => a.WorkStationId).ToList();

            //    for (int i = 0; i < compWorkStations.Count; i++)
            //    {
            //        dgvStation.Rows.Add(new[]
            //        {

            //           compWorkStations[i].WorkStationId.ToString(),
            //           compWorkStations[i].TestType,
            //           compWorkStations[i].SetRunSpeed.ToString(),
            //           compWorkStations[i].SetLongTime.ToString(),
            //           "上移", "下移", "修改", "删除"
            //        });
            //    }
            //}
            dgvStation.Rows.Add(new[]
                    {
                       "1", "高温高速耐久测试", "1500", "1000", "上移", "下移", "修改", "删除"

                    });
            dgvStation.Rows.Add(new[]
                    {
                       "2", "冷驱动耐久测试", "1500", "1000", "上移", "下移", "修改", "删除"
                    });
            dgvStation.Rows.Add(new[]
                    {
                       "3", "角度测试", "1500", "1000", "上移", "下移", "修改", "删除"
                    });
            dgvStation.Rows.Add(new[]
                    {
                       "4", "转速测试", "1500", "1000", "上移", "下移", "修改", "删除"
                    });
        }

        /// <summary>
        /// 插入试验工况
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsertTest_Click(object sender, EventArgs e)
        {
            //if (testIsStart)
            //{
            //    new MessageBoxForm("试验正在运行，不能操作试验信息", MessageBoxForm.MessageType.Erro).Show();
            //    return;
            //}
            //if (realTestInfo == null)
            //{
            //    new MessageBoxForm("请先添加或者选择试验信息", MessageBoxForm.MessageType.Erro).Show();
            //    return;
            //}
            //try
            //{
            //    WorkStation workStation = new WorkStation();
            //    if (midWorkStation != null)      //
            //    {
            //        workStation = midWorkStation;
            //    }

            //    if (midWorkStation == null)
            //    {
            //        workStation.TestCode = realTestInfo.TestCode;
            //        workStation.WorkStationId = displayWorkStations.Count + 1;
            //    }

            //    workStation.SetRunSpeed = int.Parse(txtSetRunSpeed.Text);
            //    workStation.SetLongTime = int.Parse(txtSetLongTime.Text);
            //    workStation.AccrossSpeed = 100;
            //    //workStation.HighTemp = double.Parse(txtHighTemp.Text);
            //    //workStation.LowTemp = double.Parse(txtLowTemp.Text);
            //    //workStation.SetActiveTime = int.Parse(txtActiveTime.Text);
            //    workStation.TestType = txtTestType.Text;



            //    if (txtTestType.Text == "饱和试验" && workStation.SetLongTime >= workStation.SetActiveTime)
            //    {
            //        new MessageBoxForm("持续时间不能大于有效时间", MessageBoxForm.MessageType.Erro).Show();
            //        return;
            //    }
            //    if (workStation.HighTemp <= workStation.LowTemp)
            //    {
            //        new MessageBoxForm("温度下限不能高于温度上限", MessageBoxForm.MessageType.Erro).Show();
            //        return;
            //    }
            //    if (workStation.SetRunSpeed > 8000)
            //    {
            //        new MessageBoxForm("速度设定不能超过800rpm", MessageBoxForm.MessageType.Erro).Show();
            //        return;
            //    }
            //    commonBll.sdEntities.WorkStation.AddOrUpdate(workStation);
            //    commonBll.sdEntities.SaveChanges();
            //    midWorkStation = null;
            DisplayTestWorkStation();
            //}
            //catch (Exception ex)
            //{
            //    new MessageBoxForm(ex.Message, MessageBoxForm.MessageType.Erro).Show();
            //    return;
            //}

        }

        /// <summary>
        /// 删除试验工况
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvStation_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 7)
            {
                if (MessageBox.Show("确定要删除吗？", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.No)
                {
                    return;
                }
                int deleteWorkStationId = int.Parse(dgvStation.Rows[e.RowIndex].Cells[0].Value.ToString());
                List<WorkStation> deleteWorkStations = commonBll.sdEntities.WorkStation.Where(a => a.TestCode == realTestInfo.TestCode && a.WorkStationId == deleteWorkStationId).ToList();
                if (deleteWorkStations.Count <= 0)
                {
                    return;
                }
                commonBll.sdEntities.WorkStation.Remove(deleteWorkStations[0]);
                commonBll.sdEntities.SaveChanges();
                List<WorkStation> allWorkStations = commonBll.sdEntities.WorkStation.Where(a => a.TestCode == realTestInfo.TestCode).ToList();
                if (allWorkStations.Count > 0)
                {
                    for (int i = 0; i < allWorkStations.Count; i++)
                    {
                        commonBll.sdEntities.WorkStation.Remove(allWorkStations[i]);
                        commonBll.sdEntities.SaveChanges();
                        allWorkStations[i].WorkStationId = i + 1;
                        commonBll.sdEntities.WorkStation.Add(allWorkStations[i]);
                        commonBll.sdEntities.SaveChanges();
                    }
                }
                DisplayTestWorkStation();
            }
            if (e.ColumnIndex == 4)
            {
                if (e.RowIndex == 0)
                {
                    return;
                }


                List<WorkStation> workStations = commonBll.sdEntities.WorkStation.Where(a => a.TestCode == realTestInfo.TestCode).ToList();
                if (workStations.Count <= 0)
                {
                    return;
                }
                List<WorkStation> compWorkStations = workStations.OrderBy(a => a.WorkStationId).ToList();
                int deleteWorkStationId = int.Parse(dgvStation.Rows[e.RowIndex].Cells[0].Value.ToString());
                compWorkStations[deleteWorkStationId - 1].WorkStationId = deleteWorkStationId - 1;
                compWorkStations[deleteWorkStationId - 2].WorkStationId = deleteWorkStationId;

                commonBll.sdEntities.WorkStation.AddOrUpdate(compWorkStations[deleteWorkStationId - 1]);
                commonBll.sdEntities.WorkStation.AddOrUpdate(compWorkStations[deleteWorkStationId - 2]);
                commonBll.sdEntities.SaveChanges();

                DisplayTestWorkStation();
            }
            if (e.ColumnIndex == 5)
            {
                if (e.RowIndex == dgvStation.Rows.Count - 2)
                {
                    return;
                }


                List<WorkStation> workStations = commonBll.sdEntities.WorkStation.Where(a => a.TestCode == realTestInfo.TestCode).ToList();
                if (workStations.Count <= 0)
                {
                    return;
                }
                List<WorkStation> compWorkStations = workStations.OrderBy(a => a.WorkStationId).ToList();
                int deleteWorkStationId = int.Parse(dgvStation.Rows[e.RowIndex].Cells[0].Value.ToString());
                compWorkStations[deleteWorkStationId - 1].WorkStationId = deleteWorkStationId + 1;
                compWorkStations[deleteWorkStationId].WorkStationId = deleteWorkStationId;

                commonBll.sdEntities.WorkStation.AddOrUpdate(compWorkStations[deleteWorkStationId - 1]);
                commonBll.sdEntities.WorkStation.AddOrUpdate(compWorkStations[deleteWorkStationId]);
                commonBll.sdEntities.SaveChanges();

                DisplayTestWorkStation();
            }
            if (e.ColumnIndex == 6)
            {
                int deleteWorkStationId = int.Parse(dgvStation.Rows[e.RowIndex].Cells[0].Value.ToString());
                List<WorkStation> workStations = commonBll.sdEntities.WorkStation.Where(a => a.TestCode == realTestInfo.TestCode && a.WorkStationId == deleteWorkStationId).ToList();
                if (workStations.Count <= 0)
                {
                    return;
                }
                txtTestType.Text = workStations[0].TestType;
                txtSetRunSpeed.Text = workStations[0].SetRunSpeed.ToString();
                //txtHighTemp.Text = workStations[0].HighTemp.ToString();
                //txtLowTemp.Text = workStations[0].LowTemp.ToString();
                txtSetLongTime.Text = workStations[0].SetLongTime.ToString();
                //txtActiveTime.Text = workStations[0].SetActiveTime.ToString();
                midWorkStation = workStations[0];
            }
        }

        private WorkStation midWorkStation = null;
        /// <summary>
        /// 提取试验信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadTestInfo_Click(object sender, EventArgs e)
        {
            if (testIsStart)
            {
                MessageBox.Show("试验正在运行，不能操作试验信息", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ReadTestInfoForm readTestInfoForm = new ReadTestInfoForm();
            readTestInfoForm.testContro = this;
            readTestInfoForm.type = 0;
            readTestInfoForm.ShowDialog();
        }

        /// <summary>
        /// 刷新试验信息
        /// </summary>
        public void ReflashTestInfo()
        {
            DisplayTestInfo();
        }

        /// <summary>
        /// 提取用于试验的试验工况
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvStation_SelectionChanged(object sender, EventArgs e)
        {
            if (!isStartOk)
            {
                if (dgvStation.SelectedRows.Count <= 0)
                {
                    return;
                }
                selectWorkStations.Clear();
                for (int i = 0; i < dgvStation.SelectedRows.Count; i++)
                {
                    int workStationId = int.Parse(dgvStation.SelectedRows[i].Cells[0].Value.ToString());
                    selectWorkStations.Add(displayWorkStations.Find(a => a.WorkStationId == workStationId && a.TestCode == realTestInfo.TestCode));
                }
                selectWorkStations = selectWorkStations.OrderBy(a => a.WorkStationId).ToList();
            }

        }
        private void txtTestType_SelectedIndexChanged(object sender, EventArgs e)
        {


        }


        private void btnReflush_Click(object sender, EventArgs e)
        {
            if (runWorkStation.TestType == "温升试验")
            {
                displayControl1.InitilizeMFCurve(8000, -2000);
            }
            else
            {
                displayControl1.InitilizeWSCurve(8000, -2000);
            }
        }
        #endregion

        #region 运行试验
        /// <summary>
        /// 通信读取数据线程
        /// </summary>
        private Thread readThread;
        /// <summary>
        /// 通信读取数据时钟
        /// </summary>
        private int readTimeLen = 1000;
        /// <summary>
        /// 存储数据线程
        /// </summary>
        private Thread saveThread;
        /// <summary>
        /// 显示及存储线程时钟
        /// </summary>
        private int saveTimeLen = 1000;
        /// <summary>
        /// 数据显示线程
        /// </summary>
        private Thread displayThread;
        /// <summary>
        /// 换算数据线程时间间隔
        /// </summary>
        private int displayTimeLen = 100;
        /// <summary>
        /// 数据换算线程
        /// </summary>
        private Thread workOutThread;
        /// <summary>
        /// 换算数据线程时间间隔
        /// </summary>
        private int workOutTimeLen = 1000;
        /// <summary>
        /// 实验顺序控制线程
        /// </summary>
        private Thread controlThread;
        /// <summary>
        /// 实验顺序控制线程时间间隔
        /// </summary>
        private int controlTimeLen = 1000;
        bool isStartOk = false;
        /// <summary>
        /// 数据模型
        /// </summary>
        private WorkOutData displayData = new WorkOutData();
        /// <summary>
        /// 系统故障报警
        /// </summary>
        private bool SystemIsFault = false;
        /// <summary>
        /// 正在进行的实验序号
        /// </summary>
        private int runWorkStationId = -1;
        /// <summary>
        /// 正在进行的实验工况
        /// </summary>
        private WorkStation runWorkStation = new WorkStation();
        /// <summary>
        /// 实验持续时间
        /// </summary>
        private int testKeepTime = 0;
        /// <summary>
        /// 实验有效时间（针对饱和试验类型）
        /// </summary>
        private int testActiveTime = 0;
        /// <summary>
        /// 自定义通道集合
        /// </summary>
        List<DefineChannal> realDefineChannels = new List<DefineChannal>();

        #region 200PLC
        /// <summary>
        /// PLC200IP地址
        /// </summary>
        private string ip200 = "192.168.2.1";
        /// <summary>
        /// 定义200PLC的通信对象
        /// </summary>
        private SiemensS7Net siemens200TcpNet = new SiemensS7Net(SiemensPLCS.S200Smart);

        // Siemens S7 类提供了一系列方法和功能，用于与 Siemens S7 PLC 进行通讯。

        /// <summary>
        /// 定义200PLC的读数据线程
        /// </summary>
        private Thread read200Thread = null;
        /// <summary>
        /// 定义200PLC读取数据数组（整型）
        /// </summary>
        private OperateResult<short[]> read200Arry = new OperateResult<short[]>();
        /// <summary>
        /// 定义数组长度
        /// </summary>
        private ushort dataLen = 33;
        /// <summary>
        /// 定义转换数组
        /// </summary>
        private short[] read200Data;
        /// <summary>
        /// 定义200PLC通信状态
        /// </summary>
        private OperateResult connect200State = new OperateResult();
        /// <summary>
        /// 通信连接200PLC
        /// </summary>
        /// <returns></returns>
        private bool connect200()
        {
            read200Data = new short[dataLen];
            siemens200TcpNet.IpAddress = ip200;
            try
            {
                connect200State = siemens200TcpNet.ConnectServer();
                if (connect200State.IsSuccess)
                {
                    ShowState("200PLC连接成功！");
                    return true;
                }
                else
                {
                    ShowState("200PLC连接失败！");
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 读取200PLC数据
        /// </summary>
        private void read200()
        {
            if (connect200State.IsSuccess)
            {
                read200Arry = siemens200TcpNet.ReadInt16("V0", dataLen);
                if (read200Arry.Content != null)
                {
                    for (int i = 0; i < dataLen; i++)
                    {
                        read200Data[i] = read200Arry.Content[i];
                    }
                }
            }
            else
            {

                connect200();
            }
        }
        /// <summary>
        /// 加热器风机控制
        /// </summary>
        /// <param name="type"></param>
        private void controlHeartMotor(bool type)
        {
            if (type)
            {
                if (connect200State == null || !connect200State.IsSuccess)
                {
                    return;
                }
                else
                {
                    siemens200TcpNet.Write("V4.2", true);
                }
            }
            else
            {
                if (connect200State == null || !connect200State.IsSuccess)
                {
                    return;
                }
                else
                {
                    siemens200TcpNet.Write("V4.2", false);
                }
            }
        }
        /// <summary>
        /// 加热器控制
        /// </summary>
        /// <param name="type"></param>
        private void controlHearter(bool type)
        {
            if (type)
            {
                if (connect200State == null || !connect200State.IsSuccess)
                {
                    return;
                }
                else
                {
                    siemens200TcpNet.Write("V4.1", true);
                }
            }
            else
            {
                if (connect200State == null || !connect200State.IsSuccess)
                {
                    return;
                }
                else
                {
                    siemens200TcpNet.Write("V4.1", false);
                }
            }
        }
        /// <summary>
        /// 冷却风机控制
        /// </summary>
        /// <param name="type"></param>
        private void controlCoolMotor(bool type)
        {
            if (type)
            {
                if (connect200State == null || !connect200State.IsSuccess)
                {
                    return;
                }
                else
                {
                    siemens200TcpNet.Write("V6.3", true);
                }
            }
            else
            {
                if (connect200State == null || !connect200State.IsSuccess)
                {
                    return;
                }
                else
                {
                    siemens200TcpNet.Write("V6.3", false);
                }
            }
        }
        /// <summary>
        /// 气幕开关控制
        /// </summary>
        /// <param name="type"></param>
        private void controlQiMu(bool type)
        {
            if (type)
            {
                if (connect200State == null || !connect200State.IsSuccess)
                {
                    return;
                }
                else
                {
                    siemens200TcpNet.Write("V5.5", true);
                }
            }
            else
            {
                if (connect200State == null || !connect200State.IsSuccess)
                {
                    return;
                }
                else
                {
                    siemens200TcpNet.Write("V5.5", false);
                }
            }
        }
        /// <summary>
        /// 阀门控制
        /// </summary>
        /// <param name="num">阀门编号</param>
        /// <param name="type">开或者关</param>
        private void controlFaMen(int num, bool type)
        {
            switch (num)
            {
                case 1:
                    if (type)
                    {
                        if (connect200State == null || !connect200State.IsSuccess)
                        {
                            return;
                        }
                        else
                        {
                            siemens200TcpNet.Write("V4.3", true);
                        }
                    }
                    else
                    {
                        if (connect200State == null || !connect200State.IsSuccess)
                        {
                            return;
                        }
                        else
                        {
                            siemens200TcpNet.Write("V4.4", true);
                        }
                    }
                    break;
                case 2:
                    if (type)
                    {
                        if (connect200State == null || !connect200State.IsSuccess)
                        {
                            return;
                        }
                        else
                        {
                            siemens200TcpNet.Write("V4.5", true);
                        }
                    }
                    else
                    {
                        if (connect200State == null || !connect200State.IsSuccess)
                        {
                            return;
                        }
                        else
                        {
                            siemens200TcpNet.Write("V4.6", true);
                        }
                    }
                    break;
                case 3:
                    if (type)
                    {
                        if (connect200State == null || !connect200State.IsSuccess)
                        {
                            return;
                        }
                        else
                        {
                            siemens200TcpNet.Write("V4.7", true);
                        }
                    }
                    else
                    {
                        if (connect200State == null || !connect200State.IsSuccess)
                        {
                            return;
                        }
                        else
                        {
                            siemens200TcpNet.Write("V5.0", true);
                        }
                    }
                    break;
                case 4:
                    if (type)
                    {
                        if (connect200State == null || !connect200State.IsSuccess)
                        {
                            return;
                        }
                        else
                        {
                            siemens200TcpNet.Write("V5.1", true);
                        }
                    }
                    else
                    {
                        if (connect200State == null || !connect200State.IsSuccess)
                        {
                            return;
                        }
                        else
                        {
                            siemens200TcpNet.Write("V5.2", true);
                        }
                    }
                    break;
                case 5:
                    if (type)
                    {
                        if (connect200State == null || !connect200State.IsSuccess)
                        {
                            return;
                        }
                        else
                        {
                            siemens200TcpNet.Write("V5.3", true);
                        }
                    }
                    else
                    {
                        if (connect200State == null || !connect200State.IsSuccess)
                        {
                            return;
                        }
                        else
                        {
                            siemens200TcpNet.Write("V5.4", true);
                        }
                    }
                    break;
            }

        }
        /// <summary>
        /// 启动加热
        /// </summary>
        private void startUpTemp()
        {
            stopDownTemp();

            if (displayData.HeatAlarmTemp > 280)
            {
                controlHeartMotor(true);
            }
            else
            {
                controlHeartMotor(true);
                controlHearter(true);
            }

        }
        /// <summary>
        /// 停止加热
        /// </summary>
        private void stopUpTemp()
        {
            controlHeartMotor(false);
            controlHearter(false);
        }
        /// <summary>
        /// 启动降温
        /// </summary>
        private void startDownTemp()
        {
            stopUpTemp();
            controlCoolMotor(true);

        }
        /// <summary>
        /// 停止降温
        /// </summary>
        private void stopDownTemp()
        {
            controlCoolMotor(false);

        }
        #endregion

        #region 1200PLC
        /// <summary>
        /// 1200PLC通信类
        /// </summary>
        private SiemensS7Net siemens1200TcpNet = new SiemensS7Net(SiemensPLCS.S1200);
        /// <summary>
        /// 读1200PLC线程
        /// </summary>
        private Thread read1200Thread = null;
        /// <summary>
        /// 1200PLC读取数据集
        /// </summary>
        private OperateResult<float[]> read1200Arry = new OperateResult<float[]>();
        /// <summary>
        /// 1200PLC转换数据集合
        /// </summary>
        private float[] read1200Data = new float[12];
        /// <summary>
        /// 1200PLC通信状态
        /// </summary>
        private OperateResult connect1200State = new OperateResult();
        /// <summary>
        /// 连接1200PLC通信
        /// </summary>
        /// <returns></returns>
        private bool connect1200()
        {
            siemens1200TcpNet.IpAddress = "192.168.2.30";
            try
            {
                connect1200State = siemens1200TcpNet.ConnectServer();
                if (connect1200State.IsSuccess)
                {
                    ShowState("1200PLC连接成功！");
                    return true;
                }
                else
                {
                    ShowState("1200PLC连接失败！");
                    return false;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// 读取1200PLC线程
        /// </summary>
        private void read1200()
        {

            if (connect1200State.IsSuccess)
            {
                read1200Arry = siemens1200TcpNet.ReadFloat("M800", 12);
                if (read1200Arry.Content != null)
                {
                    for (int i = 0; i < 12; i++)
                    {
                        read1200Data[i] = read1200Arry.Content[i];
                    }
                }
            }
            else
            {
                connect1200();
            }

        }
        /// <summary>
        /// 写入运行速度
        /// </summary>
        /// <param name="SetRunSpeed"></param>
        private void setRunSpeed(int SetRunSpeed)
        {
            if (connect1200State == null || !connect1200State.IsSuccess)
            {
                MessageBox.Show("通信未连接", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                siemens1200TcpNet.Write("M812", float.Parse(SetRunSpeed.ToString()));
            }


        }
        /// <summary>
        /// 写入运行加速度
        /// </summary>
        /// <param name="SetRunStepSpeed"></param>
        private void setRunStepSpeed(int SetRunStepSpeed)
        {
            if (connect1200State == null || !connect1200State.IsSuccess)
            {

                return;
            }
            else
            {
                siemens1200TcpNet.Write("M816", float.Parse(SetRunStepSpeed.ToString()));
            }

        }
        /// <summary>
        /// 变频器使能
        /// </summary>
        private void btnMotorEnble()
        {
            if (connect1200State == null || !connect1200State.IsSuccess)
            {

                return;
            }
            else
            {


                siemens1200TcpNet.Write("M1000.0", true);

            }
        }
        /// <summary>
        /// 变频器取消使能
        /// </summary>
        private void btnMotorDisEnble()
        {
            if (connect1200State == null || !connect1200State.IsSuccess)
            {

                return;
            }
            else
            {


                siemens1200TcpNet.Write("M1000.0", false);

            }
        }
        /// <summary>
        /// 启动电机运行
        /// </summary>
        private void btnMotorStart()
        {
            if (connect1200State == null || !connect1200State.IsSuccess)
            {

                return;
            }
            else
            {
                siemens1200TcpNet.Write("M1000.1", true);

                siemens1200TcpNet.Write("M1000.1", false);


            }
        }
        /// <summary>
        /// 停止电机运行
        /// </summary>
        private void btnMotorStop()
        {
            if (connect1200State == null || !connect1200State.IsSuccess)
            {
                return;
            }
            else
            {
                siemens1200TcpNet.Write("M1000.2", true);
                siemens1200TcpNet.Write("M1000.2", false);



            }
        }
        #endregion

        #region ART

        //Asynchronous Response Technology(ART)：异步响应技术是一种通信模式，其中通信的一方在接收到请求后可以不立即做出响应，
        //而是在稍后的时间内发送响应。这种技术常见于网络通信和分布式系统中，用于提高系统的吞吐量和响应速度。

        /// <summary>
        /// ARTIP地址
        /// </summary>
        private string ipART = "192.168.2.6";
        /// <summary>
        /// ART端口号
        /// </summary>
        private int portART = 502;
        /// <summary>
        /// 读取ART数据长度
        /// </summary>
        private static int readLen = 37;

        /// <summary>
        /// 缓存空间
        /// </summary>
        private int bufferLen = 1024;
        /// <summary>
        /// ART读数据指令
        /// </summary>
        private string ARTCMD = "01 04 00 00 00 10 F1 C6";

        ///16进制
        ///01:站地址/设备编号                      (1 byte)
        ///04:功能区，04表示读取输入寄存器         (1 byte)
        ///00 00 00 10:数据区,在这是用了4byte      (N byte)
        ///00 00:表示起始寄存器,从第一位开始读取,对应地址40001
        ///00 10:表示寄存器长度，一共读取10位,   对应地址40010
        ///F1 C6:CRC校验码                         (2 byte)
        ///校验码会根据前面的数据变化而变化，需要手动计算

        /// <summary>
        /// ART通信类
        /// </summary>
        private SocketCom artCom;
        /// <summary>
        /// ART通信数据
        /// </summary>
        private byte[] artBytes = new byte[readLen];


        /// <summary>
        /// ART通信连接
        /// </summary>
        /// <returns></returns>
        private bool connetArt()
        {

            try
            {
                artCom = new SocketCom(ipART, portART, readLen, bufferLen);
                artCom.Start();
                if (artCom.comConnected)
                {
                    this.Invoke((EventHandler)(delegate
                    {
                        ShowState("自定义模块连接成功！");
                    }));

                    return true;
                }
                else
                {
                    this.Invoke((EventHandler)(delegate
                    {
                        ShowState("自定义模块连接失败！");
                    }));

                    return false;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }
        /// <summary>
        /// 读取ART数据
        /// </summary>
        private void readArt()
        {
            if (artCom == null || !artCom.comConnected)
            {
                artCom = new SocketCom(ipART, portART, readLen, bufferLen);
                artCom.Start();
            }
            if (artCom.comConnected)
            {

                artCom.Send(commonBll.hexStrToByte(ARTCMD));
                if (artCom.readBytes != null && artCom.readBytes.Length == readLen)
                {
                    artBytes = artCom.readBytes;
                }
            }

        }
        #endregion

        private void btnStartTest_Click(object sender, EventArgs e)
        {

            #region 载入试验

            if (isStartOk)
            {
                MessageBox.Show("试验正在进行，不能重复进入，需要先停止试验", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (selectWorkStations.Count <= 0)
            {
                MessageBox.Show("请先选择试验以及试验工况", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            wtTemp = 0;
            runWorkStationId = 0;
            runWorkStation = selectWorkStations[0];
            if (runWorkStation.TestType == "温升试验")
            {
                displayControl1.InitilizeMFCurve(8000, -2000);
                //用于升温实验的显示
            }
            else
            {
                displayControl1.InitilizeWSCurve(8000, -2000);
                //用于饱和实验的显示
            }
            txtLoopLenShow.Text = "0";
            txtLoopLenSet.Text = "0";
            #endregion

            #region 建立通信

            //200PLC通信连接
            if (connect200())
            {
                isStartOk = true;
            }
            else
            {
                isStartOk = false;
                return;
            }
            //1200PLC通信连接
            if (connect1200())
            {
                isStartOk = true;
            }
            else
            {
                isStartOk = false;
                return;
            }
            //ART通信连接
            connetArt();

            #endregion


            #region 启动线程
            //启动线程
            if (isStartOk)
            {
                if (readThread == null)
                {
                    readThread = new Thread(read);
                    readThread.IsBackground = true;
                    readThread.Start();
                }
                if (workOutThread == null)
                {
                    workOutThread = new Thread(workOutData);
                    workOutThread.IsBackground = true;
                    workOutThread.Start();
                }
                if (saveThread == null)
                {
                    saveThread = new Thread(saveData);
                    saveThread.IsBackground = true;
                    saveThread.Start();
                }
                if (displayThread == null)
                {
                    displayThread = new Thread(display);
                    displayThread.IsBackground = true;
                    displayThread.Start();
                }
                if (controlThread == null)
                {
                    controlThread = new Thread(controlTest);
                    controlThread.IsBackground = true;
                    controlThread.Start();
                }
                mainUserControl.testIsStart = isStartOk;
                ShowState("系统启动");
            }
            #endregion
        }
        /// <summary>
        /// 读取PLC数据
        /// </summary>
        private void read()
        {
            while (true)
            {
                read200();
                read1200();
                readArt();
                Thread.Sleep(readTimeLen);

            }

        }

        /// <summary>
        /// 换算数据
        /// </summary>
        private void workOutData()
        {
            while (true)
            {
                #region 状态数据解析

                if (connect1200State.IsSuccess && connect200State.IsSuccess)
                {
                    displayData.ComState = StateStr.是;
                }
                else
                {
                    displayData.ComState = StateStr.否;
                }
                if (isStartOk)
                {
                    displayData.StartState = StateStr.是;
                }
                else
                {
                    displayData.StartState = StateStr.否;
                }
                string bstr1 = Convert.ToString(read200Data[0], 2);
                bstr1 = commonBll.AppendFrontStr(bstr1, "0", 16);
                bstr1 = commonBll.Reverse1(bstr1);
                displayData.EstopState = bstr1.Substring(8, 1) == "0" ? StateStr.是 : StateStr.否;

                if (SystemIsFault)
                {
                    displayData.AlarmState = StateStr.是;
                }
                else
                {
                    displayData.AlarmState = StateStr.否;
                }
                #endregion

                #region 采集数据解析
                displayData.MotorSpeed = Math.Round(read1200Data[0], 0);
                displayData.MotorTemp = Math.Round(read1200Data[2], 0);
                displayData.LubeTemp = Math.Round((double)read200Data[7] / 10, 1);
                displayData.MainBearTemp = Math.Round((double)read200Data[8] / 10, 1);
                displayData.BearTemp = Math.Round((double)read200Data[9] / 10, 1);
                displayData.HeatTemp = Math.Round((double)read200Data[5] / 10, 1);
                displayData.HeatAlarmTemp = Math.Round((double)read200Data[6] / 10, 1);
                displayData.RoomTemp = Math.Round((double)read200Data[10] / 10, 1);
                for (int i = 0; i < 16; i++)
                {
                    displayData.ARTReadData[i] = Math.Round(Convert.ToDouble(commonBll.byteToIntHigh(artBytes, i * 2 + 3, 2)
                     * realDefineChannels[i].Ratio + realDefineChannels[i].Offset), 2).ToString() + realDefineChannels[i].Uint;
                }
                #endregion

                Thread.Sleep(workOutTimeLen);
            }

        }

        /// <summary>
        /// 显示和存储数据
        /// </summary>
        private void saveData()
        {
            while (true)
            {
                string dataStr = "";
                for (int i = 0; i < read200Data.Length; i++)
                {
                    if (i == 0)
                    {
                        dataStr = read200Data[i].ToString();
                    }
                    else
                    {
                        dataStr = dataStr + "/" + read200Data[i].ToString();
                    }

                }
                for (int i = 0; i < read1200Data.Length; i++)
                {

                    dataStr = dataStr + "/" + read1200Data[i].ToString();

                }
                for (int i = 0; i < displayData.ARTReadData.Length; i++)
                {
                    dataStr = dataStr + "/" + displayData.ARTReadData[i].ToString();
                }
                dataStr = dataStr + "/" + displayData.WTTemp;
                TestData testData = new TestData();
                testData.TestData1 = dataStr;
                testData.TestCode = runWorkStation.TestCode;
                testData.WorkStationId = runWorkStation.WorkStationId.Value;
                testData.Time = commonBll.GetNowTimeStrsSmall();
                commonBll.sdEntities.TestData.Add(testData);
                commonBll.sdEntities.SaveChanges();
                Thread.Sleep(saveTimeLen);
            }

        }

        /// <summary>
        /// 实时显示数据线程
        /// </summary>
        public void display()
        {
            while (true)
            {
                this.Invoke((EventHandler)(delegate
                {
                    displayControl1.ReflashDisplay(displayData);

                    txtShowKeepTime.Text = testKeepTime.ToString();
                    //SystemAlarm();
                }));
                Thread.Sleep(displayTimeLen);
            }

        }

        /// <summary>
        /// 运行温升试验类型
        /// </summary>
        private void testMF()
        {
            if (int.Parse(txtLoopLenShow.Text) == 0 && int.Parse(txtLoopLenSet.Text) > 0)
            {
                this.Invoke((EventHandler)(delegate
                {
                    txtLoopLenShow.Text = "1";
                }));

            }
            if (runWorkStation.SetLongTime * 60 > testKeepTime)   //
            {
                if (displayData.MotorSetSpeed != runWorkStation.SetRunSpeed || displayData.MotorSetStepSpeed != runWorkStation.AccrossSpeed)
                {
                    for (int i = 0; i < dgvStation.RowCount; i++)
                    {
                        dgvStation.Rows[i].Selected = false;
                    }
                    dgvStation.Rows[(int)runWorkStation.WorkStationId - 1].Selected = true;

                    setRunSpeed(runWorkStation.SetRunSpeed.Value);
                    setRunStepSpeed(runWorkStation.AccrossSpeed.Value);
                    btnMotorEnble();
                    btnMotorStart();
                }
                if (displayData.MotorSpeed <= runWorkStation.SetRunSpeed + 3 && displayData.MotorSpeed >= runWorkStation.SetRunSpeed - 3)
                {
                    if (displayData.LubeTemp < runWorkStation.HighTemp - 0.5)
                    {
                        startUpTemp();
                    }
                    else
                    {
                        stopUpTemp();
                    }
                    if (displayData.LubeTemp > runWorkStation.HighTemp + 0.5)
                    {
                        startDownTemp();
                    }
                    else
                    {
                        stopDownTemp();
                    }
                    if (!startCount && displayData.LubeTemp > runWorkStation.HighTemp - 1 && displayData.LubeTemp < runWorkStation.HighTemp + 1)
                    {
                        startCount = true;
                    }
                    if (displayData.LubeTemp > runWorkStation.HighTemp - runWorkStation.LowTemp && displayData.LubeTemp < runWorkStation.HighTemp + runWorkStation.LowTemp && startCount)
                    {
                        testKeepTime++;
                    }
                }
            }
            else
            {
                if (runWorkStation.WorkStationId >= selectWorkStations[selectWorkStations.Count - 1].WorkStationId)
                {

                    if (int.Parse(txtLoopLenShow.Text) < int.Parse(txtLoopLenSet.Text))
                    {
                        startCount = false;
                        testKeepTime = 0;
                        runWorkStationId = 0;
                        runWorkStation = selectWorkStations[runWorkStationId];
                        this.Invoke((EventHandler)(delegate
                        {
                            ShowState("切换到工况" + runWorkStation.WorkStationId);
                        }));
                        this.Invoke((EventHandler)(delegate
                        {
                            txtLoopLenShow.Text = (int.Parse(txtLoopLenShow.Text) + 1).ToString();
                        }));

                    }
                    else
                    {
                        StopRun();
                    }

                }
                else
                {
                    startCount = false;
                    testKeepTime = 0;
                    runWorkStationId++;
                    runWorkStation = selectWorkStations[runWorkStationId];
                    this.Invoke((EventHandler)(delegate
                    {
                        ShowState("切换到工况" + runWorkStation.WorkStationId);
                    }));
                }
            }
        }
        /// <summary>
        /// 开始计算时间标识
        /// </summary>
        private bool startCount = false;
        /// <summary>
        /// 温升试验的稳态温度
        /// </summary>
        private double wtTemp = 0.0;
        /// <summary>
        /// 运行饱和试验类型
        /// </summary>
        private void testWS()
        {
            if (runWorkStation.SetActiveTime * 60 <= testActiveTime || wtTemp > runWorkStation.HighTemp)//超出有效时间范围及视为不合格，并停止试验
            {
                displayData.WTTemp = "稳态温度：尚未找到";
                StopRun();
                return;
            }
            if (int.Parse(txtLoopLenShow.Text) == 0 && int.Parse(txtLoopLenSet.Text) > 0)
            {
                this.Invoke((EventHandler)(delegate
                {
                    txtLoopLenShow.Text = "1";
                }));
            }
            if (runWorkStation.SetLongTime * 60 > testKeepTime)
            {
                if (displayData.MotorSetSpeed != runWorkStation.SetRunSpeed || displayData.MotorSetStepSpeed != runWorkStation.AccrossSpeed)
                {
                    for (int i = 0; i < dgvStation.RowCount; i++)
                    {
                        dgvStation.Rows[i].Selected = false;
                    }
                    dgvStation.Rows[(int)runWorkStation.WorkStationId - 1].Selected = true;
                    this.Invoke((EventHandler)(delegate
                    {
                        ShowState("切换到工况" + runWorkStation.WorkStationId);
                    }));

                    setRunSpeed(runWorkStation.SetRunSpeed.Value);
                    setRunStepSpeed(runWorkStation.AccrossSpeed.Value);
                    btnMotorEnble();
                    btnMotorStart();
                }
                if (displayData.MotorSpeed <= runWorkStation.SetRunSpeed + 3 && displayData.MotorSpeed >= runWorkStation.SetRunSpeed - 3)
                {
                    testActiveTime++;
                    if (wtTemp > displayData.LubeTemp + runWorkStation.LowTemp || //跳出温度范围及视为不合格
                        wtTemp < displayData.LubeTemp - runWorkStation.LowTemp)
                    {
                        testKeepTime = 0;
                        wtTemp = displayData.LubeTemp;
                    }

                    if (wtTemp <= displayData.LubeTemp + runWorkStation.LowTemp ||
                       wtTemp >= displayData.LubeTemp - runWorkStation.LowTemp)
                    {
                        testKeepTime++;
                    }

                }
                displayData.WTTemp = "稳态温度：尚未找到";
            }
            else
            {
                if (runWorkStation.WorkStationId >= selectWorkStations[selectWorkStations.Count - 1].WorkStationId)
                {
                    if (int.Parse(txtLoopLenShow.Text) < int.Parse(txtLoopLenSet.Text))
                    {
                        testActiveTime = 0;
                        testKeepTime = 0;
                        runWorkStationId = 0;
                        runWorkStation = selectWorkStations[runWorkStationId];
                        this.Invoke((EventHandler)(delegate
                        {
                            ShowState("切换到工况" + runWorkStation.WorkStationId);
                        }));
                        this.Invoke((EventHandler)(delegate
                        {
                            txtLoopLenShow.Text = (int.Parse(txtLoopLenShow.Text) + 1).ToString();
                        }));
                    }
                    else
                    {
                        displayData.WTTemp = "稳态温度：" + wtTemp.ToString() + "℃";
                        StopRun();
                    }

                }
                else
                {
                    testKeepTime = 0;
                    runWorkStationId++;
                    runWorkStation = selectWorkStations[runWorkStationId];
                    this.Invoke((EventHandler)(delegate
                    {
                        ShowState("切换到工况" + runWorkStation.WorkStationId);
                    }));
                }
            }
        }

        /// <summary>
        /// 试验控制
        /// </summary>
        private void controlTest()
        {
            while (true && isStartOk)
            {
                if (runWorkStation.TestType == "密封试验")
                {
                    testMF();
                }
                else
                {
                    testWS();
                }

                Thread.Sleep(controlTimeLen);
            }

        }

        private void btnStop_Click(object sender, EventArgs e)
        {

            StopRun();
        }

        //提取自定义数据采集通道信息
        private void InitializeDefineChannel()
        {
            realDefineChannels =
           commonBll.sdEntities.DefineChannal.Where(a => a.Id > 0).ToList();
            if (realDefineChannels == null || realDefineChannels.Count != 16)
            {
                return;
            }
            string[] dataName = new string[16];
            for (int i = 0; i < realDefineChannels.Count; i++)
            {
                dataName[i] = realDefineChannels[i].DataName;
            }
            displayControl1.DisplayARTDataName(dataName);
        }
        #endregion

        /// <summary>
        /// 停止运行
        /// </summary>
        private void StopRun()
        {
            this.Invoke((EventHandler)(delegate
            {
                isStartOk = false;
                mainUserControl.testIsStart = isStartOk;
                stopDownTemp();
                stopUpTemp();
                btnMotorStop();
                btnMotorDisEnble();
                ThreadClose();
                controlQiMu(true);
                testKeepTime = 0;
                testActiveTime = 0;
                startCount = false;
                ShowState("运行停止");
            }));

        }

        /// <summary>
        /// 停止关闭线程
        /// </summary>
        private void ThreadClose()
        {
            if (workOutThread != null)
            {
                workOutThread.Abort();
                workOutThread = null;
            }
            if (saveThread != null)
            {
                saveThread.Abort();
                saveThread = null;
            }
            if (displayThread != null)
            {
                displayThread.Abort();
                displayThread = null;
            }
            if (controlThread != null)
            {
                controlThread.Abort();
                controlThread = null;
            }

        }
        /// <summary>
        /// 状态显示
        /// </summary>
        /// <param name="stateStr"></param>
        private void ShowState(string stateStr)
        {
            testState.Items.Insert(0, commonBll.GetNowTimeStrsSmall() + ":" + stateStr);
        }
        #endregion

        /// <summary>
        /// 报警数据结构体
        /// </summary>
        public struct AlarmData
        {
            public int AlarmNum;
            public bool AlarmIsOn;
            public string AlarmContent;
        }
        /// <summary>
        /// 显示数据的结构体
        /// </summary>
        public struct WorkOutData
        {
            /// <summary>
            /// 系统通信状态
            /// </summary>
            public StateStr ComState;
            /// <summary>
            /// 系统启动状态
            /// </summary>
            public StateStr StartState;
            /// <summary>
            /// 系统急停状态
            /// </summary>
            public StateStr EstopState;
            /// <summary>
            /// 系统报警状态
            /// </summary>
            public StateStr AlarmState;
            /// <summary>
            /// 电机速度设定
            /// </summary>
            public double MotorSetSpeed;
            /// <summary>
            /// 电机加速度设定
            /// </summary>
            public double MotorSetStepSpeed;
            /// <summary>
            /// 电机速度
            /// </summary>
            public double MotorSpeed;
            /// <summary>
            /// 电机温度
            /// </summary>
            public double MotorTemp;
            /// <summary>
            /// 润滑油温度
            /// </summary>
            public double LubeTemp;
            /// <summary>
            /// 轴承座温度
            /// </summary>
            public double BearTemp;
            /// <summary>
            /// 主轴温度
            /// </summary>
            public double MainBearTemp;
            /// <summary>
            /// 加热器温度
            /// </summary>
            public double HeatTemp;
            /// <summary>
            /// 加热器报警温度
            /// </summary>
            public double HeatAlarmTemp;
            /// <summary>
            /// 环境仓温度
            /// </summary>
            public double RoomTemp;
            /// <summary>
            /// ART读取数据定义名称
            /// </summary>
            public string[] ARTReadName;
            /// <summary>
            /// ART读取数据
            /// </summary>
            public string[] ARTReadData;
            /// <summary>
            /// 温升试验的稳态温度
            /// </summary>
            public string WTTemp;

        }
        /// <summary>
        /// 弹出窗体的类型，询问，确认，错误
        /// </summary>
        public enum StateStr
        {
            是,
            否
        }

        private bool heartIsOpen = false;
        private bool heartMotorIsOpen = false;

    }
}


