namespace GAMEDATAHUB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updateproperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rank", "HeroID", c => c.Int());
            CreateIndex("dbo.Rank", "HeroID");
            AddForeignKey("dbo.Rank", "HeroID", "dbo.Hero", "HeroID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rank", "HeroID", "dbo.Hero");
            DropIndex("dbo.Rank", new[] { "HeroID" });
            DropColumn("dbo.Rank", "HeroID");
        }
    }
}
