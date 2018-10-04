using Esportiva.MOD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esportiva.DAL.Interfaces
{
    public interface IEscalacaoDAL
    {
        Task<List<JogadorMOD>> RetornarJogadores(int codigoTime, int v);
    }
}
