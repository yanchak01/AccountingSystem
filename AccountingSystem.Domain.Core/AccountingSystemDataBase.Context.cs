﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AccountingSystem.Domain.Core
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AccountingSystemDbEntities1 : DbContext
    {
        public AccountingSystemDbEntities1()
            : base("AccountingSystemDbEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Record>().ToTable("Records").HasKey(x => x.Id);
        }
    
        public virtual DbSet<Record> Records { get; set; }
    }
}
