using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    interface ITerminal
    {
        void Display(string s);
        void DisplayLine(string s);
        void Wait();
        char GetChar(string prompt, string chars);
        string GetString(string prompt, int length);
        int GetInt(string prompt, int min, int max);
    }
}
