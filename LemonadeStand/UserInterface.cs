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
        //public UserInterface()
        //{

        //}
        //member methods (CAN DO)
        public static void IntroText()
        {
            Console.WriteLine("Welcome to Lemonade Stand!\n\nIn this game, you will be running a Lemonade Stand over the course of a week.\n\nYou will have to purchase ingredients and set the price each day.\n\nThe weather and your recipe will affect sales.\nThere's also a small chance of a terrible misfortune affecting your supplies on any day.\n\nHow much can you make in 7 days?\n\nHit 'Enter' to start.");
            Console.ReadLine();
        }
        public static void DailyText(Day day, Inventory inv)
        {
            Console.Clear();
            Console.WriteLine($"\nWelcome to Day {day.dayNumber}.\n\nToday's forecast is {day.weather.forecast}.\n\nYou have ${inv.myWallet}.\n\nCurrent Stock: {inv.lemons} lemons, {inv.sugar} sugar, and {inv.ice} ice.\n\nEach pitcher uses {inv.myRecipe.amountoflemons} lemons, {inv.myRecipe.amountofsugar} sugar, and {inv.myRecipe.amountofice} ice.\n");
        }
        public static void StorePrices(Store store)
        {
            Console.WriteLine($"\nYou are at the store.\n\n{store.lemonsale} lemons for ${store.lemoncost}\n{store.sugarsale} sugar for ${store.sugarcost}\n{store.icesale} ice for ${store.icecost}\n\nWhat do you want to buy?");
            IngredientPrompt();
        }
        public static void IngredientPrompt()
        {
            Console.WriteLine("Type 'L' for lemons, 'S' for sugar, 'I' for ice or 'P' to proceed.");
        }
        public static void OptionPrompt()
        {
            Console.WriteLine("\nGo to store, change recipe, or proceed?\nType 'S' for store, 'R' for recipe', or 'P' to proceed.");
        }
        public static void EndOfDay(Day day, double customers, double price, double sales, Inventory inv)
        {
            Console.Clear();
            Console.WriteLine($"\nToday was Day {day.dayNumber}. The weather was {day.weather.temperature} degrees and {day.weather.actualweather}.\n\nYou sold {customers} cups at ${price} per cup, and made ${sales}. You now have $" + inv.myWallet + "." );
        }
        public static void EnterANumber()
        {
            Console.WriteLine("You must enter a number. Try again.");
            Console.ReadLine();
        }
        public static void IceMelt()
        {
            Console.WriteLine("You forgot to put your ice in the freezer, and it all melted. You'll have to buy more tomorrow.");
            Console.ReadLine();
        }
        public static void LemonToss()
        {
            Console.WriteLine("As you were packing up your lemonade stand for the night, a horde of zombies shambles down your street towards you. You pelt them with lemons until they get the message and stumble off in the opposite direction. You're safe for now, but unfortunately you'll have to buy more lemons tomorrow.");
            Console.ReadLine();
        }
        public static void SugarTank()
        {
            Console.WriteLine("A super fancy food truck that makes delicious-looking blended beverages parks right next to you, threatening to steal all your business. While the driver is distracted, you pour all your sugar in the truck's generator. The blender sputters and whirrs before stopping all together, smoke rising from the truck. The driver glares at you before driving off for repairs. Your business is safe for now, but you'll have to buy more sugar tomorrow.");
            Console.ReadLine();
        }
    }
}
