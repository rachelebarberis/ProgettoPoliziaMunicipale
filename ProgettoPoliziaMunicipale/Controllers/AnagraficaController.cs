using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using ProgettoPoliziaMunicipale.Services;
using ProgettoPoliziaMunicipale.ViewModel;

namespace ProgettoPoliziaMunicipale.Controllers
{
    public class AnagraficaController : Controller
    {
        private readonly AnagraficaService _anagraficaService;

        public AnagraficaController(AnagraficaService anagraficaService)
        {
            _anagraficaService = anagraficaService;
        }
        public async Task<IActionResult> Index()
        {
            var anag = await _anagraficaService.GetAllAnagraficheAsync();
            return View(anag);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
      
        public async Task<IActionResult> Add(AddAnagraficaViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _anagraficaService.AddAnagraficheAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var anag = await _anagraficaService.GetAnagraficheByIdAsync(id);
            if (anag == null)
            {
                return NotFound();
            }
            return View(anag);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditAnagraficaViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _anagraficaService.EditAnagraficaAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _anagraficaService.DeleteAnagraficaByIdAsync(id);

            if (!result)
            {
                TempData["Error"] = "Error while deleting entity from database";
            }
            return RedirectToAction("Index");
        }
     
    }
}
