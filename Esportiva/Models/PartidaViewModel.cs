using System.Collections.Generic;

namespace Esportiva.Models
{
    public class PartidaViewModel
    {
        public List<PartidaModel> Partidas { get; set; }
        public List<TimeModel> MeusTimes { get; set; }
        public List<TimeModel> TimesAdversarios { get; set; }
        public int codigoTime { get; set; }
    }
}