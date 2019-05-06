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

        public void DailyText(int daynumber, string forecast, double walletamount)
        {
            Console.WriteLine("\nWelcome to Day " + daynumber + ". Today's forecast is " + forecast + ". You have $" + walletamount + ".\n\nGo to store or proceed? Type 'store' or 'proceed'.");
        }
        public void EndOfDay(int daynumber, double price, double profit, double walletamount)
        {
            Console.WriteLine("\nToday was Day " + daynumber + ". You charged $" + price + " per cup, and made $" + profit + ". You now have $" + walletamount + "." );
        }
    }
}
