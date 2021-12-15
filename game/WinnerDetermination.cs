using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    public static class WinnerDetermination
    {
        public static string FindWinner(string[] allMoves, string playersMove, string computerMove)
        {
            int playersMoveIndex = Array.IndexOf(allMoves, playersMove) + 1;
            int computerMoveIndex = Array.IndexOf(allMoves, computerMove) + 1;
            int half = allMoves.Length / 2;
            if (computerMoveIndex == playersMoveIndex)
            {
                return "D";
            }
            for (int i = playersMoveIndex; i <= playersMoveIndex + half; i++)
            {
                if (i > allMoves.Length)
                {
                    if ((i - allMoves.Length) == computerMoveIndex)
                    {
                        return "W";
                    }
                }
                else
                {
                    if (i == computerMoveIndex)
                    {
                        return "W";
                    }
                }
            }
            return "L";
        }
    }
}
