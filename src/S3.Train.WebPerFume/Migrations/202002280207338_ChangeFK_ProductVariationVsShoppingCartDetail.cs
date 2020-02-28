namespace S3.Train.WebPerFume.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeFK_ProductVariationVsShoppingCartDetail : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductVariation", "Id", "dbo.ShoppingCartDetail");
            DropIndex("dbo.ProductVariation", new[] { "Id" });
            AddColumn("dbo.ShoppingCartDetail", "ProductVariation_Id", c => c.Guid(nullable: false));
            CreateIndex("dbo.ShoppingCartDetail", "ProductVariation_Id");
            AddForeignKey("dbo.ShoppingCartDetail", "ProductVariation_Id", "dbo.ProductVariation", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShoppingCartDetail", "ProductVariation_Id", "dbo.ProductVariation");
            DropIndex("dbo.ShoppingCartDetail", new[] { "ProductVariation_Id" });
            DropColumn("dbo.ShoppingCartDetail", "ProductVariation_Id");
            CreateIndex("dbo.ProductVariation", "Id");
            AddForeignKey("dbo.ProductVariation", "Id", "dbo.ShoppingCartDetail", "Id");
        }
    }
}
