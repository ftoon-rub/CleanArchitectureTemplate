using DomainLayer.Entites;
using DomainLayer.Entites.BaseEntites;
using DomainLayer.Enum;
using DomainLayer.Lookup;
using DomainLayer.Lookup.BaseLookups;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureLayer.Data
{
    public class CustomDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Biography> Biographies { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Library> Libraries { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
                {
                    modelBuilder.Entity(entityType.ClrType)
                        .Property("Id")
                        .ValueGeneratedOnAdd();
                }
            }
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(BaseLookup).IsAssignableFrom(entityType.ClrType))
                {
                    modelBuilder.Entity(entityType.ClrType)
                        .Property("Id")
                        .ValueGeneratedOnAdd();
                }
            }

            // One-to-One relationship between Author and Biography
            modelBuilder.Entity<Author>()
                .HasOne(a => a.Biography)
                .WithOne(b => b.Author)
                .HasForeignKey<Biography>(b => b.AuthorId);

            // One-to-Many relationship between Publisher and Books
            modelBuilder.Entity<Publisher>()
                .HasMany(p => p.Books)
                .WithOne(b => b.Publisher)
                .HasForeignKey(b => b.PublisherId);

            // Many-to-Many relationship between Library and Books
            modelBuilder.Entity<Library>()
                .HasMany(l => l.Books)
                .WithMany(b => b.Libraries)
                .UsingEntity(j => j.ToTable("LibraryBooks"));

            // Seed Category table from ECategory enum
            modelBuilder.Entity<Category>().HasData(
                Enum.GetValues(typeof(ECategory))
                    .Cast<ECategory>()
                    .Select(e => new Category
                    {
                        Code = (int)e,
                        Name = e.ToString()
                    })
            );

            base.OnModelCreating(modelBuilder);
        }

    }
}
