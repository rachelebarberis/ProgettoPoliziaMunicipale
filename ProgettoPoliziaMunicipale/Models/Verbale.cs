using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProgettoPoliziaMunicipale.Models;

[Table("Verbale")]
public partial class Verbale
{
    [Key]
    public int IdVerbale { get; set; }

    public DateOnly DataViolazione { get; set; }

    [StringLength(100)]
    public string IndirizzoViolazione { get; set; } = null!;

    [StringLength(100)]
    public string NominativoAgente { get; set; } = null!;

    public DateOnly DataTrascrizioneVerbale { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Importo { get; set; }

    public int DecurtamentoPunti { get; set; }

    public int IdAnagrafica { get; set; }

    [ForeignKey("IdAnagrafica")]
    [InverseProperty("Verbales")]
    public virtual Anagrafica IdAnagraficaNavigation { get; set; } = null!;

    [ForeignKey("IdVerbale")]
    [InverseProperty("IdVerbales")]
    public virtual ICollection<TipoViolazione> IdViolaziones { get; set; } = new List<TipoViolazione>();
}
