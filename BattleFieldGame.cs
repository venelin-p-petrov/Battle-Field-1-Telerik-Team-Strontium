namespace BattleField
{
    using System;
    using System.Text;

    public class BattleFieldGame
    {
        public static void Main(string[] args)
        {
            int gameBoardSize = GameEngine.ReadBoardSize();
            Board board = new Board(gameBoardSize);
            Console.WriteLine(board);
            GameEngine.PlayGame(board);
        }
    }
}
