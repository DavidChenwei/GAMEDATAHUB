using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GAMEDATAHUB
{
    public class GDHEntityDbContext : DbContext
    {
        public DbSet<Weapon> Weapon { get; set; }
        public DbSet<Gadget> Gadget { get; set; }
        public DbSet<GadgetItem> GadgetItem { get; set; }
        public DbSet<GameMode> GameMode { get; set; }
        public DbSet<GameModeItem> GameModeItem { get; set; }
        public DbSet<GObject> GObject { get; set; }
        public DbSet<GObjectItem> GObjectItem { get; set; }
        public DbSet<Hero> Hero { get; set; }
        public DbSet<Map> Map { get; set; }
        public DbSet<MapItem> MapItem { get; set; }
        public DbSet<Ribbon> Ribbon { get; set; }
        public DbSet<RibbonItem> RibbonItem { get; set; }
        public DbSet<Specialist> Specialist { get; set; }
        public DbSet<SpecialistItem> SpecialistItem { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<VehicleGroup> VehicleGroup { get; set; }
        public DbSet<VehicleItem> VehicleItem { get; set; }
        public DbSet<WeaponItem> WeaponItem { get; set; }
        public DbSet<WeaponGroup> WeaponGroup { get; set; }
        public DbSet<XP> XP { get; set; }
    }
}