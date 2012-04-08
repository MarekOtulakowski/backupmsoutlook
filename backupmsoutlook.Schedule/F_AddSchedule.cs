using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

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

            TB_taskDescription.Text = "Task copy all using pst file from Microsoft Outlook default profile\nThis task using program backupmsoutlook v.1.1";

            NUD_hour.Value = DateTime.Now.Hour;
            NUD_minute.Value = DateTime.Now.AddMinutes(5).Minute;

            TB_fullUserName.Enabled = false;
            TB_password.Enabled = false;
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
    }
}
