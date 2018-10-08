using Esportiva.BLL.Interfaces;
using Esportiva.MOD;
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
            var jogadores = await _escalacaoBLL.RetornarJogadores(codigoTime, Session["user"].ToString());
            return View("Jogador/Index", jogadores
                                            .Select(c => new JogadorModel(c))
                                            .ToList());
            
        }

        [HttpPost]
        public async Task<ActionResult> CadastraJogador(JogadorModel jogador)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var cadastrou = await _escalacaoBLL.CadastrarJogador(new JogadorMOD()
                    {
                        Altura = jogador.Altura,
                        Apelido = jogador.Apelido,
                        CodigoTime = jogador.CodigoTime,
                        DataNascimento = jogador.DataNascimento,
                        Nome = jogador.Nome,
                        NumeroCamisa = jogador.NumeroCamisa,
                        Posicao = jogador.Posicao,
                        Sobrenome = jogador.Sobrenome,
                        Time = jogador.Time
                    });

                    if (cadastrou)
                        return Json(new { Sucesso = true, Mensagem = "Jogador cadastrado com sucesso!" });
                    return Json(new { Sucesso = false, Mensagem = "Ocorreu um erro ao cadastrar o jogador" });

                }

                return Json(new { Sucesso = false, Mensagem = "Ops! Campos não preenchidos corretamente" });
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}