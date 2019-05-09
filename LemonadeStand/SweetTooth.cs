using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class SweetTooth : Customer
    {
        //member variables (HAS A)

        //constructor (SPAWNER)
        public SweetTooth()
        {
            Random rand = new Random();
            customerWallet = rand.Next(3, 7);
        }

        //member methods (CAN DO)
        public override bool DecideToBuy(Weather weather, Recipe recipe, double price)
        {
            bool decision = false;
            double decisionFactors = 0;
            if (weather.actualWeather == "sunny and dry" && price < 8)
            {
                decisionFactors++;
                decisionFactors++;
            }
            if (weather.actualWeather == "sunny" && price <=5)
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
                decisionFactors++;
            }
            if (recipe.amountOfLemons > 3)
            {
                decisionFactors--;
            }
            if (weather.actualWeather == "rainy")
            {
                decisionFactors--;
            }
            if (weather.actualWeather == "storming")
            {
                decisionFactors--;
                decisionFactors--;
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
