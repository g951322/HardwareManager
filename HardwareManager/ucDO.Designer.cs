namespace HardwareManager
{
    partial class UcDO
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.radbtnDOon = new System.Windows.Forms.RadioButton();
            this.labDONo = new System.Windows.Forms.Label();
            this.labDOMnemonic = new System.Windows.Forms.Label();
            this.radbtnDOoff = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32F));
            this.tableLayoutPanel1.Controls.Add(this.radbtnDOon, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labDONo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labDOMnemonic, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.radbtnDOoff, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 33);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // radbtnDOon
            // 
            this.radbtnDOon.AutoSize = true;
            this.radbtnDOon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radbtnDOon.Font = new System.Drawing.Font("微軟正黑體", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.radbtnDOon.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.radbtnDOon.Location = new System.Drawing.Point(44, 0);
            this.radbtnDOon.Margin = new System.Windows.Forms.Padding(0);
            this.radbtnDOon.Name = "radbtnDOon";
            this.radbtnDOon.Size = new System.Drawing.Size(40, 33);
            this.radbtnDOon.TabIndex = 3;
            this.radbtnDOon.Text = "ON";
            this.radbtnDOon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radbtnDOon.UseVisualStyleBackColor = true;
            // 
            // labDONo
            // 
            this.labDONo.AutoSize = true;
            this.labDONo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labDONo.Font = new System.Drawing.Font("微軟正黑體", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labDONo.ForeColor = System.Drawing.Color.Navy;
            this.labDONo.Location = new System.Drawing.Point(0, 0);
            this.labDONo.Margin = new System.Windows.Forms.Padding(0);
            this.labDONo.Name = "labDONo";
            this.labDONo.Size = new System.Drawing.Size(44, 33);
            this.labDONo.TabIndex = 0;
            this.labDONo.Text = "DO0";
            this.labDONo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labDOMnemonic
            // 
            this.labDOMnemonic.AutoSize = true;
            this.labDOMnemonic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labDOMnemonic.Font = new System.Drawing.Font("微軟正黑體", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labDOMnemonic.ForeColor = System.Drawing.Color.Maroon;
            this.labDOMnemonic.Location = new System.Drawing.Point(136, 0);
            this.labDOMnemonic.Margin = new System.Windows.Forms.Padding(0);
            this.labDOMnemonic.Name = "labDOMnemonic";
            this.labDOMnemonic.Size = new System.Drawing.Size(64, 33);
            this.labDOMnemonic.TabIndex = 1;
            this.labDOMnemonic.Text = "label2";
            this.labDOMnemonic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radbtnDOoff
            // 
            this.radbtnDOoff.AutoSize = true;
            this.radbtnDOoff.Checked = true;
            this.radbtnDOoff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radbtnDOoff.Font = new System.Drawing.Font("微軟正黑體", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.radbtnDOoff.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.radbtnDOoff.Location = new System.Drawing.Point(84, 0);
            this.radbtnDOoff.Margin = new System.Windows.Forms.Padding(0);
            this.radbtnDOoff.Name = "radbtnDOoff";
            this.radbtnDOoff.Size = new System.Drawing.Size(52, 33);
            this.radbtnDOoff.TabIndex = 2;
            this.radbtnDOoff.TabStop = true;
            this.radbtnDOoff.Text = "OFF";
            this.radbtnDOoff.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radbtnDOoff.UseVisualStyleBackColor = true;
            // 
            // UcDO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("微軟正黑體", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UcDO";
            this.Size = new System.Drawing.Size(200, 33);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labDONo;
        private System.Windows.Forms.Label labDOMnemonic;
        public System.Windows.Forms.RadioButton radbtnDOon;
        public System.Windows.Forms.RadioButton radbtnDOoff;
    }
}
