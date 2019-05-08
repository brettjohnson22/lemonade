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
        public int dayCounter;
        public static double cupsPerPitcher;

        //constructor (SPAWNER)
        public Game()
        {

        }
        //member methods (CAN DO)
        public void Welcome()
        {
            
            player1 = new Player();
            dayCounter = 0;
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
            dayCounter++;
            day = new Day(dayCounter);
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
            double numberOfPotentialCustomers = day.DetermineNumberOfPotentialCustomers(day.weather, pitchers);
            List<Customer> potentialCustomers = day.GiveCustomersPersonalities(numberOfPotentialCustomers);
            double actualCustomers = day.DetermineActualCustomers(day.weather, player1.myInventory.myRecipe, potentialCustomers, price);
            double sales = TotalSales(price, actualCustomers);
            double dailyexpense = DailyExpense(pitchers);
            double dailyprofit = DailyProfits(sales, dailyexpense);
            UpdateWallet(player1.myInventory, sales);
            UpdateTotalProfits(player1.myInventory, dailyprofit);
            UserInterface.EndOfDay(day, actualCustomers, price, sales, player1.myInventory);
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
            if (pitchers * inv.myRecipe.amountOfLemons <= inv.lemons && pitchers * inv.myRecipe.amountOfSugar <= inv.sugar && pitchers * inv.myRecipe.amountOfIce <= inv.ice)
            {
                inv.lemons -= (pitchers * inv.myRecipe.amountOfLemons);
                inv.sugar -= (pitchers * inv.myRecipe.amountOfSugar);
                inv.ice -= (pitchers * inv.myRecipe.amountOfIce);
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
                UserInterface.StorePrices();
                string input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "lemons":
                        goto case "l";
                    case "l":
                        Store.SellLemons(player1.myInventory);
                        MainDisplay();
                        break;
                    case "sugar":
                        goto case "s";
                    case "s":
                        Store.SellSugar(player1.myInventory);
                        MainDisplay();
                        break;
                    case "ice":
                        goto case "i";
                    case "i":
                        Store.SellIce(player1.myInventory);
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
            double costofpitcher = (player1.myInventory.myRecipe.amountOfLemons * (Store.LemonCost / Store.LemonSale) + player1.myInventory.myRecipe.amountOfSugar * (Store.SugarCost / Store.SugarSale) + player1.myInventory.myRecipe.amountOfIce * (Store.IceCost / Store.IceSale));
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
            while (dayCounter < 7)
            {
                EachDay();
                //player1.myInventory.TerribleMisfortune();
                if((player1.myInventory.myWallet < 3 && (player1.myInventory.sugar == 0 || player1.myInventory.ice == 0)) || (player1.myInventory.myWallet < 4 && player1.myInventory.lemons == 0))
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
                Console.WriteLine($"Week has ended! Your total wallet amount is ${player1.myInventory.myWallet}. Your net profit for the week is ${player1.myInventory.totalProfit}");
                Console.ReadLine();
            }
            //else if player ran out of money
        }
    }
}
