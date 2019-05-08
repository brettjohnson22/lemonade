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

        //constructor (SPAWNER)
        public Day(int dayNumber)
        {
            this.dayNumber = dayNumber;
            weather = new Weather();
        }
        //member methods (CAN DO)
        public double DetermineCustomers(Weather weather, Recipe recipe, double pitchers, double price)
        {
            double actualbuyers = 0;
            potentialBuyers = new List<Customer>();
            double numberOfPotential = 0;
            double cups = pitchers * Game.cupsPerPitcher;
            Random rand = new Random();
            if (weather.actualweather == "sunny and dry")
            {
                numberOfPotential = cups;
            }
            else if (weather.actualweather == "sunny")
            {
                if (cups >= 30)
                {
                    numberOfPotential = rand.Next(20, 30);
                }
                else
                {
                    numberOfPotential = cups;
                }
            }
            else if (weather.actualweather == "cloudy")
            {
                if (cups >= 20)
                {
                    numberOfPotential = rand.Next(10, 20);
                }
                else
                {
                    numberOfPotential = cups;
                }
                
            }
            else if (weather.actualweather == "rainy")
            {
                if (cups >= 15)
                {
                    numberOfPotential = rand.Next(5, 15);
                }
                else
                {
                    numberOfPotential = cups;
                }
            }
            else if(weather.actualweather == "storming")
            {
                if (cups >= 10)
                {
                    numberOfPotential = rand.Next(11);
                }
                else
                {
                    numberOfPotential = cups;
                }
            }
            for(int i = 0; i < numberOfPotential; i++)
            {
                Random personalityDeterminer = new Random();
                int personality = personalityDeterminer.Next(6);
                if(personality == 0 || personality == 1)
                {
                    potentialBuyers.Add(new SourPuss());
                }
                else if(personality == 2 || personality == 3)
                {
                    potentialBuyers.Add(new SweetTooth());
                }
                else
                {
                    potentialBuyers.Add(new Customer());
                }
            }
            foreach(Customer customer in potentialBuyers)
            {
                if (customer.DecideToBuy(weather, recipe, price))
                {
                    actualbuyers++;
                }
            }
            return actualbuyers;
        }

    }
}
