using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HardwareManager
{
    public partial class UcDI : UserControl
    {
        public string DINo { get { return labDINo.Text; } set { labDINo.Text = value; } }
        public string DIMnemonic { get { return labDIMnemonic.Text; } set { labDIMnemonic.Text = value; } }
        public bool DIStatus { set { radbtnDIStatus.Checked = value; } }        
        public UcDI()
        {
            InitializeComponent();
        }
    }
}
