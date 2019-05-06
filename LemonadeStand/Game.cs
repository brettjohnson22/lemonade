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
        public int daycounter;
        

        //constructor (SPAWNER)
        public Game()
        {

        }
        //member methods (CAN DO)
        public void Welcome()
        {
            UI = new UserInterface();
            player1 = new Player();
            daycounter = 0;
            UI.IntroText();
        }
        public void EachDay()
        {
            day = new Day();
            daycounter++;
            UI.DailyText(daycounter, day.weather.forecast, player1.myInventory.myWallet);
            double price = GetPrice();
            double cups = MakeCups();
            double cost = GetCost();
            double customers = DetermineBuyingCustomers(cups);
            double profit = ResolveDay(price, customers);
            player1.myInventory.myWallet = UpdateWallet(player1.myInventory.myWallet, cost, cups, profit);
            UI.EndOfDay(daycounter, price, profit, player1.myInventory.myWallet);
            Console.ReadLine();
        }
        public double GetPrice()
        {
            Console.WriteLine("What will you set today's price at?");
            double price = double.Parse(Console.ReadLine());
            return price;
        }
        public double GetCost()
        {
            double cost = 1;
            return cost;
        }
        public double MakeCups()
        {
            Console.WriteLine("How many cups will you make today?");
            double cups = double.Parse(Console.ReadLine());
            return cups;
        }
        public double DetermineBuyingCustomers(double cups)
        {
            double customers = cups;
            return customers;
        }
        public double UpdateWallet(double wallet, double cost, double cups, double profit)
        {
            double updatedWallet = wallet - (cost * cups) + profit;
            return updatedWallet;
        }
        public double ResolveDay(double price, double customers)
        {
            double profit = price * customers;
            return profit;
        }
        public void RunWeek()
        {
            while(daycounter < 7)
            {
                EachDay();                
            }
        }
    }
}
