using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleField
{
    public class GameEngine
    {
        public static void PlayerTurn(Board gameBoard, int countPlayed)
        {
            // Venelin - n, rows and cols removed
            // x and y coordinates can be made into structure
            int gameBoardSize = gameBoard.Rows;
            int rows = gameBoard.Rows;
            int cols = gameBoard.Cols;

            countPlayed++;
            Console.WriteLine("Please enter mine coordinates: ");
            string coordinates = Console.ReadLine();
            int x = int.Parse(coordinates.Substring(0, 1));
            int y = int.Parse(coordinates.Substring(2, 1));

            while ((x < 0 || x > (gameBoardSize - 1)) && (y < 0 || y > (gameBoardSize - 1)))
            {
                Console.WriteLine("Invalid move!");
                Console.WriteLine("Please enter mine coordinates: ");
                coordinates = Console.ReadLine();
                x = int.Parse(coordinates.Substring(0, 1));
                y = int.Parse(coordinates.Substring(2, 1));
            }

            while (gameBoard.GameBoard[x, y] == "-" || gameBoard.GameBoard[x, y] == "X")
            {
                Console.WriteLine("Invalid move! ");
                Console.WriteLine("Please enter coordinates: ");
                coordinates = Console.ReadLine();
                x = int.Parse(coordinates.Substring(0, 1));
                y = int.Parse(coordinates.Substring(2, 1));

                while ((x < 0 || x > (gameBoardSize - 1)) && (y < 0 || y > (gameBoardSize - 1)))
                {
                    Console.WriteLine("Invalid move !");
                    Console.WriteLine("Please enter coordinates: ");
                    coordinates = Console.ReadLine();
                    x = int.Parse(coordinates.Substring(0, 1));
                    y = int.Parse(coordinates.Substring(2, 1));
                }
            }

            ExplosionHandler.HitMine(gameBoard, x, y);

            Console.WriteLine(gameBoard);
            //PrintGameBoard(gameBoard);
            if (!IsGameOver(gameBoard))
            {
                GameEngine.PlayerTurn(gameBoard, countPlayed);
            }
            else
            {
                Console.WriteLine("Game over. Detonated mines: " + countPlayed);
            }
        }

        public static bool IsGameOver(Board gameBoard)
        {
            // Ivo - n, rows, cols removed. UnitTests are created. 
            bool isEnd = true;
            for (int i = 0; i < gameBoard.Rows; i++)
            {
                for (int j = 0; j < gameBoard.Cols; j++)
                {
                    if (gameBoard.GameBoard[i, j] == "1" || 
                        gameBoard.GameBoard[i, j] == "2" || 
                        gameBoard.GameBoard[i, j] == "3" || 
                        gameBoard.GameBoard[i, j] == "4" || 
                        gameBoard.GameBoard[i, j] == "5")
                    {
                        isEnd = false;
                        break;
                    }
                }
            }

            return isEnd;
        }

        public static int ReadBoardSize()
        {
            Console.Write("Welcome to \"Battle Field game.\" Enter battle field size: N = ");
            int gameBoardSize = Convert.ToInt32(Console.ReadLine());
            while (gameBoardSize < 1 || gameBoardSize > 10)
            {
                Console.WriteLine("Enter a number between 1 and 10!");
                gameBoardSize = Convert.ToInt32(Console.ReadLine());
            }

            return gameBoardSize;
        }
    }
}
