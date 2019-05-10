using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Ice : StoreItem
    {
        //member variables (HAS A)


        //constructor (SPAWNER)
        public Ice()
        {
            sellAmount = 100;
            costPerOrder = 5;
            name = "ice";
        }
        //member methods (CAN DO)
    }
}
