using Microsoft.AspNetCore.Mvc;
using ProgettoPoliziaMunicipale.Models;
using ProgettoPoliziaMunicipale.Services;

namespace ProgettoPoliziaMunicipale.Controllers
{
    public class TipoViolazioneController : Controller
    {
        private readonly TipoViolazioneService _tipoViolazioneService;

        public TipoViolazioneController(TipoViolazioneService tipoViolazioneService)
        {
            _tipoViolazioneService = tipoViolazioneService;
        }
        public async Task<IActionResult> IndexAsync()
        {
            var tipoViolazione = await _tipoViolazioneService.GetAllTipiViolazioneAsync();
            return View(tipoViolazione);
            
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(TipoViolazione model)
        {
            if (ModelState.IsValid)
            {
                await _tipoViolazioneService.AddTipoViolazioneAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var tV = await _tipoViolazioneService.GetTipoViolazioneByIdAsync(id);
            if (tV == null)
            {
                return NotFound();
            }
            return View(tV);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TipoViolazione model)
        {
            if (ModelState.IsValid)
            {
                await _tipoViolazioneService.EditTipoViolazioneAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

      

    }
}



