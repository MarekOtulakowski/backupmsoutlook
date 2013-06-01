using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.DirectoryServices.AccountManagement;

namespace backupmsoutlook.Schedule
{
    public partial class F_AddSchedule : Form
    {
        public string PathToOutputFolder { get; set; }
        public string PathToLogFile { get; set; }
        public bool AfterBackupShutdownComputer { get; set; }
        public string DescriptionTask { get; set; }
        public DateTime StartBackupDate { get; set; }
        public bool RepeatTask { get; set; }
        public string KindOfRepeat { get; set; }
        public int IntervalRepeat { get; set; }
        public bool UsePermission { get; set; }
        public string FullUserName { get; set; }
        public string Password { get; set; }
        public bool AddingTimestampToPst { get; set; }
        public bool CopyMSOutlookRegistrySettings { get; set; }

        public F_AddSchedule()
        {
            InitializeComponent();
        }

        private void B_abort_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void B_browseOutputFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.RootFolder = Environment.SpecialFolder.Desktop;
                DialogResult dr = fbd.ShowDialog();
                if (dr == System.Windows.Forms.DialogResult.OK)
                {
                    TB_pathToOutputFolder.Text = fbd.SelectedPath;
                }
            }
        }

        private void B_browseLogFile_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString();
                sfd.Filter = "Text file|*.txt";
                DialogResult dr = sfd.ShowDialog();
                if (dr == System.Windows.Forms.DialogResult.OK)
                {
                    TB_pathToLog.Text = sfd.FileName;
                }
            }
        }

        private void F_AddSchedule_Load(object sender, EventArgs e)
        {
            CB_scheduleType.SelectedIndex = 0;
            CB_scheduleType.Enabled = false;
            NUD_intervalSchedule.Enabled = false;

            TB_taskDescription.Text = "Task copy all using pst file from Microsoft Outlook default profile\nThis task using program backupmsoutlook v.1.0.2";

            NUD_hour.Value = DateTime.Now.Hour;
            NUD_minute.Value = DateTime.Now.AddMinutes(5).Minute;

            //TB_fullUserName.Enabled = false;
            //TB_password.Enabled = false;
            TB_fullUserName.Text = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        }

        private void CB_repeat_CheckedChanged(object sender, EventArgs e)
        {
            if (CB_repeat.Checked)
            {
                CB_scheduleType.Enabled = true;
                NUD_intervalSchedule.Enabled = true;
            }
            else
            {
                CB_scheduleType.Enabled = false;
                NUD_intervalSchedule.Enabled = false;
            }
        }

        private void B_saveSchedule_Click(object sender, EventArgs e)
        {
            //simple validation
            bool validateResult = true;
            List<bool> listValidate = new List<bool>();
            bool bPathToOutputFolder = ValidatePathToOutputFolder();
            listValidate.Add(bPathToOutputFolder);
            bool bPathToLog = ValidatePathToLog();
            listValidate.Add(bPathToLog);
            bool bFullUserName = ValidateFullUserName();
            listValidate.Add(bFullUserName);
            bool bPassword = ValidatePassword();
            listValidate.Add(bPassword);

            foreach (bool oVal in listValidate)
            {
                if (!oVal) 
                    validateResult = false;
            }

            if (validateResult)
                B_saveSchedule.DialogResult = DialogResult.OK;
            else
            {
                MessageBox.Show("Please fill in all text fields!",
                                "Adding new task",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            PathToOutputFolder = TB_pathToOutputFolder.Text;
            PathToLogFile = TB_pathToLog.Text;
            DescriptionTask = TB_taskDescription.Text;
            if (CB_afterShutdownComputer.Checked)
                AfterBackupShutdownComputer = true;
            else
                AfterBackupShutdownComputer = false;

            if (CB_repeat.Checked)
                RepeatTask = true;
            else
                RepeatTask = false;

            if (CB_copyMSOutlookRegistrySettings.Checked)
                CopyMSOutlookRegistrySettings = true;
            else
                CopyMSOutlookRegistrySettings = false;

            KindOfRepeat = CB_scheduleType.SelectedItem.ToString();

            DateTime userChooseDateAndTime = new DateTime(DTP_startDate.Value.Year, DTP_startDate.Value.Month, DTP_startDate.Value.Day, Int32.Parse(NUD_hour.Value.ToString()), Int32.Parse(NUD_minute.Value.ToString()), 0);

            StartBackupDate = userChooseDateAndTime;

            IntervalRepeat = (int)NUD_intervalSchedule.Value;

            if (CB_useBellowAccount.Checked)
                UsePermission = true;
            else
                UsePermission = false;

            FullUserName = TB_fullUserName.Text;
            Password = TB_password.Text;

            if (CB_addingTimestampToPst.Checked)
                AddingTimestampToPst = true;
            else
                AddingTimestampToPst = false;
        }

        private void CB_useBellowAccount_CheckedChanged(object sender, EventArgs e)
        {
            if (CB_useBellowAccount.Checked)
            {
                TB_fullUserName.Enabled = true;
                TB_password.Enabled = true;
            }
            else
            {
                TB_fullUserName.Enabled = false;
                TB_password.Enabled = false;
            }
        }

        private void TB_pathToOutputFolder_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidatePathToOutputFolder();
        }

        private bool ValidatePathToOutputFolder()
        { 
            if (string.IsNullOrEmpty(TB_pathToOutputFolder.Text))
            {
                ER_pathToOutputFolder.SetError(TB_pathToOutputFolder, "Path to output folder is empty");
                return false;
            }
            else if (!Directory.Exists(TB_pathToOutputFolder.Text))
            {
                ER_pathToOutputFolder.SetError(TB_pathToOutputFolder, "Directory does not exist");
                return false;
            }
            else
            {
                ER_pathToOutputFolder.SetError(TB_pathToOutputFolder, string.Empty);
                return true;
            }
        }

        private void TB_pathToLog_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidatePathToLog();
        }

        private bool ValidatePathToLog()
        {
            if (string.IsNullOrEmpty(TB_pathToLog.Text))
            {
                ER_pathToLogFile.SetError(TB_pathToLog, "Path to log file is empty");
                return false;
            }
            else
            {
                ER_pathToLogFile.SetError(TB_pathToLog, string.Empty);
                return true;
            }
        }

        private void TB_fullUserName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateFullUserName();
        }

        private bool ValidateFullUserName()
        {
            if (string.IsNullOrEmpty(TB_fullUserName.Text))
            {
                ER_fullUserName.SetError(TB_fullUserName, "User name is empty");
                return false;
            }
                //too slow checking about 5 sec
            //else if (!string.IsNullOrEmpty(TB_fullUserName.Text))
            //{
            //    return UserExist(TB_fullUserName.Text);
            //}
            else
            {
                ER_fullUserName.SetError(TB_fullUserName, string.Empty);
                return true;
            }
        }

        private void TB_password_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidatePassword();
        }

        private bool ValidatePassword()
        {
            if (string.IsNullOrEmpty(TB_password.Text))
            {
                ER_password.SetError(TB_password, "Password is empty");
                return false;
            }
            else
            {
                ER_password.SetError(TB_password, string.Empty);
                return true;
            }
        }

        //not using becouse it's to slow check
        //private bool UserExist(string userName)
        //{
        //    using (PrincipalContext pc = new PrincipalContext(ContextType.Machine))
        //    {
        //        UserPrincipal up = UserPrincipal.FindByIdentity(
        //            pc,
        //            IdentityType.SamAccountName,
        //            "UserName");

        //        return (up != null);
        //    }
        //}
    }
}
