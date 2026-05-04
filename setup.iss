; ============================================================
;  SystemPOS — Inno Setup Script
;  Instalación en C:\Program Files\SystemPOS\
;  SourceDir y OutputDir son relativos al directorio de este .iss
; ============================================================

#define AppName      "SystemPOS"
#define AppVersion   "1.0.0"
#define AppPublisher "AGROPEC"
#define AppExeName   "SystemPOS.exe"
#define SourceDir    "{#SourcePath}\..\bin\Release"
#define OutputDir    "{#SourcePath}\..\Installer"

[Setup]
AppId={{F3A2B5C1-7D4E-4F8A-9B2C-1E6D3F7A8B5C}
AppName={#AppName}
AppVersion={#AppVersion}
AppVerName={#AppName} {#AppVersion}
AppPublisher={#AppPublisher}
DefaultDirName={autopf}\{#AppName}
DefaultGroupName={#AppName}
DisableProgramGroupPage=yes
OutputDir={#OutputDir}
OutputBaseFilename=SystemPOS_Setup_v{#AppVersion}
Compression=lzma2/ultra64
SolidCompression=yes
WizardStyle=modern
ArchitecturesInstallIn64BitMode=x64compatible
PrivilegesRequired=admin
UninstallDisplayName={#AppName}
UninstallDisplayIcon={app}\icono.ico
SetupIconFile={#SourcePath}\..\icono.ico
; Preservar archivos de base de datos en actualización
UsePreviousAppDir=yes

[Languages]
Name: "spanish"; MessagesFile: "compiler:Languages\Spanish.isl"

[Tasks]
Name: "desktopicon";    Description: "Crear acceso directo en el &Escritorio";     GroupDescription: "Accesos directos:"; Flags: checkedonce
Name: "startmenuicon";  Description: "Crear acceso directo en el &Menú Inicio";    GroupDescription: "Accesos directos:"; Flags: checkedonce

; ============================================================
;  Archivos principales
; ============================================================
[Files]
; Ejecutable y configuración
Source: "{#SourceDir}\{#AppExeName}";              DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourceDir}\SystemPOS.exe.config";       DestDir: "{app}"; Flags: ignoreversion
Source: "E:\SistemaPOS\icono.ico";                 DestDir: "{app}"; Flags: ignoreversion

; DLLs raíz
Source: "{#SourceDir}\EnvDTE.dll";                                   DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourceDir}\Microsoft.Bcl.HashCode.dll";                   DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourceDir}\Microsoft.ReportViewer.Common.dll";            DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourceDir}\Microsoft.ReportViewer.DataVisualization.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourceDir}\Microsoft.ReportViewer.Design.dll";            DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourceDir}\Microsoft.ReportViewer.ProcessingObjectModel.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourceDir}\Microsoft.ReportViewer.WinForms.dll";          DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourceDir}\Microsoft.SqlServer.Types.dll";                DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourceDir}\stdole.dll";                                   DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourceDir}\System.Buffers.dll";                           DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourceDir}\System.Collections.Immutable.dll";             DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourceDir}\System.Data.SQLite.dll";                       DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourceDir}\System.Formats.Nrbf.dll";                      DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourceDir}\System.Memory.dll";                            DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourceDir}\System.Numerics.Vectors.dll";                  DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourceDir}\System.Reflection.Metadata.dll";               DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourceDir}\System.Resources.Extensions.dll";              DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourceDir}\System.Runtime.CompilerServices.Unsafe.dll";   DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourceDir}\System.ValueTuple.dll";                        DestDir: "{app}"; Flags: ignoreversion

; Carpeta Config
Source: "{#SourceDir}\Config\*"; DestDir: "{app}\Config"; Flags: ignoreversion recursesubdirs createallsubdirs

; Carpeta Reports
Source: "{#SourceDir}\Reports\*"; DestDir: "{app}\Reports"; Flags: ignoreversion recursesubdirs createallsubdirs

; SQLite nativo x64 / x86
Source: "{#SourceDir}\x64\SQLite.Interop.dll"; DestDir: "{app}\x64"; Flags: ignoreversion
Source: "{#SourceDir}\x86\SQLite.Interop.dll"; DestDir: "{app}\x86"; Flags: ignoreversion

; SqlServerTypes
Source: "{#SourceDir}\SqlServerTypes\x64\SqlServerSpatial140.dll"; DestDir: "{app}\SqlServerTypes\x64"; Flags: ignoreversion
Source: "{#SourceDir}\SqlServerTypes\x64\msvcr120.dll";            DestDir: "{app}\SqlServerTypes\x64"; Flags: ignoreversion
Source: "{#SourceDir}\SqlServerTypes\x86\SqlServerSpatial140.dll"; DestDir: "{app}\SqlServerTypes\x86"; Flags: ignoreversion
Source: "{#SourceDir}\SqlServerTypes\x86\msvcr120.dll";            DestDir: "{app}\SqlServerTypes\x86"; Flags: ignoreversion

; Carpetas de idiomas (ReportViewer resources)
Source: "{#SourceDir}\de\*"; DestDir: "{app}\de"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "{#SourceDir}\es\*"; DestDir: "{app}\es"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "{#SourceDir}\fr\*"; DestDir: "{app}\fr"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "{#SourceDir}\it\*"; DestDir: "{app}\it"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "{#SourceDir}\ja\*"; DestDir: "{app}\ja"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "{#SourceDir}\ko\*"; DestDir: "{app}\ko"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "{#SourceDir}\pt\*"; DestDir: "{app}\pt"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "{#SourceDir}\ru\*"; DestDir: "{app}\ru"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "{#SourceDir}\zh-CHS\*"; DestDir: "{app}\zh-CHS"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "{#SourceDir}\zh-CHT\*"; DestDir: "{app}\zh-CHT"; Flags: ignoreversion recursesubdirs createallsubdirs

; ============================================================
;  Accesos directos
; ============================================================
[Icons]
Name: "{group}\{#AppName}";             Filename: "{app}\{#AppExeName}"; IconFilename: "{app}\icono.ico"; Tasks: startmenuicon
Name: "{group}\Desinstalar {#AppName}"; Filename: "{uninstallexe}";   IconFilename: "{app}\icono.ico"; Tasks: startmenuicon
Name: "{commondesktop}\{#AppName}";     Filename: "{app}\{#AppExeName}"; IconFilename: "{app}\icono.ico"; Tasks: desktopicon

; ============================================================
;  Ejecución post-instalación
; ============================================================
; ============================================================
;  Directorios de datos (permisos de escritura para todos los usuarios)
; ============================================================
[Dirs]
Name: "{localappdata}\SystemPOS"; Flags: uninsneveruninstall

; ============================================================
;  Ejecución post-instalación
; ============================================================
[Run]
Filename: "{app}\{#AppExeName}"; Description: "Ejecutar {#AppName} ahora"; Flags: nowait postinstall skipifsilent runascurrentuser

; ============================================================
;  Registro en Agregar y quitar programas
; ============================================================
[Registry]
Root: HKLM; Subkey: "Software\{#AppPublisher}\{#AppName}"; ValueType: string; ValueName: "InstallPath"; ValueData: "{app}"; Flags: uninsdeletekey
Root: HKLM; Subkey: "Software\{#AppPublisher}\{#AppName}"; ValueType: string; ValueName: "Version";     ValueData: "{#AppVersion}"

; ============================================================
;  Proteger archivos .db al desinstalar/actualizar
; ============================================================
[UninstallDelete]
; Solo elimina archivos de aplicación, nunca los .db
Type: files; Name: "{app}\*.dll"
Type: files; Name: "{app}\*.exe"
Type: files; Name: "{app}\*.config"
Type: filesandordirs; Name: "{app}\Config"
Type: filesandordirs; Name: "{app}\Reports"
Type: filesandordirs; Name: "{app}\x64"
Type: filesandordirs; Name: "{app}\x86"
Type: filesandordirs; Name: "{app}\SqlServerTypes"
Type: filesandordirs; Name: "{app}\de"
Type: filesandordirs; Name: "{app}\es"
Type: filesandordirs; Name: "{app}\fr"
Type: filesandordirs; Name: "{app}\it"
Type: filesandordirs; Name: "{app}\ja"
Type: filesandordirs; Name: "{app}\ko"
Type: filesandordirs; Name: "{app}\pt"
Type: filesandordirs; Name: "{app}\ru"
Type: filesandordirs; Name: "{app}\zh-CHS"
Type: filesandordirs; Name: "{app}\zh-CHT"
Type: files; Name: "{app}\icono.ico"

; ============================================================
;  Pascal Script — verificación de .NET 4.8 + diálogo datos al desinstalar
; ============================================================
[Code]
var
  DeleteData: Boolean;
  SavedAppPath: String;

function IsDotNet48Installed(): Boolean;
var
  release: Cardinal;
begin
  Result := RegQueryDWordValue(
    HKEY_LOCAL_MACHINE,
    'SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full',
    'Release',
    release
  ) and (release >= 528040);
end;

function InitializeSetup(): Boolean;
var
  msg: String;
begin
  if not IsDotNet48Installed() then
  begin
    msg := 'SISTEMA requiere Microsoft .NET Framework 4.8.' + #13#10;
    msg := msg + #13#10 + 'Por favor instalelo desde:' + #13#10;
    msg := msg + 'https:' + '//' + 'dotnet.microsoft.com/download/dotnet-framework/net48';
    msg := msg + #13#10 + #13#10 + 'Luego vuelva a ejecutar este instalador.';
    MsgBox(msg, mbCriticalError, MB_OK);
    Result := False;
  end
  else
    Result := True;
end;

// Al iniciar la desinstalación: preguntar si se conservan o borran los datos
function InitializeUninstall(): Boolean;
var
  res: Integer;
  msg: String;
begin
  Result := True;
  // Guardar la ruta antes de que el desinstalador la libere
  SavedAppPath := ExpandConstant('{app}');

  msg := 'SISTEMA — Desinstalación' + #13#10 + #13#10;
  msg := msg + '¿Qué desea hacer con los archivos de datos (base de datos)?' + #13#10 + #13#10;
  msg := msg + '  [Sí]  CONSERVAR los datos  (podrá usarlos en una reinstalación)' + #13#10;
  msg := msg + '  [No]  BORRAR todos los datos  (acción irreversible)';

  res := MsgBox(msg, mbConfirmation, MB_YESNO or MB_DEFBUTTON1);
  DeleteData := (res = IDNO);
end;

// Después de que el desinstalador termina: borrar .db si el usuario lo eligió
procedure CurUninstallStepChanged(CurUninstallStep: TUninstallStep);
var
  FindRec: TFindRec;
  DbFile: String;
begin
  if (CurUninstallStep = usPostUninstall) and DeleteData then
  begin
    // Eliminar todos los archivos .db en la carpeta de instalación
    if FindFirst(SavedAppPath + '\*.db', FindRec) then
    begin
      try
        repeat
          DbFile := SavedAppPath + '\' + FindRec.Name;
          DeleteFile(DbFile);
        until not FindNext(FindRec);
      finally
        FindClose(FindRec);
      end;
    end;
    // Intentar eliminar la carpeta si quedó vacía
    RemoveDir(SavedAppPath);
  end;
end;
