using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Susi4.APIs;

namespace Susi4.Plugin
{
	public partial class ctlMain : UserControl
	{
		class Port
		{
			public UInt32 _detectionID;
			public UInt32 _classificationID;
			public UInt32 _voltageID;
			public UInt32 _currentID;

			public Label _detectionLabel;
			public Label _classificationLabel;
			public Label _voltageLabel;
			public Label _currentLabel;

			public Port(UInt32 detectionID, UInt32 classificationID, UInt32 voltageID, UInt32 currentID,
						Label detection, Label classification, Label voltage, Label current)
			{
				_detectionID = detectionID;
				_classificationID = classificationID;
				_voltageID = voltageID;
				_currentID = currentID;

				_detectionLabel = detection;
				_classificationLabel = classification;
				_voltageLabel = voltage;
				_currentLabel = current;
			}
		}

		private bool _available = false;
		private UInt32 _powerStatus;
		private List<Port> _ports;

		public List<string> _detectionStatus;
		public List<string> _classificationStatus;		       

		public ctlMain()
		{
            UInt32 status, tmp;

			try
			{
				status = SusiLib.SusiLibInitialize();

				if (status != SusiStatus.SUSI_STATUS_SUCCESS &&
					status != SusiStatus.SUSI_STATUS_INITIALIZED)
				{
					return;
				}
			}
			catch
			{
				return;
			}
            
            status = Lib.SusiDeviceGetValue(Lib.LTC4266_ID_INFO_AVAILABLE, out tmp);
            _available = tmp > 0 ? true : false;
			InitializeComponent();

			_powerStatus = 0x00;

			_ports = new List<Port>();
			_ports.Add(new Port(Lib.LTC4266_ID_DETECT_PORT1, Lib.LTC4266_ID_CLASS_PORT1, Lib.LTC4266_ID_VOLTAGE_PORT1, Lib.LTC4266_ID_CURRENT_PORT1,
				                label_detectValue1, label_classValue1, label_voltageValue1, label_currentValue1));
			_ports.Add(new Port(Lib.LTC4266_ID_DETECT_PORT2, Lib.LTC4266_ID_CLASS_PORT2, Lib.LTC4266_ID_VOLTAGE_PORT2, Lib.LTC4266_ID_CURRENT_PORT2,
				                label_detectValue2, label_classValue2, label_voltageValue2, label_currentValue2));
			_ports.Add(new Port(Lib.LTC4266_ID_DETECT_PORT3, Lib.LTC4266_ID_CLASS_PORT3, Lib.LTC4266_ID_VOLTAGE_PORT3, Lib.LTC4266_ID_CURRENT_PORT3,
				                label_detectValue3, label_classValue3, label_voltageValue3, label_currentValue3));
			_ports.Add(new Port(Lib.LTC4266_ID_DETECT_PORT4, Lib.LTC4266_ID_CLASS_PORT4, Lib.LTC4266_ID_VOLTAGE_PORT4, Lib.LTC4266_ID_CURRENT_PORT4,
				                label_detectValue4, label_classValue4, label_voltageValue4, label_currentValue4));

			_detectionStatus = new List<string>()
			{
				"Unknown",
				"PD Error",
				"PD Error",
				"PD Error",
				"Detected Good",
				"PD Error",
				"Detect Open",
				"PD Error"
			};

			_classificationStatus = new List<string>()
			{
				"Class Unknown",
				"Class 1",
				"Class 2",
				"Class 3",
				"Class 4",
				"Error",
				"Class 0",
				"OverCurrent"
			};
		}

		public bool Available
		{
			get
			{
                return _available;
			}
		}

		private void setPowerON(UInt32 data)
		{
			_powerStatus |= data;
		}

		private void setPowerOFF(UInt32 data)
		{
			_powerStatus &= data;
		}

#region RadioButton

		private void radioButton_enable1_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton_enable1.Checked)
			{
				radioButton_disable1.Checked = false;
				setPowerON(0x11);
			}
		}

		private void radioButton_enable2_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton_enable2.Checked)
			{
				radioButton_disable2.Checked = false;
				setPowerON(0x22);
			}
		}

		private void radioButton_enable3_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton_enable3.Checked)
			{
				radioButton_disable3.Checked = false;
				setPowerON(0x44);
			}
		}

		private void radioButton_enable4_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton_enable4.Checked)
			{
				radioButton_disable4.Checked = false;
				setPowerON(0x88);
			}
		}

		private void radioButton_disable1_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton_disable1.Checked)
			{
				radioButton_enable1.Checked = false;
				setPowerOFF(0xEE);
			}
		}

		private void radioButton_disable2_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton_disable2.Checked)
			{
				radioButton_enable2.Checked = false;
				setPowerOFF(0xDD);
			}
		}

		private void radioButton_disable3_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton_disable3.Checked)
			{
				radioButton_enable3.Checked = false;
				setPowerOFF(0xBB);
			}
		}

		private void radioButton_disable4_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton_disable4.Checked)
			{
				radioButton_enable4.Checked = false;
				setPowerOFF(0x77);
			}
		}

#endregion

		private void button_apply_Click(object sender, EventArgs e)
		{
			UInt32 status;

			status = Lib.SusiDeviceSetValue(Lib.LTC4266_ID_POWER_DISABLE, (~_powerStatus & 0xF0));
			if (status != SusiStatus.SUSI_STATUS_SUCCESS)
			{
				MessageBox.Show(String.Format("Disable Port Failed. (0x{0:X8})", status));
			}

			status = Lib.SusiDeviceSetValue(Lib.LTC4266_ID_POWER_ENABLE, _powerStatus);
			if (status != SusiStatus.SUSI_STATUS_SUCCESS)
			{
				MessageBox.Show(String.Format("Enable Port Failed. (0x{0:X8})", status));
			}
		}

		private void LTC4266_Load(object sender, EventArgs e)
		{
			UInt32 status, detena = 0;

			status = Lib.SusiDeviceGetValue(Lib.LTC4266_ID_POWER_ENABLE, out detena);
			if (status != SusiStatus.SUSI_STATUS_SUCCESS)
			{
				MessageBox.Show(String.Format("Cannot Get Initail Info.  (0x{0:X8})", status));
			}

			List<RadioButton> radioButtons = new List<RadioButton>()
			{
				radioButton_enable1, radioButton_enable2, radioButton_enable3, radioButton_enable4,
				radioButton_disable1, radioButton_disable2, radioButton_disable3, radioButton_disable4
			};

			const int RBDISABLEOFFSET = 4;
			for (int i = 0; i < radioButtons.Count / 2; i++)
			{
				bool enable = ((detena >> i) & 0x01) > 0 ? true : false;
				if (enable)
				{
					radioButtons[i].Checked = true;
				}
				else
				{
					radioButtons[i + RBDISABLEOFFSET].Checked = true;
				}
			}
		}

		private void timer_Tick(object sender, EventArgs e)
		{
			UInt32 status, value;

			foreach (var port in _ports)
			{
				status = Lib.SusiDeviceGetValue(port._detectionID, out value);
				port._detectionLabel.Text = _detectionStatus[(int)value];

				status = Lib.SusiDeviceGetValue(port._classificationID, out value);
				port._classificationLabel.Text = _classificationStatus[(int)value];

				status = Lib.SusiDeviceGetValue(port._voltageID, out value);
				port._voltageLabel.Text = String.Format("{0:00.00} V", (double)value / 1000);

				status = Lib.SusiDeviceGetValue(port._currentID, out value);
				port._currentLabel.Text = String.Format("{0:00.00} mA", (double)value / 1000);
			}
		}
	}
}
