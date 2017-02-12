using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmogWawelski.AppCode;
using System.Net;
using System.Windows;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SmogWawelski.Exceptions;
using System.ComponentModel;
using System.Reflection;

namespace SmogWawelski.Parsers
{
    public enum Measurement
    {
        [Description("pm10")]
        Pm10,
        [Description("pm2.5")]
        Pm25,
        [Description("no2")]
        No2,
        [Description("so2")]
        So2,
        [Description("co")]
        Co,
        [Description("o3")]
        O3
    }

    public class PowietrzeMalopolskaParser : IApiParser
    {
        private string apiUrl = @"http://powietrze.malopolska.pl/_powietrzeapi/api/dane?act=danemiasta&ci_id=01";

        public string ApiUrl
        {
            get { return apiUrl; }
        }


        public SensorData GetSensorData(int sensorId)
        {
            SensorData data = new SensorData();

            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString(ApiUrl);

                var dynamicObject = JsonConvert.DeserializeObject(json);

                JObject dataObject = (JObject)dynamicObject;

                if (!IsSensorAvaliable(dataObject, sensorId))
                {
                    throw new SensorNotFoundException("Brak stacji o podanym ID");
                }

                data.CityName = dataObject["dane"]["city"]["ci_citydesc"].Value<string>();
                data.StreetName = dataObject["dane"]["actual"][sensorId]["station_name"].Value<string>();
                data.Pm10 = GetMeasurementValue(dataObject, sensorId, Measurement.Pm10);
                data.Pm25 = GetMeasurementValue(dataObject, sensorId, Measurement.Pm25);
                data.No2 = GetMeasurementValue(dataObject, sensorId, Measurement.No2);
                data.So2 = GetMeasurementValue(dataObject, sensorId, Measurement.So2);
                data.Co = GetMeasurementValue(dataObject, sensorId, Measurement.Co);
                data.O3 = GetMeasurementValue(dataObject, sensorId, Measurement.O3);
            }
            return data;
        }

        public Dictionary<int, string> GetSensorNames()
        {
            Dictionary<int, string> sensors = new Dictionary<int, string>();

            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString(ApiUrl);

                var dynamicObject = JsonConvert.DeserializeObject(json);

                JObject dataObject = (JObject)dynamicObject;

                foreach (JToken token in dataObject["dane"]["actual"])
                {
                    sensors.Add(token["station_id"].Value<int>(), token["station_name"].Value<string>());
                }
            }
            return sensors;
        }

        private bool IsSensorAvaliable(JObject dataObject, int sensorId)
        {
            string sensor = dataObject["dane"]["city"]["ci_citydesc"].Value<string>();

            foreach (JToken element in dataObject["dane"]["actual"].AsQueryable())
            {
                if (element["station_id"].Value<string>() == sensorId.ToString())
                {
                    return true;
                }
            }
            return false;
        }

        private string GetMeasurementValue(JObject dataObject, int sensorId, Measurement measurement)
        {
            foreach (JToken element in dataObject["dane"]["actual"][sensorId]["details"].AsQueryable())
            {
                if (element["o_wskaznik"].Value<string>() == GetEnumDescription(measurement))
                {
                    return element["o_value"].Value<string>();
                }
            }
            return null;
        }

        private static string GetEnumDescription(Enum value)
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            if (name != null)
            {
                FieldInfo field = type.GetField(name);
                if (field != null)
                {
                    DescriptionAttribute attr =
                           Attribute.GetCustomAttribute(field,
                             typeof(DescriptionAttribute)) as DescriptionAttribute;
                    if (attr != null)
                    {
                        return attr.Description;
                    }
                }
            }
            return null;
        }
    }
}
