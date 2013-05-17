using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BattleField.Test
{
    [TestClass]
    public class BoardTest
    {
        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void TestBoardConstructor_NegativeSize()
        {
            Board gameBoard = new Board(-1);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void TestBoardConstructor_SizeBiggerThan10()
        {
            Board gameBoard = new Board(11);
        }

        [TestMethod]
        public void TestBoardConstructor_SizeEqualTo10()
        {
            Board gameBoard = new Board(10);
            Assert.AreEqual(10, gameBoard.Rows);
            Assert.AreEqual(10, gameBoard.Cols);
        }

        [TestMethod]
        public void TestBoardToString_BoardSize1()
        {
            Board gameBoard = new Board(1);
            StringBuilder expectedBoardToString = new StringBuilder();
            expectedBoardToString.AppendLine("  0");
            expectedBoardToString.AppendLine("  -");
            expectedBoardToString.AppendLine("0|" + gameBoard.GameBoard[0, 0] + " ");
            string boardToString = gameBoard.ToString();
            Assert.AreEqual(expectedBoardToString.ToString(), boardToString);
        }

        [TestMethod]
        public void TestBoardToString_BoardSize3()
        {
            Board gameBoard = new Board(3);
            StringBuilder expectedBoardToString = new StringBuilder();
            expectedBoardToString.AppendLine("  0 1 2");
            expectedBoardToString.AppendLine("  -----");
            expectedBoardToString.AppendLine("0|" + gameBoard.GameBoard[0, 0] + " " + gameBoard.GameBoard[0, 1] + " " +
                                             gameBoard.GameBoard[0, 2] + " ");
            expectedBoardToString.AppendLine("1|" + gameBoard.GameBoard[1, 0] + " " + gameBoard.GameBoard[1, 1] + " " +
                                             gameBoard.GameBoard[1, 2] + " ");
            expectedBoardToString.AppendLine("2|" + gameBoard.GameBoard[2, 0] + " " + gameBoard.GameBoard[2, 1] + " " +
                                             gameBoard.GameBoard[2, 2] + " ");
            string boardToString = gameBoard.ToString();
            Assert.AreEqual(expectedBoardToString.ToString(), boardToString);
        }

        [TestMethod]
        public void TestBoardToString_BoardSize10()
        {
            Board gameBoard = new Board(10);
            StringBuilder expectedBoardToString = new StringBuilder();
            expectedBoardToString.AppendLine("  0 1 2 3 4 5 6 7 8 9");
            expectedBoardToString.AppendLine("  -------------------");
            expectedBoardToString.AppendLine("0|" + gameBoard.GameBoard[0, 0] + " " + gameBoard.GameBoard[0, 1] + " " +
                                             gameBoard.GameBoard[0, 2] + " " +
                                             gameBoard.GameBoard[0, 3] + " " + gameBoard.GameBoard[0, 4] + " " +
                                             gameBoard.GameBoard[0, 5] + " " +
                                             gameBoard.GameBoard[0, 6] + " " + gameBoard.GameBoard[0, 7] + " " +
                                             gameBoard.GameBoard[0, 8] + " " +
                                             gameBoard.GameBoard[0, 9] + " ");
            expectedBoardToString.AppendLine("1|" + gameBoard.GameBoard[1, 0] + " " + gameBoard.GameBoard[1, 1] + " " +
                                             gameBoard.GameBoard[1, 2] + " " +
                                             gameBoard.GameBoard[1, 3] + " " + gameBoard.GameBoard[1, 4] + " " +
                                             gameBoard.GameBoard[1, 5] + " " +
                                             gameBoard.GameBoard[1, 6] + " " + gameBoard.GameBoard[1, 7] + " " +
                                             gameBoard.GameBoard[1, 8] + " " +
                                             gameBoard.GameBoard[1, 9] + " ");
            expectedBoardToString.AppendLine("2|" + gameBoard.GameBoard[2, 0] + " " + gameBoard.GameBoard[2, 1] + " " +
                                             gameBoard.GameBoard[2, 2] + " " +
                                             gameBoard.GameBoard[2, 3] + " " + gameBoard.GameBoard[2, 4] + " " +
                                             gameBoard.GameBoard[2, 5] + " " +
                                             gameBoard.GameBoard[2, 6] + " " + gameBoard.GameBoard[2, 7] + " " +
                                             gameBoard.GameBoard[2, 8] + " " +
                                             gameBoard.GameBoard[2, 9] + " ");
            expectedBoardToString.AppendLine("3|" + gameBoard.GameBoard[3, 0] + " " + gameBoard.GameBoard[3, 1] + " " +
                                             gameBoard.GameBoard[3, 2] + " " +
                                             gameBoard.GameBoard[3, 3] + " " + gameBoard.GameBoard[3, 4] + " " +
                                             gameBoard.GameBoard[3, 5] + " " +
                                             gameBoard.GameBoard[3, 6] + " " + gameBoard.GameBoard[3, 7] + " " +
                                             gameBoard.GameBoard[3, 8] + " " +
                                             gameBoard.GameBoard[3, 9] + " ");
            expectedBoardToString.AppendLine("4|" + gameBoard.GameBoard[4, 0] + " " + gameBoard.GameBoard[4, 1] + " " +
                                             gameBoard.GameBoard[4, 2] + " " +
                                             gameBoard.GameBoard[4, 3] + " " + gameBoard.GameBoard[4, 4] + " " +
                                             gameBoard.GameBoard[4, 5] + " " +
                                             gameBoard.GameBoard[4, 6] + " " + gameBoard.GameBoard[4, 7] + " " +
                                             gameBoard.GameBoard[4, 8] + " " +
                                             gameBoard.GameBoard[4, 9] + " ");
            expectedBoardToString.AppendLine("5|" + gameBoard.GameBoard[5, 0] + " " + gameBoard.GameBoard[5, 1] + " " +
                                             gameBoard.GameBoard[5, 2] + " " +
                                             gameBoard.GameBoard[5, 3] + " " + gameBoard.GameBoard[5, 4] + " " +
                                             gameBoard.GameBoard[5, 5] + " " +
                                             gameBoard.GameBoard[5, 6] + " " + gameBoard.GameBoard[5, 7] + " " +
                                             gameBoard.GameBoard[5, 8] + " " +
                                             gameBoard.GameBoard[5, 9] + " ");
            expectedBoardToString.AppendLine("6|" + gameBoard.GameBoard[6, 0] + " " + gameBoard.GameBoard[6, 1] + " " +
                                             gameBoard.GameBoard[6, 2] + " " +
                                             gameBoard.GameBoard[6, 3] + " " + gameBoard.GameBoard[6, 4] + " " +
                                             gameBoard.GameBoard[6, 5] + " " +
                                             gameBoard.GameBoard[6, 6] + " " + gameBoard.GameBoard[6, 7] + " " +
                                             gameBoard.GameBoard[6, 8] + " " +
                                             gameBoard.GameBoard[6, 9] + " ");
            expectedBoardToString.AppendLine("7|" + gameBoard.GameBoard[7, 0] + " " + gameBoard.GameBoard[7, 1] + " " +
                                             gameBoard.GameBoard[7, 2] + " " +
                                             gameBoard.GameBoard[7, 3] + " " + gameBoard.GameBoard[7, 4] + " " +
                                             gameBoard.GameBoard[7, 5] + " " +
                                             gameBoard.GameBoard[7, 6] + " " + gameBoard.GameBoard[7, 7] + " " +
                                             gameBoard.GameBoard[7, 8] + " " +
                                             gameBoard.GameBoard[7, 9] + " ");
            expectedBoardToString.AppendLine("8|" + gameBoard.GameBoard[8, 0] + " " + gameBoard.GameBoard[8, 1] + " " +
                                             gameBoard.GameBoard[8, 2] + " " +
                                             gameBoard.GameBoard[8, 3] + " " + gameBoard.GameBoard[8, 4] + " " +
                                             gameBoard.GameBoard[8, 5] + " " +
                                             gameBoard.GameBoard[8, 6] + " " + gameBoard.GameBoard[8, 7] + " " +
                                             gameBoard.GameBoard[8, 8] + " " +
                                             gameBoard.GameBoard[8, 9] + " ");
            expectedBoardToString.AppendLine("9|" + gameBoard.GameBoard[9, 0] + " " + gameBoard.GameBoard[9, 1] + " " +
                                             gameBoard.GameBoard[9, 2] + " " +
                                             gameBoard.GameBoard[9, 3] + " " + gameBoard.GameBoard[9, 4] + " " +
                                             gameBoard.GameBoard[9, 5] + " " +
                                             gameBoard.GameBoard[9, 6] + " " + gameBoard.GameBoard[9, 7] + " " +
                                             gameBoard.GameBoard[9, 8] + " " +
                                             gameBoard.GameBoard[9, 9] + " ");
            string boardToString = gameBoard.ToString();
            Assert.AreEqual(expectedBoardToString.ToString(), boardToString);
        }
    }
}