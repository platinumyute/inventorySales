namespace InventorySales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Inventories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        UnitsPurchased = c.Int(nullable: false),
                        UnitsSold = c.Int(nullable: false),
                        PricePaidPerUnit = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        BrandId = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductBrands", t => t.BrandId)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .Index(t => t.CategoryId)
                .Index(t => t.BrandId);
            
            CreateTable(
                "dbo.ProductBrands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inventories", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Products", "BrandId", "dbo.ProductBrands");
            DropIndex("dbo.Products", new[] { "BrandId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.Inventories", new[] { "ProductId" });
            DropTable("dbo.ProductBrands");
            DropTable("dbo.Products");
            DropTable("dbo.Inventories");
            DropTable("dbo.Categories");
        }
    }
}
