using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Game
    {
        //member variables (HAS A)
        public UserInterface UI;
        public Player player1;
        public Day day;
        public Store store;
        public int daycounter;


        //constructor (SPAWNER)
        public Game()
        {

        }
        //member methods (CAN DO)
        public void Welcome()
        {
            UI = new UserInterface();
            player1 = new Player();
            store = new Store();
            daycounter = 0;
            UI.IntroText();
        }
        public void EachDay()
        {
            daycounter++;
            day = new Day(daycounter);
            bool valid = false;
            while (!valid)
            {
                UI.DailyText(day, player1.myInventory);
                string input = Console.ReadLine();
                switch (input)
                {
                    case "recipe":
                        ChangeRecipe();
                        break;
                    case "store":
                        GoToStore();
                        break;
                    case "proceed":
                        valid = true;
                        break;
                }
            }
            double price = GetPrice();
            double cups = MakePitchers(player1.myInventory);
            double cost = GetCost();
            double sales = DetermineSales(cups);
            double profit = ResolveDay(price, sales);
            player1.myInventory.myWallet = UpdateWallet(player1.myInventory.myWallet, cost, cups, profit);
            UI.EndOfDay(day, price, profit, player1.myInventory.myWallet);
            Console.ReadLine();
        }
        public double GetPrice()
        {
            Console.WriteLine("\nWhat will you set today's price at?");
            double price = double.Parse(Console.ReadLine());
            return price;
        }
        public double GetCost()
        {
            double cost = 1;
            return cost;
        }
        public double MakePitchers(Inventory inv)
        {
            Console.WriteLine($"\nYou have {inv.lemons} lemons, {inv.sugar} sugar, and {inv.ice} ice.\nEach pitcher uses {inv.myrecipe.amountoflemons} lemons, {inv.myrecipe.amountofsugar} sugar, and {inv.myrecipe.amountofice} ice.\n8 cups in a pitcher. How many pitchers will you make today?");
            int pitchers = int.Parse(Console.ReadLine());
            
            return pitchers;
        }
        public double DetermineSales(double cups)
        {
            //Will eventually be the full algorhythm to determine number of sales
            double customers = cups;
            return customers;
        }
        public double UpdateWallet(double wallet, double cost, double cups, double profit)
        {
            double updatedWallet = wallet - (cost * cups) + profit;
            return updatedWallet;
        }
        public double ResolveDay(double price, double customers)
        {
            double profit = price * customers;
            return profit;
        }
        public void GoToStore()
        {
            bool valid = false;
            while (!valid)
            {
                Console.WriteLine("\nWhat do you want to buy? Type 'lemons', 'sugar', 'ice', or 'exit'.");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "lemons":
                        store.SellLemons(player1.myInventory);
                        break;
                    case "sugar":
                        store.SellSugar(player1.myInventory);
                        break;
                    case "ice":
                        store.SellIce(player1.myInventory);
                        break;
                    case "exit":
                        valid = true;
                        break;
                    default:
                        break;
                }
            }
        }
        public void ChangeRecipe()
        {

        }
        public void RunWeek()
        {
            while(daycounter < 7)
            {
                EachDay();                
            }
        }
        public void GameOver()
        {

        }
    }
}
