using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BibliotecaDigital.Models
{
    [Table("AutoresLivros")]
    public class AutorLivro
    {
        public int ID { get; set; }
        [Required]
        public int AutorID { get; set; }
        [Required]
        public int LivroID { get; set; }
        public virtual Autor Autor { get; set; }
        public virtual Livro Livro { get; set; }

    }
}