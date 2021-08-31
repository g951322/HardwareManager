using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Susi4.APIs;

namespace Susi4.Plugin
{
    public partial class ctlMain : UserControl
    {
        class DeviceInfo
        {
            public UInt32 ID;
            public UInt32 SupportInput;
            public UInt32 SupportOutput;

            public DeviceInfo(UInt32 DeviceID)
            {
                ID = DeviceID;
                SupportInput = 0;
                SupportOutput = 0;
            }
        }

        class DevPinInfo
        {
            public UInt32 ID;

            private string _Name = "";
            public string Name
            {
                get { return _Name; }
            }

            override public string ToString()
            {
                return String.Format("{0} ({1})", ID, Name);
            }

            public DevPinInfo(UInt32 DeviceID)
            {
                ID = DeviceID;

                UInt32 Length = 32;
                StringBuilder sb = new StringBuilder((int)Length);
                if (SusiBoard.SusiBoardGetStringA(SusiBoard.SUSI_ID_MAPPING_GET_NAME_GPIO(ID), sb, ref Length) == SusiStatus.SUSI_STATUS_SUCCESS)
                {
                    _Name = sb.ToString();
                }
            }
        }

        const int MAX_BANK_NUM = 4;

        List<DeviceInfo> DevList = new List<DeviceInfo>();
        DeviceInfo Dev = null;
        List<DevPinInfo> DevPinList = new List<DevPinInfo>();
        DevPinInfo DevPin = null;

        public bool Available
        {
            get { return (DevList.Count > 0); }
        }

        public ctlMain()
        {
            try
            {
                UInt32 Status = SusiLib.SusiLibInitialize();

                if (Status != SusiStatus.SUSI_STATUS_SUCCESS && Status != SusiStatus.SUSI_STATUS_INITIALIZED)
                    return;
            }
            catch
            {
                return;
            }

            InitializeComponent();
            InitializeGPIO();
            InitializePins();
        }

        private void PageGPIO_Load(object sender, EventArgs e)
        {
            radioButton_SinglePin.Checked = true;
        }

        private void InitializeGPIO()
        {
            UInt32 Status;

            for (int i = 0; i < MAX_BANK_NUM; i++)
            {
                DeviceInfo info = new DeviceInfo(SusiGPIO.SUSI_ID_GPIO_BANK((UInt32)i));

                Status = SusiGPIO.SusiGPIOGetCaps(info.ID, SusiGPIO.SUSI_ID_GPIO_INPUT_SUPPORT, out info.SupportInput);
                if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                    continue;

                Status = SusiGPIO.SusiGPIOGetCaps(info.ID, SusiGPIO.SUSI_ID_GPIO_OUTPUT_SUPPORT, out info.SupportOutput);
                if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                    continue;

                DevList.Add(info);
                comboBox_BankNum.Items.Add(i.ToString());
            }

            if (DevList.Count > 0)
            {
                comboBox_BankNum.SelectedIndex = 0;
            }
        }

        private void InitializePins()
        {
            StringBuilder sb = new StringBuilder(32);
            UInt32 mask;

            for (int i = 0; i < DevList.Count; i++)
            {
                // 32 pins per bank
                for (int j = 0; j < 32; j++)
                {
                    mask = (UInt32)(1 << j);
                    if ((DevList[i].SupportInput & mask) > 0 || (DevList[i].SupportOutput & mask) > 0)
                    {
                        DevPinInfo pinInfo = new DevPinInfo((UInt32)((i << 5) + j));
                        DevPinList.Add(pinInfo);

                        comboBox_PinNum.Items.Add(pinInfo.ToString());
                    }
                }
            }

            if (DevList.Count > 0)
            {
                comboBox_PinNum.SelectedIndex = 0;
            }
        }

        private void ShowSupportedInfo()
        {
            if (radioButton_SinglePin.Checked)
            {
                if ((DevList[(int)(DevPin.ID >> 5)].SupportInput & (UInt32)(1 << (int)(DevPin.ID & 0x1F))) > 0)
                    label_Inputs.Text = "1";
                else
                    label_Inputs.Text = "0";

                if ((DevList[(int)(DevPin.ID >> 5)].SupportOutput & (UInt32)(1 << (int)(DevPin.ID & 0x1F))) > 0)
                    label_Outputs.Text = "1";
                else
                    label_Outputs.Text = "0";
            }
            else
            {
                label_Inputs.Text = Convert.ToString(Dev.SupportInput, 2).PadLeft(32, '0');
                label_Outputs.Text = Convert.ToString(Dev.SupportOutput, 2).PadLeft(32, '0');
            }
        }

