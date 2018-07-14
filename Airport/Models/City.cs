using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airport.Models.Connection;

namespace Airport.Models
{
    public class City
    {
        #region attributes
        private string _id;
        private string _name;
        #endregion

        #region properties
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        #endregion

        #region constructors
        public City()
        {
            _id = "";
            _name = "";
        }

        public City(string id)
        {
            _id = id;
            _name = GetName(_id);
        }

        public City(string id, string name)
        {
            _id = id;
            _name = name;
        }

        #endregion

        #region methods

        public override string ToString()
        {
            return _name;
        }
        #endregion

        #region statics
        private static string GetName(string _id)
        {
            string name = "";
            SqlServerConnection connection = SqlServerConnection.Local;
            DataTable table = connection.GetDataTable("SELECT name FROM cities WHERE id='{0}'", _id);
            foreach (DataRow row in table.Rows)
                name = row["name"].ToString();
            return name;
        }

        public List<Flight> Arrivals
        {
            get
            {
                List<Flight> flights = new List<Flight>();
                string query = @"select f.id, f.airlineId, a.name as airlineName, date, f.departureCityId, dc.name as departureCityName, f.departureTime, 
                            f.arrivalCityId, ac.name as arrivalCityName, f.arrivalTime, f.status
                            from flights as f 
                            join airlines as a on f.airlineId = a.id
                            join cities as dc on f.departureCityId = dc.id
                            join cities as ac on f.arrivalCityId = ac.id
                            where f.arrivalCityId = '{0}'
                            order by f.arrivalTime";
                DataTable table = SqlServerConnection.Local.GetDataTable(query, this.Id);
                foreach (DataRow row in table.Rows)
                {
                    Airline airline = new Airline(row["airlineId"].ToString(), row["airlineName"].ToString());
                    City arrivalCity = new City(row["arrivalCityId"].ToString(), row["arrivalCityName"].ToString());
                    DateTime arrivalTime = DateTime.Parse(row["arrivalTime"].ToString());
                    DateTime date = DateTime.Parse(row["date"].ToString());
                    City departureCity = new City(row["departureCityId"].ToString(), row["departureCityName"].ToString());
                    DateTime departureTime = DateTime.Parse(row["departureTime"].ToString());
                    Flight flight = new Flight();
                    flight.Airline = airline;
                    flight.ArrivalCity = arrivalCity;
                    flight.ArrivalTime = arrivalTime;
                    flight.Date = date;
                    flight.DepartureCity = departureCity;
                    flight.DepartureTime = departureTime;
                    flight.Id = int.Parse(row["id"].ToString());
                    flights.Add(flight);
                }
                return flights;
            }
        }

        public List<Flight> Departures
        {
            get
            {
                List<Flight> flights = new List<Flight>();
                string query = @"select f.id, f.airlineId, a.name as airlineName, date, f.departureCityId, dc.name as departureCityName, f.departureTime, 
                            f.arrivalCityId, ac.name as arrivalCityName, f.arrivalTime, f.status
                            from flights as f 
                            join airlines as a on f.airlineId = a.id
                            join cities as dc on f.departureCityId = dc.id
                            join cities as ac on f.arrivalCityId = ac.id
                            where f.departureCityId = '{0}'
                            order by f.departureTime";
                DataTable table = SqlServerConnection.Local.GetDataTable(query, this.Id);
                foreach (DataRow row in table.Rows)
                {
                    Airline airline = new Airline(row["airlineId"].ToString(), row["airlineName"].ToString());
                    City arrivalCity = new City(row["arrivalCityId"].ToString(), row["arrivalCityName"].ToString());
                    DateTime arrivalTime = DateTime.Parse(row["arrivalTime"].ToString());
                    DateTime date = DateTime.Parse(row["date"].ToString());
                    City departureCity = new City(row["departureCityId"].ToString(), row["departureCityName"].ToString());
                    DateTime departureTime = DateTime.Parse(row["departureTime"].ToString());
                    Flight flight = new Flight();
                    flight.Airline = airline;
                    flight.ArrivalCity = arrivalCity;
                    flight.ArrivalTime = arrivalTime;
                    flight.Date = date;
                    flight.DepartureCity = departureCity;
                    flight.DepartureTime = departureTime;
                    flight.Id = int.Parse(row["id"].ToString());
                    flights.Add(flight);
                }
                return flights;
            }
        }

        #endregion
    }
}
