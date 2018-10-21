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
    public class AdministrativoController : Controller
    {
        private IAdministrativoBLL _administrativoBLL;
        private IAutenticacaoBLL _autenticaBLL;


        public AdministrativoController(IAdministrativoBLL administrativoBLL, IAutenticacaoBLL autenticaBLL)
        {
            _administrativoBLL = administrativoBLL;
            _autenticaBLL = autenticaBLL;

        }


        #region TIME
        [HttpGet]
        public async Task<ActionResult> Time()
        {
            var usuario = await _autenticaBLL.RetornarUsuario(Session["user"].ToString());
            var times = await _administrativoBLL.RetornarTimes(usuario);

            return View("Time/Index", times
                                        .Select(c => new TimeModel(c))
                                        .ToList());
        }

        [HttpPost]
        public async Task<ActionResult> CadastrarTime(TimeModel time, string nomeAntigo, bool adversario = false)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var timeExiste = await _administrativoBLL.RetornarTimeExiste(nomeAntigo ?? time.Nome);
                    var usuario = Session["user"].ToString();
                    var novoTime = new TimeMOD()
                    {
                        Nome = time.Nome,
                        DataFundacao = time.DataFundacao,
                        Nacionalidade = time.Nacionalidade,
                        Sigla = time.Sigla,
                        Cor1 = time.Cor1,
                        Cor2 = time.Cor2,
                        Cor3 = time.Cor3
                    };

                    if (!timeExiste)
                    {
                        bool cadastrou = await _administrativoBLL.CadastrarTime(novoTime, usuario, adversario);
                        if (cadastrou)
                            return Json(new { Sucesso = true, Mensagem = "Time cadastrado com sucesso!" });
                        else
                            return Json(new { Sucesso = false, Mensagem = "Ops! Ocorreu um erro" });
                    }
                    else
                    {
                        await _administrativoBLL.AlterarTime(novoTime, nomeAntigo ?? novoTime.Nome, usuario);
                        return Json(new { Sucesso = true, Mensagem = "Time alterado com sucesso!" });
                    }
                }

                return Json(new { Sucesso = false, Mensagem = "Por favor preencha todos os campos corretamente." });
            }
            catch (Exception e)
            {
                return Json(new { Sucesso = false, Mensagem = e.Message });
            }
        }


        [HttpPost]
        public async Task<JsonResult> ExcluirTime(int codigoTime, bool adversario = false)
        {
            return Json(new { Sucesso = await _administrativoBLL.ExcluirTime(codigoTime, Session["user"].ToString(), adversario) });
        }

        [HttpGet]
        public async Task<ActionResult> EditarTime(int codigoTime)
        {
            var time = await _administrativoBLL.RetornarTime(codigoTime, Session["user"].ToString());
            return View("Time/Editar", new TimeModel(time));
        }

        #endregion

        #region ACONTECIMENTOS / PARTIDAS

        [HttpGet]
        public async Task<ActionResult> Acontecimentos(int codigoTime)
        {
            var user = Session["user"].ToString();
            var acontecimentos = await _administrativoBLL.RetornarAcontecimentos(codigoTime, user);
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Partidas(int codigoTime)
        {
            var login = Session["user"].ToString();
            var partidas = await _administrativoBLL.RetornarPartidas(codigoTime, login);
            var usuario = await _autenticaBLL.RetornarUsuario(login);

            var model = new PartidaViewModel()
            {
                Partidas = partidas.Select(c => new PartidaModel(c)).ToList(),
                MeusTimes = (await _administrativoBLL.RetornarTimes(usuario)).Select(c => new TimeModel(c)).ToList(),
                TimesAdversarios = (await _administrativoBLL.RetornarTimesAdversarios(usuario, codigoTime)).Select(c => new TimeModel(c)).ToList()
            };

            return View("Partidas/Index", model);
        }

        [HttpPost]
        public async Task<ActionResult> ExcluirPartida(int codigoPartida)
        {
            return Json(new { Sucesso = await _administrativoBLL.ExcluirPartida(codigoPartida, Session["user"].ToString()) });
        }


        [HttpPost]

        public async Task<JsonResult> CadastrarPartida(PartidaModel partida)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var cadastrou = await _administrativoBLL.CadastrarPartida(new PartidasMOD()
                    {
                        Competicao = partida.Competicao,
                        DataPartida = partida.DataPartida,
                        IdTime1 = partida.IdTime1,
                        IdTime2 = partida.IdTime2,
                        LocalCompeticao = partida.LocalCompeticao,
                        NomePartida = partida.NomePartida
                    });

                    if (cadastrou)
                        return Json(new { Sucesso = true, Mensagem = "Partida cadastrada com sucesso!" });
                    return Json(new { Sucesso = false, Mensagem = "Ops! Ocorreu um erro ao cadastrar a partida." });
                }

                return Json(new { Sucesso = false, Mensagem = "Campos não preenchidos corretamente." });
            }
            catch (Exception e)
            {

                return Json(new { Sucesso = false, Mensagem = e.Message });
            }

        }
        #endregion

    }
}