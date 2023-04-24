using AM.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace AM.Data
{
    public class AMContext: DbContext
    {
        //tp part 3 a,b,,c
        //lazem nhot haka bch naati accee bd
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Traveller> Travellers { get; set; }

        //parametrer l'acces a la bd
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb; 
                    Initial Catalog = Airport;  
                    Integrated Security = true");

        }

    }
}