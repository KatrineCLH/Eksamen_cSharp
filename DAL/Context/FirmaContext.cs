using DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    internal class FirmaContext : DbContext
    {
        public FirmaContext() : base("KarenVolf") { }
        public DbSet<Afdeling> Afdelings { get; set; }
        public DbSet<Medarbejder>  Medarbejders { get; set; }
        public DbSet<Sag> Sags { get; set; }
        public DbSet<Tidsregistrering> Tidsregistrerings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
