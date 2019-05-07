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
        public double cupsPerPitcher;

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
            cupsPerPitcher = 8;
            UI.IntroText();
        }
        public void MainDisplay()
        {
            UI.DailyText(day, player1.myInventory);
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
            double customers = DetermineCustomers(pitchers);
            double sales = TotalSales(price, customers);
            double dailyexpense = DailyExpense(pitchers);
            double dailyprofit = DailyProfits(sales, dailyexpense);
            UpdateWallet(player1.myInventory, sales);
            UpdateTotalProfits(player1.myInventory, dailyprofit);
            UI.EndOfDay(day, customers, price, sales, player1.myInventory);
            Console.ReadLine();
        }
        public double GetPrice()
        {
            MainDisplay();
            double price = 0;
            Console.WriteLine("\nWhat will you set today's price at?");
            try
            {
                price = double.Parse(Console.ReadLine());
            }
            catch(FormatException)
            {
                Console.WriteLine("You must enter a number. Try again.");
                Console.ReadLine();
            }
            return price;
        }
        public double MakePitchers(Inventory inv, double price)
        {
            MainDisplay();
            int pitchers = 0;
            Console.WriteLine($"\nCharging ${price} per cup. Each pitcher makes {cupsPerPitcher} cups.\nHow many pitchers will you make today?");
            try
            {
                pitchers = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("You must enter a number. Try again.");
                Console.ReadLine();
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
                Console.WriteLine("You don't have enough supplies!");
                Console.ReadLine();
                return 0;
            }
        }
        public double DetermineCustomers(double pitchers)
        {
            double cups = pitchers * cupsPerPitcher;
            //Will eventually be the full algorhythm to determine number of sales
            double customers = cups;
            return customers;
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
                UI.OptionPrompt();
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
                UI.StorePrices(store);
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
                Console.WriteLine("\nWhich do you want to change?");
                UI.IngredientPrompt();
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
        public void IceMelt()
        {
            player1.myInventory.ice = 0;
            Console.WriteLine("Your excess ice has melted. You must buy more!");
            Console.ReadLine();
        }
        public void RunWeek()
        {
            while(daycounter < 7)
            {
                EachDay();
                IceMelt();
            }
        }
        public void GameOver()
        {
            Console.WriteLine($"Week has ended! Your total wallet amount is ${player1.myInventory.myWallet}.");
        }
    }
}
