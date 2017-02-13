using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmogWawelski.AppCode
{
    class DatabaseManger
    {
        private SQLiteConnection sqlite;

        public DatabaseManger()
        {
            sqlite = new SQLiteConnection("Data Source=data/SmogWawelskiDb.sqlite");
        }

        public void AddDataToDatabase(SensorData data)
        {
            try
            {
                SQLiteCommand insertSQL = new SQLiteCommand("INSERT INTO SensorData (SensorId, CityName, CityDescription, Temperature, Pressure, pm10, pm25, no2, so2, co, o3) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)", sqlite);
                insertSQL.Parameters.Add(data.SensorId);
                insertSQL.Parameters.Add(data.CityName);
                insertSQL.Parameters.Add(data.StreetName);
                insertSQL.Parameters.Add(data.Temperature);
                insertSQL.Parameters.Add(data.Pressure);
                insertSQL.Parameters.Add(data.Pm10);
                insertSQL.Parameters.Add(data.Pm25);
                insertSQL.Parameters.Add(data.No2);
                insertSQL.Parameters.Add(data.So2);
                insertSQL.Parameters.Add(data.Co);
                insertSQL.Parameters.Add(data.O3);
                try
                {
                    insertSQL.Prepare();
                    insertSQL.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            catch (SQLiteException ex)
            {
                throw ex;
            }
            sqlite.Close();
        }
    }
}
