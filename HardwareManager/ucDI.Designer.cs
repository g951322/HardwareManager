namespace HardwareManager
{
    partial class UcDI
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
            this.labDINo = new System.Windows.Forms.Label();
            this.labDIMnemonic = new System.Windows.Forms.Label();
            this.radbtnDIStatus = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.labDINo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labDIMnemonic, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.radbtnDIStatus, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(107, 17);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labDINo
            // 
            this.labDINo.AutoSize = true;
            this.labDINo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labDINo.Font = new System.Drawing.Font("微軟正黑體", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labDINo.Location = new System.Drawing.Point(1, 0);
            this.labDINo.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labDINo.Name = "labDINo";
            this.labDINo.Size = new System.Drawing.Size(30, 17);
            this.labDINo.TabIndex = 0;
            this.labDINo.Text = "DI0";
            this.labDINo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labDIMnemonic
            // 
            this.labDIMnemonic.AutoSize = true;
            this.labDIMnemonic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labDIMnemonic.Font = new System.Drawing.Font("微軟正黑體", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labDIMnemonic.Location = new System.Drawing.Point(54, 0);
            this.labDIMnemonic.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labDIMnemonic.Name = "labDIMnemonic";
            this.labDIMnemonic.Size = new System.Drawing.Size(52, 17);
            this.labDIMnemonic.TabIndex = 1;
            this.labDIMnemonic.Text = "label2";
            this.labDIMnemonic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radbtnDIStatus
            // 
            this.radbtnDIStatus.AutoCheck = false;
            this.radbtnDIStatus.AutoSize = true;
            this.radbtnDIStatus.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radbtnDIStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radbtnDIStatus.Enabled = false;
            this.radbtnDIStatus.Font = new System.Drawing.Font("微軟正黑體", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.radbtnDIStatus.Location = new System.Drawing.Point(33, 1);
            this.radbtnDIStatus.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.radbtnDIStatus.Name = "radbtnDIStatus";
            this.radbtnDIStatus.Size = new System.Drawing.Size(19, 15);
            this.radbtnDIStatus.TabIndex = 2;
            this.radbtnDIStatus.TabStop = true;
            this.radbtnDIStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radbtnDIStatus.UseVisualStyleBackColor = true;
            // 
            // UcDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(5F, 10F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("微軟正黑體", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Name = "UcDI";
            this.Size = new System.Drawing.Size(107, 17);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labDINo;
        private System.Windows.Forms.Label labDIMnemonic;
        private System.Windows.Forms.RadioButton radbtnDIStatus;
    }
}
