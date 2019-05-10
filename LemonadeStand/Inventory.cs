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
        public List<StoreItem> allItems;


        //constructor (SPAWNER)
        public Inventory()
        {
            myWallet = 10;
            totalProfit = 0;
            StartingStock();
        }
        //member methods (CAN DO)
        public void StartingStock()
        {
            int startingLemons = 10;
            int startingSugar = 10;
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
        public void SubtractItemFromInventory(string itemName)
        {
            foreach (StoreItem item in allItems)
            {
                if (item.Name == itemName)
                {
                    allItems.Remove(item);
                    break;
                }

            }
        }
        public void TerribleMisfortune()
        {
            Random rand = new Random();
            int misfortune = rand.Next(10);
            switch (misfortune)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                    break;
                case 5:
                case 6:
                    allItems.RemoveAll(t => t.name == "ice");
                    UserInterface.IceMelt();
                    break;
                case 7:
                    allItems.RemoveAll(t => t.name == "lemon");
                    UserInterface.LemonToss();
                    break;
                case 8:
                    allItems.RemoveAll(t => t.name == "sugar");
                    UserInterface.SugarTank();
                    break;
                case 9:
                    if (myWallet > 15)
                    {
                        myWallet -= 5;
                        totalProfit -= 5;
                        UserInterface.BullySwipe();
                    }
                    break;
            }
        }
    }
    }

