using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BattleField.Tests
{
    [TestClass]
    public class AddBombsTest
    {
        private string[,] gameField;
        // Venelin - GenerateGameField just copied from main class.
        // Should be refactored or removed.
        private static void GenerateGameField(String[,] gameField)
        {
            int rows = gameField.GetLength(0);
            int cols = gameField.GetLength(1);

            gameField[0, 0] = " ";
            gameField[0, 1] = " ";
            gameField[1, 0] = " ";
            gameField[1, 1] = " ";

            for (int row = 2; row < rows; row++)
            {
                for (int col = 2; col < cols; col++)
                {
                    if (col % 2 == 0)
                    {
                        if (col == 2)
                        {
                            gameField[0, col] = "0";
                        }
                        else
                        {
                            gameField[0, col] = Convert.ToString((col - 2) / 2);
                        }
                    }
                    else
                    {
                        gameField[0, col] = " ";
                    }
                    if (col < cols - 1)
                    {
                        gameField[1, col] = "-";
                    }

                    gameField[row, 0] = Convert.ToString(row - 2);
                    gameField[row, 1] = "|";
                    if (col % 2 == 0)
                    {
                        gameField[row, col] = "-";
                    }
                    else
                    {
                        gameField[row, col] = " ";
                    }
                }
            }
        }

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
            int gameFieldSize = 5;
            int rows = gameFieldSize + 2;
            int cols = gameFieldSize * 2 + 2;
            gameField = new String[rows, cols];
            GenerateGameField(gameField);
        }

        [TestMethod]
        public void ValidFieldGenerated()
        {
            Methods.AddBombs(gameField);

            Assert.IsTrue(IsValidField(gameField));
        }
    }
}
