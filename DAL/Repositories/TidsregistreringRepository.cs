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
        /// <summary>
        /// Den angivne tidsregistrering må ikke være null.
        /// Hvis den angivne tidsregistrerings medarbejder og sag findes i databasen og tilføjes korrekt, 
        /// returneres tidsregistreringens ID. Ellers returneres -1.
        /// </summary>
        public static int AddTidsregistrering(DTO.Model.Tidsregistrering t)
        {
            using (FirmaContext context = new FirmaContext())
            {
                DTO.Model.Medarbejder dtoMedarbejder = MedarbejderRepository.GetMedarbejder(t.Medarbejder.Initial);
                DTO.Model.Sag dtoSag = SagRepository.GetSag(t.Sag.Nummer);
                if (dtoMedarbejder != null && dtoSag != null)
                {
                    Tidsregistrering dalTidsregistrering = TidsregistreringMapper.MapToDAL(t);
                    context.Tidsregistrerings.Add(dalTidsregistrering);
                    context.SaveChanges();
                    return dalTidsregistrering.Id;
                }
                return -1;
            }
        }

        /// <summary>
        /// Hvis der findes korrekte tidsregistreringer for medarbejderen med de angivne initialer, 
        /// så returneres en liste af dem som DTO-objekter 
        /// ordnet stigende efter Start-dato. Ellers returneres en tom liste.
        /// </summary>
        public static List<DTO.Model.Tidsregistrering> GetAlleTidsregistreringerForMedarbejder(string initialer)
        {
            using (FirmaContext context = new FirmaContext())
            {
                List<DTO.Model.Tidsregistrering> dtoTidsregistreringer = new List<DTO.Model.Tidsregistrering>();
                DTO.Model.Medarbejder dtoMedarbjeder = MedarbejderRepository.GetMedarbejder(initialer);
                if (dtoMedarbjeder != null)
                {
                    List<Model.Tidsregistrering> dalTidsregistreringer = context.Tidsregistrerings.Where(t => t.MedarbejderInitial == initialer).OrderBy(x => x.Start).ToList();                   
                    if (dalTidsregistreringer.Count > 0)
                    {
                        foreach (Model.Tidsregistrering tr in dalTidsregistreringer)
                        {
                            DTO.Model.Sag dtoSag = SagRepository.GetSag(tr.SagsNummer);
                            if (dtoSag != null)
                            {
                                DTO.Model.Tidsregistrering dtoTidsregistrering = TidsregistreringMapper.MapToDTO(tr, dtoMedarbjeder, dtoSag);
                                dtoTidsregistreringer.Add(dtoTidsregistrering);
                            }
                        }
                    }
                }
                return dtoTidsregistreringer;
            }
        }
    }
}
