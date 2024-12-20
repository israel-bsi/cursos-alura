namespace ByteBankIO;

partial class Program
{
    static void UsandoStreamReader()
    {
        const string FilePath = "contas.txt";

        using(var fileStream = new FileStream(FilePath, FileMode.Open))
        {
            //var line = reader.ReadLine();
            //var text = reader.ReadToEnd();
            //var number = reader.Read();

            var reader = new StreamReader(fileStream);
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var contaCorrente = ConverterStringParaContaCorrente(line);
                var msg = $"{contaCorrente.Titular.Nome}: Conta número {contaCorrente.Numero}, ag {contaCorrente.Agencia}, saldo {contaCorrente.Saldo}";
                Console.WriteLine(msg);
            }
        }
    }
    static ContaCorrente ConverterStringParaContaCorrente(string linha)
    {
        var campos = linha.Split(',').ToList();
        var agencia = int.Parse(campos[0]);
        var numero = int.Parse(campos[1]);
        var saldo = double.Parse(campos[2].Replace('.', ','));
        var nomeTitular = campos[3];

        var result = new ContaCorrente(agencia, numero);
        result.Depositar(saldo);
        result.Titular = new Cliente { Nome = nomeTitular };

        return result;
    }
}