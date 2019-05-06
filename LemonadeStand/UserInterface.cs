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

        //member methods (CAN DO)
        public void IntroText()
        {
            Console.WriteLine("Welcome to Lemonade Stand!");
            Console.ReadLine();
            Console.WriteLine("In this game, you will be running a Lemonade Stand over the course of a week. You will set the price each day.");
        }

        public void DailyText(Day day, Inventory inv)
        {
            Console.Clear();
            Console.WriteLine($"\nWelcome to Day {day.dayNumber}.\nToday's forecast is {day.weather.forecast}.\nYou have ${inv.myWallet}.\nCurrent Stock: {inv.lemons} lemons, {inv.sugar} sugar, and {inv.ice} ice.\nEach pitcher uses {inv.myRecipe.amountoflemons} lemons, {inv.myRecipe.amountofsugar} sugar, and {inv.myRecipe.amountofice} ice.");
        }
        public void StorePrices(Store store)
        {
            Console.WriteLine($"\n{store.lemonsale} lemons for ${store.lemoncost}\n{store.sugarsale} sugar for ${store.sugarcost}\n{store.icesale} ice for ${store.icecost}\nWhat do you want to buy? Type 'lemons', 'sugar', or 'ice'.");
        }
        public void OptionPrompt()
        {
            Console.WriteLine("\nGo to store, change recipe, or proceed ?\nType 'store', 'recipe', or 'proceed'.");
        }
        public void EndOfDay(Day day, double price, double profit, double walletamount)
        {
            Console.Clear();
            Console.WriteLine($"\nToday was Day {day.dayNumber}. You charged $" + price + " per cup, and made $" + profit + ". You now have $" + walletamount + "." );
        }
    }
}
