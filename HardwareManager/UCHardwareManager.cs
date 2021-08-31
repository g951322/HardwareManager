using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using TimersTimer = System.Timers.Timer;
using Susi4.APIs;
using Susi4.Plugin;
using Susi4.Libraries;

namespace HardwareManager
{

    public partial class UCHardwareManager : UserControl, ISusiHost
    {
        TimersTimer timer;
        Motor motor;
        MotorDIO motorDIO;
        UcDO[] ucDO;
        UcDI[] ucDI;
        bool swapWatcher = false;
        static string selectTab;
        string[] mnemonicDO = new string[8] { "翻片組(上)", "翻片組(下)", "取片組(下)", "黏塵組(下)", "翻片組Vac", "取片組Vac", "背光Vac", "Z剎車釋放" };
        string[] mnemonicDI = new string[8] { "翻片組(上)", "翻片組(下)", "取片組(上)", "取片組(下)", "黏塵組(左上)", "黏塵組(左下)", "黏塵組(右上)", "黏塵組(右下)" };
        int[] DI = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
        int[] DO = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
        public string DIstatus { get { return _DIstatus; } }
        private string _DIstatus = "0";
        public string DOstatus { get { return _DOstatus; } }
        private string _DOstatus = "0";
        private bool isStopRefresh = false, isRunning = false;
        private int procedureChecker = (int)StatusHWOps.None;
        private string wastedTimeByCallback = "00:00";
        CancellationTokenSource cts;
        private DigitalIN platformVAC = DigitalIN.DI11, pickerVAC = DigitalIN.DI10, flipperVAC = DigitalIN.DI9;
        private const double xFlipABSPOS = 22.1;
        private const double xStandbyABSPOS = 3;
        private const double zPickABSPOS = 19.6;
        private const double zFlipABSPOS = 32.6;
        private const double zStandbyABSPOS = 10;
        private const double xHomeABSPOS = 0, zHomeABSPOS = 0;
        private const int pltMoveInTimeout = 20000, xzFlipFilmTimeout = 120000;
        
        public enum StatusHWOps
        {
            BeginInspection = 0,
            BeginGrab,
            MoveInCompleted,
            FlipCompleted,
            InHomePosition,
            None
        }

        #region ISusiHost
        public const string PLUGIN_PATH = @"..\Plugins";
        private DemoConfig config;
        public DemoConfig Config
        {
            get { return config; }
        }
        #endregion

        public UCHardwareManager()
        {
            InitializeComponent();
            timer = new TimersTimer();
            timer.Interval = 500;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            motor = new Motor("COM7", (int)BaudRate._9600, (int)DataBits._8, (int)StopBits.One, (int)Parity.None, (int)Handshake.XOnXOff);
            motorDIO = new MotorDIO("COM6", (int)BaudRate._115200, (int)DataBits._8, (int)StopBits.One, (int)Parity.None, (int)Handshake.None);
            ucDO = new UcDO[8];
            ucDI = new UcDI[8];
            for (int i = 0; i < 8; i++)
            {
                ucDO[i] = new UcDO();
                ucDO[i].DONo = "DO" + (i + 1).ToString();
                ucDO[i].DOMnemonic = mnemonicDO[i];
                ucDO[i].radbtnDOon.Name = "RADdo" + (i + 1).ToString();
                ucDO[i].radbtnDOon.Click += RadbtnDOon_Click;
                ucDO[i].radbtnDOoff.Name = "RADdf" + (i + 1).ToString();
                ucDO[i].radbtnDOoff.Click += RadbtnDOoff_Click;
                ucDI[i] = new UcDI();
                ucDI[i].DINo = "DI" + (i + 1).ToString();
                ucDI[i].DIMnemonic = mnemonicDI[i];
            }
            UserControlsLoad();
        }

        public UCHardwareManager(string motorComport = "COM8", string motorDIOComport = "COM6", int mbaudrate = (int)BaudRate._9600, int mdatabits = (int)DataBits._8, int mstopbits = (int)StopBits.One, int mparity = (int)Parity.None, int mhandshake = (int)Handshake.XOnXOff, 
                         int dbaudrate = (int)BaudRate._115200, int ddatabits = (int)DataBits._8, int dstopbits = (int)StopBits.One, int dparity = (int)Parity.None, int dhandshake = (int)Handshake.None)
        {
            InitializeComponent();
            timer = new TimersTimer();
            timer.Interval = 500;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            motor = new Motor(motorComport, mbaudrate, mdatabits, mstopbits, mparity, mhandshake);
            motorDIO = new MotorDIO(motorDIOComport, dbaudrate, ddatabits, dstopbits, dparity, dhandshake);
            ucDO = new UcDO[8];
            ucDI = new UcDI[8];
            for (int i = 0; i < 8; i++)
            {
                ucDO[i] = new UcDO();
                ucDO[i].DONo = "DO" + (i + 1).ToString();
                ucDO[i].DOMnemonic = mnemonicDO[i];
                ucDO[i].radbtnDOon.Name = "RADdo" + (i + 1).ToString();
                ucDO[i].radbtnDOon.Click += RadbtnDOon_Click;
                ucDO[i].radbtnDOoff.Name = "RADdf" + (i + 1).ToString();
                ucDO[i].radbtnDOoff.Click += RadbtnDOoff_Click;
                ucDI[i] = new UcDI();
                ucDI[i].DINo = "DI" + (i + 1).ToString();
                ucDI[i].DIMnemonic = mnemonicDI[i];
            }
            UserControlsLoad();
            //timer.Start();
        }

        private void RadbtnDOoff_Click(object sender, EventArgs e)
        {
            RadioButton radDO = sender as RadioButton;
            int donum;
            if (int.TryParse(radDO.Name.Remove(0, 5), out donum))
            {
                //if (!ucDO[donum - 1].DOStatus) motorDIO.DisableDO((DigitalOUT)donum);
                //else motorDIO.EnableDO((DigitalOUT)donum);
                motorDIO.DisableDO((DigitalOUT)donum);
            }
        }

