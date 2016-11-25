﻿using System;

namespace GammaProjekt
{
    internal class Runtime
    {
        string output = "0";
        string thingiee = " ";
        double numberOne = 0;
        bool newNumber = false;
        internal void Start()
        {
            Graphics();
            Console.CursorVisible = false;
            while (true)
            {
                ShowNumbers();
                var input = Console.ReadKey(true);
                if ((input.Modifiers & ConsoleModifiers.Shift) != 0 && input.Key == ConsoleKey.D7)
                {
                    thingiee = "/";
                    numberOne = double.Parse(output);
                    newNumber = true;
                }
                else
                {
                    CheckIfNumber(input.Key);
                    switch (input.Key)
                    {
                        case ConsoleKey.OemComma:
                        case ConsoleKey.OemPeriod:
                            if (!output.Contains(".")) output += ".";
                            break;
                        case ConsoleKey.OemPlus:
                            thingiee = "+";
                            numberOne = double.Parse(output);
                            newNumber = true;
                            break;

                        case ConsoleKey.OemMinus:
                            thingiee = "-";
                            numberOne = double.Parse(output);
                            Console.WriteLine(numberOne);
                            newNumber = true;
                            break;
                        case ConsoleKey.X:
                            thingiee = "x";
                            numberOne = double.Parse(output);
                            newNumber = true;
                            break;
                        case ConsoleKey.C:
                            output = "0";
                            break;
                        case ConsoleKey.Enter:
                            Enter();
                            break;
                        case ConsoleKey.Backspace:
                            if (!newNumber)
                            {
                                output = output.Remove(output.Length - 1);
                            }
                            else output = "0";
                            if (output.Length == 0)
                                output = "0";
                            break;
                    }
                }
            }
        }

        private void Enter()
        {
            if (thingiee == "+")
                output = (numberOne + double.Parse(output)).ToString();
            else if (thingiee == "-")
                output = (numberOne - double.Parse(output)).ToString();
            else if (thingiee == "x")
                output = (numberOne * double.Parse(output)).ToString();
            else if (thingiee == "/" && numberOne != 0 && output != "0")
                output = (numberOne / double.Parse(output)).ToString();

            else if (thingiee == "/" && numberOne != 0 && output == "0")
            {
                Console.WriteLine("du kan inte dela med 0");
                Console.ReadKey(true);
                Console.SetCursorPosition(0, 15);
                Console.WriteLine("                      ");
            }
                thingiee = " ";
                newNumber = true;
        }
        private void CheckIfNumber(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.D0:
                    Number(0);
                    break;
                case ConsoleKey.D1:
                    Number(1);
                    break;
                case ConsoleKey.D2:
                    Number(2);
                    break;
                case ConsoleKey.D3:
                    Number(3);
                    break;
                case ConsoleKey.D4:
                    Number(4);
                    break;
                case ConsoleKey.D5:
                    Number(5);
                    break;
                case ConsoleKey.D6:
                    Number(6);
                    break;
                case ConsoleKey.D7:
                    Number(7);
                    break;
                case ConsoleKey.D8:
                    Number(8);
                    break;
                case ConsoleKey.D9:
                    Number(9);
                    break;
            }
        }

        public void Number(int number)
        {
            if (newNumber)
            {
                output = number.ToString();
                newNumber = false;
            }

            else if (output == "0")
            {
                output = number.ToString();
            }
            else if (output.Length < 10)
            {
                output += number.ToString();

            }
        }
        private void ShowNumbers()
        {
            Console.SetCursorPosition(3, 2);
            Console.WriteLine("{0}         ", thingiee);
            Console.SetCursorPosition(14 - output.Length, 2);
            Console.WriteLine(output);
            Console.SetCursorPosition(0, 15);
        }
        private void Graphics()
        {
            Console.WriteLine("┌───────────────┐");
            Console.WriteLine("│ ┌───────────┐ │");
            Console.WriteLine("│ │           │ │");
            Console.WriteLine("│ └───────────┘ │");
            Console.WriteLine("├───┬───┬───┬───┤");
            Console.WriteLine("│ 1 │ 2 │ 3 │ + │");
            Console.WriteLine("├───┼───┼───┼───┤");
            Console.WriteLine("│ 4 │ 5 │ 6 │ - │");
            Console.WriteLine("├───┼───┼───┼───┤");
            Console.WriteLine("│ 7 │ 8 │ 9 │ x │");
            Console.WriteLine("├───┼───┼───┼───┤");
            Console.WriteLine("│ C │ 0 │ = │ / │");
            Console.WriteLine("└───┴───┴───┴───┘");
        }
    }
}