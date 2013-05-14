﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BattleField;

namespace BattleField.Test
{
    [TestClass]
    public class IsGameOverTest
    {
        [TestMethod]
        public void IsGameOverTest_IfNoBombsLeft()
        {
            for (int i = 1; i < 10; i++)
            {
                int gameFieldSize = i;
                int matrixSize = gameFieldSize + 2;
                string[,] testMatrix = new string[matrixSize, matrixSize];
                
                SetDefaultMatrixDisplay(testMatrix);
                //PrintTestMatrix(testMatrix);
                Assert.IsTrue(Methods.IsGameOver(testMatrix));
            }
        }

        [TestMethod]
        public void IsGameOverTest_IfBombAtTopLeft()
        {
            var random = new Random();
            for (int i = 1; i < 10; i++)
            {
                int gameFieldSize = i;
                int matrixSize = gameFieldSize + 2;
                string randomBombNumber = random.Next(1, 6).ToString();
                //Console.WriteLine(randomBombNumber);
                string[,] testMatrix = new string[matrixSize, matrixSize];

                SetDefaultMatrixDisplay(testMatrix);
                testMatrix[2, 2] = randomBombNumber;

                Assert.IsFalse(Methods.IsGameOver(testMatrix));
            }
        }

        [TestMethod]
        public void IsGameOverTest_IfBombAtTopRight()
        {
            var random = new Random();
            for (int i = 1; i < 10; i++)
            {
                int gameFieldSize = i;
                int matrixSize = gameFieldSize + 2;
                string randomBombNumber = random.Next(1, 6).ToString();
                //Console.WriteLine(randomBombNumber);
                string[,] testMatrix = new string[matrixSize, matrixSize];

                SetDefaultMatrixDisplay(testMatrix);
                testMatrix[2, matrixSize - 1] = randomBombNumber;

                Assert.IsFalse(Methods.IsGameOver(testMatrix));
            }
        }

        [TestMethod]
        public void IsGameOverTest_IfBombAtBottomLeft()
        {
            var random = new Random();
            for (int i = 1; i < 10; i++)
            {
                int gameFieldSize = i;
                int matrixSize = gameFieldSize + 2;
                string randomBombNumber = random.Next(1, 6).ToString();
                //Console.WriteLine(randomBombNumber);
                string[,] testMatrix = new string[matrixSize, matrixSize];

                SetDefaultMatrixDisplay(testMatrix);
                testMatrix[matrixSize - 1, 2] = randomBombNumber;

                Assert.IsFalse(Methods.IsGameOver(testMatrix));
            }
        }

        [TestMethod]
        public void IsGameOverTest_IfBombAtBottomRight()
        {
            var random = new Random();
            for (int i = 1; i < 10; i++)
            {
                int gameFieldSize = i;
                int matrixSize = gameFieldSize + 2;
                string randomBombNumber = random.Next(1, 6).ToString();
                //Console.WriteLine(randomBombNumber);
                string[,] testMatrix = new string[matrixSize, matrixSize];

                SetDefaultMatrixDisplay(testMatrix);
                testMatrix[matrixSize - 1, matrixSize - 1] = randomBombNumber;

                Assert.IsFalse(Methods.IsGameOver(testMatrix));
            }
        }

        private static void SetDefaultMatrixDisplay(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = " ";
                }
            }

            for (int row = 2; row < matrix.GetLength(0); row++)
            {
                //matrix[row, col]
                matrix[row, 0] = (row - 2).ToString();
                matrix[row, 1] = "|";
            }

            for (int col = 2; col < matrix.GetLength(1); col++)
            {
                //matrix[row, col]
                matrix[0, col] = (col - 2).ToString();
                matrix[1, col] = "-";
            }
        }

        private static void PrintTestMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
