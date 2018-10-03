using Esportiva.MOD;
using System;
using System.ComponentModel.DataAnnotations;

namespace Esportiva.Models
{
    public class TimeModel
    {
        public TimeModel(TimeMOD time)
        {
            Id = time.Id;
            Nome = time.Nome;
            Sigla = time.Sigla;
            Cor1 = time.Cor1;
            Cor2 = time.Cor2;
            Cor3 = time.Cor3;
            Nacionalidade = time.Nacionalidade;
            DataFundacao = time.DataFundacao;
        }

        public TimeModel() { }

        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }

        [Required]
        public string Sigla { get; set; }

        [Required]
        public string Cor1 { get; set; }

        public string Cor2 { get; set; }

        public string Cor3 { get; set; }

        [Required]
        public string Nacionalidade { get; set; }

        [Required]
        public DateTime DataFundacao { get; set; }
    }
}