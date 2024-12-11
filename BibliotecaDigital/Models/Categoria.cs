using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BibliotecaDigital.Models
{
    public class Categoria
    {
        public int ID { get; set; }
        [Required]
        public string Nome { get; set; }

        public virtual ICollection<Livro> Livros { get; set; }
    }
}