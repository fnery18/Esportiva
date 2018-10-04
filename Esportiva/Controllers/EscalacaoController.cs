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
        private IJogadorBLL _jogadorBLL;

        public EscalacaoController(IJogadorBLL jogadorBLL)
        {
            _jogadorBLL = jogadorBLL;
        }

        [HttpGet]
        public async Task<ActionResult> Jogadores(int codigoTime)
        {
            var jogadores = await _jogadorBLL.RetornarJogadores(codigoTime, Session["user"].ToString());

            return View("Jogador/Index", jogadores.Select(batata => new JogadorModel(batata)).ToList());
            
        }
    }
}