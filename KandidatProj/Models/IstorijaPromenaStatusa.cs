using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KandidatApp.Models
{
   
    public class IstorijaPromenaStatusa
    {
        public int Id { get; set; }
        public int KandidatId { get; set; }
        public string Status { get; set; } // Status kandidata u konkursu
        public DateTime LastUpdate { get; set; } = DateTime.Now;

        public Kandidat Kandidat { get; set; }
    }

}
