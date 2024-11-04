
using KandidatApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public class Kandidat
{
    public int Id { get; set; } // Identifikator

    [Required]
    [MaxLength(100)]
    public string Ime { get; set; } // Ime (obavezno)

    [Required]
    [MaxLength(100)]
    public string Prezime { get; set; } // Prezime (obavezno)

    [Required]
    [MaxLength(13)]
    public string JMBG { get; set; } // JMBG (obavezno)

    [Required]
    public DateTime DatumRodjenja { get; set; } // Datum roðenja (obavezno)

    [Required]
    [EmailAddress]
    [MaxLength(255)]
    public string Email { get; set; } // Email (obavezno)

    [MaxLength(255)]
    public string DodatniLinkovi { get; set; } // Dodatni linkovi

    [MaxLength(15)]
    public string Telefon { get; set; } // Telefon

    public string Napomena { get; set; } // Napomena

    public DateTime LastUpdate { get; set; } // Datum i vreme izmene podataka

    public byte[] Slika { get; set; } // Slika (konvertovana u bajt niz)

    [Range(1, 5)]
    public int Ocena { get; set; } // Ocena (1-5)

    public StatusKandidata Status { get; set; } // Status kandidata u konkursu

    public ICollection<Prilog> Prilozi { get; set; } // Lista priloga

    public ICollection<IstorijaPromenaStatusa> StatusIstorija { get; set; } // Istorija promena statusa
    //public int Id { get; set; }

    //[Required]
    //public string Ime { get; set; }

    //[Required]
    //public string Prezime { get; set; }

    //[Required]
    //public string JMBG { get; set; }

    //[Required]
    //public DateTime DatumRodjenja { get; set; }

    //[Required]
    //[EmailAddress]
    //public string Email { get; set; }

    //public string DodatniLinkovi { get; set; }
    //public string Telefon { get; set; }
    //public string Napomena { get; set; }

    //public DateTime LastUpdate { get; set; } = DateTime.Now;
    //public byte[]? Slika { get; set; }

    //public int Ocena { get; set; } = 0; // Default value

    //public StatusKandidata Status { get; set; }

    //public ICollection<Prilog>? Prilozi { get; set; }
    //public ICollection<IstorijaPromenaStatusa>? StatusIstorija { get; set; }

}
//public int Id { get; set; }
//public string Ime { get; set; }
//public string Prezime { get; set; }
//public string JMBG { get; set; }
//public DateTime DatumRodjenja { get; set; }
//public string Email { get; set; }
//public string DodatniLinkovi { get; set; }
//public string Telefon { get; set; }
//public string Napomena { get; set; }
//public DateTime LastUpdate { get; set; }
//public List<Prilog> Prilozi { get; set; }
//public int Ocena { get; set; }
//public StatusKandidata Status { get; set; }
//public List<IstorijaPromenaStatusa> IstorijaStatusa { get; set; }


