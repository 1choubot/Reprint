using System;
using System.Net.NetworkInformation;
using System.Threading;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reprint.VIew;
using HslCommunication.ModBus;
using Reprint.Module;
namespace WindowsSoftwear.Module
{
    public class PLCCom
    {
        #region Property
        /// <summary>
        /// 公共操作类
        /// </summary>
        private CommonBLL commonBll = new CommonBLL();
        /// <summary>
        /// 错误状态
        /// </summary>
        public bool erroState = true;
        /// <summary>
        /// TCP通信实例对象
        /// </summary>
        private ModbusTcpNet busTcpClient = null; // 站号1
        /// <summary>
        /// 通信IP地址
        /// </summary>
        public string ipAddress = "192.168.3.35";
        /// <summary>
        /// 通信端口号
        /// </summary>
        public int port = 502;
        private HslCommunication.OperateResult<byte[]> mainRead;
        /// <summary>
        /// 通信线程
        /// </summary>
        private static Thread ModbusThread;
        /// <summary>
        /// 读取数据浮点数组  长度14
        /// </summary>
        public List<double> readDataList = new List<double>();
        /// <summary>
        /// 读取整数数组 长度38
        /// </summary>
        public List<double> readDataIntList = new List<double>(38);
        /// <summary>
        /// 写入整数数组 长度17
        /// </summary>
        public List<double> writeDataIntList = new List<double>(17);
        /// <summary>
        /// 检测通信是否正常
        /// </summary>
        private Thread checkConThread;
        /// <summary>
        /// 通信状态
        /// </summary>
        public bool comConnected = false;
        /// <summary>
        /// 通信启动标识
        /// </summary>
        public bool conStart = false;
        public delegate void DataReflashHandler();
        public event DataReflashHandler DataReflash;
        #endregion

        #region Method
        /// <summary>
        /// 初始化读取写入数据
        /// </summary>
        private void InitilizeReadWriteData()
        {
            for (int i = 0; i < 38; i++)
            {
                readDataIntList.Add(0);
            }
            for (int i = 0; i < writeDataIntList.Count; i++)
            {
                readDataIntList.Add(0);
            }
        }
        /// <summary>
        /// ping ip,测试能否ping通
        /// </summary>
        /// <param name="strIP">IP地址</param>
        /// <returns></returns>
        private bool PingIp(string strIP, int portNum)
        {
            bool bRet = false;
            try
            {
                Ping pingSend = new Ping();
                PingReply reply = pingSend.Send(strIP, portNum);
                if (reply.Status == IPStatus.Success)
                    bRet = true;
            }
            catch (Exception)
            {
                bRet = false;
            }
            return bRet;
        }
        public PLCCom()
        {
            InitilizeReadWriteData();
            checkConThread = new Thread(StartCon);
            checkConThread.Start();
        }
        /// <summary>
        /// 断开重连
        /// </summary>
        private void StartCon()
        {
            while (true)
            {
                if (!comConnected && conStart)
                {
                    Stop();
                    Start();
                }

                Thread.Sleep(500);
            }
        }
        /// <summary>
        /// 通信启动
        /// </summary>
        /// <returns></returns>
        public void Start()
        {
            conStart = true;
            if (!comConnected)
            {
                try
                {
                    if (PingIp(ipAddress, port))
                    {
                        busTcpClient = new ModbusTcpNet(ipAddress, port, 0x01);
                        if (busTcpClient.ConnectServer().IsSuccess)
                        {
                            comConnected = true;
                            ModbusThread = new Thread(Read);
                            ModbusThread.IsBackground = true;
                            ModbusThread.Start();
                        }
                        else
                        {
                            comConnected = false;
                        }
                    }
                    else
                    {
                        comConnected = false;
                    }

                }
                catch (Exception)
                {
                    comConnected = false;
                }
            }
        }
        /// <summary>
        /// 读取数据过程
        /// </summary>
        private void Read()
        {
            while (true)
            {
                if (comConnected == true)
                {
                    mainRead = busTcpClient.Read("11000", (ushort)readDataIntList.Count);
                    if (!mainRead.IsSuccess)
                    {
                        comConnected = false;
                    }
                    else
                    {
                        for (int i = 0; i < readDataIntList.Count; i++)
                        {
                            readDataIntList[i] = busTcpClient.ByteTransform.TransInt16(mainRead.Content, i * 2);
                        }

                        DataReflash();
                    }
                }
                else
                {
                    try
                    {
                        busTcpClient.ConnectClose();
                        if (busTcpClient.ConnectServer().IsSuccess)
                        {
                            comConnected = true;
                        }
                    }
                    catch
                    {
                        comConnected = false;
                    }
                }
                Thread.Sleep(500);
            }
        }
        /// <summary>
        /// 写数据过程
        /// </summary>
        /// <param name="address">写入数据地址</param>
        /// <param name="value">写入数据内容</param>
        public void Send(int address, double value)
        {
            if (comConnected == true)
            {
                busTcpClient.Write(address.ToString(), Convert.ToInt16(value));
            }
        }
        /// <summary>
        /// 通信停止
        /// </summary>
        public void Stop()
        {
            conStart = false;
            if (busTcpClient != null)
            {
                busTcpClient.ConnectClose();
            }
            if (ModbusThread != null)
            {
                ModbusThread.Abort();
            }
        }

        #endregion
    }
}
