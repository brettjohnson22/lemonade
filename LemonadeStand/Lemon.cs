using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Lemon : StoreItem
    {
        //member variables (HAS A)

        //constructor (SPAWNER)
        public Lemon()
        {
            sellAmount = 5;
            costPerOrder = 4;
            name = "lemon";
        }

        //member methods (CAN DO)
    }
}
