namespace QuoteBank2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeQuoteRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.QuotesTBLs", "Quote", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.QuotesTBLs", "Quote", c => c.String());
        }
    }
}
