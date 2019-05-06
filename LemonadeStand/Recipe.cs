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
        public int amountoflemons;
        public int amountofsugar;
        public int amountofice;

        //constructor (SPAWNER)
        public Recipe()
        {
            amountoflemons = 4;
            amountofsugar = 4;
            amountofice = 4;
        }

        //member methods (CAN DO)
        public void AdjustLemons()
        {
            bool keepGoing = true;
            while (keepGoing == true)
            {
                Console.Clear();
                Console.WriteLine($"Your pitchers currently use {amountoflemons} lemons. Use up/down arrows to adjust. Hit 'enter' when done.");
                ConsoleKey keyinput = Console.ReadKey().Key;
                switch (keyinput)
                {
                    case ConsoleKey.UpArrow:
                        amountoflemons++;
                        break;
                    case ConsoleKey.DownArrow:
                        amountoflemons--;
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
                Console.Clear();
                Console.WriteLine($"Your pitchers currently use {amountofsugar} sugar. Use up/down arrows to adjust. Hit 'enter' when done.");
                ConsoleKey keyinput = Console.ReadKey().Key;
                switch (keyinput)
                {
                    case ConsoleKey.UpArrow:
                        amountofsugar++;
                        break;
                    case ConsoleKey.DownArrow:
                        amountofsugar--;
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
            bool keepGoing = true;
            while (keepGoing == true)
            {
                Console.Clear();
                Console.WriteLine($"Your pitchers currently use {amountofice} ice. Use up/down arrows to adjust. Hit 'enter' when done.");
                ConsoleKey keyinput = Console.ReadKey().Key;
                switch (keyinput)
                {
                    case ConsoleKey.UpArrow:
                        amountofice++;
                        break;
                    case ConsoleKey.DownArrow:
                        amountofice--;
                        break;
                    case ConsoleKey.Enter:
                        keepGoing = false;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
