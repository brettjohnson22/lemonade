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
            double tasteFactor = LikeTheTaste(weather, recipe);
            double weatherFactor = LikeTheWeather(weather);
            double priceFactor = LikeThePrice(price);
            bool decideToBuy = false;
            if (tasteFactor + weatherFactor + priceFactor >= 2)
            {
                decideToBuy = true;
            }
            return decideToBuy;
        }
        public override double LikeTheTaste(Weather weather, Recipe recipe)
        {
            double decisionFactors = 0;
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
            if (recipe.amountOfSugar >= recipe.amountOfLemons)
            {
                decisionFactors++;
            }
            if (recipe.amountOfSugar > 3)
            {
                decisionFactors++;
            }
            if (recipe.amountOfLemons > recipe.amountOfSugar)
            {
                decisionFactors--;
            }
            if (recipe.amountOfIce < 5 || recipe.amountOfIce > 20)
            {
                decisionFactors--;
                decisionFactors--;
            }
            if (recipe.amountOfSugar < 2 || recipe.amountOfSugar > 15)
            {
                decisionFactors--;
                decisionFactors--;
                decisionFactors--;
            }
            if (recipe.amountOfLemons < 2 || recipe.amountOfLemons > 8)
            {
                decisionFactors--;
                decisionFactors--;
                decisionFactors--;
            }
            return decisionFactors;
        }
    }
}
