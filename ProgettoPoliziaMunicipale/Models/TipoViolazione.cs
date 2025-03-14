using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProgettoPoliziaMunicipale.Models;

[Table("Tipo_Violazione")]
public partial class TipoViolazione
{
    [Key]
    public int IdViolazione { get; set; }

    [StringLength(1000)]
    public string Descrizione { get; set; } = null!;

    [ForeignKey("IdViolazione")]
    [InverseProperty("IdViolaziones")]
    public virtual ICollection<Verbale> IdVerbales { get; set; } = new List<Verbale>();
}
