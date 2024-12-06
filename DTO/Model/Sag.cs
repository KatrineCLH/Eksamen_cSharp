using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Model
{
    public class Sag
    {
        public int Nummer { get; set; }
        public string Overskrift { get; set; }
        public string Beskrivelse { get; set; }
        public Afdeling Afdeling { get; set; }
        public Sag() { }
        public Sag(int nummer, string overskrift, string beskrivelse, Afdeling afdeling)
        {
            Nummer = nummer;
            Overskrift = overskrift;
            Beskrivelse = beskrivelse;
            Afdeling = afdeling;
        }
        public Sag(string overskrift, string beskrivelse, Afdeling afdeling)
        {
            Overskrift = overskrift;
            Beskrivelse = beskrivelse;
            Afdeling = afdeling;
        }
        public override string ToString()
        {
            return "#" + Nummer + " " + Overskrift + " (" + Afdeling.Navn + ")";
        }
    }
}
