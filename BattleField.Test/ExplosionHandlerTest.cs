using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BattleField;

namespace BattleField.Test
{
    [TestClass]
    public class ExplosionHandlerTest
    {
        [TestMethod]
        public void HitMineTest_sizeOne()
        {
            const int testMatrixSize = 3;

            string[,] initialBoard1 = new string[testMatrixSize, testMatrixSize]
            {
                {"-", "-", "-"},
                {"-", "1", "-"},
                {"-", "-", "-"}
            };
            string[,] expectedBoard1 = new string[testMatrixSize, testMatrixSize]
            {
                {"X", "-", "X"},
                {"-", "X", "-"},
                {"X", "-", "X"}
            };
            Assert.IsTrue(CheckForEqualOutput(testMatrixSize, 1, 1, initialBoard1, expectedBoard1));

            string[,] initialBoard2 = new string[testMatrixSize, testMatrixSize]
            {
                {"-", "-", "1"},
                {"-", "-", "-"},
                {"-", "-", "-"}
            };
            string[,] expectedBoard2 = new string[testMatrixSize, testMatrixSize]
            {
                {"-", "-", "X"},
                {"-", "X", "-"},
                {"-", "-", "-"}
            };
            Assert.IsTrue(CheckForEqualOutput(testMatrixSize, 0, 2, initialBoard2, expectedBoard2));

            string[,] initialBoard3 = new string[testMatrixSize, testMatrixSize]
            {
                {"1", "-", "-"},
                {"-", "-", "-"},
                {"-", "-", "-"}
            };
            string[,] expectedBoard3 = new string[testMatrixSize, testMatrixSize]
            {
                {"X", "-", "-"},
                {"-", "X", "-"},
                {"-", "-", "-"}
            };
            Assert.IsTrue(CheckForEqualOutput(testMatrixSize, 0, 0, initialBoard3, expectedBoard3));

            string[,] initialBoard4 = new string[testMatrixSize, testMatrixSize]
            {
                {"-", "-", "-"},
                {"-", "-", "-"},
                {"1", "-", "-"}
            };
            string[,] expectedBoard4 = new string[testMatrixSize, testMatrixSize]
            {
                {"-", "-", "-"},
                {"-", "X", "-"},
                {"X", "-", "-"}
            };
            Assert.IsTrue(CheckForEqualOutput(testMatrixSize, 2, 0, initialBoard4, expectedBoard4));

            string[,] initialBoard5 = new string[testMatrixSize, testMatrixSize]
            {
                {"-", "-", "-"},
                {"-", "-", "-"},
                {"-", "-", "1"}
            };
            string[,] expectedBoard5 = new string[testMatrixSize, testMatrixSize]
            {
                {"-", "-", "-"},
                {"-", "X", "-"},
                {"-", "-", "X"}
            };
            Assert.IsTrue(CheckForEqualOutput(testMatrixSize, 2, 2, initialBoard5, expectedBoard5));
        }

        [TestMethod]
        public void HitMineTest_sizeTwo()
        {
            const int testMatrixSize = 3;

            string[,] initialBoard1 = new string[testMatrixSize, testMatrixSize]
            {
                {"-", "-", "-"},
                {"-", "2", "-"},
                {"-", "-", "-"}
            };
            string[,] expectedBoard1 = new string[testMatrixSize, testMatrixSize]
            {
                {"X", "X", "X"},
                {"X", "X", "X"},
                {"X", "X", "X"}
            };
            Assert.IsTrue(CheckForEqualOutput(testMatrixSize, 1, 1, initialBoard1, expectedBoard1));

            string[,] initialBoard2 = new string[testMatrixSize, testMatrixSize]
            {
                {"-", "-", "2"},
                {"-", "-", "-"},
                {"-", "-", "-"}
            };
            string[,] expectedBoard2 = new string[testMatrixSize, testMatrixSize]
            {
                {"-", "X", "X"},
                {"-", "X", "X"},
                {"-", "-", "-"}
            };
            Assert.IsTrue(CheckForEqualOutput(testMatrixSize, 0, 2, initialBoard2, expectedBoard2));

            string[,] initialBoard3 = new string[testMatrixSize, testMatrixSize]
            {
                {"2", "-", "-"},
                {"-", "-", "-"},
                {"-", "-", "-"}
            };
            string[,] expectedBoard3 = new string[testMatrixSize, testMatrixSize]
            {
                {"X", "X", "-"},
                {"X", "X", "-"},
                {"-", "-", "-"}
            };
            Assert.IsTrue(CheckForEqualOutput(testMatrixSize, 0, 0, initialBoard3, expectedBoard3));

            string[,] initialBoard4 = new string[testMatrixSize, testMatrixSize]
            {
                {"-", "-", "-"},
                {"-", "-", "-"},
                {"2", "-", "-"}
            };
            string[,] expectedBoard4 = new string[testMatrixSize, testMatrixSize]
            {
                {"-", "-", "-"},
                {"X", "X", "-"},
                {"X", "X", "-"}
            };
            Assert.IsTrue(CheckForEqualOutput(testMatrixSize, 2, 0, initialBoard4, expectedBoard4));

            string[,] initialBoard5 = new string[testMatrixSize, testMatrixSize]
            {
                {"-", "-", "-"},
                {"-", "-", "-"},
                {"-", "-", "2"}
            };
            string[,] expectedBoard5 = new string[testMatrixSize, testMatrixSize]
            {
                {"-", "-", "-"},
                {"-", "X", "X"},
                {"-", "X", "X"}
            };
            Assert.IsTrue(CheckForEqualOutput(testMatrixSize, 2, 2, initialBoard5, expectedBoard5));
        }

