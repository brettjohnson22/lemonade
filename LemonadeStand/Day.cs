using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Day
    {
        //member variables (HAS A)
        public int dayNumber;
        public Weather weather;
        //public Customer[] potentialbuyers;
        //public double actualbuyers;

        //constructor (SPAWNER)
        public Day(int dayNumber)
        {
            this.dayNumber = dayNumber;
            weather = new Weather();
        }
        //member methods (CAN DO)
        

    }
}
