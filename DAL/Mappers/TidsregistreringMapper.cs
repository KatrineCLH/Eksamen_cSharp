﻿using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    public class TidsregistreringMapper
    {
        public static Model.Tidsregistrering MapToDAL(DTO.Model.Tidsregistrering t)
        {
            //Model.Medarbejder dalMedarbejder = MedarbejderMapper.MapToDAL(t.Medarbejder);
            //Model.Sag dalSag = SagMapper.MapToDAL(t.Sag);
            return new Model.Tidsregistrering(t.Id, t.Start, t.Slut, t.Medarbejder.Initial, t.Sag.Nummer);
        }
        public static List<DTO.Model.Tidsregistrering> MapListToDTO(List<Model.Tidsregistrering> tidsregistreringer)
        {
            if(tidsregistreringer != null && tidsregistreringer.Count > 0)
            {
                List<DTO.Model.Tidsregistrering> dtoTidsregistreringer = new List<DTO.Model.Tidsregistrering>();
                foreach(Model.Tidsregistrering t in tidsregistreringer){
                    dtoTidsregistreringer.Add(MapToDTO(t));
                }
                return dtoTidsregistreringer;
            }
            return null;
        }
        public static DTO.Model.Tidsregistrering MapToDTO(Model.Tidsregistrering t)
        {
            DTO.Model.Medarbejder dtoMedarbejder = MedarbejderRepository.GetMedarbejder(t.Initial);
            DTO.Model.Sag dtoSag = SagRepository.GetSag(t.SagsNummer);
            return new DTO.Model.Tidsregistrering(t.Id, t.Start, t.Slut, dtoMedarbejder, dtoSag);
        }
    }
}
