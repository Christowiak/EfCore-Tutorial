using EntityFramework.Tutorial.Entities;
using EntityFramework.Tutorial.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityFramework.Tutorial
{
   public class LibraryContext : DbContext
    {

        public LibraryContext(DbContextOptions options) : base(options)
        {

        }

        public LibraryContext()
        {

        }


        public DbSet<AuthorEntity> Autors { get; set; }

        public DbSet<LibraryEntity> Labraries { get; set; }

        public DbSet<BookEntity> Books { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BookEntity>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(x => x.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<LibraryEntity>()
                .HasMany(l => l.Books)
                .WithOne(b => b.Library)
                .HasForeignKey(x => x.LibraryId);
        }

        public override int SaveChanges()
        {
            foreach (var item in ChangeTracker.Entries<EntityBase>().ToList())
            {
                switch (item.State)
                {
                    case EntityState.Modified:

                        item.Entity.Editor = "SomeBodyElse";
                        item.Entity.EditorDate = DateTime.Now;

                        break;
                    case EntityState.Added:

                        item.Entity.Creator = "SomeBody";
                        item.Entity.CreateDate = DateTime.Now;
                        item.Entity.Editor = "SomeBody";
                        item.Entity.EditorDate = DateTime.Now;

                        break;
                    default:
                        break;
                }
            }
            


            return base.SaveChanges();
        }
    }
}
