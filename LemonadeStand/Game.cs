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
        public void EachDay()
        {
            daycounter++;
            day = new Day(daycounter);
            double pitchers = 0;
            double price = 0;
            while(pitchers == 0 || price == 0)
            { 
            MainOptions();
            UI.DailyText(day, player1.myInventory);
            price = GetPrice();
            UI.DailyText(day, player1.myInventory);
            pitchers = MakePitchers(player1.myInventory, price);
            }
            double sales = DetermineSales(pitchers);
            double profit = ResolveDay(price, sales);
            player1.myInventory.myWallet = UpdateWallet(player1.myInventory.myWallet, profit);
            UI.EndOfDay(day, price, profit, player1.myInventory);
            Console.ReadLine();
        }
        public double GetPrice()
        {
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
        public void DisplayCost()
        {
            double costofpitcher = (player1.myInventory.myRecipe.amountoflemons * (store.lemoncost / store.lemonsale) + player1.myInventory.myRecipe.amountofsugar * (store.sugarcost / store.sugarsale) + player1.myInventory.myRecipe.amountofice * (store.icecost / store.icesale));
            double costofcup = costofpitcher / cupsPerPitcher;
            Console.WriteLine($"Each cups costs you ${costofcup}.");
            Console.ReadLine();
        }
        public double MakePitchers(Inventory inv, double price)
        {
            int pitchers = 0;
            UI.DailyText(day, player1.myInventory);
            Console.WriteLine($"\n8 cups in a pitcher. Charging ${price} per cup.\nHow many pitchers will you make today? Type '0' to go back.");
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
                return pitchers;
            }
            else 
            {
                Console.WriteLine("You don't have enough supplies");
                return 0;
            }
        }
        public double DetermineSales(double pitchers)
        {
            double cups = pitchers * cupsPerPitcher;
            //Will eventually be the full algorhythm to determine number of sales
            double customers = cups;
            return customers;
        }
        public double UpdateWallet(double wallet, double profit)
        {
            double updatedWallet = wallet + profit;
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
                DisplayCost();
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
            UI.DailyText(day, player1.myInventory);
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
                        UI.DailyText(day, player1.myInventory);
                        break;
                    case "sugar":
                        goto case "s";
                    case "s":
                        store.SellSugar(player1.myInventory);
                        UI.DailyText(day, player1.myInventory);
                        break;
                    case "ice":
                        goto case "i";
                    case "i":
                        store.SellIce(player1.myInventory);
                        UI.DailyText(day, player1.myInventory);
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
                UI.DailyText(day, player1.myInventory);
                Console.WriteLine("\nWhich do you want to change?");
                UI.IngredientPrompt();
                string input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "lemons":
                        goto case "l";
                    case "l":
                        UI.DailyText(day, player1.myInventory);
                        player1.myInventory.myRecipe.AdjustLemons();
                        break;
                    case "sugar":
                        goto case "s";
                    case "s":
                        UI.DailyText(day, player1.myInventory);
                        player1.myInventory.myRecipe.AdjustSugar();
                        break;
                    case "ice":
                        goto case "i";
                    case "i":
                        UI.DailyText(day, player1.myInventory);
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
