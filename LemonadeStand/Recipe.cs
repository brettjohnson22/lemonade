using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Recipe
    {
        //member variables (HAS A)
        public double amountOfLemons;
        public double amountOfSugar;
        public double amountOfIce;

        //constructor (SPAWNER)
        public Recipe()
        {
            amountOfLemons = 3;
            amountOfSugar = 4;
            amountOfIce = 16;
        }

        //member methods (CAN DO)
        public void AdjustLemons()
        {
            Console.WriteLine("");
            bool keepGoing = true;
            while (keepGoing == true)
            {
                Console.WriteLine($"You will be using {amountOfLemons} lemons per pitcher. Use up/down arrows to adjust. Hit 'enter' when done.");
                ConsoleKey keyinput = Console.ReadKey().Key;
                switch (keyinput)
                {
                    case ConsoleKey.UpArrow:
                        amountOfLemons++;
                        ClearOldLine();
                        break;
                    case ConsoleKey.DownArrow:
                        if(amountOfLemons > 1)
                        {
                            amountOfLemons--;
                            ClearOldLine();
                        }
                        else
                        {
                            ClearOldLine();
                        }
                        break;
                    case ConsoleKey.Enter:
                        keepGoing = false;
                        break;
                    default:
                        ClearOldLine();
                        break;
                }
            }

        }
        public void AdjustSugar()
        {
            Console.WriteLine("");
            bool keepGoing = true;
            while (keepGoing == true)
            {
                Console.WriteLine($"You will be using {amountOfSugar} sugar per pitcher. Use up/down arrows to adjust. Hit 'enter' when done.");
                ConsoleKey keyinput = Console.ReadKey().Key;
                switch (keyinput)
                {
                    case ConsoleKey.UpArrow:
                        amountOfSugar++;
                        ClearOldLine();
                        break;
                    case ConsoleKey.DownArrow:
                        if (amountOfSugar > 1)
                        {
                            amountOfSugar--;
                            ClearOldLine();
                        }
                        else
                        {
                            ClearOldLine();
                        }
                        break;
                    case ConsoleKey.Enter:
                        keepGoing = false;
                        break;
                    default:
                        ClearOldLine();
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
                Console.WriteLine($"You will be using {amountOfIce} ice per pitcher. Use up/down arrows to adjust. Hit 'enter' when done.");
                ConsoleKey keyinput = Console.ReadKey().Key;
                switch (keyinput)
                {
                    case ConsoleKey.UpArrow:
                        amountOfIce++;
                        ClearOldLine();
                        break;
                    case ConsoleKey.DownArrow:
                        if (amountOfIce > 1)
                        {
                            amountOfIce--;
                            ClearOldLine();
                        }
                        else
                        {
                            ClearOldLine();
                        }
                        break;
                    case ConsoleKey.Enter:
                        keepGoing = false;
                        break;
                    default:
                        ClearOldLine();
                        break;
                }
            }
        }
        private void ClearOldLine()
        {
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            int returnplacement = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, returnplacement);
        }
    }
}
