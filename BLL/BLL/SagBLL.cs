using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Model;
using DAL;
using DAL.Repositories;

namespace BLL.BLL
{
    public class SagBLL
    {
        public SagBLL() { }

        /// <summary>
        /// Sag må ikke være null.
        /// Hvis succes, returneres nummeret på den sag, der blev tilføjet. Ellers returneres -1
        /// </summary>
        public int AddSag(Sag sag)
        {
            return SagRepository.AddSag(sag);
        }

        /// <summary>
        /// Returnerer en liste af alle korrekte sager i databasen som DTO-objekter. Ellers returneres en tom liste
        /// </summary>
        public List<DTO.Model.Sag> GetAlleSager()
        {
            return SagRepository.GetAlleSager();
        }

        /// <summary>
        /// Hvis der findes en sag med det angivne sagsNummer i Databasen, returneres den som DTO-objekt. Ellers returneres null
        /// </summary>
        public Sag GetSag(int sagsNummer)
        {
            return SagRepository.GetSag(sagsNummer);
        }

        /// <summary>
        /// Hvis der findes sager på afdelingen med det angivne afdelingsnummer, 
        /// så returneres de som en liste af DTO-objekter. Ellers returneres null.
        /// </summary>
        public List<Sag> GetSagerForAfdeling(int afdelingsNummer)
        {
            return SagRepository.GetSagerForAfdeling(afdelingsNummer);
        }

        /// <summary>
        /// Hvis den angivne sag eksisterer i Databasen, opdateres den. Ellers intet.
        /// </summary>
        public void UpdateSag(Sag sag)
        {
            SagRepository.UpdateSag(sag);
        }
    }
}
