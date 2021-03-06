﻿﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using Microsoft.Win32.TaskScheduler;
using System.Reflection;

namespace backupmsoutlook.Schedule
{
    public partial class FScheduler : Form
    {
        public FScheduler()
        {
            InitializeComponent();

            Version version = Assembly.GetEntryAssembly().GetName().Version;
            this.Text = this.Text + version.ToString();
        }

        private void B_addSchedule_Click(object sender, EventArgs e)
        {
            F_AddSchedule fad = new F_AddSchedule();
            try
            {
                DialogResult dr = fad.ShowDialog();
                if (dr == System.Windows.Forms.DialogResult.OK)
                {
                    if (SaveTask(fad.PathToOutputFolder, fad.PathToLogFile, fad.DescriptionTask, fad.AfterBackupShutdownComputer, fad.StartBackupDate, fad.IntervalRepeat, fad.KindOfRepeat, fad.RepeatTask, fad.FullUserName, fad.Password, fad.UsePermission, fad.AddingTimestampToPst, fad.CopyMSOutlookRegistrySettings))
                    {
                        MessageBox.Show("Adding task successfull!", "Adding task", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshTasks();
                    }
                }
            }
            finally
            {
                if (fad != null)
                    fad.Dispose();
            }
        }

        private static bool SaveTask(string pathToOutputFolder,
                                     string pathToLogFile,
                                     string description,
                                     bool shutdownAfterBackup,
                                     DateTime startTask,
                                     int intervalCout,
                                     string scheduleType,
                                     bool repeatTask,
                                     string fullUserName,
                                     string password,
                                     bool usePermission,
                                     bool addingTimestampToPst,
                                     bool copyMSOutlookRegistrySettings)
        {
            bool result = false;

            string pathToProgram = ConfigurationManager.AppSettings["pathToBackupmsoutlook"];
            if (pathToProgram == "Path.GetDirectoryName(Application.ExecutablePath)")
                pathToProgram = Path.GetDirectoryName(Application.ExecutablePath) + "\\backupmsoutlook.exe";
            else
                pathToProgram = ConfigurationManager.AppSettings["pathToBackupmsoutlook"];
            try
            {
                using (TaskService ts = new TaskService())
                {
                    TaskDefinition td = ts.NewTask();
                    td.RegistrationInfo.Description = description;

                    //permission
                    td.Principal.LogonType = TaskLogonType.InteractiveToken;
                    td.Principal.RunLevel = TaskRunLevel.Highest;
                    td.Principal.UserId = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

                    //add action
                    td.Actions.Add(new ExecAction(pathToProgram,
                    "\"" + pathToOutputFolder + "\"" + " " +
                    "\"" + pathToLogFile + "\"" + " " +
                    shutdownAfterBackup + " " +
                    addingTimestampToPst + " " +
                    copyMSOutlookRegistrySettings,
                    null));

                    if (repeatTask)
                    {
                        if (scheduleType == "hour(s)")
                        {
                            using (var tt = new Microsoft.Win32.TaskScheduler.TimeTrigger() { StartBoundary = startTask, Enabled = true })
                            {
                                tt.Repetition.Interval = TimeSpan.FromHours(1);
                                td.Triggers.Add(tt);
                            }
                        }
                        else
                            if (scheduleType == "day(s)")
                            {
                                using (Microsoft.Win32.TaskScheduler.DailyTrigger dt = new Microsoft.Win32.TaskScheduler.DailyTrigger() { StartBoundary = startTask, Enabled = true, DaysInterval = (short)intervalCout })
                                {
                                    td.Triggers.Add(dt);
                                }
                            }
                            else
                                if (scheduleType == "week(s)")
                                    using (var wt = new Microsoft.Win32.TaskScheduler.WeeklyTrigger() { StartBoundary = startTask, Enabled = true, WeeksInterval = (short)intervalCout })
                                    {
                                        td.Triggers.Add(wt);
                                    }
                    }
                    else
                    {
                        var tt = new Microsoft.Win32.TaskScheduler.TimeTrigger() 
                        { 
                            StartBoundary = startTask,
                            EndBoundary = startTask.AddHours(12), //12 hours limit execution
                            Enabled = true 
                        };
                        td.Triggers.Add(tt);
                    }

                    //settings
                    td.Settings.Hidden = true;
                    td.Settings.MultipleInstances = Microsoft.Win32.TaskScheduler.TaskInstancesPolicy.IgnoreNew;
                    td.Settings.DisallowStartIfOnBatteries = true;
                    td.Settings.StopIfGoingOnBatteries = true;
                    td.Settings.AllowHardTerminate = true;
                    td.Settings.StartWhenAvailable = false;
                    td.Settings.RunOnlyIfNetworkAvailable = false;
                    td.Settings.Priority = System.Diagnostics.ProcessPriorityClass.High;
                    td.Settings.IdleSettings.StopOnIdleEnd = true;
                    td.Settings.IdleSettings.RestartOnIdle = false;
                    td.Settings.AllowDemandStart = true;
                    td.Settings.Enabled = true;
                    td.Settings.RunOnlyIfIdle = false;
                    td.Settings.WakeToRun = false;
                    td.RegistrationInfo.Date = DateTime.Now;
                    td.Settings.ExecutionTimeLimit = new TimeSpan(12, 0, 0); //12 hours limit execution
                    td.Settings.DeleteExpiredTaskAfter = new TimeSpan(30 * 24, 0, 0); //delete task
                    //from scheduler
                    //after 30 days

                    //author
                    td.RegistrationInfo.Author = td.Principal.UserId;

                    //register task
                    string taskName = Get_NextTaskName();

                    if (usePermission)
                    {
                        td.Principal.LogonType = Microsoft.Win32.TaskScheduler.TaskLogonType.Password;
                        ts.RootFolder.RegisterTaskDefinition(taskName,
                        td,
                        Microsoft.Win32.TaskScheduler.TaskCreation.CreateOrUpdate,
                        fullUserName,
                        password,
                        Microsoft.Win32.TaskScheduler.TaskLogonType.Password,
                        null);
                    }
                    else
                        ts.RootFolder.RegisterTaskDefinition(taskName, td);
                }

                result = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Adding task error -> " + ex.Message);
            }

            return result;
        }

        private void B_advancedEdit_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Environment.SystemDirectory +
            "//" +
            "taskschd.msc", "/s");
        }

