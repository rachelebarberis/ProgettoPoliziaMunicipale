namespace ProgettoPoliziaMunicipale.ViewModel
{
    public class VerbaliTrasgressoreViewModel
    {
        public string Cognome { get; set; } = null!;
        public string Nome { get; set; } = null!;
        public string CodiceFiscale { get; set; } = null!;
        public int NumeroVerbali { get; set; }
        public decimal ImportoTotale { get; set; }
    }
}
