namespace HardwareManager
{
    partial class UcComPort
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.grpbxComport = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtbxPortname = new System.Windows.Forms.TextBox();
            this.cmbbxParity = new System.Windows.Forms.ComboBox();
            this.cmbbxBaudrate = new System.Windows.Forms.ComboBox();
            this.cmbbxDatabits = new System.Windows.Forms.ComboBox();
            this.cmbbxStopbits = new System.Windows.Forms.ComboBox();
            this.cmbbxHandshake = new System.Windows.Forms.ComboBox();
            this.grpbxComport.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpbxComport
            // 
            this.grpbxComport.Controls.Add(this.tableLayoutPanel1);
            this.grpbxComport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpbxComport.Font = new System.Drawing.Font("微軟正黑體", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.grpbxComport.ForeColor = System.Drawing.Color.Olive;
            this.grpbxComport.Location = new System.Drawing.Point(0, 0);
            this.grpbxComport.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.grpbxComport.Name = "grpbxComport";
            this.grpbxComport.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.grpbxComport.Size = new System.Drawing.Size(611, 89);
            this.grpbxComport.TabIndex = 1;
            this.grpbxComport.TabStop = false;
            this.grpbxComport.Text = "通訊埠設定";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetDouble;
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtbxPortname, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbbxParity, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbbxBaudrate, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbbxDatabits, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbbxStopbits, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbbxHandshake, 5, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 27);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(605, 57);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Port Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(6, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Baud Rate";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(206, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Data Bits";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(206, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "Parity";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(406, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 24);
            this.label5.TabIndex = 4;
            this.label5.Text = "Stop Bits";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.ForeColor = System.Drawing.Color.Navy;
            this.label6.Location = new System.Drawing.Point(406, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 24);
            this.label6.TabIndex = 5;
            this.label6.Text = "Handshake";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtbxPortname
            // 
            this.txtbxPortname.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtbxPortname.Font = new System.Drawing.Font("微軟正黑體", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtbxPortname.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtbxPortname.Location = new System.Drawing.Point(106, 8);
            this.txtbxPortname.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtbxPortname.Name = "txtbxPortname";
            this.txtbxPortname.Size = new System.Drawing.Size(91, 23);
            this.txtbxPortname.TabIndex = 6;
            // 
            // cmbbxParity
            // 
            this.cmbbxParity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbbxParity.Font = new System.Drawing.Font("微軟正黑體", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cmbbxParity.FormattingEnabled = true;
            this.cmbbxParity.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even"});
            this.cmbbxParity.Location = new System.Drawing.Point(306, 35);
            this.cmbbxParity.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cmbbxParity.Name = "cmbbxParity";
            this.cmbbxParity.Size = new System.Drawing.Size(91, 24);
            this.cmbbxParity.TabIndex = 12;
            // 
            // cmbbxBaudrate
            // 
            this.cmbbxBaudrate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbbxBaudrate.Font = new System.Drawing.Font("微軟正黑體", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cmbbxBaudrate.FormattingEnabled = true;
            this.cmbbxBaudrate.Items.AddRange(new object[] {
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "28800",
            "38400",
            "115200"});
            this.cmbbxBaudrate.Location = new System.Drawing.Point(106, 35);
            this.cmbbxBaudrate.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cmbbxBaudrate.Name = "cmbbxBaudrate";
            this.cmbbxBaudrate.Size = new System.Drawing.Size(91, 24);
            this.cmbbxBaudrate.TabIndex = 13;
            this.cmbbxBaudrate.SelectedIndexChanged += new System.EventHandler(this.CmbbxBaudrate_SelectedIndexChanged);
            // 
            // cmbbxDatabits
            // 
            this.cmbbxDatabits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbbxDatabits.Font = new System.Drawing.Font("微軟正黑體", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cmbbxDatabits.FormattingEnabled = true;
            this.cmbbxDatabits.Items.AddRange(new object[] {
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cmbbxDatabits.Location = new System.Drawing.Point(306, 8);
            this.cmbbxDatabits.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cmbbxDatabits.Name = "cmbbxDatabits";
            this.cmbbxDatabits.Size = new System.Drawing.Size(91, 24);
            this.cmbbxDatabits.TabIndex = 14;
            // 
            // cmbbxStopbits
            // 
            this.cmbbxStopbits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbbxStopbits.Font = new System.Drawing.Font("微軟正黑體", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cmbbxStopbits.FormattingEnabled = true;
            this.cmbbxStopbits.Items.AddRange(new object[] {
            "None",
            "One",
            "Two",
            "OnePointFive"});
            this.cmbbxStopbits.Location = new System.Drawing.Point(506, 8);
            this.cmbbxStopbits.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cmbbxStopbits.Name = "cmbbxStopbits";
            this.cmbbxStopbits.Size = new System.Drawing.Size(93, 24);
            this.cmbbxStopbits.TabIndex = 15;
            // 
            // cmbbxHandshake
            // 
            this.cmbbxHandshake.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbbxHandshake.Font = new System.Drawing.Font("微軟正黑體", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cmbbxHandshake.FormattingEnabled = true;
            this.cmbbxHandshake.Items.AddRange(new object[] {
            "None",
            "XOnXOff",
            "RTS",
            "RTSXOnXOff"});
            this.cmbbxHandshake.Location = new System.Drawing.Point(506, 35);
            this.cmbbxHandshake.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cmbbxHandshake.Name = "cmbbxHandshake";
            this.cmbbxHandshake.Size = new System.Drawing.Size(93, 24);
            this.cmbbxHandshake.TabIndex = 16;
            // 
            // UcComPort
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpbxComport);
            this.Font = new System.Drawing.Font("微軟正黑體", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "UcComPort";
            this.Size = new System.Drawing.Size(611, 89);
            this.Load += new System.EventHandler(this.ucComPort_Load);
            this.grpbxComport.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpbxComport;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtbxPortname;
        private System.Windows.Forms.ComboBox cmbbxParity;
        private System.Windows.Forms.ComboBox cmbbxBaudrate;
        private System.Windows.Forms.ComboBox cmbbxDatabits;
        private System.Windows.Forms.ComboBox cmbbxStopbits;
        private System.Windows.Forms.ComboBox cmbbxHandshake;
    }
}
