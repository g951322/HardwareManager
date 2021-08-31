using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace HardwareManager
{
    /// <summary>
    /// 旋轉方向
    /// </summary>
    public enum RotateDirectionType
    {
        /// <summary>
        /// 順時針方向旋轉
        /// </summary>
        ForwardRotate = 0,

        /// <summary>
        /// 逆時針方向旋轉
        /// </summary>
        ReverseRotate
    }

    /// <summary>
    /// 旋轉位置
    /// </summary>
    public enum RotatePositionType
    {
        /// <summary>
        /// 絕對位置
        /// </summary>
        AbsolutePosition = 0,

        /// <summary>
        /// 相對位置
        /// </summary>
        RelativePosition
    }
    interface IMotor
    {
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

        /// <summary>
        /// 重新啟動馬達控制
        /// </summary>
        void Reset();

        /// <summary>
        /// 開啟馬達控制
        /// </summary>
        void ServoOn();

        /// <summary>
        /// 關閉馬達控制
        /// </summary>
        void ServoOff();

        #endregion

        #region 移動控制

        /// <summary>
        /// 移動至原點
        /// </summary>
        void MoveToHome();

        /// <summary>
        /// 移動位置
        /// </summary>
        /// <param name="position">旋轉位置</param>
        /// <param name="value">移動數值</param>
        void MoveTo(RotatePositionType position, double value);

        /// <summary>
        /// 連續旋轉 (JOG)
        /// </summary>
        /// <param name="direction">旋轉方向</param>
        void ContinuousRotation(RotateDirectionType direction);

        /// <summary>
        /// 停止連續旋轉 (JOG)
        /// </summary>
        void ContinuousRotationStop();

        /// <summary>
        /// 暫停旋轉
        /// </summary>
        void Pause();

        /// <summary>
        /// 取消暫停旋轉
        /// </summary>
        void ReDo();

        /// <summary>
        /// 緊急停止
        /// </summary>
        void Stop();

        /// <summary>
        /// 回機械原點
        /// </summary>
        void ResetMechanism();

        #endregion

        #region 參數控制

        /// <summary>
        /// 讀取參數值
        /// </summary>
        /// <param name="paramName"></param>
        /// <returns></returns>
        string GetParameter(string paramName);

        /// <summary>
        /// 設定參數值
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="value"></param>
        void SetParameter(string paramName, string value);

        /// <summary>
        /// 儲存參數
        /// </summary>
        void SaveParameter();

        #endregion

        #region 速度控制

        /// <summary>
        /// 加速度
        /// </summary>
        double AccelerationSpeed { get; set; }

        /// <summary>
        /// 移動速度
        /// </summary>
        double MoveSpeed { get; set; }

        /// <summary>
        /// 出原點的速度
        /// </summary>
        double BeginSpeed { get; set; }

        /// <summary>
        /// 回原點的速度
        /// </summary>
        double BackSpeed { get; set; }

        /// <summary>
        /// 連續旋轉速度 (JOG)
        /// </summary>
        double ContinuousRotationSpeed { get; set; }

        /// <summary>
        /// 目前旋轉速度
        /// </summary>
        double CurrentRotateSpeed { get; }

        #endregion

        #region 狀態檢測

        /// <summary>
        /// 判斷馬達是否啟動
        /// </summary>
        bool IsServoOn { get; }

        /// <summary>
        /// 判斷馬達是否正在運轉
        /// </summary>
        bool IsRunning { get; }

        /// <summary>
        /// 判斷是否發生異常
        /// </summary>
        bool IsError { get; }

        /// <summary>
        /// 判斷是否旋轉已到位
        /// </summary>
        bool IsRotateReach { get; }

        /// <summary>
        /// 判斷是否連續旋轉 (JOG)
        /// </summary>
        bool IsContinuousRotation { get; }

        /// <summary>
        /// 判斷是否旋轉暫停
        /// </summary>
        bool IsPause { get; }

        /// <summary>
        /// 取得錯誤訊息
        /// </summary>
        string ErrorMessage { get; }

        #endregion

        #region 指令控制
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

        #region 位置與方向控制

        /// <summary>
        /// 目前位置 (Pulse)
        /// </summary>
        /// <returns></returns>
        double CurrentPosition { get; set; }

        /// <summary>
        /// 目前位置 (Millimeter)
        /// </summary>
        double CurrentMillimeter { get; }

        /// <summary>
        /// 一毫米幾個脈波
        /// </summary>
		double OneMillimetrePulse { get; set; }

        /// <summary>
        /// 旋轉方向
        /// </summary>
        RotateDirectionType Direction { get; set; }

        /// <summary>
        /// 最後一次執行的旋轉方向
        /// </summary>
        RotateDirectionType LastRotateDirection { get; }

        #endregion
    }
}
