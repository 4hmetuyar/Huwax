﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Huwax.Dal
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HuwaxEntities : DbContext
    {
        public HuwaxEntities()
            : base("name=HuwaxEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Cari> Cari { get; set; }
        public virtual DbSet<CariOperation> CariOperation { get; set; }
        public virtual DbSet<CarWash> CarWash { get; set; }
        public virtual DbSet<DayOff> DayOff { get; set; }
        public virtual DbSet<Personnel> Personnel { get; set; }
        public virtual DbSet<Salary> Salary { get; set; }
        public virtual DbSet<Vehicle> Vehicle { get; set; }
        public virtual DbSet<User> User { get; set; }
    }
}
