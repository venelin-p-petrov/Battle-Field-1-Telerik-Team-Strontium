using System;
using System.Linq;

namespace BattleField
{
    /// <summary>
    /// Interface introducing the needed functionality for user UI
    /// </summary>
    public interface IConsole
    {
        void Write(string message);
        void WriteLine(string message);
        string ReadLine();
    }
}
