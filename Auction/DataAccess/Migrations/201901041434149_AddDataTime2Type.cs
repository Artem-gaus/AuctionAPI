namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataTime2Type : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bids", "TimeOfBit", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Products", "PublicationDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Products", "EndDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Products", "PublicationDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Bids", "TimeOfBit", c => c.DateTime(nullable: false));
        }
    }
}
