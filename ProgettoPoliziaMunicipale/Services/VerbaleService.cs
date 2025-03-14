using Microsoft.EntityFrameworkCore;
using ProgettoPoliziaMunicipale.Data;
using ProgettoPoliziaMunicipale.ViewModel;


namespace ProgettoPoliziaMunicipale.Services
{
    public class VerbaleService
    {
        private readonly PoliziaMunicipaleDbContext _context;

        public VerbaleService(PoliziaMunicipaleDbContext context)
        {
            _context = context;
        }

        public async Task<List<VerbaleViewModel>> GetAllVerbaliAsync()
        {
            return await _context.Verbales
                .Include(v => v.IdAnagraficaNavigation) 
                .Select(v => new VerbaleViewModel
                {
                    IdVerbale = v.IdVerbale,
                    DataViolazione = v.DataViolazione,
                    IndirizzoViolazione = v.IndirizzoViolazione,
                    NominativoAgente = v.NominativoAgente,
                    DataTrascrizioneVerbale = v.DataTrascrizioneVerbale,
                    Importo = v.Importo,
                    DecurtamentoPunti = v.DecurtamentoPunti,
                    IdAnagrafica = v.IdAnagrafica,
                    NomeCognomeAnagrafica = $"{v.IdAnagraficaNavigation.Cognome} {v.IdAnagraficaNavigation.Nome}"
                })
                .OrderByDescending(v => v.DataViolazione)
                .ToListAsync();
        }

        public async Task<VerbaleViewModel?> GetVerbaleByIdAsync(int id)
        {
            var verbale = await _context.Verbales
                .Include(v => v.IdAnagraficaNavigation) 
                .FirstOrDefaultAsync(v => v.IdVerbale == id);

            if (verbale == null)
                return null;

            return new VerbaleViewModel
            {
                IdVerbale = verbale.IdVerbale,
                DataViolazione = verbale.DataViolazione,
                IndirizzoViolazione = verbale.IndirizzoViolazione,
                NominativoAgente = verbale.NominativoAgente,
                DataTrascrizioneVerbale = verbale.DataTrascrizioneVerbale,
                Importo = verbale.Importo,
                DecurtamentoPunti = verbale.DecurtamentoPunti,
                IdAnagrafica = verbale.IdAnagrafica,
                NomeCognomeAnagrafica = $"{verbale.IdAnagraficaNavigation.Cognome} {verbale.IdAnagraficaNavigation.Nome}"
            };

        }

        public async Task<bool> AddVerbaleAsync(VerbaleViewModel model)
        {
            var verbale = new Models.Verbale
            {
                DataViolazione = model.DataViolazione,
                IndirizzoViolazione = model.IndirizzoViolazione!,
                NominativoAgente = model.NominativoAgente!,
                DataTrascrizioneVerbale = model.DataTrascrizioneVerbale,
                Importo = model.Importo,
                DecurtamentoPunti = model.DecurtamentoPunti,
                IdAnagrafica = model.IdAnagrafica
            };

            _context.Verbales.Add(verbale);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateVerbaleAsync(int id, VerbaleViewModel model)
        {
            var verbale = await _context.Verbales.FindAsync(id);
            if (verbale == null)
                return false;

            // Aggiornamento dei campi
            verbale.DataViolazione = model.DataViolazione;
            verbale.IndirizzoViolazione = model.IndirizzoViolazione!;
            verbale.NominativoAgente = model.NominativoAgente!;
            verbale.DataTrascrizioneVerbale = model.DataTrascrizioneVerbale;
            verbale.Importo = model.Importo;
            verbale.DecurtamentoPunti = model.DecurtamentoPunti;
            verbale.IdAnagrafica = model.IdAnagrafica;

            // Salvataggio modifiche
            _context.Verbales.Update(verbale);
            await _context.SaveChangesAsync();
            return true;
        }


    }
}
