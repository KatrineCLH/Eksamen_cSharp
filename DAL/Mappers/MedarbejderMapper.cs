using DAL.Repositories;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    public class MedarbejderMapper
    {
        /// <summary>
        /// Medarbejder må ikke være null.
        /// Returnerer den angivne medarbejder som DAL-objekt.
        /// </summary>
        public static Medarbejder MapToDAL(DTO.Model.Medarbejder medarbejder)
        {
            Medarbejder dalMedarbejder = new Medarbejder(medarbejder.Initial, medarbejder.Cpr, medarbejder.Navn, medarbejder.Afdeling.AfdelingsNummer);
            return dalMedarbejder;
        }

        /// <summary>
        /// En medarbejder må ikke være null. Afdeling må ikke være null og skal være korrekt.
        /// Returnerer den angivne medarbejders returneres som DTO-objekt.
        /// </summary>
        public static DTO.Model.Medarbejder MapToDTO(Medarbejder medarbejder, Afdeling afdeling)
        {
            DTO.Model.Afdeling dtoAfdeling = AfdelingMapper.MapToDTO(afdeling);
            DTO.Model.Medarbejder dtoMedarbejder = new DTO.Model.Medarbejder(medarbejder.Initial, medarbejder.Cpr, medarbejder.Navn, dtoAfdeling);
            return dtoMedarbejder;
        }
    }
}
