using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleField
{
    class Board
    {
        private int rows = 0;
        private int cols = 0;
        private string[,] gameBoard = new string[1, 1];

        public int Rows 
        {
            get
            {
                return this.rows;
            }
            protected set
            {
                this.rows = value;
            }        
        }

        public int Cols 
        {
            get
            {
                return this.cols;
            }
            protected set
            {
                this.cols = value;
            } 
        }

        public string[,] GameBoard 
        {
            get 
            {
                return this.gameBoard;
            }
            protected set 
            {
                this.gameBoard = value;
            } 
        }

        public Board(int rows, int cols) 
        {
            this.Rows = rows;
            this.Cols = cols;
            this.GameBoard = CreateGameBoard();
        }

        private string[,] CreateGameBoard()
        {
            string[,] gameBoard = new string[rows, cols];

            gameBoard[0, 0] = " ";
            gameBoard[0, 1] = " ";
            gameBoard[1, 0] = " ";
            gameBoard[1, 1] = " ";

            for (int row = 2; row < rows; row++)
            {
                for (int col = 2; col < cols; col++)
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
                    if (col < cols - 1)
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
            
            Methods.AddBombs(gameBoard);
            
            return gameBoard;
        }        
    }
}
