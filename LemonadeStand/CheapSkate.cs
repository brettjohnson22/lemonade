using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class CheapSkate : Customer
    {
        //member methods (CAN DO)
        
        //constructor (SPAWNER)
        public CheapSkate()
        {
            Random rand = new Random();
            customerWallet = rand.Next(4);
        }

        //member variables
        public override bool DecideToBuy(Weather weather, Recipe recipe, double price)
        {
            double tasteFactor = LikeTheTaste(weather, recipe);
            double weatherFactor = LikeTheWeather(weather);
            double priceFactor = LikeThePrice(price);
            bool decideToBuy = false;
            if (tasteFactor + weatherFactor + priceFactor > 3)
            {
                decideToBuy = true;
            }
            return decideToBuy;
        }
        public override double LikeThePrice(double price)
        {
            double decisionFactors = 0;
            if (price <= 2)
            {
                decisionFactors++;
            }
            if (price <= customerWallet)
            {
                decisionFactors++;
            }
            if (price >= 3)
            {
                decisionFactors--;
            }
            if (price >= 5)
            {
                decisionFactors--;
                decisionFactors--;
            }
            return decisionFactors;
        }
    }
}
