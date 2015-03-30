#define ApplicationName 'BackupMsOutlook'
#define ApplicationGuiVersion GetFileVersion('C:\Users\Marek\Documents\GitHub\CodeGoogle\backupmsoutlook\backupmsoutlook.Schedule\bin\Release\backupmsoutlook.Schedule.exe')
#define ApplicationLibVersion GetFileVersion('C:\Users\Marek\Documents\GitHub\CodeGoogle\backupmsoutlook\backupmsoutlook.Schedule\bin\Release\backupmsoutlook.Library.dll')
#define ApplicationConVersion GetFileVersion('C:\Users\Marek\Documents\GitHub\CodeGoogle\backupmsoutlook\backupmsoutlook.Schedule\bin\Release\backupmsoutlook.exe')

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{142FE211-6D24-4C9D-87B6-82E9828071E5}
AppName={#ApplicationName}
AppVersion={#ApplicationGuiVersion}
AppVerName={#ApplicationName} {#ApplicationGuiVersion}
AppPublisher=MarekOtulakowski
AppPublisherURL=https://github.com/MarekOtulakowski/backupmsoutlook
AppSupportURL=https://github.com/MarekOtulakowski/backupmsoutlook
AppUpdatesURL=https://github.com/MarekOtulakowski/backupmsoutlook
DefaultDirName=C:\Program Files\BackupMsOutlook
DefaultGroupName={#ApplicationName}
LicenseFile=C:\Users\Marek\Documents\GitHub\CodeGoogle\backupmsoutlook\License.txt
OutputDir=C:\Users\Marek\Documents\GitHub\CodeGoogle\backupmsoutlook\backupmsoutlook.Schedule\Setup
OutputBaseFilename=setup-backupmsoutlook-v{#ApplicationGuiVersion}
VersionInfoVersion={#ApplicationGuiVersion}
VersionInfoCopyright=Copyright © MarekOtulakowski 2011-2015
VersionInfoDescription=Installer for {#ApplicationName}
SetupIconFile=C:\Users\Marek\Documents\GitHub\CodeGoogle\backupmsoutlook\backupmsoutlook.Schedule\Setup\Schedule.ico
Compression=lzma
SolidCompression=yes
UninstallDisplayIcon={app}\Uninstaller.ico

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked
Name: "quicklaunchicon"; Description: "{cm:CreateQuickLaunchIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked; OnlyBelowVersion: 0,6.1

[Files]
Source: "C:\Users\Marek\Documents\GitHub\CodeGoogle\backupmsoutlook\backupmsoutlook.Schedule\bin\Release\backupmsoutlook.Schedule.exe"; DestDir: "{app}"; StrongAssemblyName: "backupmsoutlook.Schedule, Version={#ApplicationGuiVersion}, Culture=neutral, PublicKeyToken=a7aa57c62cea45d5, ProcessorArchitecture=MSIL"; Flags: ignoreversion
Source: "C:\Users\Marek\Documents\GitHub\CodeGoogle\backupmsoutlook\backupmsoutlook.Schedule\bin\Release\backupmsoutlook.Schedule.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Marek\Documents\GitHub\CodeGoogle\backupmsoutlook\backupmsoutlook.Schedule\bin\Release\backupmsoutlook.exe"; DestDir: "{app}"; StrongAssemblyName: "backupmsoutlook, Version={#ApplicationConVersion}, Culture=neutral, PublicKeyToken=bd1fa2dd1fecdbc0, ProcessorArchitecture=MSIL"; Flags: ignoreversion
Source: "C:\Users\Marek\Documents\GitHub\CodeGoogle\backupmsoutlook\backupmsoutlook.Schedule\bin\Release\backupmsoutlook.Library.dll"; DestDir: "{app}"; StrongAssemblyName: "backupmsoutlook.Library, Version={#ApplicationLibVersion}, Culture=neutral, PublicKeyToken=40f9d1a8346d85c8, ProcessorArchitecture=MSIL"; Flags: ignoreversion
Source: "C:\Users\Marek\Documents\GitHub\CodeGoogle\backupmsoutlook\backupmsoutlook.Schedule\bin\Release\Microsoft.Win32.TaskScheduler.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Marek\Documents\GitHub\CodeGoogle\backupmsoutlook\backupmsoutlook.Schedule\bin\Debug\HoboCopy-x64.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Marek\Documents\GitHub\CodeGoogle\backupmsoutlook\backupmsoutlook.Schedule\bin\Debug\HoboCopy-x86.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Marek\Documents\GitHub\CodeGoogle\backupmsoutlook\backupmsoutlook.Schedule\bin\Debug\HoboCopy-x86-XP.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Marek\Documents\GitHub\CodeGoogle\backupmsoutlook\License.txt"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Marek\Documents\GitHub\CodeGoogle\backupmsoutlook\backupmsoutlook.Schedule\Setup\Uninstaller.ico"; DestDir: "{app}"; Flags: ignoreversion
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{group}\{cm:ProgramOnTheWeb,BackupMsOutlook}"; Filename: "https://github.com/MarekOtulakowski/backupmsoutlook"
Name: "{group}\backupmsoutlook"; Filename: "{app}\backupmsoutlook.Schedule.exe"    
Name: "{group}\{cm:UninstallProgram,BackupMsMail}"; Filename: "{uninstallexe}"; IconFilename: "{app}\Uninstaller.ico"
Name: "{commondesktop}\backupmsoutlook"; Filename: "{app}\backupmsoutlook.Schedule.exe"; Tasks: desktopicon



