using Microsoft.AspNetCore.Mvc;
using PoliziaMunicipale.Models;

namespace PoliziaMunicipale.Controllers
{
    public class VerbaleController : Controller
    {
        private readonly ILogger<VerbaleController> _logger;
        private readonly GuardieDBContext _context;

        public VerbaleController(ILogger<VerbaleController> logger, GuardieDBContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            var Verbali = _context.Verbale.ToList();
            return View(Verbali);
        }

        public IActionResult AggiungiVerbale(VerbaleMOD verbale)
        {
            if (ModelState.IsValid)
            {
                _context.Verbale.Add(verbale);
                _context.SaveChanges();
                return RedirectToAction("Index", new { id = verbale.ID });
            }
            else
            {
                return View(verbale);
            }
        }


    }
}
