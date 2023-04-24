using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Domain
{
    public class Plane
    {
        public int Capacity { get; set; }
        public DateTime ManufactureDate { get; set; }
        public int PlaneId { get; set; }
        public PlaneType MyPlaneType { get; set; }
        public override string ToString()
        {
            return "Capacity:" + Capacity + ";"
                + "ManufactureDate:" + ManufactureDate + ";"
                + "PlaneId:" + PlaneId + ";"
                + "PlaneType:" + MyPlaneType;
        }


        //one to many
        public IList<Flight> Flights { get; set; }

        //teb3a lmany to one 3aks lifou9i bch njm ml flight n3ayet lka3ba plane
        public Plane(PlaneType pt, int capacity, DateTime date)
        {
            Capacity = capacity;// on peut utiliser  this.Capacity = capacity; ou sans this (pour distinguer les noms)
            ManufactureDate = date;
            MyPlaneType = pt;
        }
        public Plane()//constructeur par defaut
        {

        }
 

    }
}
