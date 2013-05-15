namespace BattleField
{
    using System;
    using System.Text;

    public class GameEngine
    {
        private static int turnsCounter = 0;

        public static void PlayGame(Board gameBoard)
        {
            // Venelin - n, rows and cols removed
            // x and y mineCoordinates can be made into structure
            int gameBoardSize = gameBoard.Rows;
            int rows = gameBoard.Rows;
            int cols = gameBoard.Cols;

            GameEngine.turnsCounter++;

            Console.WriteLine("Please enter mine coordinates: ");
            string[] mineCoordinates = Console.ReadLine().Split(' ', ',');
            int x = int.Parse(mineCoordinates[0]);
            int y = int.Parse(mineCoordinates[1]);

            while (x < 0 || x >= gameBoardSize || 
                   y < 0 || y >= gameBoardSize ||
                   gameBoard.GameBoard[x, y] == "-" || gameBoard.GameBoard[x, y] == "X")
            {
                Console.WriteLine("Invalid move!");
                Console.WriteLine("Please enter valid coordinates: ");
                mineCoordinates = Console.ReadLine().Split(' ', ',');
                x = int.Parse(mineCoordinates[0]);
                y = int.Parse(mineCoordinates[1]);
            }

            ExplosionHandler.HitMine(gameBoard, x, y);

            Console.WriteLine(gameBoard);
            if (!IsGameOver(gameBoard))
            {
                GameEngine.PlayGame(gameBoard);
            }
            else
            {
                Console.WriteLine("Game over. Detonated mines: {0}", GameEngine.turnsCounter);
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
            Console.Write("Welcome to \"Battle Field game.\" Enter battlefield size: N = ");
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
