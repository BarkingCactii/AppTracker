using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DataModel
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Period> Periods { get; set; }
        public virtual DbSet<Position> Positions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Period>()
                .HasMany(e => e.Positions)
                .WithRequired(e => e.Period)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Position>()
                .Property(e => e.Position1)
                .IsUnicode(false);

            modelBuilder.Entity<Position>()
                .Property(e => e.Company)
                .IsUnicode(false);

            modelBuilder.Entity<Position>()
                .Property(e => e.Location)
                .IsUnicode(false);

            modelBuilder.Entity<Position>()
                .Property(e => e.Contact)
                .IsUnicode(false);

            modelBuilder.Entity<Position>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Position>()
                .Property(e => e.URL)
                .IsUnicode(false);
        }
    }
}
