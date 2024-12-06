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
        /// <summary>
        /// Sag må ikke være null.
        /// Returnerer den angivne DTO-sag som DAL-sag.
        /// </summary>
        public static Model.Sag MapToDAL(DTO.Model.Sag sag)
        {
            Model.Sag dalSag = new Model.Sag(sag.Overskrift, sag.Beskrivelse, sag.Afdeling.AfdelingsNummer);
            return dalSag;
        }

        /// <summary>
        /// Sag må ikke være null. Afdeling må ikke være null og skal være korrekt.
        /// Den angivne sag returneres som DTO-objekt.
        /// </summary>
        public static DTO.Model.Sag MapToDTO(Model.Sag sag, Model.Afdeling afdeling)
        {
            DTO.Model.Afdeling dtoAfdeling = AfdelingMapper.MapToDTO(afdeling);
            DTO.Model.Sag dtoSag = new DTO.Model.Sag(sag.Nummer, sag.Overskrift, sag.Beskrivelse, dtoAfdeling);
            return dtoSag;
        }

        /// <summary>
        /// Den angivne liste af sager må ikke være null eller tom. 
        /// Sagerne skal have den samme afdeling. 
        /// Afdeling må ikke være null og skal være korrekt.
        /// Returnerer alle sagerne som en liste af DTO-sager.
        /// </summary>
        public static List<DTO.Model.Sag> MapToDTOList(List<Model.Sag> sager, Model.Afdeling afdeling)
        {
            List<DTO.Model.Sag> dtoSager = new List<DTO.Model.Sag>();
            foreach (Model.Sag s in sager)
            {
                DTO.Model.Sag dtoSag = MapToDTO(s, afdeling);
                dtoSager.Add(dtoSag);
            }
            return dtoSager;
        }
    }
}
