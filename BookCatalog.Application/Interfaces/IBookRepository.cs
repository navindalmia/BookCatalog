using BookCatalog.Domain.Entities;

namespace BookCatalog.Application.Interfaces
{
    public interface IBookRepository
    {
        Task AddAsync(Book book);
    }
}
