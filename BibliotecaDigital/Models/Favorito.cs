using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BibliotecaDigital.Models
{
    [Table("Favoritos")]
    public class Favorito
    {
        public int ID { get; set; }
        public int UsuarioID { get; set; }
        public int LivroID { get; set; }

        public Usuario Usuario { get; set; }
        public Livro Livro { get; set; }
    }
}