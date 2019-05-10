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
            dayCounter = 0;
            cupsPerPitcher = 6;
            UserInterface.IntroText();
        }
        public void MainDisplay(Player player)
        {
            UserInterface.DailyText(day, player.myInventory, player.myRecipe);
            DisplayCost(player);
        }
        public void DisplayCost(Player player)
        {
            double costOfCup = CalculateCost(player);
            UserInterface.CostDisplay(costOfCup);
        }
        public void EachDay(Player player)
        {
            dayCounter++;
            day = new Day(dayCounter);
            double pitchers = 0;
            double price = 0;
            MainOptions(player);
            while (price == 0)
            {
                MainDisplay(player);
                price = GetPrice(player);
            }
            while(pitchers == 0)
            {
                MainDisplay(player);
                pitchers = MakePitchers(player, price);
            }
            double cups = player.PourCups(pitchers);
            double numberOfPotentialCustomers = day.DetermineNumberOfPotentialCustomers(day.weather);
            List<Customer> potentialCustomers = day.GiveCustomersPersonalities(numberOfPotentialCustomers);
            double actualCustomers = day.DeterminePayingCustomers(potentialCustomers, day.weather, player.myRecipe, price, cups);
            double sales = TotalSales(price, actualCustomers);
            double dailyExpense = DailyExpense(player, pitchers);
            double dailyProfit = DailyProfits(sales, dailyExpense);
            UpdateWallet(player, sales);
            UpdateTotalProfits(player, dailyProfit);
            UserInterface.EndOfDay(day, numberOfPotentialCustomers, actualCustomers, cups, price, sales, dailyProfit, player.myInventory);
            Console.ReadLine();
        }
        public double GetPrice(Player player)
        {
            MainDisplay(player);
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
        public double MakePitchers(Player player, double price)
        {
            MainDisplay(player);
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
            if (pitchers * player.myRecipe.NumberInRecipe("lemon") <= player.myInventory.NumberOfItems("lemon") && pitchers * player.myRecipe.NumberInRecipe("sugar") <= player.myInventory.NumberOfItems("sugar") && pitchers * player.myRecipe.NumberInRecipe("ice") <= player.myInventory.NumberOfItems("ice"))
            {
                player.myInventory.SubtractInventoryItem("lemon", player.myRecipe.NumberInRecipe("lemon"));
                player.myInventory.SubtractInventoryItem("sugar", player.myRecipe.NumberInRecipe("sugar"));
                player.myInventory.SubtractInventoryItem("ice", player.myRecipe.NumberInRecipe("ice"));
                return pitchers;
            }
            else 
            {
                UserInterface.NeedSupplies();
                string input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "y":
                        MainOptions(player);
                        break;
                    case "n":
                        break;
                }
                pitchers = MakePitchers(player, price);
                return pitchers;
            }
        }
        public double TotalSales(double price, double customers)
        {
            double sales = price * customers;
            return sales;
        }
        public void MainOptions(Player player)
        {
            bool proceed = false;
            while (!proceed)
            {
                MainDisplay(player);
                UserInterface.OptionPrompt();
                string input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "recipe":
                        goto case "r";
                    case "r":
                        ChangeRecipe(player);
                        break;
                    case "store":
                        goto case "s";
                    case "s":
                        GoToStore(player);
                        break;
                    case "p":
                        proceed = true;
                        break;
                }
            }
        }
        public void GoToStore(Player player)
        {
            MainDisplay(player);
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
                        store.SellItem(player.myInventory, ref store.lemon);
                        MainDisplay(player);
                        break;
                    case "sugar":
                        goto case "s";
                    case "s":
                        store.SellItem(player.myInventory, ref store.sugar);
                        MainDisplay(player);
                        break;
                    case "ice":
                        goto case "i";
                    case "i":
                        store.SellItem(player.myInventory, ref store.ice);
                        MainDisplay(player);
                        break;
                    case "p":
                        proceed = true;
                        break;
                    default:
                        MainDisplay(player);
                        break;
                }
            }
        }
        public void ChangeRecipe(Player player)
        { 
            bool proceed = false;
            while (!proceed)
            {
                MainDisplay(player);
                UserInterface.ChangePrompt();
                UserInterface.IngredientPrompt();
                string input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "lemons":
                        goto case "l";
                    case "l":
                        MainDisplay(player);
                        player.myRecipe.AdjustItem<Lemon>(player.myInventory, ref store.lemon);
                        break;
                    case "sugar":
                        goto case "s";
                    case "s":
                        MainDisplay(player);
                        player.myRecipe.AdjustItem<Sugar>(player.myInventory, ref store.sugar);
                        break;
                    case "ice":
                        goto case "i";
                    case "i":
                        MainDisplay(player);
                        player.myRecipe.AdjustItem<Ice>(player.myInventory, ref store.ice);
                        break;
                    case "p":
                        proceed = true;
                        break;
                    default:
                        break;
                }
            }
        }
        public double CalculateCost(Player player)
        {
            double costofpitcher = (player.myRecipe.NumberInRecipe("lemon") * (store.lemon.CostPerOrder / store.lemon.SellAmount) + player.myRecipe.NumberInRecipe("sugar") * (store.sugar.CostPerOrder / store.sugar.SellAmount) + player.myRecipe.NumberInRecipe("ice") * (store.ice.CostPerOrder / store.ice.SellAmount));
            double costofcup = Math.Round(costofpitcher / cupsPerPitcher, 2);
            return costofcup;
        }
        public double DailyExpense(Player player, double pitchers)
        {
            double costofcup = CalculateCost(player);
            double expense = pitchers * (costofcup * cupsPerPitcher);
            return expense;
        }
        public double DailyProfits(double sales, double dailyexpense)
        {
            double profits = sales - dailyexpense;
            return profits;
        }
        public void UpdateWallet(Player player, double sales)
        {
            player.myInventory.myWallet += sales;
        }
        public void UpdateTotalProfits(Player player, double dailyprofit)
        {
            player.myInventory.totalProfit += dailyprofit;
        }
        public void RunWeek()
        {
            while (dayCounter < 7)
            {
                EachDay(player1);
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
