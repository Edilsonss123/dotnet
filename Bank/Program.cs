using System;
using System.Collections.Generic;
using Bank.Classes;
using Bank.Classes.Enum;

namespace Bank
{
    class Program
    {

        static void Main(string[] args)
        {
            
            List<Conta> contas = new List<Conta>();
            Console.Clear();
            string opcaoSelecionada = ObterOpcaousuario();
            while(opcaoSelecionada != "X")
            {
                Console.Clear();
                switch (opcaoSelecionada)
                {
                    case "1":
                        ListarContas(contas);
                        break;
                    case "2":
                       Conta conta = CadastrarConta();
                       contas.Add(conta);
                        break;
                    case "3":
                        Transferir(contas);
                        break;                    
                    case "4":
                        Sacar(contas);
                        break;                   
                    case "5":
                        Depositar(contas);
                        break;
                    case "C":
                        LimparTela();
                        break;
                    default:
                        Console.WriteLine("Opção invalida, digite alguma tecla para retornar ao menu");
                        Console.ReadKey();
                        break;
                }
                
                opcaoSelecionada = ObterOpcaousuario();
            }


        }
        private static string ObterOpcaousuario() 
        {
            Console.WriteLine("\n######## Bank Edi ########\n");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Listar contas:");
            Console.WriteLine("2 - Inserir nova conta:");
            Console.WriteLine("3 - Transferir:");
            Console.WriteLine("4 - Sacar:");
            Console.WriteLine("5 - Depositar:");
            Console.WriteLine("C - Limpar Tela:");
            Console.WriteLine("X - Sair:\n");
            
            string opcaoSelecionada = Console.ReadLine().ToUpper();
            return opcaoSelecionada;
        }

        public static void ListarContas(List<Conta> contas)
        {
            Console.WriteLine("Lista de contas cadastradas:\n");
            if (contas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada");
            }

            int indice = 1;
            foreach (Conta conta in contas)
            {
                Console.WriteLine("Conta nº {0}\n{1}\n", indice, conta.DadosConta());
                indice++;
            }

        }

        public static Conta CadastrarConta()
        {
            Console.WriteLine("Cadastro de conta\n");
            string nomeTitular;
            double saldoInicial, creditoInicial;
            Console.Write("Informe o nome do titular da conta:");
            nomeTitular = Console.ReadLine();

            Console.Write("Informe o saldo inicial da conta:");
            saldoInicial = Int32.Parse(Console.ReadLine());

            Console.Write("Informe o crédito inicial da conta:");
            creditoInicial = Int32.Parse(Console.ReadLine());

            Conta conta = new Conta(TipoConta.PessoaFisica, saldoInicial, creditoInicial, nomeTitular);

            Console.WriteLine("Conta Cadastrada com sucesso\n {0}", conta.DadosConta());

            return conta;
        }

        public static void Transferir(List<Conta> contas)
        {
            try 
            {
                Console.WriteLine("Transferência\n");
                Conta contaOrigem = recuperarConta(contas, "origem");
                Console.Write("Informe o valor a ser transferido:");
                double valorTransferencia = double.Parse(Console.ReadLine());

                Conta contaDestino = recuperarConta(contas, "destino");

                contaOrigem.Sacar(valorTransferencia);
                contaDestino.Depositar(valorTransferencia);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void Sacar(List<Conta> contas)
        {
            try
            {
                Console.WriteLine("Saque\n");
                Conta conta = recuperarConta(contas);
                Console.Write("Informe o valor a ser sacado:");
                double valorSaque = double.Parse(Console.ReadLine());
                conta.Sacar(valorSaque);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        
        }

        public static void Depositar(List<Conta> contas)
        {
            try
            {
                Console.WriteLine("Deposito\n");
                Conta conta = recuperarConta(contas);
                Console.Write("Informe o valor a ser depositado:");
                double valorDeposito = double.Parse(Console.ReadLine());
                conta.Depositar(valorDeposito);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void LimparTela() 
        {
            Console.Clear();
        }
        public static Conta recuperarConta(List<Conta> contas, string stringAuxiliar="") 
        {

                Console.Write("Informe o número da conta {0}:", stringAuxiliar);
                int numeroConta = Int32.Parse(Console.ReadLine());
                if (contas.Count == 0)
                { 
                    throw new InvalidOperationException("Nenhuma conta cadastrada");   
                }

                if(numeroConta < 0){
                    throw new InvalidOperationException("Número da conta " + stringAuxiliar + " invalido");   
                }     

                if(contas[numeroConta-1] == null){
                    throw new InvalidOperationException("Número da conta " + stringAuxiliar + " invalido");   
                }
                Conta conta = contas[numeroConta-1];
                return conta;

           
        }

    }
}
