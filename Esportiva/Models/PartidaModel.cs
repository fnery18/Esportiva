using Esportiva.MOD;
using System;
using System.ComponentModel.DataAnnotations;

namespace Esportiva.Models
{
    public class PartidaModel
    {
        public int Id { get; set; }
        [Required]
        public string NomePartida { get; set; }

        [Required]
        public DateTime DataPartida { get; set; }
        public int IdTime1 { get; set; }
        public TimeModel Time1 { get; set; }

        [Required]
        public int IdTime2 { get; set; }

        public TimeModel Time2 { get; set; }

        [Required]
        public string LocalCompeticao { get; set; }

        [Required]
        public string Competicao { get; set; }

        public PartidaModel()
        {

        }

        public PartidaModel(PartidasMOD partida)
        {
            Id = partida.Id;
            NomePartida = partida.NomePartida;
            DataPartida = partida.DataPartida;
            IdTime1 = partida.IdTime1;
            IdTime2 = partida.IdTime2;
            Time1 = new TimeModel(partida.Time1) ?? null;
            Time2 = new TimeModel(partida.Time2) ?? null;
            LocalCompeticao = partida.LocalCompeticao;
            Competicao = partida.Competicao;
        }
    }
}