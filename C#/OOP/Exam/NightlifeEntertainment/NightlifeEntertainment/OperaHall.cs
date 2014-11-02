using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NightlifeEntertainment
{
    class OperaHall : Venue
    {
        public OperaHall(string name, string location, int numberOfSeats)
            : base(name, location, numberOfSeats, new List<PerformanceType> { PerformanceType.Theatre, PerformanceType.Opera })
        {
        }
    }
}
