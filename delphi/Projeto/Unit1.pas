unit Unit1;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls;

type
  TForm1 = class(TForm)
    txtDolar: TEdit;
    btnConverter: TButton;
    txtReal: TEdit;
    lblDolar: TLabel;
    lblReal: TLabel;
    txtDolarAtual: TEdit;
    Label1: TLabel;
    btnCompra: TButton;
    lblMsg: TLabel;
    procedure btnConverterClick(Sender: TObject);
    procedure btnCompraClick(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
//  var1: string;
//  var2: real;
//  var3: integer;
//  var4: currency;
  resultado : currency;
  nome : string;
  x: integer;
implementation

{$R *.dfm}

procedure TForm1.btnCompraClick(Sender: TObject);
begin
  x := 0;
  if (txtdolar.Text = '0') or (txtdolar.Text = '') then
  begin
    x:= 1;
    showmessage('Falta informar o dolar');
  end
  else
  begin
    nome := inputbox('Nome', 'Digite seu nome', '');
      if (nome = '') then
      begin
        x := 1;
        showmessage('Falta informar o nome');
      end;
  end;

  if x = 0 then
    lblMsg.Caption := 'Parabens ' + nome + ' voce comprou ' + txtdolar.Text + ' dolar(es)';
end;

procedure TForm1.btnConverterClick(Sender: TObject);
begin
  if txtdolar.Text = '' then begin
    ShowMessage('Digite valor em dolar')
  end
  else begin
    btncompra.Enabled := true;
    resultado := strtofloat(txtdolar.Text) * strtofloat(txtdolaratual.Text);
    txtreal.Text := floattostr(resultado);
  end;

  //var1 := 'Mensaggem';
  //var2 := 1000.13;
  //inteiro pra string
  //edit1.Text := inttostr(var2);

  //decimal pra string
  //edit1.Text := floattostr(var2);
end;

end.
