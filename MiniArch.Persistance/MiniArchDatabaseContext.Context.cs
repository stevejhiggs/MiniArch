﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MiniArch.Persistance
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MiniArchDatabaseContext : DbContext
    {
        public MiniArchDatabaseContext()
            : base("name=MiniArchDatabaseContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TodoListItem> TodoListItems { get; set; }
        public virtual DbSet<TodoList> TodoLists { get; set; }
    }
}
