using DAL.Context;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Mappers;
using System.Data.Entity.Migrations;

namespace DAL.Repositories
{
    public class MedarbejderRepository
    {
        public static string AddMedarbejder(DTO.Model.Medarbejder medarbejder)
        {
            using(FirmaContext context = new FirmaContext())
            {
                if (context.Medarbejders.Find(medarbejder.Initial) == null)
                {
                    Model.Afdeling dalAfdeling = context.Afdelings.Find(medarbejder.Afdeling.AfdelingsNummer);
                    Model.Medarbejder dalMedarbejder = MedarbejderMapper.MapToDAL(medarbejder);
                    dalMedarbejder.Afdeling = dalAfdeling;
                    context.Medarbejders.Add(dalMedarbejder);
                    context.SaveChanges();
                    return medarbejder.Initial;
                }
                return "fejl";
            }
        }
        public static List<DTO.Model.Medarbejder> GetAllMedarbejdere()
        {
            using (FirmaContext context = new FirmaContext())
            {
                List<DTO.Model.Medarbejder> dtoMedarbejdere = MedarbejderMapper.MapToDTOList(context.Medarbejders.ToList());
                return dtoMedarbejdere;
            }
        }
        public static DTO.Model.Medarbejder GetMedarbejder(string initialer)
        {
            using (FirmaContext context = new FirmaContext())
            {
                DTO.Model.Medarbejder dtoMedarbejder = MedarbejderMapper.MapToDTO(context.Medarbejders.Find(initialer));
                return dtoMedarbejder;
            }
        }
        public static void UpdateMedarbejder(DTO.Model.Medarbejder medarbejder)
        {
            using (FirmaContext context = new FirmaContext())
            {
                Model.Medarbejder dalMedarbejder = context.Medarbejders.Find(medarbejder.Initial);
                Model.Afdeling dalAfdeling = context.Afdelings.Find(dalMedarbejder.AfdelingsNummer);
                dalMedarbejder.Afdeling = dalAfdeling;

                dalMedarbejder.Navn = medarbejder.Navn;
                dalMedarbejder.Cpr = medarbejder.Cpr;
                if (dalAfdeling.AfdelingsNummer != medarbejder.Afdeling.AfdelingsNummer)
                {
                    Model.Afdeling nyAfdeling = context.Afdelings.Find(medarbejder.Afdeling.AfdelingsNummer);
                    dalMedarbejder.Afdeling = nyAfdeling;
                }


                context.SaveChanges();
            }
        }
    }
}
