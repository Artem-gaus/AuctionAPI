namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AttachDataAnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Customers", "Surname", c => c.String(maxLength: 255));
            AlterColumn("dbo.Customers", "Email", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Products", "Title", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Producers", "Title", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.ProductCategories", "Title", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Sellers", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Sellers", "Surname", c => c.String(maxLength: 255));
            AlterColumn("dbo.Sellers", "Email", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sellers", "Email", c => c.String());
            AlterColumn("dbo.Sellers", "Surname", c => c.String());
            AlterColumn("dbo.Sellers", "Name", c => c.String());
            AlterColumn("dbo.ProductCategories", "Title", c => c.String());
            AlterColumn("dbo.Producers", "Title", c => c.String());
            AlterColumn("dbo.Products", "Title", c => c.String());
            AlterColumn("dbo.Customers", "Email", c => c.String());
            AlterColumn("dbo.Customers", "Surname", c => c.String());
            AlterColumn("dbo.Customers", "Name", c => c.String());
        }
    }
}
