﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Game
    {
        //member variables (HAS A)
        
        public Player player1;
        public Day day;
        public Store store;
        public int daycounter;
        public static double cupsPerPitcher;

        //constructor (SPAWNER)
        public Game()
        {

        }
        //member methods (CAN DO)
        public void Welcome()
        {
            
            player1 = new Player();
            store = new Store();
            daycounter = 0;
            cupsPerPitcher = 8;
            UserInterface.IntroText();
        }
        public void MainDisplay()
        {
            UserInterface.DailyText(day, player1.myInventory);
            DisplayCost();
        }
        public void DisplayCost()
        {
            double costofcup = CalculateCost();
            Console.WriteLine($"Each cup costs you ${costofcup}.");
        }
        public void EachDay()
        {
            daycounter++;
            day = new Day(daycounter);
            double pitchers = 0;
            double price = 0;
            while (price == 0)
            {
                MainOptions();
                price = GetPrice();
            }
            while(pitchers == 0)
            {
                MainDisplay();
                pitchers = MakePitchers(player1.myInventory, price);
            }
            double customers = day.DetermineCustomers(day.weather, player1.myInventory.myRecipe, pitchers, price);
            double sales = TotalSales(price, customers);
            double dailyexpense = DailyExpense(pitchers);
            double dailyprofit = DailyProfits(sales, dailyexpense);
            UpdateWallet(player1.myInventory, sales);
            UpdateTotalProfits(player1.myInventory, dailyprofit);
            UserInterface.EndOfDay(day, customers, price, sales, player1.myInventory);
            Console.ReadLine();
        }
        public double GetPrice()
        {
            MainDisplay();
            double price = 0;
            Console.WriteLine("\nWhat will you set today's price at? (In dollars)");
            try
            {
                price = double.Parse(Console.ReadLine());
            }
            catch(FormatException)
            {
                UserInterface.EnterANumber();
            }
            return price;
        }
        public double MakePitchers(Inventory inv, double price)
        {
            MainDisplay();
            double pitchers = 0;
            Console.WriteLine($"\nCharging ${price} per cup. Each pitcher makes {cupsPerPitcher} cups.\nHow many pitchers will you make today?");
            try
            {
                pitchers = double.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                UserInterface.EnterANumber();
            }
            if (pitchers * inv.myRecipe.amountoflemons <= inv.lemons && pitchers * inv.myRecipe.amountofsugar <= inv.sugar && pitchers * inv.myRecipe.amountofice <= inv.ice)
            {
                inv.lemons -= (pitchers * inv.myRecipe.amountoflemons);
                inv.sugar -= (pitchers * inv.myRecipe.amountofsugar);
                inv.ice -= (pitchers * inv.myRecipe.amountofice);
                return pitchers;
            }
            else 
            {
                Console.WriteLine("You don't have enough supplies. Buy more? 'Y' for yes, 'N' for no.");
                string input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "y":
                        MainOptions();
                        break;
                    case "n":
                        break;
                }
                pitchers = MakePitchers(inv, price);
                return pitchers;
            }
        }
        public double TotalSales(double price, double customers)
        {
            double sales = price * customers;
            return sales;
        }
        public void MainOptions()
        {
            bool valid = false;
            while (!valid)
            {
                MainDisplay();
                UserInterface.OptionPrompt();
                string input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "recipe":
                        goto case "r";
                    case "r":
                        ChangeRecipe();
                        break;
                    case "store":
                        goto case "s";
                    case "s":
                        GoToStore();
                        break;
                    case "p":
                        valid = true;
                        break;
                }
            }
        }
        public void GoToStore()
        {
            MainDisplay();
            bool valid = false;
            while (!valid)
            {
                UserInterface.StorePrices(store);
                string input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "lemons":
                        goto case "l";
                    case "l":
                        store.SellLemons(player1.myInventory);
                        MainDisplay();
                        break;
                    case "sugar":
                        goto case "s";
                    case "s":
                        store.SellSugar(player1.myInventory);
                        MainDisplay();
                        break;
                    case "ice":
                        goto case "i";
                    case "i":
                        store.SellIce(player1.myInventory);
                        MainDisplay();
                        break;
                    case "p":
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
                MainDisplay();
                Console.WriteLine("\nWhich do you want to change?\n");
                UserInterface.IngredientPrompt();
                string input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "lemons":
                        goto case "l";
                    case "l":
                        MainDisplay();
                        player1.myInventory.myRecipe.AdjustLemons();
                        break;
                    case "sugar":
                        goto case "s";
                    case "s":
                        MainDisplay();
                        player1.myInventory.myRecipe.AdjustSugar();
                        break;
                    case "ice":
                        goto case "i";
                    case "i":
                        MainDisplay();
                        player1.myInventory.myRecipe.AdjustIce();
                        break;
                    case "p":
                        valid = true;
                        break;
                    default:
                        break;
                }
            }
        }
        public double CalculateCost()
        {
            double costofpitcher = (player1.myInventory.myRecipe.amountoflemons * (store.lemoncost / store.lemonsale) + player1.myInventory.myRecipe.amountofsugar * (store.sugarcost / store.sugarsale) + player1.myInventory.myRecipe.amountofice * (store.icecost / store.icesale));
            double costofcup = Math.Round(costofpitcher / cupsPerPitcher, 2);
            return costofcup;
        }
        public double DailyExpense(double pitchers)
        {
            double costofcup = CalculateCost();
            double expense = pitchers * costofcup;
            return expense;
        }
        public double DailyProfits(double sales, double dailyexpense)
        {
            double profits = sales - dailyexpense;
            return profits;
        }
        public void UpdateWallet(Inventory inv, double sales)
        {
            inv.myWallet += sales;
        }
        public void UpdateTotalProfits(Inventory Inv, double dailyprofit)
        {
            Inv.totalProfit += dailyprofit;
        }
        public void RunWeek()
        {
            while (daycounter < 7 && player1.myInventory.myWallet >= 0)
            {
                EachDay();
                player1.myInventory.TerribleMisfortune();
            }
            GameOver();
        }
        public void GameOver()
        {
            if (daycounter == 7)
            {
                Console.WriteLine($"Week has ended! Your total wallet amount is ${player1.myInventory.myWallet}. Your net profit for the week is ${player1.myInventory.totalProfit}");
                Console.ReadLine();
            }
            //else if player ran out of money
        }
    }
}
