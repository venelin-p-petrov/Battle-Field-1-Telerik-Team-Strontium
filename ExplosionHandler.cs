namespace BattleField
{
    using System;

    public class ExplosionHandler
    {
        public static void HitMine(Board gameBoard, int x, int y)
        {
            int mineSize = Convert.ToInt32(gameBoard.GameBoard[x, y]);

            switch (mineSize)
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

            if (x - 1 >= 0 && y - 1 >= 0)
            {
                gameBoard.GameBoard[x - 1, y - 1] = "X";
            }

            if (x - 1 >= 0 && y + 1 < cols)
            {
                gameBoard.GameBoard[x - 1, y + 1] = "X";
            }

            if (x + 1 < rows && y + 1 < cols)
            {
                gameBoard.GameBoard[x + 1, y + 1] = "X";
            }

            if (x + 1 < rows && y - 1 >= 0)
            {
                gameBoard.GameBoard[x + 1, y - 1] = "X";
            }
        }

        private static void HitMineOfSizeTwo(int x, int y, Board gameBoard)
        {
            int rows = gameBoard.Rows;
            int cols = gameBoard.Cols;

            gameBoard.GameBoard[x, y] = "X";

            HitMineOfSizeOne(x, y, gameBoard);
            if (y - 1 >= 0)
            {
                gameBoard.GameBoard[x, y - 1] = "X";
            }

            if (y + 1 < cols)
            {
                gameBoard.GameBoard[x, y + 1] = "X";
            }

            if (x - 1 >= 0)
            {
                gameBoard.GameBoard[x - 1, y] = "X";
            }

            if (x + 1 < rows)
            {
                gameBoard.GameBoard[x + 1, y] = "X";
            }
        }

        private static void HitMineOfSizeThree(int x, int y, Board gameBoard)
        {
            int rows = gameBoard.Rows;
            int cols = gameBoard.Cols;

            HitMineOfSizeTwo(x, y, gameBoard);

            if (x - 2 >= 0)
            {
                gameBoard.GameBoard[x - 2, y] = "X";
            }

            if (x + 2 < rows)
            {
                gameBoard.GameBoard[x + 2, y] = "X";
            }

            if (y - 2 >= 0)
            {
                gameBoard.GameBoard[x, y - 2] = "X";
            }

            if (y + 2 < cols)
            {
                gameBoard.GameBoard[x, y + 2] = "X";
            }
        }

        private static void HitMineOfSizeFour(int x, int y, Board gameBoard)
        {
            int rows = gameBoard.Rows;
            int cols = gameBoard.Cols;

            HitMineOfSizeThree(x, y, gameBoard);

            if (x - 2 >= 0 && y - 1 >= 0)
            {
                gameBoard.GameBoard[x - 2, y - 1] = "X";
            }

            if (x - 2 >= 0 && y + 1 < cols)
            {
                gameBoard.GameBoard[x - 2, y + 1] = "X";
            }

            if (x - 1 >= 0  && y + 2 < cols)
            {
                gameBoard.GameBoard[x - 1, y + 2] = "X";
            }

            if (x + 1 < rows && y + 2 < cols)
            {
                gameBoard.GameBoard[x + 1, y + 2] = "X";
            }            

            if (x + 2 < rows && y + 1 < cols)
            {
                gameBoard.GameBoard[x + 2, y + 1] = "X";
            }

            if (x + 2 < rows && y - 1 >= 0)
            {
                gameBoard.GameBoard[x + 2, y - 1] = "X";
            }

            if (x - 1 >= 0 && y - 2 >= 0)
            {
                gameBoard.GameBoard[x - 1, y - 2] = "X";
            }

            if (x + 1 < rows && y - 2 >= 0)
            {
                gameBoard.GameBoard[x + 1, y - 2] = "X";
            }            
        }

        private static void HitMineOfSizeFive(int x, int y, Board gameBoard)
        {
            int rows = gameBoard.Rows;
            int cols = gameBoard.Cols;

            HitMineOfSizeFour(x, y, gameBoard);

            if (x - 2 >= 0 && y - 2 >= 0)
            {
                gameBoard.GameBoard[x - 2, y - 2] = "X";
            }

            if (x - 2 >= 0 && y + 2 < cols)
            {
                gameBoard.GameBoard[x - 2, y + 2] = "X";
            }

            if (x + 2 < rows && y + 2 < cols)
            {
                gameBoard.GameBoard[x + 2, y + 2] = "X";
            }

            if (x + 2 < rows && y - 2 >= 0)
            {
                gameBoard.GameBoard[x + 2, y - 2] = "X";
            }            
        }
    }
}