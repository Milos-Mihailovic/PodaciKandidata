using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KandidatApp.Models
{
   
    public class Prilog
    {
        public int Id { get; set; }
        public int KandidatId { get; set; }
        public string Naziv { get; set; }
        public string Tip { get; set; } // CV, propratno pismo, sertifikat
        public byte[] FileData { get; set; }
        public DateTime LastUpdate { get; set; } = DateTime.Now;

        public Kandidat Kandidat { get; set; }





    }
}
