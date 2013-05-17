namespace BattleField
{
    using System;
    using System.Linq;

    /// <summary>
    /// Console abstarction needed for mocking purposes.
    /// </summary>
    class ConsoleUI : IConsole
    {
        public void Write(string message)
        {
            Console.Write(message);
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
