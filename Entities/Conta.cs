using System;
using System.Text;
using System.Globalization;
using Bank.Entities.Enum;
namespace Bank.Entities
{
    public class Conta
    {
        private TipoConta tipoConta { get; set; }
        private double Saldo { get; set; }
        public double Credito { get; set; }
        private string Nome { get; set; }

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.tipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }
        // Validação de Saque...
        public bool Sacar(double valorSaque)
        {
            if(Saldo - valorSaque < (Credito * -1)){
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }
            Saldo -= valorSaque;
            Console.WriteLine($"O Saldo da conta de {Nome} é {Saldo}");
            return true;
        }
        public void Deposito(double valorDeposito)
        {
            Saldo += valorDeposito;
            Console.WriteLine($"O saldo atual da conta de {Nome} é {Saldo}");
        }
        public void Transferir(double valorTrasnferencia, Conta contaDestino)
        {
            if(Sacar(valorTrasnferencia)){
                contaDestino.Deposito(valorTrasnferencia);
            }
        }
        public override string ToString()
        {
            StringBuilder saida = new StringBuilder();
            saida.AppendLine("Tipo da conta"+ tipoConta);
            saida.AppendLine("Nome: "+ Nome);
            saida.AppendLine("Saldo: "+ Saldo.ToString("F2", CultureInfo.InvariantCulture));
            saida.Append("Credito: "+ Credito);
            return saida.ToString();
        }
    }
}