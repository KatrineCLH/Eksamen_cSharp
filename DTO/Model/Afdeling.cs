using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Model
{
    public class Afdeling
    {
        public int AfdelingsNummer { get; set; }
        public string Navn { get; set; }
        public Afdeling() { }
        public Afdeling(int nummer, string navn)
        {
            AfdelingsNummer = nummer;
            Navn = navn;
        }
        public override string ToString()
        {
            return AfdelingsNummer + " " + Navn;
        }
    }
}
