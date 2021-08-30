using System; 

namespace Herenca
{
    class Program
    {
        static void Main(string[] args)
        {
            Rodar();
            
        }

        private static void Rodar() {
            var conta1 = new ContaInvestimento(10);

            var contaConvertida = ConverterConta<ContaCorrente, ContaInvestimento>(conta1);

            Console.Read();
        }

        public static void Transferencia<A>(int valor, A contaOrigem, A contaDestino)
            where A : Conta
        {
            contaOrigem.Transferir(valor, contaDestino);
            contaDestino.Depositar(valor);
        }

        public static B ConverterConta<B, A>(A contaOrigem)
            where A : Conta
            where B : Conta
        {
            B contaConvertida = Activator.CreateInstance<B>();
            contaConvertida.Depositar(contaOrigem.Saldo);

            return contaConvertida;
        }
    }
}