        private void RadbtnDOon_Click(object sender, EventArgs e)
        {            
            RadioButton radDO = sender as RadioButton;
            int donum;
            if (int.TryParse(radDO.Name.Remove(0, 5), out donum))
            {
                //if (!ucDO[donum-1].DOStatus) motorDIO.DisableDO((DigitalOUT)donum);
                //else motorDIO.EnableDO((DigitalOUT)donum);
                motorDIO.EnableDO((DigitalOUT)donum);
            }
        }

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //swapWatcher = !swapWatcher;            
            //this.BeginInvoke(new Action(delegate () {
            //    selectTab = tabControl1.SelectedTab.Name;
            //}));            
            if(selectTab == "tabpgDIO")
            {
                _DIstatus = motorDIO.ReadDI(DigitalIN.DIALL);
                //_DIstatus = motorDIO.DIStatus;
                int status = 0;
                for (int i = 0; i < _DIstatus.Length-4; i++)
                {
                    if (int.TryParse(_DIstatus.Substring(_DIstatus.Length - 1 - i, 1), out status)) { }
                    else status = 0;
                    this.BeginInvoke(new UpdateControl(_mUpdateControl), new object[] { ucDI[i], status });
                }
                Thread.Sleep(50);
                _DOstatus = motorDIO.ReadDO(DigitalOUT.DOALL);
                //_DOstatus = "00000000";
                for (int i = 0; i < _DOstatus.Length; i++)
                {
                    if (int.TryParse(_DOstatus.Substring(_DOstatus.Length - 1 - i, 1), out status)) { }
                    else status = 0;
                    this.BeginInvoke(new UpdateControl(_mUpdateControl), new object[] { ucDO[i], status });
                }
            }
            else
            if(selectTab == "tabpgPickPlace")
            {
                int m0ABSPOS, m1ABSPOS;
                try
                {
                    string posString = motorDIO.GetParameter("M0", "ABS_POS");
                    m0ABSPOS = Convert.ToInt32(posString, 16);
                    Thread.Sleep(50);
                    m1ABSPOS = Convert.ToInt32(motorDIO.GetParameter("M1", "ABS_POS"), 16);
                    this.BeginInvoke(new UpdateControl(_mUpdateControl), new object[] { labXPosition, m1ABSPOS });
                    this.BeginInvoke(new UpdateControl(_mUpdateControl), new object[] { labZPosition, m0ABSPOS });
                }
                catch (Exception ex)
                {                    
                    this.BeginInvoke(new UpdateControl(_mUpdateControl), new object[] { labXPosition, -1 });                    
                    this.BeginInvoke(new UpdateControl(_mUpdateControl), new object[] { labZPosition, -1 });
                }                              
            }
            else
            if(null == selectTab | selectTab == "tabpgPlatform")
            {
                if (motor.IsComPortOpen)
                {
                    this.BeginInvoke(new UpdateControl(_mUpdateControl), new object[] { labPosition, (int)motor.CurrentPosition });
                    this.BeginInvoke(new UpdateControl(_mUpdateControl), new object[] { labSpeed, (int)motor.MoveSpeed });
                    this.BeginInvoke(new UpdateControl(_mUpdateControl), new object[] { labProcedureChecker, procedureChecker });
                    this.BeginInvoke(new UpdateControl(_mUpdateControl), new object[] { labWastedTimeByCallback, null });
                }
            }
        }

        delegate void UpdateControl(Control Ctrl, int diostatus);
        private object _objLock = new object();
        void _mUpdateControl(Control Ctrl, int diostatus)
        {
            lock (this._objLock)
            {
                if (Ctrl is UcDI) ((UcDI)Ctrl).DIStatus = diostatus == 1 ? true : false;
                if (Ctrl is UcDO) ((UcDO)Ctrl).DOStatus = diostatus == 1 ? true : false;
                if (Ctrl is Label)
                {
                    if (Ctrl.Name == "labPosition")
                    {
                        if (!isStopRefresh)
                        {
                            Ctrl.Text = diostatus.ToString();
                            trkbrPlatformPosition.Value = diostatus > 0 ? diostatus : 0;
                        }
                    }
                    else if (Ctrl.Name == "labSpeed")
                    {
                        if(!isStopRefresh)
                        {
                            Ctrl.Text = diostatus.ToString();
                            trkbrPlatformSpeed.Value = diostatus > 0 ? diostatus : 0;
                        }                        
                    }
                    else if (Ctrl.Name == "labProcedureChecker")
                    {
                        Ctrl.Text = diostatus.ToString(); 
                    }
                    else if(Ctrl.Name == "labWastedTimeByCallback")
                    {
                        Ctrl.Text = wastedTimeByCallback;
                    }
                    else if (Ctrl.Name == "labXPosition")
                    {
                        if (!isStopRefresh)
                        {
                            Ctrl.Text = diostatus == 0 ? 0.ToString() : ((float)(MotorDIOParameters.MAX_ABS_POS - diostatus) / MotorDIOParameters.CM2Pulse).ToString("0.00");
                            trkbrXPosition.Value = MotorDIOParameters.MAX_ABS_POS - diostatus < trkbrXPosition.Maximum ? MotorDIOParameters.MAX_ABS_POS - diostatus : 0;
                        }
                    }
                    else if (Ctrl.Name == "labZPosition")
                    {
                        if (!isStopRefresh)
                        {
                            Ctrl.Text = diostatus == 0 ? 0.ToString() : ((float)(MotorDIOParameters.MAX_ABS_POS - diostatus) / MotorDIOParameters.CM2Pulse).ToString("0.00");
                            trkbrZPosition.Value = MotorDIOParameters.MAX_ABS_POS - diostatus < trkbrZPosition.Maximum ? MotorDIOParameters.MAX_ABS_POS - diostatus : 0;
                        }
                    }
                }                
            }
        }

        private void UserControlsLoad()
        {
            layoutpnlHWManager.Controls.Add(motor.ucComPort, 0, 0);
            motor.ucComPort.Dock = DockStyle.Fill;
            if (motor.OpenComPort()) labPosition.Text = motor.CurrentPosition.ToString();
            trkbrPlatformPosition.Value = Convert.ToInt32(motor.CurrentPosition);
            motor.MoveSpeed = 50;
            labSpeed.Text = motor.MoveSpeed.ToString();

            layoutpnlHWManager.Controls.Add(motorDIO.ucComPort, 0, 1);
            motorDIO.ucComPort.Dock = DockStyle.Fill;
            if (motorDIO.OpenComPort())
            {
                for (int i = 0; i < 8; i++)
                {
                    layoutpnlDO.Controls.Add(ucDO[i], i / 4, i % 4);
                    ucDO[i].Dock = DockStyle.Fill;
                    layoutpnlDI.Controls.Add(ucDI[i], i / 4, i % 4);
                    ucDI[i].Dock = DockStyle.Fill;
                }
                InitXZAxis();
            }
        }
        private void LoadPlugins()
        {
            PluginService pluginService = new PluginService(this as ISusiHost);

            pluginService.FindPlugins(Path.Combine(Application.StartupPath, PLUGIN_PATH));

            foreach (ISusiPlugin isp in pluginService.Plugins)
            {
                if (!isp.Enable)
                    continue;

                TabPage newPage = new TabPage(isp.Name);
                newPage.Controls.Add(isp.MainInterface);
                isp.MainInterface.Dock = DockStyle.Fill;
                tabControlSUSI.TabPages.Add(newPage);
            }
        }

