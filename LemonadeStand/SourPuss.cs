using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class SourPuss : Customer
    {
        //member variables (HAS A)

        //constructor (SPAWNER)
        public SourPuss()
        {
            Random rand = new Random();
            customerWallet = rand.Next(5);
        }

        //member methods (CAN DO)
        public override bool DecideToBuy(Weather weather, Recipe recipe, double price)
        {
            bool decision = false;
            double decisionFactors = 0;
            if (weather.actualWeather == "sunny and dry" && price < 6)
            {
                decisionFactors++;
                decisionFactors++;
            }
            if (weather.temperature > 80 && recipe.amountOfIce > 16)
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
            if (price < customerWallet)
            {
                decisionFactors++;
            }
            if (recipe.amountOfLemons > 3)
            {
                decisionFactors++;
            }
            if (weather.actualWeather == "rainy" || weather.actualWeather == "storming")
            {
                decisionFactors--;
                decisionFactors--;
            }
            if (price <= 2)
            {
                decisionFactors++;
            }
            if (price > 3)
            {
                decisionFactors--;
            }
            if (price > customerWallet)
            {
                decisionFactors--;
                decisionFactors--;
            }
            if (decisionFactors > 3)
            {
                decision = true;
            }
            return decision;
        }
    }
}
