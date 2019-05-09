using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Customer
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
            double tasteFactor = LikeTheTaste(weather, recipe);
            double weatherFactor = LikeTheWeather(weather);
            double priceFactor = LikeThePrice(price);
            bool decideToBuy = false;
            if (tasteFactor + weatherFactor + priceFactor > 2)
            {
                decideToBuy = true;
            }
            return decideToBuy;
        }
        public virtual double LikeTheTaste(Weather weather, Recipe recipe)
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
            if (recipe.amountOfLemons > recipe.amountOfSugar)
            {
                decisionFactors--;
            }
            if (recipe.amountOfIce < 5 || recipe.amountOfIce > 20)
            {
                decisionFactors--;
                decisionFactors--;
            }
            if (recipe.amountOfSugar < 2 || recipe.amountOfSugar > 10)
            {
                decisionFactors--;
                decisionFactors--;
                decisionFactors--;
            }
            if (recipe.amountOfLemons < 2 || recipe.amountOfLemons > 10)
            {
                decisionFactors--;
                decisionFactors--;
                decisionFactors--;
            }
            return decisionFactors;
        }
        public virtual double LikeTheWeather(Weather weather)
        {
            double decisionFactors = 0;
            if (weather.actualWeather == "sunny and dry")
            {
                decisionFactors++;
                decisionFactors++;
            }
            if (weather.actualWeather == "sunny")
            {
                decisionFactors++;
            }
            if (weather.actualWeather == "cloudy")
            {
                decisionFactors--;
            }
            if (weather.actualWeather == "rainy")
            {
                decisionFactors--;
                decisionFactors--;
            }
            if (weather.actualWeather == "storming")
            {
                decisionFactors--;
                decisionFactors--;
                decisionFactors--;
            }
            if (weather.temperature < 65)
            {
                decisionFactors--;
            }
            if (weather.temperature > 85)
            {
                decisionFactors++;
            }
            return decisionFactors;
        }
        public virtual double LikeThePrice(double price)
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
            if (price >= 5)
            {
                decisionFactors--;
            }
            if (price >= 7)
            {
                decisionFactors--;
                decisionFactors--;
            }
            return decisionFactors;
        }
    }
}
