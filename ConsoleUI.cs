﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleField
{
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
