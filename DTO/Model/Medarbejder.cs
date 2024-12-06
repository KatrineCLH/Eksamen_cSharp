using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Model
{
    public class Medarbejder
    {
        public string Initial { get; set; }
        public string Cpr { get; set; }
        public string Navn { get; set; }
        public Afdeling Afdeling { get; set; }
        public Medarbejder() { }
        public Medarbejder(string initial, string cpr, string navn, Afdeling afdeling)
        {
            Initial = initial.ToUpper();
            Cpr = cpr;
            Navn = navn;
            Afdeling = afdeling;
        }
        public override string ToString()
        {
            return String.Format("{0}: {1} ({2})", Initial, Navn, Afdeling.Navn);
        }
    }
}
