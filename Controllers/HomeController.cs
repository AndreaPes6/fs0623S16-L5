using Microsoft.AspNetCore.Mvc;
using PoliziaMunicipale.Models;
using System.Diagnostics;

namespace PoliziaMunicipale.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly GuardieDBContext _context;

        public HomeController(ILogger<HomeController> logger, GuardieDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult VerbaliPerTrasgressore()
        {
            var verbaliPerTrasgressore = _context.Verbale.GroupBy(v => v.IDAnagrafica)
                .Select(g => new { IDAnagrafica = g.Key, TotaleVerbali = g.Count() })
                .ToList();
            return View(verbaliPerTrasgressore);
        }

        public IActionResult PuntiDecurtatiPerTrasgressore()
        {
            var puntiDecurtatiPerTrasgressore = _context.Verbale.GroupBy(v => v.IDAnagrafica)
                .Select(g => new { IDAnagrafica = g.Key, TotalePunti = g.Sum(v => v.DecurtamentoPunti) })
                .ToList();
            return View(puntiDecurtatiPerTrasgressore);
        }

        public IActionResult ViolazioniConPiùDi10Punti()
        {
            var violazioni = _context.Verbale.Where(v => v.DecurtamentoPunti > 10)
                .Select(v => new { v.Importo, v.IDAnagrafica, v.DataViolazione, v.DecurtamentoPunti })
                .ToList();
            return View(violazioni);
        }

        public IActionResult ViolazioniConImportoMaggioreDi400Euro()
        {
            var violazioni = _context.Verbale.Where(v => v.Importo > 400)
                .Select(v => new { v.Importo, v.IDAnagrafica, v.DataViolazione, v.DecurtamentoPunti })
                .ToList();
            return View(violazioni);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
