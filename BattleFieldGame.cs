using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleField
{
    class BattleFieldGame
    {
        private static int gameFieldSize = 0;

        static void Main(string[] args)
        {
            ReadInput();

            int rows = gameFieldSize + 2;
            int cols = gameFieldSize * 2 + 2;


            Board gameField = new Board(rows, cols);            
            Methods.PrintArray(gameField.GameBoard);
            int countPlayed = 0;
            Methods.PlayerTurn(gameField.GameBoard, countPlayed);
        }

        private static void ReadInput()
        {
            Console.Write("Welcome to \"Battle Field game.\" Enter battle field size: n = ");
            gameFieldSize = Convert.ToInt32(Console.ReadLine());
            while (gameFieldSize < 1 || gameFieldSize > 10)
            {
                Console.WriteLine("Enter a number between 1 and 10!");
                gameFieldSize = Convert.ToInt32(Console.ReadLine());
            }
        }
    }
}

