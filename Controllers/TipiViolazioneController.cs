using Microsoft.AspNetCore.Mvc;
using PoliziaMunicipale.Models;

namespace PoliziaMunicipale.Controllers
{
    public class TipiViolazioneController : Controller
    {
        private readonly ILogger<TipiViolazioneController> _logger;
        private readonly GuardieDBContext _context;

        public TipiViolazioneController(ILogger<TipiViolazioneController> logger, GuardieDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var ListaViolazioni = _context.TipiViolazione.ToList();
            return View(ListaViolazioni);
        }

        public IActionResult AggiungiViolazione(TipoViolazioneMOD Violazione)
        {
            if (ModelState.IsValid)
            {
                _context.TipiViolazione.Add(Violazione);
                _context.SaveChanges();
                return RedirectToAction("Index", new { id = Violazione.ID });
            }
            else
            {
                return View(Violazione);
            }
        }

        [HttpPost]
        public IActionResult EliminaViolazione(int ID)
        {
            var ViolazioneCancellata = _context.TipiViolazione.Find(ID);
            if (ViolazioneCancellata != null)
            {

                _context.TipiViolazione.Remove(ViolazioneCancellata);
                _context.SaveChanges();         
                return RedirectToAction("Index");
            }
            TempData["messaggioErrore"] = "C'è stato un errore nell'eliminazione";
            return RedirectToAction("Index");
        }
    }

}

