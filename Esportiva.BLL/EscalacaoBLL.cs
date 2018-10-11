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
    public class EscalacaoBLL : IEscalacaoBLL
    {
        private IEscalacaoDAL _escalacaoDAL;
        private IAutenticacaoDAL _autenticacaoDAL;
        public EscalacaoBLL(IEscalacaoDAL escalacaoDAL, IAutenticacaoDAL autenticacaoDAL)
        {
            _escalacaoDAL = escalacaoDAL;
            _autenticacaoDAL = autenticacaoDAL;
        }

        public async Task<bool> CadastrarJogador(JogadorMOD jogadorMOD, string usuario)
        {
            jogadorMOD.CodigoTime = await _escalacaoDAL.RetornarCodigoTime(usuario);
            return await _escalacaoDAL.CadastrarJogador(jogadorMOD);
        }

        public async Task<bool> EditarJogador(JogadorMOD jogadorMOD, string usuario)
        {
            return await _escalacaoDAL.EditarJogador(jogadorMOD, usuario);
        }

        public async Task<List<JogadorMOD>> RetornarJogadores(int codigoTime, string usuario)
        {
            var codigoUsuario = (await _autenticacaoDAL.RetornarUsuario(usuario))?.Id;

            var jogadores = await _escalacaoDAL.RetornarJogadores(codigoTime, codigoUsuario ?? 0);

            if (jogadores == null)
                return new List<JogadorMOD>();
            return jogadores;
        }


        
    }
}
