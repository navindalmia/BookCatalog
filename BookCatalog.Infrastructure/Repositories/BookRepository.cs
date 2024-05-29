using BookCatalog.Application.Interfaces;
using BookCatalog.Domain.Entities;
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

        public async Task AddAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
        }
    }
}
