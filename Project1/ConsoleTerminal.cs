using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Project1
{
    interface ITerminal
    {
        void Display(string s);
        void DisplayLine(string s);
        char GetChar(string prompt, string chars);
        string GetString(string prompt, int length);
        int GetInt(string prompt, int min, int max);
    }

    class ConsoleTerminal : ITerminal
    {
        void ITerminal.Display(string s)
        {
            Console.Write(s);
        }

        void ITerminal.DisplayLine(string s)
        {
            Console.WriteLine(s);
        }

        char ITerminal.GetChar(string prompt, string chars)
        {
            //TODO: Implement method.
        }

        string ITerminal.GetString(string prompt, int length)
        {
            //TODO: Implement method.
        }

        int ITerminal.GetInt(string prompt, int min, int max)
        {
            //TODO: Implement method.
        }
    }
}
