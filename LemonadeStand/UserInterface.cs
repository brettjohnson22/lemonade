using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    static class UserInterface
    {
        //member variables (HAS A)

        //constructor (SPAWNER)

        //member methods (CAN DO)
        public static void IntroText()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Lemonade Stand!\n\nIn this game, you will be running a Lemonade Stand over the course of a week.\n\nYou will have to purchase ingredients and set the price each day. While you can charge less than a dollar per cup, keep in mind it's 2019 and a cup of lemonade costs $5 at Starbucks.\n\nThe weather and your recipe will affect sales.\nThere's also a small chance of a terrible misfortune affecting your supplies on any day.\n\nHow much can you make in 7 days?");
        }
        public static void PlayerPrompt()
        {
            Console.WriteLine("\nEnter number of players:");
        }
        public static void NamePrompt(int i)
        {
            Console.WriteLine($"\nEnter name, for Player {i + 1} then hit 'Enter'");
        }

        public static void DailyText(Day day, Player player)
        {
            Console.Clear();
            Console.WriteLine($"\nWelcome to Day {day.dayNumber}, {player.name}!\n\nToday's forecast is {day.weather.forecast}.\n\nYou have ${player.myInventory.myWallet}.\n\nCurrent Stock: {player.myInventory.NumberOfItems("lemon")} lemons, {player.myInventory.NumberOfItems("sugar")} sugar, and {player.myInventory.NumberOfItems("ice")} ice.\n\nEach pitcher uses {player.myRecipe.NumberInRecipe("lemon")} lemons, {player.myRecipe.NumberInRecipe("sugar")} sugar, and {player.myRecipe.NumberInRecipe("ice")} ice.\n");
        }
        public static void CostDisplay(double costOfCup)
        {
            Console.WriteLine($"Each cup costs you ${costOfCup}.");
        }
        public static void StorePrices(Store store)
        {
            Console.WriteLine($"\nYou are at the store.\n\n{store.lemon.sellAmount} lemons for ${store.lemon.costPerOrder}\n{store.sugar.sellAmount} sugar for ${store.sugar.costPerOrder}\n{store.ice.sellAmount} ice for ${store.ice.costPerOrder}\n\nWhat do you want to buy?");
            IngredientPrompt();
        }
        public static void CantAfford()
        {
            Console.WriteLine($"\nYou can't afford this. Make more money!");
            Console.ReadLine();
        }
        public static void IngredientPrompt()
        {
            Console.WriteLine("Type 'L' for lemons, 'S' for sugar, 'I' for ice or 'P' to proceed.");
        }
        public static void OptionPrompt()
        {
            Console.WriteLine("\nGo to store, change recipe, or proceed?\nType 'S' for store, 'R' for recipe', or 'P' to proceed.");
        }
        public static void EndOfDay(Day day, double potential, double customers, double cups, double price, double sales, double profit, Inventory inv)
        {
            Console.Clear();
            Console.WriteLine($"\nToday was Day {day.dayNumber}. The weather was {day.weather.temperature} degrees and {day.weather.actualWeather}.\n\n{potential} people walked by your stand.\n\nYou sold {customers} of your {cups} cups at ${price} per cup, and made ${sales} for a profit of ${profit}. You now have $" + inv.myWallet + "." );
        }
        public static void IceMelt()
        {
            Console.WriteLine("You forgot to put your ice in the freezer, and it all melted. You'll have to buy more tomorrow.");
            Console.ReadLine();
        }
        public static void LemonToss()
        {
            Console.WriteLine("As you're packing up your lemonade stand for the night, a horde of caffiene-deprived programmers shamble down your street towards you. You pelt them with lemons until they get the message and stumble off in the opposite direction. You're safe for now, but unfortunately you'll have to buy more lemons tomorrow.");
            Console.ReadLine();
        }
        public static void SugarTank()
        {
            Console.WriteLine("A super fancy food truck that makes delicious-looking blended beverages parks right next to you, threatening to steal all your business. While the driver is distracted by counting out pomegranate seeds to drop into the blender, you pour all your sugar into the truck's generator. The blender sputters and whirrs before stopping all together, smoke rising from the back of the truck. The driver glares at you before driving off for repairs. Your business is safe for now, but you'll have to buy more sugar tomorrow.");
            Console.ReadLine();
        }
        public static void BullySwipe()
        {
            Console.WriteLine("The neighborhood bully swiped $5 when you weren't looking. What a jerk!");
            Console.ReadLine();
        }
        public static void GameOver(Player player)
        {
            Console.WriteLine($"{player.name}, you made it to the end of the week! Your total wallet amount is ${ player.myInventory.myWallet}. Your net profit for the week is ${ player.myInventory.totalProfit}.");
            Console.ReadLine();
            Console.ResetColor();
            Console.Clear();
        }
        public static void GameOver100(Player player)
        {
            Console.WriteLine($"{player.name}, you made it to the end of the week! Your total wallet amount is ${ player.myInventory.myWallet}. Your net profit for the week is ${ player.myInventory.totalProfit}. Looks like there's a new Lemonade Tycoon on the block!");
            Console.ReadLine();
        }
        public static void Bankrupt(Player player)
        {
            Console.WriteLine($"{player.name}, you went Bankrupt! Next time be more pennywise!");
            Console.ReadLine();
        }
        public static void NeedSupplies()
        {
            Console.WriteLine("You don't have enough supplies. Buy more? 'Y' for yes, 'N' for no.");
        }
        public static void PitcherPrompt(double price)
        {
            Console.WriteLine($"\nCharging ${price} per cup. Each pitcher makes {Game.cupsPerPitcher} cups.\nHow many pitchers will you make today?");
        }
        public static void PricePrompt()
        {
            Console.WriteLine("\nWhat will you set today's price at? (In dollars)");
        }
        public static void EnterANumber()
        {
            Console.WriteLine("You must enter a number. Try again.");
            Console.ReadLine();
        }
        public static void LowerNumber()
        {
            Console.WriteLine("You seriously want that many people to play? Try a smaller number.");
            Console.ReadLine();
        }
        public static void ChangePrompt()
        {
            Console.WriteLine("\nWhich do you want to change?\n");
        }
        public static void UseInPitcher(double amount, string ingredient)
        {
            Console.WriteLine($"You will be using {amount} {ingredient} per pitcher. Use up/down arrows to adjust. Hit 'enter' when done.");
        }
        public static void ClearOldLine()
        {
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            int returnPlacement = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, returnPlacement);
        }
        public static void ChangeTextColor()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Clear();
        }
    }
}
