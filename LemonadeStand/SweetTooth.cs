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

        }

        //member methods (CAN DO)
        public override bool DecideToBuy(Weather weather, Recipe recipe, double price)
        {
            Random rand = new Random();
            customerWallet = rand.Next(3, 9);
            bool decision = false;
            double decisionfactors = 0;
            if (weather.actualweather == "sunny and dry" && price < 8)
            {
                decisionfactors++;
                decisionfactors++;
            }
            if (weather.actualweather == "sunny" && price <=5)
            {
                decisionfactors++;
                decisionfactors++;
            }
            if (weather.temperature > 80 && recipe.amountofice > 16)
            {
                decisionfactors++;
            }
            if (weather.temperature >= 63 && weather.temperature <= 85 & recipe.amountofice > 10 && recipe.amountofice <= 16)
            {
                decisionfactors++;
            }
            if (weather.temperature < 63 && recipe.amountofice <= 12)
            {
                decisionfactors++;
            }
            if (price <= customerWallet)
            {
                decisionfactors++;
            }
            if (recipe.amountofsugar >= recipe.amountoflemons)
            {
                decisionfactors++;
            }
            if (recipe.amountofsugar > 4)
            {
                decisionfactors++;
            }
            if (price <= 2)
            {
                decisionfactors++;
            }
            if (recipe.amountoflemons > 3)
            {
                decisionfactors--;
            }
            if (weather.actualweather == "storming")
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
