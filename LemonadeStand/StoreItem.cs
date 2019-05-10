using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public abstract class StoreItem
    {
        //member variables (HAS A)
        public double sellAmount;
        public double costPerOrder;
        public string name;

        //constructor (SPAWNER)
        static StoreItem()
        {

        }
        public StoreItem()
        {

        }
        //member methods (CAN DO)
    }
}
