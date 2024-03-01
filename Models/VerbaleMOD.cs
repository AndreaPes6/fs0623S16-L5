using System;
using System.ComponentModel.DataAnnotations;

namespace PoliziaMunicipale.Models
{
    public class VerbaleMOD
    {
        public int ID { get; set; }

        public int IDViolazione { get; set; }

        public int IDAnagrafica { get; set; }

        public DateTime DataViolazione { get; set; }

        public string IndirizzoViolazione { get; set; }

        public string Nominativo_Agente { get; set; }

        public DateTime DataTrascrizioneVerbale { get; set; }

        public decimal Importo { get; set; }

        public int DecurtamentoPunti { get; set; }

        public bool Contestazione { get; set; }
    }
}
