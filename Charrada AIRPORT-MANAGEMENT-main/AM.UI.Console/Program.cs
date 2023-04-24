// See https://aka.ms/new-console-template for more information

using AM.Core.Domain;
using AM.Data;//zidha tansech
//using System.Numerics;

Console.WriteLine("Hello, World!");

//TP1. Question 7   initialisé ..
/*
Plane plane = new Plane();//constructeur par defaut
plane.Capacity = 100;
plane.ManufactureDate = new DateTime(2000, 1, 1);
plane.MyPlaneType = PlaneType.BOING;
*/
//TP1. Question 8 => créer le constructeur paramétré suivant : public Plane (PlaneType pt, int capacity, DateTime date)
//houni bl par defaut
Plane plane2 = new Plane (PlaneType.BOING , 55, new DateTime(2000,1,5) );
//TP1 Question 9 (initialiseur d'objet) tari9a o5ra
Plane plane3 = new Plane()
{
    Capacity = 100,
    ManufactureDate = new DateTime(2000, 1, 1),
    MyPlaneType = PlaneType.BOING
};

//tp1 q13

// create a new Passenger object and set the BirthDate property
Passenger passenger = new Passenger();
passenger.BirthDate = new DateTime(1990, 5, 1);

// call the GetAge1 method to calculate the passenger's age
passenger.GetAge1(passenger);

// the passenger's age is now stored in the Age property
Console.WriteLine( passenger.Age);



int age = 0;
Passenger passenger1 = new Passenger();
passenger.GetAge2(new DateTime(1990, 5, 1),ref age); //ken nhot ref nzid lkol ref lfn
Console.WriteLine(age);


//bch gadina l bd installina lsql halina l console fl am.data w zedna [key] mbaed Add-Migration,Update-Database


//tp3 q8 

Plane plane = new Plane()
{
    Capacity = 10,
    ManufactureDate = new DateTime(1998, 09, 01, 10, 30, 0),
    MyPlaneType = PlaneType.AIRBUS
};

Flight flight = new Flight()
{
    Comment = "comment",
    Departure = "Tunis",
    Destination = "Algerie",
    EffectiveArrival = new DateTime(2023, 09, 01, 12, 0, 0),
    EstimatedDuration = 60,
    FlightDate = new DateTime(2023, 09, 01, 10, 30, 0),
    MyPlane = plane

};



//tp3 q9  Migrer la BDD ajouti migration

AMContext aMContext = new AMContext();//sna3na houni l bd
aMContext.Add(plane); //addinehom et save
aMContext.Add(flight);
aMContext.SaveChanges();


//test q15 tp4
Flight flightQ11 = aMContext.Find<Flight>(2);
Console.WriteLine(flightQ11);
Console.WriteLine(flightQ11.MyPlane);
