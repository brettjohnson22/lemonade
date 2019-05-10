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
        public double SellAmount { get { return sellAmount; } }
        public double CostPerOrder { get { return costPerOrder; } }
        public string Name { get { return name; } }

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
