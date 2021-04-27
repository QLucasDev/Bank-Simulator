using System;
using System.Collections.Generic;
using Bank.Entities;
using Bank.Entities.Enum;

namespace Bank
{
    class Program
    {
        static List<Conta> list = new List<Conta>();
        static void Main(string[] args)
        {
            string opUsuario = ObterOpcaoUsuario();
            while (opUsuario.ToUpper() != "X"){
                switch (opUsuario)
                {
                    case "1":
                    listarContas();
                    break;

                    case "2":
                    inserirConta();
                    break;

                    case "3":
                    Transferir();
                    break;

                    case "4":
                    Sacar();
                    break;

                    case "5":
                    Depositar();
                    break;

                    case "C":
                    Console.Clear();
                    break;

                    default :
                        throw new ArgumentOutOfRangeException("OPÇÃO INVALIDA!!");
                }
                opUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado pela preferencia!");
        }

        private static void Transferir()
        {
            Console.Write("Digite o número da conta de origem: ");
            int Origem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
            int Destino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor da transferencia: ");
            double valor = double.Parse(Console.ReadLine());

            list[Origem].Transferir(valor, list[Destino]);
        }
        private static void Depositar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());
            
            Console.Write("Digite o valor a ser depositado: ");
            double valor = double.Parse(Console.ReadLine());

            list[indiceConta].Deposito(valor);
        }
        private static void Sacar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());
            
            Console.Write("Digite o valor a ser sacado: ");
            double valor = double.Parse(Console.ReadLine());

            list[indiceConta].Sacar(valor);
        }
        private static void inserirConta()
        {
            Console.WriteLine("Inserir nova conta");
            Console.Write("Digite '1' para pessoa fisica ou '2' para pessoa juridica: ");
            int pessoa = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do cliente: ");
            string clienteNome = Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o limite de credito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            list.Add(new Conta((TipoConta)pessoa, entradaSaldo, entradaCredito, clienteNome));
        }

        private static void listarContas()
        {
            Console.WriteLine("Listar contas");
            if (list.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }

            int i = 0;
            foreach(var obj in list)
            {
                Console.WriteLine($"#{i} - {obj}");
                i++;
            }
        }

        private static string ObterOpcaoUsuario(){
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar contas");
            Console.WriteLine("2- Inserir nova conta");
            Console.WriteLine("3- Transferencia");
            Console.WriteLine("4- Saque");
            Console.WriteLine("5- Deposito");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            return opcaoUsuario;
        }
    } 
}
