using domain.entities;
using Microsoft.EntityFrameworkCore;

namespace infra
{
   public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<PersonEntity> Persons { get; set; }
        public DbSet<TransactionEntity> Transactions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonEntity>()
                .HasMany(e => e.Transactions)
                .WithOne(e => e.Person)
                .HasForeignKey(e => e.PersonId);

            modelBuilder.Entity<CategoryEntity>()
                .HasMany(e => e.Transactions)
                .WithOne(e => e.Category)
                .HasForeignKey(e => e.CategoryId);

                    base.OnModelCreating(modelBuilder);

        }
    }
}
