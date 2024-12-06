using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;

namespace DAL.Mappers
{
    public class TidsregistreringMapper
    {
        /// <summary>
        /// Den angivne Tidsregistrering må ikke være null. Den tilknyttede medarbejder og sag skal findes i databasen.
        /// Returnerer den angivne tidsregistrering som DAL-objekt.
        /// </summary>
        public static  Tidsregistrering MapToDAL(DTO.Model.Tidsregistrering t)
        {
            return new Tidsregistrering(t.Start, t.Slut, t.Medarbejder.Initial, t.Sag.Nummer);
        }

        /// <summary>
        /// Den angivne tidsregistrering, medarbejder og sag må ikke være null. 
        /// Medarbejder og sag skal være korrekt.
        /// Den angivne tidsregistrering returneres som DTO-objekt med korrekt sat medarbejder og sag.
        /// </summary>
        public static DTO.Model.Tidsregistrering MapToDTO(Tidsregistrering t, DTO.Model.Medarbejder medarbejder, DTO.Model.Sag sag)
        {
            return new DTO.Model.Tidsregistrering(t.Id, t.Start, t.Slut, medarbejder, sag);
        }
    }
}
