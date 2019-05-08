using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Day
    {
        //member variables (HAS A)
        public int dayNumber;
        public Weather weather;
        public List<Customer> potentialBuyers;
        public double actualbuyers;

        //constructor (SPAWNER)
        public Day(int dayNumber)
        {
            this.dayNumber = dayNumber;
            weather = new Weather();
        }
        //member methods (CAN DO)
        public double DetermineCustomers(Weather weather, double pitchers)
        {
            double numberOfPotential = 0;
            double cups = pitchers * Game.cupsPerPitcher;
            Random rand = new Random();
            if (weather.actualweather == "sunny and dry")
            {
                numberOfPotential = rand.Next(40, 55);
            }
            else if (weather.actualweather == "sunny")
            {
                numberOfPotential = rand.Next(30, 45);
            }
            else if (weather.actualweather == "cloudy")
            {
                numberOfPotential = rand.Next(20, 30);
            }
            else if (weather.actualweather == "rainy")
            {
                numberOfPotential = rand.Next(5, 15);
            }
            else if(weather.actualweather == "storming")
            {
                numberOfPotential = rand.Next(10);
            }

            //Will eventually be the full algorhythm to determine number of sales
            //double customers = cups;
            //return customers;
        }

    }
}
