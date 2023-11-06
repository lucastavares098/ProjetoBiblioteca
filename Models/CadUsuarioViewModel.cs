using System.Collections.Generic;

namespace Biblioteca.Models
{
    public class CadastroUsuarioModel
    {
        public Usuario Usuario { get; set; }
        public List<string> TiposUsuario { get; set; }
    }
}