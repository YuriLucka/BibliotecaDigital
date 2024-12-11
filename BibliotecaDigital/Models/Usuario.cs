using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BibliotecaDigital.Models
{
    [Table("usuarios")]
    public class Usuario
    {
        public int ID { get; set; }
        [Required]
        public string NomeUsuario { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }


        public virtual ICollection<Comentario> Comentarios { get; set; }
        public virtual ICollection<Favorito> LivrosFavoritos { get; set; }
    }
}