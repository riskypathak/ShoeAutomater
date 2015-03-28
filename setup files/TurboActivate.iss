; -- TurboActivate.iss --
;
; This script shows how to use TurboActivate in your installer.

[Setup]
AppName=JustCopIt 4 in 1 Bot
AppVersion=2.0
DefaultDirName={pf}\JustCopIt
DisableProgramGroupPage=yes
UninstallDisplayIcon={app}\JustCopIt.exe
DefaultGroupName=JustCopIt 4 in 1 Bot
OutputDir=output
[Icons]
Name: "{group}\JustCopIt"; Filename: "{app}\JustCopIt.EXE"; WorkingDir: "{app}";
;[Icons] 
;Name: "{userstartup}\JustCopIt"; Filename: "{app}\JustCopIt.exe"; Tasks: desktopicon
Name: "{commondesktop}\JustCopIt"; Filename: "{app}\JustCopIt.exe" ; Parameters: "."; WorkingDir: "{app}"; IconFilename: "{app}\logo.ico";  Tasks: desktopicon
[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}";

[Run]
Filename: {app}\{cm:AppName}.exe; Description: {cm:LaunchProgram,{cm:AppName}}; Flags: nowait postinstall skipifsilent

[CustomMessages]
AppName=JustCopIt
LaunchProgram=Start mySoftware after finishing installation

[Files]
; Install TurboActivate to {app} so we can access it at uninstall time
; Also, notice we're putting the TurboActivate files at the top of the file
; list. This is so that if you're using "SolidCompression=yes" your installer
; can still start relatively quickly.
Source: "TurboActivate.dll"; DestDir: "{app}"
Source: "TurboActivate.dat"; DestDir: "{app}"

;TODO: add your files that you'll be installing 
Source: "JustCopIt.exe"; DestDir: "{app}"
Source: "logo.ico"; DestDir: "{app}"


[Code]
//TODO: go to the version page in your LimeLM account and paste this GUID here
const
  VERSION_GUID = 'ea47f8154f93260b389f5.40653018';

// functions for activation
function IsActivated(versionGUID: WideString): longint;
external 'IsActivated@files:TurboActivate.dll,TurboActivate.dat cdecl setuponly';

function CheckAndSavePKey(productKey: WideString; flags: UINT): longint;
external 'CheckAndSavePKey@files:TurboActivate.dll,TurboActivate.dat cdecl setuponly';

function Activate(): longint;
external 'Activate@files:TurboActivate.dll,TurboActivate.dat cdecl setuponly';


// functions for the uninstaller
function IsActivatedUninstall(versionGUID: WideString): longint;
external 'IsActivated@{app}\TurboActivate.dll cdecl uninstallonly';

function Deactivate(erasePkey: boolean): longint;
external 'Deactivate@{app}\TurboActivate.dll cdecl uninstallonly';


var
  PkeyPage: TInputQueryWizardPage;
  activated: Boolean;

procedure InitializeWizard;
begin
    // create the product key page
    PkeyPage := CreateInputQueryPage(wpWelcome,
        'Type your product key', '',
        'You can find the product key in the email we sent you. Activation will register the product key to this computer.');
    PkeyPage.Add('Product Key:', False);
end;


function NextButtonClick(CurPage: Integer): Boolean;
var
  ret: LongInt;
begin
    if CurPage = wpWelcome then begin

        // after the welcome page, check if we're activated
        ret := IsActivated(VERSION_GUID);

        if ret = 0 then begin
            activated := true;
        end;
        Result := True;
    end else if CurPage = PkeyPage.ID then begin

        // check if the product key is valid
        ret := CheckAndSavePKey(PkeyPage.Values[0], 1);
        if ret = 0 then begin

            // try to activate, show a specific error if it fails
            ret := Activate();

            case ret of
              2: // TA_E_PKEY
                MsgBox('The product key is invalid or there''s no product key.', mbError, MB_OK);
              4: // TA_E_INET
                MsgBox('Connection to the server failed.', mbError, MB_OK);
              5: // TA_E_INUSE
                MsgBox('The product key has already been activated with the maximum number of computers.', mbError, MB_OK);
              6: // TA_E_REVOKED
                MsgBox('The product key has been revoked.', mbError, MB_OK);
              8: // TA_E_PDETS
                MsgBox('The product details file "TurboActivate.dat" failed to load. It''s either missing or corrupt.', mbError, MB_OK);
              11: // TA_E_COM
                MsgBox('CoInitializeEx failed.', mbError, MB_OK);
              13: // TA_E_EXPIRED
                MsgBox('Failed because your system date and time settings are incorrect. Fix your date and time settings, restart your computer, and try to activate again.', mbError, MB_OK);
              17: // TA_E_IN_VM
                MsgBox('Failed to activate because this instance of your program if running inside a virtual machine or hypervisor.', mbError, MB_OK);
              20: // TA_E_KEY_FOR_TURBOFLOAT
                MsgBox('The product key used is for TurboFloat, not TurboActivate.', mbError, MB_OK); 
              0: // successful
              begin
                activated := true;
                Result := True
                exit;
              end else
                MsgBox('Failed to activate.', mbError, MB_OK);
            end;
            Result := False
        end else begin
            MsgBox('You must enter a valid product key.', mbError, MB_OK);
            Result := False;
        end;
    end else
        Result := True;
end;


function ShouldSkipPage(PageID: Integer): Boolean;
begin
    // skip the "Pkey" page if were already activated
    if (PageID = PkeyPage.ID) and activated then
        Result := True
    else
        Result := False;
end;

procedure CurUninstallStepChanged(CurUninstallStep: TUninstallStep);
var
  ret: LongInt;
begin
    // Call our function just before the actual uninstall process begins
    if CurUninstallStep = usUninstall then begin

        // check if activated
        ret := IsActivatedUninstall(VERSION_GUID);

        // deactivate if activated
        if ret = 0 then begin
            ret := Deactivate(True);
        end;

        // Now that we're finished with it, unload TurboActivate.dll from memory.
        // We have to do this so that the uninstaller will be able to remove the DLL and the {app} directory.
        UnloadDLL(ExpandConstant('{app}\TurboActivate.dll'));
    end;
end;
