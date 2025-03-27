namespace CalculadorApp
{
    class Program
    {
        static string[] historicoOperacoes = new string[100];
        static int contadorHistorico = 0;

        static void Main(string[] args)
        {
            while (true)
            {
                string operacao = MostrarMenu();

                if (OpcaoSaidaSelecionada(operacao))
                    break;

                else if (OpcaoTabuadaSelecionada(operacao))
                    ExibirTabuada();

                else if (OpcaoHistoricoSelecionada(operacao))
                    ExibirHistoricoOperacoes(contadorHistorico,historicoOperacoes);

                else if (OpcaoInvalida(operacao))
                    ExibirMensagemErro();

                else
                    ExibirResultado(RealizarCalculo(operacao));
            }
        }

        static string MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Calculadora Tabajara 2025");
            Console.WriteLine("--------------------------------");

            Console.WriteLine("1 - Somar");
            Console.WriteLine("2 - Subtrair");
            Console.WriteLine("3 - Multiplicação");
            Console.WriteLine("4 - Divisão");
            Console.WriteLine("5 - Tabuada");
            Console.WriteLine("6 - Histórico de Operações");
            Console.WriteLine("S - Sair");

            string operacao = Console.ReadLine()!.ToUpper();

            return operacao;
        }

        static bool OpcaoSaidaSelecionada(string opcao)
        {
            bool opcaoSaidaSelecionada = opcao == "S";

            return opcaoSaidaSelecionada;
        }

        static bool OpcaoTabuadaSelecionada(string opcao)
        {
            return opcao == "5";
        }

        static bool OpcaoInvalida(string opcao)
        {
            bool opcaoInvalida = opcao != "1" && opcao != "2" && opcao != "3" && opcao != "4" && opcao != "5" && opcao != "6" && opcao != "S";

            return opcaoInvalida;
        }

        static void ExibirMensagemErro()
        {
            Console.WriteLine("Operação inválida, tente novamente...");
            Console.ReadLine();
        }

        static decimal RealizarCalculo(string operacao)
        {
            Console.WriteLine("Digite o primeiro número:");

            decimal primeiroNumero = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Digite o segundo número:");

            decimal segundoNumero = Convert.ToDecimal(Console.ReadLine());

            decimal resultado = 0;

            switch (operacao)
            {
                case "1":
                    resultado = primeiroNumero + segundoNumero;
                    historicoOperacoes[contadorHistorico] = $"{primeiroNumero} + {segundoNumero} = {resultado}";
                    break;

                case "2":
                    resultado = primeiroNumero - segundoNumero;
                    historicoOperacoes[contadorHistorico] = $"{primeiroNumero} - {segundoNumero} = {resultado}";
                    break;

                case "3":
                    resultado = primeiroNumero * segundoNumero;
                    historicoOperacoes[contadorHistorico] = $"{primeiroNumero} * {segundoNumero} = {resultado}";
                    break;

                case "4":
                    while (segundoNumero == 0)
                    {
                        Console.Write("Não é possível dividir por 0\n Digite o segundo número novamente -> ");

                        segundoNumero = Convert.ToDecimal(Console.ReadLine());
                    }

                    resultado = primeiroNumero / segundoNumero;
                    historicoOperacoes[contadorHistorico] = $"{primeiroNumero} / {segundoNumero} = {resultado}";
                    break;
            }

            contadorHistorico++;

            return resultado;
        }

        static void ExibirResultado(decimal resultado)
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine("O resultado é: " + resultado.ToString("F2"));
            Console.WriteLine("--------------------------------");

            Console.ReadLine();
        }

        static void ExibirTabuada()
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Tabuada");
            Console.WriteLine("--------------------------------");

            Console.Write("Digite o número: ");
            int numeroTabuada = Convert.ToInt32(Console.ReadLine());

            for (int contador = 1; contador <= 10; contador++)
            {
                int resultadoTabuada = numeroTabuada * contador;

                Console.WriteLine($"{numeroTabuada} x {contador} = {resultadoTabuada}");
            }

            Console.Write("Aperte ENTER para continuar");
            Console.ReadLine();
        }
        static bool OpcaoHistoricoSelecionada(string opcao)
        {
            return opcao == "6";
        }
        static void ExibirHistoricoOperacoes(int contadorHistorico, string[] historicoOperacoes)
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Histórico de Operações");
            Console.WriteLine("--------------------------------");

            for (int contador = 0; contador < historicoOperacoes.Length; contador++)
            {
                string valorAtual = historicoOperacoes[contador];

                if (valorAtual != null)
                    Console.WriteLine(valorAtual);
            }

            Console.Write("Aperte ENTER para continuar");
            Console.ReadLine();
        }
    }
}
