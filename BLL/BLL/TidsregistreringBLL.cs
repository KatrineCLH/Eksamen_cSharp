using DAL.Repositories;
using DTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BLL
{
    public class TidsregistreringBLL
    {
        public TidsregistreringBLL() { }
        public int AddTidsregistrering(Tidsregistrering t) {
            return TidsregistreringRepository.AddTidsregistrering(t);
        }
        public List<DTO.Model.Tidsregistrering> GetAlleTidsregistreringerForID(string intitialer)
        {
            return TidsregistreringRepository.GetAlleTidsregistreringerForID(intitialer);
        }
    }
}
