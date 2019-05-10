using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Sugar : StoreItem
    {
        //member variables (HAS A)

        //constructor (SPAWNER)
        public Sugar()
        {
            sellAmount = 8;
            costPerOrder = 4;
            name = "sugar";
        }

        //member methods (CAN DO)
    }
}
