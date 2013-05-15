using System;

namespace BattleField
{
    public class ExplosionHandler
    {
        public static void HitMine(Board gameBoard, int x, int y)
        {
            int hitCoordinate = Convert.ToInt32(gameBoard.GameBoard[x, y]);

            switch (hitCoordinate)
            {
                case 1:
                    HitMineOfSizeOne(x, y, gameBoard);
                    break;
                case 2:
                    HitMineOfSizeTwo(x, y, gameBoard);
                    break;
                case 3:
                    HitMineOfSizeThree(x, y, gameBoard);
                    break;
                case 4:
                    HitMineOfSizeFour(x, y, gameBoard);
                    break;
                case 5:
                    HitMineOfSizeFive(x, y, gameBoard);
                    break;
            }
        }

        private static void HitMineOfSizeOne(int x, int y, Board gameBoard)
        {
            int rows = gameBoard.Rows;
            int cols = gameBoard.Cols;

            gameBoard.GameBoard[x, y] = "X";
            if (x - 1 > 1 && y - 2 > 1)
            {
                gameBoard.GameBoard[x - 1, y - 2] = "X";
            }

            if (x - 1 > 1 && y < cols - 2)
            {
                gameBoard.GameBoard[x - 1, y + 2] = "X";
            }

            if (x < rows - 1 && y < cols - 2)
            {
                gameBoard.GameBoard[x + 1, y + 2] = "X";
            }

            if (x < rows - 1 && y - 2 > 1)
            {
                gameBoard.GameBoard[x + 1, y - 2] = "X";
            }
        }

        private static void HitMineOfSizeTwo(int x, int y, Board gameBoard)
        {
            int rows = gameBoard.Rows;
            int cols = gameBoard.Cols;

            gameBoard.GameBoard[x, y] = "X";

            HitMineOfSizeOne(x, y, gameBoard);
            if (y - 2 > 1)
            {
                gameBoard.GameBoard[x, y - 2] = "X";
            }

            if (y < cols - 2)
            {
                gameBoard.GameBoard[x, y + 2] = "X";
            }

            if (x - 1 > 1)
            {
                gameBoard.GameBoard[x - 1, y] = "X";
            }

            if (x < rows - 1)
            {
                gameBoard.GameBoard[x + 1, y] = "X";
            }
        }

        private static void HitMineOfSizeThree(int x, int y, Board gameBoard)
        {
            int rows = gameBoard.Rows;
            int cols = gameBoard.Cols;

            HitMineOfSizeTwo(x, y, gameBoard);
            if (x - 2 > 1)
            {
                gameBoard.GameBoard[x - 2, y] = "X";
            }

            if (x < rows - 2)
            {
                gameBoard.GameBoard[x + 2, y] = "X";
            }

            if (y - 4 > 1)
            {
                gameBoard.GameBoard[x, y - 4] = "X";
            }

            if (y == 18)
            {
                gameBoard.GameBoard[x, y + 2] = "X";
            }
            else if (y == 20)
            {
                gameBoard.GameBoard[x, y] = "X";
            }
            else
            {
                if (y < cols - 3)
                {
                    gameBoard.GameBoard[x, y + 4] = "X";
                }
            }
        }

        private static void HitMineOfSizeFour(int x, int y, Board gameBoard)
        {
            int rows = gameBoard.Rows;
            int cols = gameBoard.Cols;

            HitMineOfSizeThree(x, y, gameBoard);
            if (x - 2 > 1 && y - 2 > 1)
            {
                gameBoard.GameBoard[x - 2, y - 2] = "X";
            }

            if (x - 1 > 1 && y - 4 > 1)
            {
                gameBoard.GameBoard[x - 1, y - 4] = "X";
            }

            if (x - 2 > 1 && y < cols - 2)
            {
                gameBoard.GameBoard[x - 2, y + 2] = "X";
            }

            if (x < rows - 1 && y - 4 > 1)
            {
                gameBoard.GameBoard[x + 1, y - 4] = "X";
            }

            if (x < rows - 2 && y - 2 > 1)
            {
                gameBoard.GameBoard[x + 2, y - 2] = "X";
            }

            if (x < rows - 2 && y < cols - 2)
            {
                gameBoard.GameBoard[x + 2, y + 2] = "X";
            }

            if (y == 18)
            {
                if (x - 1 > 1)
                {
                    gameBoard.GameBoard[x - 1, y + 2] = "X";
                }

                if (x < rows - 1)
                {
                    gameBoard.GameBoard[x + 1, y + 2] = "X";
                }
            }
            else if (y == 20)
            {
                if (x - 1 > 1)
                {
                    gameBoard.GameBoard[x - 1, y] = "X";
                }

                if (x < rows - 1)
                {
                    gameBoard.GameBoard[x + 1, y] = "X";
                }
            }
            else
            {
                if (x - 1 > 1 && y < cols - 3)
                {
                    gameBoard.GameBoard[x - 1, y + 4] = "X";
                }

                if (x < rows - 1 && y < cols - 3)
                {
                    gameBoard.GameBoard[x + 1, y + 4] = "X";
                }
            }
        }

        private static void HitMineOfSizeFive(int x, int y, Board gameBoard)
        {
            int rows = gameBoard.Rows;
            int cols = gameBoard.Cols;

            HitMineOfSizeFour(x, y, gameBoard);
            if (x - 2 > 1 && y - 4 > 1)
            {
                gameBoard.GameBoard[x - 2, y - 4] = "X";
            }

            if (x < rows - 2 && y - 4 > 1)
            {
                gameBoard.GameBoard[x + 2, y - 4] = "X";
            }

            if (y == 18)
            {
                if (x < rows - 2)
                {
                    gameBoard.GameBoard[x + 2, y + 2] = "X";
                }

                if (x - 2 > 1)
                {
                    gameBoard.GameBoard[x - 2, y + 2] = "X";
                }
            }
            else if (y == 20)
            {
                if (x < rows - 2)
                {
                    gameBoard.GameBoard[x + 2, y] = "X";
                }

                if (x - 2 > 1)
                {
                    gameBoard.GameBoard[x - 2, y] = "X";
                }
            }
            else
            {
                if (x < rows - 2 && y < cols - 3)
                {
                    gameBoard.GameBoard[x + 2, y + 4] = "X";
                }

                if (x - 2 > 1 && y < cols - 3)
                {
                    gameBoard.GameBoard[x - 2, y + 4] = "X";
                }
            }
        }
    }
}