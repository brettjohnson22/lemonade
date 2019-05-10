using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Weather
    {
        //member variables (HAS A)
        public string forecast;
        public List<string> conditions;
        public string actualWeather;
        public double temperature;
     
        //constructor (SPAWNER)
        public Weather()
        {
            Random chaos = new Random();
            double forecastRand = chaos.Next(5);
            int weatherIndex = chaos.Next(8);
            actualWeather = DetermineWeather(weatherIndex);
            temperature = DetermineTemperature(actualWeather);
            forecast = DetermineForecast(temperature, actualWeather, forecastRand);
        }

        //member methods (CAN DO)
        public string DetermineWeather(int weatherIndex)
        {
            conditions = new List<string>() { "sunny and dry", "sunny", "sunny", "sunny", "cloudy", "cloudy", "rainy", "storming" };
            string actualWeather = conditions[weatherIndex];
            return actualWeather;
        }
        public double DetermineTemperature(string actualweather)
        {
            double temp;
            Random tempRand = new Random();
            if (actualweather == "sunny and dry")
            {
                temp = tempRand.Next(75, 95);
            }
            else if (actualweather == "sunny")
            {
                temp = tempRand.Next(70, 85);
            }
            else
            {
                temp = tempRand.Next(55, 80);
            }
            return temp;
        }
        public string DetermineForecast(double temp, string weather, double chaos)
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
                        forecast += "and likely overcast";
                        break;
                    case 4:
                        forecast += "with a thunderstorm watch in effect";
                        break;
                }
            }
            return forecast;
        }
    }
}
