namespace BibliotecaDigital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterTableLivro : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Livros", "UrlCapa", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Livros", "UrlCapa", c => c.Int(nullable: false));
        }
    }
}
