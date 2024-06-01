using BookCatalog.Domain.Entities;

namespace BookCatalog.Application.Interfaces
{
    public interface IBookRepository
    {
        Task AddAsync(Book book);
        //Task DeleteAsync(Book book);
        Task<List<Book>> GetAllAsync();

        Task<Book?> GetByIdAsync(int id);
        Task UpdateAsync(Book book); 
                
    }

}
