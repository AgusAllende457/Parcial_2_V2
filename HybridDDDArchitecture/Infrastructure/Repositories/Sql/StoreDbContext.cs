using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Sql
{
 
    internal class StoreDbContext : DbContext
    {
        public DbSet<DummyEntity> DummyEntity { get; set; }
        public DbSet<Automovil> Automoviles { get; set; }

        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {
        }

        protected StoreDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DummyEntity>().ToTable("DummyEntity");
            modelBuilder.Entity<Automovil>().ToTable("Automovil");
        }
    }
}
