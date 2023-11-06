using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Models
{
    public class Usuario
    {
        [Key]
        public int usuario_id { get; set; }
        public string usuario_nome { get; set; }
        public string usuario_login { get; set; }
        public string usuario_senha { get; set; }

        public string usuario_tipo { get; set; }
    }
}