using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Model;
using DAL;
using DAL.Repositories;

namespace BLL.BLL
{
    public class SagBLL
    {
        public SagBLL() { }
        public int AddSag(Sag sag)
        {
            return SagRepository.AddSag(sag);
        }
        public List<DTO.Model.Sag> GetAlleSager()
        {
            return SagRepository.GetAlleSager();
        }
        public Sag GetSag(int id)
        {
            return SagRepository.GetSag(id);
        }
        public List<Sag> GetSagerForAfdeling(int id)
        {
            return SagRepository.GetSagerForAfdeling(id);
        }
        public void UpdateSag(Sag sag)
        {
            SagRepository.UpdateSag(sag);
        }
    }
}
