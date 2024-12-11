using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BibliotecaDigital.Models
{
    [Table("Comentarios")]
    public class Comentario
    {
        public int ID { get; set; }
        [Required]
        public int UsuarioID { get; set; }
        [Required]
        public int LivroID { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Texto { get; set; }


        public virtual Usuario Usuario { get; set; }
        public virtual Livro Livro { get; set; }
    }
}