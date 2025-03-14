using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgettoPoliziaMunicipale.Data;
using ProgettoPoliziaMunicipale.Services;
using ProgettoPoliziaMunicipale.ViewModel;

namespace ProgettoPoliziaMunicipale.Controllers
{
    public class VerbaleController : Controller
    {
        private readonly VerbaleService _verbaleService;
        private readonly PoliziaMunicipaleDbContext _context;

        public VerbaleController(VerbaleService verbaleService, PoliziaMunicipaleDbContext context)
        {
            _verbaleService = verbaleService;
            _context = context;
        }

        // GET: Visualizza tutti i verbali
        public async Task<IActionResult> Index()
        {
            var verbali = await _verbaleService.GetAllVerbaliAsync();
            return View(verbali);
        }

        // GET: Visualizza il dettaglio di un verbale
        public async Task<IActionResult> Details(int id)
        {
            var verbale = await _verbaleService.GetVerbaleByIdAsync(id);
            if (verbale == null)
            {
                return NotFound();
            }
            return View(verbale);
        }

        // Metodo per caricare le ViewBag con le persone e le violazioni
        private async Task CaricaDatiViewBag()
        {
            ViewBag.Anagrafiche = await _context.Anagraficas
                .Select(a => new { a.IdAnagrafica, NomeCompleto = a.Cognome + " " + a.Nome })
                .ToListAsync();

            ViewBag.Violazioni = await _context.TipoViolaziones
                .Select(v => new { v.IdViolazione, v.Descrizione })
                .ToListAsync();
        }

        // GET: Mostra la vista per aggiungere un nuovo verbale
        public async Task<IActionResult> Add()
        {
            await CaricaDatiViewBag();
            return View();
        }

        // POST: Aggiunge un nuovo verbale
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(VerbaleViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _verbaleService.AddVerbaleAsync(model);
                return RedirectToAction("Index");
            }

            await CaricaDatiViewBag();
            return View(model);
        }

        // GET: Mostra la vista per modificare un verbale esistente
        public async Task<IActionResult> Edit(int id)
        {
            var verbale = await _verbaleService.GetVerbaleByIdAsync(id);
            if (verbale == null)
            {
                return NotFound();
            }

            await CaricaDatiViewBag();
            return View(verbale);
        }

        // POST: Modifica un verbale esistente
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, VerbaleViewModel model)
        {
            if (!ModelState.IsValid)
            {
                await CaricaDatiViewBag();
                return View(model);
            }

            var result = await _verbaleService.UpdateVerbaleAsync(id, model);
            if (!result)
            {
                return NotFound();
            }

            return RedirectToAction("Index");
        }
    }
}
