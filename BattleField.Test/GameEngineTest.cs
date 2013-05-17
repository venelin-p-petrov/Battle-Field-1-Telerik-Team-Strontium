namespace BattleField.Test
{
    using System;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GameEngineTest
    {
        [TestMethod]
        public void IsGameOverTest_IfBombAtTopLeft()
        {
            Random random = new Random();
            for (int i = 1; i <= 10; i++)
            {
                int gameFieldSize = i;
                string randomBombNumber = random.Next(1, 6).ToString();
                Board board = new Board(gameFieldSize);

                board.GameBoard[0, 0] = randomBombNumber;

                Assert.IsFalse(GameEngine.IsGameOver(board));
            }
        }

        [TestMethod]
        public void IsGameOverTest_IfBombAtTopRight()
        {
            Random random = new Random();
            for (int i = 1; i <= 10; i++)
            {
                int gameFieldSize = i;
                string randomBombNumber = random.Next(1, 6).ToString();
                Board board = new Board(gameFieldSize);

                board.GameBoard[0, gameFieldSize - 1] = randomBombNumber;

                Assert.IsFalse(GameEngine.IsGameOver(board));
            }
        }

        [TestMethod]
        public void IsGameOverTest_IfBombAtBottomLeft()
        {
            Random random = new Random();
            for (int i = 1; i <= 10; i++)
            {
                int gameFieldSize = i;
                string randomBombNumber = random.Next(1, 6).ToString();
                Board board = new Board(gameFieldSize);

                board.GameBoard[gameFieldSize - 1, 0] = randomBombNumber;

                Assert.IsFalse(GameEngine.IsGameOver(board));
            }
        }

        [TestMethod]
        public void IsGameOverTest_IfBombAtBottomRight()
        {
            Random random = new Random();
            for (int i = 1; i <= 10; i++)
            {
                int gameFieldSize = i;
                string randomBombNumber = random.Next(1, 6).ToString();
                Board board = new Board(gameFieldSize);

                board.GameBoard[gameFieldSize - 1, gameFieldSize - 1] = randomBombNumber;

                Assert.IsFalse(GameEngine.IsGameOver(board));
            }
        }

        [TestMethod]
        public void IsGameOverTest_NoBombsLeft()
        {
            for (int i = 1; i <= 10; i++)
            {
                int gameFieldSize = i;
                Board board = new Board(gameFieldSize);
                ClearGameBoard(board);

                Assert.IsTrue(GameEngine.IsGameOver(board));
            }
        }

        [TestMethod]
        public void ReadBoardSizeTest_ValidSize5()
        {
            TestConsoleUI testConsole = new TestConsoleUI();
            testConsole.Input = "5";
            StringBuilder expectedOutput = new StringBuilder();
            expectedOutput.Append("Welcome to \"Battle Field game.\" Enter battlefield size: N = ");

            int boardSize = GameEngine.ReadBoardSize(testConsole);

            Assert.AreEqual(5, boardSize);
            Assert.AreEqual(expectedOutput.ToString(), testConsole.Output.ToString());
        }

        [TestMethod]
        public void ReadBoardSizeTest_ValidSize1()
        {
            TestConsoleUI testConsole = new TestConsoleUI();
            testConsole.Input = "1";
            StringBuilder expectedOutput = new StringBuilder();
            expectedOutput.Append("Welcome to \"Battle Field game.\" Enter battlefield size: N = ");

            int boardSize = GameEngine.ReadBoardSize(testConsole);

            Assert.AreEqual(1, boardSize);
            Assert.AreEqual(expectedOutput.ToString(), testConsole.Output.ToString());
        }

        [TestMethod]
        public void ReadBoardSizeTest_ValidSize10()
        {
            TestConsoleUI testConsole = new TestConsoleUI();
            testConsole.Input = "10";
            StringBuilder expectedOutput = new StringBuilder();
            expectedOutput.Append("Welcome to \"Battle Field game.\" Enter battlefield size: N = ");

            int boardSize = GameEngine.ReadBoardSize(testConsole);

            Assert.AreEqual(10, boardSize);
            Assert.AreEqual(expectedOutput.ToString(), testConsole.Output.ToString());
        }

        [TestMethod]
        public void ReadBoardSizeTest_InvalidSize0ThenValid5()
        {
            TestConsoleUI testConsole = new TestConsoleUI();
            testConsole.Input = "0\n5";
            StringBuilder expectedOutput = new StringBuilder();
            expectedOutput.Append("Welcome to \"Battle Field game.\" Enter battlefield size: N = ");
            expectedOutput.AppendLine("Enter a number between 1 and 10!");

            int boardSize = GameEngine.ReadBoardSize(testConsole);

            Assert.AreEqual(5, boardSize);
            Assert.AreEqual(expectedOutput.ToString(), testConsole.Output.ToString());
        }

        [TestMethod]
        public void ReadBoardSizeTest_TwiceInvalidSize0ThenValid5()
        {
            TestConsoleUI testConsole = new TestConsoleUI();
            testConsole.Input = "0\n0\n5";
            StringBuilder expectedOutput = new StringBuilder();
            expectedOutput.Append("Welcome to \"Battle Field game.\" Enter battlefield size: N = ");
            expectedOutput.AppendLine("Enter a number between 1 and 10!");
            expectedOutput.AppendLine("Enter a number between 1 and 10!");

            int boardSize = GameEngine.ReadBoardSize(testConsole);

            Assert.AreEqual(5, boardSize);
            Assert.AreEqual(expectedOutput.ToString(), testConsole.Output.ToString());
        }

        [TestMethod]
        public void PlayGameTest_SuccessfulGamePlayed1Bomb()
        {
            TestConsoleUI testConsole = new TestConsoleUI();
            testConsole.Input = "1 1";
            StringBuilder expectedOutput = new StringBuilder();
            Board board = new Board(3);
            var initialBoard = new string[3,3]
                {
                    {"-", "-", "-"},
                    {"-", "1", "-"},
                    {"-", "-", "-"}
                };
            var expectedBoard = new string[3,3]
                {
                    {"X", "-", "X"},
                    {"-", "X", "-"},
                    {"X", "-", "X"}
                };
            SetBoard(board, initialBoard);
            expectedOutput.AppendLine("Please enter coordinates: ");
            expectedOutput.AppendLine("  0 1 2");
            expectedOutput.AppendLine("  -----");
            expectedOutput.AppendLine("0|X - X ");
            expectedOutput.AppendLine("1|- X - ");
            expectedOutput.AppendLine("2|X - X ");
            expectedOutput.AppendLine();
            expectedOutput.AppendLine("Game over. Detonated mines: 1");

            GameEngine.PlayGame(board, testConsole);

            Assert.IsTrue(EqualBoards(expectedBoard, board.GameBoard));
            Assert.AreEqual(expectedOutput.ToString(), testConsole.Output.ToString());
        }

        [TestMethod]
        public void PlayGameTest_SuccessfulGamePlayedTryInvalidMove()
        {
            TestConsoleUI testConsole = new TestConsoleUI();
            testConsole.Input = "-1 0\n1 1\n1 1\n0 1";
            StringBuilder expectedOutput = new StringBuilder();
            Board board = new Board(3);
            var initialBoard = new string[3,3]
                {
                    {"-", "1", "-"},
                    {"-", "1", "-"},
                    {"-", "-", "-"}
                };
            var expectedBoard = new string[3,3]
                {
                    {"X", "X", "X"},
                    {"X", "X", "X"},
                    {"X", "-", "X"}
                };
            SetBoard(board, initialBoard);
            expectedOutput.AppendLine("Please enter coordinates: ");
            expectedOutput.AppendLine("Invalid move!");
            expectedOutput.AppendLine("Please enter coordinates: ");
            expectedOutput.AppendLine("  0 1 2");
            expectedOutput.AppendLine("  -----");
            expectedOutput.AppendLine("0|X 1 X ");
            expectedOutput.AppendLine("1|- X - ");
            expectedOutput.AppendLine("2|X - X ");
            expectedOutput.AppendLine();
            expectedOutput.AppendLine("Please enter coordinates: ");
            expectedOutput.AppendLine("Invalid move!");
            expectedOutput.AppendLine("Please enter coordinates: ");
            expectedOutput.AppendLine("  0 1 2");
            expectedOutput.AppendLine("  -----");
            expectedOutput.AppendLine("0|X X X ");
            expectedOutput.AppendLine("1|X X X ");
            expectedOutput.AppendLine("2|X - X ");
            expectedOutput.AppendLine();
            expectedOutput.AppendLine("Game over. Detonated mines: 2");

            GameEngine.PlayGame(board, testConsole);

            Assert.IsTrue(EqualBoards(expectedBoard, board.GameBoard));
            Assert.AreEqual(expectedOutput.ToString(), testConsole.Output.ToString());
        }

        private static void ClearGameBoard(Board board)
        {
            Random rand = new Random();

            for (int row = 0; row < board.Rows; row++)
            {
                for (int col = 0; col < board.Cols; col++)
                {
                    board.GameBoard[row, col] = (rand.Next(2) == 0 ? "-" : "X");
                }
            }
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

        private static bool EqualBoards(string[,] expected, string[,] actual)
        {
            try
            {
                for (int row = 0; row < expected.GetLength(0); row++)
                {
                    for (int col = 0; col < expected.GetLength(1); col++)
                    {
                        if (expected[row, col] != actual[row, col])
                        {
                            return false;
                        }
                    }
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private class TestConsoleUI : IConsole
        {
            public TestConsoleUI()
            {
                Output = new StringBuilder();
            }

            public StringBuilder Output { get; set; }
            public string Input { get; set; }

            public void Write(string message)
            {
                Output.Append(message);
            }

            public void WriteLine(string message)
            {
                Output.AppendLine(message);
            }

            public string ReadLine()
            {
                int endOfLineIndex = Input.IndexOf('\n');
                if (endOfLineIndex < 0)
                {
                    return Input;
                }

                string result = Input.Substring(0, endOfLineIndex);
                Input = Input.Remove(0, endOfLineIndex + 1);

                return result;
            }
        }
    }
}