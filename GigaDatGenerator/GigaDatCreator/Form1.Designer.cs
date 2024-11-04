namespace GigaDatCreator
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.actionCheckBox = new System.Windows.Forms.CheckBox();
            this.btnInputRemoveDevice = new System.Windows.Forms.Button();
            this.btnInputAddDevice = new System.Windows.Forms.Button();
            this.tgvInputFileDetails = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnInputScncfgPath = new System.Windows.Forms.Button();
            this.txtScncfgFilePath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnInputFirmwarePath_Click = new System.Windows.Forms.Button();
            this.txtFirmwareFilePath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGenerateDAT = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.targetEC = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.targetPID = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tgvInputFileDetails)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.ForeColor = System.Drawing.Color.Navy;
            this.groupBox1.Location = new System.Drawing.Point(9, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(654, 67);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Target Scanner";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(112, 38);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(124, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.Text = "Select Model Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Scanner Name";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.actionCheckBox);
            this.groupBox2.Controls.Add(this.btnInputRemoveDevice);
            this.groupBox2.Controls.Add(this.btnInputAddDevice);
            this.groupBox2.Controls.Add(this.tgvInputFileDetails);
            this.groupBox2.Controls.Add(this.btnInputScncfgPath);
            this.groupBox2.Controls.Add(this.txtScncfgFilePath);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.btnInputFirmwarePath_Click);
            this.groupBox2.Controls.Add(this.txtFirmwareFilePath);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.ForeColor = System.Drawing.Color.Navy;
            this.groupBox2.Location = new System.Drawing.Point(9, 93);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(535, 398);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select Required Files";
            // 
            // actionCheckBox
            // 
            this.actionCheckBox.AutoSize = true;
            this.actionCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actionCheckBox.ForeColor = System.Drawing.Color.Red;
            this.actionCheckBox.Location = new System.Drawing.Point(2, 359);
            this.actionCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.actionCheckBox.Name = "actionCheckBox";
            this.actionCheckBox.Size = new System.Drawing.Size(179, 21);
            this.actionCheckBox.TabIndex = 38;
            this.actionCheckBox.Text = "Remove Action Attribute";
            this.actionCheckBox.UseVisualStyleBackColor = true;
            // 
            // btnInputRemoveDevice
            // 
            this.btnInputRemoveDevice.ForeColor = System.Drawing.Color.Navy;
            this.btnInputRemoveDevice.Location = new System.Drawing.Point(368, 359);
            this.btnInputRemoveDevice.Name = "btnInputRemoveDevice";
            this.btnInputRemoveDevice.Size = new System.Drawing.Size(70, 34);
            this.btnInputRemoveDevice.TabIndex = 37;
            this.btnInputRemoveDevice.Text = "Remove Devices";
            this.btnInputRemoveDevice.UseVisualStyleBackColor = true;
            this.btnInputRemoveDevice.Click += new System.EventHandler(this.btnInputRemoveDevice_Click);
            // 
            // btnInputAddDevice
            // 
            this.btnInputAddDevice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInputAddDevice.ForeColor = System.Drawing.Color.Navy;
            this.btnInputAddDevice.Location = new System.Drawing.Point(450, 359);
            this.btnInputAddDevice.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnInputAddDevice.Name = "btnInputAddDevice";
            this.btnInputAddDevice.Size = new System.Drawing.Size(78, 34);
            this.btnInputAddDevice.TabIndex = 36;
            this.btnInputAddDevice.Text = "Add Device";
            this.btnInputAddDevice.UseVisualStyleBackColor = true;
            this.btnInputAddDevice.Click += new System.EventHandler(this.btnInputAddDevice_Click);
            // 
            // tgvInputFileDetails
            // 
            this.tgvInputFileDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tgvInputFileDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.tgvInputFileDetails.Location = new System.Drawing.Point(2, 159);
            this.tgvInputFileDetails.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tgvInputFileDetails.Name = "tgvInputFileDetails";
            this.tgvInputFileDetails.RowTemplate.Height = 24;
            this.tgvInputFileDetails.Size = new System.Drawing.Size(644, 165);
            this.tgvInputFileDetails.TabIndex = 21;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "DAT File Name";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 325;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Scncfg File Name";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 330;
            // 
            // btnInputScncfgPath
            // 
            this.btnInputScncfgPath.Location = new System.Drawing.Point(472, 113);
            this.btnInputScncfgPath.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnInputScncfgPath.Name = "btnInputScncfgPath";
            this.btnInputScncfgPath.Size = new System.Drawing.Size(56, 27);
            this.btnInputScncfgPath.TabIndex = 20;
            this.btnInputScncfgPath.Text = "...";
            this.btnInputScncfgPath.UseVisualStyleBackColor = true;
            this.btnInputScncfgPath.Click += new System.EventHandler(this.btnInputScncfgPath_Click);
            // 
            // txtScncfgFilePath
            // 
            this.txtScncfgFilePath.BackColor = System.Drawing.SystemColors.Control;
            this.txtScncfgFilePath.Location = new System.Drawing.Point(4, 117);
            this.txtScncfgFilePath.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtScncfgFilePath.Name = "txtScncfgFilePath";
            this.txtScncfgFilePath.ReadOnly = true;
            this.txtScncfgFilePath.Size = new System.Drawing.Size(464, 20);
            this.txtScncfgFilePath.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 93);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Scncfg File Path";
            // 
            // btnInputFirmwarePath_Click
            // 
            this.btnInputFirmwarePath_Click.Location = new System.Drawing.Point(472, 51);
            this.btnInputFirmwarePath_Click.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnInputFirmwarePath_Click.Name = "btnInputFirmwarePath_Click";
            this.btnInputFirmwarePath_Click.Size = new System.Drawing.Size(56, 27);
            this.btnInputFirmwarePath_Click.TabIndex = 17;
            this.btnInputFirmwarePath_Click.Text = "...";
            this.btnInputFirmwarePath_Click.UseVisualStyleBackColor = true;
            this.btnInputFirmwarePath_Click.Click += new System.EventHandler(this.btnInputFirmwarePath_Click_Click);
            // 
            // txtFirmwareFilePath
            // 
            this.txtFirmwareFilePath.BackColor = System.Drawing.SystemColors.Control;
            this.txtFirmwareFilePath.Location = new System.Drawing.Point(4, 55);
            this.txtFirmwareFilePath.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtFirmwareFilePath.Name = "txtFirmwareFilePath";
            this.txtFirmwareFilePath.ReadOnly = true;
            this.txtFirmwareFilePath.Size = new System.Drawing.Size(464, 20);
            this.txtFirmwareFilePath.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 32);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Firmware DAT File Path";
            // 
            // btnGenerateDAT
            // 
            this.btnGenerateDAT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateDAT.ForeColor = System.Drawing.Color.Navy;
            this.btnGenerateDAT.Location = new System.Drawing.Point(453, 502);
            this.btnGenerateDAT.Name = "btnGenerateDAT";
            this.btnGenerateDAT.Size = new System.Drawing.Size(91, 54);
            this.btnGenerateDAT.TabIndex = 35;
            this.btnGenerateDAT.Text = "Generate DAT File";
            this.btnGenerateDAT.UseVisualStyleBackColor = true;
            this.btnGenerateDAT.Click += new System.EventHandler(this.btnGenerateDAT_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.targetEC);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.targetPID);
            this.groupBox3.ForeColor = System.Drawing.Color.Navy;
            this.groupBox3.Location = new System.Drawing.Point(16, 495);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Size = new System.Drawing.Size(434, 61);
            this.groupBox3.TabIndex = 36;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Header Information";
            // 
            // targetEC
            // 
            this.targetEC.Location = new System.Drawing.Point(337, 28);
            this.targetEC.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.targetEC.Name = "targetEC";
            this.targetEC.Size = new System.Drawing.Size(76, 20);
            this.targetEC.TabIndex = 3;
            this.targetEC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.targetEC.TextChanged += new System.EventHandler(this.targetEC_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(241, 30);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "EC Level (Hex)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1, 28);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "PID Value (Hex)";
            // 
            // targetPID
            // 
            this.targetPID.Location = new System.Drawing.Point(105, 27);
            this.targetPID.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.targetPID.Name = "targetPID";
            this.targetPID.Size = new System.Drawing.Size(76, 20);
            this.targetPID.TabIndex = 0;
            this.targetPID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.targetPID.TextChanged += new System.EventHandler(this.targetPID_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 560);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnGenerateDAT);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GigaDatCreator";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.windows_close);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tgvInputFileDetails)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnInputFirmwarePath_Click;
        private System.Windows.Forms.TextBox txtFirmwareFilePath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnInputScncfgPath;
        private System.Windows.Forms.TextBox txtScncfgFilePath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGenerateDAT;
        private System.Windows.Forms.DataGridView tgvInputFileDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Button btnInputAddDevice;
        private System.Windows.Forms.Button btnInputRemoveDevice;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox targetEC;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox targetPID;
        private System.Windows.Forms.CheckBox actionCheckBox;
    }
}

