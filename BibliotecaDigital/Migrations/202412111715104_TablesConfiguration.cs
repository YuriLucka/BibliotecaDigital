namespace BibliotecaDigital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TablesConfiguration : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Autors", newName: "Autores");
            RenameTable(name: "dbo.Livroes", newName: "Livros");
            DropForeignKey("dbo.AutorLivroes", "AutorID", "dbo.Autors");
            DropForeignKey("dbo.AutorLivroes", "LivroID", "dbo.Livroes");
            DropIndex("dbo.AutorLivroes", new[] { "AutorID" });
            DropIndex("dbo.AutorLivroes", new[] { "LivroID" });
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
            
            AddColumn("dbo.Livros", "AutorID", c => c.Int(nullable: false));
            AddColumn("dbo.Livros", "NumeroDePaginas", c => c.Int(nullable: false));
            AddColumn("dbo.Livros", "PaginaAtual", c => c.Int());
            AddColumn("dbo.Comentarios", "Texto", c => c.String(nullable: false));
            AlterColumn("dbo.Autores", "Nome", c => c.String(nullable: false));
            AlterColumn("dbo.Livros", "Titulo", c => c.String(nullable: false));
            AlterColumn("dbo.Livros", "Descricao", c => c.String(nullable: false));
            AlterColumn("dbo.Categorias", "Nome", c => c.String(nullable: false));
            AlterColumn("dbo.usuarios", "NomeUsuario", c => c.String(nullable: false));
            AlterColumn("dbo.usuarios", "Senha", c => c.String(nullable: false));
            CreateIndex("dbo.Livros", "AutorID");
            AddForeignKey("dbo.Livros", "AutorID", "dbo.Autores", "ID", cascadeDelete: true);
            DropTable("dbo.AutorLivroes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AutorLivroes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AutorID = c.Int(nullable: false),
                        LivroID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            DropForeignKey("dbo.Favoritos", "UsuarioID", "dbo.usuarios");
            DropForeignKey("dbo.Favoritos", "LivroID", "dbo.Livros");
            DropForeignKey("dbo.Livros", "AutorID", "dbo.Autores");
            DropIndex("dbo.Favoritos", new[] { "LivroID" });
            DropIndex("dbo.Favoritos", new[] { "UsuarioID" });
            DropIndex("dbo.Livros", new[] { "AutorID" });
            AlterColumn("dbo.usuarios", "Senha", c => c.String());
            AlterColumn("dbo.usuarios", "NomeUsuario", c => c.String());
            AlterColumn("dbo.Categorias", "Nome", c => c.String());
            AlterColumn("dbo.Livros", "Descricao", c => c.String());
            AlterColumn("dbo.Livros", "Titulo", c => c.String());
            AlterColumn("dbo.Autores", "Nome", c => c.String());
            DropColumn("dbo.Comentarios", "Texto");
            DropColumn("dbo.Livros", "PaginaAtual");
            DropColumn("dbo.Livros", "NumeroDePaginas");
            DropColumn("dbo.Livros", "AutorID");
            DropTable("dbo.Favoritos");
            CreateIndex("dbo.AutorLivroes", "LivroID");
            CreateIndex("dbo.AutorLivroes", "AutorID");
            AddForeignKey("dbo.AutorLivroes", "LivroID", "dbo.Livroes", "ID", cascadeDelete: true);
            AddForeignKey("dbo.AutorLivroes", "AutorID", "dbo.Autors", "ID", cascadeDelete: true);
            RenameTable(name: "dbo.Livros", newName: "Livroes");
            RenameTable(name: "dbo.Autores", newName: "Autors");
        }
    }
}
