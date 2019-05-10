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
            if (weather.temperature > 80 && recipe.NumberInRecipe("ice") > 16)
            {
                decisionFactors++;
            }
            if (weather.temperature >= 63 && weather.temperature <= 80 & recipe.NumberInRecipe("ice") > 10 && recipe.NumberInRecipe("ice") <= 16)
            {
                decisionFactors++;
            }
            if (weather.temperature < 63 && recipe.NumberInRecipe("ice") <= 12)
            {
                decisionFactors++;
            }
            if (recipe.NumberInRecipe("sugar") >= recipe.NumberInRecipe("lemons"))
            {
                decisionFactors++;
            }
            if (recipe.NumberInRecipe("sugar") > 3)
            {
                decisionFactors++;
                decisionFactors++;
            }
            if (recipe.NumberInRecipe("lemons") > recipe.NumberInRecipe("sugar"))
            {
                decisionFactors--;
            }
            if (recipe.NumberInRecipe("ice") < 5 || recipe.NumberInRecipe("ice") > 20)
            {
                decisionFactors--;
                decisionFactors--;
            }
            if (recipe.NumberInRecipe("sugar") < 2 || recipe.NumberInRecipe("sugar") > 15)
            {
                decisionFactors--;
                decisionFactors--;
                decisionFactors--;
            }
            if (recipe.NumberInRecipe("lemons") < 2 || recipe.NumberInRecipe("lemons") > 8)
            {
                decisionFactors--;
                decisionFactors--;
                decisionFactors--;
            }
            return decisionFactors;
        }
    }
}
