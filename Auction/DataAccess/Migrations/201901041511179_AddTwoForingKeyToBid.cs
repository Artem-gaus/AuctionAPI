namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTwoForingKeyToBid : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bids", "ProductId", "dbo.Products");
            AddForeignKey("dbo.Bids", "ProductId", "dbo.Products", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bids", "ProductId", "dbo.Products");
            AddForeignKey("dbo.Bids", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}
