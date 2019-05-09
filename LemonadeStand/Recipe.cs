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
        public void AdjustLemons(double lemonsInInventory)
        {
            Console.WriteLine("");
            bool keepGoing = true;
            while (keepGoing == true)
            {
                UserInterface.UseInPitcher(amountOfLemons, "lemons");
                ConsoleKey keyinput = Console.ReadKey().Key;
                switch (keyinput)
                {
                    case ConsoleKey.UpArrow:
                        if (amountOfLemons < lemonsInInventory)
                        {
                            amountOfLemons++;
                        }
                        ClearOldLine();
                        break;
                    case ConsoleKey.DownArrow:
                        if(amountOfLemons > 1)
                        {
                            amountOfLemons--;
                        }
                        ClearOldLine();
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
        public void AdjustSugar(double sugarInInventory)
        {
            Console.WriteLine("");
            bool keepGoing = true;
            while (keepGoing == true)
            {
                UserInterface.UseInPitcher(amountOfSugar, "sugar");
                ConsoleKey keyinput = Console.ReadKey().Key;
                switch (keyinput)
                {
                    case ConsoleKey.UpArrow:
                        if (amountOfSugar < sugarInInventory)
                        {
                            amountOfSugar++;
                        }
                        ClearOldLine();
                        break;
                    case ConsoleKey.DownArrow:
                        if (amountOfSugar > 1)
                        {
                            amountOfSugar--;
                        }
                        ClearOldLine();
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
        public void AdjustIce(double iceInInventory)
        {
            Console.WriteLine("");
            bool keepGoing = true;
            while (keepGoing == true)
            {
                UserInterface.UseInPitcher(amountOfIce, "ice");
                ConsoleKey keyinput = Console.ReadKey().Key;
                switch (keyinput)
                {
                    case ConsoleKey.UpArrow:
                        if (amountOfIce < iceInInventory)
                        {
                            amountOfIce++;
                        }
                        ClearOldLine();
                        break;
                    case ConsoleKey.DownArrow:
                        if (amountOfIce > 1)
                        {
                            amountOfIce--;
                        }
                        ClearOldLine();
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
