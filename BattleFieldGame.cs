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

            String[,] gameField = new String[rows, cols];

            gameField[0, 0] = " ";
            gameField[0, 1] = " ";
            gameField[1, 0] = " ";
            gameField[1, 1] = " ";

            for (int row = 2; row < rows; row++)
            {
                for (int col = 2; col < cols; col++)
                {
                    if (col % 2 == 0)
                    {
                        if (col == 2)
                        {
                            gameField[0, col] = "0";
                        }
                        else
                        {
                            gameField[0, col] = Convert.ToString((col - 2) / 2);
                        }
                    }
                    else
                    {
                        gameField[0, col] = " ";
                    }
                    if (col < cols - 1)
                    {
                        gameField[1, col] = "-";
                    }

                    gameField[row, 0] = Convert.ToString(row - 2);
                    gameField[row, 1] = "|";
                    if (col % 2 == 0)
                    {
                        gameField[row, col] = "-";
                    }
                    else
                    {
                        gameField[row, col] = " ";
                    }

                }

            }

            Methods.AddBombs(gameField);
            Methods.PrintArray(gameField);
            int countPlayed = 0;
            Methods.PlayerTurn(gameField, countPlayed);

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

