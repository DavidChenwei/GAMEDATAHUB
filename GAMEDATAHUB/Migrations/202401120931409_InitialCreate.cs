namespace GAMEDATAHUB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Gadget",
                c => new
                    {
                        GadgetID = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false, maxLength: 50),
                        GadgetName = c.String(nullable: false, maxLength: 50),
                        Image = c.String(nullable: false, maxLength: 255),
                        Id = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.GadgetID);
            
            CreateTable(
                "dbo.GadgetItem",
                c => new
                    {
                        GadgetItemId = c.Int(nullable: false, identity: true),
                        GadgetID = c.Int(nullable: false),
                        HeroID = c.Int(nullable: false),
                        Kills = c.Int(),
                        Spawns = c.Int(),
                        Damage = c.Int(),
                        Uses = c.Int(),
                        Multikills = c.Int(),
                        VehiclesDestroyedWith = c.Int(),
                        KPM = c.Decimal(precision: 10, scale: 2),
                        DPM = c.Decimal(precision: 10, scale: 2),
                        SecondsPlayed = c.Int(),
                    })
                .PrimaryKey(t => t.GadgetItemId)
                .ForeignKey("dbo.Hero", t => t.HeroID)
                .ForeignKey("dbo.Gadget", t => t.GadgetID)
                .Index(t => t.GadgetID)
                .Index(t => t.HeroID);
            
            CreateTable(
                "dbo.Hero",
                c => new
                    {
                        HeroID = c.Int(nullable: false, identity: true),
                        UserID = c.String(nullable: false, maxLength: 50),
                        Avatar = c.String(nullable: false, maxLength: 255),
                        UserName = c.String(nullable: false, maxLength: 50),
                        Id = c.String(nullable: false, maxLength: 50),
                        PlatForm = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.HeroID);
            
            CreateTable(
                "dbo.GameModeItem",
                c => new
                    {
                        GameModeItemId = c.Int(nullable: false, identity: true),
                        GameModeID = c.Int(nullable: false),
                        HeroID = c.Int(nullable: false),
                        Kills = c.Int(),
                        Assists = c.Int(),
                        Revives = c.Int(),
                        BestSquad = c.Int(),
                        Wins = c.Int(),
                        Losses = c.Int(),
                        Mvp = c.Int(),
                        Matches = c.Int(),
                        SectorDefend = c.Int(),
                        ObjectivesArmed = c.Int(),
                        ObjectivesDisarmed = c.Int(),
                        ObjectivesDefended = c.Int(),
                        ObjectivesDestroyed = c.Int(),
                        ObjetiveTime = c.Int(),
                        KPM = c.Decimal(precision: 10, scale: 2),
                        WinPercent = c.Decimal(precision: 10, scale: 2),
                        SecondsPlayed = c.Int(),
                    })
                .PrimaryKey(t => t.GameModeItemId)
                .ForeignKey("dbo.GameMode", t => t.GameModeID)
                .ForeignKey("dbo.Hero", t => t.HeroID)
                .Index(t => t.GameModeID)
                .Index(t => t.HeroID);
            
            CreateTable(
                "dbo.GameMode",
                c => new
                    {
                        GameModeID = c.Int(nullable: false, identity: true),
                        GamemodeName = c.String(nullable: false, maxLength: 50),
                        Images = c.String(nullable: false, maxLength: 255),
                        Id = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.GameModeID);
            
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
                .PrimaryKey(t => t.GObjectItemId)
                .ForeignKey("dbo.GObject", t => t.GObjectID, cascadeDelete: true)
                .ForeignKey("dbo.Hero", t => t.HeroID)
                .Index(t => t.HeroID)
                .Index(t => t.GObjectID);
            
            CreateTable(
                "dbo.GObject",
                c => new
                    {
                        GObjectID = c.Int(nullable: false, identity: true),
                        HerolD = c.Int(nullable: false),
                        Armed = c.Int(),
                        Captured = c.Int(),
                        Neutralized = c.Int(),
                        Destroyed = c.Int(),
                    })
                .PrimaryKey(t => t.GObjectID);
            
            CreateTable(
                "dbo.HeroOverView",
                c => new
                    {
                        HeroOverViewId = c.Int(nullable: false, identity: true),
                        HeroID = c.Int(nullable: false),
                        BestClass = c.String(nullable: false, maxLength: 20),
                        HumanPercentage = c.Decimal(precision: 10, scale: 2),
                        Kills = c.Int(),
                        Deaths = c.Int(),
                        Wins = c.Int(),
                        Losses = c.Int(),
                        KillsPerMinute = c.Decimal(precision: 10, scale: 2),
                        DamagePerMinute = c.Decimal(precision: 10, scale: 2),
                        KillsPerMatch = c.Decimal(precision: 10, scale: 2),
                        DamagePerMatch = c.Decimal(precision: 10, scale: 2),
                        HeadShots = c.Int(),
                        WinPercent = c.Decimal(precision: 10, scale: 2),
                        HeadShotrate = c.Decimal(precision: 10, scale: 2),
                        KillDeath = c.Decimal(precision: 10, scale: 2),
                        InfantryKillDeath = c.Decimal(precision: 10, scale: 2),
                        Damage = c.Int(),
                        TimePlayed = c.String(nullable: false, maxLength: 30),
                        Accuracy = c.Decimal(precision: 10, scale: 2),
                        Revives = c.Int(),
                        Heals = c.Int(),
                        Resupplies = c.Int(),
                        Repairs = c.Int(),
                        SquadmateRevive = c.Int(),
                        SquadmateRespawn = c.Int(),
                        ThrownThrowables = c.Int(),
                        GadgetsDestoyed = c.Int(),
                        CallIns = c.Int(),
                        PlayerTakeDowns = c.Int(),
                        MatchesPlayed = c.Int(),
                        SecondsPlayed = c.Int(),
                        BestSquad = c.Int(),
                        TeammatesSupported = c.Int(),
                        SaviorKills = c.Int(),
                        ShotsFired = c.Int(),
                        ShotsHit = c.Int(),
                        KillAssists = c.Int(),
                        VehiclesDestroyed = c.Int(),
                        EnemiesSpotted = c.Int(),
                        Mvp = c.Int(),
                    })
                .PrimaryKey(t => t.HeroOverViewId)
                .ForeignKey("dbo.Hero", t => t.HeroID, cascadeDelete: true)
                .Index(t => t.HeroID);
            
            CreateTable(
                "dbo.MapItem",
                c => new
                    {
                        MapItemId = c.Int(nullable: false, identity: true),
                        MapID = c.Int(nullable: false),
                        HeroID = c.Int(nullable: false),
                        Wins = c.Int(),
                        Losses = c.Int(),
                        Matches = c.Int(),
                        WinPercent = c.Decimal(precision: 10, scale: 2),
                        SecondsPlayed = c.Int(),
                    })
                .PrimaryKey(t => t.MapItemId)
                .ForeignKey("dbo.Map", t => t.MapID)
                .ForeignKey("dbo.Hero", t => t.HeroID)
                .Index(t => t.MapID)
                .Index(t => t.HeroID);
            
            CreateTable(
                "dbo.Map",
                c => new
                    {
                        MapID = c.Int(nullable: false, identity: true),
                        MapName = c.String(nullable: false, maxLength: 50),
                        Image = c.String(nullable: false, maxLength: 255),
                        Id = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.MapID);
            
            CreateTable(
                "dbo.Ribbon",
                c => new
                    {
                        RibbonID = c.Int(nullable: false, identity: true),
                        HeroID = c.Int(nullable: false),
                        Total = c.Int(),
                        Squad = c.Int(),
                        Combat = c.Int(),
                        Intel = c.Int(),
                        Objective = c.Int(),
                        Support = c.Int(),
                    })
                .PrimaryKey(t => t.RibbonID)
                .ForeignKey("dbo.Hero", t => t.HeroID, cascadeDelete: true)
                .Index(t => t.HeroID);
            
            CreateTable(
                "dbo.SpecialistItem",
                c => new
                    {
                        SpecialistItemID = c.Int(nullable: false, identity: true),
                        SpecialistID = c.Int(nullable: false),
                        HeroID = c.Int(nullable: false),
                        Kills = c.Int(),
                        Deaths = c.Int(),
                        KMP = c.Decimal(precision: 10, scale: 2),
                        Spawns = c.Int(),
                        KillDeath = c.Decimal(precision: 10, scale: 2),
                        Revives = c.Int(),
                        Assists = c.Int(),
                        HazardZoneStreaks = c.Int(),
                        SecondsPlayed = c.Int(),
                    })
                .PrimaryKey(t => t.SpecialistItemID)
                .ForeignKey("dbo.Specialist", t => t.SpecialistID)
                .ForeignKey("dbo.Hero", t => t.HeroID)
                .Index(t => t.SpecialistID)
                .Index(t => t.HeroID);
            
            CreateTable(
                "dbo.Specialist",
                c => new
                    {
                        SpecialistID = c.Int(nullable: false, identity: true),
                        ClassName = c.String(nullable: false, maxLength: 50),
                        CharacterName = c.String(nullable: false, maxLength: 50),
                        StatName = c.String(nullable: false, maxLength: 50),
                        Image = c.String(nullable: false, maxLength: 255),
                        AvatarImage1 = c.String(nullable: false, maxLength: 255),
                        AvatarImage2 = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.SpecialistID);
            
            CreateTable(
                "dbo.VehicleGroup",
                c => new
                    {
                        VehicleGroupID = c.Int(nullable: false, identity: true),
                        HeroID = c.Int(nullable: false),
                        Type = c.String(nullable: false, maxLength: 50),
                        VehicleName = c.String(nullable: false, maxLength: 50),
                        Image = c.String(nullable: false, maxLength: 50),
                        Id = c.String(nullable: false, maxLength: 50),
                        Kills = c.Int(),
                        Damage = c.Int(),
                        Roadkills = c.Int(),
                        Spawns = c.Int(),
                        DriverAssists = c.Int(),
                        PassengerAssists = c.Int(),
                        MultiKills = c.Int(),
                        DistanceTraveled = c.Int(),
                        KillsPerMinute = c.Decimal(precision: 10, scale: 2),
                        VehiclesDestroyedWith = c.Int(),
                        Assists = c.Int(),
                        CallIns = c.Int(),
                        DamageTo = c.Int(),
                        Destroyed = c.Int(),
                        Timeln = c.Int(),
                    })
                .PrimaryKey(t => t.VehicleGroupID)
                .ForeignKey("dbo.Hero", t => t.HeroID)
                .Index(t => t.HeroID);
            
            CreateTable(
                "dbo.VehicleItem",
                c => new
                    {
                        VehicleItemId = c.Int(nullable: false, identity: true),
                        VehicleID = c.Int(nullable: false),
                        HeroID = c.Int(nullable: false),
                        Kills = c.Int(),
                        Damage = c.Int(),
                        Roadkills = c.Int(),
                        Spawns = c.Int(),
                        DriverAssists = c.Int(),
                        PassengerAssists = c.Int(),
                        Multikills = c.Int(),
                        DistanceTraveled = c.Int(),
                        KillsPerMinute = c.Decimal(precision: 10, scale: 2),
                        VehiclesDestroyedWith = c.Int(),
                        Assists = c.Int(),
                        Callins = c.Int(),
                        DamageTo = c.Int(),
                        Destroyed = c.Int(),
                        Timeln = c.Int(),
                    })
                .PrimaryKey(t => t.VehicleItemId)
                .ForeignKey("dbo.Vehicle", t => t.VehicleID)
                .ForeignKey("dbo.Hero", t => t.HeroID)
                .Index(t => t.VehicleID)
                .Index(t => t.HeroID);
            
            CreateTable(
                "dbo.Vehicle",
                c => new
                    {
                        VehicleID = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false, maxLength: 50),
                        VehicleName = c.String(nullable: false, maxLength: 50),
                        Image = c.String(nullable: false, maxLength: 255),
                        ID = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.VehicleID);
            
            CreateTable(
                "dbo.WeaponGroup",
                c => new
                    {
                        WeaponGroupID = c.Int(nullable: false, identity: true),
                        HeroID = c.Int(nullable: false),
                        Type = c.String(nullable: false, maxLength: 50),
                        GroupName = c.String(nullable: false, maxLength: 50),
                        Id = c.String(nullable: false, maxLength: 50),
                        Kills = c.Int(),
                        Damage = c.Int(),
                        BodyKills = c.Int(),
                        HeadshotKills = c.Int(),
                        HipfireKills = c.Int(),
                        MultiKills = c.Int(),
                        Accuracy = c.Decimal(precision: 10, scale: 2),
                        KillsPerMinute = c.Decimal(precision: 10, scale: 2),
                        DamagePerMinute = c.Decimal(precision: 10, scale: 2),
                        Headshots = c.Decimal(precision: 10, scale: 2),
                        HitVKills = c.Decimal(precision: 10, scale: 2),
                        ShotsHit = c.Int(),
                        ShotsFired = c.Int(),
                        Spawns = c.Int(),
                        TimeEquipped = c.Int(),
                    })
                .PrimaryKey(t => t.WeaponGroupID)
                .ForeignKey("dbo.Hero", t => t.HeroID)
                .Index(t => t.HeroID);
            
            CreateTable(
                "dbo.WeaponItem",
                c => new
                    {
                        WeaponItemId = c.Int(nullable: false, identity: true),
                        WeaponID = c.Int(nullable: false),
                        HeroID = c.Int(nullable: false),
                        Kills = c.Int(),
                        Damage = c.Int(),
                        BodyKills = c.Int(),
                        HeadshotKills = c.Int(),
                        HipfireKills = c.Int(),
                        MultiKills = c.Int(),
                        Accuracy = c.Decimal(precision: 10, scale: 2),
                        KillsPerMinute = c.Decimal(precision: 10, scale: 2),
                        DamagePerMinute = c.Decimal(precision: 10, scale: 2),
                        Headshots = c.Decimal(precision: 10, scale: 2),
                        HitVKills = c.Decimal(precision: 10, scale: 2),
                        ShotsHit = c.Int(),
                        ShotsFired = c.Int(),
                        Spawns = c.Int(),
                        TimeEquipped = c.Int(),
                    })
                .PrimaryKey(t => t.WeaponItemId)
                .ForeignKey("dbo.Weapon", t => t.WeaponID)
                .ForeignKey("dbo.Hero", t => t.HeroID)
                .Index(t => t.WeaponID)
                .Index(t => t.HeroID);
            
            CreateTable(
                "dbo.Weapon",
                c => new
                    {
                        WeaponID = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false, maxLength: 50),
                        WeaponName = c.String(nullable: false, maxLength: 50),
                        Image = c.String(nullable: false, maxLength: 255),
                        Id = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.WeaponID);
            
            CreateTable(
                "dbo.XP",
                c => new
                    {
                        XPId = c.Int(nullable: false, identity: true),
                        HeroID = c.Int(nullable: false),
                        Total = c.Int(),
                        Performance = c.Int(),
                    })
                .PrimaryKey(t => t.XPId)
                .ForeignKey("dbo.Hero", t => t.HeroID, cascadeDelete: true)
                .Index(t => t.HeroID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GadgetItem", "GadgetID", "dbo.Gadget");
            DropForeignKey("dbo.XP", "HeroID", "dbo.Hero");
            DropForeignKey("dbo.WeaponItem", "HeroID", "dbo.Hero");
            DropForeignKey("dbo.WeaponItem", "WeaponID", "dbo.Weapon");
            DropForeignKey("dbo.WeaponGroup", "HeroID", "dbo.Hero");
            DropForeignKey("dbo.VehicleItem", "HeroID", "dbo.Hero");
            DropForeignKey("dbo.VehicleItem", "VehicleID", "dbo.Vehicle");
            DropForeignKey("dbo.VehicleGroup", "HeroID", "dbo.Hero");
            DropForeignKey("dbo.SpecialistItem", "HeroID", "dbo.Hero");
            DropForeignKey("dbo.SpecialistItem", "SpecialistID", "dbo.Specialist");
            DropForeignKey("dbo.Ribbon", "HeroID", "dbo.Hero");
            DropForeignKey("dbo.MapItem", "HeroID", "dbo.Hero");
            DropForeignKey("dbo.MapItem", "MapID", "dbo.Map");
            DropForeignKey("dbo.HeroOverView", "HeroID", "dbo.Hero");
            DropForeignKey("dbo.GObjectItem", "HeroID", "dbo.Hero");
            DropForeignKey("dbo.GObjectItem", "GObjectID", "dbo.GObject");
            DropForeignKey("dbo.GameModeItem", "HeroID", "dbo.Hero");
            DropForeignKey("dbo.GameModeItem", "GameModeID", "dbo.GameMode");
            DropForeignKey("dbo.GadgetItem", "HeroID", "dbo.Hero");
            DropIndex("dbo.XP", new[] { "HeroID" });
            DropIndex("dbo.WeaponItem", new[] { "HeroID" });
            DropIndex("dbo.WeaponItem", new[] { "WeaponID" });
            DropIndex("dbo.WeaponGroup", new[] { "HeroID" });
            DropIndex("dbo.VehicleItem", new[] { "HeroID" });
            DropIndex("dbo.VehicleItem", new[] { "VehicleID" });
            DropIndex("dbo.VehicleGroup", new[] { "HeroID" });
            DropIndex("dbo.SpecialistItem", new[] { "HeroID" });
            DropIndex("dbo.SpecialistItem", new[] { "SpecialistID" });
            DropIndex("dbo.Ribbon", new[] { "HeroID" });
            DropIndex("dbo.MapItem", new[] { "HeroID" });
            DropIndex("dbo.MapItem", new[] { "MapID" });
            DropIndex("dbo.HeroOverView", new[] { "HeroID" });
            DropIndex("dbo.GObjectItem", new[] { "GObjectID" });
            DropIndex("dbo.GObjectItem", new[] { "HeroID" });
            DropIndex("dbo.GameModeItem", new[] { "HeroID" });
            DropIndex("dbo.GameModeItem", new[] { "GameModeID" });
            DropIndex("dbo.GadgetItem", new[] { "HeroID" });
            DropIndex("dbo.GadgetItem", new[] { "GadgetID" });
            DropTable("dbo.XP");
            DropTable("dbo.Weapon");
            DropTable("dbo.WeaponItem");
            DropTable("dbo.WeaponGroup");
            DropTable("dbo.Vehicle");
            DropTable("dbo.VehicleItem");
            DropTable("dbo.VehicleGroup");
            DropTable("dbo.Specialist");
            DropTable("dbo.SpecialistItem");
            DropTable("dbo.Ribbon");
            DropTable("dbo.Map");
            DropTable("dbo.MapItem");
            DropTable("dbo.HeroOverView");
            DropTable("dbo.GObject");
            DropTable("dbo.GObjectItem");
            DropTable("dbo.GameMode");
            DropTable("dbo.GameModeItem");
            DropTable("dbo.Hero");
            DropTable("dbo.GadgetItem");
            DropTable("dbo.Gadget");
        }
    }
}