        private void InputLimitProtect()
        {
            UInt32 mask = (Dev.SupportInput | Dev.SupportOutput) & 0xff;
            bool isZero = (mask == 0);
            textBox_Mask0.Enabled = !isZero;
            textBox_Mask0.Text = Convert.ToString(mask, 2).PadLeft(8, '0');
            textBox_Dir0.Enabled = !isZero;
            textBox_Level0.Enabled = !isZero;

            mask = ((Dev.SupportInput | Dev.SupportOutput) >> 8) & 0xff;
            isZero = (mask == 0);
            textBox_Mask1.Enabled = !isZero;
            textBox_Mask1.Text = Convert.ToString(mask, 2).PadLeft(8, '0');
            textBox_Dir1.Enabled = !isZero;
            textBox_Level1.Enabled = !isZero;

            mask = ((Dev.SupportInput | Dev.SupportOutput) >> 16) & 0xff;
            isZero = (mask == 0);
            textBox_Mask2.Enabled = !isZero;
            textBox_Mask2.Text = Convert.ToString(mask, 2).PadLeft(8, '0');
            textBox_Dir2.Enabled = !isZero;
            textBox_Level2.Enabled = !isZero;

            mask = ((Dev.SupportInput | Dev.SupportOutput) >> 24) & 0xff;
            isZero = (mask == 0);
            textBox_Mask3.Enabled = !isZero;
            textBox_Mask3.Text = Convert.ToString(mask, 2).PadLeft(8, '0');
            textBox_Dir3.Enabled = !isZero;
            textBox_Level3.Enabled = !isZero;

        }

        private void radioButton_SinglePin_CheckedChanged(object sender, EventArgs e)
        {
            comboBox_PinNum.Enabled = radioButton_SinglePin.Checked;

            if (radioButton_SinglePin.Checked)
            {
                textBox_Level3.MaxLength = 1;
                textBox_Level3.Text = "0";

                textBox_Dir3.MaxLength = 1;
                textBox_Dir3.Text = "0";

                textBox_Mask3.ReadOnly = true;
                textBox_Mask3.Text = "1";
            }
            else
            {
                textBox_Level3.MaxLength = 8;
                textBox_Level3.Text = "00000000";

                textBox_Dir3.MaxLength = 8;
                textBox_Dir3.Text = "00000000";

                textBox_Mask3.ReadOnly = false;
                textBox_Mask3.Text = "00000000";
            }

            ShowSupportedInfo();
        }

        private void radioButton_MultiPin_CheckedChanged(object sender, EventArgs e)
        {
            bool isMulti = radioButton_MultiPin.Checked;

            textBox_Level2.Visible = isMulti;
            textBox_Level1.Visible = isMulti;
            textBox_Level0.Visible = isMulti;

            textBox_Mask2.Visible = isMulti;
            textBox_Mask1.Visible = isMulti;
            textBox_Mask0.Visible = isMulti;

            textBox_Dir2.Visible = isMulti;
            textBox_Dir1.Visible = isMulti;
            textBox_Dir0.Visible = isMulti;

            comboBox_BankNum.Enabled = isMulti;

            label_Bit0.Visible = isMulti;
            label_Bit8.Visible = isMulti;
            label_Bit16.Visible = isMulti;
            label_Bit24.Visible = isMulti;
            label_Bit31.Visible = isMulti;

            if (radioButton_MultiPin.Checked)
                InputLimitProtect();
            else
            {
                textBox_Level3.Enabled = true;
                textBox_Mask3.Enabled = true;
                textBox_Dir3.Enabled = true;
            }
                
        }

        private void comboBox_BankNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dev = DevList[comboBox_BankNum.SelectedIndex];
            ShowSupportedInfo();
            InputLimitProtect();
        }

