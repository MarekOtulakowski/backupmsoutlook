#region UsingDirectives
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;
using System.Linq;

#endregion

namespace backupmsoutlook.Library
{
    /// <summary>
    /// Main class to manage library
    /// </summary>
    public static class Manager
    {
        #region Variables
        private static string OutputFolder { get; set; }
        public static string PathToLog { get; set; }
        public static bool AddingTimestampForPstFiles { get; set; }
        private static string PathToDefaultPst { get; set; }
        public static bool CopyMSOutlookRegistrySettings { get; set; }
        #endregion

        #region PublicFunction
        /// <summary>
        /// Return list pst paths
        /// </summary>
        /// <returns>lists pst</returns>
        public static List<string> GetPstPathsFromDefaultOutlookProfile()
        {
            List<string> listToPst = new List<string>();

            try
            {
                //check Outlook version
                RegistryKey regVersionOutlook = Registry.LocalMachine.OpenSubKey("Software").OpenSubKey("Microsoft").OpenSubKey("Windows").OpenSubKey("CurrentVersion").OpenSubKey("App Paths").OpenSubKey("OUTLOOK.EXE");
                string pathToOutlook = string.Empty;
                pathToOutlook = (string)regVersionOutlook.GetValue("Path");
                pathToOutlook = pathToOutlook + "OUTLOOK.EXE";
                int noVersion = GetMajorVersion(pathToOutlook);

                //get paths to archive actually using
                using (RegistryKey reg = Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("Microsoft").OpenSubKey("Windows NT").OpenSubKey("CurrentVersion").OpenSubKey("Windows Messaging Subsystem").OpenSubKey("Profiles"))
                {
                    string defaultProfile = (string)reg.GetValue("DefaultProfile");
                    if (string.IsNullOrEmpty(defaultProfile))
                        defaultProfile = "Outlook";

                    using (RegistryKey regInDefaultProfile = Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("Microsoft").OpenSubKey("Windows NT").OpenSubKey("CurrentVersion").OpenSubKey("Windows Messaging Subsystem").OpenSubKey("Profiles").OpenSubKey(defaultProfile))
                    {
                        string[] tabAllSubKeyNames = regInDefaultProfile.GetSubKeyNames();
                        for (int i = 0; i < tabAllSubKeyNames.Length; i++)
                        {
                            //add all actual using archive without default pst
                            using (RegistryKey regAdditionalPst = Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("Microsoft").OpenSubKey("Windows NT").OpenSubKey("CurrentVersion").OpenSubKey("Windows Messaging Subsystem").OpenSubKey("Profiles").OpenSubKey(defaultProfile).OpenSubKey(tabAllSubKeyNames[i]))
                            {
                                byte[] bytes = (byte[])regAdditionalPst.GetValue("01020fff");
                                if (bytes != null)
                                {
                                    if (noVersion < 13)
                                    {
                                        //for MS Outlook 2003, 2007
                                        string output = Encoding.Unicode.GetString(bytes, 12, bytes.Length - 12);
                                        output = output.Substring(21, output.Length - 22);
                                        byte[] bytes2 = (byte[])regAdditionalPst.GetValue("001f3d09");
                                        string output2;
                                        output2 = Encoding.Unicode.GetString(bytes2);
                                        if (!string.IsNullOrEmpty(output2))
                                            if (output2 == "MSPST MS\0")
                                            {
                                                if (FileExists(output))
                                                    listToPst.Add(output);
                                            }
                                            else
                                                if (output2 == "MSUPST MS\0")
                                                {
                                                    if (FileExists(output))
                                                        listToPst.Add(output);
                                                }
                                                else
                                                    if (output2 == "INTERSTOR\0")
                                                    {
                                                        output = output.Replace("\0", "");
                                                        if (FileExists(output))
                                                            listToPst.Add(output);
                                                    }
                                    }
                                    else
                                    {
                                        //for MS Outlook 2010
                                        byte[] bytes2 = (byte[])regAdditionalPst.GetValue("001f3d09");
                                        string output2;
                                        output2 = Encoding.Unicode.GetString(bytes2);
                                        string output4;
                                        if (output2 == "MSPST MS\0")
                                        {
                                            output4 = Encoding.Unicode.GetString(bytes, 12, bytes.Length - 12);
                                            output4 = output4.Substring(21, output4.Length - 22);
                                            if (FileExists(output4))
                                                listToPst.Add(output4);
                                        }
                                        else
                                            if (output2 == "MSUPST MS\0")
                                            {
                                                output4 = Encoding.Unicode.GetString(bytes, 12, bytes.Length - 12);
                                                output4 = output4.Substring(21, output4.Length - 22);
                                                if (FileExists(output4))
                                                    listToPst.Add(output4);
                                            }
                                            else
                                                if (output2 == "INTERSTOR\0")
                                                {
                                                    output4 = Encoding.Unicode.GetString(bytes, 12, bytes.Length - 12);
                                                    output4 = output4.Substring(23, output4.Length - 24);
                                                    if (FileExists(output4))
                                                        listToPst.Add(output4);
                                                }
                                    }
                                }
                            }

                            //add main Outlook profile
                            using (RegistryKey regDefaultPst = Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("Microsoft").OpenSubKey("Windows NT").OpenSubKey("CurrentVersion").OpenSubKey("Windows Messaging Subsystem").OpenSubKey("Profiles").OpenSubKey(defaultProfile).OpenSubKey(tabAllSubKeyNames[i]))
                            {
                                byte[] bytes3 = (byte[])regDefaultPst.GetValue("1102039b");
                                if (bytes3 != null)
                                {
                                    string output3 = Encoding.Unicode.GetString(bytes3, 12, bytes3.Length - 12);
                                    output3 = output3.Substring(27, output3.Length - 29);
                                    if (noVersion < 12)
                                        //for MS Outlook 2003
                                        if (FileExists(output3))
                                            listToPst.Add(output3);
                                        else
                                            if (noVersion < 13)
                                            {
                                                //for MS Outlook 2007
                                                if (FileExists(output3 + "t"))
                                                    listToPst.Add(output3 + "t");
                                            }
                                            else
                                            {
                                                //for MS Outlook 2010
                                                output3 = output3.Substring(4, output3.Length - 4);
                                                if (FileExists(output3 + "t"))
                                                    listToPst.Add(output3 + "t");
                                            }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SaveToLog(String.Format("Error durring read pst file - Outlook 2007 or newest Detail: {0}", ex.Message), ESaveLogCategory.ERROR);
            }

            return listToPst;
        }

        /// <summary>
        /// Run backup using hobocopy
        /// </summary>
        /// <returns>true if backup result is true</returns>
        public static bool RunBackup()
        {
            bool result = false;
            string uniqueSig;

            //close hobocopy different process
            try
            {
                Process[] processlist = Process.GetProcesses();
                List<int> listHobocopyProcessId = new List<int>();
                foreach(Process theprocess in processlist)
                {
                    if (theprocess.ProcessName.ToLower().Contains("hobocopy"))
                    {
                        listHobocopyProcessId.Add(theprocess.Id);
                    }
                }
                while (listHobocopyProcessId.Count > 0)
                {
                    Process process = Process.GetProcessById(listHobocopyProcessId[0]);                    
                    int idProcess = process.Id;
                    string nameProcess = process.ProcessName;
                    process.Kill();
                    listHobocopyProcessId.Remove(listHobocopyProcessId[0]);
                    SaveToLog(String.Format("Force close process id = {0}, name = {1}", idProcess, nameProcess), ESaveLogCategory.WARNING);
                }
            }
            catch (Exception e3)
            {
                SaveToLog(String.Format("Error close hobocopy different running process Detail: {0}", e3.Message), ESaveLogCategory.WARNING);
            }

            try
            {
                List<string> listParametrs = Manager.GetHobocopyParametrs();

                listParametrs.ForEach(hobocopyParametrs =>
                {
                    try
                    {
                        ProcessStartInfo psi = new ProcessStartInfo();
                        if (Environment.OSVersion.Version.Major >= 6)
                            psi.Verb = "runas";
                        psi.UseShellExecute = true;
                        psi.WindowStyle = ProcessWindowStyle.Hidden;
                        psi.CreateNoWindow = true;
                        psi.FileName = HobocopyPath;
                        psi.Arguments = hobocopyParametrs;
                        using (Process p = Process.Start(psi))
                            p.WaitForExit();
                        SaveToLog(string.Format("Backup pst file use command: {0}{1} {2}", Environment.NewLine, "        " + HobocopyPath, hobocopyParametrs), ESaveLogCategory.INFO);
                    }
                    catch (Exception e2)
                    {
                        SaveToLog(String.Format("Error durring backup pst file used command {0} {1} Detail: {2}", HobocopyPath, hobocopyParametrs, e2.Message), ESaveLogCategory.ERROR);
                    }

                    if (AddingTimestampForPstFiles)
                    {
                        try
                        {
                            //rename file adding backup date
                            uniqueSig = DateTime.Now.ToString();
                            uniqueSig = uniqueSig.Replace(":", "-");
                            uniqueSig = uniqueSig.Replace(" ", "-");
                            uniqueSig = uniqueSig.Replace("/", "-");
                            string fileName = hobocopyParametrs.Substring(0, hobocopyParametrs.Length - 1);
                            fileName = fileName.Substring(fileName.LastIndexOf("\"") + 1, fileName.Length - fileName.LastIndexOf("\"") - 1);
                            string fullPath = String.Format("{0}\\{1}", OutputFolder, fileName);
                            if (File.Exists(fullPath))
                            {
                                string newFileName = fileName.Substring(0, fileName.LastIndexOf("."));

                                //rename backup pst file (default - one, archive - others)
                                if (PathToDefaultPst == hobocopyParametrs)
                                    newFileName = String.Format("{0}_{1}.pst", newFileName, "DEFAULT_" + uniqueSig);
                                else
                                    newFileName = String.Format("{0}_{1}.pst", newFileName, "ARCHIVE_" + uniqueSig);

                                newFileName = String.Format("{0}\\{1}", OutputFolder, newFileName);
                                File.Move(fullPath, newFileName);
                                SaveToLog(String.Format("Change file name:{0}{1} => {2}", Environment.NewLine, "        " + fullPath, newFileName), ESaveLogCategory.INFO);
                            }
                        }
                        catch (Exception e)
                        {
                            SaveToLog(String.Format("Error durring adding timestamp for Pst files Detail: {0}", e.Message), ESaveLogCategory.ERROR);
                        }
                    }
                });

                if (CopyMSOutlookRegistrySettings)
                {
                    try
                    {
                        //rename file adding backup date
                        uniqueSig = DateTime.Now.ToString();
                        uniqueSig = uniqueSig.Replace(":", "-");
                        uniqueSig = uniqueSig.Replace(" ", "-");
                        uniqueSig = uniqueSig.Replace("/", "-");
                        SaveRegistryOutlookSettingInFile(OutputFolder +
                                                         "\\registryCopy" +
                                                         uniqueSig +
                                                         ".reg");
                    }
                    catch (Exception ex2)
                    {
                        SaveToLog(String.Format("Error durring save registryCopy.reg Detail: {0}", ex2.Message), ESaveLogCategory.ERROR);
                    }
                }

                result = true;
            }
            catch (Exception ex)
            {
                SaveToLog(String.Format("Error durring run backup Detail: {0}",  ex.Message), ESaveLogCategory.ERROR);
            }

            return result;
        }

        /// <summary>
        /// Export registry settings include all profiles MS Outlook
        /// </summary>
        /// <param name="pathToRegFile">path to *.reg output file</param>
        /// <returns>return result function, true if export is correct</returns>
        private static bool SaveRegistryOutlookSettingInFile(string pathToRegFile)
        {
            try
            {
                string fullRegPath = "\"" + @"HKEY_CURRENT_USER\Software\Microsoft\Windows NT\CurrentVersion\Windows Messaging Subsystem" + "\"";
                string command = @"/E " + pathToRegFile + " " + fullRegPath;
                var psiRegistry = new ProcessStartInfo();
                psiRegistry.FileName = "regedit.exe";
                psiRegistry.Arguments = command;
                if (Environment.OSVersion.Version.Major >= 6)
                {
                    psiRegistry.Verb = "runas";
                    psiRegistry.UseShellExecute = true;
                }
                else
                {
                    psiRegistry.UseShellExecute = true;
                }
                psiRegistry.CreateNoWindow = true;
                psiRegistry.WindowStyle = ProcessWindowStyle.Hidden;
                System.Diagnostics.Process pRegistry = Process.Start(psiRegistry);
            }
            catch (Exception ex)
            {
                SaveToLog(String.Format("Copy registry setting isn't correclty! Detail: {0}", ex.Message), ESaveLogCategory.ERROR);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Save empty line to log
        /// </summary>
        public static void SaveSeparateLineToLog()
        {
            StreamWriter log = !File.Exists(PathToLog) ? new StreamWriter(PathToLog) : File.AppendText(PathToLog);

            try
            {
                log.WriteLine();
            }
            catch
            {
            }

            log.Close();
        }

        /// <summary>
        /// Save information to log
        /// </summary>
        /// <param name="message"></param>
        public static void SaveToLog(string message, ESaveLogCategory category)
        {
            StreamWriter log = !File.Exists(PathToLog) ? new StreamWriter(PathToLog) : File.AppendText(PathToLog);

            try
            {
                log.WriteLine(String.Format("{0} -> {1} -> {2}", category, DateTime.Now, message));
            }
            catch
            {
            }

            log.Close();
        }

        /// <summary>
        /// Set initialize variable
        /// </summary>
        /// <param name="_outputFolder">output path to backup folder</param>
        /// <param name="_pathToLog">path to log file</param>
        /// <param name="_addingTimestampForPstFiles">bool adding timestamp to backup file name</param>
        /// <returns>true if initialize ok</returns>
        public static bool Initialize(string _outputFolder,
        string _pathToLog,
        bool _addingTimestampForPstFiles)
        {
            bool result = false;

            if (!string.IsNullOrEmpty(_outputFolder) &&
            !string.IsNullOrEmpty(_pathToLog))
            {
                OutputFolder = _outputFolder;
                PathToLog = _pathToLog;

                try
                {
                    AddingTimestampForPstFiles = _addingTimestampForPstFiles;
                }
                catch
                {
                    AddingTimestampForPstFiles = false;
                    return false;
                }

                result = true;
            }

            return result;
        }
        #endregion

        #region PrivateFunction
        /// <summary>
        /// Return string.Empty value
        /// </summary>
        private static string GetStringEmpty
        {
            get
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Return file.exist question
        /// </summary>
        /// <param name="path">path to file</param>
        /// <returns>true if file exist</returns>
        private static bool FileExists(string path)
        {
            try
            {
                if (File.Exists(path))
                    return true;
                else
                {
                    SaveToLog(String.Format("Pst file read from registry: \"{0}\" doesn't exist on disk or is unavailable, skip add file to backup", path), ESaveLogCategory.WARNING);
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Return full hobocopy argument
        /// </summary>
        /// <param name="oCommand">path to pst file</param>
        /// <returns>arguments for hobocopy</returns>
        private static string GetFullHobocopyArguments(string oCommand)
        {
            return String.Format("\"{0}\" \"{1}\" \"{2}\"", oCommand.Substring(0, oCommand.LastIndexOf("\\")), OutputFolder, oCommand.Substring(oCommand.LastIndexOf("\\") + 1, oCommand.Length - oCommand.LastIndexOf("\\") - 1));
        }

        /// <summary>
        /// Return list hobocopy arguments (for few pst files)
        /// </summary>
        /// <returns>list hobocopy parametrs</returns>
        private static List<string> GetHobocopyParametrs()
        {
            List<string> listHobocopyParametrs = new List<string>();
            List<string> listPst = GetPstPathsFromDefaultOutlookProfile();

            if (listPst.Count > 1)
                PathToDefaultPst = listPst[listPst.Count - 1];
            else if (listPst.Count == 1)
                PathToDefaultPst = listPst[0];
            else
            {
                SaveToLog("List Pst files to backup is empty, nothing to backup", ESaveLogCategory.WARNING);
                return listHobocopyParametrs;
            }

            string paths = string.Empty;
            foreach (string oPath in listPst)
                if (oPath != listPst[listPst.Count - 1])
                    paths += oPath + Environment.NewLine + "        ";
                else
                    paths += oPath;

            SaveToLog(String.Format("Read list MS Outlook paths to stores, full list files to backup:{0}{1}", Environment.NewLine, "        " + paths), ESaveLogCategory.INFO);

            foreach (string oCommand in listPst)
            {
                string fullHobocopyArguments = GetFullHobocopyArguments(oCommand);
                if (oCommand == PathToDefaultPst)
                    PathToDefaultPst = fullHobocopyArguments;

                string newName = string.Empty;
                foreach (var item in GetFullHobocopyArguments(oCommand).ToArray())
                    if ((int)item == 20)
                        //for long "-" (new style named Outlook 2010)
                        newName += (char)8212;
                    else
                        newName += item;

                fullHobocopyArguments = newName;
                listHobocopyParametrs.Add(fullHobocopyArguments);
            }

            return listHobocopyParametrs;
        }

        /// <summary>
        /// Return hobocopy path
        /// </summary>
        private static string HobocopyPath
        {
            get
            {
                return Manager.GetHobocopyPath();
            }
        }

        /// <summary>
        /// Return file version
        /// </summary>
        /// <param name="_path">path to file</param>
        /// <returns>file major version</returns>
        private static int GetMajorVersion(string _path)
        {
            int toReturn = 0;
            if (File.Exists(_path))
                try
                {
                    FileVersionInfo _fileVersion = FileVersionInfo.GetVersionInfo(_path);
                    toReturn = _fileVersion.FileMajorPart;
                }
                catch
                {
                }
            return toReturn;
        }

        /// <summary>
        /// Return path to correctly hobocopy version (for OS)
        /// </summary>
        /// <returns>path to hobocopy</returns>
        private static string GetHobocopyPath()
        {
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location.Substring(0, System.Reflection.Assembly.GetExecutingAssembly().Location.LastIndexOf("\\")) + "\\";
            bool is64bit = !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("PROCESSOR_ARCHITEW6432"));

            if (Environment.OSVersion.VersionString.Contains("Microsoft Windows NT 5.1"))
                path += "HoboCopy-x86-XP.exe";
            else
                if (is64bit)
                    path += "HoboCopy-x64.exe";
                else
                    path += "HoboCopy-x86.exe";

            return path;
        } 
        #endregion
    }
}
