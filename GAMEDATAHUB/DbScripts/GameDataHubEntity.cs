using System.Data.Entity;

namespace GAMEDATAHUB.DbScripts
{
    public partial class GameDataHubEntity : DbContext
    {
        public GameDataHubEntity()
            : base("name=GameDataHubEntity")
        {
        }

        public virtual DbSet<Gadget> Gadget { get; set; }
        public virtual DbSet<GadgetItem> GadgetItem { get; set; }
        public virtual DbSet<GameMode> GameMode { get; set; }
        public virtual DbSet<GameModeItem> GameModeItem { get; set; }
        public virtual DbSet<GObject> GObject { get; set; }
        public virtual DbSet<Hero> Hero { get; set; }
        public virtual DbSet<HeroOverView> HeroOverView { get; set; }
        public virtual DbSet<Map> Map { get; set; }
        public virtual DbSet<MapItem> MapItem { get; set; }
        public virtual DbSet<Ribbon> Ribbon { get; set; }
        public virtual DbSet<Specialist> Specialist { get; set; }
        public virtual DbSet<SpecialistItem> SpecialistItem { get; set; }
        public virtual DbSet<Vehicle> Vehicle { get; set; }
        public virtual DbSet<VehicleGroup> VehicleGroup { get; set; }
        public virtual DbSet<VehicleItem> VehicleItem { get; set; }
        public virtual DbSet<Weapon> Weapon { get; set; }
        public virtual DbSet<WeaponGroup> WeaponGroup { get; set; }
        public virtual DbSet<WeaponItem> WeaponItem { get; set; }
        public virtual DbSet<XP> XP { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<DividedKill> DividedKill { get; set; }
        public virtual DbSet<Rank> Rank { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hero>()
                .HasMany(e => e.MapItem)
                .WithRequired(e => e.Hero)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Hero>()
                .HasMany(e => e.GadgetItem)
                .WithRequired(e => e.Hero)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Hero>()
                .HasMany(e => e.GameModeItem)
                .WithRequired(e => e.Hero)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Hero>()
                .HasMany(e => e.SpecialistItem)
                .WithRequired(e => e.Hero)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Hero>()
                .HasMany(e => e.VehicleItem)
                .WithRequired(e => e.Hero)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Hero>()
                .HasMany(e => e.WeaponItem)
                .WithRequired(e => e.Hero)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Hero>()
                .HasMany(e => e.VehicleGroup)
                .WithRequired(e => e.Hero)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Hero>()
                .HasMany(e => e.WeaponGroup)
                .WithRequired(e => e.Hero)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Hero>()
                .HasMany(e => e.WeaponGroup)
                .WithRequired(e => e.Hero)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Map>()
                .HasMany(e => e.MapItem)
                .WithRequired(e => e.Map)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Gadget>()
                .HasMany(e => e.GadgetItem)
                .WithRequired(e => e.Gadget)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GameMode>()
                .HasMany(e => e.GameModeItem)
                .WithRequired(e => e.GameMode)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Specialist>()
                .HasMany(e => e.SpecialistItem)
                .WithRequired(e => e.Specialist)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Vehicle>()
                .HasMany(e => e.VehicleItem)
                .WithRequired(e => e.Vehicle)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Weapon>()
                .HasMany(e => e.WeaponItem)
                .WithRequired(e => e.Weapon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GadgetItem>()
                .Property(e => e.KPM)
                .HasColumnType("decimal")
                .HasPrecision(10, 2);

            modelBuilder.Entity<GadgetItem>()
                .Property(e => e.DPM)
                .HasColumnType("decimal")
                .HasPrecision(10, 2);

            modelBuilder.Entity<GameModeItem>()
                .Property(e => e.KPM)
                .HasColumnType("decimal")
                .HasPrecision(10, 2);

            modelBuilder.Entity<GameModeItem>()
                .Property(e => e.WinPercent)
                .HasColumnType("decimal")
                .HasPrecision(10, 2);

            modelBuilder.Entity<HeroOverView>()
                .Property(e => e.HumanPercentage)
                .HasColumnType("decimal")
                .HasPrecision(10, 2);

            modelBuilder.Entity<HeroOverView>()
                .Property(e => e.KillsPerMinute)
                .HasColumnType("decimal")
                .HasPrecision(10, 2);

            modelBuilder.Entity<HeroOverView>()
                .Property(e => e.DamagePerMinute)
                .HasColumnType("decimal")
                .HasPrecision(10, 2);

            modelBuilder.Entity<HeroOverView>()
                .Property(e => e.KillsPerMatch)
                .HasColumnType("decimal")
                .HasPrecision(10, 2);

            modelBuilder.Entity<HeroOverView>()
                .Property(e => e.DamagePerMatch)
                .HasColumnType("decimal")
                .HasPrecision(10, 2);

            modelBuilder.Entity<HeroOverView>()
                .Property(e => e.WinPercent)
                .HasColumnType("decimal")
                .HasPrecision(10, 2);

            modelBuilder.Entity<HeroOverView>()
                .Property(e => e.HeadShotrate)
                .HasColumnType("decimal")
                .HasPrecision(10, 2);

            modelBuilder.Entity<HeroOverView>()
                .Property(e => e.KillDeath)
                .HasColumnType("decimal")
                .HasPrecision(10, 2);

            modelBuilder.Entity<HeroOverView>()
                .Property(e => e.InfantryKillDeath)
                .HasColumnType("decimal")
                .HasPrecision(10, 2);

            modelBuilder.Entity<HeroOverView>()
                .Property(e => e.Accuracy)
                .HasColumnType("decimal")
                .HasPrecision(10, 2);

            modelBuilder.Entity<MapItem>()
                .Property(e => e.WinPercent)
                .HasColumnType("decimal")
                .HasPrecision(10, 2);

            modelBuilder.Entity<SpecialistItem>()
                .Property(e => e.KMP)
                .HasColumnType("decimal")
                .HasPrecision(10, 2);

            modelBuilder.Entity<SpecialistItem>()
                .Property(e => e.KillDeath)
                .HasColumnType("decimal")
                .HasPrecision(10, 2);

            modelBuilder.Entity<VehicleGroup>()
                .Property(e => e.KillsPerMinute)
                .HasColumnType("decimal")
                .HasPrecision(10, 2);

            modelBuilder.Entity<VehicleItem>()
                .Property(e => e.KillsPerMinute)
                .HasColumnType("decimal")
                .HasPrecision(10, 2);

            modelBuilder.Entity<WeaponGroup>()
                .Property(e => e.Accuracy)
                .HasColumnType("decimal")
                .HasPrecision(10, 2);

            modelBuilder.Entity<WeaponGroup>()
                .Property(e => e.KillsPerMinute)
                .HasColumnType("decimal")
                .HasPrecision(10, 2);

            modelBuilder.Entity<WeaponGroup>()
                .Property(e => e.DamagePerMinute)
                .HasColumnType("decimal")
                .HasPrecision(10, 2);

            modelBuilder.Entity<WeaponGroup>()
                .Property(e => e.Headshots)
                .HasColumnType("decimal")
                .HasPrecision(10, 2);

            modelBuilder.Entity<WeaponGroup>()
                .Property(e => e.HitVKills)
                .HasColumnType("decimal")
                .HasPrecision(10, 2);

            modelBuilder.Entity<WeaponItem>()
                .Property(e => e.Accuracy)
                .HasColumnType("decimal")
                .HasPrecision(10, 2);

            modelBuilder.Entity<WeaponItem>()
                .Property(e => e.KillsPerMinute)
                .HasColumnType("decimal")
                .HasPrecision(10, 2);

            modelBuilder.Entity<WeaponItem>()
                .Property(e => e.DamagePerMinute)
                .HasColumnType("decimal")
                .HasPrecision(10, 2);

            modelBuilder.Entity<WeaponItem>()
                .Property(e => e.Headshots)
                .HasColumnType("decimal")
                .HasPrecision(10, 2);

            modelBuilder.Entity<WeaponItem>()
                .Property(e => e.HitVKills)
                .HasColumnType("decimal")
                .HasPrecision(10, 2);

            modelBuilder.Entity<Rank>()
                .Property(e => e.KDRank)
                .HasColumnType("decimal")
                .HasPrecision(10, 2);

            modelBuilder.Entity<Rank>()
                .Property(e => e.HSRank)
                .HasColumnType("decimal")
                .HasPrecision(10, 2);

            modelBuilder.Entity<Rank>()
                .Property(e => e.WinPercentRank)
                .HasColumnType("decimal")
                .HasPrecision(10, 2);

            modelBuilder.Entity<Rank>()
                .Property(e => e.HumanKDRank)
                .HasColumnType("decimal")
                .HasPrecision(10, 2);

            modelBuilder.Entity<Rank>()
                .Property(e => e.DeathRank)
                .HasColumnType("decimal")
                .HasPrecision(10, 2);

            modelBuilder.Entity<Rank>()
                .Property(e => e.KPMRank)
                .HasColumnType("decimal")
                .HasPrecision(10, 2);

            modelBuilder.Entity<Rank>()
                .Property(e => e.KPMatchRank)
                .HasColumnType("decimal")
                .HasPrecision(10, 2);

            modelBuilder.Entity<Rank>()
                .Property(e => e.WinRank)
                .HasColumnType("decimal")
                .HasPrecision(10, 2);

            modelBuilder.Entity<Rank>()
                .Property(e => e.LostRank)
                .HasColumnType("decimal")
                .HasPrecision(10, 2);

            modelBuilder.Entity<Rank>()
                .Property(e => e.DamageRank)
                .HasColumnType("decimal")
                .HasPrecision(10, 2);

            modelBuilder.Entity<Rank>()
                .Property(e => e.DPMRank)
                .HasColumnType("decimal")
                .HasPrecision(10, 2);

            modelBuilder.Entity<Rank>()
                .Property(e => e.VehiclesDestroyedRank)
                .HasColumnType("decimal")
                .HasPrecision(10, 2);

            modelBuilder.Entity<Rank>()
                .Property(e => e.HSAmountRank)
                .HasColumnType("decimal")
                .HasPrecision(10, 2);

            modelBuilder.Entity<Rank>()
                .Property(e => e.RoadKillRank)
                .HasColumnType("decimal")
                .HasPrecision(10, 2);

            modelBuilder.Entity<Rank>()
                .Property(e => e.MeleeKillRank)
                .HasColumnType("decimal")
                .HasPrecision(10, 2);

            modelBuilder.Entity<Rank>()
                .Property(e => e.VehicleKillRank)
                .HasColumnType("decimal")
                .HasPrecision(10, 2);

            modelBuilder.Entity<Rank>()
                .Property(e => e.ScopedKillRank)
                .HasColumnType("decimal")
                .HasPrecision(10, 2);

            modelBuilder.Entity<Rank>()
                .Property(e => e.HipfireKillRank)
                .HasColumnType("decimal")
                .HasPrecision(10, 2);

            modelBuilder.Entity<Rank>()
                .Property(e => e.HumanKillRank)
                .HasColumnType("decimal")
                .HasPrecision(10, 2);

            modelBuilder.Entity<Rank>()
                .Property(e => e.AIKillRank)
                .HasColumnType("decimal")
                .HasPrecision(10, 2);

            modelBuilder.Entity<Rank>()
                .Property(e => e.ObjectiveTimeRank)
                .HasColumnType("decimal")
                .HasPrecision(10, 2);

            modelBuilder.Entity<Rank>()
                .Property(e => e.DisarmedObjectRank)
                .HasColumnType("decimal")
                .HasPrecision(10, 2);

            modelBuilder.Entity<Rank>()
                .Property(e => e.CapturedObjectiRank)
                .HasColumnType("decimal")
                .HasPrecision(10, 2);

            modelBuilder.Entity<Rank>()
                .Property(e => e.ObjectivesDeutralizeRank)
                .HasColumnType("decimal")
                .HasPrecision(10, 2);

            modelBuilder.Entity<Rank>()
                .Property(e => e.SectorsDefendeRank)
                .HasColumnType("decimal")
                .HasPrecision(10, 2);

            modelBuilder.Entity<Rank>()
                .Property(e => e.SectorsCapturedRank)
                .HasColumnType("decimal")
                .HasPrecision(10, 2);

            modelBuilder.Entity<Rank>()
                .Property(e => e.AttackedObjectRank)
                .HasColumnType("decimal")
                .HasPrecision(10, 2);

        }
    }
}