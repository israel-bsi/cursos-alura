object Form1: TForm1
  Left = 0
  Top = 0
  Caption = 'Form1'
  ClientHeight = 631
  ClientWidth = 883
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -19
  Font.Name = 'Segoe UI'
  Font.Style = []
  TextHeight = 25
  object lblDolar: TLabel
    Left = 248
    Top = 212
    Width = 46
    Height = 25
    Caption = 'Dolar'
  end
  object lblReal: TLabel
    Left = 392
    Top = 212
    Width = 35
    Height = 25
    Caption = 'Real'
  end
  object Label1: TLabel
    Left = 32
    Top = 436
    Width = 95
    Height = 25
    Caption = 'Dolar Atual'
  end
  object lblMsg: TLabel
    Left = 248
    Top = 420
    Width = 5
    Height = 25
  end
  object txtDolar: TEdit
    Left = 248
    Top = 243
    Width = 121
    Height = 33
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -19
    Font.Name = 'Segoe UI'
    Font.Style = []
    ParentFont = False
    TabOrder = 0
  end
  object btnConverter: TButton
    Left = 392
    Top = 307
    Width = 121
    Height = 46
    Caption = 'Converter'
    TabOrder = 1
    OnClick = btnConverterClick
  end
  object txtReal: TEdit
    Left = 392
    Top = 243
    Width = 121
    Height = 33
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -19
    Font.Name = 'Segoe UI'
    Font.Style = []
    ParentFont = False
    TabOrder = 2
  end
  object txtDolarAtual: TEdit
    Left = 32
    Top = 467
    Width = 121
    Height = 33
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -19
    Font.Name = 'Segoe UI'
    Font.Style = []
    ParentFont = False
    TabOrder = 3
  end
  object btnCompra: TButton
    Left = 248
    Top = 307
    Width = 121
    Height = 46
    Caption = 'Compra'
    Enabled = False
    TabOrder = 4
    OnClick = btnCompraClick
  end
end
