namespace ByteBankIO;

public class ContaCorrente(int agencia, int numero)
{
    public int Numero { get; } = numero;
    public int Agencia { get; } = agencia;
    public double Saldo { get; private set; }
    public Cliente Titular { get; set; } = new();
    public void Depositar(double valor)
    {
        if (valor <= 0)
            throw new ArgumentException("Valor de deposito deve ser maior que zero.", nameof(valor));

        Saldo += valor;
    }
    public void Sacar(double valor)
    {
        if (valor <= 0)
            throw new ArgumentException("Valor de saque deve ser maior que zero.", nameof(valor));

        if (valor > Saldo)
            throw new InvalidOperationException("Saldo insuficiente.");

        Saldo += valor;
    }
}