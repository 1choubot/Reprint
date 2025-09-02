using Reprint;
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
using WindowsSoftwear.Module;
using ZedGraph;

namespace Reprint
{
    public partial class DisplayControl : UserControl
    {
        /// <summary>
        /// 读取数据集合
        /// </summary>
        private List<List<double>> readDataList = new List<List<double>>();

        private List<double> readMotorSpeedShow = new List<double>();
        private List<double> readLubeTempShow = new List<double>();
        private List<string> smallTimeList = new List<string>();
        private List<string> smallTimeListShow = new List<string>();
        public List<DefineChannal> realDefineChannels = new List<DefineChannal>();
        private int curveShowLength = 1000;
        private double lubeTempShowK = 0.0;
        private double lubeTempShowB = 0.0;
        private double motorSpeedShowK = 0.0;
        private double motorSpeedShowB = 0.0;
        private Control[] channelNameControls = new Control[16];
        private Control[] channeDataControls = new Control[16];
        private Control[] channelUnitControls = new Control[16];

        private bool IsInitilizeChannel = false;


        private List<double> motorSpeedData = new List<double>();
        private List<double> lubeTempData = new List<double>();

        public DisplayControl()
        {
            InitializeComponent();
            for (int i = 0; i < curveShowLength; i++)
            {
                readMotorSpeedShow.Add(0.0);
                readLubeTempShow.Add(0.0);

                smallTimeListShow.Add("");
            }

            //InitilizeMFCurve(8000, 0);
            InitializeZedGraphControl();
            GenerateSampleData();
            InitializeMFCurve(1200, 800);
            DrawDemoCurves();

        }

        private void InitializeZedGraphControl()
        {
            // 设置ZedGraph基本属性
            zghShow.GraphPane.Title.Text = "设备运行状态监控";
            zghShow.GraphPane.Title.FontSpec.Size = 16;
            zghShow.GraphPane.Title.FontSpec.IsBold = true;
            zghShow.GraphPane.Chart.Fill = new Fill(Color.WhiteSmoke);
            zghShow.GraphPane.Fill = new Fill(Color.FromArgb(240, 240, 245));
        }

        private void GenerateSampleData()
        {
            // 生成电机转速模拟数据（800-1200 RPM）
            for (int i = 0; i < curveShowLength; i++)
            {
                double baseSpeed = 1000;
                double variation = 200 * Math.Sin(i * 0.03);
                double noise = new Random().NextDouble() * 20 - 10;
                motorSpeedData.Add(baseSpeed + variation + noise);
            }

            // 生成油温模拟数据（30-90℃）
            for (int i = 0; i < curveShowLength; i++)
            {
                double baseTemp = 60;
                double variation = 30 * Math.Sin(i * 0.02 + 2);
                double noise = new Random().NextDouble() * 3 - 1.5;
                lubeTempData.Add(baseTemp + variation + noise);
            }
        }

