using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public static class Store
    {
        //member variables (HAS A)
        private static double lemoncost;
        private static double lemonsale;
        private static double sugarcost;
        private static double sugarsale;
        private static double icesale;
        private static double icecost;
        public static double Lemoncost { get { return lemoncost; } }
        public static double Lemonsale { get { return lemonsale; } }
        public static double Sugarcost { get { return sugarcost; } }
        public static double Sugarsale { get { return sugarsale; } }
        public static double Icesale { get { return icesale; } }
        public static double Icecost { get { return icecost; } }

        //constructor (SPAWNER)
        static Store()
        {
            lemoncost = 4;
            lemonsale = 8;
            sugarcost = 3;
            sugarsale = 5;
            icecost = 3;
            icesale = 100;
        }
        //member methods (CAN DO)
        public static void SellLemons(Inventory inv)
        {
            double lem = inv.lemons;
            double wallet = inv.myWallet;
            if (wallet >= lemoncost)
            {
                inv.lemons = lem + lemonsale;
                inv.myWallet = wallet - lemoncost;
            }
            else
            {
                Console.WriteLine("\nYou can't afford these lemons.");
            }
        }
        public static void SellSugar(Inventory inv)
        {
            double sug = inv.sugar;
            double wallet = inv.myWallet;
            if (wallet >= sugarcost)
            {
                inv.sugar = sug + sugarsale;
                inv.myWallet = wallet - sugarcost;
            }
            else
            {
                Console.WriteLine("\nYou can't afford this sugar.");
            }
        }
        public static void SellIce(Inventory inv)
        {
            double ice = inv.ice;
            double wallet = inv.myWallet;
            if (wallet >= icecost)
            {
                inv.ice = ice + icesale;
                inv.myWallet = wallet - icecost;
            }
            else
            {
                Console.WriteLine("\nYou can't afford this ice.");
            }
        }

    }
}
