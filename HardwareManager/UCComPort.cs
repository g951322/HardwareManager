using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace HardwareManager
{
    partial class UcComPort : UserControl
    {        
        private int _hardwareID;
        private BindingSource _ucbindingSource = new BindingSource();        
        private BindingList<Parameters> ParamsCollection { get; } = new BindingList<Parameters>();
        /// <summary>
        /// RS232物件
        /// </summary>
        private SerialPort _serialPort = new SerialPort();
        public SerialPort serialPort { get { return _serialPort; } }
        /// <summary>
        /// 關鍵區域鎖定物件
        /// </summary>
        private readonly Object _commandLock = new Object();
        /// <summary>
        /// Private Variables
        /// </summary>
        private string _portName = string.Empty;
        private int _baudRate = 9600;
        private int _dataBits = 8;
        private Handshake _handshake = Handshake.None;
        private Parity _parity = Parity.None;
        private StopBits _stopbits = StopBits.One;
        public string PortTitle { set; get; }
        public UcComPort(string portname, int baudrate, int databits, int stopbits, int parity, int handshake)
        {
            InitializeComponent();
            ParamsCollection.AllowNew = true;
            ParamsCollection.Add(new Parameters()
            {
                PortName = portname,
                BaudRate = baudrate,
                DataBits = databits,
                StopBits = stopbits,
                Parity = parity,
                Handshake = handshake
            });
            _ucbindingSource.DataSource = ParamsCollection;            
        }             
        private void ucComPort_Load(object sender, EventArgs e)
        {
            this.grpbxComport.Text = PortTitle;
            this.txtbxPortname.DataBindings.Add(new Binding("Text", this._ucbindingSource, "PortName", true, DataSourceUpdateMode.OnPropertyChanged));
            this.cmbbxBaudrate.DataBindings.Add(new Binding("Text", this._ucbindingSource, "BaudRate", true, DataSourceUpdateMode.OnPropertyChanged));
            this.cmbbxDatabits.DataBindings.Add(new Binding("Text", this._ucbindingSource, "DataBits", true, DataSourceUpdateMode.OnPropertyChanged));
            this.cmbbxParity.DataBindings.Add(new Binding("SelectedIndex", this._ucbindingSource, "Parity", true, DataSourceUpdateMode.OnPropertyChanged));
            this.cmbbxStopbits.DataBindings.Add(new Binding("SelectedIndex", this._ucbindingSource, "StopBits", true, DataSourceUpdateMode.OnPropertyChanged));
            this.cmbbxHandshake.DataBindings.Add(new Binding("SelectedIndex", this._ucbindingSource, "Handshake", true, DataSourceUpdateMode.OnPropertyChanged));            
        }

        private void CmbbxBaudrate_SelectedIndexChanged(object sender, EventArgs e)
        {
            //_ucbindingSource.
        }

        #region 指令控制
        /// <summary>
        /// 開啟RS232連線
        /// </summary>
        /// <returns></returns>
        public bool OpenComPort()
        {
            try
            {
                CloseComPort();
                _serialPort.PortName = ParamsCollection[0].PortName;
                _serialPort.Handshake = (Handshake)ParamsCollection[0].Handshake;
                _serialPort.DtrEnable = true;
                _serialPort.BaudRate = ParamsCollection[0].BaudRate;
                _serialPort.Parity = (Parity)ParamsCollection[0].Parity;
                _serialPort.DataBits = ParamsCollection[0].DataBits;
                //_serialPort.DiscardNull = false;
                _serialPort.StopBits = (StopBits)ParamsCollection[0].StopBits;
                _serialPort.Encoding = Encoding.ASCII;
                _serialPort.ReadBufferSize = 4096;
                _serialPort.WriteBufferSize = 8192;
                _serialPort.ReadTimeout = 5000;
                _serialPort.WriteTimeout = 5000;
                //_serialPort.WriteTimeout = System.IO.Ports.SerialPort.InfiniteTimeout;
                _serialPort.Open();
                // 清空 serial port 的緩存
                _serialPort.DiscardInBuffer();
                _serialPort.DiscardOutBuffer();
                Thread.Sleep(800);
                _serialPort.ReadExisting();
                return _serialPort.IsOpen;
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
            if (_serialPort.IsOpen)
            {
                _serialPort.Close();
                _serialPort.Dispose();
            }
        }

        /// <summary>
        /// 判斷RS232是否連線
        /// </summary>
        public bool IsComPortOpen
        {
            get { return _serialPort.IsOpen; }
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
                    string message = ResultMessage;
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
    }
    public class Parameters
    {
        public Parameters()
        { }
        public int HardwareID { get; set; }
        public string Mnemonic { get; set; }
        public string PortName { get; set; }
        public int BaudRate { get; set; }
        public int DataBits { get; set; }
        public int StopBits { get; set; }
        public int Parity { get; set; }
        public int Handshake { get; set; }
    }
       
    /// <summary>
    /// 指定在 SerialPort 物件上使用的Data Rate。
    /// </summary>
    public enum BaudRate
    {
        /// <summary>
        /// Data Rate 2400 bits/Sec。
        /// </summary>           
        _2400 = 2400,            
        /// <summary>
        /// Data Rate 4800 bits/Sec。
        /// </summary>
        _4800 = 4800,
        /// <summary>
        /// Data Rate 9600 bits/Sec。
        /// </summary>
        _9600 = 9600,
        /// <summary>
        /// Data Rate 14400 bits/Sec。
        /// </summary>
        _14400 = 14400,
        /// <summary>
        /// Data Rate 19200 bits/Sec。
        /// </summary>
        _19200 = 19200,
        //
        // 摘要:
        //     Data Rate 28800 bits/Sec。
        _28800 = 28800,
        /// <summary>
        /// Data Rate 38400 bits/Sec。
        /// </summary>
        _38400 = 38400,
        /// <summary>
        /// Data Rate 115200 bits/Sec。
        /// </summary>
        _115200 = 115200
    }
    
    /// <summary>
    /// 指定在 SerialPort 物件上使用的Data Bits。
    /// </summary>
    public enum DataBits
    {
        /// <summary>
        /// 6 Data Bits。
        /// </summary>            
        _6 = 6,
        /// <summary>
        /// 7 Data Bits。
        /// </summary>
        _7 = 7,
        /// <summary>
        /// 8 Data Bits。
        /// </summary>
        _8 = 8,
        /// <summary>
        /// 9 Data Bits。
        /// </summary>
        _9 = 9,
        /// <summary>
        /// 10 Data Bits。
        /// </summary>
        _10 = 10        
    }
}
