using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Susi4.APIs;

namespace Susi4.Plugin
{
    public class SusiPlugin : SusiPluginTemplate
    {
        public SusiPlugin(string path)
            : base(path)
        {
            base.myName = "VGA";
            base.myMainInterface = new ctlMain();
        }

        public override void OnCreate()
        {
            if (Host.Config.HideVGA)
            {
                this.myEnable = false;
            }
            else
            {
                ctlMain main = MainInterface as ctlMain;

                if (main.Available == false)
                {
                    this.myEnable = false;
                }
            }
        }
    }
}
