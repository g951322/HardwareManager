namespace HardwareManager
{
    partial class UCHardwareManager
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
            this.layoutpnlHWManager = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabpgPlatform = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.trkbrPlatformPosition = new System.Windows.Forms.TrackBar();
            this.labPosition = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.trkbrPlatformSpeed = new System.Windows.Forms.TrackBar();
            this.labSpeed = new System.Windows.Forms.Label();
            this.btnPlatformHome = new System.Windows.Forms.Button();
            this.btnPlatformReset = new System.Windows.Forms.Button();
            this.labProcedureChecker = new System.Windows.Forms.Label();
            this.labWastedTimeByCallback = new System.Windows.Forms.Label();
            this.tabpgPickPlace = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.trkbrXPosition = new System.Windows.Forms.TrackBar();
            this.labXPosition = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.trkbrZPosition = new System.Windows.Forms.TrackBar();
            this.labZPosition = new System.Windows.Forms.Label();
            this.btnXHome = new System.Windows.Forms.Button();
            this.btnXZReset = new System.Windows.Forms.Button();
            this.btnZHome = new System.Windows.Forms.Button();
            this.btnXStop = new System.Windows.Forms.Button();
            this.btnZStop = new System.Windows.Forms.Button();
            this.tabpgDIO = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.layoutpnlDI = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.layoutpnlDO = new System.Windows.Forms.TableLayoutPanel();
            this.tabpgSUSI = new System.Windows.Forms.TabPage();
            this.tabControlSUSI = new System.Windows.Forms.TabControl();
            this.layoutpnlHWManager.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabpgPlatform.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkbrPlatformPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkbrPlatformSpeed)).BeginInit();
            this.tabpgPickPlace.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkbrXPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkbrZPosition)).BeginInit();
            this.tabpgDIO.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabpgSUSI.SuspendLayout();
            this.SuspendLayout();
            // 
            // layoutpnlHWManager
            // 
            this.layoutpnlHWManager.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset;
            this.layoutpnlHWManager.ColumnCount = 1;
            this.layoutpnlHWManager.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutpnlHWManager.Controls.Add(this.tabControl1, 0, 2);
            this.layoutpnlHWManager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutpnlHWManager.Location = new System.Drawing.Point(0, 0);
            this.layoutpnlHWManager.Name = "layoutpnlHWManager";
            this.layoutpnlHWManager.RowCount = 3;
            this.layoutpnlHWManager.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.layoutpnlHWManager.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.layoutpnlHWManager.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 230F));
            this.layoutpnlHWManager.Size = new System.Drawing.Size(600, 417);
            this.layoutpnlHWManager.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabpgPlatform);
            this.tabControl1.Controls.Add(this.tabpgPickPlace);
            this.tabControl1.Controls.Add(this.tabpgDIO);
            this.tabControl1.Controls.Add(this.tabpgSUSI);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("微軟正黑體", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabControl1.Location = new System.Drawing.Point(5, 179);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(590, 233);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabpgPlatform
            // 
            this.tabpgPlatform.Controls.Add(this.tableLayoutPanel2);
            this.tabpgPlatform.Location = new System.Drawing.Point(4, 29);
            this.tabpgPlatform.Name = "tabpgPlatform";
            this.tabpgPlatform.Padding = new System.Windows.Forms.Padding(3);
            this.tabpgPlatform.Size = new System.Drawing.Size(582, 200);
            this.tabpgPlatform.TabIndex = 0;
            this.tabpgPlatform.Text = "置片平台";
            this.tabpgPlatform.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.trkbrPlatformPosition, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.labPosition, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.trkbrPlatformSpeed, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.labSpeed, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnPlatformHome, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnPlatformReset, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.labProcedureChecker, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.labWastedTimeByCallback, 4, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(576, 194);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "位置";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trkbrPlatformPosition
            // 
            this.trkbrPlatformPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trkbrPlatformPosition.Location = new System.Drawing.Point(60, 3);
            this.trkbrPlatformPosition.Maximum = 310;
            this.trkbrPlatformPosition.Name = "trkbrPlatformPosition";
            this.trkbrPlatformPosition.Size = new System.Drawing.Size(282, 42);
            this.trkbrPlatformPosition.TabIndex = 1;
            this.trkbrPlatformPosition.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trkbrPlatformPosition.Scroll += new System.EventHandler(this.TrkbrPlatformPosition_Scroll);
            this.trkbrPlatformPosition.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trkbrPlatformPosition_MouseDown);
            this.trkbrPlatformPosition.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trkbrPlatformPosition_MouseUp);
            // 
            // labPosition
            // 
            this.labPosition.AutoSize = true;
            this.labPosition.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labPosition.ForeColor = System.Drawing.Color.Maroon;
            this.labPosition.Location = new System.Drawing.Point(348, 0);
            this.labPosition.Name = "labPosition";
            this.labPosition.Size = new System.Drawing.Size(51, 48);
            this.labPosition.TabIndex = 2;
            this.labPosition.Text = "0";
            this.labPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(3, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 48);
            this.label3.TabIndex = 3;
            this.label3.Text = "移動速度";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trkbrPlatformSpeed
            // 
            this.trkbrPlatformSpeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trkbrPlatformSpeed.LargeChange = 50;
            this.trkbrPlatformSpeed.Location = new System.Drawing.Point(60, 51);
            this.trkbrPlatformSpeed.Maximum = 900;
            this.trkbrPlatformSpeed.Name = "trkbrPlatformSpeed";
            this.trkbrPlatformSpeed.Size = new System.Drawing.Size(282, 42);
            this.trkbrPlatformSpeed.TabIndex = 4;
            this.trkbrPlatformSpeed.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trkbrPlatformSpeed.Value = 50;
            this.trkbrPlatformSpeed.Scroll += new System.EventHandler(this.TrkbrPlatformSpeed_Scroll);
            this.trkbrPlatformSpeed.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trkbrPlatformSpeed_MouseDown);
            this.trkbrPlatformSpeed.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trkbrPlatformSpeed_MouseUp);
            // 
            // labSpeed
            // 
            this.labSpeed.AutoSize = true;
            this.labSpeed.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labSpeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labSpeed.ForeColor = System.Drawing.Color.Maroon;
            this.labSpeed.Location = new System.Drawing.Point(348, 48);
            this.labSpeed.Name = "labSpeed";
            this.labSpeed.Size = new System.Drawing.Size(51, 48);
            this.labSpeed.TabIndex = 5;
            this.labSpeed.Text = "0";
            this.labSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPlatformHome
            // 
            this.btnPlatformHome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPlatformHome.ForeColor = System.Drawing.Color.Navy;
            this.btnPlatformHome.Location = new System.Drawing.Point(491, 3);
            this.btnPlatformHome.Name = "btnPlatformHome";
            this.btnPlatformHome.Size = new System.Drawing.Size(82, 42);
            this.btnPlatformHome.TabIndex = 6;
            this.btnPlatformHome.Text = "GoHome";
            this.btnPlatformHome.UseVisualStyleBackColor = true;
            this.btnPlatformHome.Click += new System.EventHandler(this.BtnPlatformHome_Click);
            // 
            // btnPlatformReset
            // 
            this.btnPlatformReset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPlatformReset.ForeColor = System.Drawing.Color.Navy;
            this.btnPlatformReset.Location = new System.Drawing.Point(491, 51);
            this.btnPlatformReset.Name = "btnPlatformReset";
            this.btnPlatformReset.Size = new System.Drawing.Size(82, 42);
            this.btnPlatformReset.TabIndex = 7;
            this.btnPlatformReset.Text = "Reset";
            this.btnPlatformReset.UseVisualStyleBackColor = true;
            this.btnPlatformReset.Click += new System.EventHandler(this.BtnPlatformReset_Click);
            // 
            // labProcedureChecker
            // 
            this.labProcedureChecker.AutoSize = true;
            this.labProcedureChecker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labProcedureChecker.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labProcedureChecker.Location = new System.Drawing.Point(405, 96);
            this.labProcedureChecker.Name = "labProcedureChecker";
            this.labProcedureChecker.Size = new System.Drawing.Size(80, 48);
            this.labProcedureChecker.TabIndex = 8;
            this.labProcedureChecker.Text = "0";
            this.labProcedureChecker.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labWastedTimeByCallback
            // 
            this.labWastedTimeByCallback.AutoSize = true;
            this.labWastedTimeByCallback.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labWastedTimeByCallback.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labWastedTimeByCallback.Location = new System.Drawing.Point(491, 96);
            this.labWastedTimeByCallback.Name = "labWastedTimeByCallback";
            this.labWastedTimeByCallback.Size = new System.Drawing.Size(82, 48);
            this.labWastedTimeByCallback.TabIndex = 9;
            this.labWastedTimeByCallback.Text = "00:00";
            this.labWastedTimeByCallback.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabpgPickPlace
            // 
            this.tabpgPickPlace.Controls.Add(this.tableLayoutPanel3);
            this.tabpgPickPlace.Location = new System.Drawing.Point(4, 29);
            this.tabpgPickPlace.Name = "tabpgPickPlace";
            this.tabpgPickPlace.Padding = new System.Windows.Forms.Padding(3);
            this.tabpgPickPlace.Size = new System.Drawing.Size(582, 200);
            this.tabpgPickPlace.TabIndex = 1;
            this.tabpgPickPlace.Text = "取片機構";
            this.tabpgPickPlace.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 5;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.trkbrXPosition, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.labXPosition, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.trkbrZPosition, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.labZPosition, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.btnXHome, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnXZReset, 4, 2);
            this.tableLayoutPanel3.Controls.Add(this.btnZHome, 4, 1);
            this.tableLayoutPanel3.Controls.Add(this.btnXStop, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnZStop, 3, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(576, 194);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 48);
            this.label2.TabIndex = 0;
            this.label2.Text = "X軸位置";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trkbrXPosition
            // 
            this.trkbrXPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trkbrXPosition.Location = new System.Drawing.Point(60, 3);
            this.trkbrXPosition.Maximum = 768000;
            this.trkbrXPosition.Name = "trkbrXPosition";
            this.trkbrXPosition.Size = new System.Drawing.Size(282, 42);
            this.trkbrXPosition.TabIndex = 1;
            this.trkbrXPosition.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trkbrXPosition.Scroll += new System.EventHandler(this.TrkbrXPosition_Scroll);
            this.trkbrXPosition.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trkbrXPosition_MouseDown);
            this.trkbrXPosition.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trkbrXPosition_MouseUp);
            // 
            // labXPosition
            // 
            this.labXPosition.AutoSize = true;
            this.labXPosition.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labXPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labXPosition.ForeColor = System.Drawing.Color.Maroon;
            this.labXPosition.Location = new System.Drawing.Point(348, 0);
            this.labXPosition.Name = "labXPosition";
            this.labXPosition.Size = new System.Drawing.Size(51, 48);
            this.labXPosition.TabIndex = 2;
            this.labXPosition.Text = "0";
            this.labXPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(3, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 48);
            this.label5.TabIndex = 3;
            this.label5.Text = "Z軸位置";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trkbrZPosition
            // 
            this.trkbrZPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trkbrZPosition.Location = new System.Drawing.Point(60, 51);
            this.trkbrZPosition.Maximum = 1024000;
            this.trkbrZPosition.Name = "trkbrZPosition";
            this.trkbrZPosition.Size = new System.Drawing.Size(282, 42);
            this.trkbrZPosition.TabIndex = 4;
            this.trkbrZPosition.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trkbrZPosition.Scroll += new System.EventHandler(this.TrkbrZPosition_Scroll);
            this.trkbrZPosition.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trkbrZPosition_MouseDown);
            this.trkbrZPosition.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trkbrZPosition_MouseUp);
            // 
            // labZPosition
            // 
            this.labZPosition.AutoSize = true;
            this.labZPosition.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labZPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labZPosition.ForeColor = System.Drawing.Color.Maroon;
            this.labZPosition.Location = new System.Drawing.Point(348, 48);
            this.labZPosition.Name = "labZPosition";
            this.labZPosition.Size = new System.Drawing.Size(51, 48);
            this.labZPosition.TabIndex = 5;
            this.labZPosition.Text = "0";
            this.labZPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnXHome
            // 
            this.btnXHome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnXHome.ForeColor = System.Drawing.Color.Navy;
            this.btnXHome.Location = new System.Drawing.Point(491, 3);
            this.btnXHome.Name = "btnXHome";
            this.btnXHome.Size = new System.Drawing.Size(82, 42);
            this.btnXHome.TabIndex = 6;
            this.btnXHome.Text = "X_Home";
            this.btnXHome.UseVisualStyleBackColor = true;
            this.btnXHome.Click += new System.EventHandler(this.btnXHome_Click);
            // 
            // btnXZReset
            // 
            this.btnXZReset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnXZReset.ForeColor = System.Drawing.Color.Navy;
            this.btnXZReset.Location = new System.Drawing.Point(491, 99);
            this.btnXZReset.Name = "btnXZReset";
            this.btnXZReset.Size = new System.Drawing.Size(82, 42);
            this.btnXZReset.TabIndex = 7;
            this.btnXZReset.Text = "Reset";
            this.btnXZReset.UseVisualStyleBackColor = true;
            this.btnXZReset.Click += new System.EventHandler(this.btnXZReset_Click);
            // 
            // btnZHome
            // 
            this.btnZHome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnZHome.ForeColor = System.Drawing.Color.Navy;
            this.btnZHome.Location = new System.Drawing.Point(491, 51);
            this.btnZHome.Name = "btnZHome";
            this.btnZHome.Size = new System.Drawing.Size(82, 42);
            this.btnZHome.TabIndex = 8;
            this.btnZHome.Text = "Z_Home";
            this.btnZHome.UseVisualStyleBackColor = true;
            this.btnZHome.Click += new System.EventHandler(this.btnZHome_Click);
            // 
            // btnXStop
            // 
            this.btnXStop.ForeColor = System.Drawing.Color.Red;
            this.btnXStop.Location = new System.Drawing.Point(405, 3);
            this.btnXStop.Name = "btnXStop";
            this.btnXStop.Size = new System.Drawing.Size(80, 42);
            this.btnXStop.TabIndex = 9;
            this.btnXStop.Text = "X_Stop";
            this.btnXStop.UseVisualStyleBackColor = true;
            this.btnXStop.Click += new System.EventHandler(this.btnXStop_Click);
            // 
            // btnZStop
            // 
            this.btnZStop.ForeColor = System.Drawing.Color.Red;
            this.btnZStop.Location = new System.Drawing.Point(405, 51);
            this.btnZStop.Name = "btnZStop";
            this.btnZStop.Size = new System.Drawing.Size(80, 42);
            this.btnZStop.TabIndex = 10;
            this.btnZStop.Text = "Z_Stop";
            this.btnZStop.UseVisualStyleBackColor = true;
            this.btnZStop.Click += new System.EventHandler(this.btnZStop_Click);
            // 
            // tabpgDIO
            // 
            this.tabpgDIO.Controls.Add(this.splitContainer1);
            this.tabpgDIO.Location = new System.Drawing.Point(4, 29);
            this.tabpgDIO.Name = "tabpgDIO";
            this.tabpgDIO.Size = new System.Drawing.Size(582, 200);
            this.tabpgDIO.TabIndex = 2;
            this.tabpgDIO.Text = "DIO";
            this.tabpgDIO.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(582, 200);
            this.splitContainer1.SplitterDistance = 180;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.layoutpnlDI);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(180, 200);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DI";
            // 
            // layoutpnlDI
            // 
            this.layoutpnlDI.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.layoutpnlDI.ColumnCount = 2;
            this.layoutpnlDI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutpnlDI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutpnlDI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutpnlDI.Location = new System.Drawing.Point(3, 25);
            this.layoutpnlDI.Name = "layoutpnlDI";
            this.layoutpnlDI.RowCount = 4;
            this.layoutpnlDI.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.layoutpnlDI.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.layoutpnlDI.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.layoutpnlDI.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.layoutpnlDI.Size = new System.Drawing.Size(174, 172);
            this.layoutpnlDI.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.layoutpnlDO);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(398, 200);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "DO";
            // 
            // layoutpnlDO
            // 
            this.layoutpnlDO.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.layoutpnlDO.ColumnCount = 2;
            this.layoutpnlDO.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutpnlDO.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutpnlDO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutpnlDO.Location = new System.Drawing.Point(3, 25);
            this.layoutpnlDO.Name = "layoutpnlDO";
            this.layoutpnlDO.RowCount = 4;
            this.layoutpnlDO.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.layoutpnlDO.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.layoutpnlDO.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.layoutpnlDO.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.layoutpnlDO.Size = new System.Drawing.Size(392, 172);
            this.layoutpnlDO.TabIndex = 0;
            // 
            // tabpgSUSI
            // 
            this.tabpgSUSI.Controls.Add(this.tabControlSUSI);
            this.tabpgSUSI.Location = new System.Drawing.Point(4, 29);
            this.tabpgSUSI.Name = "tabpgSUSI";
            this.tabpgSUSI.Size = new System.Drawing.Size(582, 200);
            this.tabpgSUSI.TabIndex = 3;
            this.tabpgSUSI.Text = "SUSI";
            this.tabpgSUSI.UseVisualStyleBackColor = true;
            // 
            // tabControlSUSI
            // 
            this.tabControlSUSI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSUSI.Location = new System.Drawing.Point(0, 0);
            this.tabControlSUSI.Name = "tabControlSUSI";
            this.tabControlSUSI.SelectedIndex = 0;
            this.tabControlSUSI.Size = new System.Drawing.Size(582, 200);
            this.tabControlSUSI.TabIndex = 0;
            // 
            // UCHardwareManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutpnlHWManager);
            this.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UCHardwareManager";
            this.Size = new System.Drawing.Size(600, 417);
            this.Load += new System.EventHandler(this.UCHardwareManager_Load);
            this.layoutpnlHWManager.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabpgPlatform.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkbrPlatformPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkbrPlatformSpeed)).EndInit();
            this.tabpgPickPlace.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkbrXPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkbrZPosition)).EndInit();
            this.tabpgDIO.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tabpgSUSI.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel layoutpnlHWManager;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabpgPlatform;
        private System.Windows.Forms.TabPage tabpgPickPlace;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trkbrPlatformPosition;
        private System.Windows.Forms.Label labPosition;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar trkbrPlatformSpeed;
        private System.Windows.Forms.Label labSpeed;
        private System.Windows.Forms.Button btnPlatformHome;
        private System.Windows.Forms.Button btnPlatformReset;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trkbrXPosition;
        private System.Windows.Forms.Label labXPosition;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar trkbrZPosition;
        private System.Windows.Forms.Label labZPosition;
        private System.Windows.Forms.Button btnXHome;
        private System.Windows.Forms.Button btnXZReset;
        private System.Windows.Forms.Button btnZHome;
        private System.Windows.Forms.TabPage tabpgDIO;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel layoutpnlDI;
        private System.Windows.Forms.TableLayoutPanel layoutpnlDO;
        private System.Windows.Forms.Button btnXStop;
        private System.Windows.Forms.Button btnZStop;
        private System.Windows.Forms.Label labProcedureChecker;
        private System.Windows.Forms.Label labWastedTimeByCallback;
        private System.Windows.Forms.TabPage tabpgSUSI;
        private System.Windows.Forms.TabControl tabControlSUSI;
    }
}
