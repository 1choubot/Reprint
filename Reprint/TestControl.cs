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
    public partial class TestControl : UserControl
    {
        public TestControl()
        {
            InitializeComponent();
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
    }
}
