using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    abstract class Customer
    {
        //member variables (HAS A)
        public double customerWallet;
        //constructor (SPAWNER)
        public Customer()
        {
        }
        //member methods (CAN DO)
        public abstract bool DecideToBuy(Weather weather, Recipe recipe, double price);
    }
}
