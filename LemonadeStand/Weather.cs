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
            temperature = DetermineTemperature(actualweather);
            forecast = DetermineForecast(temperature, actualweather);
        }

        //member methods (CAN DO)
        public string DetermineWeather()
        {
            conditions = new List<string>() { "sunny and dry", "sunny", "sunny", "sunny", "cloudy", "cloudy", "rainy", "storming" };
            Random rand = new Random();
            int weatherindex = rand.Next(7);
            string actualWeather = conditions[weatherindex];
            return actualWeather;
        }
        public double DetermineTemperature(string actualweather)
        {
            double temp;
            Random rand = new Random();
            if (actualweather == "sunny and dry")
            {
                temp = rand.Next(75, 95);
            }
            else
            {
                temp = rand.Next(55, 90);
            }
            return temp;
        }
        public string DetermineForecast(double temp, string weather)
        {
            if(temp < 62)
            {
                forecast = "cool ";
            }
            else if (temp >= 62 && temp < 79)
            {
                forecast = "warm ";
            }
            else
            {
                forecast = "hot ";
            }
            Random rand = new Random();
            double chaos = rand.Next(5);
            if (weather == "sunny and dry")
            {
                switch (chaos)
                {
                    case 0:
                    case 1:
                    case 2:
                        forecast += "with clear skies";
                        break;
                    case 3:
                    case 4:
                        forecast += "and sunshine likely";
                        break;
                }
            }
            if (weather == "sunny")
            {
                switch(chaos)
                {
                    case 0:
                    case 1:
                    case 2:
                        forecast += "and sunshine likely";
                        break;
                    case 3:
                        forecast += "and possibly cloudy";
                        break;
                    case 4:
                        forecast += "with a small chance of showers";
                        break;
                }
            }
            else if (weather == "cloudy")
            {
                switch (chaos)
                {
                    case 0:
                        forecast += "and possibly cloudy";
                        break;
                    case 1:
                    case 2:
                        forecast += "and likely cloudy";
                        break;
                    case 3:
                        forecast += "with a small chance of showers";
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
                        forecast += "with a small chance of showers";
                        break;
                    case 1:
                    case 2:
                        forecast += "and rain likely";
                        break;
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
                        forecast += "and likely overcast";
                        break;
                }
            }
            return forecast;
        }
    }
}
