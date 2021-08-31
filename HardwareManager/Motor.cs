using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace HardwareManager
{
    class Motor : IMotor
    {
        public UcComPort ucComPort;
        /// <summary>
        /// 關鍵區域鎖定物件
        /// </summary>
        private readonly Object _commandLock = new Object();
        public Motor(string portname, int baudrate, int databits, int stopbits, int parity, int handshake)
        {
            ucComPort = new UcComPort(portname, baudrate, databits, stopbits, parity, handshake);
            ucComPort.PortTitle = "置片平台";
        }
        #region 馬達啟動控制
        /// <summary>
        /// 開啟RS232連線
        /// </summary>
        /// <returns></returns>
        public bool OpenComPort()
        {
            try
            {
                return ucComPort.OpenComPort();
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 關閉RS232連線
        /// </summary>
        public void CloseComPort()
        {
            ucComPort.CloseComPort();
        }
        /// <summary>
        /// 判斷RS232是否連線
        /// </summary>
        public bool IsComPortOpen
        {
            get { return ucComPort.IsComPortOpen; }
        }
        /// <summary>
        /// 重新啟動馬達控制
        /// </summary>
        public void Reset()
        {
            if (ucComPort.serialPort.IsOpen)
            {
                // 清空 serial port 的緩存
                ucComPort.serialPort.DiscardInBuffer();
                ucComPort.serialPort.DiscardOutBuffer();

                // 如果有程式在執行，要先關閉程式，RESET才會有作用
                ExecuteCommand("EXIT");
                ExecuteCommand("RESET H");
                // 執行自訂程式
                ExecuteCommand("G");
            }
        }
        public void Reset_nGo()
        {
            if (ucComPort.serialPort.IsOpen)
            {
                // 清空 serial port 的緩存
                ucComPort.serialPort.DiscardInBuffer();
                ucComPort.serialPort.DiscardOutBuffer();

                // 如果有程式在執行，要先關閉程式，RESET才會有作用
                ExecuteCommand("RESET H");
                ExecuteCommand("EXIT");
                // 執行自訂程式
                //ExecuteCommand("G");
            }
        }
        /// <summary>
        /// 開啟馬達控制
        /// </summary>
        public void ServoOn()
        {
            ExecuteCommand("HON");
        }

        /// <summary>
        /// 關閉馬達控制
        /// </summary>
        public void ServoOff()
        {
            ExecuteCommand("EXIT");
            ExecuteCommand("HOFF");
        }

        #endregion

        #region 速度控制

        /// <summary>
        /// 加速度
        /// </summary>
        public double AccelerationSpeed
        {
            get
            {
                double result = 100;
                string ParamValue = GetParameter("VA");
                if (!string.IsNullOrWhiteSpace(ParamValue))
                {
                    double.TryParse(GetParameter("VA"), out result);
                }
                return result;
            }
            set
            {
                SetParameter("VA", value.ToString());
            }
        }

        /// <summary>
        /// 移動速度
        /// </summary>
        public double MoveSpeed
        {
            get
            {
                double result = 100;
                string ParamValue = GetParameter("?VM");
                if (!string.IsNullOrWhiteSpace(ParamValue))
                {
                    double.TryParse(GetParameter("?VM"), out result);
                }
                return result;
            }
            set
            {
                SetParameter("VM", value.ToString());
            }
        }
        /// <summary>
        /// 出原點的速度
        /// </summary>
        public double BeginSpeed
        {
            get
            {
                double result = 10;
                string ParamValue = GetParameter("VB");
                if (!string.IsNullOrWhiteSpace(ParamValue))
                {
                    double.TryParse(GetParameter("VB"), out result);
                }
                return result;
            }
            set
            {
                SetParameter("VB", value.ToString());
            }
        }

        /// <summary>
        /// 回原點的速度
        /// </summary>
        public double BackSpeed
        {
            get
            {
                double result = 10;
                string ParamValue = GetParameter("VH");
                if (!string.IsNullOrWhiteSpace(ParamValue))
                {
                    double.TryParse(GetParameter("VH"), out result);
                }
                return result;
            }
            set
            {
                SetParameter("VH", value.ToString());
            }
        }

        /// <summary>
        /// 連續旋轉速度 (JOG)
        /// </summary>
        public double ContinuousRotationSpeed
        {
            get
            {
                double result = 100;
                string ParamValue = GetParameter("VJ");
                if (!string.IsNullOrWhiteSpace(ParamValue))
                {
                    double.TryParse(GetParameter("VJ"), out result);
                }
                return result;
            }
            set
            {
                SetParameter("VJ", value.ToString());
            }
        }

        /// <summary>
        /// 目前旋轉速度
        /// </summary>
        public double CurrentRotateSpeed
        {
            get
            {
                return double.Parse(GetParameter("RPM"));
            }
        }

        #endregion

        #region 參數控制

        /// <summary>
        /// 讀取參數值
        /// </summary>
        /// <param name="paramName"></param>
        /// <returns></returns>
        public string GetParameter(string paramName)
        {
            if (ucComPort.serialPort.IsOpen)
            {
                ExecuteCommand(string.Format("{0}", paramName));
                string[] MessageArray = ResultMessage.Split('\r', '\n');
                List<string> list = new List<string>();
                for (int i = 0; i < MessageArray.Length; i++)
                {
                    if (string.IsNullOrWhiteSpace(MessageArray[i])) continue;
                    list.Add(MessageArray[i]);
                }
                if (list.Count >= 2)
                {
                    if (paramName == "ST")
                    {
                        for (int i = 0; i <= list.Count - 1; i++)
                        {
                            if (list[i].StartsWith("ST="))
                            {
                                return list[i];
                            }
                        }
                    }
                    return list[1];
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// 設定參數值
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="value"></param>
        public void SetParameter(string paramName, string value)
        {
            ExecuteCommand(string.Format("{0}={1}", paramName, value));
        }

        public void SaveParameter()
        {
            ExecuteCommand("SAVE C");
        }

        #endregion

        #region 指令控制

        /// <summary>
        /// 執行馬達裝置指令
        /// </summary>
        /// <param name="command">馬達裝置指令</param>
        public void ExecuteCommand(string command)
        {
            lock (_commandLock)
            {
                if (ucComPort.serialPort.IsOpen && !string.IsNullOrWhiteSpace(command))
                {
                    // 清除暫存訊息
                    //string message = ResultMessage;
                    // 斷線讀取失敗時，_serialPort.IsOpen會變成false
                    if (ucComPort.serialPort.IsOpen)
                    {
                        //_serialPort.WriteLine(command.Trim());

                        //double count = 1;
                        //if (count <5)
                        //{
                        //
                        // count++;
                        //}
                        try
                        {
                            ucComPort.serialPort.Write(string.Format("{0}\r", command.Trim()));
                        }
                        catch
                        {
                            Console.Write("err");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 取得馬達裝置指令回傳結果
        /// </summary>
        public string ResultMessage
        {
            get
            {
                lock (_commandLock)
                {
                    if (ucComPort.serialPort.IsOpen)
                    {
                        Thread.Sleep(50);
                        // 避免斷線時，_serialPort.BytesToRead會掛掉，_serialPort.IsOpen會變成false，加入try-catch防止異常
                        try
                        {
                            if (ucComPort.serialPort.BytesToRead > 0)
                            {
                                return ucComPort.serialPort.ReadExisting();
                            }
                        }
                        catch
                        {

                            Console.Write("Err");
                        }
                    }
                    return string.Empty;
                }
            }
        }

        #endregion

        #region 位置與方向控制

        /// <summary>
        /// 目前位置 (Pulse)
        /// </summary>
        /// <returns></returns>
        public double CurrentPosition
        {
            get
            {
                int Times = 0;
                double position;
                while (!double.TryParse(GetParameter("?PC"), out position))
                {
                    if (++Times > 5)
                    {
                        //throw new Exception("Get Motor Position Error");
                    }
                    Thread.Sleep(150);
                }
                return position;
            }
            set
            {
                ExecuteCommand(string.Format("CS {0}", value));
            }
        }

        /// <summary>
        /// 目前位置 (Millimeter)
        /// </summary>
        public double CurrentMillimeter
        {
            get { return CurrentPosition / OneMillimetrePulse; }
        }

        /// <summary>
        /// 一毫米幾個脈波
		/// MSC2=1000  => MA 1000轉一圈  (1000ps) 一圈為10 mm
        /// </summary>
		public double OneMillimetrePulse
        {
            get;
            set;
        }

        /// <summary>
        /// 旋轉方向
        /// </summary>
        public RotateDirectionType Direction
        {
            get
            {
                string Param = GetParameter("PN2").Trim();
                if (Param.Length == 5)
                {
                    return (RotateDirectionType)short.Parse(Param[4].ToString());
                }
                return RotateDirectionType.ForwardRotate; // 預設
            }
            set
            {
                if (ucComPort.serialPort.IsOpen)
                {
                    StringBuilder Param = new StringBuilder(GetParameter("PN2"));
                    if (Param.Length == 5)  // Hxxxx
                    {
                        Param[4] = (value == RotateDirectionType.ForwardRotate ? '0' : '1');
                        SetParameter("PN2", Param.ToString());
                    }
                }
            }
        }

        /// <summary>
        /// 最後一次執行的旋轉方向
        /// </summary>
        public RotateDirectionType LastRotateDirection
        {
            get { return ((GetStatusValue() & 0x804) == 0 ? RotateDirectionType.ForwardRotate : RotateDirectionType.ReverseRotate); }
        }

        #endregion

        #region 移動控制

        /// <summary>
        /// 移動位置
        /// </summary>
        /// <param name="position">旋轉位置</param>
        /// <param name="value">移動數值</param>
        public void MoveTo(RotatePositionType position, double value)
        {
            switch (position)
            {
                case RotatePositionType.AbsolutePosition:
                    ExecuteCommand(string.Format("MA {0}", value));
                    break;
                case RotatePositionType.RelativePosition:
                    ExecuteCommand(string.Format("MR {0}", value));
                    break;
            }
        }

        /// <summary>
        /// 移動至原點
        /// </summary>
        public void MoveToHome()
        {
            ExecuteCommand("H");
        }

        /// <summary>
        /// 連續旋轉 (JOG)
        /// </summary>
        /// <param name="direction">旋轉方向</param>
        public void ContinuousRotation(RotateDirectionType direction)
        {
            switch (direction)
            {
                case RotateDirectionType.ForwardRotate:
                    ExecuteCommand("JGF");
                    break;
                case RotateDirectionType.ReverseRotate:
                    ExecuteCommand("JGR");
                    break;
            }
        }

        /// <summary>
        /// 停止連續旋轉 (JOG)
        /// </summary>
        public void ContinuousRotationStop()
        {
            ExecuteCommand("JG0");
        }

        /// <summary>
        /// 暫停旋轉
        /// </summary>
        public void Pause()
        {
            if (!IsPause)
            {
                ExecuteCommand("PZ");
            }
        }

        /// <summary>
        /// 取消暫停旋轉
        /// </summary>
        public void ReDo()
        {
            if (IsPause)
            {
                ExecuteCommand("REDO");
            }
        }

        /// <summary>
        /// 緊急停止
        /// </summary>
        public void Stop()
        {
            ExecuteCommand("STOP");
            // 執行自訂程式
            ExecuteCommand("G");
        }

        /// <summary>
        /// 回機械原點
        /// </summary>
        public void ResetMechanism()
        {
            ExecuteCommand("H");
        }

        #endregion

        #region 狀態檢測

        /// <summary>
        /// 判斷馬達是否啟動
        /// </summary>
        public bool IsServoOn
        {
            get { return ((GetStatusValue() & 0x01) > 0); }
        }

        /// <summary>
        /// 取得狀態值
        /// </summary>
        /// <returns></returns>
        private int GetStatusValue()
        {
            int Times = 0;
            string Status = GetParameter("?ST");  // ST=Hxxxx
            while (!Status.StartsWith("ST="))
            {
                if (++Times > 5)
                    throw new Exception("Get Status Error");
                Thread.Sleep(150);
                Status = GetParameter("?ST");
            }
            return Convert.ToInt32(Status.Substring(4, 4), 16);
        }

        /// <summary>
        /// 判斷馬達是否正在運轉
        /// </summary>
        public bool IsRunning
        {
            get { return ((GetStatusValue() & 0x04) > 0); }
        }

        /// <summary>
        /// 判斷是否發生異常
        /// </summary>
        public bool IsError
        {
            get { return ((GetStatusValue() & 0x02) > 0); }
        }

        /// <summary>
        /// 判斷是否旋轉已到位
        /// </summary>
        public bool IsRotateReach
        {
            get { return ((GetStatusValue() & 0x08) > 0); }
        }

        /// <summary>
        /// 判斷是否連續旋轉 (JOG)
        /// </summary>
        public bool IsContinuousRotation
        {
            get { return ((GetStatusValue() & 0x40) > 0); }
        }

        /// <summary>
        /// 判斷是否旋轉暫停
        /// </summary>
        public bool IsPause
        {
            get { return ((GetStatusValue() & 0x200) > 0); }
        }

        /// <summary>
        /// 取得錯誤訊息
        /// </summary>
        public string ErrorMessage
        {
            get
            {
                if (ucComPort.serialPort.IsOpen)
                {
                    ExecuteCommand("?ERR");
                    string[] MessageArray = ResultMessage.Split('\r', '\n');
                    string ResultString = string.Empty;
                    for (int i = MessageArray.Length - 1; i >= 0; i--)
                    {
                        if (string.IsNullOrWhiteSpace(MessageArray[i])) continue;

                        if (MessageArray[i].StartsWith("ERR"))
                        {
                            ResultString += (ResultString == string.Empty ? "" : " ， ") + MessageArray[i];
                        }
                    }
                    return ResultString;
                }
                return string.Empty;
            }
        }

        #endregion

        #region 其他函式

        /// <summary>
        /// 釋放物件
        /// </summary>
        public void mDispose()
        {
            ucComPort.CloseComPort();
        }
        #endregion
    }
}
