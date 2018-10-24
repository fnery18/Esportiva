using Esportiva.MOD;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Esportiva.BLL.Interfaces
{
    public interface IEscalacaoBLL
    {
        Task<List<JogadorMOD>> RetornarJogadores(int codigoTime, string usuario);
        Task<bool> CadastrarJogador(JogadorMOD jogadorMOD, string usuario);
        Task<bool> EditarJogador(JogadorMOD jogadorMOD, string usuario);
        Task<List<TimeMOD>> RetornarAdversarios(string usuarios);
        Task<List<RelatorioMOD>> RetornarRelatorioAcontecimentos(int codigoTime);
        Task<bool> ExcluirJogador(int codigoJogador, string v);
    }
}
