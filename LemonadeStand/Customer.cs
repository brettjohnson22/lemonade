﻿using System;
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
            Random rand = new Random();
            customerWallet = rand.Next(1, 7);
        }
        //member methods (CAN DO)
        public virtual bool DecideToBuy(Weather weather, Recipe recipe, double price)
        {
            bool decision = false;
            double decisionfactors = 0;
            if(weather.actualweather == "sunny & dry" && price < customerWallet + 1)
            {
                decisionfactors++;
                decisionfactors++;
            }
            if(weather.actualweather == "sunny")
            {
                decisionfactors++;
            }
            if(weather.temperature > 80 && recipe.amountofice > 16)
            {
                decisionfactors++;
            }
            if(weather.temperature < 65 && recipe.amountofice < 10)
            {
                decisionfactors++;
            }
            if(price <= customerWallet)
            {
                decisionfactors++;
            }
            if(recipe.amountofsugar >= recipe.amountoflemons)
            {
                decisionfactors++;
            }
            if(weather.actualweather == "storming")
            {
                decisionfactors--;
            }
            if (price > 7)
            {
                decisionfactors--;
            }
            if (price > 9)
            {
                decisionfactors--;
                decisionfactors--;
            }
            if (decisionfactors >= 2)
            {
                decision = true;
            }
            return decision;
        }
    }
}
