using Esportiva.MOD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Esportiva.Models
{
    public class JogadorModel
    {
        public int CodigoTime { get; set; }
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string NomeCompleto
        {

            get
            {
                return $"{Nome} {Sobrenome}";
            }
        }
        public string Posicao { get; set; }
        public DateTime DataNascimento { get; set; }
        public string DataNascimentoFormatada
        {

            get
            {
                return DataNascimento.ToShortDateString();
            }
        }
        public string Time { get; set; }
        public int NumeroCamisa { get; set; }
        public string Apelido { get; set; }
        public double Altura { get; set; }


        public JogadorModel()
        {

        }

        public JogadorModel(JogadorMOD jogador)
        {
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