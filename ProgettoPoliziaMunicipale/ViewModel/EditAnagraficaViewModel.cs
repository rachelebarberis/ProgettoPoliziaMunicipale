using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProgettoPoliziaMunicipale.ViewModel
{
    public class EditAnagraficaViewModel
    {
       
            public int IdAnagrafica { get; set; }

            [Required(ErrorMessage = "Il campo è obbligatorio.")]
            [StringLength(100)]
            public string? Cognome { get; set; }

            [Required(ErrorMessage = "Il campo è obbligatorio.")]
            [StringLength(100)]
            public string? Nome { get; set; }

            [Required(ErrorMessage = "Il campo è obbligatorio.")]
            [StringLength(100)]
            public string? Indirizzo { get; set; }

            [Required(ErrorMessage = "Il campo è obbligatorio.")]
            [StringLength(100)]
            public string? Citta { get; set; }

            [Required(ErrorMessage = "Il campo è obbligatorio.")]
            [Range(0, int.MaxValue)]
            public int Cap { get; set; }

            [Required(ErrorMessage = "Il campo è obbligatorio.")]
            [StringLength(16)]
            public string? CodiceFiscale { get; set; }
        }
}
