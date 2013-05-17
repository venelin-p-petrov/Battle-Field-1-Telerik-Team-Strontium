namespace BattleField
{
    using System;

    /// <summary>
    /// Class handling the exploding of mines
    /// </summary>
    public class ExplosionHandler
    {
        /// <summary>
        /// Determines what mine has been hit.
        /// </summary>
        /// <param name="gameBoard">the game board it is played on</param>
        /// <param name="row">the row coordinate of the field</param>
        /// <param name="col">the col coordinate of the field</param>
        public static void HitMine(Board gameBoard, int row, int col)
        {
            int mineSize = Convert.ToInt32(gameBoard.GameBoard[row, col]);

            switch (mineSize)
            {
                case 1:
                    HitMineOfSizeOne(gameBoard, row, col);
                    break;
                case 2:
                    HitMineOfSizeTwo(gameBoard, row, col);
                    break;
                case 3:
                    HitMineOfSizeThree(gameBoard, row, col);
                    break;
                case 4:
                    HitMineOfSizeFour(gameBoard, row, col);
                    break;
                case 5:
                    HitMineOfSizeFive(gameBoard, row, col);
                    break;
            }
        }

        /// <summary>
        /// Changes the game board according to the hit of mine with size one.
        /// </summary>
        /// <param name="gameBoard">the game board it is played on</param>
        /// <param name="row">the row coordinate of the field</param>
        /// <param name="col">the col coordinate of the field</param>
        private static void HitMineOfSizeOne(Board gameBoard, int row, int col)
        {
            int rows = gameBoard.Rows;
            int cols = gameBoard.Cols;

            gameBoard.GameBoard[row, col] = "X";

            if (row - 1 >= 0 && col - 1 >= 0)
            {
                gameBoard.GameBoard[row - 1, col - 1] = "X";
            }

            if (row - 1 >= 0 && col + 1 < cols)
            {
                gameBoard.GameBoard[row - 1, col + 1] = "X";
            }

            if (row + 1 < rows && col + 1 < cols)
            {
                gameBoard.GameBoard[row + 1, col + 1] = "X";
            }

            if (row + 1 < rows && col - 1 >= 0)
            {
                gameBoard.GameBoard[row + 1, col - 1] = "X";
            }
        }

        /// <summary>
        /// Changes the game board according to the hit of mine with size two.
        /// </summary>
        /// <param name="gameBoard">the game board it is played on</param>
        /// <param name="row">the row coordinate of the field</param>
        /// <param name="col">the col coordinate of the field</param>
        private static void HitMineOfSizeTwo(Board gameBoard, int row, int col)
        {
            int rows = gameBoard.Rows;
            int cols = gameBoard.Cols;

            gameBoard.GameBoard[row, col] = "X";

            HitMineOfSizeOne(gameBoard, row, col);
            if (col - 1 >= 0)
            {
                gameBoard.GameBoard[row, col - 1] = "X";
            }

            if (col + 1 < cols)
            {
                gameBoard.GameBoard[row, col + 1] = "X";
            }

            if (row - 1 >= 0)
            {
                gameBoard.GameBoard[row - 1, col] = "X";
            }

            if (row + 1 < rows)
            {
                gameBoard.GameBoard[row + 1, col] = "X";
            }
        }

        /// <summary>
        /// Changes the game board according to the hit of mine with size three.
        /// </summary>
        /// <param name="gameBoard">the game board it is played on</param>
        /// <param name="row">the row coordinate of the field</param>
        /// <param name="col">the col coordinate of the field</param>
        private static void HitMineOfSizeThree(Board gameBoard, int row, int col)
        {
            int rows = gameBoard.Rows;
            int cols = gameBoard.Cols;

            HitMineOfSizeTwo(gameBoard, row, col);

            if (row - 2 >= 0)
            {
                gameBoard.GameBoard[row - 2, col] = "X";
            }

            if (row + 2 < rows)
            {
                gameBoard.GameBoard[row + 2, col] = "X";
            }

            if (col - 2 >= 0)
            {
                gameBoard.GameBoard[row, col - 2] = "X";
            }

            if (col + 2 < cols)
            {
                gameBoard.GameBoard[row, col + 2] = "X";
            }
        }

        /// <summary>
        /// Changes the game board according to the hit of mine with size four.
        /// </summary>
        /// <param name="gameBoard">the game board it is played on</param>
        /// <param name="row">the row coordinate of the field</param>
        /// <param name="col">the col coordinate of the field</param>
        private static void HitMineOfSizeFour(Board gameBoard, int row, int col)
        {
            int rows = gameBoard.Rows;
            int cols = gameBoard.Cols;

            HitMineOfSizeThree(gameBoard, row, col);

            if (row - 2 >= 0 && col - 1 >= 0)
            {
                gameBoard.GameBoard[row - 2, col - 1] = "X";
            }

            if (row - 2 >= 0 && col + 1 < cols)
            {
                gameBoard.GameBoard[row - 2, col + 1] = "X";
            }

            if (row - 1 >= 0  && col + 2 < cols)
            {
                gameBoard.GameBoard[row - 1, col + 2] = "X";
            }

            if (row + 1 < rows && col + 2 < cols)
            {
                gameBoard.GameBoard[row + 1, col + 2] = "X";
            }            

            if (row + 2 < rows && col + 1 < cols)
            {
                gameBoard.GameBoard[row + 2, col + 1] = "X";
            }

            if (row + 2 < rows && col - 1 >= 0)
            {
                gameBoard.GameBoard[row + 2, col - 1] = "X";
            }

            if (row - 1 >= 0 && col - 2 >= 0)
            {
                gameBoard.GameBoard[row - 1, col - 2] = "X";
            }

            if (row + 1 < rows && col - 2 >= 0)
            {
                gameBoard.GameBoard[row + 1, col - 2] = "X";
            }            
        }

        /// <summary>
        /// Changes the game board according to the hit of mine with size five.
        /// </summary>
        /// <param name="gameBoard">the game board it is played on</param>
        /// <param name="row">the row coordinate of the field</param>
        /// <param name="col">the col coordinate of the field</param>
        private static void HitMineOfSizeFive(Board gameBoard, int row, int col)
        {
            int rows = gameBoard.Rows;
            int cols = gameBoard.Cols;

            HitMineOfSizeFour(gameBoard, row, col);

            if (row - 2 >= 0 && col - 2 >= 0)
            {
                gameBoard.GameBoard[row - 2, col - 2] = "X";
            }

            if (row - 2 >= 0 && col + 2 < cols)
            {
                gameBoard.GameBoard[row - 2, col + 2] = "X";
            }

            if (row + 2 < rows && col + 2 < cols)
            {
                gameBoard.GameBoard[row + 2, col + 2] = "X";
            }

            if (row + 2 < rows && col - 2 >= 0)
            {
                gameBoard.GameBoard[row + 2, col - 2] = "X";
            }            
        }
    }
}