using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmogWawelski.AppCode
{
    public class SensorData
    {
        /// <summary>
        /// ID of an air pollution sensor
        /// </summary>
        public long SensorId { get; set; }
        /// <summary>
        /// City name where the sensor is placed
        /// </summary>
        public string CityName { get; set; }
        /// <summary>
        /// Street name where the sensor is placed
        /// </summary>
        public string StreetName { get; set; }
        /// <summary>
        /// Air temperature
        /// </summary>
        public string Temperature { get; set; }
        /// <summary>
        /// Air pressure
        /// </summary>
        public string Pressure { get; set; }
        public string Pm10 { get; set; }
        public string Pm25 { get; set; }
        public string No2 { get; set; }
        public string So2 { get; set; }
        public string Co { get; set; }
        public string O3 { get; set; }
        /// <summary>
        /// Time of the measurement
        /// </summary>
        public DateTime Time { get; set; }
    }
}
