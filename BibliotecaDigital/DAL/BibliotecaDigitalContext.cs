using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using BibliotecaDigital.Models;

namespace BibliotecaDigital.DAL
{
    public class BibliotecaDigitalContext : DbContext
    {
        public BibliotecaDigitalContext() : base("BibliotecaDigitalContext") { }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

    }
}