using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Reprint.Module
{
    internal class SocketCom
    {
        #region Property
        ///<summary>
        ///通信IP地址及端口号
        ///</summary>
        public IPEndPoint ipEndPoint;

        ///<summary>
        ///定义Socket通信对象
        ///</summary>
        private Socket socket;

        /// <summary>
        /// 定义Socket的实际读取数据字节数组
        /// </summary>
        public byte[] readBytes;

        /// <summary>
        /// 定义Socket缓存区数据字节数组
        /// </summary>
        private static byte[] reback;

        /// <summary>
        /// Socket通信是否正常
        /// </summary>
        public bool comConnected = false;

        /// <summary>
        /// 检测通信是否正常
        /// </summary>
        private Thread checkConThread;

        /// <summary>
        /// 通信延时标识
        /// </summary>
        private int delayIndex = 0;
        /// <summary>
        /// 通信启动标识
        /// </summary>
        public bool conStart = false;
        public delegate void DataReflashHandler();
        public event DataReflashHandler DataReflash;
        #endregion

        #region Method
        ///<summary>
        ///以太网广播式通信
        ///</summary>
        ///<param name="IP">通信IP地址</param>
        ///<param name="portNum">通信端口号</param>
        ///<param name="readDataLen">读取数据字节长度</param>
        ///<param name="bufferLen">缓冲数据长度</param>
        ///
        public SocketCom(string IP, int portNum, int readDataLen, int bufferLen)
        {
            ipEndPoint = new IPEndPoint(IPAddress.Parse(IP), portNum);
            readBytes = new byte[readDataLen];
            reback = new byte[bufferLen];
        }
        ///<summary>
        ///ping ip,测试能否ping通
        ///使用ICMP协议
        ///应用程序使用 Ping 类来检测远程计算机是否可访问。
        ///</summary>
        ///<param name="strIP">IP地址</param>
        ///<returns></returns>
        ///
        private bool PingIP(string strIP, int portNum)
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

        ///<summary>
        ///TCP通信连接
        ///</summary>
        public void Start()
        {
            if (!comConnected)
            {
                try
                {
                    if (PingIP(ipEndPoint.Address.ToString(), ipEndPoint.Port))
                    {
                        //新建Socket对象
                        socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        //与服务端进行连接
                        socket.Connect(ipEndPoint);
                        socket.BeginReceive(reback, 0, reback.Length, SocketFlags.None, ReceiveCb, null);
                        //开启异步接收模式
                        comConnected = true;
                    }
                }
                catch (Exception)
                {

                    comConnected = false;
                }
            }
        }

        /// <summary>
        /// 关闭通信连接
        /// </summary>
        public void Stop()
        {
            try
            {
                socket.Disconnect(true);
                socket = null;
                comConnected = false;
            }
            catch (Exception)
            {
                comConnected = false;
            }
        }

        /// <summary>
        /// 异步接收数据
        /// </summary>
        /// <param name="ar"></param>
        private void ReceiveCb(IAsyncResult ar)
        {
            try
            {
                //接收数据的长度
                //count：读取数组的最大长度
                int count = socket.EndReceive(ar);
                if (count > 0)    //当接收数据长度大于0时的处理
                {
                    socket.BeginReceive(reback, 0, reback.Length, SocketFlags.None, ReceiveCb, null);
                    //开启异步接收模式
                    readBytes = new byte[count];
                    Array.Copy(reback, 0, readBytes, 0, count);
                    DataReflash();
                }
                comConnected = true;
            }
            catch (Exception)
            {

                comConnected = false;
            }
        }

        /// <summary>
        /// 异步发送数据
        /// </summary>
        /// <param name="_sendBytes">发送数据字节数组</param>
        public void Send(byte[] _sendBytes)
        {
            try
            {
                if (comConnected)
                {
                    socket.BeginSend(_sendBytes, 0, _sendBytes.Length, 0,
                        new AsyncCallback(Sendcallback), socket);
                }
            }
            catch (Exception)
            {

                comConnected = false;
            }
        }

        /// <summary>
        /// 发送数据反馈
        /// </summary>
        /// <param name="ar"></param>

        private void Sendcallback(IAsyncResult ar)
        {
            try
            {
                Socket handler = (Socket)ar.AsyncState;
                int bytesSent = handler.EndSend(ar);
                comConnected = true;
            }
            catch (Exception)
            {
                comConnected = false;
            }
        }
        #endregion
    }
}
