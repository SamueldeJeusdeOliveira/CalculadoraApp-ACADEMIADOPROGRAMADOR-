using System;
using System.Collections.Generic;
using System.Globalization;

namespace CalculadoraApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<string> historico = new List<string>(); 
            Console.WriteLine("-------------------------");
            Console.WriteLine("Calculadora Tabajara 2025");
            Console.WriteLine("-------------------------");

            while (true)
            {
                try
                {
                    Console.WriteLine("Digite uma opção:");
                    Console.WriteLine("[1] Soma\n[2] Subtrair\n[3] Multiplicação\n[4] Divisão\n[5] Tabuada\n[6] Mostrar Histórico\n[7] Sair");

                    int opcao;
                    while (!int.TryParse(Console.ReadLine(), out opcao) || opcao < 1 || opcao > 7)
                    {
                        Console.WriteLine("Opção inválida! Digite um número entre 1 e 7.");
                    }

                    if (opcao == 7)
                    {
                        Console.WriteLine("Você saiu da Calculadora!");
                        break;
                    }

                    if (opcao == 6)
                    {
                        if (historico.Count == 0)
                        {
                            Console.WriteLine("Histórico vazio.");
                        }
                        else
                        {
                            Console.WriteLine("Histórico de operações:");
                            foreach (string item in historico)
                            {
                                Console.WriteLine(item);
                            }
                        }
                        continue;
                    }

                    if (opcao == 5)
                    {
                        Tabuada();
                        continue;
                    }

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
                    string operacaoSimbolo = opcao == 1 ? "+" : opcao == 2 ? "-" : opcao == 3 ? "*" : "/";
                    string registro = $"{n1} {operacaoSimbolo} {n2} = {resultado.ToString("F2", CultureInfo.InvariantCulture)}";
                    historico.Add(registro);

                    Console.WriteLine($"Resultado: {resultado.ToString("F2", CultureInfo.InvariantCulture)}");
                    Console.WriteLine("------------------------------------------------------------------------------");

                }
                catch (Exception e)
                {
                    Console.WriteLine("Um erro aconteceu!");
                    Console.WriteLine(e.Message);
                }
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

            Console.WriteLine($"Tabuada do {num}:");
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"{num} x {i} = {num * i}");
            }
        }

        static double Operacoes(int opcao, double n1, double n2)
        {
            return opcao switch
            {
                1 => n1 + n2,
                2 => n1 - n2,
                3 => n1 * n2,
                4 => n1 / n2,
                _ => 0
            };
        }
    }
}
