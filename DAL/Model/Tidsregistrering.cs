using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Tidsregistrering
    {
        public int Id { get; set; }
        public DateTime Start {  get; set; }
        public DateTime Slut { get; set; }
        [ForeignKey("Medarbejder")]
        public string MedarbejderInitial { get; set; }
        public Medarbejder Medarbejder { get; set; }
        [ForeignKey("Sag")]
        public int SagsNummer { get; set; }
        public Sag Sag { get; set; }
        public Tidsregistrering() { }
        public Tidsregistrering(DateTime start, DateTime slut, string medarbejderInitial, int sagsNummer)
        {
            Start = start;
            Slut = slut;
            MedarbejderInitial = medarbejderInitial;
            SagsNummer = sagsNummer;
        }
    }
}
