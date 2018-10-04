using Esportiva.BLL.Interfaces;
using Esportiva.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Esportiva.Controllers
{
    [SessionCheck]
    public class EscalacaoController : Controller
    {
        private IEscalacaoBLL _escalacaoBLL;
        public EscalacaoController(IEscalacaoBLL escalacaoBLL)
        {
            _escalacaoBLL = escalacaoBLL;
        }

        [HttpGet]
        public async Task<ActionResult> Jogadores(int codigoTime)
        {
            var x = await _escalacaoBLL.RetornarJogadores(codigoTime, Session["user"].ToString());
            return View("Jogador/Index");
            
        }
    }
}