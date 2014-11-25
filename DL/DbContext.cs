using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace RepositoryPattern.DL
{
    public partial class RepositoryPatternContext : DbContext
    {
        public RepositoryPatternContext() : base("name=RepositoryPatternContext")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Foo> Foo
        {
            get;
            set;
        }
    }
}