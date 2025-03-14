using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

 

namespace ProgettoPoliziaMunicipale.ViewModel
    {
        public class AddVerbaleViewModel
        {
            public int IdVerbale { get; set; }

            [Required(ErrorMessage = "Il campo è obbligatoria.")]
            public DateOnly DataViolazione { get; set; }

            [Required(ErrorMessage = "Il campo è obbligatorio.")]
            [StringLength(100)]
            public string IndirizzoViolazione { get; set; } = null!;

            [Required(ErrorMessage = "Il campo è obbligatorio.")]
            [StringLength(100)]
            public string NominativoAgente { get; set; } = null!;

            [Required(ErrorMessage = "Il Campo è obbligatorio.")]
            public DateOnly DataTrascrizioneVerbale { get; set; }

            [Required(ErrorMessage = "Il campo è obbligatorio.")]
            [Range(0, 9999999.99)]
            [Column(TypeName = "decimal(10, 2)")]
            public decimal Importo { get; set; }

            [Required(ErrorMessage = "Il campo è obbligatorio.")]
            [Range(0, 30)]
            public int DecurtamentoPunti { get; set; }

            [Required(ErrorMessage = "Il campo è obbligatorio.")]
            public int IdAnagrafica { get; set; }

            public string? NomeCognomeAnagrafica { get; set; }

            public List<int> IdViolazioni { get; set; } = new List<int>(); 
        }
    }


