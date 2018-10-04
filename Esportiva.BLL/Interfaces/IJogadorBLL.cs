﻿using Esportiva.MOD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esportiva.BLL.Interfaces
{
    public interface IJogadorBLL
    {
        Task<List<JogadorMOD>> RetornarJogadores(int codigoTime, string usuario);
    }
}