        public void InitializeMFCurve(int maxSpeed, int minSpeed)
        {
            GraphPane pane = zghShow.GraphPane;

            // 清除现有曲线和图形元素
            pane.CurveList.Clear();
            pane.GraphObjList.Clear();

            // 配置X轴
            pane.XAxis.Title.Text = "时间 (数据点索引)";
            pane.XAxis.Title.FontSpec.Size = 12;
            pane.XAxis.Scale.FontSpec.Size = 10;
            pane.XAxis.Scale.Max = curveShowLength;
            pane.XAxis.Scale.Min = 0;
            pane.XAxis.Scale.MajorStep = 100;
            pane.XAxis.Scale.MinorStep = 10;
            pane.XAxis.MajorGrid.IsVisible = true;
            pane.XAxis.MajorGrid.Color = Color.LightGray;
            pane.XAxis.MinorGrid.IsVisible = true;
            pane.XAxis.MinorGrid.Color = Color.FromArgb(240, 240, 240);

            // 配置主Y轴（隐藏）
            pane.YAxis.IsVisible = false;

            // 清除现有Y轴列表
            pane.YAxisList.Clear();

            // 添加油温Y轴（左侧）
            YAxis yAxisLubeTemp = new YAxis("角度/°");
            yAxisLubeTemp.Title.FontSpec.Size = 12;
            yAxisLubeTemp.Title.FontSpec.FontColor = Color.OrangeRed;
            yAxisLubeTemp.Scale.FontSpec.FontColor = Color.OrangeRed;
            yAxisLubeTemp.Scale.FontSpec.Size = 10;
            yAxisLubeTemp.Scale.Max = 100;
            yAxisLubeTemp.Scale.Min = 30;
            yAxisLubeTemp.Scale.MajorStep = 10;
            yAxisLubeTemp.Scale.MinorStep = 2;
            yAxisLubeTemp.MajorGrid.IsVisible = true;
            yAxisLubeTemp.MajorGrid.Color = Color.FromArgb(255, 200, 200);
            yAxisLubeTemp.MinorGrid.IsVisible = true;
            yAxisLubeTemp.MinorGrid.Color = Color.FromArgb(255, 230, 230);
            pane.YAxisList.Add(yAxisLubeTemp);

            // 添加电机转速Y轴（右侧）
            YAxis yAxisMotorSpeed = new YAxis("电机转速/rpm");
            yAxisMotorSpeed.Title.FontSpec.Size = 12;
            yAxisMotorSpeed.Title.FontSpec.FontColor = Color.Blue;
            yAxisMotorSpeed.Scale.FontSpec.FontColor = Color.Blue;
            yAxisMotorSpeed.Scale.FontSpec.Size = 10;
            yAxisMotorSpeed.Scale.Max = maxSpeed;
            yAxisMotorSpeed.Scale.Min = minSpeed;
            yAxisMotorSpeed.Scale.MajorStep = 100;
            yAxisMotorSpeed.Scale.MinorStep = 20;
            yAxisMotorSpeed.MajorGrid.IsVisible = true;
            yAxisMotorSpeed.MajorGrid.Color = Color.FromArgb(200, 200, 255);
            yAxisMotorSpeed.MinorGrid.IsVisible = true;
            yAxisMotorSpeed.MinorGrid.Color = Color.FromArgb(230, 230, 255);
            yAxisMotorSpeed.IsVisible = true;
            pane.YAxisList.Add(yAxisMotorSpeed);

            // 添加图例
            pane.Legend.IsVisible = true;
            pane.Legend.Position = LegendPos.TopCenter;
            pane.Legend.FontSpec.Size = 10;
        }

        private void DrawDemoCurves()
        {
            GraphPane pane = zghShow.GraphPane;

            // 创建油温曲线
            LineItem curveLubeTemp = pane.AddCurve("角度", null, Color.OrangeRed, SymbolType.None);
            curveLubeTemp.YAxisIndex = 0; // 绑定到第一个Y轴（油温轴）
            curveLubeTemp.Line.Width = 2f;
            curveLubeTemp.Line.Style = System.Drawing.Drawing2D.DashStyle.Solid;

            // 创建转速曲线
            LineItem curveMotorSpeed = pane.AddCurve("转速", null, Color.Blue, SymbolType.None);
            curveMotorSpeed.YAxisIndex = 1; // 绑定到第二个Y轴（转速轴）
            curveMotorSpeed.Line.Width = 2f;
            curveMotorSpeed.Line.Style = System.Drawing.Drawing2D.DashStyle.Dash;

            // 填充曲线数据
            PointPairList lubePoints = new PointPairList();
            PointPairList speedPoints = new PointPairList();

            for (int i = 0; i < curveShowLength; i++)
            {
                lubePoints.Add(i, lubeTempData[i]);
                speedPoints.Add(i, motorSpeedData[i]);
            }

            curveLubeTemp.Points = lubePoints;
            curveMotorSpeed.Points = speedPoints;

            // 添加图表说明
            TextObj titleNote = new TextObj("设备运行数据", 0.5, 0.95)
            {
                Location = { CoordinateFrame = CoordType.ChartFraction },
                FontSpec = new FontSpec("Arial", 12, Color.DarkBlue, false, false, false)
            };
            pane.GraphObjList.Add(titleNote);

            // 添加数据来源说明
            TextObj dataSource = new TextObj("数据来源: 实时生成", 0.02, 0.02)
            {
                Location = { CoordinateFrame = CoordType.ChartFraction },
                FontSpec = new FontSpec("Arial", 9, Color.Gray, false, false, false)
            };
            pane.GraphObjList.Add(dataSource);

            // 添加坐标轴说明
            TextObj axisNote = new TextObj("左侧: 角度(°)  右侧: 转速(RPM)", 0.98, 0.95)
            {
                Location = {
                    CoordinateFrame = CoordType.ChartFraction,
                    AlignH = AlignH.Right,
                    AlignV = AlignV.Top
                },
                FontSpec = new FontSpec("Arial", 10, Color.DarkGreen, false, false, false)
            };
            pane.GraphObjList.Add(axisNote);

            // 应用所有更改并刷新
            zghShow.AxisChange();
            zghShow.Invalidate();
        }


