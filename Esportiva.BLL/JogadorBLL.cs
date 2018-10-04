using Esportiva.BLL.Interfaces;
using Esportiva.DAL.Interfaces;
using Esportiva.MOD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esportiva.BLL
{
    public class JogadorBLL : IJogadorBLL
    {
        private IJogadorDAL _jogadorDAL;

        public JogadorBLL(IJogadorDAL jogador)
        {
            _jogadorDAL = jogador;
            //_autenticacaoBLL = autenticacaoBLL;
        }

        public async Task<List<JogadorMOD>> RetornarJogadores(int codigoTime, string usuario)
        {

            //var codigoUsuario = (await _autenticacaoBLL.RetornarUsuario(usuario))?.Id;
            

            var jogadores = await _jogadorDAL.RetornarJogadores(codigoTime, 0);

            if (jogadores == null)
                jogadores = new List<JogadorMOD>();

            return jogadores;
        }
    }
}
