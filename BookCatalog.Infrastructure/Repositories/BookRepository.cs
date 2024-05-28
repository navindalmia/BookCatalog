using BookCatalog.Application.Interfaces;
using BookCatalog.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BookCatalog.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookCatalogDbContext _context;
        public BookRepository(IDbContextFactory<BookCatalogDbContext> factory) 
        {
            _context=factory.CreateDbContext();


        }
    }
}
