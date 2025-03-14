using Microsoft.AspNetCore.Mvc;
using ProgettoPoliziaMunicipale.Services;
using System.Threading.Tasks;

namespace ProgettoPoliziaMunicipale.Controllers
{
    public class ExtraController : Controller
    {
        private readonly VerbaleService _verbaleService;

        public ExtraController(VerbaleService verbaleService)
        {
            _verbaleService = verbaleService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> VerbaliTrasgressore()
        {
            var extra1 = await _verbaleService.GetVerbaliTrasgressoreAsync();
            return View(extra1);
        }

        public async Task<IActionResult> PuntiTrasgressore()
        {
            var extra2 = await _verbaleService.GetPuntiTrasgressoreAsync();
            return View(extra2);
        }

        public async Task<IActionResult> Viol10Punti()
        {
            var extra3 = await _verbaleService.GetViol10PuntiAsync();
            return View(extra3);
        }

        public async Task<IActionResult> Viol400Euro()
        {
            var extra4 = await _verbaleService.GetViol400EuroAsync();
            return View(extra4);
        }
    }
}