        private void UCHardwareManager_Load(object sender, EventArgs e)
        {
            //layoutpnlHWManager.Controls.Add(motor.ucComPort, 0, 0);
            //motor.ucComPort.Dock = DockStyle.Fill;
            //if (motor.OpenComPort()) labPosition.Text = motor.CurrentPosition.ToString();
            //trkbrPlatformPosition.Value = Convert.ToInt32(labPosition.Text);
            //motor.MoveSpeed = 50;
            //labSpeed.Text = motor.MoveSpeed.ToString();

            //layoutpnlHWManager.Controls.Add(motorDIO.ucComPort, 0, 1);
            //motorDIO.ucComPort.Dock = DockStyle.Fill;
            //if(motorDIO.OpenComPort())
            //{
            //    for (int i = 0; i < 8; i++)
            //    {
            //        layoutpnlDO.Controls.Add(ucDO[i], i / 4, i % 4);
            //        ucDO[i].Dock = DockStyle.Fill;
            //        layoutpnlDI.Controls.Add(ucDI[i], i / 4, i % 4);
            //        ucDI[i].Dock = DockStyle.Fill;
            //    }
            //    InitXZAxis();                
            //}
            config = new DemoConfig();
            LoadPlugins();
            timer.Start(); 
        }
                
        ///<summary>
        ///移動置片平台
        ///</summary>
        ///<param name = "speed" >Moving Speed(in RPM)</param>
        ///<param name="distance">Moving Distance(in mm)</param>
        public void PlatformMove(int speed, double distance)
        {
            motor.MoveSpeed = speed;
            motor.MoveTo(RotatePositionType.AbsolutePosition, distance);
        }
        ///<summary>
        ///檢查置片平台是否到位, Distance(in mm)、Time Out(in ms)
        ///</summary>
        ///<param name = "timeout">Time Out(in ms)</param>        
        ///<param name="distance">Moving Distance(in mm)</param>
        ///<returns>return Boolean True or False</returns>        
        /*public async Task<bool> IsInPositionAsync(double distance,int timeout)
        {
            if (timeout < 1000) timeout = 1000;
            try
            {
                var iipTask = Task.Factory.StartNew(async delegate
                {                    
                    while (motor.CurrentPosition != distance)//motor.IsRunning | !motor.IsRotateReach)
                    {
                        await Task.Delay(100);                        
                    }
                }, CancellationToken.None, TaskCreationOptions.DenyChildAttach, TaskScheduler.Default);
                await iipTask.Unwrap();
                if (!iipTask.Wait(timeout))
                {
                    OnPlatformInPosEvent(false);
                    return false;
                }
                else
                {
                    OnPlatformInPosEvent(true);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }            
        }*/
        
