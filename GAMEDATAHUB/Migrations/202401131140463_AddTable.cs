namespace GAMEDATAHUB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        HeroID = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 255),
                        UserEmail = c.String(nullable: false, maxLength: 255),
                        UserHashedPassword = c.String(nullable: false, maxLength: 255),
                        UserSalt = c.String(nullable: false, maxLength: 255),
                        IsPremium = c.Boolean(nullable: false),
                        CreateTime = c.DateTime(),
                        DeleteTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Hero", t => t.HeroID, cascadeDelete: true)
                .Index(t => t.HeroID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "HeroID", "dbo.Hero");
            DropIndex("dbo.User", new[] { "HeroID" });
            DropTable("dbo.User");
        }
    }
}
