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
        private ITimeBLL _timeBLL;
        private IAutenticacaoBLL _autenticaBLL;


        public AdministrativoController(ITimeBLL timeBLL, IAutenticacaoBLL autenticaBLL)
        {
            _timeBLL = timeBLL;
            _autenticaBLL = autenticaBLL;

        }


        #region TIME
        [HttpGet]
        public async Task<ActionResult> Time()
        {
            var usuario = await _autenticaBLL.RetornarUsuario(Session["user"].ToString());
            var times = await _timeBLL.RetornarTimes(usuario);

            return View("Time/Index", times
                                        .Select(c => new TimeModel(c))
                                        .ToList());
        }

        [HttpPost]
        public async Task<ActionResult> CadastrarTime(TimeModel time, string nomeAntigo)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var timeExiste = await _timeBLL.RetornarTimeExiste(nomeAntigo ?? time.Nome);
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
                        bool cadastrou = await _timeBLL.CadastrarTime(novoTime, usuario);
                        if (cadastrou)
                            return Json(new { Sucesso = true, Mensagem = "Time cadastrado com sucesso!" });
                        else
                            return Json(new { Sucesso = false, Mensagem = "Ops! Ocorreu um erro" });
                    }
                    else
                    {
                        await _timeBLL.AlterarTime(novoTime, nomeAntigo ?? novoTime.Nome, usuario);
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
        public async Task<JsonResult> ExcluirTime(int codigoTime)
        {
            return Json(new { Sucesso = await _timeBLL.ExcluirTime(codigoTime, Session["user"].ToString()) });
        }

        [HttpGet]
        public async Task<ActionResult> EditarTime(int codigoTime)
        {
            var time = await _timeBLL.RetornarTime(codigoTime, Session["user"].ToString());
            return View("Time/Editar", new TimeModel(time));
        }

        #endregion

    }
}