using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Medarbejder
    {
        [Key]
        public string Initial {  get; set; }
        public string Cpr { get; set; }
        public string Navn { get; set; }
        [ForeignKey("AfdelingsNummer")]
        public int AfdelingsNummer { get; set; }
        public Medarbejder() { }
        public Medarbejder(string initial, string cpr, string navn, int afdelingsNummer)
        {
            Initial = initial;
            Cpr = cpr;
            Navn = navn;
            AfdelingsNummer = afdelingsNummer;
        }
    }
}
