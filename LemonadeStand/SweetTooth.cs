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

        //member methods (CAN DO)
        public override bool DecideToBuy(Weather weather, Recipe recipe, double price)
        {
            bool decision = false;
            double decisionfactors = 0;
            if ((weather.actualweather == "Sunny & dry") && (price < customerWallet + 1))
            {
                decisionfactors++;
                decisionfactors++;
            }
            if (weather.temperature > 80 && recipe.amountofice > 16)
            {
                decisionfactors++;
            }
            if (weather.temperature < 65 && recipe.amountofice < 10)
            {
                decisionfactors++;
            }
            if (price <= customerWallet)
            {
                decisionfactors++;
            }
            if (recipe.amountofsugar > 4)
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
