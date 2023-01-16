using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Magazin_Cosmetice.Models
{
    public class Client
    {
        public int ID { get; set; }
        public string? Nume { get; set; }
        public string? Prenume { get; set; }
        public string? Adresa { get; set; }
        public string Email { get; set; }
        public string? NumarTelefon { get; set; }
        [Display(Name = "Nume Client")]
        public string? NumeClient
        {
            get
            {
                return Nume + " " + Prenume;
            }
        }
        public ICollection<Cumparare>? Cumparaturi { get; set; }
    }
}