        [TestMethod]
        public void HitMineTest_sizeThree()
        {
            const int testMatrixSize = 5;

            string[,] initialBoard1 = new string[testMatrixSize, testMatrixSize]
            {
                {"-", "-", "-", "-", "-"},
                {"-", "-", "-", "-", "-"},
                {"-", "-", "3", "-", "-"},
                {"-", "-", "-", "-", "-"},
                {"-", "-", "-", "-", "-"}
            };
            string[,] expectedBoard1 = new string[testMatrixSize, testMatrixSize]
            {
                {"-", "-", "X", "-", "-"},
                {"-", "X", "X", "X", "-"},
                {"X", "X", "X", "X", "X"},
                {"-", "X", "X", "X", "-"},
                {"-", "-", "X", "-", "-"}
            };
            Assert.IsTrue(CheckForEqualOutput(testMatrixSize, 2, 2, initialBoard1, expectedBoard1));

            string[,] initialBoard2 = new string[testMatrixSize, testMatrixSize]
            {
                {"3", "-", "-", "-", "-"},
                {"-", "-", "-", "-", "-"},
                {"-", "-", "-", "-", "-"},
                {"-", "-", "-", "-", "-"},
                {"-", "-", "-", "-", "-"}
            };
            string[,] expectedBoard2 = new string[testMatrixSize, testMatrixSize]
            {
                {"X", "X", "X", "-", "-"},
                {"X", "X", "-", "-", "-"},
                {"X", "-", "-", "-", "-"},
                {"-", "-", "-", "-", "-"},
                {"-", "-", "-", "-", "-"}
            };
            Assert.IsTrue(CheckForEqualOutput(testMatrixSize, 0, 0, initialBoard2, expectedBoard2));

            string[,] initialBoard3 = new string[testMatrixSize, testMatrixSize]
            {
                {"-", "-", "-", "-", "-"},
                {"-", "-", "-", "-", "-"},
                {"-", "-", "-", "-", "-"},
                {"-", "-", "-", "-", "-"},
                {"-", "-", "-", "-", "3"}
            };
            string[,] expectedBoard3 = new string[testMatrixSize, testMatrixSize]
            {
                {"-", "-", "-", "-", "-"},
                {"-", "-", "-", "-", "-"},
                {"-", "-", "-", "-", "X"},
                {"-", "-", "-", "X", "X"},
                {"-", "-", "X", "X", "X"}
            };
            Assert.IsTrue(CheckForEqualOutput(testMatrixSize, 4, 4, initialBoard3, expectedBoard3));

            string[,] initialBoard4 = new string[testMatrixSize, testMatrixSize]
            {
                {"-", "-", "-", "-", "-"},
                {"-", "-", "-", "-", "-"},
                {"-", "-", "-", "-", "-"},
                {"-", "3", "-", "-", "-"},
                {"-", "-", "-", "-", "-"}
            };
            string[,] expectedBoard4 = new string[testMatrixSize, testMatrixSize]
            {
                {"-", "-", "-", "-", "-"},
                {"-", "X", "-", "-", "-"},
                {"X", "X", "X", "-", "-"},
                {"X", "X", "X", "X", "-"},
                {"X", "X", "X", "-", "-"}
            };
            Assert.IsTrue(CheckForEqualOutput(testMatrixSize, 3, 1, initialBoard4, expectedBoard4));

            string[,] initialBoard5 = new string[testMatrixSize, testMatrixSize]
            {
                {"-", "-", "-", "-", "-"},
                {"-", "-", "-", "3", "-"},
                {"-", "-", "-", "-", "-"},
                {"-", "-", "-", "-", "-"},
                {"-", "-", "-", "-", "-"}
            };
            string[,] expectedBoard5 = new string[testMatrixSize, testMatrixSize]
            {
                {"-", "-", "X", "X", "X"},
                {"-", "X", "X", "X", "X"},
                {"-", "-", "X", "X", "X"},
                {"-", "-", "-", "X", "-"},
                {"-", "-", "-", "-", "-"}
            };
            Assert.IsTrue(CheckForEqualOutput(testMatrixSize, 1, 3, initialBoard5, expectedBoard5));
        }

