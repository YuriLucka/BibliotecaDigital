namespace BibliotecaDigital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Autors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AutorLivroes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AutorID = c.Int(nullable: false),
                        LivroID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Autors", t => t.AutorID, cascadeDelete: true)
                .ForeignKey("dbo.Livroes", t => t.LivroID, cascadeDelete: true)
                .Index(t => t.AutorID)
                .Index(t => t.LivroID);
            
            CreateTable(
                "dbo.Livroes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
                        Descricao = c.String(),
                        CategoriaID = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categorias", t => t.CategoriaID, cascadeDelete: true)
                .Index(t => t.CategoriaID);
            
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Comentarios",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UsuarioID = c.Int(nullable: false),
                        LivroID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Livroes", t => t.LivroID, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioID, cascadeDelete: true)
                .Index(t => t.UsuarioID)
                .Index(t => t.LivroID);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NomeUsuario = c.String(),
                        Senha = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comentarios", "UsuarioID", "dbo.Usuarios");
            DropForeignKey("dbo.Comentarios", "LivroID", "dbo.Livroes");
            DropForeignKey("dbo.Livroes", "CategoriaID", "dbo.Categorias");
            DropForeignKey("dbo.AutorLivroes", "LivroID", "dbo.Livroes");
            DropForeignKey("dbo.AutorLivroes", "AutorID", "dbo.Autors");
            DropIndex("dbo.Comentarios", new[] { "LivroID" });
            DropIndex("dbo.Comentarios", new[] { "UsuarioID" });
            DropIndex("dbo.Livroes", new[] { "CategoriaID" });
            DropIndex("dbo.AutorLivroes", new[] { "LivroID" });
            DropIndex("dbo.AutorLivroes", new[] { "AutorID" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Comentarios");
            DropTable("dbo.Categorias");
            DropTable("dbo.Livroes");
            DropTable("dbo.AutorLivroes");
            DropTable("dbo.Autors");
        }
    }
}
