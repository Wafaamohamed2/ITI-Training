using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7_part2
{
    public class Thermostat
    {
        private float currentTemp;

        public delegate void TemperatureChangedEventHandler(float newTemp);
        public event TemperatureChangedEventHandler OnTemperatureChanged;

        public float CurrentTemp
        {
            get { return currentTemp; }
            set
            {
                if (currentTemp != value)
                {
                    currentTemp = value;
                    OnTemperatureChanged?.Invoke(currentTemp);
                }
            }
        }
        
           
        }
    }

