using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Domain
{
    public class Flight
    {
        public string Destination { get; set; }
        public string Departure { get; set; }
        public DateTime FlightDate { get; set; }
        public int FlightId { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public int EstimatedDuration { get; set; }
        //les realtions !
        public Plane MyPlane { get; set; }//many to one
        public IList<Passenger> passengers { get; set; }//many to many

        public override string ToString()
        {
            return "Destination:" + Destination + ";"
                + "Departure:" + Departure + ";"
                + "FlightDate:" + FlightDate + ";"
                + "FlightId:" + FlightId + ";"
                + "EffectiveArrival:" + EffectiveArrival + ";"
                + "EstimatedDuration:" + EstimatedDuration;
        }

        //tp3 q7
        public string Comment { get; set; } //9ali zidha


    }
}
