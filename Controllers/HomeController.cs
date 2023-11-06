using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Biblioteca.Models;
using Microsoft.AspNetCore.Http;

namespace Biblioteca.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Autenticacao.CheckLogin(this);
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string login, string senha)
        {
            UsuarioService usuarioService = new UsuarioService();
            Usuario usuario = usuarioService.ObterPorLoginSenha(login, senha);
            if(usuario == null)
            {
                ViewData["Erro"] = "Usuário ou senha inválidos";
                return View();
            }
            else
            {
                HttpContext.Session.SetString("user", "admin");
                HttpContext.Session.SetString("Nome", usuario.usuario_nome);
                HttpContext.Session.SetString("Tipo", usuario.usuario_tipo);
                return RedirectToAction("Index");
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("user");
            HttpContext.Session.Remove("Nome");
            HttpContext.Session.Remove("Tipo");
            return RedirectToAction("Index");
        }
    }
}
