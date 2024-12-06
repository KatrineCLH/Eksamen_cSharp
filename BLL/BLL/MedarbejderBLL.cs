using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Model;
using DAL.Repositories;

namespace BLL.BLL
{
    public class MedarbejderBLL
    {
        public MedarbejderBLL() { }

        /// <summary>
        /// Den angivne medarbejder må ikke være null.
        /// Hvis medarbejderen tilføjes til databasen, så returneres medarbejderens initialer. Ellers returneres "fejl".
        /// </summary>
        public string AddMedarbejder(Medarbejder medarbejder)
        {
            return MedarbejderRepository.AddMedarbejder(medarbejder);
        }

        /// <summary>
        /// Returnerer alle korrekte Medarbejdere i databasen. Hvis der ikke er nogen, returneres en tom liste.
        /// </summary>
        public List<Medarbejder> GetAllMedarbejdere()
        {
            return MedarbejderRepository.GetAllMedarbejdere();
        }

        /// <summary>
        /// Hvis der findes en korrekt medarbejder med de angivne initialer i Databasen,
        /// returneres den som DTO-objekt. Ellers returneres null.
        /// </summary>
        public Medarbejder GetMedarbejder(string initialer)
        {
            return MedarbejderRepository.GetMedarbejder(initialer);
        }

        /// <summary>
        /// Medarbejder må ikke være null. Hvis den angivne medarbejder findes i databasen, opdateres den. Ellers intet.
        /// </summary>
        public void UpdateMedarbejder(Medarbejder medarbejder)
        {
            MedarbejderRepository.UpdateMedarbejder(medarbejder);
        }
    }
}
