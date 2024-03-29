﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.Core.Domain;
using AM.Core.Interfaces;

namespace AM.Core.Services
{
    //   public class FlightService : IFlightService ,,,, kenet haka da5alna aleha service
    public class FlightService : Service<Flight>, IFlightService

    {
        public FlightService(IUnitOfWork unitOfWork) : base(unitOfWork)  //hedhi lazem tethat obligatoire
        {

            //TP6 Question 12 
            Flights = GetAll();
            //this.unitOfWork = unitOfWork;
            //repository = unitOfWork.GetRepository<Flight>();
        }

        //tp part2 
        public IList<Flight> Flights { get; set; } //prop


        //tp part2 q6
        public IList<DateTime> GetFlightDates(string destination) // linqIntegre
        {
            //return (from f in Flights 
            //       where f.Destination == destination
            //       select f.FlightDate).ToList();
            return Flights.Where(f => f.Destination == destination) //Methoded'extention
                .Select(f => f.FlightDate).ToList();

        }

        //tp part2 q5
        public void  GetFlights(string filterType, string filterValue)
        {
            switch (filterType)
            {
                case "Destination":
                    foreach (var flight in Flights)
                    {
                        if (flight.Destination == filterValue)
                        {
                            Console.WriteLine(flight);
                        }
                    }
                    break;

                case "Departure":
                    foreach (var flight in Flights)
                    {
                        if (flight.Departure == filterValue)
                        {
                            Console.WriteLine(flight);
                        }
                    }
                    break;

                case "FlightDate":
                    foreach (var flight in Flights)
                    {
                        if (flight.FlightDate.ToString() == filterValue)
                        {
                            Console.WriteLine(flight);
                        }
                    }
                    break;
                case "FlightId":
                    foreach (var flight in Flights)
                    {
                        if (flight.FlightId.ToString() == filterValue)//to string 5ater FILTER VALUE STRING
                        {
                            Console.WriteLine(flight);
                        }
                    }
                    break;
                case "EffectiveArrival":

                    foreach (var flight in Flights)
                    {
                        // if (flight.EffectiveArrival == DateTime.Parse(filterValue))     
                        if (flight.EffectiveArrival.ToString() == filterValue)
                        {
                            Console.WriteLine(flight);
                        }
                    }
                    break;
                case "EstimatedDuration":
                    try
                    {
                        foreach (var flight in Flights)
                        {
                            if (flight.EstimatedDuration == int.Parse(filterValue))//test al int 
                            {
                                Console.WriteLine(flight);
                            }
                        }
                    }catch(Exception ex) {
                        Console.WriteLine("la valeur du filter n'est pas un int : ", ex.ToString());

                    }break;

            }

        }



        //tp part2 q7

        public void ShowFlightDetails(Plane plane)
        {
            var result= from f in Flights where f.MyPlane.PlaneId== plane.PlaneId select new {f.Destination,f.FlightDate};//type anonyme affichina hedhom zouz

     foreach(var item in result)
            {
                Console.WriteLine("destination : " + item.Destination +
                    "date :" + item.FlightDate);

            }
        
        }
        //tp part2 q8

        public int  GetWeeklyFlightNumber(DateTime date)
        {
            //select f where l date mta3 lflight bin lyouma w 7jrs mbaed .count ehsebli 9adeh  
            var result = (from f in Flights
                         where f.FlightDate >= date && f.FlightDate < date.AddDays(7)
                         select f).Count();
            return result;
        }

        //tp part2 q9
        public double GetDurationAverage(string destination) //moyenne

        {
            var result = (from f in Flights where f.Destination == destination select f.EstimatedDuration).Average();
                return result;

        }

        //tp part2 q10
        public IList<Flight>  SortFlights() //tri
        {
            var result=(from f in Flights  orderby f.EstimatedDuration descending select f ).ToList();//selectit order by duration w hatit flist
            return result;
        }

        //tp part2 q11
        public IList<Passenger> GetThreeOlderTravellers(Flight flight)
        { 
        var result = (from p in flight.passengers  orderby p.Age descending
                     select p).Take(3).ToList();//ne5ou 3 men lkbar loulenin=take ! 

            return result;
        }
        /*
       public IList<Flight> ShowGroupedFlights()
        {var result=(from f in Flights  group  by (f.Destination)).ToList();

            return result;
        }
        */

        //tp part2 q12
        public void ShowGroupedFlights()
        {
            /*var */
            IEnumerable<IGrouping<string, Flight>> 
                result = from f in Flights group f by f.Destination;
            foreach (var grp in result)
            {
                Console.WriteLine(grp.Key);
                foreach (var f in grp)
                {
                    Console.WriteLine(f);

                }
            }


        }


        //Les méthodes anonymes
        public Passenger GetSeniorPassenger(IFlightService.GetScore meth)
        {
            var result = (from f in Flights
                          from p in f.passengers
                          orderby meth(p) descending
                          select p).First();
            return result;
        }

    }
}
