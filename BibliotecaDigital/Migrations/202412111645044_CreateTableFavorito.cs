namespace BibliotecaDigital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableFavorito : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Favoritoes",
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Favoritoes", "UsuarioID", "dbo.Usuarios");
            DropForeignKey("dbo.Favoritoes", "LivroID", "dbo.Livroes");
            DropIndex("dbo.Favoritoes", new[] { "LivroID" });
            DropIndex("dbo.Favoritoes", new[] { "UsuarioID" });
            DropTable("dbo.Favoritoes");
        }
    }
}
