namespace ProgettoPoliziaMunicipale.ViewModel
{
    public class ViolGraviViewModel
    {
        public int IdVerbale { get; set; }
        public string Cognome { get; set; } = null!;
        public string Nome { get; set; } = null!;
        public DateOnly DataViolazione { get; set; }
        public decimal Importo { get; set; }
        public int DecurtamentoPunti { get; set; }
    }
}
