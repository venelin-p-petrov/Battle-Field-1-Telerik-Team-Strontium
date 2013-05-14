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

            int hitCoordinate = Convert.ToInt32(gameBoard.GameBoard[x, y]);
            switch (hitCoordinate)
            {
                case 1:
                    HitMineOfSizeOne(x, y, gameBoard);
                    break;
                case 2:
                    HitMineOfSizeTwo(x, y, gameBoard);
                    break;
                case 3:
                    HitMineOfSizeThree(x, y, gameBoard);
                    break;
                case 4:
                    HitMineOfSizeFour(x, y, gameBoard);
                    break;
                case 5:
                    HitMineOfSizeFive(x, y, gameBoard);
                    break;
            }

            Console.WriteLine(gameBoard);
            //PrintGameBoard(gameBoard);
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
        public static void HitMineOfSizeOne(int x, int y, Board gameBoard)
        {
            int rows = gameBoard.Rows;
            int cols = gameBoard.Cols;

            gameBoard.GameBoard[x, y] = "X";
            if (x - 1 > 1 && y - 2 > 1)
            {
                gameBoard.GameBoard[x - 1, y - 2] = "X";
            }

            if (x - 1 > 1 && y < cols - 2)
            {
                gameBoard.GameBoard[x - 1, y + 2] = "X";
            }

            if (x < rows - 1 && y < cols - 2)
            {
                gameBoard.GameBoard[x + 1, y + 2] = "X";
            }

            if (x < rows - 1 && y - 2 > 1)
            {
                gameBoard.GameBoard[x + 1, y - 2] = "X";
            }
        }

        public static void HitMineOfSizeTwo(int x, int y, Board gameBoard)
        {
            int rows = gameBoard.Rows;
            int cols = gameBoard.Cols;

            gameBoard.GameBoard[x, y] = "X";
            HitMineOfSizeOne(x, y, gameBoard);
            if (y - 2 > 1)
            {
                gameBoard.GameBoard[x, y - 2] = "X";
            }

            if (y < cols - 2)
            {
                gameBoard.GameBoard[x, y + 2] = "X";
            }

            if (x - 1 > 1)
            {
                gameBoard.GameBoard[x - 1, y] = "X";
            }

            if (x < rows - 1)
            {
                gameBoard.GameBoard[x + 1, y] = "X";
            }
        }

        public static void HitMineOfSizeThree(int x, int y, Board gameBoard)
        {
            int rows = gameBoard.Rows;
            int cols = gameBoard.Cols;

            HitMineOfSizeTwo(x, y, gameBoard);
            if (x - 2 > 1)
            {
                gameBoard.GameBoard[x - 2, y] = "X";
            }

            if (x < rows - 2)
            {
                gameBoard.GameBoard[x + 2, y] = "X";
            }

            if (y - 4 > 1)
            {
                gameBoard.GameBoard[x, y - 4] = "X";
            }

            if (y == 18)
            {
                gameBoard.GameBoard[x, y + 2] = "X";
            }
            else if (y == 20)
            {
                gameBoard.GameBoard[x, y] = "X";
            }
            else
            {
                if (y < cols - 3)
                {
                    gameBoard.GameBoard[x, y + 4] = "X";
                }
            }
        }

        public static void HitMineOfSizeFour(int x, int y, Board gameBoard)
        {
            int rows = gameBoard.Rows;
            int cols = gameBoard.Cols;

            HitMineOfSizeThree(x, y, gameBoard);
            if (x - 2 > 1 && y - 2 > 1)
            {
                gameBoard.GameBoard[x - 2, y - 2] = "X";
            }

            if (x - 1 > 1 && y - 4 > 1)
            {
                gameBoard.GameBoard[x - 1, y - 4] = "X";
            }

            if (x - 2 > 1 && y < cols - 2)
            {
                gameBoard.GameBoard[x - 2, y + 2] = "X";
            }

            if (x < rows - 1 && y - 4 > 1)
            {
                gameBoard.GameBoard[x + 1, y - 4] = "X";
            }

            if (x < rows - 2 && y - 2 > 1)
            {
                gameBoard.GameBoard[x + 2, y - 2] = "X";
            }

            if (x < rows - 2 && y < cols - 2)
            {
                gameBoard.GameBoard[x + 2, y + 2] = "X";
            }

            if (y == 18)
            {
                if (x - 1 > 1)
                {
                    gameBoard.GameBoard[x - 1, y + 2] = "X";
                }

                if (x < rows - 1)
                {
                    gameBoard.GameBoard[x + 1, y + 2] = "X";
                }
            }
            else if (y == 20)
            {
                if (x - 1 > 1)
                {
                    gameBoard.GameBoard[x - 1, y] = "X";
                }

                if (x < rows - 1)
                {
                    gameBoard.GameBoard[x + 1, y] = "X";
                }
            }
            else
            {
                if (x - 1 > 1 && y < cols - 3)
                {
                    gameBoard.GameBoard[x - 1, y + 4] = "X";
                }

                if (x < rows - 1 && y < cols - 3)
                {
                    gameBoard.GameBoard[x + 1, y + 4] = "X";
                }
            }
        }

        public static void HitMineOfSizeFive(int x, int y, Board gameBoard)
        {
            int rows = gameBoard.Rows;
            int cols = gameBoard.Cols;

            HitMineOfSizeFour(x, y, gameBoard);
            if (x - 2 > 1 && y - 4 > 1)
            {
                gameBoard.GameBoard[x - 2, y - 4] = "X";
            }

            if (x < rows - 2 && y - 4 > 1)
            {
                gameBoard.GameBoard[x + 2, y - 4] = "X";
            }

            if (y == 18)
            {
                if (x < rows - 2)
                {
                    gameBoard.GameBoard[x + 2, y + 2] = "X";
                }

                if (x - 2 > 1)
                {
                    gameBoard.GameBoard[x - 2, y + 2] = "X";
                }
            }
            else if (y == 20)
            {
                if (x < rows - 2)
                {
                    gameBoard.GameBoard[x + 2, y] = "X";
                }

                if (x - 2 > 1)
                {
                    gameBoard.GameBoard[x - 2, y] = "X";
                }
            }
            else
            {
                if (x < rows - 2 && y < cols - 3)
                {
                    gameBoard.GameBoard[x + 2, y + 4] = "X";
                }

                if (x - 2 > 1 && y < cols - 3)
                {
                    gameBoard.GameBoard[x - 2, y + 4] = "X";
                }
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
