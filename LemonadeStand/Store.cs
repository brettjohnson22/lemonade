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
        public int lemoncost;
        public int lemonsale;
        public int sugarcost;
        public int sugarsale;
        public int icesale;
        public int icecost;

        //constructor (SPAWNER)
        public Store()
        {
            lemoncost = 10;
            lemonsale = 10;
            sugarcost = 10;
            sugarsale = 10;
            icecost = 10;
            icesale = 10;
        }
        //member methods (CAN DO)
        public void SellLemons(Inventory inv)
        {
            double lem = inv.lemons;
            double wallet = inv.myWallet;
            if (wallet >= 10)
            {
                inv.lemons = lem + lemonsale;
                inv.myWallet = wallet - lemoncost;
                Console.WriteLine($"\nBought 10 lemons for 5 dollars. Current lemons: {inv.lemons}. Current funds: ${inv.myWallet}.");
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
            if (wallet >= 10)
            {
                inv.sugar = sug + sugarsale;
                inv.myWallet = wallet - sugarcost;
                Console.WriteLine($"\nBought 10 sugar for 5 dollars. Current sugar: {inv.sugar}. Current funds: ${inv.myWallet}.");
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
            if (wallet >= 10)
            {
                inv.ice = ice + icesale;
                inv.myWallet = wallet - icecost;
                Console.WriteLine($"\nBought 10 ice for 5 dollars. Current ice: {inv.ice}. Current funds: ${inv.myWallet}.");
            }
            else
            {
                Console.WriteLine("\nYou can't afford this ice.");
            }
        }

    }
}
