using Esportiva.BLL.Interfaces;
using Esportiva.MOD;
using Esportiva.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
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


        #region JOGADORES


        [HttpPost]
        public async Task<ActionResult> ExcluirJogador(int codigoJogador)
        {
            try
            {
                var excluiu = await _escalacaoBLL.ExcluirJogador(codigoJogador, Session["user"].ToString());
                if (excluiu)
                    return Json(new { Sucesso = true, Mensagem = "Jogador excluido com sucesso!" });
                return Json(new { Sucesso = false, Mensagem = "Ops! Ocorreu um erro." });
            }
            catch (Exception ex)
            {

                return Json(new { Sucesso = false, Mensagem = ex.Message });
            }
            

        }

        [HttpGet]
        public async Task<ActionResult> Jogadores(int codigoTime)
        {
            var jogadores = await _escalacaoBLL.RetornarJogadores(codigoTime, Session["user"].ToString());

            var model = new JogadorViewModel()
            {
                Jogadores = jogadores.Select(c => new JogadorModel(c)).ToList(),
                codigoTime = codigoTime
            };

            return View("Jogador/Index", model);

        }


        [HttpPost]
        public async Task<ActionResult> EditarJogador(JogadorModel jogador)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var cadastrou = await _escalacaoBLL.EditarJogador(new JogadorMOD()
                    {
                        Altura = jogador.Altura,
                        Apelido = jogador.Apelido,
                        CodigoTime = jogador.CodigoTime,
                        DataNascimento = jogador.DataNascimento,
                        Nome = jogador.Nome,
                        NumeroCamisa = jogador.NumeroCamisa,
                        Posicao = jogador.Posicao,
                        Sobrenome = jogador.Sobrenome,
                        Time = jogador.Time,
                        Id = jogador.Id
                    }, Session["user"].ToString());

                    if (cadastrou)
                        return Json(new { Sucesso = true, Mensagem = "Jogador editado com sucesso!" });
                    return Json(new { Sucesso = false, Mensagem = "Ocorreu um erro ao editar jogador" });

                }

                return Json(new { Sucesso = false, Mensagem = "Ops! Campos não preenchidos corretamente" });
            }
            catch (Exception e)
            {

                return Json(new { Sucesso = false, Mensagem = e.Message });
            }
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
                    }, Session["user"].ToString());

                    if (cadastrou)
                        return Json(new { Sucesso = true, Mensagem = "Jogador cadastrado com sucesso!" });
                    return Json(new { Sucesso = false, Mensagem = "Ocorreu um erro ao cadastrar o jogador" });

                }

                return Json(new { Sucesso = false, Mensagem = "Ops! Campos não preenchidos corretamente" });
            }
            catch (Exception e)
            {
                return Json(new { Sucesso = false, Mensagem = e.Message });
            }
        }
        #endregion

        [HttpGet]
        public async Task<ActionResult> Adversarios(int codigoTime)
        {
            var adversarios = await _escalacaoBLL.RetornarAdversarios(Session["user"].ToString());

            var model = new TimeViewModel()
            {
                Times = adversarios.Select(c => new TimeModel(c)).ToList(),
                codigoTime = codigoTime
            };

            return View("Adversarios/Index", model);
        }

        [HttpGet]
        public async Task<ActionResult> Relatorios(int codigoTime)
        {
            return View(model: codigoTime);
        }

        [HttpGet]
        public async Task<JsonResult> RetornarRelatorios(int codigoTime)
        {
            var acontecimentos = await _escalacaoBLL.RetornarRelatorioAcontecimentos(codigoTime);
            var model = new RelatorioViewModel()
            {
                NomeAcontecimento = acontecimentos.Select(c => c.Nome).ToList(),
                QuantidadeAcontecimento = acontecimentos.Select(c => c.Quantidade).ToList()
            };

            return Json(new { Nome = model.NomeAcontecimento, Quantidade = model.QuantidadeAcontecimento }, JsonRequestBehavior.AllowGet);
        }

    }
}