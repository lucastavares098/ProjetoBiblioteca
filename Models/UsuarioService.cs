
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca.Models
{
    public class UsuarioService
    {

        public void Inserir(Usuario u)
        {
            using (BibliotecaContext bc = new BibliotecaContext())
            {
                bc.Usuarios.Add(u);
                bc.SaveChanges();
            }
        }
        public void Atualizar(Usuario e)
        {
            using (BibliotecaContext bc = new BibliotecaContext())
            {
                Usuario Usuario = bc.Usuarios.Find(e.usuario_id);
                Usuario.usuario_nome = e.usuario_nome;
                Usuario.usuario_login = e.usuario_login;
                Usuario.usuario_senha = e.usuario_senha;
                Usuario.usuario_tipo = e.usuario_tipo;

                bc.SaveChanges();
            }
        }
        public ICollection<Usuario> ListarTodos(FiltrosUsuario filtro)
        {
            using (BibliotecaContext bc = new BibliotecaContext())
            {
                IQueryable<Usuario> query;

                if (filtro != null)
                {
                    //definindo dinamicamente a filtragem
                    switch (filtro.TipoFiltro)
                    {
                        case "Nome":
                            query = bc.Usuarios.Where(e => e.usuario_nome.Contains(filtro.Filtro));
                            break;

                        case "Login":
                            query = bc.Usuarios.Where(e => e.usuario_login.Contains(filtro.Filtro));
                            break;

                        default:
                            query = bc.Usuarios;
                            break;
                    }
                }
                else
                {
                    // caso filtro não tenha sido informado
                    query = bc.Usuarios;
                }

                //ordenação padrão
                return query.OrderByDescending(e => e.usuario_nome).ToList();
            }
        }

        public List<Usuario> Listar()
        {
            using (BibliotecaContext bc = new BibliotecaContext())
                return bc.Usuarios.ToList();
        }

        public Usuario ObterPorId(int id)
        {
            using (BibliotecaContext bc = new BibliotecaContext())
            {
                return bc.Usuarios.Find(id);
            }
        }
        public void Excluir(int id)
        {
            using (BibliotecaContext bc = new BibliotecaContext())
            {
                var usuario = bc.Usuarios.Find(id);
                if (usuario != null)
                {
                    bc.Usuarios.Remove(usuario);
                    bc.SaveChanges();
                }
            }
        }

        public Usuario ObterPorLoginSenha(string login, string senha)
        {
            senha = Criptografo.TextoCriptografado(senha);
            using (BibliotecaContext bc = new BibliotecaContext())
            {
                return bc.Usuarios.FirstOrDefault(u => u.usuario_login.Equals(login) && u.usuario_senha.Equals(senha));
            }
        }

    }
}