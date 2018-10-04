using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esportiva.MOD
{
    public class JogadorMOD
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Posicao { get; set; }
        public DateTime DataNascimento { get; set; }
        public int CodigoTime { get; set; }
        public string Time { get; set; }
        public int NumeroCamisa { get; set; }
        public string Apelido { get; set; }
        public double Altura { get; set; }
    }
}

