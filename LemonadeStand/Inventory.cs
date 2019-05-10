using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Inventory
    {
        //member variables (HAS A)
        public double myWallet;
        public double totalProfit;
        public Recipe myRecipe;
        public List<StoreItem> allItems;


        //constructor (SPAWNER)
        public Inventory()
        {
            myRecipe = new Recipe();
            myWallet = 10;
            totalProfit = 0;
        }
        //member methods (CAN DO)
        public void StartingStock()
        {
            int startingLemons = 100;
            int startingSugar = 100;
            int startingIce = 100;
            allItems = new List<StoreItem>();
            for (int i = 0; i < startingLemons; i++)
            {
                allItems.Add(new Lemon());
            }
            for (int i = 0; i < startingSugar; i++)
            {
                allItems.Add(new Sugar());
            }
            for (int i = 0; i < startingIce; i++)
            {
                allItems.Add(new Ice());
            }
        }
        public double NumberOfItems(string itemName)
        {
            double counter = 0;
            foreach (StoreItem item in allItems)
            {
                if (item.Name == itemName)
                {
                    counter++;
                }
            }
            return counter;
        }
        public void SubtractInventoryItem(string itemName, double adjustment)
        {
            int counter = 0;
            {
                for (int i = allItems.Count - 1; i >= 0; i--)
                {
                    if (allItems[i].name == itemName)
                    {
                        allItems.Remove(allItems[i]);
                        counter++;
                        if(counter == adjustment)
                        {
                            break;
                        }
                    }
                }
            }
        }
            //public void TerribleMisfortune()
            //{
            //    Random rand = new Random();
            //    int misfortune = rand.Next(10);
            //    switch(misfortune)
            //    {
            //        case 0:
            //        case 1:
            //        case 2:
            //        case 3:
            //        case 4:
            //            break;
            //        case 5:
            //        case 6:
            //            ice = 0;
            //            UserInterface.IceMelt();
            //            break;
            //        case 7:
            //            lemons = 0;
            //            UserInterface.LemonToss();
            //            break;
            //        case 8:
            //            sugar = 0;
            //            UserInterface.SugarTank();
            //            break;
            //        case 9:
            //            if (myWallet > 15)
            //            {
            //                myWallet -= 5;
            //                totalProfit -= 5;
            //                UserInterface.BullySwipe();
            //            }
            //            break;
            //    }
            //}
        }
    }

