unit UnitContatos;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, FireDAC.Stan.Intf, FireDAC.Stan.Option,
  FireDAC.Stan.Error, FireDAC.UI.Intf, FireDAC.Phys.Intf, FireDAC.Stan.Def,
  FireDAC.Stan.Pool, FireDAC.Stan.Async, FireDAC.Phys, FireDAC.Phys.MSAcc,
  FireDAC.Phys.MSAccDef, FireDAC.VCLUI.Wait, FireDAC.Stan.Param, FireDAC.DatS,
  FireDAC.DApt.Intf, FireDAC.DApt, System.Rtti, System.Bindings.Outputs,
  Vcl.Bind.Editors, Data.Bind.EngExt, Vcl.Bind.DBEngExt, Data.Bind.Components,
  Vcl.StdCtrls, Data.DB, FireDAC.Comp.DataSet, FireDAC.Comp.Client,
  Data.Bind.DBScope, Vcl.Grids, Vcl.DBGrids, Vcl.ExtCtrls, Vcl.Buttons,
  Vcl.DBCtrls;

type
  TFrmContatos = class(TForm)
    FDConnection1: TFDConnection;
    BindSourcecontatos: TBindSourceDB;
    FDTablecontatos: TFDTable;
    txtId: TEdit;
    txtName: TEdit;
    txtTelefone: TEdit;
    txtEmail: TEdit;
    BindingsList1: TBindingsList;
    LinkControlToField1: TLinkControlToField;
    LinkControlToField2: TLinkControlToField;
    LinkControlToField3: TLinkControlToField;
    LinkControlToField4: TLinkControlToField;
    lblId: TLabel;
    lblName: TLabel;
    lblTelefone: TLabel;
    lblEmail: TLabel;
    DBNavigator1: TDBNavigator;
    DataSource1: TDataSource;
    DBGrid1: TDBGrid;
    Memo1: TMemo;
    LinkControlToField5: TLinkControlToField;
    btnSair: TButton;
    procedure btnSairClick(Sender: TObject);
    procedure DBGrid1DblClick(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  FrmContatos: TFrmContatos;

implementation

{$R *.dfm}

procedure TFrmContatos.btnSairClick(Sender: TObject);
begin
  FrmContatos.Close;
end;

procedure TFrmContatos.DBGrid1DblClick(Sender: TObject);
begin
  showmessage ('Alteracoes somente pelos campos ' );
end;

end.
