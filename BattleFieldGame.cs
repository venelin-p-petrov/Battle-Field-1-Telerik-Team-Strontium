namespace BattleField
{
    using System;
    using System.Text;

    /// <summary>
    /// Class containing the begining of the program.
    /// </summary>
    public class BattleFieldGame
    {
        /// <summary>
        /// Main Method. Begining of the program.
        /// </summary>
        public static void Main(string[] args)
        {
            ConsoleUI userInput = new ConsoleUI();
            int gameBoardSize = GameEngine.ReadBoardSize(userInput);
            Board board = new Board(gameBoardSize);
            Console.WriteLine(board);
            GameEngine.PlayGame(board, userInput);
        }
    }
}
