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
                Medarbejder dalMedarbejder = context.Medarbejders.Find(t.Medarbejder.Initial);
                Sag dalSag = context.Sags.Find(t.Sag.Nummer);
                Tidsregistrering dalTidsregistrering = TidsregistreringMapper.MapToDAL(t);
                dalTidsregistrering.Medarbejder = dalMedarbejder;
                dalTidsregistrering.Sag = dalSag;
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
                List<Model.Tidsregistrering> dalTidsregistreringer = context.Tidsregistrerings.Where(t => t.MedarbejderInitial == initialer).OrderBy(x => x.Start).ToList();
                //find den rigtige medarbejder
                Model.Medarbejder dalMedarbejder = context.Medarbejders.Find(initialer);
                //knyt alle de rigtige sager og den rigtige medarbejder på
                foreach (Model.Tidsregistrering t in dalTidsregistreringer)
                {
                    Model.Sag dalSag = context.Sags.Find(t.SagsNummer);
                    t.Sag = dalSag;
                    t.Medarbejder = dalMedarbejder;
                }
                
                List<DTO.Model.Tidsregistrering> dtoTidsregistreringer = TidsregistreringMapper.MapListToDTO(dalTidsregistreringer);

                return dtoTidsregistreringer;
            }
        }
    }
}
