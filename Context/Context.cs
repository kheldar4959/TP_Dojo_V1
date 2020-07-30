using BO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TP_Dojo_V1.BO;

namespace TP_Dojo_V1
{
    public class Context : DbContext
    {
        public DbSet<Arme> Armes { get; set; }

        public DbSet<Samourai> Samourais { get; set; }

        public DbSet<ArtMartial> ArtMartiaux { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Samourai>().HasMany(x => x.ArtMartiaux).WithMany();
            base.OnModelCreating(modelBuilder);
        }
    }
}