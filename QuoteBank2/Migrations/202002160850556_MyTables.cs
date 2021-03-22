namespace QuoteBank2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuthorsTBLs",
                c => new
                    {
                        AuthID = c.Int(nullable: false, identity: true),
                        AuthorName = c.String(),
                        AuthorImage = c.String(),
                    })
                .PrimaryKey(t => t.AuthID);
            
            CreateTable(
                "dbo.QuotesTBLs",
                c => new
                    {
                        QuoteID = c.Int(nullable: false, identity: true),
                        Quote = c.String(),
                        AuthorsTBL_AuthID = c.Int(),
                    })
                .PrimaryKey(t => t.QuoteID)
                .ForeignKey("dbo.AuthorsTBLs", t => t.AuthorsTBL_AuthID)
                .Index(t => t.AuthorsTBL_AuthID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuotesTBLs", "AuthorsTBL_AuthID", "dbo.AuthorsTBLs");
            DropIndex("dbo.QuotesTBLs", new[] { "AuthorsTBL_AuthID" });
            DropTable("dbo.QuotesTBLs");
            DropTable("dbo.AuthorsTBLs");
        }
    }
}
