using BO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TP_Dojo_V1
{
    public class Context : DbContext
    {
        public DbSet<Arme> Armes { get; set; }

        public DbSet<Samourai> Samourais { get; set; }
    }
}