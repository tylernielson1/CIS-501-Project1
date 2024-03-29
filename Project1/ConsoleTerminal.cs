﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Project1
{
    class ConsoleTerminal : ITerminal
    {
        public void Display(string s)
        {
            Console.Write(s);
        }

        public void DisplayLine(string s)
        {
            Console.WriteLine(s);
        }

        public void Wait()
        {
            Console.Write("<Return> to continue");
            Console.ReadLine();
        }

        public char GetChar(string prompt, string chars)
        {
            bool accept = false;
            Console.Write(prompt);

            string response = "";

            char[] acceptableChars = chars.ToCharArray();

            do
            {
                try
                {
                    response = Console.ReadLine();
                    response = response.Trim();

                    if (response.Length > 1)
                    {
                        throw new IndexOutOfRangeException();
                    }

                    for (int i = 0; i < acceptableChars.Length; i++)
                    {
                        if (response[0] == acceptableChars[i])
                        {
                            accept = true;
                        }
                    }

                    if(!accept)
                    {
                        throw new FormatException();
                    }
                }
                catch (Exception ex)
                {
                    Console.Write(prompt);
                }
            } while (!accept);

            return response[0];
        }

        public string GetString(string prompt, int length)
        {
            Console.Write(prompt);
            string response = "";

            do
            {
                try
                {
                    response = Console.ReadLine();
                    response = response.Trim();

                    if(response.Length == length)
                    {
                        break;
                    }
                    else
                    {
                        throw new IndexOutOfRangeException();
                    }
                }
                catch(Exception ex)
                {
                    Console.Write(prompt);
                }
            } while (response.Length != length);
            return response;
        }

        public int GetInt(string prompt, int min, int max)
        {
            Console.Write(prompt);
            int answer = 0;
            do
            {
                try
                {
                    answer = Convert.ToInt32(Console.ReadLine());

                    if (answer >= min && answer <= max)
                    {
                        break;
                    }
                    else
                    {
                        throw new IndexOutOfRangeException();
                    }
                }
                catch (Exception ex)
                {
                    Console.Write(prompt);
                }
            } while (answer <= min || answer >= max);
            return answer;
        }
    }
}
