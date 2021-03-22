namespace QuoteBank2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKeyAttempt : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.QuotesTBLs", "AuthorsTBL_AuthID", "dbo.AuthorsTBLs");
            DropIndex("dbo.QuotesTBLs", new[] { "AuthorsTBL_AuthID" });
            RenameColumn(table: "dbo.QuotesTBLs", name: "AuthorsTBL_AuthID", newName: "AuthorsTBLAuthID");
            AlterColumn("dbo.QuotesTBLs", "AuthorsTBLAuthID", c => c.Int(nullable: false));
            CreateIndex("dbo.QuotesTBLs", "AuthorsTBLAuthID");
            AddForeignKey("dbo.QuotesTBLs", "AuthorsTBLAuthID", "dbo.AuthorsTBLs", "AuthID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuotesTBLs", "AuthorsTBLAuthID", "dbo.AuthorsTBLs");
            DropIndex("dbo.QuotesTBLs", new[] { "AuthorsTBLAuthID" });
            AlterColumn("dbo.QuotesTBLs", "AuthorsTBLAuthID", c => c.Int());
            RenameColumn(table: "dbo.QuotesTBLs", name: "AuthorsTBLAuthID", newName: "AuthorsTBL_AuthID");
            CreateIndex("dbo.QuotesTBLs", "AuthorsTBL_AuthID");
            AddForeignKey("dbo.QuotesTBLs", "AuthorsTBL_AuthID", "dbo.AuthorsTBLs", "AuthID");
        }
    }
}
