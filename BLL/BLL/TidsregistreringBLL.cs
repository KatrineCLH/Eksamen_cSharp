using DAL.Repositories;
using DTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BLL
{
    public class TidsregistreringBLL
    {
        public TidsregistreringBLL() { }

        /// <summary>
        /// Den angivne tidsregistrering må ikke være null. Den tilføjes, hvis dens medarbejder og sag findes i databasen.
        /// Hvis den angivne tidsregistrering tilføjes, returneres dens ID. Ellers returneres -1.
        /// </summary>
        public int AddTidsregistrering(Tidsregistrering t) {
            return TidsregistreringRepository.AddTidsregistrering(t);
        }

        /// <summary>
        /// Hvis der findes korrekte tidsregistreringer for en medarbejder med de angivne initialer, 
        /// så returneres de som en liste af DTO-objekter ordnet stigende efter Start-dato. Ellers returneres en tom liste
        /// </summary>
        public List<Tidsregistrering> GetAlleTidsregistreringerForMedarbejder(string intitialer)
        {
            return TidsregistreringRepository.GetAlleTidsregistreringerForMedarbejder(intitialer);
        }
    }
}
