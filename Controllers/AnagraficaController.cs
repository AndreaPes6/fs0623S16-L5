using Microsoft.AspNetCore.Mvc;
using PoliziaMunicipale.Models;
using System.Diagnostics;

namespace PoliziaMunicipale.Controllers
{
    public class AnagraficaController : Controller
    {
        private readonly ILogger<AnagraficaController> _logger;
        private readonly GuardieDBContext _context;

        public AnagraficaController(ILogger<AnagraficaController> logger, GuardieDBContext context)
        {
            _logger = logger;
            _context = context;
        }


        public IActionResult Index()
        {
            var Persone = _context.Anagrafica.ToList();
            return View(Persone);
        }

        public IActionResult AggiungiPersona(AnagraficaMOD Persona)
        {
            if (ModelState.IsValid)
            {
                _context.Anagrafica.Add(Persona);
                _context.SaveChanges();
                return RedirectToAction("Index", new { id = Persona.ID });
            }
            else
            {
                return View(Persona);
            }
        }

        [HttpPost]
        public IActionResult EliminaPersona(int ID)
        {
            var PersonaCancellata = _context.Anagrafica.Find(ID);
            if (PersonaCancellata != null)
            {
              
                _context.Anagrafica.Remove(PersonaCancellata);
                _context.SaveChanges();

                TempData["messaggio"] = $"Risorsa {PersonaCancellata.Nome} è stato eliminato";

                TempData["MessageSuccess"] = "Scarpe eliminate con successo!";
                return RedirectToAction("Index");
            }
            TempData["messaggioErrore"] = "C'è stato un errore nell'eliminazione";
            return RedirectToAction("Index");
        }

    }
}

