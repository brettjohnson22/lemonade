﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Recipe
    {
        //member variables (HAS A)
        public double amountoflemons;
        public double amountofsugar;
        public double amountofice;

        //constructor (SPAWNER)
        public Recipe()
        {
            amountoflemons = 2;
            amountofsugar = 4;
            amountofice = 16;
        }

        //member methods (CAN DO)
        public void AdjustLemons()
        {
            Console.WriteLine("");
            bool keepGoing = true;
            while (keepGoing == true)
            {
                Console.WriteLine($"You will be using {amountoflemons} lemons per pitcher. Use up/down arrows to adjust. Hit 'enter' when done.");
                ConsoleKey keyinput = Console.ReadKey().Key;
                switch (keyinput)
                {
                    case ConsoleKey.UpArrow:
                        amountoflemons++;
                        ClearOldLine();
                        break;
                    case ConsoleKey.DownArrow:
                        amountoflemons--;
                        ClearOldLine();
                        break;
                    case ConsoleKey.Enter:
                        keepGoing = false;
                        break;
                    default:
                        break;
                }
            }

        }
        public void AdjustSugar()
        {
            bool keepGoing = true;
            while (keepGoing == true)
            {
                Console.WriteLine($"You will be using {amountofsugar} sugar per pitcher. Use up/down arrows to adjust. Hit 'enter' when done.");
                ConsoleKey keyinput = Console.ReadKey().Key;
                switch (keyinput)
                {
                    case ConsoleKey.UpArrow:
                        amountofsugar++;
                        ClearOldLine();
                        break;
                    case ConsoleKey.DownArrow:
                        amountofsugar--;
                        ClearOldLine();
                        break;
                    case ConsoleKey.Enter:
                        keepGoing = false;
                        break;
                    default:
                        break;
                }
            }
        }
        public void AdjustIce()
        {
            Console.WriteLine("");
            bool keepGoing = true;
            while (keepGoing == true)
            {
                Console.WriteLine($"You will be using {amountofice} ice per pitcher. Use up/down arrows to adjust. Hit 'enter' when done.");
                ConsoleKey keyinput = Console.ReadKey().Key;
                switch (keyinput)
                {
                    case ConsoleKey.UpArrow:
                        amountofice++;
                        ClearOldLine();
                        break;
                    case ConsoleKey.DownArrow:
                        amountofice--;
                        ClearOldLine();
                        break;
                    case ConsoleKey.Enter:
                        keepGoing = false;
                        break;
                    default:
                        break;
                }
            }
        }
        public void ClearOldLine()
        {
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            int returnplacement = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, returnplacement);
        }
    }
}
