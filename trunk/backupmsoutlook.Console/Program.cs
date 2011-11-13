#region UsingDirectives
using System;
using System.Collections.Generic;
using backupmsoutlook.Library;
using System.Diagnostics;
using System.IO;

#endregion

namespace backupmsoutlook.Console
{
    class Program
    {
        /// <summary>
        /// Initalize library
        /// </summary>
        /// <param name="pathToOutputFolder">path to output backup folder</param>
        /// <param name="pathToLog">path to log</param>
        /// <param name="addingTimestampToPstFiles">bool adding timestamp to pst output name</param>
        /// <returns>true is initialize ok</returns>
        private static bool GetResult(string pathToOutputFolder, string pathToLog, bool addingTimestampToPstFiles)
        {
            return Manager.Initialize(pathToOutputFolder,
            pathToLog,
            addingTimestampToPstFiles);
        }

        /// <summary>
        /// main function
        /// </summary>
        /// <param name="args">args ex. c:\backup c:\backup\log.txt false false</param>
        static void Main(string[] args)
        {
            #region Variables
            string pathToOutputFolder = string.Empty;
            string pathToLog = string.Empty;
            bool afterBackupShutdownComputer = false;
            bool addingTimestampToPstFiles = false;
            #endregion

            if (args.Length == 4)
            {
                try
                {
                    if (!Directory.Exists(args[0]))
                    {
                        InfoAboutUsage();
                        return;
                    }
                    pathToOutputFolder = args[0];

                    pathToLog = args[1];
                    afterBackupShutdownComputer = bool.Parse(args[2]);
                    addingTimestampToPstFiles = bool.Parse(args[3]);
                }
                catch
                {
                    InfoAboutUsage();
                    return;
                }
            }
            else
                if (args.Length == 1)
                    try
                    {
                        if (args[0] == "/?")
                        {
                            InfoAboutProgram();
                            InfoAboutUsage();
                            return;
                        }
                        else
                        {
                            InfoAboutUsage();
                            return;
                        }
                    }
                    catch
                    {
                        InfoAboutUsage();
                        return;
                    }
                else
                {
                    InfoAboutUsage();
                    return;
                }

            DateTime startDate = DateTime.Now;
            System.Console.WriteLine(String.Format("{0} -> Start backup", startDate));
            Manager.SaveToLog("");
            Manager.SaveToLog(String.Format("{0} -> Start backup", startDate));
            if (GetResult(pathToOutputFolder, pathToLog, addingTimestampToPstFiles))
                Manager.RunBackup();

            DateTime stopDate = DateTime.Now;
            Manager.SaveToLog(String.Format("{0} -> Close backup, all time is = {1}", stopDate, stopDate - startDate));
            System.Console.WriteLine(String.Format("{0} -> Close backup, all time is = {1}", stopDate, stopDate - startDate));

            if (afterBackupShutdownComputer)
            {
                try
                {
                    System.Console.WriteLine("Shutdown computer...");
                    Process.Start("shutdown", "/s /t 0");
                }
                catch (Exception ex)
                {
                    Manager.SaveToLog(String.Format("{0} -> Error shutdown windows {1}", DateTime.Now, ex.Message));
                }
            }
        }

        /// <summary>
        /// Return about program info author etc.
        /// </summary>
        private static void InfoAboutProgram()
        {
            System.Console.WriteLine("backupmsoutlook is program to copy all pst files");
            System.Console.WriteLine("from default Microsoft Outlook profile to backup");
            System.Console.WriteLine("folder");
            System.Console.WriteLine();
            System.Console.WriteLine("Write at GLP v.2 license, read here http://opensource.org/licenses/GPL-2.0");
            System.Console.WriteLine("backupmsoutlook version 1.0.0.1");
            System.Console.WriteLine("Homepage project http://backupmsoutlook.codeplex.com");
            System.Console.WriteLine();
        }

        /// <summary>
        /// Return info about program correctly usage
        /// </summary>
        private static void InfoAboutUsage()
        {
            System.Console.WriteLine("Usage:");
            System.Console.WriteLine();
            System.Console.WriteLine("backupmsoutlook <destination folder>");
            System.Console.WriteLine("                <path to txt log>");
            System.Console.WriteLine("                <bool after copy shutdown computer>");
            System.Console.WriteLine("                <bool adding timestamp to pst file>");
            System.Console.WriteLine();
            System.Console.WriteLine("Example: backupmsoutlook C:\\backup C:\\log.txt false");
        }
    }
}
