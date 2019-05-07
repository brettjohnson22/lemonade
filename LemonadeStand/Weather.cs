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
        public double temperature;
        //public double temperature;


        //constructor (SPAWNER)
        public Weather()
        {
            actualweather = DetermineWeather();
            temperature = DetermineTemperature(); 
            forecast = DetermineForecast(temperature, actualweather);
        }

        //member methods (CAN DO)
        public string DetermineWeather()
        {
            conditions = new List<string>() { "sunny", "sunny", "sunny", "cloudy", "cloudy", "rainy", "storming" };
            Random rand = new Random();
            int weatherindex = rand.Next(7);
            string actualWeather = conditions[weatherindex];
            return actualWeather;
        }
        public double DetermineTemperature()
        {
            Random rand = new Random();
            double temp = rand.Next(50, 90);
            return temp;
        }
        public string DetermineForecast(double temp, string weather)
        {
            forecast = "";
            if(temp < 62)
            {
                forecast += "cool ";
            }
            else if (temp > 62 && temp < 78)
            {
                forecast += "warm ";
            }
            else
            {
                forecast += "hot ";
            }
            Random rand = new Random();
            double chaos = rand.Next(5);
            if(weather == "sunny")
            {
                switch(chaos)
                {
                    case 0:
                    case 1:
                    case 2:
                        forecast += "and sunshine likely";
                        break;
                    case 3:
                        forecast += "and likely cloudy";
                        break;
                    case 4:
                        forecast += "with a chance of showers";
                        break;
                }
            }
            else if (weather == "cloudy")
            {
                switch (chaos)
                {
                    case 0:
                    case 1:
                        forecast += "and likely cloudy";
                        break;
                    case 2:
                    case 3:
                        forecast += "with a chance of showers";
                        break;
                    case 4:
                        forecast += "and sunshine likely";
                        break;
                }
            }
            else if (weather == "rainy")
            {
                switch (chaos)
                {
                    case 0:
                    case 1:
                        forecast += "and rain likely";
                        break;
                    case 2:
                    case 3:
                        forecast += "with a chance of showers";
                        break;
                    case 4:
                        forecast += "and likely cloudy";
                        break;
                }
            }
            else if (weather == "storming")
            {
                switch (chaos)
                {
                    case 0:
                        forecast += "with a chance of showers";
                        break;
                    case 1:
                    case 2:
                        forecast += "and rain likely";
                        break;
                    case 3:
                        forecast += "with a thunderstorm watch";
                        break;
                    case 4:
                        forecast += "and likely cloudy";
                        break;
                }
            }
            return forecast;
        }
    }
}
