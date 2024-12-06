using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    public class MedarbejderMapper
    {
        public static Model.Medarbejder MapToDAL(DTO.Model.Medarbejder medarbejder)
        {
            if (medarbejder != null)
            {
                Model.Afdeling dalAfdeling = AfdelingMapper.MapToDAL(medarbejder.Afdeling);
                Model.Medarbejder dalMedarbejder = new Model.Medarbejder(medarbejder.Initial, medarbejder.Cpr, medarbejder.Navn, dalAfdeling);
                return dalMedarbejder;
            }
            return null;
        }
        public static DTO.Model.Medarbejder MapToDTO(Model.Medarbejder medarbejder)
        {
            if(medarbejder != null)
            {
                DTO.Model.Afdeling dtoAfdeling = AfdelingMapper.MapToDTO(AfdelingRepository.GetAfdeling(medarbejder.AfdelingsNummer));
                DTO.Model.Medarbejder dtoMedarbejder = new DTO.Model.Medarbejder(medarbejder.Initial, medarbejder.Cpr, medarbejder.Navn, dtoAfdeling);
                return dtoMedarbejder;
            }
            return null;
        }
        public static List<DTO.Model.Medarbejder> MapToDTOList(List<Model.Medarbejder> medarbejdere)
        {
            if(medarbejdere != null && medarbejdere.Count > 0)
            {
                List<DTO.Model.Medarbejder> dtoMedarbejdere = new List<DTO.Model.Medarbejder>();
                foreach(Model.Medarbejder m in medarbejdere)
                {
                    dtoMedarbejdere.Add(MapToDTO(m));
                }
                return dtoMedarbejdere;
            }
            return null;
        }
    }
}
