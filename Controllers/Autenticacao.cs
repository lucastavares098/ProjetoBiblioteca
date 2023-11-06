using System.Collections.Generic;
using System.Linq;
using Biblioteca.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Biblioteca.Controllers
{
    public class Autenticacao
    {
        public static void CheckLogin(Controller controller)
        {
            if (string.IsNullOrEmpty(controller.HttpContext.Session.GetString("user")))
            {
                controller.Request.HttpContext.Response.Redirect("/Home/Login");
            }
        }
        public static bool verificarLoginSenha(string Login, string senha, Controller controller)
        {
            using (BibliotecaContext bc = new BibliotecaContext())
            {
                verificarSeUsuarioAdminExiste(bc);
                senha = Criptografo.TextoCriptografado(senha);
                IQueryable<Usuario> UsuarioEncontrado = bc.Usuarios.Where(u => u.usuario_login == Login && u.usuario_senha == senha);
                List<Usuario> listaUsuarioEncontrado = UsuarioEncontrado.ToList();
                if (listaUsuarioEncontrado.Count == 0)
                {
                    return false;
                }
                else
                {
                    controller.HttpContext.Session.SetString("user", listaUsuarioEncontrado[0].usuario_login);
                    controller.HttpContext.Session.SetString("Nome", listaUsuarioEncontrado[0].usuario_nome);
                    controller.HttpContext.Session.SetString("Tipo", listaUsuarioEncontrado[0].usuario_tipo);
                    return true;

                }

            }
        }
        public static void verificarSeUsuarioAdminExiste(BibliotecaContext bc)
        {
            IQueryable<Usuario> UsuarioEncontrado = bc.Usuarios.Where(u => u.usuario_tipo == "Admin");
            List<Usuario> listaUsuarioEncontrado = UsuarioEncontrado.ToList();
            if (listaUsuarioEncontrado.Count == 0)
            {
                Usuario admin = new Usuario();
                admin.usuario_nome = "Administrador";
                admin.usuario_login = "Admin";
                admin.usuario_senha = Criptografo.TextoCriptografado("Admin");
                admin.usuario_tipo = "Admin";
                bc.Usuarios.Add(admin);
                bc.SaveChanges();
            }
        }

        public static void verificaSeUsuarioEAdmin(Controller controller)
        {
            if (controller.HttpContext.Session.GetString("Tipo") != "Admin")
            {
                controller.Request.HttpContext.Response.Redirect("/Usuario/AcessoNegado");
            }
        }
    }
}