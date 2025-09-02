using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextBox = System.Windows.Forms.TextBox;

namespace Reprint.Module
{
    public class CommonBLL
    {

        /// <summary>
        /// 数据库实体
        /// </summary>
        public ReprintEntities sdEntities = new ReprintEntities();
        /// <summary>
        /// 字符串倒转
        /// </summary>
        /// <param name="original"></param>
        /// <returns></returns>
        public string Reverse1(string original)
        {
            char[] arr = original.ToCharArray();
            Array.Reverse(arr);//Reverse()反转序列中元素的顺序。
            return new string(arr);
        }
        /// <summary>
        /// 允许输入非负浮点数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void InputFloat_KeyPress(object sender, KeyPressEventArgs e)
        {
            string str = "";
            if (sender.GetType() == typeof(TextBox))
            {
                TextBox txt = (TextBox)sender;
                str = txt.Text;
            }
            if (e.KeyChar == 46 && str.Contains('.'))
            {
                e.Handled = true;
            }
            if (str.Length <= 1 && (e.KeyChar == '\b'))
            {
                e.Handled = true;
            }
            if (((e.KeyChar < '0') || (e.KeyChar > '9')) && (e.KeyChar != 46) && (e.KeyChar != '\b'))
            //这是允许输入0-9数字   && (e.KeyChar != 46) && (e.KeyChar != '\b')
            {

                e.Handled = true;
            }

        }

        /// <summary>
        /// 允许输入整数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void InputInt_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            string str = "";
            if (sender.GetType() == typeof(TextBox))
            {
                TextBox txt = (TextBox)sender;
                str = txt.Text;
            }
            if (e.KeyChar == 46 && str.Contains('.'))
            {
                e.Handled = true;
            }
            if (str.Length <= 1 && (e.KeyChar == '\b'))
            {
                e.Handled = true;
            }
            if (((e.KeyChar < '0') || (e.KeyChar > '9')) && (e.KeyChar != '\b'))
            //这是允许输入0-9数字   && (e.KeyChar != 46) && (e.KeyChar != '\b')
            {

                e.Handled = true;
            }

        }


        /// <summary>
        /// 按照格式yyyy/MM/dd hh:mm:ss返回当前系统时间
        /// </summary>
        /// <returns></returns>
        public string CreatTimeStr()
        {
            return DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
        }

