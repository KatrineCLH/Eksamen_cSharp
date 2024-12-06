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
        [ForeignKey("Afdeling")]
        public int AfdelingsNummer {  get; set; }
        public Afdeling Afdeling { get; set; }
        public Medarbejder() { }
        public Medarbejder(string initial, string cpr, string navn, Afdeling afdeling)
        {
            Initial = initial;
            Cpr = cpr;
            Navn = navn;
            Afdeling = afdeling;
        }
    }
}
