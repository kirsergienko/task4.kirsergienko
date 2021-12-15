using System;
using System.Collections.Generic;
using System.Linq;

namespace game
{
    class Program
    {
        static public bool CheckArgs(string[] args)
        {
            if (args.Length < 3)
            {
                Console.WriteLine("The number of arguments must be at least 3.");
                Console.WriteLine("Example: game.exe rock paper scissors lizard Spock. " +
                    "If you want to use a space in the name, enter the name in quotation marks \" \".");

                return false;
            }
            if (args.Length % 2 == 0)
            {
                Console.WriteLine("The number of arguments must be odd.");
                Console.WriteLine("Example: game.exe rock paper scissors lizard Spock. " +
                    "If you want to use a space in the name, enter the name in quotation marks \" \".");

                return false;
            }

            var set = new HashSet<string>();

            if (!args.All(text => set.Add(text)))
            {
                Console.WriteLine("Arguments should not be repeated.");
                Console.WriteLine("Example: game.exe rock paper scissors lizard Spock. " +
                    "If you want to use a space in the name, enter the name in quotation marks \" \".");

                return false;
            }

            return true;
        }

        static public string ChooseMove(string[] args)
        {
            for (int i = 0; i <= args.Length + 1; i++)
            {
                if (i == args.Length)
                {
                    Console.WriteLine($"0 - exit");
                }
                else if (i == args.Length + 1)
                {
                    Console.WriteLine("? - help");
                }
                else
                {
                    Console.WriteLine($"{i + 1} - {args[i]}");
                }
            }

            Console.Write("Enter your move:");

            string move = Console.ReadLine();

            switch (move)
            {
                case "0":
                    Environment.Exit(0);
                    break;
                case "?":
                    HelpTable.GenerateTable(args);
                    ChooseMove(args);
                    break;
                default:
                    try
                    {
                        int i = int.Parse(move) - 1;
                        Console.WriteLine($"Your move:{args[i]}");
                        return args[i];
                    }
                    catch
                    {
                        Console.WriteLine("Incorrect move number.");
                        ChooseMove(args);
                    }
                    break;
            }

            return "";
        }

        static void Main(string[] args)
        {
            string playersMove;
            string computerMove;
            if (CheckArgs(args))
            {
                int n = new Random().Next(1, args.Length);
                computerMove = args[n];
                string key = KeyGeneration.GenerateKey();
                Console.WriteLine("HMAC:" + KeyGeneration.GenerateHMAC(key, computerMove));
                playersMove = ChooseMove(args);
                Console.WriteLine("Computer move:" + args[n]);
                string result = WinnerDetermination.FindWinner(args, playersMove, computerMove);
                switch (result)
                {
                    case "W":
                        Console.WriteLine("You win!");
                        break;
                    case "L":
                        Console.WriteLine("You lose!");
                        break;
                    case "D":
                        Console.WriteLine("Draw!");
                        break;
                }
                Console.WriteLine("HMAC key:" + key);

            }
        }
    }
}