        ///<summary>
        ///檢查置片平台是否到位, Distance(in mm)、Time Out(in ms)
        ///</summary>
        ///<param name = "timeout">Time Out(in ms)</param>        
        ///<param name="distance">Moving Distance(in mm)</param>
        ///<returns>return Boolean True or False</returns>   
        public bool InvokePlatformInPosCheck(double distance, int timeout)
        {  
            AsyncInPosChecker inPosDelegate = new AsyncInPosChecker(platformInPositionCheck);
            // Asynchronously invoke the InPosCheck method.
            IAsyncResult result = inPosDelegate.BeginInvoke(distance, null, null);
            while (!result.IsCompleted)
            {                
                result.AsyncWaitHandle.WaitOne(timeout, true);
            }
            result.AsyncWaitHandle.Close();
            return inPosDelegate.EndInvoke(result);            
        }
        public bool InvokeXZInPosCheck(string axis, double distance, int timeout)
        {
            AsyncXZInPosChecker inPosDelegate = new AsyncXZInPosChecker(xzInPositionCheck);
            // Asynchronously invoke the InPosCheck method.
            IAsyncResult result = inPosDelegate.BeginInvoke(axis, distance, null, null);
            while (!result.IsCompleted)
            {
                result.AsyncWaitHandle.WaitOne(timeout, true);
            }
            result.AsyncWaitHandle.Close();

            return inPosDelegate.EndInvoke(result);
        }
        private bool platformInPositionCheck(double distance)
        {
            try
            {
                while (motor.CurrentPosition != distance)
                {
                    Thread.Sleep(300);                    
                }                          
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private bool xzInPositionCheck(string axis, double distance)
        {
            string posString;
            int m1ABSPOS = 0;            
            try
            {
                do
                {
                    posString = motorDIO.GetParameter(axis, "ABS_POS");
                    m1ABSPOS = Convert.ToInt32(posString, 16);
                    if (m1ABSPOS > 12800) m1ABSPOS = (MotorDIOParameters.MAX_ABS_POS - m1ABSPOS) % MotorDIOParameters.MAX_ABS_POS;
                    Thread.Sleep(300);
                } while (Math.Abs(m1ABSPOS - distance * MotorDIOParameters.CM2Pulse) > 256); //((m1ABSPOS - distance * MotorDIOParameters.CM2Pulse) != 0);                
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        // Create an asynchronous delegate that matches the InPOSCheck method.
        public delegate bool AsyncInPosChecker(double distance);
        public delegate bool AsyncXZInPosChecker(string axis, double distance);
        ///<summary>
        ///置片平台回HOME
        ///</summary>
        ///<param>void</param>
        ///<returns>return Boolean True or False</returns>
        public bool PlatformHome()
        {
            try
            {
                var ph = Task.Factory.StartNew(new Action(delegate ()
                {
                    RemoverDown(false);
                    int status = 0;
                    while (status != 1)
                    {
                        Thread.Sleep(1000);
                        ReadRemoverLUp(out status);
                    }
                    status = 0;
                    while (status != 1)
                    {
                        Thread.Sleep(1000);
                        ReadRemoverRUp(out status);
                    }
                    motor.MoveToHome();
                    bool x = InvokePlatformInPosCheck(0, 10000);
                    if(x) OnStatusCallbackEvent(x, (int)StatusHWOps.InHomePosition);
                }));
                if (ph.Wait(15000)) return true;
                else return false;
            }
            catch (Exception)
            {
                return false;
            }             
        }
        ///<summary>
        ///薄片送入檢測()
        ///</summary>
        ///<param>void</param>
        ///<returns>return Boolean True or False</returns>
        public void BeginInspectionInvoke()
        {
            try
            {
                bool rtnState = true;                
                var bii = Task.Factory.StartNew(new Action(delegate ()
                {
                    int counter = 0, status = 1;
                    if (SetPlatFormVAC(true))
                    {
                        //while (status != 0)
                        //{
                        //    if (counter++ > 20) { MessageBox.Show("真空吸附功能失效", "硬體失效錯誤"); SetPlatFormVAC(false); return; }
                        //    Thread.Sleep(300);
                        //    ReadVAC(platformVAC, out status);
                        //}
                        Thread.Sleep(300);
                        RemoverDown(true);
                        status = 0;
                        counter = 0;
                        while (status != 1)
                        {
                            if (counter++ > 10) { MessageBox.Show("黏塵或位置感測裝置失效", "硬體失效錯誤"); RemoverDown(false); return; }
                            Thread.Sleep(1000);
                            ReadRemoverLDown(out status);
                        }
                        status = 0;
                        while (status != 1)
                        {
                            if (counter++ > 10) { MessageBox.Show("黏塵或位置感測裝置失效", "硬體失效錯誤"); RemoverDown(false); return; }
                            Thread.Sleep(1000);
                            ReadRemoverRDown(out status);
                        }
                        OnBeginInspectionEvent(rtnState);
                        OnStatusCallbackEvent(rtnState, (int)StatusHWOps.BeginInspection);
                    }
                    else OnStatusCallbackEvent(rtnState, (int)StatusHWOps.BeginInspection);//MessageBox.Show("真空吸附裝置失效", "硬體失效錯誤");
                }));                
                //if (bii.Wait(15000)) OnBeginInspectionEvent(rtnState);
                //else OnBeginInspectionEvent(false);
            }
            catch (Exception)
            {
                MessageBox.Show("薄片真空吸附失效", "硬體失效錯誤");
            }
        }

        ///<summary>
        ///薄片送入檢測(int speed1, double distance1, int speed2, double distance2)
        ///</summary>
        ///<param>void</param>
        ///<returns>return Boolean True or False</returns>        
        public bool FilmMoveInInvoke(int speed1=200, double distance1=100, int speed2=100, double distance2=265)
        {
            cts = new CancellationTokenSource();            
            int status = 1;
            bool x = false;                      
            try
            {
                var fmii = Task.Factory.StartNew(() =>
                {
                    RemoverDown(true);
                    status = 0;
                    while (status != 1)
                    {
                        Thread.Sleep(1000);
                        ReadRemoverLDown(out status);
                    }
                    status = 0;
                    while (status != 1)
                    {
                        Thread.Sleep(1000);
                        ReadRemoverRDown(out status);
                    }
                    PlatformMove(speed1, distance1);
                    x = InvokePlatformInPosCheck(distance1, 1000);
                }, cts.Token);
                var cont1 = fmii.ContinueWith((task) =>
                {
                    if (x)
                    {
                        PlatformMove(speed2, distance2);
                        OnPlatformInPosEvent(x);
                        OnStatusCallbackEvent(x, (int)StatusHWOps.BeginGrab);
                        x = false;
                        x = InvokePlatformInPosCheck(distance2, 6000);
                    }
                }, cts.Token);
                var cont2 = cont1.ContinueWith((task) =>
                {
                    OnMoveInCompletedEvent(x);
                    OnStatusCallbackEvent(x, (int)StatusHWOps.MoveInCompleted);
                }, cts.Token);
                if (!fmii.Wait(pltMoveInTimeout)) cts.Cancel();
                if (!cont1.Wait(pltMoveInTimeout)) cts.Cancel();
                if (!cont2.Wait(pltMoveInTimeout)) return x;
                else return x;
            }
            catch (AggregateException ex)
            {
                return false;
            }
        }
        /*public async Task<bool> FilmMoveInAsync()
        {
            try
            {
                int status = 1;
                if (SetPlatFormVAC(true)) ReadVAC(platformVAC, out status);
                if (status == 0)
                {
                    PlatformMove(100, 100);
                    bool x = await IsInPositionAsync(100, 10000);
                    if (x)
                    {
                        PlatformMove(150, 305);
                        x = await IsInPositionAsync(305, 60000);
                    }
                    return x;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }*/

        ///<summary>
        ///薄片翻面
        ///</summary>
        ///<param>void</param>
        ///<returns>return Boolean True or False</returns>
        public bool FlipFilmInvoke()
        {
            cts = new CancellationTokenSource();
            int status = 1;
            bool iip = false;
            try
            {
                var ffi = Task.Factory.StartNew(() =>
                {
                    SetPlatFormVAC(false);                    
                    Thread.Sleep(500);
                    SetBrakeOff(true);
                    Thread.Sleep(500);
                    PickerDown(true);
                    Thread.Sleep(500);
                    FliperUp(false);
                    Thread.Sleep(500);
                    FliperDown(true);
                    Thread.Sleep(500);
                    SetPickerVAC(true);
                    while (status != 0)
                    {
                        Thread.Sleep(1000);
                        ReadVAC(pickerVAC, out status);
                    }
                    Thread.Sleep(500);
                    PickerDown(false);
                    Thread.Sleep(500);
                    XAxisMove(xFlipABSPOS);
                    Thread.Sleep(500);
                    iip = InvokeXZInPosCheck("M1", xFlipABSPOS, 20000);
                }, cts.Token);
                var cont1 = ffi.ContinueWith(task =>
                {
                    if (iip)
                    {
                        Thread.Sleep(500);
                        PickerDown(true);
                        Thread.Sleep(500);
                        SetPickerVAC(false);
                        Thread.Sleep(500);
                        PickerDown(false);
                        Thread.Sleep(500);
                        XAxisMove(xStandbyABSPOS);
                        Thread.Sleep(500);
                        iip = false;
                        iip = InvokeXZInPosCheck("M1", xStandbyABSPOS, 20000);
                    }
                }, cts.Token);
                var cont2 = cont1.ContinueWith(task =>
                {
                    if (iip)
                    {
                        Thread.Sleep(300);
                        ZAxisMove(zPickABSPOS);
                        Thread.Sleep(300);
                        iip = false;
                        iip = InvokeXZInPosCheck("M0", zPickABSPOS, 20000);
                    }
                }, cts.Token);
                var cont3 = cont2.ContinueWith(task =>
                {
                    if (iip)
                    {
                        Thread.Sleep(300);
                        SetFliperVAC(true);
                        status = 1;
                        while (status != 0)
                        {
                            Thread.Sleep(1000);
                            ReadVAC(flipperVAC, out status);
                        }
                        Thread.Sleep(500);
                        ZAxisMove(zStandbyABSPOS);
                        Thread.Sleep(500);
                        iip = false;
                        iip = InvokeXZInPosCheck("M0", zStandbyABSPOS, 20000);
                    }
                }, cts.Token);
                var cont4 = cont3.ContinueWith(task =>
                {
                    if (iip)
                    {
                        Thread.Sleep(500);
                        FliperUp(true);
                        status = 0;
                        while (status != 1)
                        {
                            Thread.Sleep(500);
                            ReadFliperUp(out status);
                        }
                        Thread.Sleep(500);
                        FliperUp(false);
                        Thread.Sleep(500);
                        ZAxisMove(zFlipABSPOS);
                        Thread.Sleep(1000);
                        iip = false;
                        iip = InvokeXZInPosCheck("M0", zFlipABSPOS, 20000);
                    }
                }, cts.Token);
                var cont5 = cont4.ContinueWith(task =>
                {
                    if (iip)
                    {
                        SetFliperVAC(false);
                        Thread.Sleep(500);
                        XAxisMove(xFlipABSPOS);
                        Thread.Sleep(1000);
                        iip = false;
                        iip = InvokeXZInPosCheck("M1", xFlipABSPOS, 20000);
                    }
                }, cts.Token);
                var cont6 = cont5.ContinueWith(task =>
                {
                    if (iip)
                    {
                        PickerDown(true);
                        Thread.Sleep(500);
                        SetPickerVAC(true);
                        Thread.Sleep(500);
                        PickerDown(false);
                        Thread.Sleep(500);
                        XAxisHome_h();
                        Thread.Sleep(500);
                        iip = false;
                        iip = InvokeXZInPosCheck("M1", xHomeABSPOS, 20000);
                    }
                }, cts.Token);
                var cont7 = cont6.ContinueWith(task =>
                {
                    if (iip)
                    {
                        Thread.Sleep(500);
                        ZAxisHome_h();
                        Thread.Sleep(500);
                        PickerDown(true);
                        Thread.Sleep(500);
                        SetPickerVAC(false);
                        Thread.Sleep(500);
                        PickerDown(false);
                        Thread.Sleep(500);
                        //OnFlipFilmCompletedEvent(iip);
                        //OnStatusCallbackEvent(true, (int)StatusHWOps.FlipCompleted);
                        iip = InvokeXZInPosCheck("M0", zHomeABSPOS, 10000);
                    }
                }, cts.Token);
                var cont8 = cont7.ContinueWith(task =>
                {
                    if (iip)
                    {
                        Thread.Sleep(500);
                        FliperDown(true);
                        status = 0;
                        while (status != 1)
                        {
                            Thread.Sleep(300);
                            ReadFliperDown(out status);
                        }
                        Thread.Sleep(500);
                        FliperDown(false);
                        Thread.Sleep(300);
                    }
                });

                //OnFlipFilmCompletedEvent(iip);
                //motorDIO.GoUntil("M1", ABS_POS_ACT.RESET, MotorDirections.FWD, 35000);
                if (!ffi.Wait(xzFlipFilmTimeout)) cts.Cancel();
                if (!cont1.Wait(xzFlipFilmTimeout)) cts.Cancel();
                if (!cont2.Wait(xzFlipFilmTimeout)) cts.Cancel();
                if (!cont3.Wait(xzFlipFilmTimeout)) cts.Cancel();
                if (!cont4.Wait(xzFlipFilmTimeout)) cts.Cancel();
                if (!cont5.Wait(xzFlipFilmTimeout)) cts.Cancel();
                if (!cont6.Wait(xzFlipFilmTimeout)) cts.Cancel();
                if (!cont7.Wait(xzFlipFilmTimeout)) cts.Cancel();
                if (cont8.Wait(xzFlipFilmTimeout))                 
                {
                    OnStatusCallbackEvent(true, (int)StatusHWOps.FlipCompleted);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (AggregateException ex)
            {
                return false;
            }
        }
        /*public async Task<bool> FlipFilmAsync()
        {
            int status = 1;
            SetPlatFormVAC(false);
            await Task.Delay(500);
            PickerDown(true);
            await Task.Delay(500);
            SetPickerVAC(true);
            await Task.Factory.StartNew(async delegate
            {
                while (status != 0)
                {
                    ReadVAC(pickerVAC, out status);
                    await Task.Delay(1000);
                }
                PickerDown(false);
                await Task.Delay(1000);
                XAxisMove(FlipABSPOS);

            }, CancellationToken.None, TaskCreationOptions.DenyChildAttach, TaskScheduler.Default).Unwrap();
                        
            string posString;
            int m1ABSPOS=0;
            while(m1ABSPOS!=22.6* MotorDIOParameters.CM2Pulse)
            {
                posString = motorDIO.GetParameter("M1", "ABS_POS");
                m1ABSPOS = Convert.ToInt32(posString, 16);
                m1ABSPOS = MotorDIOParameters.MAX_ABS_POS - m1ABSPOS;
                Thread.Sleep(500);
            }
            PickerDown(true);
            Thread.Sleep(1000);
            SetPickerVAC(false);
            Thread.Sleep(1000);
            PickerDown(false);
            Thread.Sleep(1000);
            motorDIO.GoUntil("M1", ABS_POS_ACT.RESET, MotorDirections.FWD, 35000);
            return true;
        }*/
        public bool CancelOperation()
        {
            try
            {
                if (cts != null) cts.Cancel();                
                return true;
            }
            catch (Exception)
            {
                return false;
            }            
        }
        ///X軸回Home
        ///</summary>
        ///<param>void</param>
        ///<returns>return Boolean True or False</returns>
        public bool XAxisHome()
        {
            try
            {
                motorDIO.GoUntil("M1", ABS_POS_ACT.RESET, MotorDirections.FWD, 250);                
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        ///X軸快速回Home
        ///</summary>
        ///<param>void</param>
        ///<returns>return Boolean True or False</returns>
        public bool XAxisHome_h()
        {
            try
            {
                motorDIO.GoUntil("M1", ABS_POS_ACT.RESET, MotorDirections.FWD, 40000);                
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        ///X軸急停
        ///</summary>
        ///<param>void</param>
        ///<returns>return Boolean True or False</returns>
        public bool XAxisStop()
        {
            try
            {
                motorDIO.HardStop("M1");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        ///Z軸回Home
        ///</summary>
        ///<param>void</param>
        ///<returns>return Boolean True or False</returns>
        public bool ZAxisHome()
        {
            try
            {
                motorDIO.GoUntil("M0", ABS_POS_ACT.RESET, MotorDirections.FWD, 250);                
                return true;
            }
            catch (Exception)
            {
                return false;
            }            
        }
        ///Z軸回Home
        ///</summary>
        ///<param>void</param>
        ///<returns>return Boolean True or False</returns>
        public bool ZAxisHome_h()
        {
            try
            {
                motorDIO.GoUntil("M0", ABS_POS_ACT.RESET, MotorDirections.FWD, 40000);                
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        ///<summary>
        ///Z軸急停
        ///</summary>
        ///<param>void</param>
        ///<returns>return Boolean True or False</returns>
        public bool ZAxisStop()
        {
            try
            {
                motorDIO.HardStop("M0");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        ///<summary>
        ///移動X軸
        ///</summary>        
        ///<param name = "distance">Moving Distance(in cm)</param>
        ///<returns>return Boolean True or False</returns>
        public bool XAxisMove(double distance)
        {
            if (distance < 0 | (distance * MotorDIOParameters.CM2Pulse) > MotorDIOParameters.MAX_ABS_POS) return false;
            try
            {
                motorDIO.Goto("M1", MotorDIOParameters.MAX_ABS_POS - distance * MotorDIOParameters.CM2Pulse);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        ///<summary>
        ///移動Z軸
        ///</summary>        
        ///<param name = "distance">Moving Distance(in cm)</param>
        ///<returns>return Boolean True or False</returns>
        public bool ZAxisMove(double distance)
        {
            if (distance < 0 | (distance * MotorDIOParameters.CM2Pulse) > MotorDIOParameters.MAX_ABS_POS) return false;
            try
            {
                motorDIO.Goto("M0", MotorDIOParameters.MAX_ABS_POS - distance * MotorDIOParameters.CM2Pulse);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        ///<summary>
        ///X、Z軸初始化
        ///</summary>        
        ///<param>void</param>
        ///<returns>return Boolean True or False</returns>
        public bool InitXZAxis()
        {
            try
            {                
                motorDIO.SetParameter("M0", "MAX_SPEED", MotorDIOParameters._max_spd.ToString());
                Thread.Sleep(100);
                motorDIO.SetParameter("M1", "MAX_SPEED", MotorDIOParameters._max_spd.ToString());
                Thread.Sleep(100);
                motorDIO.SetParameter("M0", "MIN_SPEED", MotorDIOParameters._min_spd.ToString());
                Thread.Sleep(100);
                motorDIO.SetParameter("M1", "MIN_SPEED", MotorDIOParameters._min_spd.ToString());
                Thread.Sleep(100);
                motorDIO.SetParameter("M0", "ACC", MotorDIOParameters._acc.ToString());
                Thread.Sleep(100);
                motorDIO.SetParameter("M1", "ACC", MotorDIOParameters._acc.ToString());
                Thread.Sleep(100);
                motorDIO.SetParameter("M0", "DEC", MotorDIOParameters._dec.ToString());
                Thread.Sleep(100);
                motorDIO.SetParameter("M1", "DEC", MotorDIOParameters._dec.ToString());
                Thread.Sleep(100);
                motorDIO.SetParameter("M0", "FS_SPD", MotorDIOParameters._fs_spd.ToString());
                Thread.Sleep(100);
                motorDIO.SetParameter("M1", "FS_SPD", MotorDIOParameters._fs_spd.ToString());
                Thread.Sleep(100);
                motorDIO.SetParameter("M0", "KVAL_ACC", MotorDIOParameters._kval_acc.ToString());
                Thread.Sleep(100);
                motorDIO.SetParameter("M1", "KVAL_ACC", MotorDIOParameters._kval_acc.ToString());
                Thread.Sleep(100);
                motorDIO.SetParameter("M0", "KVAL_DEC", MotorDIOParameters._kval_dec.ToString());
                Thread.Sleep(100);
                motorDIO.SetParameter("M1", "KVAL_DEC", MotorDIOParameters._kval_dec.ToString());
                Thread.Sleep(100);
                motorDIO.SetParameter("M0", "KVAL_RUN", MotorDIOParameters._kval_run.ToString());
                Thread.Sleep(100);
                motorDIO.SetParameter("M1", "KVAL_RUN", MotorDIOParameters._kval_run.ToString());
                Thread.Sleep(100);
                motorDIO.SetParameter("M0", "KVAL_HOLD", MotorDIOParameters._kval_hold.ToString());
                Thread.Sleep(100);
                motorDIO.SetParameter("M1", "KVAL_HOLD", MotorDIOParameters._kval_hold.ToString());
                Thread.Sleep(100);
                motorDIO.SetParameter("M0", "OCD_TH", MotorDIOParameters._ocd_th.ToString());
                Thread.Sleep(100);
                motorDIO.SetParameter("M1", "OCD_TH", MotorDIOParameters._ocd_th.ToString());
                Thread.Sleep(100);
                motorDIO.SetParameter("M0", "STALL_TH", MotorDIOParameters._stall_th.ToString());
                Thread.Sleep(100);
                motorDIO.SetParameter("M1", "STALL_TH", MotorDIOParameters._stall_th.ToString());
                //motorDIO.SetParameter("M0", "STEP_MODE", MotorDIOParameters._step_mode.ToString());
                //motorDIO.SetParameter("M1", "STEP_MODE", MotorDIOParameters._step_mode.ToString());

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        private bool SetBrakeOff(bool actd)
        {
            return  actd ? motorDIO.EnableDO(DigitalOUT.DO8) : motorDIO.DisableDO(DigitalOUT.DO8);
        }
        private bool SetPlatFormVAC(bool actd)
        {
            return actd ? motorDIO.EnableDO(DigitalOUT.DO7) : motorDIO.DisableDO(DigitalOUT.DO7);
        }
        private bool SetPickerVAC(bool actd)
        {
            return actd ? motorDIO.EnableDO(DigitalOUT.DO6) : motorDIO.DisableDO(DigitalOUT.DO6);
        }
        private bool SetFliperVAC(bool actd)
        {
            return actd ? motorDIO.EnableDO(DigitalOUT.DO5) : motorDIO.DisableDO(DigitalOUT.DO5);
        }
        private bool RemoverDown(bool actd)
        {
            return actd ? motorDIO.EnableDO(DigitalOUT.DO4) : motorDIO.DisableDO(DigitalOUT.DO4);
        }
        private bool PickerDown(bool actd)
        {
            return actd ? motorDIO.EnableDO(DigitalOUT.DO3) : motorDIO.DisableDO(DigitalOUT.DO3);
        }
        private bool FliperDown(bool actd)
        {
            return actd ? motorDIO.EnableDO(DigitalOUT.DO2) : motorDIO.DisableDO(DigitalOUT.DO2);
        }
        private bool FliperUp(bool actd)
        {
            return actd ? motorDIO.EnableDO(DigitalOUT.DO1) : motorDIO.DisableDO(DigitalOUT.DO1);
        }
        private bool ReadFliperUp(out int status)
        {
            try
            {
                status = Convert.ToInt32(motorDIO.ReadDI(DigitalIN.DI1));
                return true;
            }
            catch (Exception)
            {
                status = 9;
                return false;
            }
        }
        private bool ReadFliperDown(out int status)
        {
            try
            {
                status = Convert.ToInt32(motorDIO.ReadDI(DigitalIN.DI2));
                return true;
            }
            catch (Exception)
            {
                status = 9;
                return false;
            }
        }
        private bool ReadPickerUp(out int status)
        {
            try
            {
                status = Convert.ToInt32(motorDIO.ReadDI(DigitalIN.DI3));
                return true;
            }
            catch (Exception)
            {
                status = 9;
                return false;
            }
        }
        private bool ReadPickerDown(out int status)
        {
            try
            {
                status = Convert.ToInt32(motorDIO.ReadDI(DigitalIN.DI4));
                return true;
            }
            catch (Exception)
            {
                status = 9;
                return false;
            }
        }
        private bool ReadRemoverLUp(out int status)
        {
            try
            {
                status = Convert.ToInt32(motorDIO.ReadDI(DigitalIN.DI5));
                return true;
            }
            catch (Exception)
            {
                status = 9;
                return false;
            }
        }
        private bool ReadRemoverLDown(out int status)
        {
            try
            {
                status = Convert.ToInt32(motorDIO.ReadDI(DigitalIN.DI6));
                return true;
            }
            catch (Exception)
            {
                status = 9;
                return false;
            }
        }
        private bool ReadRemoverRUp(out int status)
        {
            try
            {
                status = Convert.ToInt32(motorDIO.ReadDI(DigitalIN.DI7));
                return true;
            }
            catch (Exception)
            {
                status = 9;
                return false;
            }
        }
        private bool ReadRemoverRDown(out int status)
        {
            try
            {
                status = Convert.ToInt32(motorDIO.ReadDI(DigitalIN.DI8));
                return true;
            }
            catch (Exception)
            {
                status = 9;
                return false;
            }
        }
        private bool ReadPlatformVAC(out int status)
        {
            try
            {
                status = Convert.ToInt32(motorDIO.ReadDI(DigitalIN.DI11));
                return true;
            }
            catch (Exception)
            {
                status = 9;
                return false;
            }
        }
        private bool ReadPickerVAC(out int status)
        {
            try
            {
                status = Convert.ToInt32(motorDIO.ReadDI(DigitalIN.DI10));
                return true;
            }
            catch (Exception)
            {
                status = 9;
                return false;
            }
        }
        private bool ReadVAC(DigitalIN di, out int status)
        {
            try
            {
                status = Convert.ToInt32(motorDIO.ReadDI(di));
                return true;
            }
            catch (Exception ex)
            {
                status = 9;
                return false;
            }
        }
        private void btnXStop_Click(object sender, EventArgs e)
        {
             XAxisStop();
        }
        private void btnZStop_Click(object sender, EventArgs e)
        {
            ZAxisStop();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectTab = tabControl1.SelectedTab.Name;
        }

        private void trkbrXPosition_MouseUp(object sender, MouseEventArgs e)
        {
            isStopRefresh = false;
            Thread.Sleep(50);
            motorDIO.Goto("M1", MotorDIOParameters.MAX_ABS_POS - trkbrXPosition.Value);
        }

        private void trkbrPlatformPosition_MouseUp(object sender, MouseEventArgs e)
        {
            isStopRefresh = false;
            Thread.Sleep(50);
            motor.MoveTo(RotatePositionType.AbsolutePosition, trkbrPlatformPosition.Value);
        }

        private void trkbrPlatformPosition_MouseDown(object sender, MouseEventArgs e)
        {
            isStopRefresh = true;
        }
        
        private void TrkbrPlatformPosition_Scroll(object sender, EventArgs e)
        {
            labPosition.Text = trkbrPlatformPosition.Value.ToString();
            //motor.MoveTo(RotatePositionType.AbsolutePosition, trkbrPlatformPosition.Value);
        }

        private void TrkbrPlatformSpeed_Scroll(object sender, EventArgs e)
        {
            labSpeed.Text = trkbrPlatformSpeed.Value.ToString();
            //motor.MoveSpeed = trkbrPlatformSpeed.Value;
        }
        
        private void trkbrPlatformSpeed_MouseUp(object sender, MouseEventArgs e)
        {
            isStopRefresh = false;
            Thread.Sleep(50);
            motor.MoveSpeed = trkbrPlatformSpeed.Value;
        }

        private void trkbrPlatformSpeed_MouseDown(object sender, MouseEventArgs e)
        {
            isStopRefresh = true;
        }

        private void BtnPlatformHome_Click(object sender, EventArgs e)
        {
            motor.MoveToHome();
        }

        private void BtnPlatformReset_Click(object sender, EventArgs e)
        {
            motor.Reset();
        }

        
        private void btnXHome_Click(object sender, EventArgs e)
        {
            //motorDIO.ReleaseSW("M1", ABS_POS_ACT.RESET, MotorDirections.FWD);
            motorDIO.GoUntil("M1", ABS_POS_ACT.RESET, MotorDirections.FWD, 51200);
        }

        private void btnZHome_Click(object sender, EventArgs e)
        {
            SetBrakeOff(true);
            Thread.Sleep(300);
            motorDIO.GoUntil("M0", ABS_POS_ACT.RESET, MotorDirections.FWD, 51200);
        }

        private void btnXZReset_Click(object sender, EventArgs e)
        {
            motorDIO.ResetBoard();
            Thread.Sleep(1000);
            //motorDIO.ResetDevice("M0");
            //Thread.Sleep(50);
            //motorDIO.ResetDevice("M1");
            //Thread.Sleep(50);            
            InitXZAxis();
        }
        private void trkbrZPosition_MouseUp(object sender, MouseEventArgs e)
        {
            isStopRefresh = false;
            Thread.Sleep(50);
            motorDIO.Goto("M0", MotorDIOParameters.MAX_ABS_POS - trkbrZPosition.Value);
        }

        private void trkbrXPosition_MouseDown(object sender, MouseEventArgs e)
        {
            isStopRefresh = true;
        }
        private void trkbrZPosition_MouseDown(object sender, MouseEventArgs e)
        {
            isStopRefresh = true;
        }
        private void TrkbrXPosition_Scroll(object sender, EventArgs e)
        {
            labXPosition.Text = ((double)trkbrXPosition.Value / MotorDIOParameters.CM2Pulse).ToString("0.00");
        }
        private void TrkbrZPosition_Scroll(object sender, EventArgs e)
        {
            labZPosition.Text = ((double)trkbrZPosition.Value / MotorDIOParameters.CM2Pulse).ToString("0.00");
        }

        public delegate void BeginInspectionEventHandler(bool isPrecheckOK);
        public event BeginInspectionEventHandler BeginInspectionEvent;
        protected void OnBeginInspectionEvent(bool isPrecheckOK)
        {
            if (BeginInspectionEvent != null)
            {
                BeginInspectionEvent(isPrecheckOK);
            }
        }

        public delegate void PlatformInPosEventHandler(bool isInPos);        
        public event PlatformInPosEventHandler PlatformInPosEvent;
        protected void OnPlatformInPosEvent(bool isInPos)
        {
            if (PlatformInPosEvent != null)
            {
                PlatformInPosEvent(isInPos);
            }
        }

        public delegate void MoveInCompletedEventHandler(bool isCompleted);
        public event MoveInCompletedEventHandler MoveInCompletedEvent;
        protected void OnMoveInCompletedEvent(bool isCompleted)
        {
            if (MoveInCompletedEvent != null)
            {
                MoveInCompletedEvent(isCompleted);
            }
        }

        public delegate void FlipFilmCompletedEventHandler(bool isCompleted);
        public event FlipFilmCompletedEventHandler FlipFilmCompletedEvent;
        
        protected void OnFlipFilmCompletedEvent(bool isCompleted)
        {
            if (FlipFilmCompletedEvent != null)
            {
                FlipFilmCompletedEvent(isCompleted);
            }
        }

        //event No. 0: BeginInspect Command, 1: InPos_BeginGrab, 2: InPos_MoveInCompleted, 3:FlipCompleted
        public delegate void StatusCallbackEventHandler(bool isCompleted, int eventNo);
        public event StatusCallbackEventHandler StatusCallbackEvent;
        protected void OnStatusCallbackEvent(bool isCompleted, int eventNo)
        {
            if (StatusCallbackEvent != null)
            {
                Stopwatch stopwatch = new Stopwatch();
                procedureChecker = eventNo;                 
                stopwatch.Restart();
                StatusCallbackEvent(isCompleted, eventNo);
                stopwatch.Stop();                
                wastedTimeByCallback = stopwatch.Elapsed.ToString();
                stopwatch.Reset();
            }
            else
            {
                procedureChecker = (int)StatusHWOps.None;
            }
        }
    }
    public class MotorDIOParameters
    {
        internal static int _spd;
        internal static int _max_spd =55;
        internal static int _min_spd = 0;
        internal static int _acc = 50;//138;
        internal static int _dec = 50;//138;
        internal static int _fs_spd = 600;//1000;
        internal static int _kval_acc = 50;//150;
        internal static int _kval_run = 150;//200;
        internal static int _kval_dec = 50;
        internal static int _kval_hold = 10;//41;
        internal static int _ocd_th = 15;
        internal static int _stall_th = 127;
        internal static int _step_mode = 7;
        internal static int MAX_ABS_POS = 4194304;//ABS_POS Counter is a 22 bits register
        internal static int CM2Pulse = 25600;//2 Phase Step Motor = 200 (Pulse/Turn)，Microstep = 128;
        public int SPEED { get { return _spd; } }
        public int MAX_SPEED { get { return _max_spd; } set { _max_spd = MAX_SPEED; } }
        public int MIN_SPEED { get { return _min_spd; } set { _min_spd = MIN_SPEED; } }
        public int ACC { get { return _acc; } set { _acc = ACC; } }
        public int DEC { get { return _dec; } set { _dec = DEC; } }
        public int FS_SPD { get { return _fs_spd; } set { _fs_spd = FS_SPD; } }
        public int KVAL_ACC { get { return _kval_acc; } set { _kval_acc = KVAL_ACC; } }
        public int KVAL_RUN { get { return _kval_run; } set { _kval_run = KVAL_RUN; } }
        public int KVAL_DEC { get { return _kval_dec; } set { _kval_dec = KVAL_DEC; } }
        public int KVAL_HOLD { get { return _kval_hold; } set { _kval_hold = KVAL_HOLD; } }
        public int OCD_TH { get { return _ocd_th; } set { _ocd_th = OCD_TH; } }
        public int STALL_TH { get { return _stall_th; } set { _stall_th = STALL_TH; } }
        public int STEP_MODE { get { return _step_mode; } set { _step_mode = STEP_MODE; } }
    }
}
