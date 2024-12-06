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
        //Jeg skal bruge afdelingerne direkte fra DB
        public static Model.Afdeling GetAfdeling(int nummer)
        {
            using (FirmaContext context = new FirmaContext())
            {
                return context.Afdelings.Find(nummer);
            }
        }
        public static List<DTO.Model.Afdeling> GetAllAfdelinger()
        {
            using (FirmaContext context = new FirmaContext())
            {
                List<Model.Afdeling> dalAfdelinger = context.Afdelings.Select(a => a).ToList();
                List<DTO.Model.Afdeling> dtoAfdelinger = AfdelingMapper.MapListToDTO(dalAfdelinger);
                return dtoAfdelinger;
            }
        }
    }
}
