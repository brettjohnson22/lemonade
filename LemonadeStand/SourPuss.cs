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
            double decisionfactors = 0;
            if (weather.actualweather == "sunny and dry" && price < 6)
            {
                decisionfactors++;
                decisionfactors++;
            }
            if (weather.temperature > 80 && recipe.amountofice > 16)
            {
                decisionfactors++;
            }
            if (weather.temperature < 63 && recipe.amountofice <= 12)
            {
                decisionfactors++;
            }
            if (price < customerWallet)
            {
                decisionfactors++;
            }
            if (recipe.amountoflemons > 3)
            {
                decisionfactors++;
            }
            if (weather.actualweather == "rainy" || weather.actualweather == "storming")
            {
                decisionfactors--;
                decisionfactors--;
            }
            if (price <= 2)
            {
                decisionfactors++;
            }
            if (price > 3)
            {
                decisionfactors--;
            }
            if (price > customerWallet)
            {
                decisionfactors--;
                decisionfactors--;
            }
            if (decisionfactors > 3)
            {
                decision = true;
            }
            return decision;
        }
    }
}
