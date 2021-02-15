using System;
using Bank.Classes.Enum;

namespace Bank.Classes
{
    public class Conta
    {
        private TipoConta _TipoConta { get; set; }
        private double _Saldo { get; set; }
        private double _Credito { get; set; }
        private string _Nome { get; set; }

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome) 
        {
            _Nome       = nome;
            _Saldo      = saldo;
            _Credito    = credito;
            _TipoConta  = tipoConta;
        }

        public bool Sacar(double valorSaque)
        {
            if(_Saldo - valorSaque < (_Credito * -1))
            {
                Console.WriteLine("Saldo insuficiente;");
                return false;
            }
            _Saldo -= valorSaque; 
            Console.WriteLine("Saldo atual da conta de {0} é {1}", _Nome, _Saldo);
            return true;
        }

        public bool Depositar(double valorDeposito)
        {
            if(valorDeposito < 0)
            {
                Console.WriteLine("Valor do deposito é invalido");
                return false;
            }

            _Saldo += valorDeposito; 
            Console.WriteLine("Saldo atual da conta de {0} é {1}", _Nome, _Saldo);
            return true;
        }  

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public string DadosConta() {
            string dadosConta = "";
            dadosConta += "Tipo Conta   " + _TipoConta + "\n";
            dadosConta += "Nome         " + _Nome + "\n";
            dadosConta += "Saldo        " + _Saldo + "\n";
            dadosConta += "Crédito      " + _Credito;
            return dadosConta;
        }
    }
}