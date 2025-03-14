namespace ProgettoPoliziaMunicipale.ViewModel
{
    public class VerbaleViewModel
    {
        public int IdVerbale { get; set; }
        public DateOnly DataViolazione { get; set; }
        public string? IndirizzoViolazione { get; set; }
        public string? NominativoAgente { get; set; }
        public DateOnly DataTrascrizioneVerbale { get; set; }
        public decimal Importo { get; set; }
        public int DecurtamentoPunti { get; set; }
        public int IdAnagrafica { get; set; }
        public string? NomeCognomeAnagrafica { get; set; }

        public int IdViolazione { get; set; }
        public string? DescrizioneViolazione { get; set; }
    }


}
