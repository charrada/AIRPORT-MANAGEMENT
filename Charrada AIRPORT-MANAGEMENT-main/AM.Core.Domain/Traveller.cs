﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Domain
{
    public class Traveller:Passenger
    {
        public string HealthInformation { get; set; }
        public string Nationality { get; set; }

        public override string ToString()
        {
            return base.ToString() //l'appellation de la classe passenger
                + "HealthInformation:" + HealthInformation + ";"
                + "Nationalit:" + Nationality + ";";
        }

//12. Redéfinition des méthodes : Polymorphisme par héritage moch teb3a relation

            public override string GetPassengerType()
        {
            return "I am a Traveller";
        }
    }
}
