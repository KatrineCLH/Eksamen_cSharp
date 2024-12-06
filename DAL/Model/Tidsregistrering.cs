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
        [ForeignKey("Initial")]
        public string Initial { get; set; }
        [ForeignKey("Nummer")]
        public int SagsNummer { get; set; }
        public Tidsregistrering() { }
        public Tidsregistrering(int id, DateTime start, DateTime slut, string initial, int nummer)
        {
            Id = id;
            Start = start;
            Slut = slut;
            Initial = initial;
            SagsNummer = nummer;
        }
    }
}
