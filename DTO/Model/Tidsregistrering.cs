using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Model
{
    public class Tidsregistrering
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime Slut { get; set; }
        public Medarbejder Medarbejder { get; set; }
        public Sag Sag { get; set; }
        public Tidsregistrering() { }
        public Tidsregistrering(int id, DateTime start, DateTime slut, Medarbejder medarbejder, Sag sag)
        {
            Id = id;
            Start = start;
            Slut = slut;
            Medarbejder = medarbejder;
            Sag = sag;
        }
        public override string ToString()
        {
            return String.Format("{0} kl. {1} - {2} ({3})", Start.ToShortDateString(), Start.ToShortTimeString(), Slut.ToShortTimeString(), Sag.Overskrift);
        }
    }
}
