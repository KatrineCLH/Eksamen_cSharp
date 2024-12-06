using DAL.Context;
using DAL.Mappers;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class TidsregistreringRepository
    {
        public static int AddTidsregistrering(DTO.Model.Tidsregistrering t)
        {
            using (FirmaContext context = new FirmaContext())
            {
                //Medarbejder dalMedarbejder = context.Medarbejders.Find(t.Medarbejder.Initial);
                //Sag dalSag = context.Sags.Find(t.Sag.Nummer);
                Tidsregistrering dalTidsregistrering = TidsregistreringMapper.MapToDAL(t);
                dalTidsregistrering.Initial = t.Medarbejder.Initial;
                dalTidsregistrering.SagsNummer = t.Sag.Nummer;
                context.Tidsregistrerings.Add(dalTidsregistrering);
                context.SaveChanges();
                return dalTidsregistrering.Id;
            }
        }
        public static List<DTO.Model.Tidsregistrering> GetAlleTidsregistreringerForID(string initialer)
        {
            using (FirmaContext context = new FirmaContext())
            {   
                //hiv alle medarbejderens tider op fra db
                List<Model.Tidsregistrering> dalTidsregistreringer = context.Tidsregistrerings.Where(t => t.Initial == initialer).OrderBy(x => x.Start).ToList();
                //find den rigtige medarbejder
                Model.Medarbejder dalMedarbejder = context.Medarbejders.Find(initialer);
                //mapperen laver om til dto og tilføjer medarbejder og sag
                List<DTO.Model.Tidsregistrering> dtoTidsregistreringer = TidsregistreringMapper.MapListToDTO(dalTidsregistreringer);

                return dtoTidsregistreringer;
            }
        }
    }
}
