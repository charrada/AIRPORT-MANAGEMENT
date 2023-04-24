using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Domain
{
    public class Passenger
    {
        [Key]
        public DateTime BirthDate { get; set; }

        public string PassportNumber { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TelNumber { get; set; }
        public int Age; //teb3a l 13


        public override string ToString()
        {
            return "BirthDate:" + BirthDate + ";"
                + "PassportNumber:" + PassportNumber + ";"
                + "EmailAddress:" + EmailAddress + ";"
                + "FirstName:" + FirstName + ";"
                + "LastName:" + LastName + ";"
                + "TelNumber:" + TelNumber;
        }



        //les relations
        public IList<Flight> Flights { get; set; }//many to many




        //Question11.a tp1
        public bool CheckProfile(string lastName, string firstName)
        {
            if (lastName == LastName && firstName == FirstName)
                return true;
            return false;
        }

        //Question11.b  tp1
        /*
                public bool CheckProfile(string lastName, string firstName, string emailAdress) //min w maj tefre9
                {
                    if (lastName == LastName && firstName == FirstName && emailAdress == EmailAddress)
                        return true;
                    return false;
                }
        */
        //Question11.c  tp1  remplace a et b
        public bool CheckProfile(string lastName, string firstName, string emailAdress=null) //min w maj tefre9
        {
            if (emailAdress == null)
                return lastName == LastName && firstName == FirstName;
            else
                return lastName == LastName && firstName == FirstName && emailAdress == EmailAddress;
            /* methode o5ra
            if (emailAdress == null)
            {
                if (lastName == LastName && firstName == FirstName)
                    return true;
                return false;
            }
            else
            {
                if (lastName == LastName && firstName == FirstName && emailAdress == EmailAddress)
                    return true;
                return false;
            }*/

        }

        //12. Redéfinition des méthodes : Polymorphisme par héritage moch teb3a relation lkbira virtual

        public virtual string GetPassengerType()
        {
            return "I am a passenger";
        }

        //Question 13 tala3lou 3omrou 

        public void GetAge(DateTime birthDate, int calculatedAge)
        {
            DateTime now = DateTime.Now; //date lyoum
            int age = now.Year - birthDate.Year; //3omrou tawa


            //23/04/2023 < 2000 zidha omrek 23 walit 2023   donc yel9a eli date mta3 tawa  lo5ra ajded menha(fl mosta9bel) donc yna9es 3am
            // l akber howa date ajded a9reb leli tawa

            if (now < birthDate.AddYears(age))
            {
                if (now < birthDate.AddYears(age))
                {
                    age--;
                }


            }


            calculatedAge = age;

        }


        // Autres propriétés et méthodes de la classe Passenger
        public void GetAge1(Passenger aPassenger) //7at feha 3id miledou
        {
            DateTime now = DateTime.Now;
            int age= now.Year-aPassenger.BirthDate.Year;

            if(now<BirthDate.AddYears(age))
            {
                age--;
            }
            aPassenger.Age = age;


        }



        public void GetAge2(DateTime birthDate, ref int calculatedAge)
        {
            DateTime now = DateTime.Now;
            int age = now.Year - birthDate.Year;
            if (now < birthDate.AddYears(age))
            {
                age--;
            }

            calculatedAge = age;
        }

      
    }
}
