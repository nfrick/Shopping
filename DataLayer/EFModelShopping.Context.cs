﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayer
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ShoppingEntities : DbContext
    {
        public ShoppingEntities()
            : base("name=ShoppingEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Item> Itens { get; set; }
        public virtual DbSet<Lista> Listas { get; set; }
        public virtual DbSet<Loja> Lojas { get; set; }
        public virtual DbSet<Mapa> Mapas { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<ProdutoPicklist> vw_ProdutosPicklist { get; set; }
    
        public virtual ObjectResult<ProdutoPicklist> ProdutosPicklist(Nullable<int> listaID)
        {
            var listaIDParameter = listaID.HasValue ?
                new ObjectParameter("ListaID", listaID) :
                new ObjectParameter("ListaID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ProdutoPicklist>("ProdutosPicklist", listaIDParameter);
        }
    
        public virtual ObjectResult<ProdutoPicklist> ProdutosPicklist(Nullable<int> listaID, MergeOption mergeOption)
        {
            var listaIDParameter = listaID.HasValue ?
                new ObjectParameter("ListaID", listaID) :
                new ObjectParameter("ListaID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ProdutoPicklist>("ProdutosPicklist", mergeOption, listaIDParameter);
        }
    }
}