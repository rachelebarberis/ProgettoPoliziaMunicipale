using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProgettoPoliziaMunicipale.Models;

[Table("Anagrafica")]
[Index("CodiceFiscale", Name = "UQ__Anagrafi__86E1BBF78C74A4C3", IsUnique = true)]
public partial class Anagrafica
{
    [Key]
    public int IdAnagrafica { get; set; }

    [StringLength(100)]
    public string Cognome { get; set; } = null!;

    [StringLength(100)]
    public string Nome { get; set; } = null!;

    [StringLength(100)]
    public string Indirizzo { get; set; } = null!;

    [StringLength(100)]
    public string Citta { get; set; } = null!;

    [Column("CAP")]
    public int Cap { get; set; }

    [StringLength(16)]
    public string CodiceFiscale { get; set; } = null!;

    [InverseProperty("IdAnagraficaNavigation")]
    public virtual ICollection<Verbale> Verbales { get; set; } = new List<Verbale>();
}
