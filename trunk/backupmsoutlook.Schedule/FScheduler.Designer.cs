namespace backupmsoutlook.Schedule
{
    partial class FScheduler
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FScheduler));
            this.B_addSchedule = new System.Windows.Forms.Button();
            this.B_advancedEdit = new System.Windows.Forms.Button();
            this.B_removeSchedule = new System.Windows.Forms.Button();
            this.B_refreshTasks = new System.Windows.Forms.Button();
            this.DGV_taskBackumsoutlook = new System.Windows.Forms.DataGridView();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.state = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.execution = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeNextRun = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeLastRun = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resultLastExecution = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.author = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_taskBackumsoutlook)).BeginInit();
            this.SuspendLayout();
            // 
            // B_addSchedule
            // 
            this.B_addSchedule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.B_addSchedule.Location = new System.Drawing.Point(326, 12);
            this.B_addSchedule.Name = "B_addSchedule";
            this.B_addSchedule.Size = new System.Drawing.Size(99, 23);
            this.B_addSchedule.TabIndex = 0;
            this.B_addSchedule.Text = "Add";
            this.B_addSchedule.UseVisualStyleBackColor = true;
            this.B_addSchedule.Click += new System.EventHandler(this.B_addSchedule_Click);
            // 
            // B_advancedEdit
            // 
            this.B_advancedEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.B_advancedEdit.Location = new System.Drawing.Point(326, 41);
            this.B_advancedEdit.Name = "B_advancedEdit";
            this.B_advancedEdit.Size = new System.Drawing.Size(99, 23);
            this.B_advancedEdit.TabIndex = 1;
            this.B_advancedEdit.Text = "Advanced edit";
            this.B_advancedEdit.UseVisualStyleBackColor = true;
            this.B_advancedEdit.Click += new System.EventHandler(this.B_advancedEdit_Click);
            // 
            // B_removeSchedule
            // 
            this.B_removeSchedule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.B_removeSchedule.Location = new System.Drawing.Point(326, 70);
            this.B_removeSchedule.Name = "B_removeSchedule";
            this.B_removeSchedule.Size = new System.Drawing.Size(99, 23);
            this.B_removeSchedule.TabIndex = 3;
            this.B_removeSchedule.Text = "Delete";
            this.B_removeSchedule.UseVisualStyleBackColor = true;
            this.B_removeSchedule.Click += new System.EventHandler(this.B_removeSchedule_Click);
            // 
            // B_refreshTasks
            // 
            this.B_refreshTasks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.B_refreshTasks.Location = new System.Drawing.Point(326, 187);
            this.B_refreshTasks.Name = "B_refreshTasks";
            this.B_refreshTasks.Size = new System.Drawing.Size(99, 23);
            this.B_refreshTasks.TabIndex = 5;
            this.B_refreshTasks.Text = "Refresh tasks";
            this.B_refreshTasks.UseVisualStyleBackColor = true;
            this.B_refreshTasks.Click += new System.EventHandler(this.B_refreshTasks_Click);
            // 
            // DGV_taskBackumsoutlook
            // 
            this.DGV_taskBackumsoutlook.AllowUserToAddRows = false;
            this.DGV_taskBackumsoutlook.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV_taskBackumsoutlook.BackgroundColor = System.Drawing.Color.White;
            this.DGV_taskBackumsoutlook.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Name,
            this.state,
            this.execution,
            this.timeNextRun,
            this.timeLastRun,
            this.resultLastExecution,
            this.author,
            this.createTime});
            this.DGV_taskBackumsoutlook.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DGV_taskBackumsoutlook.Location = new System.Drawing.Point(12, 12);
            this.DGV_taskBackumsoutlook.MultiSelect = false;
            this.DGV_taskBackumsoutlook.Name = "DGV_taskBackumsoutlook";
            this.DGV_taskBackumsoutlook.Size = new System.Drawing.Size(304, 198);
            this.DGV_taskBackumsoutlook.TabIndex = 6;
            this.DGV_taskBackumsoutlook.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_taskBackumsoutlook_CellClick);
            // 
            // Name
            // 
            this.Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Name.HeaderText = "name";
            this.Name.Name = "Name";
            this.Name.ReadOnly = true;
            this.Name.Width = 58;
            // 
            // state
            // 
            this.state.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.state.DefaultCellStyle = dataGridViewCellStyle1;
            this.state.HeaderText = "State";
            this.state.Name = "state";
            this.state.ReadOnly = true;
            this.state.Width = 57;
            // 
            // execution
            // 
            this.execution.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.execution.HeaderText = "Execution";
            this.execution.Name = "execution";
            this.execution.ReadOnly = true;
            this.execution.Width = 79;
            // 
            // timeNextRun
            // 
            this.timeNextRun.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.timeNextRun.HeaderText = "Time Next Run";
            this.timeNextRun.Name = "timeNextRun";
            this.timeNextRun.ReadOnly = true;
            this.timeNextRun.Width = 103;
            // 
            // timeLastRun
            // 
            this.timeLastRun.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.timeLastRun.HeaderText = "Time Last Run";
            this.timeLastRun.Name = "timeLastRun";
            this.timeLastRun.ReadOnly = true;
            this.timeLastRun.Width = 101;
            // 
            // resultLastExecution
            // 
            this.resultLastExecution.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.resultLastExecution.DefaultCellStyle = dataGridViewCellStyle2;
            this.resultLastExecution.HeaderText = "Result Last Execution";
            this.resultLastExecution.Name = "resultLastExecution";
            this.resultLastExecution.ReadOnly = true;
            this.resultLastExecution.Width = 135;
            // 
            // author
            // 
            this.author.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.author.HeaderText = "Author";
            this.author.Name = "author";
            this.author.ReadOnly = true;
            this.author.Width = 63;
            // 
            // createTime
            // 
            this.createTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.createTime.HeaderText = "Create time";
            this.createTime.Name = "createTime";
            this.createTime.ReadOnly = true;
            this.createTime.Width = 85;
            // 
            // FScheduler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 222);
            this.Controls.Add(this.DGV_taskBackumsoutlook);
            this.Controls.Add(this.B_refreshTasks);
            this.Controls.Add(this.B_removeSchedule);
            this.Controls.Add(this.B_advancedEdit);
            this.Controls.Add(this.B_addSchedule);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            //this.Name = "FScheduler";
            this.Text = "backupmsoutlook scheduler v.1.2";
            this.Load += new System.EventHandler(this.F_MainSchedule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_taskBackumsoutlook)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button B_addSchedule;
        private System.Windows.Forms.Button B_advancedEdit;
        private System.Windows.Forms.Button B_removeSchedule;
        private System.Windows.Forms.Button B_refreshTasks;
        private System.Windows.Forms.DataGridView DGV_taskBackumsoutlook;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn state;
        private System.Windows.Forms.DataGridViewTextBoxColumn execution;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeNextRun;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeLastRun;
        private System.Windows.Forms.DataGridViewTextBoxColumn resultLastExecution;
        private System.Windows.Forms.DataGridViewTextBoxColumn author;
        private System.Windows.Forms.DataGridViewTextBoxColumn createTime;
    }
}

