using Esportiva.BLL.Interfaces;
using Esportiva.MOD;
using Esportiva.Models;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Esportiva.Controllers
{
    public class AutenticacaoController : Controller
    {
        private IAutenticacaoBLL _autenticacaoBLL;
        public AutenticacaoController(IAutenticacaoBLL autenticacaoBLL)
        {
            _autenticacaoBLL = autenticacaoBLL;
        }

        [HttpGet]
        public ActionResult Login()
        {
            if (Session["user"] == null)
                return View("Index", new LoginModel() { Mensagem = "" });

            return RedirectToAction("Index", "Home");

        }
        [HttpPost]
        public async Task<ActionResult> Autentica(LoginModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var usuario = new LoginMOD
                    {
                        Senha = model.Senha,
                        Usuario = model.Usuario
                    };

                    if (await _autenticacaoBLL.ValidaUsuario(usuario))
                    {
                        Session["user"] = usuario.Usuario;
                        return RedirectToAction("Index", "Home");
                    }
                }
                return View("Index", new LoginModel() { Mensagem = "Usuário ou senha inválidos" });
            }
            catch (Exception e)
            {
                return View("Index", new LoginModel() { Mensagem = e.Message });
            }
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session["user"] = null;
            return RedirectToAction("Login", "Autenticacao");
        }

        [HttpPost]
        public async Task<JsonResult> Cadastrar(LoginModel login)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    await _autenticacaoBLL.CadastrarUsuario(new LoginMOD()
                    {
                        Usuario = login.Usuario,
                        Senha = login.Senha
                    });

                    return Json(new { Sucesso = true, Mensagem = "Conta criada com sucesso!" });
                }

                return Json(new { Sucesso = false, Mensagem = "Ops! Ocorreu um erro." });
            }
            catch (Exception e)
            {
                return Json(new { Sucesso = true, Mensagem = e.Message });
            }
        }


    }
}