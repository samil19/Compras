﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Compras
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ComprasEntities : DbContext
    {
        public ComprasEntities()
            : base("name=ComprasEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Articulo> Articulos { get; set; }
        public virtual DbSet<Articulos_Departamentos> Articulos_Departamentos { get; set; }
        public virtual DbSet<Departamento> Departamentos { get; set; }
        public virtual DbSet<Direccion> Direccions { get; set; }
        public virtual DbSet<Identificacion> Identificacions { get; set; }
        public virtual DbSet<Medida> Medidas { get; set; }
        public virtual DbSet<Ordene> Ordenes { get; set; }
        public virtual DbSet<Proveedore> Proveedores { get; set; }
    }
}
