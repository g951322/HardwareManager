using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace HardwareManager
{
    partial class UcDO : UserControl
    {
        public string DONo { get { return labDONo.Text; } set { labDONo.Text = value; } }
        public string DOMnemonic { get { return labDOMnemonic.Text; } set { labDOMnemonic.Text = value; } }
        public bool DOStatus { get { return _doStatus; } set { _doStatus = value; radbtnDOon.Checked = value; } }
        private bool _doStatus { get { return radbtnDOon.Checked; } set { } }
        public UcDO()
        {
            InitializeComponent();
        }
    }
}
