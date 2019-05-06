using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Weather
    {
        //member variables (HAS A)
        public string forecast;
        public List<string> conditions;
        public string actualweather;
        //public double temperature;


        //constructor (SPAWNER)
        public Weather()
        {
            actualweather = DetermineWeather();
            forecast = DetermineForecast();
        }

        //member methods (CAN DO)
        public string DetermineWeather()
        {
            conditions = new List<string>() { "sunny", "cloudy", "rainy", "storming" };
            Random rand = new Random();
            int weatherindex = rand.Next(4);
            string actualWeather = conditions[weatherindex];
            return actualWeather;
        }
        public string DetermineForecast()
        {
            forecast = "50% chance of rain";
            return forecast;
        }
    }
}
