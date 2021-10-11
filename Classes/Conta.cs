using System;

namespace Bank.Agency
{
    public class Conta
    {
        private TipoDeConta TipoDeConta {get; set;}
        private double Credito {get; set;} //Cheque especial
        private double Saldo {get; set;}
        private string Nome {get; set;}

        public Conta(TipoDeConta tipoDeConta, double credito, double saldo, string nome)
        {
            this.TipoDeConta = tipoDeConta;
            this.Credito = credito;
            this.Saldo = saldo;
            this.Nome = nome;
        }

        /*
        Se o Saldo e o Crédito forem menores que o valor do saque solicitado
        será mostrado uma mensagem de saldo insuficiente. (Exception seria o mais recomentado)
        Se tiver saldo ou crédito na conta, o valor do saque será subtraído do saldo.
        */
        public bool Sacar(double valorSaque)
        {
            if(this.Saldo - valorSaque < (this.Credito * -1))
            {
                throw new Exception("Saldo insuficiente.");
            }
            
            this.Saldo -= valorSaque;
            Console.WriteLine($"O saldo atual da Conta de {this.Nome} é de {this.Saldo}.");
            return true;
        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;
            Console.WriteLine($"O saldo atual da Conta de {this.Nome} é de {this.Saldo}.");
        }

        /*
        Reusando os métodos Sacar e Depositar.
        Será verificado, se ao sacar não tiver dinheiro na conta, 
        será necessário depositar o valorTransferencia
        */
        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if(this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        //Sobrescrevendo o método ToString.
        public override string ToString()
        {
            string retorno = "";

            retorno += $"Tipo de conta: {this.TipoDeConta} \n";
            retorno += $"Nome: {this.Nome} \n";
            retorno += $"Saldo: {this.Saldo} \n";
            retorno += $"Credito: {this.Credito} \n";
                       
            return retorno; 
        }
    }
}