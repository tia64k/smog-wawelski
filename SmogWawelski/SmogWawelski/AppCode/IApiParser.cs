using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using SmogWawelski.AppCode;

namespace SmogWawelski.AppCode
{
    public interface IApiParser
    {
        string ApiUrl { get; }
        SensorData GetSensorData(int sensorId);
    }
}