        public void Display()
        {

        }

        /// <summary>
        /// 实时显示数据线程
        /// </summary>
        public void ReflashDisplay(TestControl.WorkOutData displayData)
        {
            if (!IsInitilizeChannel)
            {
                InitilizeChannel();
                IsInitilizeChannel = true;
            }
            //DisplayState(displayData);
            //DisplayPLCData(displayData);
            //DisplayARTData(displayData);
            DisplayCurve(displayData);
        }

        /// <summary>
        /// 显示状态信息
        /// </summary>
        private void DisplayState(TestControl.WorkOutData displayData)
        {
            txtComState.Text = displayData.ComState.ToString();
            txtStartState.Text = displayData.StartState.ToString();
            txtAlarmState.Text = displayData.AlarmState.ToString();
            txtEstopState.Text = displayData.EstopState.ToString();

        }

        /// <summary>
        /// 显示PLC实时采集数据
        /// </summary>
        private void DisplayPLCData(TestControl.WorkOutData displayData)
        {
            txtMotorRunSpeed.Text = Math.Round(displayData.MotorSpeed, 0).ToString();
            txtMotorTemp.Text = Math.Round(displayData.MotorTemp, 1).ToString();
            txtPLCLubeTemp.Text = Math.Round(displayData.LubeTemp, 1).ToString();
            txtPLCBearTemp.Text = Math.Round(displayData.BearTemp, 1).ToString();
            txtPLCHeatTemp.Text = Math.Round(displayData.HeatTemp, 1).ToString();
            txtPLCHeatAlarmTemp.Text = Math.Round(displayData.HeatAlarmTemp, 1).ToString();
            txtMianBearTemp.Text = Math.Round(displayData.MainBearTemp, 1).ToString();
            txtPLCRoomTemp.Text = Math.Round(displayData.RoomTemp, 1).ToString();
        }

        /// <summary>
        /// 显示ART实时采集数据
        /// </summary>
        private void DisplayARTData(TestControl.WorkOutData displayData)
        {
            for (int i = 0; i < displayData.ARTReadData.Length; i++)
            {
                channeDataControls[i].Text = displayData.ARTReadData[i];
            }
        }

        /// <summary>
        /// 显示ART实时采集数据
        /// </summary>
        public void DisplayARTDataName(string[] dataName)
        {
            if (dataName != null && dataName.Length == 16)
            {
                for (int i = 0; i < dataName.Length; i++)
                {
                    channelNameControls[i].Text = dataName[i];
                }
            }

        }

        public void clearCurve()
        {
            zghShow.GraphPane.CurveList.Clear();
            zghShow.AxisChange();
            zghShow.Refresh();
        }

