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
        //public double amountOfLemons;
        //public double amountOfSugar;
        //public double amountOfIce;
        public List<StoreItem> recipeList;

        //constructor (SPAWNER)
        public Recipe()
        {
            //amountOfLemons = 3;
            //amountOfSugar = 4;
            //amountOfIce = 16;
        }
        //member methods (CAN DO)
        //public void AdjustLemons(double lemonsInInventory)
        //{
        //    Console.WriteLine("");
        //    bool keepGoing = true;
        //    while (keepGoing == true)
        //    {
        //        UserInterface.UseInPitcher(amountOfLemons, "lemons");
        //        ConsoleKey keyinput = Console.ReadKey().Key;
        //        switch (keyinput)
        //        {
        //            case ConsoleKey.UpArrow:
        //                if (amountOfLemons < lemonsInInventory)
        //                {
        //                    amountOfLemons++;
        //                }
        //                UserInterface.ClearOldLine();
        //                break;
        //            case ConsoleKey.DownArrow:
        //                if (amountOfLemons > 1)
        //                {
        //                    amountOfLemons--;
        //                }
        //                UserInterface.ClearOldLine();
        //                break;
        //            case ConsoleKey.Enter:
        //                keepGoing = false;
        //                break;
        //            default:
        //                UserInterface.ClearOldLine();
        //                break;
        //        }
        //    }
        //}
        //public void AdjustSugar(double sugarInInventory)
        //{
        //    Console.WriteLine("");
        //    bool keepGoing = true;
        //    while (keepGoing == true)
        //    {
        //        UserInterface.UseInPitcher(amountOfSugar, "sugar");
        //        ConsoleKey keyinput = Console.ReadKey().Key;
        //        switch (keyinput)
        //        {
        //            case ConsoleKey.UpArrow:
        //                if (amountOfSugar < sugarInInventory)
        //                {
        //                    amountOfSugar++;
        //                }
        //                UserInterface.ClearOldLine();
        //                break;
        //            case ConsoleKey.DownArrow:
        //                if (amountOfSugar > 1)
        //                {
        //                    amountOfSugar--;
        //                }
        //                UserInterface.ClearOldLine();
        //                break;
        //            case ConsoleKey.Enter:
        //                keepGoing = false;
        //                break;
        //            default:
        //                UserInterface.ClearOldLine();
        //                break;
        //        }
        //    }
        //}
        //public void AdjustIce(double iceInInventory)
        //{
        //    Console.WriteLine("");
        //    bool keepGoing = true;
        //    while (keepGoing == true)
        //    {
        //        UserInterface.UseInPitcher(amountOfIce, "ice");
        //        ConsoleKey keyinput = Console.ReadKey().Key;
        //        switch (keyinput)
        //        {
        //            case ConsoleKey.UpArrow:
        //                if (amountOfIce < iceInInventory)
        //                {
        //                    amountOfIce++;
        //                }
        //                UserInterface.ClearOldLine();
        //                break;
        //            case ConsoleKey.DownArrow:
        //                if (amountOfIce > 1)
        //                {
        //                    amountOfIce--;
        //                }
        //                UserInterface.ClearOldLine();
        //                break;
        //            case ConsoleKey.Enter:
        //                keepGoing = false;
        //                break;
        //            default:
        //                UserInterface.ClearOldLine();
        //                break;
        //        }
        //    }
        //}
        public void StartingRecipe()
        {
            int startingLemons = 3;
            int startingSugar = 4;
            int startingIce = 16;
            recipeList = new List<StoreItem>();
                for (int i = 0; i<startingLemons; i++)
                {
                    recipeList.Add(new Lemon());
                }
                for (int i = 0; i<startingSugar; i++)
                {
                    recipeList.Add(new Sugar());
                }
                for (int i = 0; i<startingIce; i++)
                {
                    recipeList.Add(new Ice());
                }
        }
      
        public double NumberInRecipe(string itemName)
        {
            double counter = 0;
            foreach (StoreItem item in recipeList)
            {
                if (item.Name == itemName)
                {
                    counter++;
                }
            }
            return counter;
        }
        public void AdjustItem<T>(Inventory inventory, ref T item) where T : StoreItem, new()
        {
            Console.WriteLine("");
            bool keepGoing = true;
            while (keepGoing == true)
            {
                double currentAmount = NumberInRecipe(item.name);
                UserInterface.UseInPitcher(currentAmount, item.name);
                ConsoleKey keyinput = Console.ReadKey().Key;
                switch (keyinput)
                {
                    case ConsoleKey.UpArrow:
                        if (currentAmount < inventory.NumberOfItems(item.name))
                        {
                            T adjustment = new T();
                            recipeList.Add(adjustment);//add StoreItem of subclass to recipelist;
                        }
                        UserInterface.ClearOldLine();
                        break;
                    case ConsoleKey.DownArrow:
                        if (currentAmount > 1)
                        {
                            SubtractRecipeItem(item.name);//remove StoreItem of subclass to recipelist
                        }
                        UserInterface.ClearOldLine();
                        break;
                    case ConsoleKey.Enter:
                        keepGoing = false;
                        break;
                    default:
                        UserInterface.ClearOldLine();
                        break;
                }
            }
        }
        public void SubtractRecipeItem(string itemName)
        {
            foreach (StoreItem item in recipeList)
            {
                if (item.Name == itemName)
                {
                    recipeList.Remove(item);
                    break;
                }
                
            }
        }
    }
}
