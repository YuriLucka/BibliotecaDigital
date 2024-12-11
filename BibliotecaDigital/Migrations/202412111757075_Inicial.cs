namespace BibliotecaDigital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Autores",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Livros",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Titulo = c.String(nullable: false),
                        Descricao = c.String(nullable: false),
                        CategoriaID = c.Int(nullable: false),
                        AutorID = c.Int(nullable: false),
                        UrlCapa = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        NumeroDePaginas = c.Int(nullable: false),
                        PaginaAtual = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Autores", t => t.AutorID, cascadeDelete: true)
                .ForeignKey("dbo.Categorias", t => t.CategoriaID, cascadeDelete: true)
                .Index(t => t.CategoriaID)
                .Index(t => t.AutorID);
            
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Comentarios",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UsuarioID = c.Int(nullable: false),
                        LivroID = c.Int(nullable: false),
                        Texto = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Livros", t => t.LivroID, cascadeDelete: true)
                .ForeignKey("dbo.usuarios", t => t.UsuarioID, cascadeDelete: true)
                .Index(t => t.UsuarioID)
                .Index(t => t.LivroID);
            
            CreateTable(
                "dbo.usuarios",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NomeUsuario = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Favoritos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UsuarioID = c.Int(nullable: false),
                        LivroID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Livros", t => t.LivroID, cascadeDelete: true)
                .ForeignKey("dbo.usuarios", t => t.UsuarioID, cascadeDelete: true)
                .Index(t => t.UsuarioID)
                .Index(t => t.LivroID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Favoritos", "UsuarioID", "dbo.usuarios");
            DropForeignKey("dbo.Favoritos", "LivroID", "dbo.Livros");
            DropForeignKey("dbo.Comentarios", "UsuarioID", "dbo.usuarios");
            DropForeignKey("dbo.Comentarios", "LivroID", "dbo.Livros");
            DropForeignKey("dbo.Livros", "CategoriaID", "dbo.Categorias");
            DropForeignKey("dbo.Livros", "AutorID", "dbo.Autores");
            DropIndex("dbo.Favoritos", new[] { "LivroID" });
            DropIndex("dbo.Favoritos", new[] { "UsuarioID" });
            DropIndex("dbo.Comentarios", new[] { "LivroID" });
            DropIndex("dbo.Comentarios", new[] { "UsuarioID" });
            DropIndex("dbo.Livros", new[] { "AutorID" });
            DropIndex("dbo.Livros", new[] { "CategoriaID" });
            DropTable("dbo.Favoritos");
            DropTable("dbo.usuarios");
            DropTable("dbo.Comentarios");
            DropTable("dbo.Categorias");
            DropTable("dbo.Livros");
            DropTable("dbo.Autores");
        }
    }
}
