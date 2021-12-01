using Library.Common;
using Microsoft.EntityFrameworkCore;
using System;

namespace Library.Infrastructure
{
    public class LibraryContext:DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
            
        }
        public DbSet<LoginUser> LoginUser { get; set; }
        public DbSet<Book> Book { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
