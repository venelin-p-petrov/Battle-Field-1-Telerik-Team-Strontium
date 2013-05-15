using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleField
{
    public interface IConsole
    {
        void Write(string message);
        void WriteLine(string message);
        string ReadLine();
    }
}
