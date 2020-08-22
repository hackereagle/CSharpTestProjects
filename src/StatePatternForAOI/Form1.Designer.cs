namespace StatePatternForAOI
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPlaceLineScanState = new System.Windows.Forms.Button();
            this.btnUnload = new System.Windows.Forms.Button();
            this.btnReadBarCode = new System.Windows.Forms.Button();
            this.btnInspect = new System.Windows.Forms.Button();
            this.btnLineScanStart = new System.Windows.Forms.Button();
            this.btnMove2ScanStart = new System.Windows.Forms.Button();
            this.btnPickState = new System.Windows.Forms.Button();
            this.btnLoadState = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblState = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPreState = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPlaceLineScanState);
            this.groupBox1.Controls.Add(this.btnUnload);
            this.groupBox1.Controls.Add(this.btnReadBarCode);
            this.groupBox1.Controls.Add(this.btnInspect);
            this.groupBox1.Controls.Add(this.btnLineScanStart);
            this.groupBox1.Controls.Add(this.btnMove2ScanStart);
            this.groupBox1.Controls.Add(this.btnPickState);
            this.groupBox1.Controls.Add(this.btnLoadState);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(189, 366);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "單一動作";
            // 
            // btnPlaceLineScanState
            // 
            this.btnPlaceLineScanState.Location = new System.Drawing.Point(32, 154);
            this.btnPlaceLineScanState.Name = "btnPlaceLineScanState";
            this.btnPlaceLineScanState.Size = new System.Drawing.Size(101, 34);
            this.btnPlaceLineScanState.TabIndex = 7;
            this.btnPlaceLineScanState.Text = "線掃描吹料";
            this.btnPlaceLineScanState.UseVisualStyleBackColor = true;
            this.btnPlaceLineScanState.Click += new System.EventHandler(this.btnPlaceLineScanState_Click);
            // 
            // btnUnload
            // 
            this.btnUnload.Location = new System.Drawing.Point(32, 322);
            this.btnUnload.Name = "btnUnload";
            this.btnUnload.Size = new System.Drawing.Size(101, 34);
            this.btnUnload.TabIndex = 6;
            this.btnUnload.Text = "出料狀態";
            this.btnUnload.UseVisualStyleBackColor = true;
            this.btnUnload.Click += new System.EventHandler(this.btnUnload_Click);
            // 
            // btnReadBarCode
            // 
            this.btnReadBarCode.Location = new System.Drawing.Point(32, 282);
            this.btnReadBarCode.Name = "btnReadBarCode";
            this.btnReadBarCode.Size = new System.Drawing.Size(101, 34);
            this.btnReadBarCode.TabIndex = 5;
            this.btnReadBarCode.Text = "條碼讀取";
            this.btnReadBarCode.UseVisualStyleBackColor = true;
            this.btnReadBarCode.Click += new System.EventHandler(this.btnReadBarCode_Click);
            // 
            // btnInspect
            // 
            this.btnInspect.Location = new System.Drawing.Point(32, 242);
            this.btnInspect.Name = "btnInspect";
            this.btnInspect.Size = new System.Drawing.Size(101, 34);
            this.btnInspect.TabIndex = 4;
            this.btnInspect.Text = "開始檢測";
            this.btnInspect.UseVisualStyleBackColor = true;
            this.btnInspect.Click += new System.EventHandler(this.btnInspect_Click);
            // 
            // btnLineScanStart
            // 
            this.btnLineScanStart.Location = new System.Drawing.Point(32, 194);
            this.btnLineScanStart.Name = "btnLineScanStart";
            this.btnLineScanStart.Size = new System.Drawing.Size(101, 42);
            this.btnLineScanStart.TabIndex = 3;
            this.btnLineScanStart.Text = "Line Scan Start";
            this.btnLineScanStart.UseVisualStyleBackColor = true;
            this.btnLineScanStart.Click += new System.EventHandler(this.btnLineScanStart_Click);
            // 
            // btnMove2ScanStart
            // 
            this.btnMove2ScanStart.Location = new System.Drawing.Point(32, 114);
            this.btnMove2ScanStart.Name = "btnMove2ScanStart";
            this.btnMove2ScanStart.Size = new System.Drawing.Size(101, 34);
            this.btnMove2ScanStart.TabIndex = 2;
            this.btnMove2ScanStart.Text = "移動至掃描線";
            this.btnMove2ScanStart.UseVisualStyleBackColor = true;
            this.btnMove2ScanStart.Click += new System.EventHandler(this.btnMove2ScanStart_Click);
            // 
            // btnPickState
            // 
            this.btnPickState.Location = new System.Drawing.Point(32, 74);
            this.btnPickState.Name = "btnPickState";
            this.btnPickState.Size = new System.Drawing.Size(101, 34);
            this.btnPickState.TabIndex = 1;
            this.btnPickState.Text = "吸料狀態";
            this.btnPickState.UseVisualStyleBackColor = true;
            this.btnPickState.Click += new System.EventHandler(this.btnPickState_Click);
            // 
            // btnLoadState
            // 
            this.btnLoadState.Location = new System.Drawing.Point(32, 34);
            this.btnLoadState.Name = "btnLoadState";
            this.btnLoadState.Size = new System.Drawing.Size(101, 34);
            this.btnLoadState.TabIndex = 0;
            this.btnLoadState.Text = "進料狀態";
            this.btnLoadState.UseVisualStyleBackColor = true;
            this.btnLoadState.Click += new System.EventHandler(this.btnLoadState_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblState);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnPreState);
            this.groupBox2.Controls.Add(this.btnNext);
            this.groupBox2.Location = new System.Drawing.Point(218, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(366, 366);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(55, 34);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(91, 15);
            this.lblState.TabIndex = 5;
            this.lblState.Text = "____________";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "State: ";
            // 
            // btnPreState
            // 
            this.btnPreState.Location = new System.Drawing.Point(196, 322);
            this.btnPreState.Name = "btnPreState";
            this.btnPreState.Size = new System.Drawing.Size(101, 34);
            this.btnPreState.TabIndex = 3;
            this.btnPreState.Text = "Previous State";
            this.btnPreState.UseVisualStyleBackColor = true;
            this.btnPreState.Click += new System.EventHandler(this.btnPreState_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(74, 322);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(101, 34);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "Next State";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 401);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnPickState;
        private System.Windows.Forms.Button btnLoadState;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnPreState;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnUnload;
        private System.Windows.Forms.Button btnReadBarCode;
        private System.Windows.Forms.Button btnInspect;
        private System.Windows.Forms.Button btnLineScanStart;
        private System.Windows.Forms.Button btnMove2ScanStart;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPlaceLineScanState;
    }
}

