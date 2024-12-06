using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;

namespace DAL.Mappers
{
    public class AfdelingMapper
    {
        /// <summary>
        /// Den angivne afdeling må ikke være null.
        /// Returnerer den angivne DAL-afdeling som DTO-objekt
        /// </summary>
        public static DTO.Model.Afdeling MapToDTO(Afdeling afdeling)
        {
            DTO.Model.Afdeling dtoAfdeling = new DTO.Model.Afdeling(afdeling.AfdelingsNummer, afdeling.Navn);
            return dtoAfdeling;
        }

        /// <summary>
        /// Den angivne liste af afdelinger må ikke være null eller tom.
        /// Returnerer den angivne liste af afdelinger som en liste af DTO-objekter.
        /// </summary>
        public static List<DTO.Model.Afdeling> MapListToDTO(List<Afdeling> afdelinger)
        {
            List<DTO.Model.Afdeling> dtoAfdelingList = new List<DTO.Model.Afdeling>();
            foreach (Afdeling a in afdelinger)
            {
                dtoAfdelingList.Add(MapToDTO(a));
            }
            return dtoAfdelingList;
        }
    }
}
