namespace GAMEDATAHUB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GObjectItem", "GObjectID", "dbo.GObject");
            DropForeignKey("dbo.GObjectItem", "HeroID", "dbo.Hero");
            DropIndex("dbo.GObjectItem", new[] { "HeroID" });
            DropIndex("dbo.GObjectItem", new[] { "GObjectID" });
            CreateTable(
                "dbo.DividedKills",
                c => new
                    {
                        DividedKillID = c.Int(nullable: false, identity: true),
                        HeroID = c.Int(nullable: false),
                        MultiKills = c.Int(),
                        HeadShotAmount = c.Int(),
                        RoadKills = c.Int(),
                        MeleeKills = c.Int(),
                        VechileKills = c.Int(),
                        GrenadesKills = c.Int(),
                        HipfireKills = c.Int(),
                        AIKills = c.Int(),
                        HumanKills = c.Int(),
                        ScopedKills = c.Int(),
                    })
                .PrimaryKey(t => t.DividedKillID)
                .ForeignKey("dbo.Hero", t => t.HeroID, cascadeDelete: true)
                .Index(t => t.HeroID);
            
            AddColumn("dbo.GObject", "HeroID", c => c.Int(nullable: false));
            AddColumn("dbo.GObject", "ObjectTotal", c => c.Int());
            AddColumn("dbo.GObject", "AttackedTotal", c => c.Int());
            AddColumn("dbo.GObject", "DefendedTotal", c => c.Int());
            AddColumn("dbo.GObject", "Defused", c => c.Int());
            AddColumn("dbo.GObject", "AttackedSector", c => c.Int());
            AddColumn("dbo.GObject", "DefendedSector", c => c.Int());
            CreateIndex("dbo.GObject", "HeroID");
            AddForeignKey("dbo.GObject", "HeroID", "dbo.Hero", "HeroID", cascadeDelete: true);
            DropColumn("dbo.GObject", "HerolD");
            DropTable("dbo.GObjectItem");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.GObjectItem",
                c => new
                    {
                        GObjectItemId = c.Int(nullable: false, identity: true),
                        HeroID = c.Int(nullable: false),
                        GObjectID = c.Int(nullable: false),
                        Total = c.Int(),
                        Attacked = c.Int(),
                        Defended = c.Int(),
                    })
                .PrimaryKey(t => t.GObjectItemId);
            
            AddColumn("dbo.GObject", "HerolD", c => c.Int(nullable: false));
            DropForeignKey("dbo.GObject", "HeroID", "dbo.Hero");
            DropForeignKey("dbo.DividedKills", "HeroID", "dbo.Hero");
            DropIndex("dbo.GObject", new[] { "HeroID" });
            DropIndex("dbo.DividedKills", new[] { "HeroID" });
            DropColumn("dbo.GObject", "DefendedSector");
            DropColumn("dbo.GObject", "AttackedSector");
            DropColumn("dbo.GObject", "Defused");
            DropColumn("dbo.GObject", "DefendedTotal");
            DropColumn("dbo.GObject", "AttackedTotal");
            DropColumn("dbo.GObject", "ObjectTotal");
            DropColumn("dbo.GObject", "HeroID");
            DropTable("dbo.DividedKills");
            CreateIndex("dbo.GObjectItem", "GObjectID");
            CreateIndex("dbo.GObjectItem", "HeroID");
            AddForeignKey("dbo.GObjectItem", "HeroID", "dbo.Hero", "HeroID");
            AddForeignKey("dbo.GObjectItem", "GObjectID", "dbo.GObject", "GObjectID", cascadeDelete: true);
        }
    }
}
