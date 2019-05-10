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
        
        public Player player1;
        public Day day;
        public Store store;
        public int dayCounter;
        public static double cupsPerPitcher;

        //constructor (SPAWNER)
        public Game()
        {
        }
        //member methods (CAN DO)
        public void Welcome()
        {
            UserInterface.ChangeTextColor();
            player1 = new Player();
            store = new Store();
            player1.myInventory.StartingStock();
            player1.myRecipe.StartingRecipe();
            dayCounter = 0;
            cupsPerPitcher = 6;
            UserInterface.IntroText();
        }
        public void MainDisplay()
        {
            UserInterface.DailyText(day, player1.myInventory, player1.myRecipe);
            DisplayCost();
        }
        public void DisplayCost()
        {
            double costOfCup = CalculateCost();
            UserInterface.CostDisplay(costOfCup);
        }
        public void EachDay()
        {
            dayCounter++;
            day = new Day(dayCounter);
            double pitchers = 0;
            double price = 0;
            MainOptions();
            while (price == 0)
            {
                MainDisplay();
                price = GetPrice();
            }
            while(pitchers == 0)
            {
                MainDisplay();
                pitchers = MakePitchers(player1.myInventory, player1.myRecipe, price);
            }
            double cups = player1.PourCups(pitchers);
            double numberOfPotentialCustomers = day.DetermineNumberOfPotentialCustomers(day.weather);
            List<Customer> potentialCustomers = day.GiveCustomersPersonalities(numberOfPotentialCustomers);
            double actualCustomers = day.DeterminePayingCustomers(potentialCustomers, day.weather, player1.myRecipe, price, cups);
            double sales = TotalSales(price, actualCustomers);
            double dailyExpense = DailyExpense(pitchers);
            double dailyProfit = DailyProfits(sales, dailyExpense);
            UpdateWallet(player1.myInventory, sales);
            UpdateTotalProfits(player1.myInventory, dailyProfit);
            UserInterface.EndOfDay(day, numberOfPotentialCustomers, actualCustomers, cups, price, sales, dailyProfit, player1.myInventory);
            Console.ReadLine();
        }
        public double GetPrice()
        {
            MainDisplay();
            double price = 0;
            UserInterface.PricePrompt();
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
        public double MakePitchers(Inventory inv, Recipe recipe, double price)
        {
            MainDisplay();
            double pitchers = 0;
            UserInterface.PitcherPrompt(price);
            try
            {
                pitchers = double.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                UserInterface.EnterANumber();
            }
            if (pitchers * recipe.NumberInRecipe("lemon") <= inv.NumberOfItems("lemon") && pitchers * recipe.NumberInRecipe("sugar") <= inv.NumberOfItems("sugar") && pitchers * recipe.NumberInRecipe("ice") <= inv.NumberOfItems("ice"))
            {
                inv.SubtractInventoryItem("lemon", recipe.NumberInRecipe("lemon"));
                inv.SubtractInventoryItem("sugar", recipe.NumberInRecipe("sugar"));
                inv.SubtractInventoryItem("ice", recipe.NumberInRecipe("ice"));
                return pitchers;
            }
            else 
            {
                UserInterface.NeedSupplies();
                string input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "y":
                        MainOptions();
                        break;
                    case "n":
                        break;
                }
                pitchers = MakePitchers(inv, recipe, price);
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
            bool proceed = false;
            while (!proceed)
            {
                MainDisplay();
                UserInterface.OptionPrompt();
                string input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "recipe":
                        goto case "r";
                    case "r":
                        ChangeRecipe(player1.myRecipe);
                        break;
                    case "store":
                        goto case "s";
                    case "s":
                        GoToStore();
                        break;
                    case "p":
                        proceed = true;
                        break;
                }
            }
        }
        public void GoToStore()
        {
            MainDisplay();
            bool proceed = false;
            while (!proceed)
            {
                UserInterface.StorePrices(store);
                string input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "lemons":
                        goto case "l";
                    case "l":
                        store.SellItem(player1.myInventory, ref store.lemon);
                        MainDisplay();
                        break;
                    case "sugar":
                        goto case "s";
                    case "s":
                        store.SellItem(player1.myInventory, ref store.sugar);
                        MainDisplay();
                        break;
                    case "ice":
                        goto case "i";
                    case "i":
                        store.SellItem(player1.myInventory, ref store.ice);
                        MainDisplay();
                        break;
                    case "p":
                        proceed = true;
                        break;
                    default:
                        MainDisplay();
                        break;
                }
            }
        }
        public void ChangeRecipe(Recipe recipe)
        { 
            bool proceed = false;
            while (!proceed)
            {
                MainDisplay();
                UserInterface.ChangePrompt();
                UserInterface.IngredientPrompt();
                string input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "lemons":
                        goto case "l";
                    case "l":
                        MainDisplay();
                        recipe.AdjustItem<Lemon>(player1.myInventory, ref store.lemon);
                        break;
                    case "sugar":
                        goto case "s";
                    case "s":
                        MainDisplay();
                        recipe.AdjustItem<Sugar>(player1.myInventory, ref store.sugar);
                        break;
                    case "ice":
                        goto case "i";
                    case "i":
                        MainDisplay();
                        recipe.AdjustItem<Ice>(player1.myInventory, ref store.ice);
                        break;
                    case "p":
                        proceed = true;
                        break;
                    default:
                        break;
                }
            }
        }
        public double CalculateCost()
        {
            double costofpitcher = (player1.myRecipe.NumberInRecipe("lemon") * (store.lemon.CostPerOrder / store.lemon.SellAmount) + player1.myRecipe.NumberInRecipe("sugar") * (store.sugar.CostPerOrder / store.sugar.SellAmount) + player1.myRecipe.NumberInRecipe("ice") * (store.ice.CostPerOrder / store.ice.SellAmount));
            double costofcup = Math.Round(costofpitcher / cupsPerPitcher, 2);
            return costofcup;
        }
        public double DailyExpense(double pitchers)
        {
            double costofcup = CalculateCost();
            double expense = pitchers * (costofcup * cupsPerPitcher);
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
            while (dayCounter < 7)
            {
                EachDay();
                if (dayCounter < 6)
                {
                    player1.myInventory.TerribleMisfortune();
                }
                if((player1.myInventory.myWallet < 3 && (player1.myInventory.NumberOfItems("sugar") == 0 || player1.myInventory.NumberOfItems("ice") == 0)) || (player1.myInventory.myWallet < 4 && player1.myInventory.NumberOfItems("lemons") == 0))
                {
                    break;
                }
            }
            GameOver();
        }
        public void GameOver()
        {
            if (dayCounter == 7)
            {
                if(player1.myInventory.totalProfit >= 100)
                {
                    UserInterface.GameOver100(player1);
                }
                else
                {
                    UserInterface.GameOver(player1);
                }
            }
            else if ((player1.myInventory.myWallet < 3 && (player1.myInventory.NumberOfItems("sugar") == 0 || player1.myInventory.NumberOfItems("ice") == 0)) || (player1.myInventory.myWallet < 4 && player1.myInventory.NumberOfItems("lemons") == 0))
            {
                UserInterface.Bankrupt();
            }
        }
    }
}
