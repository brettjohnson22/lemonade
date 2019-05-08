using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Customer
    {
        //member variables (HAS A)
        public double customerWallet;

        //constructor (SPAWNER)
        public Customer()
        {

        }
        //member methods (CAN DO)
        public virtual bool DecideToBuy(Weather weather, Recipe recipe, double price)
        {
            bool decision = false;
            double decisionFactors = 0;
            if(weather.actualWeather == "sunny and dry" && price < 8)
            {
                decisionFactors++;
                decisionFactors++;
            }
            if(weather.actualWeather == "sunny")
            {
                decisionFactors++;
            }
            if(weather.temperature > 80 && recipe.amountOfIce > 16)
            {
                decisionFactors++;
            }
            if (weather.temperature >= 63 && weather.temperature <= 80 & recipe.amountOfIce > 10 && recipe.amountOfIce <= 16)
            {
                decisionFactors++;
            }
            if (weather.temperature < 63 && recipe.amountOfIce <= 12)
            {
                decisionFactors++;
            }
            if (recipe.amountOfSugar >= recipe.amountOfLemons)
            {
                decisionFactors++;
            }
            if (price <= customerWallet)
            {
                decisionFactors++;
            }
            if(price > customerWallet)
            {
                decisionFactors--;
            }
            if(weather.actualWeather == "storming")
            {
                decisionFactors--;
            }
            if (price <= 2)
            {
                decisionFactors++;
            }
            if (price > 7)
            {
                decisionFactors--;
            }
            if (price > 9)
            {
                decisionFactors--;
                decisionFactors--;
            }
            if (decisionFactors >= 2)
            {
                decision = true;
            }
            return decision;
        }
    }
}
