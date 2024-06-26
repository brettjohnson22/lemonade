﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public abstract class Customer
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
            if (recipe.NumberInRecipe("sugar") >= recipe.NumberInRecipe("lemon"))
            {
                decisionFactors++;
            }
            if (recipe.NumberInRecipe("lemon") > recipe.NumberInRecipe("sugar"))
            {
                decisionFactors--;
            }
            if (recipe.NumberInRecipe("ice") < 5 || recipe.NumberInRecipe("ice") > 20)
            {
                decisionFactors--;
                decisionFactors--;
            }
            if (recipe.NumberInRecipe("sugar") < 2 || recipe.NumberInRecipe("sugar") > 10)
            {
                decisionFactors--;
                decisionFactors--;
                decisionFactors--;
            }
            if (recipe.NumberInRecipe("lemon") < 2 || recipe.NumberInRecipe("lemon") > 10)
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
            if (weather.temperature < 60)
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