        /// <summary>
        /// 显示曲线图
        /// </summary>
        private void DisplayCurve(TestControl.WorkOutData displayData)
        {
            readMotorSpeedShow.Remove(readMotorSpeedShow.Count - 1);
            readMotorSpeedShow.Insert(0, Math.Round(displayData.MotorSpeed * motorSpeedShowK + motorSpeedShowB, 1));
            readLubeTempShow.Remove(readLubeTempShow.Count - 1);
            readLubeTempShow.Insert(0, Math.Round(displayData.LubeTemp * lubeTempShowK + lubeTempShowB, 1));
            zghShow.GraphPane.CurveList.Clear();
            zghShow.GraphPane.AddCurve("", null, readMotorSpeedShow.ToArray(), Color.Blue, SymbolType.None);
            zghShow.GraphPane.AddCurve("", null, readLubeTempShow.ToArray(), Color.OrangeRed, SymbolType.None);
            if (zghShow.GraphPane.XAxis.Title.IsVisible == true)
            {
                zghShow.GraphPane.XAxis.Title.Text = displayData.WTTemp;
            }
            zghShow.GraphPane.XAxis.Scale.TextLabels = smallTimeListShow.ToArray();
            zghShow.AxisChange();
            zghShow.Refresh();

        }
        public void InitilizeWSCurve(int maxSpeed, int minSpeed)    //饱和试验
        {

            //GraphPane.AddCurve: 用于添加折线图。
            //GraphPane.AddBar: 用于添加柱状图。
            //GraphPane.AddPie: 用于添加饼图。
            //GraphPane.AddScatter: 用于添加散点图。
            //GraphPane.SetCurveOptions: 用于设置曲线的选项，包括线型、颜色、标记等。
            //GraphPane.SetBarOptions: 用于设置柱状图的选项，包括颜色、填充等。
            //GraphPane.SetPieOptions: 用于设置饼图的选项，包括颜色、标签等。
            //GraphPane.SetScatterOptions: 用于设置散点图的选项，包括标记、颜色等。
            //GraphPane.Title: 用于设置图表的标题。
            //GraphPane.XAxis: 用于设置X轴的属性，包括标签、刻度等。
            //GraphPane.YAxis: 用于设置Y轴的属性，包括标签、刻度等。
            //GraphPane.Legend: 用于设置图例的属性，如位置、大小等。


            zghShow.GraphPane.Title.IsVisible = false;
            zghShow.GraphPane.XAxis.Title.IsVisible = true;
            zghShow.GraphPane.XAxis.Title.Text = "稳定温度：";
            zghShow.GraphPane.XAxis.Scale.FontSpec.Size = 14;
            zghShow.GraphPane.YAxis.Scale.IsVisible = false;
            zghShow.GraphPane.YAxis.Title.IsVisible = false;
            zghShow.GraphPane.XAxis.Scale.Max = curveShowLength;
            zghShow.GraphPane.XAxis.Scale.Min = 0;
            zghShow.GraphPane.XAxis.Scale.MajorStep = 100;
            zghShow.GraphPane.XAxis.Scale.MinorStep = 10;
            zghShow.GraphPane.YAxis.Scale.Max = 10;
            zghShow.GraphPane.YAxis.Scale.Min = 0;
            zghShow.GraphPane.YAxis.Scale.MajorStep = 2;
            zghShow.GraphPane.YAxis.Scale.MinorStep = 1;
            zghShow.GraphPane.YAxis.MajorGrid.IsVisible = true;

            zghShow.GraphPane.YAxis.MinorGrid.IsVisible = true;
            zghShow.GraphPane.YAxisList.Clear();

            YAxis yAxisTorque = new YAxis();
            yAxisTorque.Title.Text = "测试箱油温/℃";
            yAxisTorque.Title.FontSpec.Size = 14;
            yAxisTorque.Title.FontSpec.FontColor = Color.OrangeRed;
            yAxisTorque.Scale.FontSpec.FontColor = Color.OrangeRed;
            yAxisTorque.Scale.FontSpec.Size = 14;
            yAxisTorque.Scale.Max = 200;
            yAxisTorque.Scale.Min = 0;
            yAxisTorque.Scale.MajorStep = yAxisTorque.Scale.Max / 5;
            yAxisTorque.Scale.MinorStep = yAxisTorque.Scale.Max / 5;

            zghShow.GraphPane.YAxisList.Add(yAxisTorque);
            lubeTempShowK = (zghShow.GraphPane.YAxis.Scale.Max - zghShow.GraphPane.YAxis.Scale.Min) /
                            (yAxisTorque.Scale.Max - yAxisTorque.Scale.Min);
            lubeTempShowB = -yAxisTorque.Scale.Min;

            //×100
            YAxis yAxisSpeed = new YAxis();
            yAxisSpeed.Title.Text = "电机转速/rpm";
            yAxisSpeed.Title.FontSpec.Size = 14;
            yAxisSpeed.Title.FontSpec.FontColor = Color.Blue;
            yAxisSpeed.Scale.FontSpec.FontColor = Color.Blue;
            yAxisSpeed.Scale.FontSpec.Size = 14;
            yAxisSpeed.Scale.Max = maxSpeed;
            yAxisSpeed.Scale.Min = minSpeed;
            yAxisSpeed.Scale.MajorStep = (maxSpeed - minSpeed) / 5;
            yAxisSpeed.Scale.MinorStep = (maxSpeed - minSpeed) / 5;

            zghShow.GraphPane.YAxisList.Add(yAxisSpeed);
            motorSpeedShowK = (zghShow.GraphPane.YAxis.Scale.Max - zghShow.GraphPane.YAxis.Scale.Min) /
                              (yAxisSpeed.Scale.Max - yAxisSpeed.Scale.Min);
            motorSpeedShowB = -yAxisSpeed.Scale.Min * motorSpeedShowK;
            zghShow.AxisChange();
            zghShow.Refresh();
        }




