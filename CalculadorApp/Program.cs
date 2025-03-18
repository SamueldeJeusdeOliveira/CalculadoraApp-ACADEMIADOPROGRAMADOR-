using System;
using System.Globalization;

namespace CalculadoraApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("-------------------------");
            Console.WriteLine("Calculadora Tabajara 2025");
            Console.WriteLine("-------------------------");
            bool t = true;

            try
            {
                while (t)
                {
                    Console.WriteLine("Digite uma opção:");
                    Console.WriteLine("[1] Soma\n[2] Subtrair\n[3] Multiplicação\n[4] Divisão\n[5] Tabuada\n[6] Sair");

                    int opcao;
                    while (!int.TryParse(Console.ReadLine(), out opcao) || opcao < 1 || opcao > 6)
                    {
                        Console.WriteLine("Opção inválida! Digite um número entre 1 e 6.");
                    }

                    if (opcao == 6)
                    {
                        break;
                    }

                    if (opcao != 5)
                    {
                        Console.WriteLine("Digite o primeiro número: ");
                        double n1;
                        while (!double.TryParse(Console.ReadLine(), out n1))
                        {
                            Console.WriteLine("Entrada inválida! Digite um número válido.");
                        }

                        Console.WriteLine("Digite o segundo número:");
                        double n2;
                        while (!double.TryParse(Console.ReadLine(), out n2) || (opcao == 4 && n2 == 0))
                        {
                            Console.WriteLine("Número inválido! Para divisão, o divisor não pode ser zero.");
                        }

                        double resultado = Operacoes(opcao, n1, n2);
                        Console.WriteLine($"Resultado: {resultado.ToString("F2", CultureInfo.InvariantCulture)}");
                        Console.WriteLine("------------------------------------------------------------------------------");
                    }
                    else
                    {
                        Tabuada();
                    }
                }
                Console.WriteLine("Você saiu da Calculadora!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Um erro aconteceu!");
                Console.WriteLine(e.Message);
            }
        }

        static void Tabuada()
        {
            Console.WriteLine("Digite um número para ver a tabuada:");
            int num;
            while (!int.TryParse(Console.ReadLine(), out num))
            {
                Console.WriteLine("Entrada inválida! Digite um número inteiro.");
            }

            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"{num} x {i} = {num * i}");
            }
        }

        static double Operacoes(int opcao, double n1, double n2)
        {
            switch (opcao)
            {
                case 1: return n1 + n2;
                case 2: return n1 - n2;
                case 3: return n1 * n2;
                case 4: return n1 / n2;
                default: return 0;
            }
        }
    }
}
