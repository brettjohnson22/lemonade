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
        public double DetermineNumberOfPotentialCustomers(Weather weather)
        {
            double numberOfPotential = 0;
            Random rand = new Random();
            if (weather.actualWeather == "sunny and dry")
            {
                numberOfPotential = rand.Next(22, 30);
            }
            else if (weather.actualWeather == "sunny")
            {
                numberOfPotential = rand.Next(18, 25);
            }
            else if (weather.actualWeather == "cloudy")
            {
                {
                    numberOfPotential = rand.Next(10, 20);
                }
            }
            else if (weather.actualWeather == "rainy")
            {
                {
                    numberOfPotential = rand.Next(5, 10);
                }
            }
            else if (weather.actualWeather == "storming")
            {
                {
                    numberOfPotential = rand.Next(6);
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
                int personality = personalityDeterminer.Next(9);
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
                else if (personality == 6 || personality == 7)
                {
                    this.potentialCustomers.Add(new YourMom());
                }
                else if (personality == 8)
                {
                    this.potentialCustomers.Add(new CheapSkate());
                }
            }
            return potentialCustomers;
        }
        public double DeterminePayingCustomers(List<Customer> potentialBuyers, Weather weather, Recipe recipe, double price, double cups)
        {
            double actualCustomers = 0;
            foreach (Customer customer in potentialBuyers)
            {
                if (customer.DecideToBuy(weather, recipe, price))
                {
                    actualCustomers++;
                }
            }
            if (actualCustomers < cups)
            {
                return actualCustomers;
            }
            else
            {
                return cups;
            }
        }

    }
}
