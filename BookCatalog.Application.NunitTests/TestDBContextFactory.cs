using BookCatalog.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalog.Infrastructure
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
