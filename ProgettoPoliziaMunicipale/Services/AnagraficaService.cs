
using ProgettoPoliziaMunicipale.Data;
using ProgettoPoliziaMunicipale.Models;
using ProgettoPoliziaMunicipale.ViewModel;

using Microsoft.EntityFrameworkCore;

namespace ProgettoPoliziaMunicipale.Services
{
    public class AnagraficaService
    {
        private readonly PoliziaMunicipaleDbContext _context;

        public AnagraficaService(PoliziaMunicipaleDbContext context)
        {
            _context = context;
        }

        public async Task<List<Anagrafica>> GetAllAnagraficheAsync()
        {
            return await _context.Anagraficas
                .Select(a => new Anagrafica
                {
                    IdAnagrafica = a.IdAnagrafica,
                    Cognome = a.Cognome,
                    Nome = a.Nome,
                    Indirizzo = a.Indirizzo,
                    Citta = a.Citta,
                    Cap = a.Cap,
                    CodiceFiscale = a.CodiceFiscale
                })
                .OrderBy(a => a.Cognome)
                .ToListAsync();
        }

        //DA TOGLIERE
        public async Task<Anagrafica> GetAnagraficheByIdAsync(int id)
        {
            var anag = await _context.Anagraficas.FindAsync(id);
            if (anag == null)
                return null;
            return new Anagrafica
            {
                IdAnagrafica = anag.IdAnagrafica,
                Cognome = anag.Cognome,
                Nome = anag.Nome,
                Indirizzo = anag.Indirizzo,
                Citta = anag.Citta,
                Cap = anag.Cap,
                CodiceFiscale = anag.CodiceFiscale
            };
        }
        public async Task AddAnagraficheAsync(AddAnagraficaViewModel model)
        {
            var anag = new Anagrafica
            {
                IdAnagrafica = model.IdAnagrafica,
                Cognome = model.Cognome,
                Nome = model.Nome,
                Indirizzo = model.Indirizzo,
                Citta = model.Citta,
                Cap = model.Cap,
                CodiceFiscale = model.CodiceFiscale
            };
            _context.Anagraficas.Add(anag);
            await _context.SaveChangesAsync();
        }

        public async Task<EditAnagraficaViewModel> EditAnagraficaAsync(EditAnagraficaViewModel model)
        {
            var anag = await _context.Anagraficas.FindAsync(model.IdAnagrafica);

            if (anag == null)
                return null;

            anag.Cognome = model.Cognome;
            anag.Nome = model.Nome;
            anag.Indirizzo = model.Indirizzo;
            anag.Citta = model.Citta;
            anag.Cap = model.Cap;
            anag.CodiceFiscale = model.CodiceFiscale;

            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<bool> DeleteAnagraficaByIdAsync(int id)
        {
            var anag = await _context.Anagraficas.FindAsync(id);
            if (anag == null) { return false; }
            _context.Anagraficas.Remove(anag);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
