using DAL.Context;
using DAL.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;

namespace DAL.Repositories
{
    public class MedarbejderRepository
    {
        /// <summary>
        /// Den angivne medarbejder må ikke være null.
        /// For succes: Den tilføjede medarbejders initialer (id) returneres - ellers returneres string "fejl" 
        /// </summary>
        public static string AddMedarbejder(DTO.Model.Medarbejder medarbejder)
        {
            using(FirmaContext context = new FirmaContext())
            {
                if (context.Medarbejders.Find(medarbejder.Initial) == null)
                {
                    Model.Medarbejder dalMedarbejder = MedarbejderMapper.MapToDAL(medarbejder);
                    context.Medarbejders.Add(dalMedarbejder);
                    context.SaveChanges();
                    return medarbejder.Initial;
                }
                return "fejl";
            }
        }

        /// <summary> Returnerer en liste med alle de Medarbejdere i Databasen, der kan mappes korrekt om med 
        /// <see cref="MedarbejderMapper.MapToDTO(Medarbejder, Afdeling)"/>, 
        /// som DTO-objekter. Ellers returneres en tom liste.</summary>
        public static List<DTO.Model.Medarbejder> GetAllMedarbejdere()
        {
            using (FirmaContext context = new FirmaContext())
            {
                List<Model.Medarbejder> dalMedarbejdere = context.Medarbejders.ToList();
                List<DTO.Model.Medarbejder> dtoMedarbejdere = new List<DTO.Model.Medarbejder>();
                if (dalMedarbejdere.Count > 0)
                {                   
                    foreach (Model.Medarbejder m in dalMedarbejdere)
                    {
                        Model.Afdeling dalAfdeling = AfdelingRepository.GetAfdeling(m.AfdelingsNummer);
                        if (dalAfdeling != null)
                        {
                            DTO.Model.Medarbejder dtoMedarbejder = MedarbejderMapper.MapToDTO(m, dalAfdeling);
                            dtoMedarbejdere.Add(dtoMedarbejder);
                        }
                    }
                }
                return dtoMedarbejdere;
            }
        }

        /// <summary>
        /// Hvis medarbejderen med de angivne initialer eksisterer i Databasen og dens afdeling ligeså, 
        /// så returnes medarbejderen som DTO-objekt. Ellers returner null.
        /// </summary>
        public static DTO.Model.Medarbejder GetMedarbejder(string initialer)
        {
            using (FirmaContext context = new FirmaContext())
            {
                Model.Medarbejder dalMedarbejder = context.Medarbejders.Find(initialer);
                if (dalMedarbejder != null)
                {
                    Model.Afdeling dalAfdeling = AfdelingRepository.GetAfdeling(dalMedarbejder.AfdelingsNummer);
                    if (dalAfdeling != null)
                    {
                        DTO.Model.Medarbejder dtoMedarbejder = MedarbejderMapper.MapToDTO(dalMedarbejder, dalAfdeling);
                        return dtoMedarbejder;
                    }
                }
                return null;
            }
        }

        /// <summary>
        /// Medarbejder må ikke være null.
        /// Finder den angivne medarbejder i databasen. Hvis den findes, opdateres dens attributter. Ellers sker intet.
        /// </summary>
        public static void UpdateMedarbejder(DTO.Model.Medarbejder medarbejder)
        {
            using (FirmaContext context = new FirmaContext())
            {
                Model.Medarbejder dalMedarbejder = context.Medarbejders.Find(medarbejder.Initial);
                if (dalMedarbejder != null)
                {
                    dalMedarbejder.Navn = medarbejder.Navn;
                    dalMedarbejder.Cpr = medarbejder.Cpr;
                    dalMedarbejder.AfdelingsNummer = medarbejder.Afdeling.AfdelingsNummer;
                    context.SaveChanges();
                }
            }
        }
    }
}
