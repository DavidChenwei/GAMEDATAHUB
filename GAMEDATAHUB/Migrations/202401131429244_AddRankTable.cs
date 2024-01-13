namespace GAMEDATAHUB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRankTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.User", "HeroID", "dbo.Hero");
            DropIndex("dbo.User", new[] { "HeroID" });
            CreateTable(
                "dbo.Rank",
                c => new
                    {
                        RankID = c.Int(nullable: false, identity: true),
                        KDRank = c.Decimal(nullable: false, precision: 10, scale: 2),
                        HSRank = c.Decimal(nullable: false, precision: 10, scale: 2),
                        WinPercentRank = c.Decimal(nullable: false, precision: 10, scale: 2),
                        HumanKDRank = c.Decimal(nullable: false, precision: 10, scale: 2),
                        DeathRank = c.Decimal(nullable: false, precision: 10, scale: 2),
                        KPMRank = c.Decimal(nullable: false, precision: 10, scale: 2),
                        KPMatchRank = c.Decimal(nullable: false, precision: 10, scale: 2),
                        WinRank = c.Decimal(nullable: false, precision: 10, scale: 2),
                        LostRank = c.Decimal(nullable: false, precision: 10, scale: 2),
                        DamageRank = c.Decimal(nullable: false, precision: 10, scale: 2),
                        DPMRank = c.Decimal(nullable: false, precision: 10, scale: 2),
                        VehiclesDestroyedRank = c.Decimal(nullable: false, precision: 10, scale: 2),
                        HSAmountRank = c.Decimal(nullable: false, precision: 10, scale: 2),
                        RoadKillRank = c.Decimal(nullable: false, precision: 10, scale: 2),
                        MeleeKillRank = c.Decimal(nullable: false, precision: 10, scale: 2),
                        VehicleKillRank = c.Decimal(nullable: false, precision: 10, scale: 2),
                        ScopedKillRank = c.Decimal(nullable: false, precision: 10, scale: 2),
                        HipfireKillRank = c.Decimal(nullable: false, precision: 10, scale: 2),
                        HumanKillRank = c.Decimal(nullable: false, precision: 10, scale: 2),
                        AIKillRank = c.Decimal(nullable: false, precision: 10, scale: 2),
                        ObjectiveTimeRank = c.Decimal(nullable: false, precision: 10, scale: 2),
                        DisarmedObjectRank = c.Decimal(nullable: false, precision: 10, scale: 2),
                        CapturedObjectiRank = c.Decimal(nullable: false, precision: 10, scale: 2),
                        ObjectivesDeutralizeRank = c.Decimal(nullable: false, precision: 10, scale: 2),
                        SectorsDefendeRank = c.Decimal(nullable: false, precision: 10, scale: 2),
                        SectorsCapturedRank = c.Decimal(nullable: false, precision: 10, scale: 2),
                        AttackedObjectRank = c.Decimal(nullable: false, precision: 10, scale: 2),
                    })
                .PrimaryKey(t => t.RankID);
            
            AlterColumn("dbo.User", "HeroID", c => c.Int());
            CreateIndex("dbo.User", "HeroID");
            AddForeignKey("dbo.User", "HeroID", "dbo.Hero", "HeroID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "HeroID", "dbo.Hero");
            DropIndex("dbo.User", new[] { "HeroID" });
            AlterColumn("dbo.User", "HeroID", c => c.Int(nullable: false));
            DropTable("dbo.Rank");
            CreateIndex("dbo.User", "HeroID");
            AddForeignKey("dbo.User", "HeroID", "dbo.Hero", "HeroID", cascadeDelete: true);
        }
    }
}
