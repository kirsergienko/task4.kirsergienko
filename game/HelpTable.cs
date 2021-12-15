using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    public static class HelpTable
    {
        public static void GenerateTable(string[] moves)
        {
            int N = moves.Length;
            string[,] table = new string[N + 1, N + 1];
            table[0, 0] = "Help";
            for (int i = 0; i < N; i++)
            {
                table[i + 1, 0] = moves[i];

                table[0, i + 1] = moves[i];
            }
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    table[j + 1, i + 1] = WinnerDetermination.FindWinner(moves, moves[i], moves[j]);
                }
            }
            for (int i = 0; i < N + 1; i++)
            {
                for (int j = 0; j < N + 1; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        if (table[i, j].Length > 4)
                        {
                            Console.Write($"{table[i, j].Substring(0, 4)}\t");
                        }
                    }
                    else
                    {
                        Console.Write($"{table[i, j]}\t");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
