using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Model;
using DAL.Repositories;

namespace BLL.BLL
{
    public class MedarbejderBLL
    {
        public MedarbejderBLL() { }
        public string AddMedarbejder(Medarbejder medarbejder)
        {
            return MedarbejderRepository.AddMedarbejder(medarbejder);
        }
        public List<Medarbejder> GetAllMedarbejdere()
        {
            return MedarbejderRepository.GetAllMedarbejdere();
        }
        public Medarbejder GetMedarbejder(string initialer)
        {
            return MedarbejderRepository.GetMedarbejder(initialer);
        }
        public void UpdateMedarbejder(Medarbejder medarbejder)
        {
            MedarbejderRepository.UpdateMedarbejder(medarbejder);
        }
    }
}
