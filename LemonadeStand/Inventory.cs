using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Inventory
    {
        //member variables (HAS A)
        public double myWallet;
        public double totalProfit;
        public double lemons;
        public double sugar;
        public double ice;
        public Recipe myRecipe;


        //constructor (SPAWNER)
        public Inventory()
        {
            myRecipe = new Recipe();
            myWallet = 10;
            totalProfit = 0;
            lemons = 10;
            sugar = 20;
            ice = 100;
        }
        //member methods (CAN DO)

    }
}
