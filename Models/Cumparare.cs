using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace Magazin_Cosmetice.Models
{
    public class Cumparare
    {
        public int ID { get; set; }
        public int? ClientID { get; set; }
        public Client? Client { get; set; }
        public int? ProdusID { get; set; }
        public Produs? Produs { get; set; }
       
    }
}
