namespace BattleField
{
    using System;
    using System.Text;

    public class BattleFieldGame
    {
        public static void Main(string[] args)
        {
            ConsoleUserInput userInput = new ConsoleUserInput();
            int gameBoardSize = GameEngine.ReadBoardSize(userInput);
            Board board = new Board(gameBoardSize);
            Console.WriteLine(board);
            GameEngine.PlayGame(board, userInput);
        }
    }
}
