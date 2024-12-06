using DAL.Context;
using DAL.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class AfdelingRepository
    {
        /// <summary>
        /// Hvis der findes en afdeling i Databasen med det angivne nummer, returneres den som DAL-objekt. Ellers returneres null.
        /// </summary>
        public static Model.Afdeling GetAfdeling(int afdelingsNummer)
        {
            using (FirmaContext context = new FirmaContext())
            {
                Model.Afdeling afdeling = context.Afdelings.Find(afdelingsNummer);
                if (afdeling != null) 
                {
                    return afdeling;
                }
                return null;
            }
        }

        /// <summary>
        /// Returnerer alle afdelinger i Databasen, transformeret til DTO-objekter. Hvis der ingen er, returneres null
        /// </summary>
        public static List<DTO.Model.Afdeling> GetAllAfdelinger()
        {
            using (FirmaContext context = new FirmaContext())
            {
                List<Model.Afdeling> dalAfdelinger = context.Afdelings.ToList();
                if (dalAfdelinger.Count > 0)
                {
                    List<DTO.Model.Afdeling> dtoAfdelinger = AfdelingMapper.MapListToDTO(dalAfdelinger);
                    return dtoAfdelinger;
                }
                return null;
            }
        }
    }
}
