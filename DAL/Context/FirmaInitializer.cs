using DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    internal class FirmaInitializer : CreateDatabaseIfNotExists<FirmaContext>
    {
        protected override void Seed(FirmaContext context)
        {
            Afdeling a1 = context.Afdelings.Add(new Afdeling(1, "Produktion"));
            Afdeling a2 = context.Afdelings.Add(new Afdeling(2, "Produktudvikling"));
            Afdeling a3 = context.Afdelings.Add(new Afdeling(3, "Kvalitetstest"));
            
            context.Sags.Add(new Sag(0, "Diverse", "Til arbejde, der ikke knytter sig til en sag", a1));
            context.Sags.Add(new Sag(0, "Diverse", "Til arbejde, der ikke knytter sig til en sag", a2));
            context.Sags.Add(new Sag(0, "Diverse", "Til arbejde, der ikke knytter sig til en sag", a3));
            
            context.SaveChanges();
        }
        private void dummy()
        {
            string result = System.Data.Entity.SqlServer.SqlFunctions.Char(65);
        }
    }
}
