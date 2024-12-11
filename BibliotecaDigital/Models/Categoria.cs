using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BibliotecaDigital.Models
{
    [Table("Categorias")]
    public class Categoria
    {
        public int ID { get; set; }
        [Required]
        public string Nome { get; set; }

        public virtual ICollection<Livro> Livros { get; set; }
    }
}