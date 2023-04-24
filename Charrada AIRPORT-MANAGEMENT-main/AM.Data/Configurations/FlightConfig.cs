using AM.Core.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Data.Configurations
{
    internal class flightConfig : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder//many to many f ->passenger
                .HasMany(f => f.passengers)
                .WithMany(p => p.Flights)
                .UsingEntity(a => a.ToTable("FP"));

            builder // one to many f->plane
                .HasOne(f => f.MyPlane)
                .WithMany(p => p.Flights)
                .HasForeignKey(f => f.PlaneId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}