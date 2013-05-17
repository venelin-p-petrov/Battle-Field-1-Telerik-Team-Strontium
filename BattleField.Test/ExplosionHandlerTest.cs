namespace BattleField.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ExplosionHandlerTest
    {
        [TestMethod]
        public void HitMineTest_sizeOne()
        {
            const int testMatrixSize = 3;

            var initialBoard1 = new string[testMatrixSize,testMatrixSize]
                {
                    {"-", "-", "-"},
                    {"-", "1", "-"},
                    {"-", "-", "-"}
                };
            var expectedBoard1 = new string[testMatrixSize,testMatrixSize]
                {
                    {"X", "-", "X"},
                    {"-", "X", "-"},
                    {"X", "-", "X"}
                };
            Assert.IsTrue(CheckForEqualOutput(testMatrixSize, 1, 1, initialBoard1, expectedBoard1));

            var initialBoard2 = new string[testMatrixSize,testMatrixSize]
                {
                    {"-", "-", "1"},
                    {"-", "-", "-"},
                    {"-", "-", "-"}
                };
            var expectedBoard2 = new string[testMatrixSize,testMatrixSize]
                {
                    {"-", "-", "X"},
                    {"-", "X", "-"},
                    {"-", "-", "-"}
                };
            Assert.IsTrue(CheckForEqualOutput(testMatrixSize, 0, 2, initialBoard2, expectedBoard2));

            var initialBoard3 = new string[testMatrixSize,testMatrixSize]
                {
                    {"1", "-", "-"},
                    {"-", "-", "-"},
                    {"-", "-", "-"}
                };
            var expectedBoard3 = new string[testMatrixSize,testMatrixSize]
                {
                    {"X", "-", "-"},
                    {"-", "X", "-"},
                    {"-", "-", "-"}
                };
            Assert.IsTrue(CheckForEqualOutput(testMatrixSize, 0, 0, initialBoard3, expectedBoard3));

            var initialBoard4 = new string[testMatrixSize,testMatrixSize]
                {
                    {"-", "-", "-"},
                    {"-", "-", "-"},
                    {"1", "-", "-"}
                };
            var expectedBoard4 = new string[testMatrixSize,testMatrixSize]
                {
                    {"-", "-", "-"},
                    {"-", "X", "-"},
                    {"X", "-", "-"}
                };
            Assert.IsTrue(CheckForEqualOutput(testMatrixSize, 2, 0, initialBoard4, expectedBoard4));

            var initialBoard5 = new string[testMatrixSize,testMatrixSize]
                {
                    {"-", "-", "-"},
                    {"-", "-", "-"},
                    {"-", "-", "1"}
                };
            var expectedBoard5 = new string[testMatrixSize,testMatrixSize]
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

            var initialBoard1 = new string[testMatrixSize,testMatrixSize]
                {
                    {"-", "-", "-"},
                    {"-", "2", "-"},
                    {"-", "-", "-"}
                };
            var expectedBoard1 = new string[testMatrixSize,testMatrixSize]
                {
                    {"X", "X", "X"},
                    {"X", "X", "X"},
                    {"X", "X", "X"}
                };
            Assert.IsTrue(CheckForEqualOutput(testMatrixSize, 1, 1, initialBoard1, expectedBoard1));

            var initialBoard2 = new string[testMatrixSize,testMatrixSize]
                {
                    {"-", "-", "2"},
                    {"-", "-", "-"},
                    {"-", "-", "-"}
                };
            var expectedBoard2 = new string[testMatrixSize,testMatrixSize]
                {
                    {"-", "X", "X"},
                    {"-", "X", "X"},
                    {"-", "-", "-"}
                };
            Assert.IsTrue(CheckForEqualOutput(testMatrixSize, 0, 2, initialBoard2, expectedBoard2));

            var initialBoard3 = new string[testMatrixSize,testMatrixSize]
                {
                    {"2", "-", "-"},
                    {"-", "-", "-"},
                    {"-", "-", "-"}
                };
            var expectedBoard3 = new string[testMatrixSize,testMatrixSize]
                {
                    {"X", "X", "-"},
                    {"X", "X", "-"},
                    {"-", "-", "-"}
                };
            Assert.IsTrue(CheckForEqualOutput(testMatrixSize, 0, 0, initialBoard3, expectedBoard3));

            var initialBoard4 = new string[testMatrixSize,testMatrixSize]
                {
                    {"-", "-", "-"},
                    {"-", "-", "-"},
                    {"2", "-", "-"}
                };
            var expectedBoard4 = new string[testMatrixSize,testMatrixSize]
                {
                    {"-", "-", "-"},
                    {"X", "X", "-"},
                    {"X", "X", "-"}
                };
            Assert.IsTrue(CheckForEqualOutput(testMatrixSize, 2, 0, initialBoard4, expectedBoard4));

            var initialBoard5 = new string[testMatrixSize,testMatrixSize]
                {
                    {"-", "-", "-"},
                    {"-", "-", "-"},
                    {"-", "-", "2"}
                };
            var expectedBoard5 = new string[testMatrixSize,testMatrixSize]
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

            var initialBoard1 = new string[testMatrixSize,testMatrixSize]
                {
                    {"-", "-", "-", "-", "-"},
                    {"-", "-", "-", "-", "-"},
                    {"-", "-", "3", "-", "-"},
                    {"-", "-", "-", "-", "-"},
                    {"-", "-", "-", "-", "-"}
                };
            var expectedBoard1 = new string[testMatrixSize,testMatrixSize]
                {
                    {"-", "-", "X", "-", "-"},
                    {"-", "X", "X", "X", "-"},
                    {"X", "X", "X", "X", "X"},
                    {"-", "X", "X", "X", "-"},
                    {"-", "-", "X", "-", "-"}
                };
            Assert.IsTrue(CheckForEqualOutput(testMatrixSize, 2, 2, initialBoard1, expectedBoard1));

            var initialBoard2 = new string[testMatrixSize,testMatrixSize]
                {
                    {"3", "-", "-", "-", "-"},
                    {"-", "-", "-", "-", "-"},
                    {"-", "-", "-", "-", "-"},
                    {"-", "-", "-", "-", "-"},
                    {"-", "-", "-", "-", "-"}
                };
            var expectedBoard2 = new string[testMatrixSize,testMatrixSize]
                {
                    {"X", "X", "X", "-", "-"},
                    {"X", "X", "-", "-", "-"},
                    {"X", "-", "-", "-", "-"},
                    {"-", "-", "-", "-", "-"},
                    {"-", "-", "-", "-", "-"}
                };
            Assert.IsTrue(CheckForEqualOutput(testMatrixSize, 0, 0, initialBoard2, expectedBoard2));

            var initialBoard3 = new string[testMatrixSize,testMatrixSize]
                {
                    {"-", "-", "-", "-", "-"},
                    {"-", "-", "-", "-", "-"},
                    {"-", "-", "-", "-", "-"},
                    {"-", "-", "-", "-", "-"},
                    {"-", "-", "-", "-", "3"}
                };
            var expectedBoard3 = new string[testMatrixSize,testMatrixSize]
                {
                    {"-", "-", "-", "-", "-"},
                    {"-", "-", "-", "-", "-"},
                    {"-", "-", "-", "-", "X"},
                    {"-", "-", "-", "X", "X"},
                    {"-", "-", "X", "X", "X"}
                };
            Assert.IsTrue(CheckForEqualOutput(testMatrixSize, 4, 4, initialBoard3, expectedBoard3));

            var initialBoard4 = new string[testMatrixSize,testMatrixSize]
                {
                    {"-", "-", "-", "-", "-"},
                    {"-", "-", "-", "-", "-"},
                    {"-", "-", "-", "-", "-"},
                    {"-", "3", "-", "-", "-"},
                    {"-", "-", "-", "-", "-"}
                };
            var expectedBoard4 = new string[testMatrixSize,testMatrixSize]
                {
                    {"-", "-", "-", "-", "-"},
                    {"-", "X", "-", "-", "-"},
                    {"X", "X", "X", "-", "-"},
                    {"X", "X", "X", "X", "-"},
                    {"X", "X", "X", "-", "-"}
                };
            Assert.IsTrue(CheckForEqualOutput(testMatrixSize, 3, 1, initialBoard4, expectedBoard4));

            var initialBoard5 = new string[testMatrixSize,testMatrixSize]
                {
                    {"-", "-", "-", "-", "-"},
                    {"-", "-", "-", "3", "-"},
                    {"-", "-", "-", "-", "-"},
                    {"-", "-", "-", "-", "-"},
                    {"-", "-", "-", "-", "-"}
                };
            var expectedBoard5 = new string[testMatrixSize,testMatrixSize]
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

            var initialBoard1 = new string[testMatrixSize,testMatrixSize]
                {
                    {"-", "-", "-", "-", "-"},
                    {"-", "-", "-", "-", "-"},
                    {"-", "-", "4", "-", "-"},
                    {"-", "-", "-", "-", "-"},
                    {"-", "-", "-", "-", "-"}
                };
            var expectedBoard1 = new string[testMatrixSize,testMatrixSize]
                {
                    {"-", "X", "X", "X", "-"},
                    {"X", "X", "X", "X", "X"},
                    {"X", "X", "X", "X", "X"},
                    {"X", "X", "X", "X", "X"},
                    {"-", "X", "X", "X", "-"}
                };
            Assert.IsTrue(CheckForEqualOutput(testMatrixSize, 2, 2, initialBoard1, expectedBoard1));

            var initialBoard2 = new string[testMatrixSize,testMatrixSize]
                {
                    {"4", "-", "-", "-", "-"},
                    {"-", "-", "-", "-", "-"},
                    {"-", "-", "-", "-", "-"},
                    {"-", "-", "-", "-", "-"},
                    {"-", "-", "-", "-", "-"}
                };
            var expectedBoard2 = new string[testMatrixSize,testMatrixSize]
                {
                    {"X", "X", "X", "-", "-"},
                    {"X", "X", "X", "-", "-"},
                    {"X", "X", "-", "-", "-"},
                    {"-", "-", "-", "-", "-"},
                    {"-", "-", "-", "-", "-"}
                };
            Assert.IsTrue(CheckForEqualOutput(testMatrixSize, 0, 0, initialBoard2, expectedBoard2));

            var initialBoard3 = new string[testMatrixSize,testMatrixSize]
                {
                    {"-", "-", "-", "-", "-"},
                    {"-", "-", "-", "-", "-"},
                    {"-", "-", "-", "-", "-"},
                    {"-", "-", "-", "-", "-"},
                    {"-", "-", "-", "-", "4"}
                };
            var expectedBoard3 = new string[testMatrixSize,testMatrixSize]
                {
                    {"-", "-", "-", "-", "-"},
                    {"-", "-", "-", "-", "-"},
                    {"-", "-", "-", "X", "X"},
                    {"-", "-", "X", "X", "X"},
                    {"-", "-", "X", "X", "X"}
                };
            Assert.IsTrue(CheckForEqualOutput(testMatrixSize, 4, 4, initialBoard3, expectedBoard3));

            var initialBoard4 = new string[testMatrixSize,testMatrixSize]
                {
                    {"-", "-", "-", "-", "-"},
                    {"-", "-", "-", "-", "-"},
                    {"-", "-", "-", "-", "-"},
                    {"-", "4", "-", "-", "-"},
                    {"-", "-", "-", "-", "-"}
                };
            var expectedBoard4 = new string[testMatrixSize,testMatrixSize]
                {
                    {"-", "-", "-", "-", "-"},
                    {"X", "X", "X", "-", "-"},
                    {"X", "X", "X", "X", "-"},
                    {"X", "X", "X", "X", "-"},
                    {"X", "X", "X", "X", "-"}
                };
            Assert.IsTrue(CheckForEqualOutput(testMatrixSize, 3, 1, initialBoard4, expectedBoard4));

            var initialBoard5 = new string[testMatrixSize,testMatrixSize]
                {
                    {"-", "-", "-", "-", "-"},
                    {"-", "-", "-", "4", "-"},
                    {"-", "-", "-", "-", "-"},
                    {"-", "-", "-", "-", "-"},
                    {"-", "-", "-", "-", "-"}
                };
            var expectedBoard5 = new string[testMatrixSize,testMatrixSize]
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

            var initialBoard1 = new string[testMatrixSize,testMatrixSize]
                {
                    {"-", "-", "-", "-", "-"},
                    {"-", "-", "-", "-", "-"},
                    {"-", "-", "5", "-", "-"},
                    {"-", "-", "-", "-", "-"},
                    {"-", "-", "-", "-", "-"}
                };
            var expectedBoard1 = new string[testMatrixSize,testMatrixSize]
                {
                    {"X", "X", "X", "X", "X"},
                    {"X", "X", "X", "X", "X"},
                    {"X", "X", "X", "X", "X"},
                    {"X", "X", "X", "X", "X"},
                    {"X", "X", "X", "X", "X"}
                };
            Assert.IsTrue(CheckForEqualOutput(testMatrixSize, 2, 2, initialBoard1, expectedBoard1));

            var initialBoard2 = new string[testMatrixSize,testMatrixSize]
                {
                    {"5", "-", "-", "-", "-"},
                    {"-", "-", "-", "-", "-"},
                    {"-", "-", "-", "-", "-"},
                    {"-", "-", "-", "-", "-"},
                    {"-", "-", "-", "-", "-"}
                };
            var expectedBoard2 = new string[testMatrixSize,testMatrixSize]
                {
                    {"X", "X", "X", "-", "-"},
                    {"X", "X", "X", "-", "-"},
                    {"X", "X", "X", "-", "-"},
                    {"-", "-", "-", "-", "-"},
                    {"-", "-", "-", "-", "-"}
                };
            Assert.IsTrue(CheckForEqualOutput(testMatrixSize, 0, 0, initialBoard2, expectedBoard2));

            var initialBoard3 = new string[testMatrixSize,testMatrixSize]
                {
                    {"-", "-", "-", "-", "-"},
                    {"-", "-", "-", "-", "-"},
                    {"-", "-", "-", "-", "-"},
                    {"-", "-", "-", "-", "-"},
                    {"-", "-", "-", "-", "5"}
                };
            var expectedBoard3 = new string[testMatrixSize,testMatrixSize]
                {
                    {"-", "-", "-", "-", "-"},
                    {"-", "-", "-", "-", "-"},
                    {"-", "-", "X", "X", "X"},
                    {"-", "-", "X", "X", "X"},
                    {"-", "-", "X", "X", "X"}
                };
            Assert.IsTrue(CheckForEqualOutput(testMatrixSize, 4, 4, initialBoard3, expectedBoard3));

            var initialBoard4 = new string[testMatrixSize,testMatrixSize]
                {
                    {"-", "-", "-", "-", "-"},
                    {"-", "-", "-", "-", "-"},
                    {"-", "-", "-", "-", "-"},
                    {"-", "5", "-", "-", "-"},
                    {"-", "-", "-", "-", "-"}
                };
            var expectedBoard4 = new string[testMatrixSize,testMatrixSize]
                {
                    {"-", "-", "-", "-", "-"},
                    {"X", "X", "X", "X", "-"},
                    {"X", "X", "X", "X", "-"},
                    {"X", "X", "X", "X", "-"},
                    {"X", "X", "X", "X", "-"}
                };
            Assert.IsTrue(CheckForEqualOutput(testMatrixSize, 3, 1, initialBoard4, expectedBoard4));

            var initialBoard5 = new string[testMatrixSize,testMatrixSize]
                {
                    {"-", "-", "-", "-", "-"},
                    {"-", "-", "-", "5", "-"},
                    {"-", "-", "-", "-", "-"},
                    {"-", "-", "-", "-", "-"},
                    {"-", "-", "-", "-", "-"}
                };
            var expectedBoard5 = new string[testMatrixSize,testMatrixSize]
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

        private static bool CheckForEqualOutput(int gameFieldSize, int x, int y, string[,] initialBoard,
                                                string[,] expectedBoard)
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