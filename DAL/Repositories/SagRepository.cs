using DAL.Context;
using DAL.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class SagRepository
    {
        /// <summary>
        /// Sag må ikke være null.
        /// Tilføjer den angivne sag til Databasen, hvis den ikke allerede eksisterer i Databasen.
        /// Hvis succes, så returneres nummeret på den sag, der er blevet tilføjet. Ellers returneres -1
        /// </summary>
        public static int AddSag(DTO.Model.Sag sag)
        {
            using (FirmaContext context = new FirmaContext())
            {
                if (context.Sags.Find(sag.Nummer) == null)
                {
                    Model.Sag dalSag = SagMapper.MapToDAL(sag);
                    context.Sags.Add(dalSag);
                    context.SaveChanges();
                    return dalSag.Nummer;
                }
                return -1;
            }
        }

        /// <summary>
        /// Returnerer en liste af alle sager i Databasen, der er tilknyttet en afdeling, 
        /// som findes i Databasen, som DTO-objekter. Ellers tom liste.
        /// </summary>
        public static List<DTO.Model.Sag> GetAlleSager()
        {
            using (FirmaContext context = new FirmaContext())
            {
                List<DTO.Model.Sag> sager = new List<DTO.Model.Sag>();
                List<Model.Sag> dalSager = context.Sags.ToList();
                foreach (Model.Sag s in dalSager)
                {
                    Model.Afdeling dalAfdeling = AfdelingRepository.GetAfdeling(s.AfdelingsNummer);
                    if (dalAfdeling != null)
                    {
                        DTO.Model.Sag dtoSag = SagMapper.MapToDTO(s, dalAfdeling);
                        sager.Add(dtoSag);
                    }
                }
                return sager;
            }
        }

        /// <summary>
        /// Hvis sagen med det angivne sagsnummer findes i Databasen, så returner den som DTO-objekt. Ellers returner null
        /// </summary>
        public static DTO.Model.Sag GetSag(int sagsNummer)
        {
            using (FirmaContext ctx = new FirmaContext())
            {
                Model.Sag dalSag = ctx.Sags.Find(sagsNummer);
                if (dalSag != null)
                {
                    Model.Afdeling dalAfdeling = AfdelingRepository.GetAfdeling(dalSag.AfdelingsNummer);
                    DTO.Model.Sag dtoSag = SagMapper.MapToDTO(dalSag, dalAfdeling);
                    return dtoSag;
                }
                return null;
            }
        }

        /// <summary>
        /// Hvis der findes sager på den angivne afdeling, 
        /// så returnes de som en liste af DTO-objekter. Ellers returneres null.
        /// </summary>
        public static List<DTO.Model.Sag> GetSagerForAfdeling(int afdelingsNummer)
        {
            using (FirmaContext context = new FirmaContext())
            {
                List<Model.Sag> dalSager = context.Sags.Where(s => s.AfdelingsNummer == afdelingsNummer).ToList();
                if (dalSager.Count > 0)
                {
                    Model.Afdeling dalAfdeling = AfdelingRepository.GetAfdeling(afdelingsNummer);
                    return SagMapper.MapToDTOList(dalSager, dalAfdeling);
                }
                return null;
            }
        }

        /// <summary>
        /// Hvis den angivne sag findes i databasen, så opdater den med den angivne sags attributter. Ellers ingenting.
        /// </summary>
        public static void UpdateSag(DTO.Model.Sag sag)
        {
            using (FirmaContext context = new FirmaContext())
            {
                Model.Sag dalSag = context.Sags.Find(sag.Nummer);
                if (dalSag != null)
                {
                    dalSag.Overskrift = sag.Overskrift;
                    dalSag.Beskrivelse = sag.Beskrivelse;
                    dalSag.AfdelingsNummer = sag.Afdeling.AfdelingsNummer;
                    context.SaveChanges();
                }
            }
        }
    }
}
