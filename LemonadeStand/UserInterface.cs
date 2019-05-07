using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class UserInterface
    {
        //member variables (HAS A)

        //constructor (SPAWNER)
        public UserInterface()
        {

        }
        //member methods (CAN DO)
        public void IntroText()
        {
            Console.WriteLine("Welcome to Lemonade Stand!\n\nIn this game, you will be running a Lemonade Stand over the course of a week.\n\nYou will have to purchase ingredients and set the price each day.\n\nThe weather and your recipe will affect sales.\nThere's also a small chance of a terrible misfortune affecting your supplies on any day.\n\nHow much can you make in 7 days?\n\nHit 'Enter' to start.");
            Console.ReadLine();
        }
        public void DailyText(Day day, Inventory inv)
        {
            Console.Clear();
            Console.WriteLine($"\nWelcome to Day {day.dayNumber}.\n\nToday's forecast is {day.weather.forecast}.\n\nYou have ${inv.myWallet}.\n\nCurrent Stock: {inv.lemons} lemons, {inv.sugar} sugar, and {inv.ice} ice.\n\nEach pitcher uses {inv.myRecipe.amountoflemons} lemons, {inv.myRecipe.amountofsugar} sugar, and {inv.myRecipe.amountofice} ice.\n");
        }
        public void StorePrices(Store store)
        {
            Console.WriteLine($"\nYou are at the store.\n\n{store.lemonsale} lemons for ${store.lemoncost}\n{store.sugarsale} sugar for ${store.sugarcost}\n{store.icesale} ice for ${store.icecost}\n\nWhat do you want to buy?");
            IngredientPrompt();
        }
        public void IngredientPrompt()
        {
            Console.WriteLine("Type 'L' for lemons, 'S' for sugar, 'I' for ice or 'P' to proceed.");
        }
        public void OptionPrompt()
        {
            Console.WriteLine("\nGo to store, change recipe, or proceed?\nType 'S' for store, 'R' for recipe', or 'P' to proceed.");
        }
        public void EndOfDay(Day day, double customers, double price, double sales, Inventory inv)
        {
            Console.Clear();
            Console.WriteLine($"\nToday was Day {day.dayNumber}. The weather was {day.weather.temperature} degrees and {day.weather.actualweather}.\n\nYou sold {customers} cups at ${price} per cup, and made ${sales}. You now have $" + inv.myWallet + "." );
        }
    }
}
