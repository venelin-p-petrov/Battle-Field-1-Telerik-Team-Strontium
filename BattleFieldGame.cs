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
            GameEngine.PrintBoard(board.GameBoard);
            int countPlayed = 0;
            GameEngine.PlayerTurn(board.GameBoard, countPlayed);
        }
    }
}
