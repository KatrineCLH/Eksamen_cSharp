using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;
using DTO.Model;

namespace DAL.Mappers
{
    public class AfdelingMapper
    {
        public static DTO.Model.Afdeling MapToDTO(Model.Afdeling afdeling)
        {
            if (afdeling != null)
            {
                DTO.Model.Afdeling dtoAfdeling = new DTO.Model.Afdeling(afdeling.AfdelingsNummer, afdeling.Navn);
                return dtoAfdeling;
            }
            return null;
        }
        public static Model.Afdeling MapToDAL(DTO.Model.Afdeling afdeling)
        {
            if (afdeling != null)
            {
                Model.Afdeling dalAfdeling = new Model.Afdeling(afdeling.AfdelingsNummer, afdeling.Navn);
                return dalAfdeling;
            }
            return null;
        }
        public static List<DTO.Model.Afdeling> MapListToDTO(List<Model.Afdeling> afdelinger)
        {
            if (afdelinger.Count > 0) {
                List<DTO.Model.Afdeling> dtoAfdelingList = new List<DTO.Model.Afdeling>();
                foreach (Model.Afdeling a in afdelinger)
                {
                    dtoAfdelingList.Add(MapToDTO(a));
                }
                return dtoAfdelingList;
            }
            return null;
        }
    }
}
