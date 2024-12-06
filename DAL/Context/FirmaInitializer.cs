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
            //Hardcoded afdelinger
            Afdeling a1 = context.Afdelings.Add(new Afdeling(1, "Produktion"));
            Afdeling a2 = context.Afdelings.Add(new Afdeling(2, "Produktudvikling"));
            Afdeling a3 = context.Afdelings.Add(new Afdeling(3, "Kvalitetstest"));

            //Sager til arbejde, der ikke kan knytte sig til en normal sag
            context.Sags.Add(new Sag("Diverse", "Til arbejde, der ikke knytter sig til en sag", a1.AfdelingsNummer));
            context.Sags.Add(new Sag("Diverse", "Til arbejde, der ikke knytter sig til en sag", a2.AfdelingsNummer));
            context.Sags.Add(new Sag("Diverse", "Til arbejde, der ikke knytter sig til en sag", a3.AfdelingsNummer));

            //Sager til Afdeling: "Produktion"
            context.Sags.Add(new Sag("Bagning af chokoladesmåkager", "Produktion af en ny batch chokoladesmåkager efter opskrift A42", a1.AfdelingsNummer));
            context.Sags.Add(new Sag("Pakning af vaniljesmåkager", "Pakning af vaniljesmåkager i 500 g æsker klar til distribution", a1.AfdelingsNummer));
            context.Sags.Add(new Sag("Vedligeholdelse af ovn 3", "Planlagt vedligeholdelse og kalibrering af ovn 3 til optimal bagning", a1.AfdelingsNummer));
            context.Sags.Add(new Sag("Produktion af glutenfri småkager", "Testproduktion af en ny glutenfri småkagevariant", a1.AfdelingsNummer));
            context.Sags.Add(new Sag("Overvågning af sukkerlager", "Sikring af korrekt lagerføring og overvågning af sukkerbeholdningen", a1.AfdelingsNummer));

            //Medarbejder
            context.Medarbejders.Add(new Medarbejder("AB", "123456-7890", "Anders Birk", a1.AfdelingsNummer));

            //Tidsregistreringer for m1
            List<Tidsregistrering> tidsregistreringer = new List<Tidsregistrering>
            {
                new Tidsregistrering(new DateTime(2020, 12, 1, 8, 0, 0), new DateTime(2020, 12, 1, 16, 0, 0), "AB", 4),
                new Tidsregistrering(new DateTime(2020, 12, 5, 9, 0, 0), new DateTime(2020, 12, 5, 15, 0, 0), "AB", 5),
                new Tidsregistrering(new DateTime(2020, 12, 15, 10, 0, 0), new DateTime(2020, 12, 15, 14, 0, 0), "AB", 6),

                new Tidsregistrering(new DateTime(2021, 12, 2, 8, 0, 0), new DateTime(2021, 12, 2, 16, 0, 0), "AB", 4),
                new Tidsregistrering(new DateTime(2021, 12, 10, 9, 0, 0), new DateTime(2021, 12, 10, 15, 0, 0), "AB", 7),
                new Tidsregistrering(new DateTime(2021, 12, 20, 10, 0, 0), new DateTime(2021, 12, 20, 14, 0, 0), "AB", 8),

                new Tidsregistrering(new DateTime(2022, 12, 3, 8, 0, 0), new DateTime(2022, 12, 3, 16, 0, 0), "AB", 5),
                new Tidsregistrering(new DateTime(2022, 12, 12, 9, 0, 0), new DateTime(2022, 12, 12, 15, 0, 0), "AB", 6),
                new Tidsregistrering(new DateTime(2022, 12, 22, 10, 0, 0), new DateTime(2022, 12, 22, 14, 0, 0), "AB", 4),

                new Tidsregistrering(new DateTime(2023, 12, 4, 8, 0, 0), new DateTime(2023, 12, 4, 16, 0, 0), "AB", 7),
                new Tidsregistrering(new DateTime(2023, 12, 14, 9, 0, 0), new DateTime(2023, 12, 14, 15, 0, 0), "AB", 8),
                new Tidsregistrering(new DateTime(2023, 12, 24, 10, 0, 0), new DateTime(2023, 12, 24, 14, 0, 0), "AB", 5),

                new Tidsregistrering(new DateTime(2024, 12, 5, 8, 0, 0), new DateTime(2024, 12, 5, 16, 0, 0), "AB", 6),
                new Tidsregistrering(new DateTime(2024, 12, 15, 9, 0, 0), new DateTime(2024, 12, 15, 15, 0, 0), "AB", 4),
                new Tidsregistrering(new DateTime(2024, 12, 25, 10, 0, 0), new DateTime(2024, 12, 25, 14, 0, 0), "AB", 8),
            };
            foreach(Tidsregistrering t in tidsregistreringer)
            {
                context.Tidsregistrerings.Add(t);
            }


            context.SaveChanges();
        }
        private void dummy()
        {
            string result = System.Data.Entity.SqlServer.SqlFunctions.Char(65);
        }
    }
}
