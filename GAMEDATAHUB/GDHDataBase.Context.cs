﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GAMEDATAHUB
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class GameDataHubEntitiy : DbContext
    {
        public GameDataHubEntitiy()
            : base("name=GameDataHubEntitiy")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Gadget> Gadget { get; set; }
        public virtual DbSet<GadgetItem> GadgetItem { get; set; }
        public virtual DbSet<GameMode> GameMode { get; set; }
        public virtual DbSet<GameModeItem> GameModeItem { get; set; }
        public virtual DbSet<GObject> GObject { get; set; }
        public virtual DbSet<GObjectItem> GObjectItem { get; set; }
        public virtual DbSet<Hero> Hero { get; set; }
        public virtual DbSet<Map> Map { get; set; }
        public virtual DbSet<MapItem> MapItem { get; set; }
        public virtual DbSet<Ribbon> Ribbon { get; set; }
        public virtual DbSet<RibbonItem> RibbonItem { get; set; }
        public virtual DbSet<Specialist> Specialist { get; set; }
        public virtual DbSet<SpecialistItem> SpecialistItem { get; set; }
        public virtual DbSet<Vehicle> Vehicle { get; set; }
        public virtual DbSet<VehicleGroup> VehicleGroup { get; set; }
        public virtual DbSet<VehicleItem> VehicleItem { get; set; }
        public virtual DbSet<Weapon> Weapon { get; set; }
        public virtual DbSet<WeaponGroup> WeaponGroup { get; set; }
        public virtual DbSet<WeaponItem> WeaponItem { get; set; }
        public virtual DbSet<XP> XP { get; set; }
        public virtual DbSet<HeroOverView> HeroOverView { get; set; }
    }
}