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
        public List<Customer> potentialCustomers;

        //constructor (SPAWNER)
        public Day(int dayNumber)
        {
            this.dayNumber = dayNumber;
            weather = new Weather();
        }
        //member methods (CAN DO)
        public double DetermineNumberOfPotentialCustomers(Weather weather, double pitchers)
        {
            double numberOfPotential = 0;
            double cups = pitchers * Game.cupsPerPitcher;
            Random rand = new Random();
            if (weather.actualWeather == "sunny and dry")
            {
                numberOfPotential = cups;
            }
            else if (weather.actualWeather == "sunny")
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
            else if (weather.actualWeather == "cloudy")
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
            else if (weather.actualWeather == "rainy")
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
            else if (weather.actualWeather == "storming")
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
        public List<Customer> GiveCustomersPersonalities(double numberOfPotential)
        {
            potentialCustomers = new List<Customer>();
            Random personalityDeterminer = new Random();
            for (int i = 0; i < numberOfPotential; i++)
            {
                int personality = personalityDeterminer.Next(8);
                if (personality == 0 || personality == 1)
                {
                    potentialCustomers.Add(new SourPuss());
                }
                else if (personality == 2 || personality == 3)
                {
                    potentialCustomers.Add(new SweetTooth());
                }
                else if (personality == 4 || personality == 5)
                {
                    potentialCustomers.Add(new AverageJoe());
                }
                else if (personality == 6)
                {
                    this.potentialCustomers.Add(new YourMom());
                }
                else if (personality == 7)
                {
                    this.potentialCustomers.Add(new CheapSkate());
                }
            }
            return potentialCustomers;
        }
        public double DetermineActualCustomers(Weather weather, Recipe recipe, List<Customer> potentialBuyers, double price)
        {
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
