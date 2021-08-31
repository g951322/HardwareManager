using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;
using System.Threading;

namespace HardwareManager
{
    class MotorDIO : IMotorDIO
    {
        public UcComPort ucComPort;
        /// <summary>
        /// 關鍵區域鎖定物件
        /// </summary>
        private readonly Object _commandLock = new Object();
        /// <summary>
        /// RS232物件
        /// </summary>
        private SerialPort _serialPort = new SerialPort();
        private string diStatus { get; set; }
        public string DIStatus { get { return diStatus; } }
        public MotorDIO(string portname, int baudrate, int databits, int stopbits, int parity, int handshake)
        {
            ucComPort = new UcComPort(portname, baudrate, databits, stopbits, parity, handshake);
            ucComPort.PortTitle = "翻面機構";
            _serialPort = ucComPort.serialPort;
            //_serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            diStatus = "00000000";
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string mess = sp.ReadExisting();            
            int decval;           
            if (int.TryParse(mess, out decval))
            {                
                diStatus = System.Convert.ToString(decval, 2).PadLeft(8, '0');                
            }
            //else diStatus = "00000000";            
        }
        #region DIDO控制
        /// <summary>
        ///Enable輸出埠
        /// </summary>
        public bool EnableDO(DigitalOUT digitalOutput)
        {
            try
            {
                string cmdString = "M" + ((int)(((int)digitalOutput - 1) / 8)).ToString() + ".ENABLEDO." + ((int)digitalOutput).ToString();
                ExecuteCommand(cmdString);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
        /// <summary>
        /// Disable輸出埠
        /// </summary>
        public bool DisableDO(DigitalOUT digitalOutput)
        {
            try
            {
                string cmdString = "M" + ((int)(((int)digitalOutput - 1) / 8)).ToString() + ".DISABLEDO." + ((int)digitalOutput).ToString();
                ExecuteCommand(cmdString);
                return true;
            }
            catch (Exception)
            {
                return false;
            }            
        }
        /// <summary>
        ///讀取輸入埠
        /// </summary>
        public string ReadDI(DigitalIN digitalInput)
        {
            string diStatus = "000000000000";
            int decval;
            ExecuteCommand("M0.READDI");
            string mess = ucComPort.ResultMessage;              
            if (int.TryParse(mess, out decval))
            {
                diStatus = System.Convert.ToString(decval/10, 2).PadLeft(8, '0');
                diStatus = System.Convert.ToString(decval - (decval / 10) * 10, 2).PadLeft(4, '0') + diStatus;
            }
            else diStatus = "000000000000";
            if (digitalInput == DigitalIN.DIALL) return diStatus;
            else return diStatus.Substring(diStatus.Length - (int)digitalInput, 1);
        }
        /// <summary>
        ///讀取輸出埠
        /// </summary>
        public string ReadDO(DigitalOUT digitalOutput)
        {
            string doStatus = "00000000";
            int decval;
            ExecuteCommand("M0.READDO");
            string mess = ucComPort.ResultMessage;
            if (int.TryParse(mess, out decval))
            {
                doStatus = System.Convert.ToString(decval, 2).PadLeft(8, '0');                
            }
            else doStatus = "00000000";
            if (digitalOutput == DigitalOUT.DOALL) return doStatus;
            else return doStatus;
        }
        public void ResetBoard()
        {
            ExecuteCommand("M0.RESETBOARD");
        }
        #endregion
        #region 連線控制

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
        #endregion

        #region 參數控制

        /// <summary>
        /// 讀取參數值
        /// </summary>
        /// <param name="motorID"></param>
        /// <param name="paramName"></param>
        /// <returns>string</returns>
        public string GetParameter(string motorID, string paramName)
        {
            if (_serialPort.IsOpen)
            {
                ExecuteCommand(string.Format("{0}.GETPARAM.{1}", motorID, paramName));
                string[] MessageArray = ResultMessage.Split('\r', '\n');
                List<string> list = new List<string>();
                for (int i = 0; i < MessageArray.Length; i++)
                {
                    if (string.IsNullOrWhiteSpace(MessageArray[i])) continue;
                    list.Add(MessageArray[i]);
                }
                if (list.Count > 0)
                {
                    for (int i = 0; i <= list.Count - 1; i++)
                    {
                        if (list[i].StartsWith("L6470#" + motorID.Remove(0, 1) + " " + paramName + " value is"))
                        {
                            return list[i].Remove(0, ("L6470#" + motorID.Remove(0, 1) + " " + paramName + " value is ").Length);
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
        /// <param name="motorID"></param>
        /// <param name="paramName"></param>
        /// <param name="value"></param>
        public void SetParameter(string motorID, string paramName, string value)
        {
            Thread.Sleep(50);
            ExecuteCommand(string.Format("{0}.SETPARAM.{1}.{2}", motorID, paramName, value));
        }

        /// <summary>
        /// 儲存參數值
        /// </summary>
        /// <param></param> 
        /// <returns></returns>
        public void SaveParameter()
        {
            ExecuteCommand("M0.NOP");
        }

        /// <summary>
        /// 執行馬達裝置指令
        /// </summary>
        /// <param name="command">馬達裝置指令</param>
        public void ExecuteCommand(string command)
        {
            lock (_commandLock)
            {
                if (_serialPort.IsOpen && !string.IsNullOrWhiteSpace(command))
                {
                    // 清除暫存訊息
                    //string message = ResultMessage;
                    // 斷線讀取失敗時，_serialPort.IsOpen會變成false
                    if (_serialPort.IsOpen)
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
                            _serialPort.Write(string.Format("{0}\r", command.Trim()));
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
                    if (_serialPort.IsOpen)
                    {
                        Thread.Sleep(50);
                        // 避免斷線時，_serialPort.BytesToRead會掛掉，_serialPort.IsOpen會變成false，加入try-catch防止異常
                        try
                        {
                            if (_serialPort.BytesToRead > 0)
                            {
                                return _serialPort.ReadExisting();
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

        #region 指令控制
        public void Run(string motorID, MotorDirections direction, double speed)
        {
            switch (direction)
            {
                case MotorDirections.FWD:
                    ExecuteCommand(string.Format("{0}.RUN.{1}.{2}", motorID, "FWD", speed));
                    break;
                case MotorDirections.REV:
                    ExecuteCommand(string.Format("{0}.RUN.{1}.{2}", motorID, "REV", speed));
                    break;
            }
        }
        public void Run(string motorID, string direction, double speed)
        {
            ExecuteCommand(string.Format("{0}.RUN.{1}.{2}", motorID, direction, speed));
        }

        public void StepClock(string motorID, MotorDirections direction)
        {
            switch (direction)
            {
                case MotorDirections.FWD:
                    ExecuteCommand(string.Format("{0}.STEPCLOCK.{1}", motorID, "FWD"));
                    break;
                case MotorDirections.REV:
                    ExecuteCommand(string.Format("{0}.STEPCLOCK.{1}", motorID, "REV"));
                    break;
            }
        }

        public void Move(string motorID, MotorDirections direction, double steps)
        {
            switch (direction)
            {
                case MotorDirections.FWD:
                    ExecuteCommand(string.Format("{0}.MOVE.{1}.{2}", motorID, "FWD", steps));
                    break;
                case MotorDirections.REV:
                    ExecuteCommand(string.Format("{0}.MOVE.{1}.{2}", motorID, "REV", steps));
                    break;
            }
        }

        public void Move(string motorID, string direction, double steps)
        {
            ExecuteCommand(string.Format("{0}.MOVE.{1}.{2}", motorID, direction, steps));
        }

        public void Goto(string motorID, double absPos)
        {
            ExecuteCommand(string.Format("{0}.GOTO.{1}", motorID, absPos));
        }

        public void GotoDir(string motorID, MotorDirections direction, double absPos)
        {
            switch (direction)
            {
                case MotorDirections.FWD:
                    ExecuteCommand(string.Format("{0}.GOTO_DIR.{1}.{2}", motorID, "FWD", absPos));
                    break;
                case MotorDirections.REV:
                    ExecuteCommand(string.Format("{0}.GOTO_DIR.{1}.{2}", motorID, "REV", absPos));
                    break;
            }
        }

        public void GotoDir(string motorID, string direction, double absPos)
        {
            ExecuteCommand(string.Format("{0}.GOTO_DIR.{1}.{2}", motorID, direction, absPos));
        }

        public void GoUntil(string motorID, ABS_POS_ACT action, MotorDirections direction, double speed)
        {
            string[] Act = { "RST", "CPY" };
            string[] Dir = { "FWD", "REV" };
            ExecuteCommand(string.Format("{0}.GOUNTIL.{1}.{2}.{3}", motorID, Act[(int)action], Dir[(int)direction], speed));
            //ExecuteCommand(string.Format("{0}.GOUNTIL.{1}.{2}.{3}", motorID, "RST", "FWD", speed));
            //switch (direction)
            //{
            //    case MotorDirections.FWD:
            //        ExecuteCommand(string.Format("{0}.GOUNTIL.{1}.{2}.{3}", motorID, action, "FWD", speed));
            //        break;
            //    case MotorDirections.REV:
            //        ExecuteCommand(string.Format("{0}.GOUNTIL.{1}.{2}.{3}", motorID, action, "REV", speed));
            //        break;
            //}
        }
        public void GoUntil(string motorID, string action, string direction, double speed)
        {
            ExecuteCommand(string.Format("{0}.GOUNTIL.{1}.{2}.{3}", motorID, action, direction, speed));
        }

        public void ReleaseSW(string motorID, ABS_POS_ACT action, MotorDirections direction)
        {
            switch (direction)
            {
                case MotorDirections.FWD:
                    ExecuteCommand(string.Format("{0}.RELEASESW.{1}.{2}", motorID, "FWD", action));
                    break;
                case MotorDirections.REV:
                    ExecuteCommand(string.Format("{0}.RELEASESW.{1}.{2}", motorID, "REV", action));
                    break;
            }
        }
        public void ReleaseSW(string motorID, string action, string direction)
        {
            ExecuteCommand(string.Format("{0}.RELEASESW.{1}.{2}", motorID, action, direction));
        }

        public void GoHome(string motorID)
        {
            ExecuteCommand(string.Format("{0}.GOHOME", motorID));
        }

        public void ResetPos(string motorID)
        {
            ExecuteCommand(string.Format("{0}.RESETPOS", motorID));
        }

        public void ResetDevice(string motorID)
        {
            ExecuteCommand(string.Format("{0}.RESETDEVICE", motorID));
        }

        public void SoftStop(string motorID)
        {
            ExecuteCommand(string.Format("{0}.SOFTSTOP", motorID));
        }

        public void HardStop(string motorID)
        {
            ExecuteCommand(string.Format("{0}.HARDSTOP", motorID));
        }

        public void SoftHIZ(string motorID)
        {
            ExecuteCommand(string.Format("{0}.SOFTHIZ", motorID));
        }

        public void HardHIZ(string motorID)
        {
            ExecuteCommand(string.Format("{0}.HARDHIZ", motorID));
        }
        #endregion

        #region 其他函式

        /// <summary>
        /// 釋放物件
        /// </summary>
        public void Dispose()
        {
            CloseComPort();
        }
        #endregion
    }
}
