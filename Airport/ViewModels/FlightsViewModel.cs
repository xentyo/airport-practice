using Airport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Airport.ViewModels
{
    public class FlightsViewModel
    {
        public City City { get; set; }
        public List<Flight> Arrivals { get; set; }
        public List<Flight> Departures { get; set; }

        public FlightsViewModel(City city)
        {
            City = city;
            Arrivals = city.Arrivals;
            Departures = city.Departures;
        }
    }
}