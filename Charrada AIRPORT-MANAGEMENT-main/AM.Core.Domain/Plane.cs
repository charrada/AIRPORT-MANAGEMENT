using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Domain
{
    public class Plane
    {
        //    [Range(int.MinValue, -1, ErrorMessage = "La valeur doit être négative.")]

        [Range(0, int.MaxValue, ErrorMessage = "entier positive")]//men ila

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
