namespace QuoteBank2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReNullifyQuotesTBL : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.QuotesTBLs", "Quote", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.QuotesTBLs", "Quote", c => c.String(nullable: false));
        }
    }
}
