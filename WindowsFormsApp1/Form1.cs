using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HardwareManager;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        UCHardwareManager ucHardwareManager;
        bool moveinCompleted = false;
        public Form1()
        {
            InitializeComponent();
            ucHardwareManager = new UCHardwareManager("COM7", "COM6");
            ucHardwareManager.MoveInCompletedEvent += UcHardwareManager_MoveInCompletedEvent;
            ucHardwareManager.FlipFilmCompletedEvent += UcHardwareManager_FlipFilmCompletedEvent;
            ucHardwareManager.BeginInspectionEvent += UcHardwareManager_BeginInspectionEvent;
            ucHardwareManager.StatusCallbackEvent += UcHardwareManager_StatusCallbackEvent;
        }

        private void UcHardwareManager_StatusCallbackEvent(bool isCompleted, int eventNo)
        {
            bool rtn=false;
            switch (eventNo)
            {
                case (int)UCHardwareManager.StatusHWOps.BeginInspection:                    
                    if (isCompleted)
                        ucHardwareManager.FilmMoveInInvoke();
                    MessageBox.Show(rtn.ToString());
                    break;
                case (int)UCHardwareManager.StatusHWOps.BeginGrab:
                    //if (isCompleted) ucHardwareManager.FilmMoveInInvoke(); 
                    //System.Threading.Thread.Sleep(10000);
                    break;
                case (int)UCHardwareManager.StatusHWOps.MoveInCompleted:
                    if (isCompleted) ucHardwareManager.FlipFilmInvoke();
                    break;
                case (int)UCHardwareManager.StatusHWOps.FlipCompleted:
                    if (isCompleted) ucHardwareManager.PlatformHome();
                    break;
            }
        }

        private void UcHardwareManager_BeginInspectionEvent(bool isPrecheckOK)
        {
            //if (isPrecheckOK) ucHardwareManager.FilmMoveInInvoke();            
        }

        private void UcHardwareManager_FlipFilmCompletedEvent(bool isCompleted)
        {
           //if (isCompleted) ucHardwareManager.PlatformHome();
        }

        private void UcHardwareManager_MoveInCompletedEvent(bool isCompleted)
        {
            //moveinCompleted = isCompleted;
            //if(isCompleted) ucHardwareManager.FlipFilmInvoke();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.tabControl1.TabPages[1].Controls.Add(ucHardwareManager);
            this.tabControl1.Invalidate();
            //this.Controls.Add(ucHardwareManager);            
        }
        private void BtnStart_Click(object sender, EventArgs e)
        {
            //ucHardwareManager.PlatformMove(300, 100);
            //if (ucHardwareManager.IsInPosition(10000))
            //{
            //    ucHardwareManager.PlatformMove(150, 300);
            //    if (ucHardwareManager.IsInPosition(60000)) ucHardwareManager.PlatformHome();
            //}
            ucHardwareManager.BeginInspectionInvoke();
            //ucHardwareManager.FlipFilmInvoke();
            //await ucHardwareManager.FlipFilmAsync();            
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            ucHardwareManager.CancelOperation();
        }
    }
}
