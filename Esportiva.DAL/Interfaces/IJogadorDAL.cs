using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esportiva.MOD;

namespace Esportiva.DAL.Interfaces
{
    public interface IJogadorDAL
    {
        Task<List<JogadorMOD>> RetornarJogadores(int codigoTime, int codigoUsuario);
    }
}
