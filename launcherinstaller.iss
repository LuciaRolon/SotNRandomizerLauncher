; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "Symphony of the Night Randomizer Launcher"
#define MyAppVersion "0.4.4.1"
#define MyAppPublisher "SacredLucy"
#define MyAppURL "https://github.com/LuciaRolon/SotNRandomizerLauncher"
#define MyAppExeName "SotNRandomizerLauncher.exe"

[Setup]
AppId={{A246E201-B3F9-4EF6-A78D-B37ADE4673A3}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={autopf}\{#MyAppName}
DisableProgramGroupPage=yes
LicenseFile={src}\LICENSE.txt
PrivilegesRequired=lowest
OutputDir={build}\Output
OutputBaseFilename=SotNRandomizerLauncher
SetupIconFile={src}\SotNRandomizerLauncher\Captykure.ico
Compression=lzma
SolidCompression=yes
WizardStyle=modern

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}";

[Files]
Source: "{src}\bin\Release\{#MyAppExeName}"; DestDir: "{app}"; Flags: ignoreversion
Source: "{src}\bin\Release\apply_ppf.bat"; DestDir: "{app}"; Flags: ignoreversion
Source: "{src}\bin\Release\applyppf3_vc.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "{src}\bin\Release\error_recalc.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "{src}\bin\Release\Newtonsoft.Json.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{src}\bin\Release\Newtonsoft.Json.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "{src}\bin\Release\SotNRandomizerLauncher.application"; DestDir: "{app}"; Flags: ignoreversion
Source: "{src}\bin\Release\SotNRandomizerLauncher.exe.manifest"; DestDir: "{app}"; Flags: ignoreversion
Source: "{src}\bin\Release\SotNRandomizerLauncher.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "{src}\bin\Release\LauncherUpdater.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "{src}\bin\Release\LauncherUpdater.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "{src}\bin\Release\baseFiles\*"; DestDir: "{app}\baseFiles"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "{src}\Captykure.ico"; DestDir: "{app}"; Flags: ignoreversion 

[Icons]
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; IconFilename: "{app}\Captykure.ico"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; IconFilename: "{app}\Captykure.ico"; Tasks: desktopicon

[UninstallDelete]
Type: filesandordirs; Name: "{app}\apps\AreaRando\*"
Type: filesandordirs; Name: "{app}\apps\BizHawk\*"
Type: filesandordirs; Name: "{app}\apps\LiveSplit\*"
Type: filesandordirs; Name: "{app}\apps\Presets\*"
Type: filesandordirs; Name: "{app}\apps\RandoTools\*"
Type: filesandordirs; Name: "{app}\apps\Randomizer\*"
Type: filesandordirs; Name: "{app}\apps\AreaRandoMapTracker\*"
Type: filesandordirs; Name: "{app}\files\randomized\*"
Type: files; Name: "{app}\SotNRandomizerLauncher.exe.Config"

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: runascurrentuser nowait postinstall skipifsilent