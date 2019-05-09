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
            bool decision = false;
            double decisionFactors = 1;
            if (weather.actualWeather == "sunny and dry" && price < 8)
            {
                decisionFactors++;
                decisionFactors++;
            }
            if (weather.actualWeather == "sunny" && price <= 5)
            {
                decisionFactors++;
                decisionFactors++;
            }
            if (weather.temperature > 80 && recipe.amountOfIce > 16)
            {
                decisionFactors++;
            }
            if (weather.temperature >= 63 && weather.temperature <= 85 & recipe.amountOfIce > 10 && recipe.amountOfIce <= 16)
            {
                decisionFactors++;
            }
            if (weather.temperature < 63 && recipe.amountOfIce <= 12)
            {
                decisionFactors++;
            }
            if (price <= customerWallet)
            {
                decisionFactors++;
            }
            if (recipe.amountOfSugar >= recipe.amountOfLemons)
            {
                decisionFactors++;
            }
            if (recipe.amountOfSugar > 4)
            {
                decisionFactors++;
            }
            if (price <= 2)
            {
                decisionFactors++;
            }
            if (recipe.amountOfLemons > recipe.amountOfSugar)
            {
                decisionFactors--;
            }
            if (weather.actualWeather == "storming")
            {
                decisionFactors--;
            }
            if (price > 5)
            {
                decisionFactors--;
            }
            if (price > 7)
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
