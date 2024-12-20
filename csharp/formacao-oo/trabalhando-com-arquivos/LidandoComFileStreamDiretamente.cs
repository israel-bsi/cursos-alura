using System.Text;

namespace ByteBankIO;

partial class Program
{
    public static void LidandoComFileStream()
    {
        const string FilePath = "contas.txt";

        //public override int Read(byte[] array, int offset, int count);
        //byte = onde será armazenado o dado lido -> buffer de bytes que será preenchido com os dados lidos
        //offset = a partir de qual posição do array será armazenado o dado lido
        //count = quantidade de bytes que serão lidos

        using (var fileStream = new FileStream(FilePath, FileMode.Open))
        {
            var numberBytesRead = -1;
            var buffer = new byte[1024]; //1kb

            while (numberBytesRead != 0)
            {
                numberBytesRead = fileStream.Read(buffer, 0, 1024);
                WriteBuffer(buffer, numberBytesRead);
            }
        }
        // Devoluções
        // O número total de bytes lidos do buffer. Isso poderá ser menor que o numero de 
        // bytes solicitado se esse número de bytes não estiver disponível no momento, ou
        // zero. se o final do fluxo for atigindo.

        Console.ReadLine();
    }
    private static void WriteBuffer(byte[] buffer, int readBytes)
    {
        var utf8 = new UTF8Encoding();
        //public virtual string GetString(byte[] bytes, int index, int count);
        //bytes = buffer de bytes que será convertido em string
        //index = a partir de qual posição do array será convertido em string
        //count = quantidade de bytes que serão convertidos em string
        var text = utf8.GetString(buffer, 0, readBytes);
        Console.Write(text);
        //foreach (var myByte in buffer)
        //{
        //    Console.Write(myByte);
        //    Console.Write(" ");
        //}
    }
}