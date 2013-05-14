using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleField
{
    public class Board
    {
        public int Rows
        {
            get;
            protected set;
        }

        public int Cols
        {
            get;
            protected set;
        }

        public string[,] GameBoard
        {
            get;
            protected set;
        }

        public Board(int gameBoardSize)
        {
            if (gameBoardSize < 1 || gameBoardSize > 10)
            {
                throw new ArgumentException("Invalid board size!");
            }

            this.Rows = gameBoardSize;
            this.Cols = gameBoardSize;
            this.GameBoard = GenerateGameBoard();
        }

        private string[,] GenerateGameBoard()
        {
            string[,] gameBoard = new string[this.Rows, this.Cols];

            AddBombs(gameBoard);

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
                } while (gameBoard[randomPlaceI, randomPlaceJ] != null);

                string randomDigit = Convert.ToString(randomNumber.Next(1, 6));
                gameBoard[randomPlaceI, randomPlaceJ] = randomDigit;
                count++;
            }
        }

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
    }
}
