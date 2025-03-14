using ProgettoPoliziaMunicipale.Models;
using Microsoft.EntityFrameworkCore;
using ProgettoPoliziaMunicipale.Data;


namespace ProgettoPoliziaMunicipale.Services
{
    public class TipoViolazioneService
    {
        private readonly PoliziaMunicipaleDbContext _context;

        public TipoViolazioneService(PoliziaMunicipaleDbContext context)
        {
            _context = context;
        }

        public async Task<List<TipoViolazione>> GetAllTipiViolazioneAsync()
        {
            return await _context.TipoViolaziones
                .Select(t => new TipoViolazione
                {
                    IdViolazione = t.IdViolazione,
                    Descrizione = t.Descrizione
                })
                .OrderBy(t => t.Descrizione)
            .ToListAsync();
        }
        public async Task<TipoViolazione> GetTipoViolazioneByIdAsync(int id)
        {
            var tV = await _context.TipoViolaziones.FindAsync(id);

            if (tV == null)
                return null;

            return new TipoViolazione
            {
                IdViolazione = tV.IdViolazione,
                Descrizione = tV.Descrizione
            };
        }

        public async Task<TipoViolazione> AddTipoViolazioneAsync(TipoViolazione model)
        {
            var tV = new TipoViolazione
            {
                IdViolazione = model.IdViolazione,
                Descrizione = model.Descrizione
            };

            _context.TipoViolaziones.Add(tV);
            await _context.SaveChangesAsync();

            model.IdViolazione = tV.IdViolazione;
            return model;
        }

        public async Task<TipoViolazione> EditTipoViolazioneAsync(TipoViolazione model)
        {
            var tV = await _context.TipoViolaziones.FindAsync(model.IdViolazione);

            if (tV == null)
                return null;

            tV.Descrizione = model.Descrizione;

            await _context.SaveChangesAsync();
            return model;
        }

       
    
    }
}


       