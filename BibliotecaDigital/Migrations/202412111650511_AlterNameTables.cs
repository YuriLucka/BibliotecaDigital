namespace BibliotecaDigital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterNameTables : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Autors", newName: "Autores");
            RenameTable(name: "dbo.AutorLivroes", newName: "AutoresLivros");
            RenameTable(name: "dbo.Livroes", newName: "Livros");
            RenameTable(name: "dbo.Favoritoes", newName: "Favoritos");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Favoritos", newName: "Favoritoes");
            RenameTable(name: "dbo.Livros", newName: "Livroes");
            RenameTable(name: "dbo.AutoresLivros", newName: "AutorLivroes");
            RenameTable(name: "dbo.Autores", newName: "Autors");
        }
    }
}
