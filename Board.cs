namespace BattleField
{
    using System;
    using System.Text;

    /// <summary>
    /// Class representing the game board.
    /// </summary>
    public class Board
    {
        /// <summary>
        /// Constructor creating a game board by given size.
        /// </summary>
        /// <param name="gameBoardSize">size of the game board</param>
        public Board(int gameBoardSize)
        {
            if (gameBoardSize < 1 || gameBoardSize > 10)
            {
                throw new ArgumentException("Invalid board size!");
            }

            this.Rows = gameBoardSize;
            this.Cols = gameBoardSize;
            this.GameBoard = this.GenerateGameBoard();
        }

        /// <summary>
        /// Property containing the rows of the game board.
        /// </summary>
        public int Rows
        {
            get;
            protected set;
        }

        /// <summary>
        /// Property containig the rows of the game board.
        /// </summary>
        public int Cols
        {
            get;
            protected set;
        }

        /// <summary>
        /// Property containing the game board.
        /// </summary>
        public string[,] GameBoard
        {
            get;
            protected set;
        }

        /// <summary>
        /// ToString method creating the presentation of the board fit for screen.
        /// </summary>
        /// <returns>String representation of the game board</returns>
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int row = 0; row < 2; row++)
            {
                result.Append("  ");
                for (int col = 2; col < (this.Cols * 2) + 1; col++)
                {
                    if (row == 0)
                    {
                        if (col % 2 == 0)
                        {
                            result.Append((col - 2) / 2);
                        }
                        else
                        {
                            result.Append(" ");
                        }
                    }
                    else
                    {
                        result.Append("-");
                    }
                }

                result.AppendLine();
            }

            for (int row = 0; row < this.Rows; row++)
            {
                result.AppendFormat("{0}|", row);

                for (int col = 0; col < this.Cols; col++)
                {
                    result.AppendFormat("{0} ", this.GameBoard[row, col]);
                }

                result.AppendLine();
            }

            return result.ToString();
        }

        /// <summary>
        /// Creates the game board initial state.
        /// </summary>
        /// <returns>created gamme board</returns>
        private string[,] GenerateGameBoard()
        {
            string[,] gameBoard = new string[this.Rows, this.Cols];

            this.AddBombs(gameBoard);

            for (int row = 0; row < this.Rows; row++)
            {
                for (int col = 0; col < this.Cols; col++)
                {
                    if (gameBoard[row, col] == null)
                    {
                        gameBoard[row, col] = "-";
                    }
                }
            }

            return gameBoard;
        }

        /// <summary>
        /// Add bombs at random positions to the game bombs.
        /// </summary>
        /// <param name="gameBoard">the game board to add to</param>
        private void AddBombs(string[,] gameBoard)
        {
            int gameBoardSize = this.Rows;
            int count = 0;
            Random randomNumber = new Random();
            int randomPlaceI;
            int randomPlaceJ;
            int minPercent = Convert.ToInt32(0.15 * (gameBoardSize * gameBoardSize));
            int maxPercent = Convert.ToInt32(0.30 * (gameBoardSize * gameBoardSize));
            int countMines = randomNumber.Next(minPercent, maxPercent);

            while (count < countMines)
            {
                do
                {
                    randomPlaceI = randomNumber.Next(0, gameBoardSize);
                    randomPlaceJ = randomNumber.Next(0, gameBoardSize);
                }
                while (gameBoard[randomPlaceI, randomPlaceJ] != null);

                string randomDigit = Convert.ToString(randomNumber.Next(1, 6));
                gameBoard[randomPlaceI, randomPlaceJ] = randomDigit;
                count++;
            }
        }
    }
}