        private void F_MainSchedule_Load(object sender, EventArgs e)
        {
            RefreshTasks();
        }

        private static string Get_NextTaskName()
        {
            int no = 1;

            const string result = "backupmsoutlook_";
            while (CheckTaskName(result + no))
            {
                no++;
            }

            return result + no;
        }

        private static bool CheckTaskName(string taskName)
        {
            bool result = false;

            using (Microsoft.Win32.TaskScheduler.TaskService ts = new Microsoft.Win32.TaskScheduler.TaskService())
            {
                using (Microsoft.Win32.TaskScheduler.TaskFolder taskFolder = ts.GetFolder(@"\"))
                {
                    foreach (Task t in taskFolder.Tasks)
                    {
                        if (t.Name.Contains(taskName))
                        {
                            result = true;
                        }
                    }
                }
            }

            return result;
        }

        private void RefreshTasks()
        {
            DGV_taskBackumsoutlook.Rows.Clear();

            using (Microsoft.Win32.TaskScheduler.TaskService ts = new Microsoft.Win32.TaskScheduler.TaskService())
            {
                using (Microsoft.Win32.TaskScheduler.TaskFolder taskFolder = ts.GetFolder(@"\"))
                {
                    foreach (Task t in taskFolder.Tasks)
                    {
                        if (t.Name.Contains("backupmsoutlook_"))
                        {
                            TaskDefinition td = t.Definition;
                            string lastRun = t.LastRunTime.ToString();
                            if (lastRun.Contains("1899"))
                                lastRun = string.Empty;
                            string actions = td.Actions[0].ToString();
                            if (actions.Contains("\t"))
                                actions = actions.Replace("\t", " -> ");
                            string[] row = new string[] { t.Name, t.State.ToString(), actions, t.NextRunTime.ToString(), lastRun, "0x" + t.LastTaskResult, td.RegistrationInfo.Author, td.RegistrationInfo.Date.ToString() };
                            DGV_taskBackumsoutlook.Rows.Add(row);
                            DGV_taskBackumsoutlook.Rows[DGV_taskBackumsoutlook.Rows.Count - 1].Selected = true;
                        }
                    }
                }
            }

            if (DGV_taskBackumsoutlook.Rows.Count > 0)
            {
                DGV_taskBackumsoutlook.Rows[0].Cells[0].Selected = false;
                DGV_taskBackumsoutlook.Rows[DGV_taskBackumsoutlook.Rows.Count - 1].Selected = true;
            }
        }

        private void B_refreshTasks_Click(object sender, EventArgs e)
        {
            RefreshTasks();
        }

        private void B_removeSchedule_Click(object sender, EventArgs e)
        {
            Int32 selectedCellCount = DGV_taskBackumsoutlook.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedCellCount > 0)
            {
                foreach (DataGridViewRow row in DGV_taskBackumsoutlook.Rows)
                {
                    if (row.Selected)
                    {
                        string taskName = row.Cells[0].Value.ToString();
                        DialogResult dr = MessageBox.Show("Are you sure, delete task name = " + taskName,
                        "Remove task",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                        if (dr == System.Windows.Forms.DialogResult.Yes)
                        {
                            Microsoft.Win32.TaskScheduler.TaskService ts = new TaskService();
                            try
                            {
                                using (TaskFolder taskFolder = ts.GetFolder(@"\"))
                                {
                                    try
                                    {
                                        taskFolder.DeleteTask(taskName);
                                        RefreshTasks();
                                        //MessageBox.Show(String.Format("Successfull delete task -> {0}", taskName), "Delete task", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(String.Format("Failure delete task -> {0}\nError -> {1}", taskName, ex.Message), "Delete task", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                            finally
                            {
                                if (ts != null)
                                    ts.Dispose();
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Not selected task to delete",
                "Delete task",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
        }

        private void DGV_taskBackumsoutlook_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Int32 selectedCellCount = DGV_taskBackumsoutlook.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedCellCount > 0)
            {
                DGV_taskBackumsoutlook.Rows[e.RowIndex].Selected = true;
            }
        }
    }
}