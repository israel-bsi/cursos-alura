program ProjetoContatos;

uses
  Vcl.Forms,
  UnitContatos in 'UnitContatos.pas' {FrmContatos};

{$R *.res}

begin
  Application.Initialize;
  Application.MainFormOnTaskbar := True;
  Application.CreateForm(TFrmContatos, FrmContatos);
  Application.Run;
end.
