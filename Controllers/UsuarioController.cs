using System.Collections.Generic;
using Biblioteca.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Cadastro()
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaSeUsuarioEAdmin(this);
            return View(new CadastroUsuarioModel());
        }

        [HttpPost]
        public IActionResult Cadastro(CadastroUsuarioModel viewModel)
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaSeUsuarioEAdmin(this);
            viewModel.Usuario.usuario_senha = Criptografo.TextoCriptografado(viewModel.Usuario.usuario_senha);
            UsuarioService UsuarioService = new UsuarioService();

            if (viewModel.Usuario.usuario_id == 0)
            {
                UsuarioService.Inserir(viewModel.Usuario);
            }
            else
            {
                UsuarioService.Atualizar(viewModel.Usuario);
            }
            return RedirectToAction("Listagem");
        }
        public IActionResult Listagem(string tipoFiltro, string filtro)
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaSeUsuarioEAdmin(this);
            FiltrosUsuario objFiltro = null;
            if (!string.IsNullOrEmpty(filtro))
            {
                objFiltro = new FiltrosUsuario();
                objFiltro.TipoFiltro = tipoFiltro;
                objFiltro.Filtro = filtro;
            }
            UsuarioService UsuarioService = new UsuarioService();
            return View(UsuarioService.ListarTodos(objFiltro));
        }

        public IActionResult Edicao(int id)
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaSeUsuarioEAdmin(this);
            UsuarioService em = new UsuarioService();
            Usuario e = em.ObterPorId(id);

            CadastroUsuarioModel cadModel = new CadastroUsuarioModel();
            cadModel.Usuario = e;
            cadModel.TiposUsuario = new List<string>() { "Admin", "User" };

            return View(cadModel);
        }
        public IActionResult Excluir(int id)
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaSeUsuarioEAdmin(this);
            UsuarioService UsuarioService = new UsuarioService();
            UsuarioService.Excluir(id);
            return RedirectToAction("Listagem");
        }
        public IActionResult AcessoNegado()
        {
            return View();
        }
    }
}