        /// <summary>
        ///获取当时系统时间，格式2016-10-16 23:23:23:23
        /// </summary>
        /// <returns></returns>
        public string GetNowTimeStrsSmall()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff");
        }

        /// <summary>
        /// 用指定的字符填充字符串，满足字符串长度
        /// </summary>
        /// <param name="oldStr">原有字符串</param>
        /// <param name="appendStr">添加延长字符</param>
        /// <param name="Strlen">目标字符串长度</param>
        /// <returns></returns>
        public string AppendFrontStr(string oldStr, string appendStr, int Strlen)
        {
            while (oldStr.Length < Strlen)
            {
                oldStr = appendStr + oldStr;
            }
            return oldStr;
        }
        /// <summary>
        /// 低字节在前
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="startIndex"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public int byteToIntLow(byte[] bytes, int startIndex, int length)
        {
            int returnInt = 0;
            List<byte> dataList = new List<byte>();

            if (length > 1)
            {

                for (int i = 0; i < length; i++)
                {
                    dataList.Add(bytes[i + startIndex]);
                }
            }
            else
            {
                dataList.Add(bytes[startIndex]);
            }
            while (dataList.Count < 4)
            {
                dataList.Add(0x0);
            }

            returnInt = BitConverter.ToInt32(dataList.ToArray(), 0);


            return returnInt;
        }
        /// <summary>
        /// 高字节在前
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="startIndex"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public int byteToIntHigh(byte[] bytes, int startIndex, int length)
        {
            int returnInt = 0;
            List<byte> dataList = new List<byte>();

            if (length > 1)
            {

                for (int i = length - 1; i >= 0; i--)
                {
                    dataList.Add(bytes[i + startIndex]);
                }
            }
            else
            {
                dataList.Add(bytes[startIndex]);
            }
            while (dataList.Count < 4)
            {
                dataList.Add(0x0);
            }

            returnInt = BitConverter.ToInt32(dataList.ToArray(), 0);


            return returnInt;
        }
        /// <summary>
        /// 字节数组转16进制字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public string byteToHexStr(byte[] bytes)
        {
            string returnStr = "";
            if (bytes != null)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    returnStr += bytes[i].ToString("X2");
                }
            }
            return returnStr;
        }
        /// <summary>
        /// 只能输入数字（正数，负数，小数） 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void InputFloatOrNeg_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            //允许输入数字、小数点、删除键和负号  
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != (char)('\b') && e.KeyChar != (char)('.') &&
                e.KeyChar != (char)('-'))
            {
                e.Handled = true;
            }
            /*输入负号的时候必须是空*/
            if (e.KeyChar == (char)('-'))
            {
                if (txt.Text != "")
                {
                    e.Handled = true;
                }
            }
            /*小数点只能输入一次*/
            if (e.KeyChar == (char)('.') && ((TextBox)sender).Text.IndexOf('.') != -1)
            {
                e.Handled = true;
            }
            /*第一位不能为小数点*/
            if (e.KeyChar == (char)('.') && ((TextBox)sender).Text == "")
            {
                e.Handled = true;
            }
            /*第一位是0，第二位必须为小数点*/
            if (e.KeyChar != (char)('.') && ((TextBox)sender).Text == "0")
            {
                e.Handled = true;
            }
            /*第一位是负号，第二位不能为小数点*/
            if (((TextBox)sender).Text == "-" && e.KeyChar == (char)('.'))
            {
                e.Handled = true;
            }
        }
        /// <summary>
        /// 只能输入数字（正数，负数） 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void InputIntOrNeg_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            //允许输入数字、删除键和负号  
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != (char)('\b') && e.KeyChar != (char)('-'))
            {
                e.Handled = true;
            }
            ///*输入负号的时候必须是空*/
            //if (e.KeyChar == (char)('-'))
            //{
            //    if (txt.Text != "")
            //    {
            //        e.Handled = true;
            //    }
            //}
            /*负号只能输入一次*/
            if (e.KeyChar == (char)('-') && ((TextBox)sender).Text.IndexOf('-') != -1)
            {
                e.Handled = true;
            }

        }

        /// <summary>
        /// 十六进制字符串转换成数组
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        public byte[] hexStrToByte(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
                hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }

        /// <summary>
        ///获取当时系统时间，格式23:23
        /// </summary>
        /// <returns></returns>
        public string GetNowSmallTimeStrs()
        {
            string str = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff");
            return str;
        }
        /// <summary>
        ///获取当时系统时间，格式2020-03-27 11:36:50 925
        /// </summary>
        /// <returns></returns>
        public string GetNowSmallTimeShowStrs()
        {
            string str = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff");
            return str.Substring(14, 5) + ":" + str.Substring(20, 3);
        }

        public void DatagridviewToexcel(DataGridView dgvData)
        {
            string fileName = "";

            string saveFileName = "";

            SaveFileDialog saveDialog = new SaveFileDialog();

            saveDialog.DefaultExt = "xls";

            saveDialog.Filter = "Excel文件|*.xls";

            saveDialog.FileName = fileName;

            saveDialog.ShowDialog();

            saveFileName = saveDialog.FileName;
        }
        /// <summary>
        /// CRC校验
        /// </summary>
        /// <param name="data">校验数据</param>
        /// <returns>高低8位</returns>
        public string CRCCalc(string data)
        {
            string[] datas = data.Split(' ');
            List<byte> bytedata = new List<byte>();

            foreach (string str in datas)
            {
                bytedata.Add(byte.Parse(str, System.Globalization.NumberStyles.AllowHexSpecifier));
            }
            byte[] crcbuf = bytedata.ToArray();
            //计算并填写CRC校验码
            int crc = 0xffff;
            int len = crcbuf.Length;
            for (int n = 0; n < len; n++)
            {
                byte i;
                crc = crc ^ crcbuf[n];
                for (i = 0; i < 8; i++)
                {
                    int TT;
                    TT = crc & 1;
                    crc = crc >> 1;
                    crc = crc & 0x7fff;
                    if (TT == 1)
                    {
                        crc = crc ^ 0xa001;
                    }
                    crc = crc & 0xffff;
                }

            }
            string[] redata = new string[2];
            redata[1] = Convert.ToString((byte)((crc >> 8) & 0xff), 16);
            redata[1] = new CommonBLL().AppendFrontStr(redata[1], "0", 2);
            redata[0] = Convert.ToString((byte)((crc & 0xff)), 16);
            redata[0] = new CommonBLL().AppendFrontStr(redata[0], "0", 2);
            return redata[0] + " " + redata[1];
        }
    }
}





