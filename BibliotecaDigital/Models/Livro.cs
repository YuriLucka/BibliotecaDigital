using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BibliotecaDigital.Models
{
    public enum StatusLivro
    {
        LeituraFutura,
        EmAndamento,
        JaLido,
    }
    [Table("Livros")]
    public class Livro
    {
        public int ID { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Descricao { get; set; }
        [Required]
        public int CategoriaID { get; set; }
        [Required]
        public int AutorID { get; set; }
        [Required]
        public StatusLivro Status { get; set; }
        [Required]
        public int NumeroDePaginas { get; set; }
        public int? PaginaAtual { get; set; }



        public virtual Categoria Categoria { get; set; }
        public virtual Autor Autor { get; set; }
        public virtual ICollection<Comentario> Comentarios { get; set; }

    }
}