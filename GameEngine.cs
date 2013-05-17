namespace BattleField
{
    using System;

    /// <summary>
    /// Class containing the main game logic.
    /// </summary>
    public class GameEngine
    {
        /// <summary>
        /// The main game cycle.
        /// </summary>
        /// <param name="gameBoard">the game board it is played on</param>
        /// <param name="userInput">the user UI handling object</param>
        public static void PlayGame(Board gameBoard, IConsole userInput)
        {
            int gameBoardSize = gameBoard.Rows;
            int rows = gameBoard.Rows;
            int cols = gameBoard.Cols;
            int detonatedMinesCounter = 0;

            do
            {
                int row;
                int col;
                bool isValidCell = false;

                do
                {
                    EnterCoordinates(out row, out col, userInput);

                    bool isInField = (row >= 0 && row < gameBoardSize - 1) &&
                       (col >= 0 && col < gameBoardSize - 1);

                    isValidCell = isInField &&
                        gameBoard.GameBoard[row, col] != "-" &&
                        gameBoard.GameBoard[row, col] != "X";

                    if (!isValidCell)
                    {
                        userInput.WriteLine("Invalid move!");
                    }
                } while (!isValidCell);

                ExplosionHandler.HitMine(gameBoard, row, col);
                detonatedMinesCounter++;

                userInput.WriteLine(gameBoard.ToString());
            } while (!IsGameOver(gameBoard));

            userInput.WriteLine("Game over. Detonated mines: " + detonatedMinesCounter);
        }

        /// <summary>
        /// Check if the game has ended.
        /// </summary>
        /// <param name="gameBoard">the game board it is played on</param>
        /// <returns>whether the game has come to an end</returns>
        public static bool IsGameOver(Board gameBoard)
        {
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
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Reads from the input the game size.
        /// </summary>
        /// <param name="userInput">the user UI handling object</param>
        /// <returns>the size of the game board</returns>
        public static int ReadBoardSize(IConsole userInput)
        {
            userInput.Write("Welcome to \"Battle Field game.\" Enter battlefield size: N = ");
            int gameBoardSize = Convert.ToInt32(userInput.ReadLine());
            while (gameBoardSize < 1 || gameBoardSize > 10)
            {
                userInput.WriteLine("Enter a number between 1 and 10!");
                gameBoardSize = Convert.ToInt32(userInput.ReadLine());
            }

            return gameBoardSize;
        }

        /// <summary>
        /// Reads from the input the coordinates for the next turn
        /// </summary>
        /// <param name="row">the entered row will be saved here</param>
        /// <param name="col">the entered col will be saved here</param>
        /// <param name="userInput">the user UI handling object</param>
        private static void EnterCoordinates(out int row, out int col, IConsole userInput)
        {
            userInput.WriteLine("Please enter coordinates: ");
            string[] mineCoordinates = userInput.ReadLine().Split(new char[] { ' ', ',' },
                StringSplitOptions.RemoveEmptyEntries);
            row = int.Parse(mineCoordinates[0]);
            col = int.Parse(mineCoordinates[1]);
        }
    }
}
