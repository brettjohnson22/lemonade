using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Store
    {
        //member variables (HAS A)
        public double lemoncost;
        public double lemonsale;
        public double sugarcost;
        public double sugarsale;
        public double icesale;
        public double icecost;

        //constructor (SPAWNER)
        public Store()
        {
            lemoncost = 4;
            lemonsale = 8;
            sugarcost = 3;
            sugarsale = 10;
            icecost = 3;
            icesale = 100;
        }
        //member methods (CAN DO)
        public void SellLemons(Inventory inv)
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
        public void SellSugar(Inventory inv)
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
        public void SellIce(Inventory inv)
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
