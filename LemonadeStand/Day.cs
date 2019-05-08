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
        public double DeterminePotentialCustomers(Weather weather, double pitchers)
        {
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
            else if (weather.actualweather == "storming")
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
            return numberOfPotential;
        }
        public double DetermineActualCustomers(Weather weather, Recipe recipe, double potentialCustomers, double price)
        {
            potentialBuyers = new List<Customer>();
            for (int i = 0; i < potentialCustomers; i++)
            {
                Random personalityDeterminer = new Random();
                int personality = personalityDeterminer.Next(7);
                if (personality == 0 || personality == 1)
                {
                    potentialBuyers.Add(new SourPuss());
                }
                else if (personality == 2 || personality == 3)
                {
                    potentialBuyers.Add(new SweetTooth());
                }
                else if (personality == 4 || personality == 5)
                {
                    potentialBuyers.Add(new AverageJoe());
                }
                else if (personality == 6)
                {
                    potentialBuyers.Add(new YourMom());
                }
            }
            double actualCustomers = 0;
            foreach (Customer customer in potentialBuyers)
            {
                if (customer.DecideToBuy(weather, recipe, price))
                {
                    actualCustomers++;
                }
            }
            return actualCustomers;
        }

    }
}
