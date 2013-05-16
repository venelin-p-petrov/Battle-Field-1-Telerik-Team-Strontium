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
            string[,] initialBoard = new string[3, 3]
            {
                {"-", "-", "-"},
                {"-", "1", "-"},
                {"-", "-", "-"}
            };

            string[,] expectedBoard = new string[3, 3]
            {
                {"X", "-", "X"},
                {"-", "X", "-"},
                {"X", "-", "X"}
            };

            Assert.IsTrue(CheckIfEqual(3, initialBoard, expectedBoard));
        }

        [TestMethod]
        public void HitMineTest_sizeTwo()
        {
            string[,] initialBoard = new string[3, 3]
            {
                {"-", "-", "-"},
                {"-", "2", "-"},
                {"-", "-", "-"}
            };

            string[,] expectedBoard = new string[3, 3]
            {
                {"X", "X", "X"},
                {"X", "X", "X"},
                {"X", "X", "X"}
            };

            Assert.IsTrue(CheckIfEqual(3, initialBoard, expectedBoard));
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

        private static bool CheckIfEqual(int gameFieldSize, string[,] initialBoard, string[,] expectedBoard)
        {
            bool boardsAreEqual = true;
            Board board = new Board(gameFieldSize);
            SetBoard(board, initialBoard);

            ExplosionHandler.HitMine(board, 1, 1);

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
