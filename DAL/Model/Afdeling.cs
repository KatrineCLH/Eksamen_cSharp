using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Afdeling
    {
        [Key]
        public int AfdelingsNummer { get; set; }
        public string Navn { get; set; }
        public Afdeling() { }
        public Afdeling(int nummer, string navn)
        {
            AfdelingsNummer = nummer;
            Navn = navn;
        }
    }
}
