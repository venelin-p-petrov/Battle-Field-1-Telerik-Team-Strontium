using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BattleField.Tests
{
    // Venelin - Can't compile right now. Has to be rewriten.
    /*
    [TestClass]
    public class AddBombsTest
    {
        private Board board;

        private static bool IsValidField(String[,] gameField)
        {
            int rows = gameField.GetLength(0);
            int cols = gameField.GetLength(1);
            int mineCount = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < cols - 1; column++)
                {
                    if (row < 2 && column < 2)
                    {
                        if (gameField[row, column] != " ")
                        {
                            return false;
                        }
                    }
                    else if (column == 0 || (row == 0 && column % 2 == 0))
                    {
                        int result = 0;
                        if (!int.TryParse(gameField[row, column], out result))
                        {
                            return false;
                        }

                        if (result < 0 || 9 < result)
                        {
                            return false;
                        }
                    }
                    else if (row == 1)
                    {
                        if (gameField[row, column] != "-")
                        {
                            return false;
                        }
                    }
                    else if (column == 1)
                    {
                        if (gameField[row, column] != "|")
                        {
                            return false;
                        }
                    }
                    else if (column % 2 == 1)
                    {
                        if (gameField[row, column] != " ")
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (gameField[row, column] != "-")
                        {
                            int mine = 0;
                            if (!int.TryParse(gameField[row, column], out mine))
                            {
                                return false;
                            }
                            if (mine < 1 || 5 < mine)
                            {
                                return false;
                            }
                            else
                            {
                                mineCount++;
                            }
                        }
                    }
                }
            }

            int gameFieldSize = gameField.GetLength(0) - 2;
            int minPercent = Convert.ToInt32(0.15 * (gameFieldSize * gameFieldSize));
            int maxPercent = Convert.ToInt32(0.30 * (gameFieldSize * gameFieldSize));

            if (mineCount < minPercent || maxPercent < mineCount)
            {
                return false;
            }

            return true;
        }

        [TestInitialize()]
        public void Initialize()
        {
            int gameBoardSize = 5;
            board = new Board(gameBoardSize);
        }

        [TestMethod]
        public void ValidFieldGenerated()
        {
            Assert.IsTrue(IsValidField(board));
        }
    }
    */
}
