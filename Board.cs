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
                throw new ArgumentException("Ivalid board size!");
            }
            this.Rows = gameBoardSize + 2;
            this.Cols = (gameBoardSize * 2) + 2;
            this.GameBoard = this.CreateGameBoard();
        }

        private string[,] CreateGameBoard()
        {
            string[,] gameBoard = new string[this.Rows, this.Cols];

            gameBoard[0, 0] = " ";
            gameBoard[0, 1] = " ";
            gameBoard[1, 0] = " ";
            gameBoard[1, 1] = " ";

            for (int row = 2; row < this.Rows; row++)
            {
                for (int col = 2; col < this.Cols; col++)
                {
                    if (col % 2 == 0)
                    {
                        if (col == 2)
                        {
                            gameBoard[0, col] = "0";
                        }
                        else
                        {
                            gameBoard[0, col] = Convert.ToString((col - 2) / 2);
                        }
                    }
                    else
                    {
                        gameBoard[0, col] = " ";
                    }

                    if (col < this.Cols - 1)
                    {
                        gameBoard[1, col] = "-";
                    }

                    gameBoard[row, 0] = Convert.ToString(row - 2);
                    gameBoard[row, 1] = "|";
                    if (col % 2 == 0)
                    {
                        gameBoard[row, col] = "-";
                    }
                    else
                    {
                        gameBoard[row, col] = " ";
                    }
                }
            }
            
            GameEngine.AddBombs(gameBoard);
            
            return gameBoard;
        }        
    }
}
