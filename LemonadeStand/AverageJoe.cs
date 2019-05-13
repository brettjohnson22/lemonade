using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class AverageJoe : Customer
    {
        //membervariables (HAS A)

        //constructor (SPAWNER)
        public AverageJoe()
        {
            Random rand = new Random();
            customerWallet = rand.Next(2, 6);
        }
        //membermethods (CAN DO)
    }
}
