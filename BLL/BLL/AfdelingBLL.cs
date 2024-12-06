using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Model;
using DAL.Repositories;
using DAL.Mappers;

namespace BLL.BLL
{
    public class AfdelingBLL
    {
        public AfdelingBLL() { }

        /// <summary>Hvis der er afdelinger i Databasen, returneres de som DTO-objekter. Ellers returneres null.</summary>
        public List<Afdeling> GetAllAfdelinger()
        {
            return AfdelingRepository.GetAllAfdelinger();
        }
    }
}
