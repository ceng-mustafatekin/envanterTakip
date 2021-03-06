﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace envanterTakip
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class envanterDBEntities : DbContext
    {
        public envanterDBEntities()
            : base("name=envanterDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<category> categories { get; set; }
        public virtual DbSet<role> roles { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<PIDetail> PIDetails { get; set; }
        public virtual DbSet<product> products { get; set; }
        public virtual DbSet<purchaseInvoice> purchaseInvoices { get; set; }
        public virtual DbSet<supplier> suppliers { get; set; }
        public virtual DbSet<PIDetailss> PIDetailsses { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }
    
        public virtual ObjectResult<SP_getLoginDetails_Result> SP_getLoginDetails(string user, string pass)
        {
            var userParameter = user != null ?
                new ObjectParameter("user", user) :
                new ObjectParameter("user", typeof(string));
    
            var passParameter = pass != null ?
                new ObjectParameter("pass", pass) :
                new ObjectParameter("pass", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_getLoginDetails_Result>("SP_getLoginDetails", userParameter, passParameter);
        }
    
        public virtual ObjectResult<SP_getAllUser_Result> SP_getAllUser()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_getAllUser_Result>("SP_getAllUser");
        }
    }
}
