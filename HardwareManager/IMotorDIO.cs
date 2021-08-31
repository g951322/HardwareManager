using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace HardwareManager
{

    ///<summary>
    ///Digital Output Mnemonic
    /// </summary>
    public enum DigitalOUT
    {
        DO1 = 1,
        DO2,
        DO3,
        DO4,
        DO5,
        DO6,
        DO7,
        DO8,
        DO9,
        DO10,
        DO11,
        DO12,
        DO13,
        DO14,
        DO15,
        DO16,
        DOALL
    }
    ///<summary>
    ///Digital Input Mnemonic
    /// </summary>
    public enum DigitalIN
    {
        DI1 = 1,
        DI2,
        DI3,
        DI4,
        DI5,
        DI6,
        DI7,
        DI8,
        DI9,
        DI10,
        DI11,
        DI12,
        DI13,
        DI14,
        DI15,
        DI16,
        DIALL
    }
    /// <summary>
    /// Motor directions 
    /// </summary>
    public enum MotorDirections
    {
        /// <summary>
        /// 順時針方向旋轉
        /// </summary>
        FWD = 0,

        /// <summary>
        /// 逆時針方向旋轉
        /// </summary>
        REV
    }

    /// <summary>
    ///  Action about ABS_POS [ACT] 
    /// </summary>
    public enum ABS_POS_ACT
    {
        /// <summary>
        /// ABS_POS register is reset 
        /// </summary>
        RESET = 0,

        /// <summary>
        /// ABS_POS register is copied into the MARK register 
        /// </summary>
        CPY
    }    
    /// <summary>
    /// 程式說明: L6470 馬達驅動IC控制介面
    /// 建立日期: 2018-06-11
    /// 修改記錄:    /// 
    /// </summary>
    interface IMotorDIO
    {
        #region DIDO控制
        /// <summary>
        ///Enable輸出埠
        /// </summary>
        bool EnableDO(DigitalOUT digitalOutput);
        /// <summary>
        /// Disable輸出埠
        /// </summary>
        bool DisableDO(DigitalOUT digitalOutput);
        /// <summary>
        ///讀取輸入埠
        /// </summary>
        string ReadDI(DigitalIN digitalInput);
        /// <summary>
        ///重置硬體
        /// </summary>
        void ResetBoard();
        #endregion
        #region 連線控制

        /// <summary>
        /// 開啟RS232連線
        /// </summary>
        bool OpenComPort();

        /// <summary>
        /// 關閉RS232連線
        /// </summary>
        void CloseComPort();

        /// <summary>
        /// 判斷RS232是否連線
        /// </summary>
        bool IsComPortOpen { get; }
        #endregion

        #region 參數控制        
        /// <summary>
        /// 讀取參數值
        /// </summary>
        /// <param name="motorID"></param>
        /// <param name="paramName"></param>
        /// <returns></returns>
        string GetParameter(string motorID, string paramName);

        /// <summary>
        /// 設定參數值
        /// </summary>
        /// <param name="motorID"></param>
        /// <param name="paramName"></param>
        /// <param name="value"></param>
        void SetParameter(string motorID, string paramName, string value);

        /// <summary>
        /// 儲存參數
        /// </summary>
        void SaveParameter();

        /// <summary>
        /// 取得馬達裝置指令回傳結果
        /// </summary>
        string ResultMessage { get; }

        /// <summary>
        /// 執行馬達裝置指令
        /// </summary>
        /// <param name="command"></param>
        void ExecuteCommand(string command);
        #endregion

        #region 指令控制

        /// <summary>
        /// Sets the target speed and the motor direction
        /// </summary>
        /// <param name="motorID">馬達識別</param>
        /// <param name="direction">旋轉方向</param>
        ///  <param name="speed">速度</param>
        void Run(string motorID, MotorDirections direction, double speed);
        void Run(string motorID, string direction, double speed);

        /// <summary>
        /// Puts the device in Step-clock mode and imposes DIR direction
        /// </summary>
        /// <param name="motorID">馬達識別</param>
        /// <param name="direction">旋轉方向</param>
        void StepClock(string motorID, MotorDirections direction);

        /// <summary>
        /// Makes N_STEP (micro)steps in DIR direction (not performable when motor is running)
        /// </summary>
        /// <param name="motorID">馬達識別</param>
        /// <param name="direction">旋轉方向</param>
        ///  <param name="steps">距離</param>
        void Move(string motorID, MotorDirections direction, double steps);
        void Move(string motorID, string direction, double steps);

        /// <summary>
        /// Brings motor into ABS_POS position (minimum path)
        /// </summary>
        /// <param name="motorID">馬達識別</param>
        /// <param name="absPos">絕對位置</param>
        void Goto(string motorID, double absPos);

        /// <summary>
        /// Makes N_STEP (micro)steps in DIR direction (not performable when motor is running)
        /// </summary>
        /// <param name="motorID">馬達識別</param>
        /// <param name="direction">旋轉方向</param>
        /// <param name="absPos">絕對位置</param>
        void GotoDir(string motorID, MotorDirections direction, double absPos);
        void GotoDir(string motorID, string direction, double absPos);

        /// <summary>
        /// Performs a motion in DIR direction with speed SPD until SW is closed, 
        /// the ACT action is executed then a SoftStop takes place 
        /// </summary>
        /// <param name="motorID">馬達識別</param>
        /// <param name="action">到位動作</param>
        /// <param name="direction">旋轉方向</param>
        /// <param name="speed">速度</param>
        void GoUntil(string motorID, ABS_POS_ACT action, MotorDirections direction, double speed);
        void GoUntil(string motorID, string action, string direction, double speed);

        /// <summary>
        /// Performs a motion in DIR direction at minimum speed until the SW is released (open),
        /// the ACT action is executed then a HardStop takes place
        /// </summary>
        /// <param name="motorID">馬達識別</param>
        /// <param name="action">到位動作</param>
        /// <param name="direction">速度</param>
        void ReleaseSW(string motorID, ABS_POS_ACT action, MotorDirections direction);
        void ReleaseSW(string motorID, string action, string direction);

        /// <summary>
        /// Brings the motor into HOME position
        /// </summary>
        /// <param name="motorID">馬達識別</param>
        void GoHome(string motorID);

        /// <summary>
        /// Resets the ABS_POS register (set HOME position) 
        /// </summary>
        /// <param name="motorID">馬達識別</param>
        void ResetPos(string motorID);

        /// <summary>
        /// Device is reset to power-up conditions 
        /// </summary>
        /// <param name="motorID">馬達識別</param>
        void ResetDevice(string motorID);

        /// <summary>
        /// Stops motor with a deceleration phase 
        /// </summary>
        /// <param name="motorID">馬達識別</param>
        void SoftStop(string motorID);

        /// <summary>
        /// Stops motor immediately 
        /// </summary>
        /// <param name="motorID">馬達識別</param>
        void HardStop(string motorID);

        /// <summary>
        /// Puts the bridges in high impedance status after a deceleration phase 
        /// </summary>
        /// <param name="motorID">馬達識別</param>
        void SoftHIZ(string motorID);

        /// <summary>
        /// Puts the bridges in high impedance status immediately  
        /// </summary>
        /// <param name="motorID">馬達識別</param>
        void HardHIZ(string motorID);
        #endregion
    }
}