        public void InitilizeMFCurve(int maxSpeed, int minSpeed)    //温升实验
        {

            zghShow.GraphPane.Title.IsVisible = false;
            zghShow.GraphPane.XAxis.Title.IsVisible = false;
            zghShow.GraphPane.XAxis.Scale.FontSpec.Size = 14;
            zghShow.GraphPane.YAxis.Scale.IsVisible = false;
            zghShow.GraphPane.YAxis.Title.IsVisible = false;
            zghShow.GraphPane.XAxis.Scale.Max = curveShowLength;
            zghShow.GraphPane.XAxis.Scale.Min = 0;
            zghShow.GraphPane.XAxis.Scale.MajorStep = 100;
            zghShow.GraphPane.XAxis.Scale.MinorStep = 10;
            zghShow.GraphPane.YAxis.Scale.Max = 10;
            zghShow.GraphPane.YAxis.Scale.Min = 0;
            zghShow.GraphPane.YAxis.Scale.MajorStep = 2;
            zghShow.GraphPane.YAxis.Scale.MinorStep = 1;
            zghShow.GraphPane.YAxis.MajorGrid.IsVisible = true;

            zghShow.GraphPane.YAxis.MinorGrid.IsVisible = true;
            zghShow.GraphPane.YAxisList.Clear();

            YAxis yAxisTorque = new YAxis();
            yAxisTorque.Title.Text = "测试箱油温/℃";
            yAxisTorque.Title.FontSpec.Size = 14;
            yAxisTorque.Title.FontSpec.FontColor = Color.OrangeRed;
            yAxisTorque.Scale.FontSpec.FontColor = Color.OrangeRed;
            yAxisTorque.Scale.FontSpec.Size = 14;
            yAxisTorque.Scale.Max = 200;
            yAxisTorque.Scale.Min = 0;
            yAxisTorque.Scale.MajorStep = yAxisTorque.Scale.Max / 5;
            yAxisTorque.Scale.MinorStep = yAxisTorque.Scale.Max / 5;

            zghShow.GraphPane.YAxisList.Add(yAxisTorque);
            lubeTempShowK = (zghShow.GraphPane.YAxis.Scale.Max - zghShow.GraphPane.YAxis.Scale.Min) /
                            (yAxisTorque.Scale.Max - yAxisTorque.Scale.Min);
            lubeTempShowB = -yAxisTorque.Scale.Min;

            //×100
            YAxis yAxisSpeed = new YAxis();
            yAxisSpeed.Title.Text = "电机转速/rpm";
            yAxisSpeed.Title.FontSpec.Size = 14;
            yAxisSpeed.Title.FontSpec.FontColor = Color.Blue;
            yAxisSpeed.Scale.FontSpec.FontColor = Color.Blue;
            yAxisSpeed.Scale.FontSpec.Size = 14;
            yAxisSpeed.Scale.Max = maxSpeed;
            yAxisSpeed.Scale.Min = minSpeed;
            yAxisSpeed.Scale.MajorStep = (maxSpeed - minSpeed) / 5;
            yAxisSpeed.Scale.MinorStep = (maxSpeed - minSpeed) / 5;

            zghShow.GraphPane.YAxisList.Add(yAxisSpeed);
            motorSpeedShowK = (zghShow.GraphPane.YAxis.Scale.Max - zghShow.GraphPane.YAxis.Scale.Min) /
                              (yAxisSpeed.Scale.Max - yAxisSpeed.Scale.Min);
            motorSpeedShowB = -yAxisSpeed.Scale.Min * motorSpeedShowK;
            zghShow.AxisChange();
            zghShow.Refresh();
        }

        /// <summary>
        /// 公共操作类
        /// </summary>
        private CommonBLL commonBll = new CommonBLL();

        private void InitilizeChannel()
        {
            for (int i = 0; i < realDefineChannels.Count; i++)
            {
                channelNameControls[i].Text = realDefineChannels[i].DataName;
                channelUnitControls[i].Text = realDefineChannels[i].Uint;
            }
        }

        private void zghShow_ContextMenuBuilder(ZedGraphControl sender, ContextMenuStrip menuStrip, Point mousePt,
            ZedGraphControl.ContextMenuObjectState objState)
        {
            if (menuStrip.Items.Count <= 0)
            {
                return;

            }
            for (int i = 0; i < menuStrip.Items.Count; i++)
            {
                menuStrip.Items.Remove(menuStrip.Items[i]); //移除菜单项

                menuStrip.Items[i].Visible = false; //不显示
            }

        }
    }

}
