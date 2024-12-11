using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BibliotecaDigital.Models
{
    public class Autor
    {
        public int ID { get; set; }
        [Required]
        public string Nome { get; set; }

        public virtual ICollection<AutorLivro> AutorLivros { get; set; }

    }
}