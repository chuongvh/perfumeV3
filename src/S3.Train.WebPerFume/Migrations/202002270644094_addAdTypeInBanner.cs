namespace S3.Train.WebPerFume.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAdTypeInBanner : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Banner", "AdType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Banner", "AdType");
        }
    }
}
