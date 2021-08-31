namespace Susi4.Plugin
{
    partial class ctlMain
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox_Info = new System.Windows.Forms.GroupBox();
            this.button_SetLevel = new System.Windows.Forms.Button();
            this.button_SetDir = new System.Windows.Forms.Button();
            this.button_GetLevel = new System.Windows.Forms.Button();
            this.button_GetDir = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label_Bit31 = new System.Windows.Forms.Label();
            this.label_Bit24 = new System.Windows.Forms.Label();
            this.label_Bit16 = new System.Windows.Forms.Label();
            this.label_Bit8 = new System.Windows.Forms.Label();
            this.label_Bit0 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_Level0 = new System.Windows.Forms.TextBox();
            this.textBox_Mask0 = new System.Windows.Forms.TextBox();
            this.textBox_Dir0 = new System.Windows.Forms.TextBox();
            this.textBox_Mask1 = new System.Windows.Forms.TextBox();
            this.textBox_Level1 = new System.Windows.Forms.TextBox();
            this.textBox_Dir1 = new System.Windows.Forms.TextBox();
            this.textBox_Mask2 = new System.Windows.Forms.TextBox();
            this.textBox_Level2 = new System.Windows.Forms.TextBox();
            this.textBox_Dir2 = new System.Windows.Forms.TextBox();
            this.textBox_Mask3 = new System.Windows.Forms.TextBox();
            this.textBox_Level3 = new System.Windows.Forms.TextBox();
            this.textBox_Dir3 = new System.Windows.Forms.TextBox();
            this.comboBox_PinNum = new System.Windows.Forms.ComboBox();
            this.groupBox_PinSelection = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButton_MultiPin = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label_Outputs = new System.Windows.Forms.Label();
            this.label_Inputs = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_BankNum = new System.Windows.Forms.ComboBox();
            this.radioButton_SinglePin = new System.Windows.Forms.RadioButton();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox_Info.SuspendLayout();
            this.groupBox_PinSelection.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_Info
            // 
            this.groupBox_Info.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_Info.Controls.Add(this.button_SetLevel);
            this.groupBox_Info.Controls.Add(this.button_SetDir);
            this.groupBox_Info.Controls.Add(this.button_GetLevel);
            this.groupBox_Info.Controls.Add(this.button_GetDir);
            this.groupBox_Info.Controls.Add(this.label6);
            this.groupBox_Info.Controls.Add(this.label_Bit31);
            this.groupBox_Info.Controls.Add(this.label_Bit24);
            this.groupBox_Info.Controls.Add(this.label_Bit16);
            this.groupBox_Info.Controls.Add(this.label_Bit8);
            this.groupBox_Info.Controls.Add(this.label_Bit0);
            this.groupBox_Info.Controls.Add(this.label7);
            this.groupBox_Info.Controls.Add(this.label5);
            this.groupBox_Info.Controls.Add(this.textBox_Level0);
            this.groupBox_Info.Controls.Add(this.textBox_Mask0);
            this.groupBox_Info.Controls.Add(this.textBox_Dir0);
            this.groupBox_Info.Controls.Add(this.textBox_Mask1);
            this.groupBox_Info.Controls.Add(this.textBox_Level1);
            this.groupBox_Info.Controls.Add(this.textBox_Dir1);
            this.groupBox_Info.Controls.Add(this.textBox_Mask2);
            this.groupBox_Info.Controls.Add(this.textBox_Level2);
            this.groupBox_Info.Controls.Add(this.textBox_Dir2);
            this.groupBox_Info.Controls.Add(this.textBox_Mask3);
            this.groupBox_Info.Controls.Add(this.textBox_Level3);
            this.groupBox_Info.Controls.Add(this.textBox_Dir3);
            this.groupBox_Info.Location = new System.Drawing.Point(16, 124);
            this.groupBox_Info.MaximumSize = new System.Drawing.Size(600, 250);
            this.groupBox_Info.MinimumSize = new System.Drawing.Size(525, 0);
            this.groupBox_Info.Name = "groupBox_Info";
            this.groupBox_Info.Size = new System.Drawing.Size(600, 192);
            this.groupBox_Info.TabIndex = 5;
            this.groupBox_Info.TabStop = false;
            this.groupBox_Info.Text = "Information";
            // 
            // button_SetLevel
            // 
            this.button_SetLevel.Location = new System.Drawing.Point(106, 155);
            this.button_SetLevel.Name = "button_SetLevel";
            this.button_SetLevel.Size = new System.Drawing.Size(57, 23);
            this.button_SetLevel.TabIndex = 4;
            this.button_SetLevel.Text = "Set";
            this.button_SetLevel.UseVisualStyleBackColor = true;
            this.button_SetLevel.Click += new System.EventHandler(this.button_SetLevel_Click);
            // 
            // button_SetDir
            // 
            this.button_SetDir.Location = new System.Drawing.Point(106, 89);
            this.button_SetDir.Name = "button_SetDir";
            this.button_SetDir.Size = new System.Drawing.Size(57, 23);
            this.button_SetDir.TabIndex = 4;
            this.button_SetDir.Text = "Set";
            this.button_SetDir.UseVisualStyleBackColor = true;
            this.button_SetDir.Click += new System.EventHandler(this.button_SetDir_Click);
            // 
            // button_GetLevel
            // 
            this.button_GetLevel.Location = new System.Drawing.Point(169, 155);
            this.button_GetLevel.Name = "button_GetLevel";
            this.button_GetLevel.Size = new System.Drawing.Size(57, 23);
            this.button_GetLevel.TabIndex = 4;
            this.button_GetLevel.Text = "Get";
            this.button_GetLevel.UseVisualStyleBackColor = true;
            this.button_GetLevel.Click += new System.EventHandler(this.button_GetLevel_Click);
            // 
            // button_GetDir
            // 
            this.button_GetDir.Location = new System.Drawing.Point(169, 89);
            this.button_GetDir.Name = "button_GetDir";
            this.button_GetDir.Size = new System.Drawing.Size(57, 23);
            this.button_GetDir.TabIndex = 4;
            this.button_GetDir.Text = "Get";
            this.button_GetDir.UseVisualStyleBackColor = true;
            this.button_GetDir.Click += new System.EventHandler(this.button_GetDir_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 12);
            this.label6.TabIndex = 3;
            this.label6.Text = "Level:";
            this.toolTip.SetToolTip(this.label6, "1: High voltage level\r\n0: Low voltage level");
            // 
            // label_Bit31
            // 
            this.label_Bit31.AutoSize = true;
            this.label_Bit31.Location = new System.Drawing.Point(104, 18);
            this.label_Bit31.Name = "label_Bit31";
            this.label_Bit31.Size = new System.Drawing.Size(17, 12);
            this.label_Bit31.TabIndex = 3;
            this.label_Bit31.Text = "31";
            // 
            // label_Bit24
            // 
            this.label_Bit24.AutoSize = true;
            this.label_Bit24.Location = new System.Drawing.Point(152, 18);
            this.label_Bit24.Name = "label_Bit24";
            this.label_Bit24.Size = new System.Drawing.Size(17, 12);
            this.label_Bit24.TabIndex = 3;
            this.label_Bit24.Text = "24";
            // 
            // label_Bit16
            // 
            this.label_Bit16.AutoSize = true;
            this.label_Bit16.Location = new System.Drawing.Point(221, 18);
            this.label_Bit16.Name = "label_Bit16";
            this.label_Bit16.Size = new System.Drawing.Size(17, 12);
            this.label_Bit16.TabIndex = 3;
            this.label_Bit16.Text = "16";
            // 
            // label_Bit8
            // 
            this.label_Bit8.AutoSize = true;
            this.label_Bit8.Location = new System.Drawing.Point(291, 18);
            this.label_Bit8.Name = "label_Bit8";
            this.label_Bit8.Size = new System.Drawing.Size(11, 12);
            this.label_Bit8.TabIndex = 3;
            this.label_Bit8.Text = "8";
            // 
            // label_Bit0
            // 
            this.label_Bit0.AutoSize = true;
            this.label_Bit0.Location = new System.Drawing.Point(360, 18);
            this.label_Bit0.Name = "label_Bit0";
            this.label_Bit0.Size = new System.Drawing.Size(11, 12);
            this.label_Bit0.TabIndex = 3;
            this.label_Bit0.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 12);
            this.label7.TabIndex = 3;
            this.label7.Text = "Mask:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "Direction:";
            this.toolTip.SetToolTip(this.label5, "1: Input direction\r\n0: Output direction");
            // 
            // textBox_Level0
            // 
            this.textBox_Level0.Location = new System.Drawing.Point(307, 127);
            this.textBox_Level0.MaxLength = 8;
            this.textBox_Level0.Name = "textBox_Level0";
            this.textBox_Level0.Size = new System.Drawing.Size(65, 22);
            this.textBox_Level0.TabIndex = 0;
            this.textBox_Level0.Text = "00000000";
            this.toolTip.SetToolTip(this.textBox_Level0, "1: High voltage level\r\n0: Low voltage level");
            this.textBox_Level0.Leave += new System.EventHandler(this.textBox_Bin_Leave);
            this.textBox_Level0.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Bin_KeyPress);
            // 
            // textBox_Mask0
            // 
            this.textBox_Mask0.Location = new System.Drawing.Point(307, 33);
            this.textBox_Mask0.MaxLength = 8;
            this.textBox_Mask0.Name = "textBox_Mask0";
            this.textBox_Mask0.Size = new System.Drawing.Size(65, 22);
            this.textBox_Mask0.TabIndex = 0;
            this.textBox_Mask0.Text = "00000000";
            this.textBox_Mask0.Leave += new System.EventHandler(this.textBox_Bin_Leave);
            this.textBox_Mask0.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Bin_KeyPress);
            // 
            // textBox_Dir0
            // 
            this.textBox_Dir0.Location = new System.Drawing.Point(307, 61);
            this.textBox_Dir0.MaxLength = 8;
            this.textBox_Dir0.Name = "textBox_Dir0";
            this.textBox_Dir0.Size = new System.Drawing.Size(65, 22);
            this.textBox_Dir0.TabIndex = 0;
            this.textBox_Dir0.Text = "00000000";
            this.toolTip.SetToolTip(this.textBox_Dir0, "1: Input direction\r\n0: Output direction");
            this.textBox_Dir0.Leave += new System.EventHandler(this.textBox_Bin_Leave);
            this.textBox_Dir0.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Bin_KeyPress);
            // 
            // textBox_Mask1
            // 
            this.textBox_Mask1.Location = new System.Drawing.Point(240, 33);
            this.textBox_Mask1.MaxLength = 8;
            this.textBox_Mask1.Name = "textBox_Mask1";
            this.textBox_Mask1.Size = new System.Drawing.Size(65, 22);
            this.textBox_Mask1.TabIndex = 0;
            this.textBox_Mask1.Text = "00000000";
            this.textBox_Mask1.Leave += new System.EventHandler(this.textBox_Bin_Leave);
            this.textBox_Mask1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Bin_KeyPress);
            // 
            // textBox_Level1
            // 
            this.textBox_Level1.Location = new System.Drawing.Point(240, 127);
            this.textBox_Level1.MaxLength = 8;
            this.textBox_Level1.Name = "textBox_Level1";
            this.textBox_Level1.Size = new System.Drawing.Size(65, 22);
            this.textBox_Level1.TabIndex = 0;
            this.textBox_Level1.Text = "00000000";
            this.toolTip.SetToolTip(this.textBox_Level1, "1: High voltage level\r\n0: Low voltage level");
            this.textBox_Level1.Leave += new System.EventHandler(this.textBox_Bin_Leave);
            this.textBox_Level1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Bin_KeyPress);
            // 
            // textBox_Dir1
            // 
            this.textBox_Dir1.Location = new System.Drawing.Point(240, 61);
            this.textBox_Dir1.MaxLength = 8;
            this.textBox_Dir1.Name = "textBox_Dir1";
            this.textBox_Dir1.Size = new System.Drawing.Size(65, 22);
            this.textBox_Dir1.TabIndex = 0;
            this.textBox_Dir1.Text = "00000000";
            this.toolTip.SetToolTip(this.textBox_Dir1, "1: Input direction\r\n0: Output direction");
            this.textBox_Dir1.Leave += new System.EventHandler(this.textBox_Bin_Leave);
            this.textBox_Dir1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Bin_KeyPress);
            // 
            // textBox_Mask2
            // 
            this.textBox_Mask2.Location = new System.Drawing.Point(173, 33);
            this.textBox_Mask2.MaxLength = 8;
            this.textBox_Mask2.Name = "textBox_Mask2";
            this.textBox_Mask2.Size = new System.Drawing.Size(65, 22);
            this.textBox_Mask2.TabIndex = 0;
            this.textBox_Mask2.Text = "00000000";
            this.textBox_Mask2.Leave += new System.EventHandler(this.textBox_Bin_Leave);
            this.textBox_Mask2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Bin_KeyPress);
            // 
            // textBox_Level2
            // 
            this.textBox_Level2.Location = new System.Drawing.Point(173, 127);
            this.textBox_Level2.MaxLength = 8;
            this.textBox_Level2.Name = "textBox_Level2";
            this.textBox_Level2.Size = new System.Drawing.Size(65, 22);
            this.textBox_Level2.TabIndex = 0;
            this.textBox_Level2.Text = "00000000";
            this.toolTip.SetToolTip(this.textBox_Level2, "1: High voltage level\r\n0: Low voltage level");
            this.textBox_Level2.Leave += new System.EventHandler(this.textBox_Bin_Leave);
            this.textBox_Level2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Bin_KeyPress);
            // 
            // textBox_Dir2
            // 
            this.textBox_Dir2.Location = new System.Drawing.Point(173, 61);
            this.textBox_Dir2.MaxLength = 8;
            this.textBox_Dir2.Name = "textBox_Dir2";
            this.textBox_Dir2.Size = new System.Drawing.Size(65, 22);
            this.textBox_Dir2.TabIndex = 0;
            this.textBox_Dir2.Text = "00000000";
            this.toolTip.SetToolTip(this.textBox_Dir2, "1: Input direction\r\n0: Output direction");
            this.textBox_Dir2.Leave += new System.EventHandler(this.textBox_Bin_Leave);
            this.textBox_Dir2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Bin_KeyPress);
            // 
            // textBox_Mask3
            // 
            this.textBox_Mask3.Location = new System.Drawing.Point(106, 33);
            this.textBox_Mask3.MaxLength = 8;
            this.textBox_Mask3.Name = "textBox_Mask3";
            this.textBox_Mask3.Size = new System.Drawing.Size(65, 22);
            this.textBox_Mask3.TabIndex = 0;
            this.textBox_Mask3.Text = "00000000";
            this.textBox_Mask3.Leave += new System.EventHandler(this.textBox_Bin_Leave);
            this.textBox_Mask3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Bin_KeyPress);
            // 
            // textBox_Level3
            // 
            this.textBox_Level3.Location = new System.Drawing.Point(106, 127);
            this.textBox_Level3.MaxLength = 8;
            this.textBox_Level3.Name = "textBox_Level3";
            this.textBox_Level3.Size = new System.Drawing.Size(65, 22);
            this.textBox_Level3.TabIndex = 0;
            this.textBox_Level3.Text = "00000000";
            this.toolTip.SetToolTip(this.textBox_Level3, "1: High voltage level\r\n0: Low voltage level");
            this.textBox_Level3.Leave += new System.EventHandler(this.textBox_Bin_Leave);
            this.textBox_Level3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Bin_KeyPress);
            // 
            // textBox_Dir3
            // 
            this.textBox_Dir3.Location = new System.Drawing.Point(106, 61);
            this.textBox_Dir3.MaxLength = 8;
            this.textBox_Dir3.Name = "textBox_Dir3";
            this.textBox_Dir3.Size = new System.Drawing.Size(65, 22);
            this.textBox_Dir3.TabIndex = 0;
            this.textBox_Dir3.Text = "00000000";
            this.toolTip.SetToolTip(this.textBox_Dir3, "1: Input direction\r\n0: Output direction");
            this.textBox_Dir3.Leave += new System.EventHandler(this.textBox_Bin_Leave);
            this.textBox_Dir3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Bin_KeyPress);
            // 
            // comboBox_PinNum
            // 
            this.comboBox_PinNum.FormattingEnabled = true;
            this.comboBox_PinNum.Location = new System.Drawing.Point(106, 69);
            this.comboBox_PinNum.Name = "comboBox_PinNum";
            this.comboBox_PinNum.Size = new System.Drawing.Size(121, 20);
            this.comboBox_PinNum.TabIndex = 2;
            this.comboBox_PinNum.SelectedIndexChanged += new System.EventHandler(this.comboBox_PinNum_SelectedIndexChanged);
            // 
            // groupBox_PinSelection
            // 
            this.groupBox_PinSelection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_PinSelection.Controls.Add(this.label1);
            this.groupBox_PinSelection.Controls.Add(this.comboBox_PinNum);
            this.groupBox_PinSelection.Controls.Add(this.label2);
            this.groupBox_PinSelection.Controls.Add(this.radioButton_MultiPin);
            this.groupBox_PinSelection.Controls.Add(this.label4);
            this.groupBox_PinSelection.Controls.Add(this.label_Outputs);
            this.groupBox_PinSelection.Controls.Add(this.label_Inputs);
            this.groupBox_PinSelection.Controls.Add(this.label3);
            this.groupBox_PinSelection.Controls.Add(this.comboBox_BankNum);
            this.groupBox_PinSelection.Controls.Add(this.radioButton_SinglePin);
            this.groupBox_PinSelection.Location = new System.Drawing.Point(16, 14);
            this.groupBox_PinSelection.MaximumSize = new System.Drawing.Size(600, 120);
            this.groupBox_PinSelection.MinimumSize = new System.Drawing.Size(525, 0);
            this.groupBox_PinSelection.Name = "groupBox_PinSelection";
            this.groupBox_PinSelection.Size = new System.Drawing.Size(600, 104);
            this.groupBox_PinSelection.TabIndex = 5;
            this.groupBox_PinSelection.TabStop = false;
            this.groupBox_PinSelection.Text = "Pin Selection";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "Pin number:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Bank number:";
            // 
            // radioButton_MultiPin
            // 
            this.radioButton_MultiPin.AutoSize = true;
            this.radioButton_MultiPin.Checked = true;
            this.radioButton_MultiPin.Location = new System.Drawing.Point(100, 21);
            this.radioButton_MultiPin.Name = "radioButton_MultiPin";
            this.radioButton_MultiPin.Size = new System.Drawing.Size(67, 16);
            this.radioButton_MultiPin.TabIndex = 0;
            this.radioButton_MultiPin.TabStop = true;
            this.radioButton_MultiPin.Text = "Multi-Pin";
            this.radioButton_MultiPin.UseVisualStyleBackColor = true;
            this.radioButton_MultiPin.CheckedChanged += new System.EventHandler(this.radioButton_MultiPin_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(251, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "Support outputs:";
            this.toolTip.SetToolTip(this.label4, "1: Output direction supported\r\n0: Output direction unsupported");
            // 
            // label_Outputs
            // 
            this.label_Outputs.AutoSize = true;
            this.label_Outputs.Location = new System.Drawing.Point(344, 72);
            this.label_Outputs.Name = "label_Outputs";
            this.label_Outputs.Size = new System.Drawing.Size(13, 12);
            this.label_Outputs.TabIndex = 3;
            this.label_Outputs.Text = "--";
            this.toolTip.SetToolTip(this.label_Outputs, "1: Output direction supported\r\n0: Output direction unsupported");
            // 
            // label_Inputs
            // 
            this.label_Inputs.AutoSize = true;
            this.label_Inputs.Location = new System.Drawing.Point(344, 46);
            this.label_Inputs.Name = "label_Inputs";
            this.label_Inputs.Size = new System.Drawing.Size(13, 12);
            this.label_Inputs.TabIndex = 3;
            this.label_Inputs.Text = "--";
            this.toolTip.SetToolTip(this.label_Inputs, "1: Input direction supported\r\n0: Input direction unsupported");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(251, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "Support inputs:";
            this.toolTip.SetToolTip(this.label3, "1: Input direction supported\r\n0: Input direction unsupported");
            // 
            // comboBox_BankNum
            // 
            this.comboBox_BankNum.FormattingEnabled = true;
            this.comboBox_BankNum.Location = new System.Drawing.Point(106, 43);
            this.comboBox_BankNum.Name = "comboBox_BankNum";
            this.comboBox_BankNum.Size = new System.Drawing.Size(121, 20);
            this.comboBox_BankNum.TabIndex = 2;
            this.comboBox_BankNum.SelectedIndexChanged += new System.EventHandler(this.comboBox_BankNum_SelectedIndexChanged);
            // 
            // radioButton_SinglePin
            // 
            this.radioButton_SinglePin.AutoSize = true;
            this.radioButton_SinglePin.Location = new System.Drawing.Point(15, 21);
            this.radioButton_SinglePin.Name = "radioButton_SinglePin";
            this.radioButton_SinglePin.Size = new System.Drawing.Size(70, 16);
            this.radioButton_SinglePin.TabIndex = 0;
            this.radioButton_SinglePin.TabStop = true;
            this.radioButton_SinglePin.Text = "Single Pin";
            this.radioButton_SinglePin.UseVisualStyleBackColor = true;
            this.radioButton_SinglePin.CheckedChanged += new System.EventHandler(this.radioButton_SinglePin_CheckedChanged);
            // 
            // PageGPIO
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupBox_PinSelection);
            this.Controls.Add(this.groupBox_Info);
            this.MinimumSize = new System.Drawing.Size(630, 400);
            this.Name = "PageGPIO";
            this.Size = new System.Drawing.Size(630, 400);
            this.Load += new System.EventHandler(this.PageGPIO_Load);
            this.groupBox_Info.ResumeLayout(false);
            this.groupBox_Info.PerformLayout();
            this.groupBox_PinSelection.ResumeLayout(false);
            this.groupBox_PinSelection.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_Info;
        private System.Windows.Forms.ComboBox comboBox_PinNum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_BankNum;
        private System.Windows.Forms.GroupBox groupBox_PinSelection;
        private System.Windows.Forms.RadioButton radioButton_MultiPin;
        private System.Windows.Forms.RadioButton radioButton_SinglePin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_Outputs;
        private System.Windows.Forms.Label label_Inputs;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_Dir3;
        private System.Windows.Forms.Button button_SetLevel;
        private System.Windows.Forms.Button button_SetDir;
        private System.Windows.Forms.Button button_GetLevel;
        private System.Windows.Forms.Button button_GetDir;
        private System.Windows.Forms.TextBox textBox_Level0;
        private System.Windows.Forms.TextBox textBox_Dir0;
        private System.Windows.Forms.TextBox textBox_Level1;
        private System.Windows.Forms.TextBox textBox_Dir1;
        private System.Windows.Forms.TextBox textBox_Level2;
        private System.Windows.Forms.TextBox textBox_Dir2;
        private System.Windows.Forms.TextBox textBox_Level3;
        private System.Windows.Forms.TextBox textBox_Mask0;
        private System.Windows.Forms.TextBox textBox_Mask1;
        private System.Windows.Forms.TextBox textBox_Mask2;
        private System.Windows.Forms.TextBox textBox_Mask3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label_Bit31;
        private System.Windows.Forms.Label label_Bit24;
        private System.Windows.Forms.Label label_Bit16;
        private System.Windows.Forms.Label label_Bit8;
        private System.Windows.Forms.Label label_Bit0;
        private System.Windows.Forms.ToolTip toolTip;
    }
}
