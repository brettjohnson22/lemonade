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
            MainOptions();
            double price = GetPrice();
            double cups = MakePitchers(player1.myInventory);
            if(cups == 0)
            {
                MainOptions();
            }
           // }
            //else
            //{
            //    Console.WriteLine("You don't have enough supplies to make a pitcher. Buy more ingredients or adjust your recipe.");
            //    double cups = 0;
            //}
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
            Console.Clear();
            Console.WriteLine($"\nYou have {inv.lemons} lemons, {inv.sugar} sugar, and {inv.ice} ice.\nEach pitcher uses {inv.myRecipe.amountoflemons} lemons, {inv.myRecipe.amountofsugar} sugar, and {inv.myRecipe.amountofice} ice.\n8 cups in a pitcher. How many pitchers will you make today? Type '0' to go back.");
            int pitchers = int.Parse(Console.ReadLine());
            if (pitchers * inv.myRecipe.amountoflemons <= inv.lemons && pitchers * inv.myRecipe.amountofsugar <= inv.sugar && pitchers * inv.myRecipe.amountofice <= inv.ice)
            {
                return pitchers;
            }
            else 
            {
                Console.WriteLine("You don't have enough supplies");
                return 0;
            }
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
        public void MainOptions()
        {
            bool valid = false;
            while (!valid)
            {
                UI.DailyText(day, player1.myInventory);
                UI.OptionPrompt();
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
        }
        public void GoToStore()
        {
            UI.DailyText(day, player1.myInventory);
            bool valid = false;
            while (!valid)
            {
                UI.StorePrices(store);
                string input = Console.ReadLine();
                switch (input)
                {
                    case "lemons":
                        store.SellLemons(player1.myInventory);
                        UI.DailyText(day, player1.myInventory);
                        break;
                    case "sugar":
                        store.SellSugar(player1.myInventory);
                        UI.DailyText(day, player1.myInventory);
                        break;
                    case "ice":
                        store.SellIce(player1.myInventory);
                        UI.DailyText(day, player1.myInventory);
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
            bool valid = false;
            while (!valid)
            {
                UI.DailyText(day, player1.myInventory);
                Console.WriteLine("\nWhich do you want to change? Type 'lemons', 'sugar', 'ice', or 'exit'.");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "lemons":
                        UI.DailyText(day, player1.myInventory);
                        player1.myInventory.myRecipe.AdjustLemons();
                        break;
                    case "sugar":
                        UI.DailyText(day, player1.myInventory);
                        player1.myInventory.myRecipe.AdjustSugar();
                        break;
                    case "ice":
                        UI.DailyText(day, player1.myInventory);
                        player1.myInventory.myRecipe.AdjustIce();
                        break;
                    case "exit":
                        valid = true;
                        break;
                    default:
                        break;
                }
            }
        }
        public void IceMelt()
        {
            player1.myInventory.ice = 0;
            Console.WriteLine("Your excess ice has melted. You must buy more!");
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
