namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Purchase_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Purchases", t => t.Purchase_Id)
                .Index(t => t.Purchase_Id);
            
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PurchaseProduct",
                c => new
                    {
                        PurchaseId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PurchaseId, t.ProductId })
                .ForeignKey("dbo.Purchases", t => t.PurchaseId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.PurchaseId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Purchase_Id", "dbo.Purchases");
            DropForeignKey("dbo.PurchaseProduct", "ProductId", "dbo.Products");
            DropForeignKey("dbo.PurchaseProduct", "PurchaseId", "dbo.Purchases");
            DropIndex("dbo.PurchaseProduct", new[] { "ProductId" });
            DropIndex("dbo.PurchaseProduct", new[] { "PurchaseId" });
            DropIndex("dbo.Products", new[] { "Purchase_Id" });
            DropTable("dbo.PurchaseProduct");
            DropTable("dbo.Purchases");
            DropTable("dbo.Products");
        }
    }
}
