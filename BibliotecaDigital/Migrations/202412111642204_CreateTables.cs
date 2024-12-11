namespace BibliotecaDigital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Livroes", "NumeroDePaginas", c => c.Int(nullable: false));
            AddColumn("dbo.Livroes", "PaginaAtual", c => c.Int());
            AddColumn("dbo.Comentarios", "Texto", c => c.String(nullable: false));
            AlterColumn("dbo.Autors", "Nome", c => c.String(nullable: false));
            AlterColumn("dbo.Livroes", "Titulo", c => c.String(nullable: false));
            AlterColumn("dbo.Livroes", "Descricao", c => c.String(nullable: false));
            AlterColumn("dbo.Categorias", "Nome", c => c.String(nullable: false));
            AlterColumn("dbo.Usuarios", "NomeUsuario", c => c.String(nullable: false));
            AlterColumn("dbo.Usuarios", "Senha", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Usuarios", "Senha", c => c.String());
            AlterColumn("dbo.Usuarios", "NomeUsuario", c => c.String());
            AlterColumn("dbo.Categorias", "Nome", c => c.String());
            AlterColumn("dbo.Livroes", "Descricao", c => c.String());
            AlterColumn("dbo.Livroes", "Titulo", c => c.String());
            AlterColumn("dbo.Autors", "Nome", c => c.String());
            DropColumn("dbo.Comentarios", "Texto");
            DropColumn("dbo.Livroes", "PaginaAtual");
            DropColumn("dbo.Livroes", "NumeroDePaginas");
        }
    }
}
