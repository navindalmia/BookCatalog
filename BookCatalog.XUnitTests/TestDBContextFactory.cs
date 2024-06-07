using BookCatalog.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BookCatalog.Infrastructure.XunitTests
{
    class TestDbContextFactory : IDbContextFactory<BookCatalogDbContext>
    {
        private readonly DbContextOptions<BookCatalogDbContext> _options;

        public TestDbContextFactory(DbContextOptions<BookCatalogDbContext> options)
        {
            _options = options;
        }

        public BookCatalogDbContext CreateDbContext()
        {
            return new BookCatalogDbContext(_options);
        }
    }
}
