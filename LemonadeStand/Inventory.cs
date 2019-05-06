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
        public double lemons;
        public double sugar;
        public double ice;
        public Recipe myrecipe;


        //constructor (SPAWNER)
        public Inventory()
        {
            myrecipe = new Recipe();
            myWallet = 50;
            lemons = 20;
            sugar = 20;
            ice = 20;
        }
        //member methods (CAN DO)
        
    }
}
