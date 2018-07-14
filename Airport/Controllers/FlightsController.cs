using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Airport.Models;
using Airport.ViewModels;

namespace Airport.Controllers
{
    public class FlightsController : Controller
    {
        // GET: Flights
        public ActionResult Index(string id)
        {
            City c = new City(id);
            FlightsViewModel fvm = new FlightsViewModel(c);
            return View(fvm);
        }
    }
}