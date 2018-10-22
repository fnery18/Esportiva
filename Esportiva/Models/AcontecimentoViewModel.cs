using System.Collections.Generic;

namespace Esportiva.Models
{
    public class AcontecimentoViewModel
    {
        public TimeModel Time { get; set; }

        public PartidaModel Partida { get; set; }

        public int Tempo { get; set; }

        public JogadorModel Jogador { get; set; }

        public List<TipoAcontecimentoModel> TipoAcontecimento { get; set; }
    }
}