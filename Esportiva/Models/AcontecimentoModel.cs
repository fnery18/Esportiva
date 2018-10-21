using Esportiva.MOD;
using System.ComponentModel.DataAnnotations;

namespace Esportiva.Models
{
    public class AcontecimentoModel
    {
        public int Id { get; set; }

        [Required]
        public int Jogador_Id { get; set; }


        public JogadorModel Jogador { get; set; }
        public int Partida_Id { get; set; }
        public PartidaModel Partida { get; set; }

        [Required]
        public int Tempo { get; set; }

        [Required]
        public int Time_Id { get; set; }


        public TimeModel Time { get; set; }

        [Required]
        public int TipoAcontecimento_Id { get; set; }


        public TipoAcontecimentoModel TipoAcontecimento { get; set; }

        public AcontecimentoModel()
        {

        }

        public AcontecimentoModel(AcontecimentosMOD ac)
        {
            Jogador_Id = ac.Jogador_Id;
            Tempo = ac.Tempo;
            TipoAcontecimento_Id = ac.TipoAcontecimento_Id;

            Id = ac.Id;
            Partida_Id = ac.Partida_Id;
            Time_Id = ac.Time_Id;
            Jogador = new JogadorModel(ac.Jogador);
            Partida = new PartidaModel(ac.Partida);
            Time = new TimeModel(ac.Time);
            TipoAcontecimento = new TipoAcontecimentoModel(ac.TipoAcontecimento);


        }

    }
}