        [TestMethod]
        public void HitMineTest_sizeFour()
        {
            const int testMatrixSize = 5;

            string[,] initialBoard1 = new string[testMatrixSize, testMatrixSize]
            {
                {"-", "-", "-", "-", "-"},
                {"-", "-", "-", "-", "-"},
                {"-", "-", "4", "-", "-"},
                {"-", "-", "-", "-", "-"},
                {"-", "-", "-", "-", "-"}
            };
            string[,] expectedBoard1 = new string[testMatrixSize, testMatrixSize]
            {
                {"-", "X", "X", "X", "-"},
                {"X", "X", "X", "X", "X"},
                {"X", "X", "X", "X", "X"},
                {"X", "X", "X", "X", "X"},
                {"-", "X", "X", "X", "-"}
            };
            Assert.IsTrue(CheckForEqualOutput(testMatrixSize, 2, 2, initialBoard1, expectedBoard1));

            string[,] initialBoard2 = new string[testMatrixSize, testMatrixSize]
            {
                {"4", "-", "-", "-", "-"},
                {"-", "-", "-", "-", "-"},
                {"-", "-", "-", "-", "-"},
                {"-", "-", "-", "-", "-"},
                {"-", "-", "-", "-", "-"}
            };
            string[,] expectedBoard2 = new string[testMatrixSize, testMatrixSize]
            {
                {"X", "X", "X", "-", "-"},
                {"X", "X", "X", "-", "-"},
                {"X", "X", "-", "-", "-"},
                {"-", "-", "-", "-", "-"},
                {"-", "-", "-", "-", "-"}
            };
            Assert.IsTrue(CheckForEqualOutput(testMatrixSize, 0, 0, initialBoard2, expectedBoard2));

            string[,] initialBoard3 = new string[testMatrixSize, testMatrixSize]
            {
                {"-", "-", "-", "-", "-"},
                {"-", "-", "-", "-", "-"},
                {"-", "-", "-", "-", "-"},
                {"-", "-", "-", "-", "-"},
                {"-", "-", "-", "-", "4"}
            };
            string[,] expectedBoard3 = new string[testMatrixSize, testMatrixSize]
            {
                {"-", "-", "-", "-", "-"},
                {"-", "-", "-", "-", "-"},
                {"-", "-", "-", "X", "X"},
                {"-", "-", "X", "X", "X"},
                {"-", "-", "X", "X", "X"}
            };
            Assert.IsTrue(CheckForEqualOutput(testMatrixSize, 4, 4, initialBoard3, expectedBoard3));

            string[,] initialBoard4 = new string[testMatrixSize, testMatrixSize]
            {
                {"-", "-", "-", "-", "-"},
                {"-", "-", "-", "-", "-"},
                {"-", "-", "-", "-", "-"},
                {"-", "4", "-", "-", "-"},
                {"-", "-", "-", "-", "-"}
            };
            string[,] expectedBoard4 = new string[testMatrixSize, testMatrixSize]
            {
                {"-", "-", "-", "-", "-"},
                {"X", "X", "X", "-", "-"},
                {"X", "X", "X", "X", "-"},
                {"X", "X", "X", "X", "-"},
                {"X", "X", "X", "X", "-"}
            };
            Assert.IsTrue(CheckForEqualOutput(testMatrixSize, 3, 1, initialBoard4, expectedBoard4));

            string[,] initialBoard5 = new string[testMatrixSize, testMatrixSize]
            {
                {"-", "-", "-", "-", "-"},
                {"-", "-", "-", "4", "-"},
                {"-", "-", "-", "-", "-"},
                {"-", "-", "-", "-", "-"},
                {"-", "-", "-", "-", "-"}
            };
            string[,] expectedBoard5 = new string[testMatrixSize, testMatrixSize]
            {
                {"-", "X", "X", "X", "X"},
                {"-", "X", "X", "X", "X"},
                {"-", "X", "X", "X", "X"},
                {"-", "-", "X", "X", "X"},
                {"-", "-", "-", "-", "-"}
            };
            Assert.IsTrue(CheckForEqualOutput(testMatrixSize, 1, 3, initialBoard5, expectedBoard5));
        }

