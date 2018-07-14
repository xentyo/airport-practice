using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Models
{
    public enum FlightStatus
    {
        Boarding = 0,
        Departed = 1,
        OnTime = 2,
        Arriving = 3,
        Arrived = 4,
        Delayed = 5,
        Cancelled = 6
    }
}
