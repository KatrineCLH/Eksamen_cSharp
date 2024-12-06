using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Sag
    {
        [Key]
        public int Nummer {  get; set; }
        public string Overskrift { get; set; }
        public string Beskrivelse { get; set; }
        [ForeignKey("Afdeling")]
        public int AfdelingsNummer { get; set; }
        public Afdeling Afdeling { get; set; }
        public Sag() { }
        public Sag(string overskrift, string beskrivelse, int afdelingsNummer)
        {
            Overskrift = overskrift;
            Beskrivelse = beskrivelse;
            AfdelingsNummer = afdelingsNummer;
        }
    }
}
