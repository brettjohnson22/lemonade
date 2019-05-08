using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Player
    {
        //member variables (HAS A)
        public Inventory myInventory;

        //constructor (SPAWNER)
        public Player()
        {
            myInventory = new Inventory();
        }
        //member methods (CAN DO)
        public double PourCups(double pitchers)
        {
            double cups = pitchers * Game.cupsPerPitcher;
            return cups;
        }
    }
}
