namespace backupmsoutlook.Schedule
{
    partial class F_AddSchedule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_AddSchedule));
            this.label1 = new System.Windows.Forms.Label();
            this.B_browseOutputFolder = new System.Windows.Forms.Button();
            this.TB_pathToOutputFolder = new System.Windows.Forms.TextBox();
            this.TB_pathToLog = new System.Windows.Forms.TextBox();
            this.B_browseLogFile = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TB_taskDescription = new System.Windows.Forms.TextBox();
            this.DTP_startDate = new System.Windows.Forms.DateTimePicker();
            this.NUD_hour = new System.Windows.Forms.NumericUpDown();
            this.NUD_minute = new System.Windows.Forms.NumericUpDown();
            this.CB_scheduleType = new System.Windows.Forms.ComboBox();
            this.CB_repeat = new System.Windows.Forms.CheckBox();
            this.B_saveSchedule = new System.Windows.Forms.Button();
            this.B_abort = new System.Windows.Forms.Button();
            this.CB_afterShutdownComputer = new System.Windows.Forms.CheckBox();
            this.NUD_intervalSchedule = new System.Windows.Forms.NumericUpDown();
            this.GB_permission = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TB_password = new System.Windows.Forms.TextBox();
            this.TB_fullUserName = new System.Windows.Forms.TextBox();
            this.CB_useBellowAccount = new System.Windows.Forms.CheckBox();
            this.CB_addingTimestampToPst = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_hour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_minute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_intervalSchedule)).BeginInit();
            this.GB_permission.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Path to Output backup folder";
            // 
            // B_browseOutputFolder
            // 
            this.B_browseOutputFolder.Location = new System.Drawing.Point(354, 27);
            this.B_browseOutputFolder.Name = "B_browseOutputFolder";
            this.B_browseOutputFolder.Size = new System.Drawing.Size(75, 23);
            this.B_browseOutputFolder.TabIndex = 1;
            this.B_browseOutputFolder.Text = "Browse";
            this.B_browseOutputFolder.UseVisualStyleBackColor = true;
            this.B_browseOutputFolder.Click += new System.EventHandler(this.B_browseOutputFolder_Click);
            // 
            // TB_pathToOutputFolder
            // 
            this.TB_pathToOutputFolder.Location = new System.Drawing.Point(29, 29);
            this.TB_pathToOutputFolder.Name = "TB_pathToOutputFolder";
            this.TB_pathToOutputFolder.Size = new System.Drawing.Size(319, 20);
            this.TB_pathToOutputFolder.TabIndex = 2;
            // 
            // TB_pathToLog
            // 
            this.TB_pathToLog.Location = new System.Drawing.Point(29, 78);
            this.TB_pathToLog.Name = "TB_pathToLog";
            this.TB_pathToLog.Size = new System.Drawing.Size(319, 20);
            this.TB_pathToLog.TabIndex = 5;
            // 
            // B_browseLogFile
            // 
            this.B_browseLogFile.Location = new System.Drawing.Point(354, 76);
            this.B_browseLogFile.Name = "B_browseLogFile";
            this.B_browseLogFile.Size = new System.Drawing.Size(75, 23);
            this.B_browseLogFile.TabIndex = 4;
            this.B_browseLogFile.Text = "Browse";
            this.B_browseLogFile.UseVisualStyleBackColor = true;
            this.B_browseLogFile.Click += new System.EventHandler(this.B_browseLogFile_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Path to log file";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Task Description";
            // 
            // TB_taskDescription
            // 
            this.TB_taskDescription.Location = new System.Drawing.Point(29, 153);
            this.TB_taskDescription.Multiline = true;
            this.TB_taskDescription.Name = "TB_taskDescription";
            this.TB_taskDescription.Size = new System.Drawing.Size(319, 53);
            this.TB_taskDescription.TabIndex = 7;
            // 
            // DTP_startDate
            // 
            this.DTP_startDate.Location = new System.Drawing.Point(32, 226);
            this.DTP_startDate.Name = "DTP_startDate";
            this.DTP_startDate.Size = new System.Drawing.Size(151, 20);
            this.DTP_startDate.TabIndex = 8;
            // 
            // NUD_hour
            // 
            this.NUD_hour.Location = new System.Drawing.Point(212, 225);
            this.NUD_hour.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.NUD_hour.Name = "NUD_hour";
            this.NUD_hour.Size = new System.Drawing.Size(41, 20);
            this.NUD_hour.TabIndex = 9;
            // 
            // NUD_minute
            // 
            this.NUD_minute.Location = new System.Drawing.Point(271, 225);
            this.NUD_minute.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.NUD_minute.Name = "NUD_minute";
            this.NUD_minute.Size = new System.Drawing.Size(41, 20);
            this.NUD_minute.TabIndex = 10;
            // 
            // CB_scheduleType
            // 
            this.CB_scheduleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_scheduleType.FormattingEnabled = true;
            this.CB_scheduleType.Items.AddRange(new object[] {
            "hour(s)",
            "day(s)",
            "week(s)"});
            this.CB_scheduleType.Location = new System.Drawing.Point(119, 262);
            this.CB_scheduleType.Name = "CB_scheduleType";
            this.CB_scheduleType.Size = new System.Drawing.Size(121, 21);
            this.CB_scheduleType.TabIndex = 11;
            // 
            // CB_repeat
            // 
            this.CB_repeat.AutoSize = true;
            this.CB_repeat.Location = new System.Drawing.Point(33, 264);
            this.CB_repeat.Name = "CB_repeat";
            this.CB_repeat.Size = new System.Drawing.Size(61, 17);
            this.CB_repeat.TabIndex = 12;
            this.CB_repeat.Text = "Repeat";
            this.CB_repeat.UseVisualStyleBackColor = true;
            this.CB_repeat.CheckedChanged += new System.EventHandler(this.CB_repeat_CheckedChanged);
            // 
            // B_saveSchedule
            // 
            this.B_saveSchedule.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.B_saveSchedule.Location = new System.Drawing.Point(29, 428);
            this.B_saveSchedule.Name = "B_saveSchedule";
            this.B_saveSchedule.Size = new System.Drawing.Size(158, 23);
            this.B_saveSchedule.TabIndex = 13;
            this.B_saveSchedule.Text = "Save task";
            this.B_saveSchedule.UseVisualStyleBackColor = true;
            this.B_saveSchedule.Click += new System.EventHandler(this.B_saveSchedule_Click);
            // 
            // B_abort
            // 
            this.B_abort.Location = new System.Drawing.Point(271, 428);
            this.B_abort.Name = "B_abort";
            this.B_abort.Size = new System.Drawing.Size(158, 23);
            this.B_abort.TabIndex = 14;
            this.B_abort.Text = "Abort";
            this.B_abort.UseVisualStyleBackColor = true;
            this.B_abort.Click += new System.EventHandler(this.B_abort_Click);
            // 
            // CB_afterShutdownComputer
            // 
            this.CB_afterShutdownComputer.AutoSize = true;
            this.CB_afterShutdownComputer.Location = new System.Drawing.Point(29, 111);
            this.CB_afterShutdownComputer.Name = "CB_afterShutdownComputer";
            this.CB_afterShutdownComputer.Size = new System.Drawing.Size(167, 17);
            this.CB_afterShutdownComputer.TabIndex = 15;
            this.CB_afterShutdownComputer.Text = "After task shutdown computer";
            this.CB_afterShutdownComputer.UseVisualStyleBackColor = true;
            // 
            // NUD_intervalSchedule
            // 
            this.NUD_intervalSchedule.Location = new System.Drawing.Point(272, 262);
            this.NUD_intervalSchedule.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.NUD_intervalSchedule.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUD_intervalSchedule.Name = "NUD_intervalSchedule";
            this.NUD_intervalSchedule.Size = new System.Drawing.Size(41, 20);
            this.NUD_intervalSchedule.TabIndex = 16;
            this.NUD_intervalSchedule.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // GB_permission
            // 
            this.GB_permission.Controls.Add(this.label5);
            this.GB_permission.Controls.Add(this.label4);
            this.GB_permission.Controls.Add(this.TB_password);
            this.GB_permission.Controls.Add(this.TB_fullUserName);
            this.GB_permission.Controls.Add(this.CB_useBellowAccount);
            this.GB_permission.Location = new System.Drawing.Point(29, 301);
            this.GB_permission.Name = "GB_permission";
            this.GB_permission.Size = new System.Drawing.Size(400, 121);
            this.GB_permission.TabIndex = 17;
            this.GB_permission.TabStop = false;
            this.GB_permission.Text = "Permission";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(64, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Password:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Full user name:";
            // 
            // TB_password
            // 
            this.TB_password.Location = new System.Drawing.Point(127, 86);
            this.TB_password.Name = "TB_password";
            this.TB_password.PasswordChar = '*';
            this.TB_password.Size = new System.Drawing.Size(207, 20);
            this.TB_password.TabIndex = 19;
            // 
            // TB_fullUserName
            // 
            this.TB_fullUserName.Location = new System.Drawing.Point(127, 60);
            this.TB_fullUserName.Name = "TB_fullUserName";
            this.TB_fullUserName.Size = new System.Drawing.Size(207, 20);
            this.TB_fullUserName.TabIndex = 18;
            // 
            // CB_useBellowAccount
            // 
            this.CB_useBellowAccount.AutoSize = true;
            this.CB_useBellowAccount.Location = new System.Drawing.Point(13, 30);
            this.CB_useBellowAccount.Name = "CB_useBellowAccount";
            this.CB_useBellowAccount.Size = new System.Drawing.Size(120, 17);
            this.CB_useBellowAccount.TabIndex = 18;
            this.CB_useBellowAccount.Text = "Use bellow account";
            this.CB_useBellowAccount.UseVisualStyleBackColor = true;
            this.CB_useBellowAccount.CheckedChanged += new System.EventHandler(this.CB_useBellowAccount_CheckedChanged);
            // 
            // CB_addingTimestampToPst
            // 
            this.CB_addingTimestampToPst.AutoSize = true;
            this.CB_addingTimestampToPst.Location = new System.Drawing.Point(212, 111);
            this.CB_addingTimestampToPst.Name = "CB_addingTimestampToPst";
            this.CB_addingTimestampToPst.Size = new System.Drawing.Size(201, 17);
            this.CB_addingTimestampToPst.TabIndex = 18;
            this.CB_addingTimestampToPst.Text = "Adding timestamp for coped pst file(s)";
            this.CB_addingTimestampToPst.UseVisualStyleBackColor = true;
            // 
            // F_AddSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 463);
            this.Controls.Add(this.CB_addingTimestampToPst);
            this.Controls.Add(this.GB_permission);
            this.Controls.Add(this.NUD_intervalSchedule);
            this.Controls.Add(this.CB_afterShutdownComputer);
            this.Controls.Add(this.B_abort);
            this.Controls.Add(this.B_saveSchedule);
            this.Controls.Add(this.CB_repeat);
            this.Controls.Add(this.CB_scheduleType);
            this.Controls.Add(this.NUD_minute);
            this.Controls.Add(this.NUD_hour);
            this.Controls.Add(this.DTP_startDate);
            this.Controls.Add(this.TB_taskDescription);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TB_pathToLog);
            this.Controls.Add(this.B_browseLogFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TB_pathToOutputFolder);
            this.Controls.Add(this.B_browseOutputFolder);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "F_AddSchedule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "One Task Schedule";
            this.Load += new System.EventHandler(this.F_AddSchedule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NUD_hour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_minute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_intervalSchedule)).EndInit();
            this.GB_permission.ResumeLayout(false);
            this.GB_permission.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button B_browseOutputFolder;
        private System.Windows.Forms.TextBox TB_pathToOutputFolder;
        private System.Windows.Forms.TextBox TB_pathToLog;
        private System.Windows.Forms.Button B_browseLogFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TB_taskDescription;
        private System.Windows.Forms.DateTimePicker DTP_startDate;
        private System.Windows.Forms.NumericUpDown NUD_hour;
        private System.Windows.Forms.NumericUpDown NUD_minute;
        private System.Windows.Forms.ComboBox CB_scheduleType;
        private System.Windows.Forms.CheckBox CB_repeat;
        private System.Windows.Forms.Button B_saveSchedule;
        private System.Windows.Forms.Button B_abort;
        private System.Windows.Forms.CheckBox CB_afterShutdownComputer;
        private System.Windows.Forms.NumericUpDown NUD_intervalSchedule;
        private System.Windows.Forms.GroupBox GB_permission;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TB_password;
        private System.Windows.Forms.TextBox TB_fullUserName;
        private System.Windows.Forms.CheckBox CB_useBellowAccount;
        private System.Windows.Forms.CheckBox CB_addingTimestampToPst;
    }
}