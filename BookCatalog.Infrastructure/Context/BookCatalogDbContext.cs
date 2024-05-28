using BookCatalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookCatalog.Infrastructure.Context
{
    public class BookCatalogDbContext:DbContext
    {
        public BookCatalogDbContext(DbContextOptions<BookCatalogDbContext> options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
    }
}
