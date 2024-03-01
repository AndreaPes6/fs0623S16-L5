using Microsoft.EntityFrameworkCore;
using PoliziaMunicipale.Models;

namespace PoliziaMunicipale.Models
{
    public class GuardieDBContext : DbContext
    {
        public GuardieDBContext(DbContextOptions<GuardieDBContext> options) : base(options)
        {
        }

        public DbSet<AnagraficaMOD> Anagrafica { get; set; }

        public AnagraficaMOD? GetByIdAnagrafica(int idAnagrafica)
        {
            for (int i = 0; i < Anagrafica.Count(); i++)
            {
                var Persona = Anagrafica.ElementAt(i);
                if (Persona.ID == idAnagrafica)
                {
                    return Persona;
                }
            }
            return null;
        }

        public DbSet<TipoViolazioneMOD> TipiViolazione { get; set; }

        public TipoViolazioneMOD? GetByIdViolazione(int idViolazione)
        {
            for (int i = 0; i < TipiViolazione.Count(); i++)
            {
                var Violazione = TipiViolazione.ElementAt(i);
                if (Violazione.ID == idViolazione)
                {
                    return Violazione;
                }
            }
            return null;
        }

        public DbSet<VerbaleMOD> Verbale { get; set; }

        public VerbaleMOD? GetByIdVerbale(int idVerbale)
        {
            for (int i = 0; i < Verbale.Count(); i++)
            {
                var Multa = Verbale.ElementAt(i);
                if (Multa.ID == idVerbale)
                {
                    return Multa;
                }
            }
            return null;
        }




    }
}
