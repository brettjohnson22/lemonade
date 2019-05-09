using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class YourMom : Customer
    {
        //member variables (HAS A)

        //constructor (SPAWNER)
        public YourMom()
        {
            Random rand = new Random();
            customerWallet = rand.Next(4, 9);
        }
        //member methods (CAN DO)
        public override bool DecideToBuy(Weather weather, Recipe recipe, double price)
        {
            double tasteFactor = LikeTheTaste(weather, recipe);
            double weatherFactor = LikeTheWeather(weather);
            double priceFactor = LikeThePrice(price);
            bool decideToBuy = false;
            if (tasteFactor + weatherFactor + priceFactor > 0)
            {
                decideToBuy = true;
            }
            return decideToBuy;
        }
    }
}
