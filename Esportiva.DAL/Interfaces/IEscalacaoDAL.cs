using Esportiva.MOD;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Esportiva.DAL.Interfaces
{
    public interface IEscalacaoDAL
    {
        Task<List<JogadorMOD>> RetornarJogadores(int codigoTime, int v);
        Task<bool> CadastrarJogador(JogadorMOD jogadorMOD);
        Task<int> RetornarCodigoTime(string usuario);
        Task<bool> EditarJogador(JogadorMOD jogadorMOD, string usuario);
        Task<List<TimeMOD>> RetornarAdversarios(int id);
        Task<List<RelatorioMOD>> RetornarRelatorioAcontecimentos(int codigoTime);
    }
}
