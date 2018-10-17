using Esportiva.MOD;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Esportiva.Models
{
    public class JogadorModel
    {
        public int CodigoTime { get; set; }
        public string Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Sobrenome { get; set; }
        public string NomeCompleto
        {

            get
            {
                return $"{Nome} {Sobrenome}";
            }
        }
        [Required]
        public string Posicao { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
        public string DataNascimentoFormatada
        {

            get
            {
                return DataNascimento.ToShortDateString();
            }
        }
        
        public string Time { get; set; }
        [Required]
        public int NumeroCamisa { get; set; }
        [Required]
        public string Apelido { get; set; }
        [Required]
        public double Altura { get; set; }


        public JogadorModel()
        {

        }

        public JogadorModel(JogadorMOD jogador)
        {
            CodigoTime = jogador.CodigoTime;
            Id = jogador.Id;
            Nome = jogador.Nome;
            Sobrenome = jogador.Sobrenome;
            Posicao = jogador.Posicao;
            DataNascimento = jogador.DataNascimento;
            Time = jogador.Time;
            NumeroCamisa = jogador.NumeroCamisa;
            Apelido = jogador.Apelido;
            Altura = jogador.Altura;
        }
    }
}