        [TestMethod]
        public void HitMineTest_sizeFive()
        {
            const int testMatrixSize = 5;

            string[,] initialBoard1 = new string[testMatrixSize, testMatrixSize]
            {
                {"-", "-", "-", "-", "-"},
                {"-", "-", "-", "-", "-"},
                {"-", "-", "5", "-", "-"},
                {"-", "-", "-", "-", "-"},
                {"-", "-", "-", "-", "-"}
            };
            string[,] expectedBoard1 = new string[testMatrixSize, testMatrixSize]
            {
                {"X", "X", "X", "X", "X"},
                {"X", "X", "X", "X", "X"},
                {"X", "X", "X", "X", "X"},
                {"X", "X", "X", "X", "X"},
                {"X", "X", "X", "X", "X"}
            };
            Assert.IsTrue(CheckForEqualOutput(testMatrixSize, 2, 2, initialBoard1, expectedBoard1));

            string[,] initialBoard2 = new string[testMatrixSize, testMatrixSize]
            {
                {"5", "-", "-", "-", "-"},
                {"-", "-", "-", "-", "-"},
                {"-", "-", "-", "-", "-"},
                {"-", "-", "-", "-", "-"},
                {"-", "-", "-", "-", "-"}
            };
            string[,] expectedBoard2 = new string[testMatrixSize, testMatrixSize]
            {
                {"X", "X", "X", "-", "-"},
                {"X", "X", "X", "-", "-"},
                {"X", "X", "X", "-", "-"},
                {"-", "-", "-", "-", "-"},
                {"-", "-", "-", "-", "-"}
            };
            Assert.IsTrue(CheckForEqualOutput(testMatrixSize, 0, 0, initialBoard2, expectedBoard2));

            string[,] initialBoard3 = new string[testMatrixSize, testMatrixSize]
            {
                {"-", "-", "-", "-", "-"},
                {"-", "-", "-", "-", "-"},
                {"-", "-", "-", "-", "-"},
                {"-", "-", "-", "-", "-"},
                {"-", "-", "-", "-", "5"}
            };
            string[,] expectedBoard3 = new string[testMatrixSize, testMatrixSize]
            {
                {"-", "-", "-", "-", "-"},
                {"-", "-", "-", "-", "-"},
                {"-", "-", "X", "X", "X"},
                {"-", "-", "X", "X", "X"},
                {"-", "-", "X", "X", "X"}
            };
            Assert.IsTrue(CheckForEqualOutput(testMatrixSize, 4, 4, initialBoard3, expectedBoard3));

            string[,] initialBoard4 = new string[testMatrixSize, testMatrixSize]
            {
                {"-", "-", "-", "-", "-"},
                {"-", "-", "-", "-", "-"},
                {"-", "-", "-", "-", "-"},
                {"-", "5", "-", "-", "-"},
                {"-", "-", "-", "-", "-"}
            };
            string[,] expectedBoard4 = new string[testMatrixSize, testMatrixSize]
            {
                {"-", "-", "-", "-", "-"},
                {"X", "X", "X", "X", "-"},
                {"X", "X", "X", "X", "-"},
                {"X", "X", "X", "X", "-"},
                {"X", "X", "X", "X", "-"}
            };
            Assert.IsTrue(CheckForEqualOutput(testMatrixSize, 3, 1, initialBoard4, expectedBoard4));

            string[,] initialBoard5 = new string[testMatrixSize, testMatrixSize]
            {
                {"-", "-", "-", "-", "-"},
                {"-", "-", "-", "5", "-"},
                {"-", "-", "-", "-", "-"},
                {"-", "-", "-", "-", "-"},
                {"-", "-", "-", "-", "-"}
            };
            string[,] expectedBoard5 = new string[testMatrixSize, testMatrixSize]
            {
                {"-", "X", "X", "X", "X"},
                {"-", "X", "X", "X", "X"},
                {"-", "X", "X", "X", "X"},
                {"-", "X", "X", "X", "X"},
                {"-", "-", "-", "-", "-"}
            };
            Assert.IsTrue(CheckForEqualOutput(testMatrixSize, 1, 3, initialBoard5, expectedBoard5));
        }

        private static void SetBoard(Board board, string[,] initialBoard)
        {
            for (int row = 0; row < board.Rows; row++)
            {
                for (int col = 0; col < board.Cols; col++)
                {
                    board.GameBoard[row, col] = initialBoard[row, col];
                }
            }
        }

        private static bool CheckForEqualOutput(int gameFieldSize, int x, int y, string[,] initialBoard, string[,] expectedBoard)
        {
            bool boardsAreEqual = true;
            Board board = new Board(gameFieldSize);
            SetBoard(board, initialBoard);

            ExplosionHandler.HitMine(board, x, y);

            for (int i = 0; i < gameFieldSize; i++)
            {
                for (int j = 0; j < gameFieldSize; j++)
                {
                    if (expectedBoard[i, j] != board.GameBoard[i, j])
                    {
                        boardsAreEqual = false;
                        break;
                    }
                }
            }
            return boardsAreEqual;
        }
    }
}
