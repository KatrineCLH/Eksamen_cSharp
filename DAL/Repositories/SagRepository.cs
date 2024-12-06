using DAL.Context;
using DAL.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class SagRepository
    {
        public static int AddSag(DTO.Model.Sag sag)
        {
            using (FirmaContext context = new FirmaContext())
            {
                if (context.Sags.Find(sag.Nummer) == null)
                {
                    //Model.Afdeling dalAfdeling = context.Afdelings.Find(sag.Afdeling.AfdelingsNummer);
                    Model.Sag dalSag = SagMapper.MapToDAL(sag);
                    dalSag.AfdelingsNummer = sag.Afdeling.AfdelingsNummer;
                    context.Sags.Add(dalSag);
                    context.SaveChanges();
                    return context.Sags.OrderByDescending(s => s.SagsNummer).First().SagsNummer;
                }
                return -1;
            }
        }

        public static List<DTO.Model.Sag> GetAlleSager()
        {
            using (FirmaContext context = new FirmaContext())
            {
                List<DTO.Model.Sag> sager = new List<DTO.Model.Sag>();
                List<Model.Sag> dalSager = context.Sags.ToList();
                foreach (Model.Sag s in dalSager)
                {
                    sager.Add(SagMapper.MapToDTO(s));
                }
                return sager;
            }
        }
        public static DTO.Model.Sag GetSag(int id)
        {
            using (FirmaContext ctx = new FirmaContext())
            {
                Model.Sag dalSag = ctx.Sags.Find(id);
                DTO.Model.Sag dtoSag = SagMapper.MapToDTO(dalSag);
                return dtoSag;
            }
        }
        public static List<DTO.Model.Sag> GetSagerForAfdeling(int id)
        {
            using (FirmaContext context = new FirmaContext())
            {
                List<Model.Sag> dalSager = context.Sags.Where(s => s.AfdelingsNummer == id).ToList();
                return SagMapper.MapToDTOList(dalSager);
            }
        }
        public static void UpdateSag(DTO.Model.Sag sag)
        {
            using (FirmaContext context = new FirmaContext())
            {
                Model.Sag dalSag = context.Sags.Find(sag.Nummer);
                //Model.Afdeling dalAfdeling = context.Afdelings.Find(dalSag.AfdelingsNummer);
                dalSag.AfdelingsNummer = sag.Afdeling.AfdelingsNummer;

                dalSag.Overskrift = sag.Overskrift;
                dalSag.Beskrivelse = sag.Beskrivelse;
                if (dalSag.AfdelingsNummer != sag.Afdeling.AfdelingsNummer)
                {
                    Model.Afdeling nyAfdeling = context.Afdelings.Find(sag.Afdeling.AfdelingsNummer);
                    dalSag.AfdelingsNummer = sag.Afdeling.AfdelingsNummer;
                }

                context.SaveChanges();
            }
        }
    }
}
