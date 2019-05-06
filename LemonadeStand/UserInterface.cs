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
            Console.WriteLine($"\nWelcome to Day {day.dayNumber}. Today's forecast is " + day.weather.forecast + $". You have ${inv.myWallet}, and {inv.lemons} lemons, {inv.sugar} sugar, and {inv.ice} ice.\n\nGo to store, change recipe, or proceed? Type 'store', 'recipe', or 'proceed'.");
        }
        public void EndOfDay(Day day, double price, double profit, double walletamount)
        {
            Console.WriteLine($"\nToday was Day {day.dayNumber}. You charged $" + price + " per cup, and made $" + profit + ". You now have $" + walletamount + "." );
        }
    }
}
