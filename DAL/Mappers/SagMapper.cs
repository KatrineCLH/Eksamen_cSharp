using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    public class SagMapper
    {
        public static Model.Sag MapToDAL(DTO.Model.Sag sag)
        {
            if (sag != null)
            {
                //Model.Afdeling dalAfdeling = AfdelingMapper.MapToDAL(sag.Afdeling);
                Model.Sag dalSag = new Model.Sag(sag.Nummer, sag.Overskrift, sag.Beskrivelse, sag.Afdeling.AfdelingsNummer);
                return dalSag;
            }
            return null;
        }
        public static DTO.Model.Sag MapToDTO(Model.Sag sag)
        {
            if (sag != null)
            {
                DTO.Model.Afdeling dtoAfdeling = AfdelingMapper.MapToDTO(AfdelingRepository.GetAfdeling(sag.AfdelingsNummer));
                DTO.Model.Sag dtoSag = new DTO.Model.Sag(sag.SagsNummer, sag.Overskrift, sag.Beskrivelse, dtoAfdeling);
                return dtoSag;
            }
            return null;
        }
        public static List<DTO.Model.Sag> MapToDTOList(List<Model.Sag> sager)
        {
            if (sager != null && sager.Count > 0)
            {
                List<DTO.Model.Sag> dtoSager = new List<DTO.Model.Sag>();
                foreach (Model.Sag s in sager)
                {
                    dtoSager.Add(MapToDTO(s));
                }
                return dtoSager;
            }
            return null;
        }
    }
}
