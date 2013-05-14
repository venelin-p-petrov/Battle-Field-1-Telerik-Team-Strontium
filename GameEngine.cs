using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleField
{
    public class GameEngine
    {
        // No Need for this method. Should use Board.ToString()
        public static void PrintGameBoard(string[,] gameBoard)
        {
            // Venelin - rows and cols removed
            int rows = gameBoard.GetLength(0);
            int cols = gameBoard.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(gameBoard[i, j]);
                }

                Console.WriteLine();
            }
        }

        public static void PlayerTurn(string[,] gameBoard, int countPlayed)
        {
            // Venelin - n, rows and cols removed
            // x and y coordinates can be made into structure
            int gameBoardSize = gameBoard.GetLength(0) - 2;
            int rows = gameBoard.GetLength(0);
            int cols = gameBoard.GetLength(1);

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

            x += 2;
            y = (2 * y) + 2;

            while (gameBoard[x, y] == "-" || gameBoard[x, y] == "X")
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

                x += 2;
                y = (2 * y) + 2;
            }

            int hitCoordinate = Convert.ToInt32(gameBoard[x, y]);
            switch (hitCoordinate)
            {
                case 1:
                    HitMineOfSizeOne(x, y, rows, cols, gameBoard);
                    break;
                case 2:
                    HitMineOfSizeTwo(x, y, rows, cols, gameBoard);
                    break;
                case 3:
                    HitMineOfSizeThree(x, y, rows, cols, gameBoard);
                    break;
                case 4:
                    HitMineOfSizeFour(x, y, rows, cols, gameBoard);
                    break;
                case 5:
                    HitMineOfSizeFive(x, y, rows, cols, gameBoard);
                    break;
            }

            PrintGameBoard(gameBoard);
            if (!IsGameOver(gameBoard))
            {
                PlayerTurn(gameBoard, countPlayed);
            }
            else
            {
                Console.WriteLine("Game over. Detonated mines: " + countPlayed);
            }
        }

        // Venelin - All Hit methods could be joined in one.
        public static void HitMineOfSizeOne(int x, int y, int rows, int cols, string[,] gameBoard)
        {
            gameBoard[x, y] = "X";
            if (x - 1 > 1 && y - 2 > 1)
            {
                gameBoard[x - 1, y - 2] = "X";
            }

            if (x - 1 > 1 && y < cols - 2)
            {
                gameBoard[x - 1, y + 2] = "X";
            }

            if (x < rows - 1 && y < cols - 2)
            {
                gameBoard[x + 1, y + 2] = "X";
            }

            if (x < rows - 1 && y - 2 > 1)
            {
                gameBoard[x + 1, y - 2] = "X";
            }
        }

        public static void HitMineOfSizeTwo(int x, int y, int rows, int cols, string[,] gameBoard)
        {
            gameBoard[x, y] = "X";
            HitMineOfSizeOne(x, y, rows, cols, gameBoard);
            if (y - 2 > 1)
            {
                gameBoard[x, y - 2] = "X";
            }

            if (y < cols - 2)
            {
                gameBoard[x, y + 2] = "X";
            }

            if (x - 1 > 1)
            {
                gameBoard[x - 1, y] = "X";
            }

            if (x < rows - 1)
            {
                gameBoard[x + 1, y] = "X";
            }
        }

        public static void HitMineOfSizeThree(int x, int y, int rows, int cols, string[,] gameBoard)
        {
            HitMineOfSizeTwo(x, y, rows, cols, gameBoard);
            if (x - 2 > 1)
            {
                gameBoard[x - 2, y] = "X";
            }

            if (x < rows - 2)
            {
                gameBoard[x + 2, y] = "X";
            }

            if (y - 4 > 1)
            {
                gameBoard[x, y - 4] = "X";
            }

            if (y == 18)
            {
                gameBoard[x, y + 2] = "X";
            }
            else if (y == 20)
            {
                gameBoard[x, y] = "X";
            }
            else
            {
                if (y < cols - 3)
                {
                    gameBoard[x, y + 4] = "X";
                }
            }
        }

        public static void HitMineOfSizeFour(int x, int y, int rows, int cols, string[,] gameBoard)
        {
            HitMineOfSizeThree(x, y, rows, cols, gameBoard);
            if (x - 2 > 1 && y - 2 > 1)
            {
                gameBoard[x - 2, y - 2] = "X";
            }

            if (x - 1 > 1 && y - 4 > 1)
            {
                gameBoard[x - 1, y - 4] = "X";
            }

            if (x - 2 > 1 && y < cols - 2)
            {
                gameBoard[x - 2, y + 2] = "X";
            }

            if (x < rows - 1 && y - 4 > 1)
            {
                gameBoard[x + 1, y - 4] = "X";
            }

            if (x < rows - 2 && y - 2 > 1)
            {
                gameBoard[x + 2, y - 2] = "X";
            }

            if (x < rows - 2 && y < cols - 2)
            {
                gameBoard[x + 2, y + 2] = "X";
            }

            if (y == 18)
            {
                if (x - 1 > 1)
                {
                    gameBoard[x - 1, y + 2] = "X";
                }

                if (x < rows - 1)
                {
                    gameBoard[x + 1, y + 2] = "X";
                }
            }
            else if (y == 20)
            {
                if (x - 1 > 1)
                {
                    gameBoard[x - 1, y] = "X";
                }

                if (x < rows - 1)
                {
                    gameBoard[x + 1, y] = "X";
                }
            }
            else
            {
                if (x - 1 > 1 && y < cols - 3)
                {
                    gameBoard[x - 1, y + 4] = "X";
                }

                if (x < rows - 1 && y < cols - 3)
                {
                    gameBoard[x + 1, y + 4] = "X";
                }
            }
        }

        public static void HitMineOfSizeFive(int x, int y, int rows, int cols, string[,] gameBoard)
        {
            HitMineOfSizeFour(x, y, rows, cols, gameBoard);
            if (x - 2 > 1 && y - 4 > 1)
            {
                gameBoard[x - 2, y - 4] = "X";
            }

            if (x < rows - 2 && y - 4 > 1)
            {
                gameBoard[x + 2, y - 4] = "X";
            }

            if (y == 18)
            {
                if (x < rows - 2)
                {
                    gameBoard[x + 2, y + 2] = "X";
                }

                if (x - 2 > 1)
                {
                    gameBoard[x - 2, y + 2] = "X";
                }
            }
            else if (y == 20)
            {
                if (x < rows - 2)
                {
                    gameBoard[x + 2, y] = "X";
                }

                if (x - 2 > 1)
                {
                    gameBoard[x - 2, y] = "X";
                }
            }
            else
            {
                if (x < rows - 2 && y < cols - 3)
                {
                    gameBoard[x + 2, y + 4] = "X";
                }

                if (x - 2 > 1 && y < cols - 3)
                {
                    gameBoard[x - 2, y + 4] = "X";
                }
            }
        }

        public static bool IsGameOver(string[,] gameBoard)
        {
            // Ivo - n, rows, cols removed. UnitTests are created. 
            bool isEnd = true;
            for (int i = 2; i < gameBoard.GetLength(0); i++)
            {
                for (int j = 2; j < gameBoard.GetLength(1); j++)
                {
                    if (gameBoard[i, j] == "1" || gameBoard[i, j] == "2" || gameBoard[i, j] == "3" || gameBoard[i, j] == "4" || gameBoard[i, j] == "5")
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
