using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleField
{
    public class BattleFieldGame
    {
        public static void Main(string[] args)
        {
            int gameBoardSize = GameEngine.ReadBoardSize();
            Board board = new Board(gameBoardSize);
            // No need for PrintGameBoard
            //GameEngine.PrintGameBoard(board.GameBoardView);
            Console.WriteLine(board);
            int countPlayed = 0;
            // Venelin - PlayerTurn has to be changed.
            //GameEngine.PlayerTurn(board, countPlayed);
        }
    }
}
