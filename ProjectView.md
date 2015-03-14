Console program to copy all active (usage) pst files from default Microsoft Outlook to backup folder. It's stripped down and modified version of the program http://backupmymail.codeplex.com

This program copy pst file even MS Outlook is open using program hobocopy(c) program download from https://github.com/candera/hobocopy/downloads website.
In contrast to previous project backupmymail.codeplex.com, program read information about pst files only windows registry (not using Microsoft.Office.Interop.Outlook)
Actuall version (1.0.0.0 to 1.0.0.3) tested only:
- MS Outlook 2007 usage Windows 7 x64 (64 bit) - (mail IMAP configuration)
- MS Outlook 2010 (32 bit) + usage Windows 7 x86 (32 bit) - (mail IMAP configuration)
NEW
in v.1.3 adding support to backup pst from MS Outlook 2013 (64 and 32 bit) and copy registry setting MS Outlook 2013 (different registry key than eariler MS Outlook version)

Info from use: backupmsoutlook.exe /?

backupmsoutlook is program to copy all pst files
from default Microsoft Outlook profile to backup folder.

Write at GPL v.2 license, read here http://opensource.org/licenses/GPL-2.0
backupmsoutlook version 1.0.0.3
Homepage project http://code.google.com/p/backupmsoutlook (this page)

Usage:
backupmsoutlook <destination folder> <path to txt log> <bool after copy shutdown computer> <bool adding timestamp to pst file>

Example: backupmsoutlook c:\\backup c:\log.txt false false


Schedulder task (application independent auxiliary) using library http://taskscheduler.codeplex.com/ in version 1.7.0.0
To run scheduler use backupmsoutlook.Schedule.exe file

View main form (v.1.0.0.3)

![https://lh5.googleusercontent.com/-ZGT8bjC-89k/Tr_AmmsLSwI/AAAAAAAAAMM/2p7DiPC12-4/s466/schedule-main.jpg](https://lh5.googleusercontent.com/-ZGT8bjC-89k/Tr_AmmsLSwI/AAAAAAAAAMM/2p7DiPC12-4/s466/schedule-main.jpg)

Task adding (v.1.0.0.3)

![https://lh5.googleusercontent.com/-P7-wATuxGFM/Tr_At5fKIrI/AAAAAAAAAMk/M_LCkTTIwpI/s504/schedule-task.jpg](https://lh5.googleusercontent.com/-P7-wATuxGFM/Tr_At5fKIrI/AAAAAAAAAMk/M_LCkTTIwpI/s504/schedule-task.jpg)

If you want, running task backup hidding fill permission account

# System Requirements #
  * Windows 7 32 and 64 bit (other Windows not tested yet)
  * Net Framework 3.5
  * Microsoft Outlook 2007 and 2010 32 and 64 bit (other Office version not tested yet)