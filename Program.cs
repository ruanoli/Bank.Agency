using System;
using System.Collections.Generic;

namespace Bank.Agency
{
    class Program
    {
        /*
        Criando uma lista da class Contas para armazenar nossas contas.
        Esse List funcionará como se fosse um Banco de dados, porém, o 
        armazenamento será feito em memória. Ao fechar o console, os dados
        ficaram salvos na memória somente durante a execução.
        */
        static List<Conta> ListConta = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario.ToUpper() != "S")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;

                    case "2":
                        InserirConta();
                        break;

                    case "3":
                        Tranferir();
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

                    default:
                        throw new ArgumentOutOfRangeException("Insira uma opção válida.");
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
            
            Console.WriteLine("Obrigado por utilizar nossos serviços!");
        }

        /*
        O usuário deverá informar a conta que será debitado o valor, 
        a conta que o valor será transferido e o valor.
        */
        private static void Tranferir()
        {

            Console.WriteLine("Insira o índice da conta de origem:");
            int indiceContaOrigem = int.Parse(Console.ReadLine());
           
            Console.WriteLine("Insira o índice da conta de destino:");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.WriteLine("Insira o valor da transferência");
            double valorTransferencia = double.Parse(Console.ReadLine());

            Console.WriteLine($"Confirma a transferência da conta #{indiceContaOrigem} para a conta #{indiceContaDestino}?");
            Console.WriteLine("Digite 'S' para confirmar.");
            string verificaTransfe = Console.ReadLine();
            
            if ( verificaTransfe.ToUpper() == "S")
            {
               ListConta[indiceContaOrigem].Transferir(valorTransferencia, ListConta[indiceContaDestino]);        
            }
            else
            {
                Console.WriteLine("Transferência cancelada.");
            }
        }

        /*
        Acessamos a ListConta pelo indiceConta informado 
        pelo usuário, e executamos o método Depositar da
        class Conta, passando o valorDeposito como parâmetro.
        */
        private static void Depositar()
        {
            Console.WriteLine("Insira o índice da conta.");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Insira o valor do depósito.");
            double valorDeposito = double.Parse(Console.ReadLine());

            ListConta[indiceConta].Depositar(valorDeposito);
        }

        /*
        Acessamos a conta cadastrada no ListConta pelo número
        do índice informado pelo usuário
        e executamos o método Sacar da classe Conta.
        */
        private static void Sacar()
        {
            Console.WriteLine("Digite o índice da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser sacado:");
            double valorSaque = double.Parse(Console.ReadLine());

            ListConta[indiceConta].Sacar(valorSaque);
        }

        /*
        Se não tiver nenhuma conta cadastrada, será exibida uma mensagem e
        retornará imediatamente, evitando a execução do laço for.
        No laço for será exibido as alterações feitas no método ToString na class Conta.
        */
        private static void ListarContas()
        {
            Console.WriteLine("Lista de contas: \n");

            if(ListConta.Count == 0)
            {
                Console.WriteLine("Nenhuma conta foi cadastrada.");
                return;
            }

            for(int i = 0; i < ListConta.Count; i++)
            {
                Conta conta = ListConta[i];
                Console.Write("Conta índice: {0} \n", i);
                Console.WriteLine(conta);
            }
        }

        /*
        Ao armazenar todas as informações fornecidas pelo usuário nas
        respectivas variáveis, é instânciado um objeto da class Conta.
        Setando os valores de entrada fornecidos pelo usuário nas variáveis
        nas propriedades do objeto instânciado da class Conta.
        */
        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta.");
            Console.WriteLine();
            Console.WriteLine("Digite 1 para Pessoa Física ou 2 para pessoa Jurídica:");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do cliente: ");
            string entradaNomeCliente = Console.ReadLine();

            Console.WriteLine("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor do cheque especial");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoDeConta: (TipoDeConta)entradaTipoConta, 
                                        saldo: entradaSaldo,
                                        credito: entradaCredito,
                                        nome: entradaNomeCliente);
            ListConta.Add(novaConta);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada: ");
            Console.WriteLine();

            Console.WriteLine("1 - Listar Contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("S - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            return opcaoUsuario;
        }
    }
}
