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
        private static readonly double lemonCost;
        private static readonly double lemonSale;
        private static readonly double sugarCost;
        private static readonly double sugarSale;
        private static readonly double iceSale;
        private static readonly double iceCost;
        public static double LemonCost { get { return lemonCost; } }
        public static double LemonSale { get { return lemonSale; } }
        public static double SugarCost { get { return sugarCost; } }
        public static double SugarSale { get { return sugarSale; } }
        public static double IceSale { get { return iceSale; } }
        public static double IceCost { get { return iceCost; } }

        //constructor (SPAWNER)
        static Store()
        {
            lemonCost = 4;
            lemonSale = 5;
            sugarCost = 4;
            sugarSale = 8;
            iceCost = 5;
            iceSale = 100;
        }
        //member methods (CAN DO)
        public static void SellLemons(Inventory inv)
        {
            double lem = inv.lemons;
            double wallet = inv.myWallet;
            if (wallet >= lemonCost)
            {
                inv.lemons = lem + lemonSale;
                inv.myWallet = wallet - lemonCost;
            }
            else
            {
                UserInterface.CantAfford();
            }
        }
        public static void SellSugar(Inventory inv)
        {
            double sug = inv.sugar;
            double wallet = inv.myWallet;
            if (wallet >= sugarCost)
            {
                inv.sugar = sug + sugarSale;
                inv.myWallet = wallet - sugarCost;
            }
            else
            {
                UserInterface.CantAfford();
            }
        }
        public static void SellIce(Inventory inv)
        {
            double ice = inv.ice;
            double wallet = inv.myWallet;
            if (wallet >= iceCost)
            {
                inv.ice = ice + iceSale;
                inv.myWallet = wallet - iceCost;
            }
            else
            {
                UserInterface.CantAfford();
            }
        }
    }
}
