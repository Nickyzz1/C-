using System;
using System.Collections.Generic;

namespace BattleSimulation
{
    public class Attack
    {
        public int NumberSoldier { get; set; }
        public int Points { get; set; }

        public Attack(int soldiers, int points)
        {
            NumberSoldier = soldiers;
            Points = points;
        }
    }

    public class Defense
    {
        public int NumberSoldier { get; set; }
        public int Points { get; set; }

        public Defense(int soldiers, int points)
        {
            NumberSoldier = soldiers;
            Points = points;
        }
    }

    class Program
    {
        static Random rand = new Random();
        static int N = 20; // Número de simulações
        static int pontAttTotal = 0;

        static void Main(string[] args)
        {
            monteCarlo();
            Console.WriteLine($"========== A probabilidade de um ataque vencer é de aproximadamente: {(pontAttTotal / (double)N) * 100}% ================");
        }

        static int roll() => rand.Next(1, 7); // Gera um número entre 1 e 6.

        static List<int> turnDice(int quantSoldires)
        {
            List<int> result = new List<int>();

            int numDice = Math.Min(3, quantSoldires); // Garante que o número de dados não seja maior que 3.

            for (int i = 0; i < numDice; i++)
            {
                result.Add(roll());
            }

            return result;
        }

        static void monteCarlo()
        {
            for (int n = 0; n < N; n++)
            {
                int pontAtt = 0;
                int pontDef = 0;

                // Inicializa os soldados com números arbitrários (exemplo: 1700 soldados para o ataque e 1000 para a defesa)
                Attack attack = new Attack(1700, pontAtt);
                Defense defense = new Defense(1000, pontDef);

                // Continuar a batalha até que um dos lados perca todos os soldados
                while (attack.NumberSoldier > 0 && defense.NumberSoldier > 0)
                {
                    // Exibir o status da rodada
                    Console.WriteLine("\n=============================");

                    // Gerar dados para o ataque e defesa
                    List<int> resultAtt = turnDice(attack.NumberSoldier); // Ataque
                    List<int> resultDef = turnDice(defense.NumberSoldier); // Defesa

                    // Determinar o número de batalhas (número de dados a serem comparados)
                    int rounds = Math.Min(resultAtt.Count, resultDef.Count);

                    // Realizar as comparações das batalhas
                    for (int j = 0; j < rounds; j++)
                    {
                        if (resultAtt[j] > resultDef[j]) // Ataque vence
                        {
                            pontAtt++;
                            Console.WriteLine($"{j + 1}° batalha! Ataque venceu! Com {attack.NumberSoldier} contra {defense.NumberSoldier}");
                            defense.NumberSoldier--; // O número de soldados da defesa diminui
                        }
                        else // Defesa vence
                        {
                            pontDef++;
                            Console.WriteLine($"{j + 1}° batalha! Defesa venceu! Com {defense.NumberSoldier} contra {attack.NumberSoldier}");
                            attack.NumberSoldier--; // O número de soldados do ataque diminui
                        }
                    }

                    // Checar quem venceu a rodada com base nos pontos
                    if (pontAtt > pontDef)
                    {
                        pontAttTotal++; // Acumular vitórias do ataque
                        Console.WriteLine("Ataque venceu a rodada!");
                    }
                    else
                    {
                        Console.WriteLine("Defesa venceu a rodada!");
                    }

                    // Resetar os pontos para a próxima rodada de comparações
                    pontAtt = 0;
                    pontDef = 0;
                }
            }
        }
    }
}
