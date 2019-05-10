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
        public List<StoreItem> recipeList;

        //constructor (SPAWNER)
        public Recipe()
        {
            StartingRecipe();
        }
        //member methods (CAN DO)

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
                            recipeList.Add(adjustment);
                        }
                        UserInterface.ClearOldLine();
                        break;
                    case ConsoleKey.DownArrow:
                        if (currentAmount > 1)
                        {
                            SubtractRecipeItem(item.name);
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
