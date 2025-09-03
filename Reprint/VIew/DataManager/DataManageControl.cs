using Reprint.Module;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reprint
{
    public partial class DataManageControl : UserControl
    {

        #region Property

        private CommonBLL commonBLL = new CommonBLL();

        /// <summary>
        /// 按试验工况提取的数据
        /// </summary>
        /// 
        private List<TestData> selectAllTestDatas = new List<TestData>();

        /// <summary>
        /// 按时间范围提取的数据
        /// </summary>
        /// 
        private List<TestData> selectTestDatas = new List<TestData>();
        private List<TestData> dgvShowDatas = new List<TestData>();
        private List<TestDefineVarible> testDefineVaribles = new List<TestDefineVarible>();
        private DataGridView dgvData = new DataGridView();
        private Thread showThread;
        private int showIndex = 0;   //
        private TestInfo nowTestInfo = new TestInfo();
        private List<WorkStation> nowWorkStations = new List<WorkStation>();

        /// <summary>
        /// 当前使用的实验数据集
        /// </summary>
        /// 
        List<TestData> realTestDatas = new List<TestData>();

        /// <summary>
        /// 当前实际操作的实验对象
        /// </summary>
        /// 
        public TestInfo realTestInfo = null;
        private List<WorkStation> realWorkStations = new List<WorkStation>();

        public List<List<double>> readDataList = new List<List<double>>();

        /// <summary>
        /// 当前选择的尚未进入试验流程的试验工况
        /// </summary>
        /// 
        private List<WorkStation> selectWorkStations = new List<WorkStation>();

        /// <summary>
        /// 数据模型
        /// </summary>
        /// 
        private TestControl.WorkOutData displayData = new TestControl.WorkOutData();

        List<int> workStationIds = new List<int>();

        #endregion


        #region Method

        public DataManageControl()
        {
            InitializeComponent();
        }

        private void btnSelectData_Click(object sender, EventArgs e)
        {
            if (dgvStation.SelectedRows.Count <= 0)
            {
                MessageBox.Show("请先选择试验以及试验工况", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            workStationIds.Clear();
            for (int i = 0; i < dgvStation.SelectedRows.Count; i++)
            {
                workStationIds.Add(int.Parse(dgvStation.SelectedRows[i].Cells[0].Value.ToString()));
            }
            if (workStationIds.Count <= 0)
            {
                return;
            }
            selectAllTestDatas.Clear();
            for (int i = 0; i < workStationIds.Count; i++)
            {
                int workStationID = workStationIds[i];
                List<TestData> myTestDatas =
                    commonBLL.sdEntities.TestData.Where(a => a.TestCode == realTestInfo.TestCode && a.WorkStationId == workStationID).ToList();

                selectAllTestDatas.AddRange(myTestDatas);
            }

            if (selectAllTestDatas.Count <= 0)
            {
                return;
            }
            selectAllTestDatas = selectAllTestDatas.OrderBy(a => a.Id).ToList();

            for (int i = 0; i < selectAllTestDatas.Count; i++)
            {
                if (Convert.ToDateTime(selectAllTestDatas[i].Time.Substring(0, 19)) <= dtpStartTime.Value)
                {
                    dtpStartTime.Value = Convert.ToDateTime(selectAllTestDatas[i].Time.Substring(0, 19));
                }
                if (Convert.ToDateTime(selectAllTestDatas[i].Time.Substring(0, 19)) >= dtpOverTime.Value)
                {
                    dtpOverTime.Value = Convert.ToDateTime(selectAllTestDatas[i].Time.Substring(0, 19));
                }
            }

            displayData.ComState = TestControl.StateStr.否;
            displayData.StartState = TestControl.StateStr.否;
            displayData.EstopState = TestControl.StateStr.否;
            displayData.AlarmState = TestControl.StateStr.否;

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
        }

        private void DgvShow()
        {
            #region 添加表头

            dgvData.Rows.Clear();
            dgvData.Columns.Clear();
            for (int i = 0; i < 3; i++)
            {
                dgvData.Columns.Add(new DataGridViewTextBoxColumn());
                dgvData.Columns[i].HeaderText = "输入转速";
            }

            dgvData.Columns[0].HeaderText = "转速(rpm)";
            dgvData.Columns[1].HeaderText = "温度(℃)";
            dgvData.Columns[2].HeaderText = "时间";

            #endregion

            #region 添加数据

            foreach (var selectTestData in selectTestDatas)
            {
                string[] strs = selectTestData.TestData1.Split('/');
                string speed = Math.Round(Convert.ToDouble(strs[33]), 0).ToString();
                string temp = Math.Round(Convert.ToDouble(strs[7]), 1).ToString();
                string time = selectTestData.Time;
                string[] newstr = new[] { speed, temp, time };

                dgvData.Rows.Add(newstr);
            }
            #endregion
        }

        private void DataRecordControl_Load(object sender, EventArgs e)
        {
            InitData();
            txtShowSpeed.KeyPress += commonBLL.InputInt_KeyPress;
            showThread = new Thread(Display);
        }


        /// <summary>
        /// 数据模型
        /// </summary>
        /// 
        private TestControl.WorkOutData showData = new TestControl.WorkOutData();

        /// <summary>
        /// 实时显示数据线程
        /// </summary>
        private void Display()
        {
            while (true)
            {
                if (showIndex >= selectTestDatas.Count)
                {
                    showIndex = 0;
                    StopShow();
                    return;
                }

                TestData testData = selectTestDatas[showIndex];
                string[] dataStrs = testData.TestData1.Split('/');

                #region 状态数据解析

                displayData.ComState = TestControl.StateStr.是;

                displayData.StartState = TestControl.StateStr.是;

                string bstr1 = Convert.ToString(int.Parse(dataStrs[0]), 2);
                bstr1 = commonBLL.AppendFrontStr(bstr1, "0", 16);
                bstr1 = commonBLL.Reverse1(bstr1);
                displayData.EstopState = bstr1.Substring(8, 1) == "0" ? TestControl.StateStr.是 : TestControl.StateStr.否;

                displayData.AlarmState = TestControl.StateStr.否;
                #endregion

                #region 采集数据解析
                displayData.MotorSpeed = Math.Round(Convert.ToDouble(dataStrs[33]), 0);
                displayData.MotorTemp = Math.Round(Convert.ToDouble(dataStrs[35]), 1);
                displayData.LubeTemp = Math.Round(Convert.ToDouble(dataStrs[7]) / 10, 1);
                displayData.MainBearTemp = Math.Round(Convert.ToDouble(dataStrs[8]) / 10, 1);
                displayData.BearTemp = Math.Round(Convert.ToDouble(dataStrs[9]) / 10, 1);
                displayData.HeatTemp = Math.Round(Convert.ToDouble(dataStrs[5]) / 10, 1);
                displayData.HeatAlarmTemp = Math.Round(Convert.ToDouble(dataStrs[6]) / 10, 1);
                displayData.RoomTemp = Math.Round(Convert.ToDouble(dataStrs[10]) / 10, 1);
                for (int i = 0; i < 16; i++)
                {
                    displayData.ARTReadData[i] = dataStrs[dataStrs.Length - 16 + i];
                }
                if (dataStrs[dataStrs.Length - 1] != null)
                {
                    displayData.WTTemp = dataStrs[dataStrs.Length - 1];
                }

                #endregion

                this.Invoke((EventHandler)(delegate
                {
                    if (showIndex == 0)
                    {
                        if (dgvStation.SelectedRows[showIndex].Cells[1].Value.ToString() == "温升试验")
                        {
                            displayControl1.InitilizeWSCurve(8000, -2000);

                        }
                        else
                        {
                            displayControl1.InitilizeMFCurve(8000, -2000);
                        }
                    }
                    displayControl1.ReflashDisplay(displayData);
                }));
                Thread.Sleep(int.Parse(txtShowSpeed.Text));
                showIndex++;
            }
        }

        private void StopShow()
        {
            this.Invoke((EventHandler)(delegate
            {
                btnReadData.Enabled = true;
                btnStartShow.Enabled = true;
                btnImportData.Enabled = true;
                btnSelectData.Enabled = true;
                btnImportDgv.Enabled = true;
            }));

            if (showThread != null)
            {
                showThread.Abort();
            }
        }


        /// <summary>
        /// 初始化读取数据
        /// </summary>
        private void InitData()
        {
            selectTestDatas = new List<TestData>();
            dgvShowDatas = new List<TestData>();
            testDefineVaribles = new List<TestDefineVarible>();
            readDataList.Clear();
            List<double> dataList = new List<double>();
            for (int i = 0; i < 6; i++)
            {
                dataList.Add(0);
            }
            readDataList.Add(dataList);

            dataList = new List<double>();
            for (int j = 0; j < 6; j++)
            {
                dataList.Add(0);
            }
            readDataList.Add(dataList);

            dataList = new List<double>();
            for (int j = 0; j < 14; j++)
            {
                dataList.Add(0);
            }
            readDataList.Add(dataList);

            dataList = new List<double>();
            for (int j = 0; j < 8; j++)
            {
                dataList.Add(0);
            }
            readDataList.Add(dataList);

        }

        private void txtShowSpeed_TextChanged(object sender, EventArgs e)
        {
            if (int.Parse(txtShowSpeed.Text) < 10)
            {
                MessageBox.Show("最快速度不能小于10ms", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtShowSpeed.Text = "10";
            }
        }

        private void btnStartShow_Click(object sender, EventArgs e)
        {
            if (selectTestDatas == null || selectTestDatas.Count <= 0)
            {
                MessageBox.Show("请先查询和提取试验数据", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            showThread = new Thread(Display);
            showThread.Start();
            btnStartShow.Enabled = false;
            btnReadData.Enabled = false;
            btnImportData.Enabled = false;
            btnSelectData.Enabled = false;
            btnImportDgv.Enabled = false;
        }

        private void btnStopShow_Click(object sender, EventArgs e)
        {
            StopShow();
        }

        private void ShowState(string stateStr)
        {
            this.Invoke((EventHandler)(delegate
            {
                txtState.Items.Insert(0, commonBLL.GetNowTimeStrsSmall() + ":" + stateStr);
            }));
        }

        private void btnImportData_Click(object sender, EventArgs e)
        {
            Bitmap bt = displayControl1.zghShow.GraphPane.GetImage();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "图片文件(*.png)|*.png";
            saveFileDialog.ShowDialog();
            bt.Save(saveFileDialog.FileName);
        }

        private void btnImportDgv_Click(object sender, EventArgs e)
        {
            if (selectTestDatas == null || selectTestDatas.Count <= 0)
            {
                MessageBox.Show("请先查询和提取试验数据", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            commonBLL.DatagridviewToexcel(dgvData);
        }


        #endregion

        private void btnReadTestInfo_Click(object sender, EventArgs e)
        {
            ReadTestInfoForm readTestInfoForm = new ReadTestInfoForm();
            readTestInfoForm.dataManageControl = this;
            readTestInfoForm.type = 1;
            readTestInfoForm.ShowDialog();
        }

        public void ReflashTestInfo()
        {
            if (realTestInfo != null)
            {
                txtTestName.Text = realTestInfo.TestName;
                txtTestCode.Text = realTestInfo.TestCode;
                txtTime.Text = realTestInfo.Time;
                dgvStation.Rows.Clear();
                DisplayTestWorkStation();
            }
        }

        private void DisplayTestWorkStation()
        {
            if (realTestInfo == null)
            {
                return;
            }
            nowWorkStations = commonBLL.sdEntities.WorkStation.Where(a => a.TestCode == realTestInfo.TestCode).ToList();
            dgvStation.Rows.Clear();
            if (nowWorkStations.Count > 0)
            {
                List<WorkStation> compWorkStations = nowWorkStations.OrderBy(a => a.WorkStationId).ToList();
                for (int i = 0; i < compWorkStations.Count; i++)
                {
                    dgvStation.Rows.Add(new[]
                    {
                       compWorkStations[i].WorkStationId.ToString(),compWorkStations[i].TestType,   compWorkStations[i].SetRunSpeed.ToString(),
                          compWorkStations[i].HighTemp.ToString(), compWorkStations[i].LowTemp.ToString(),
                           compWorkStations[i].SetLongTime.ToString(), compWorkStations[i].SetActiveTime.ToString()
                    });
                }
            }
        }

        private void btnReadData_Click(object sender, EventArgs e)
        {
            if (selectAllTestDatas == null || selectAllTestDatas.Count <= 0)
            {
                MessageBox.Show("请先查询试验数据", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            selectTestDatas.Clear();
            for (int i = 0; i < selectAllTestDatas.Count; i++)
            {
                if (Convert.ToDateTime(selectAllTestDatas[i].Time.Substring(0, 19)) <= dtpOverTime.Value
                    && Convert.ToDateTime(selectAllTestDatas[i].Time.Substring(0, 19)) >= dtpStartTime.Value)
                {
                    selectTestDatas.Add(selectAllTestDatas[i]);
                }

            }
            if (selectTestDatas.Count > 0)
            {
                DgvShow();
                ShowState("数据查询完成");
            }
        }
    }
}