        private void comboBox_PinNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            DevPin = DevPinList[comboBox_PinNum.SelectedIndex];
            ShowSupportedInfo();
        }

        private void textBox_Bin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar) || e.KeyChar == '0' || e.KeyChar == '1')
                return;

            e.Handled = true;
        }

        private void textBox_Bin_Leave(object sender, EventArgs e)
        {
            TextBox current = sender as TextBox;

            if (radioButton_SinglePin.Checked)
            {
                if (current.Text.Length < 1)
                    current.Text = "0";
            }
            else
            {
                UInt32 bin = 0;

                if (current.Text.Length > 0)
                {
                    bin = Convert.ToUInt32(current.Text, 2);
                }

                current.Text = Convert.ToString(bin, 2).PadLeft(8, '0');
            }
        }

        private UInt32 GetID()
        {
            if (radioButton_SinglePin.Checked)
                return DevPin.ID;
            else
                return Dev.ID;
        }

        private UInt32 GetMask()
        {
            if (radioButton_SinglePin.Checked)
                return 1;
            else
            {
                UInt32 mask = Convert.ToUInt32(textBox_Mask0.Text, 2);
                mask += Convert.ToUInt32(textBox_Mask1.Text, 2) << 8;
                mask += Convert.ToUInt32(textBox_Mask2.Text, 2) << 16;
                mask += Convert.ToUInt32(textBox_Mask3.Text, 2) << 24;
                return mask;
            }
        }

        private void button_GetLevel_Click(object sender, EventArgs e)
        {
            UInt32 Status;
            UInt32 Value;

            Status = SusiGPIO.SusiGPIOGetLevel(GetID(), GetMask(), out Value);
            if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
            {
                if (radioButton_SinglePin.Checked)
                {
                    textBox_Level3.Text = Value.ToString();
                }
                else
                {
                    textBox_Level3.Text = Convert.ToString((Value >> 24) & 0xFF, 2).PadLeft(8, '0');
                    textBox_Level2.Text = Convert.ToString((Value >> 16) & 0xFF, 2).PadLeft(8, '0');
                    textBox_Level1.Text = Convert.ToString((Value >> 8) & 0xFF, 2).PadLeft(8, '0');
                    textBox_Level0.Text = Convert.ToString(Value & 0xFF, 2).PadLeft(8, '0');
                }
            }
            else
                MessageBox.Show(String.Format("SusiGPIOGetLevel() failed. (0x{0:X8})", Status));
        }

        private void button_SetLevel_Click(object sender, EventArgs e)
        {
            UInt32 Status;
            UInt32 Value = Convert.ToUInt32(textBox_Level3.Text, 2);

            if (radioButton_MultiPin.Checked)
            {
                Value <<= 24;
                Value += Convert.ToUInt32(textBox_Level2.Text, 2) << 16;
                Value += Convert.ToUInt32(textBox_Level1.Text, 2) << 8;
                Value += Convert.ToUInt32(textBox_Level0.Text, 2);
            }

            Status = SusiGPIO.SusiGPIOSetLevel(GetID(), GetMask(), Value);
            if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                MessageBox.Show(String.Format("SusiGPIOSetLevel() failed. (0x{0:X8})", Status));
        }

        private void button_GetDir_Click(object sender, EventArgs e)
        {
            UInt32 Status;
            UInt32 Value;

            Status = SusiGPIO.SusiGPIOGetDirection(GetID(), GetMask(), out Value);
            if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
            {
                if (radioButton_SinglePin.Checked)
                {
                    textBox_Dir3.Text = Value.ToString();
                }
                else
                {
                    textBox_Dir3.Text = Convert.ToString((Value >> 24) & 0xFF, 2).PadLeft(8, '0');
                    textBox_Dir2.Text = Convert.ToString((Value >> 16) & 0xFF, 2).PadLeft(8, '0');
                    textBox_Dir1.Text = Convert.ToString((Value >> 8) & 0xFF, 2).PadLeft(8, '0');
                    textBox_Dir0.Text = Convert.ToString(Value & 0xFF, 2).PadLeft(8, '0');
                }
            }
            else
                MessageBox.Show(String.Format("SusiGPIOGetDirection() failed. (0x{0:X8})", Status));
        }

        private void button_SetDir_Click(object sender, EventArgs e)
        {
            UInt32 Status;
            UInt32 Value = Convert.ToUInt32(textBox_Dir3.Text, 2);

            if (radioButton_MultiPin.Checked)
            {
                Value <<= 24;
                Value += Convert.ToUInt32(textBox_Dir2.Text, 2) << 16;
                Value += Convert.ToUInt32(textBox_Dir1.Text, 2) << 8;
                Value += Convert.ToUInt32(textBox_Dir0.Text, 2);
            }

            Status = SusiGPIO.SusiGPIOSetDirection(GetID(), GetMask(), Value);
            if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                MessageBox.Show(String.Format("SusiGPIOSetDirection() failed. (0x{0:X8})", Status));
        }
    }
}
