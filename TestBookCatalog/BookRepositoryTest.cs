using BookCatalog.Application.Interfaces;
using BookCatalog.Domain.Entities;
using BookCatalog.Infrastructure.Repositories;
namespace TestBookCatalog
{
    public class BookRepositoryTest
    {
        //IBookRepository BookRepository;
        //public BookRepositoryTest(IBookRepository _BookRepository)
        //{
        //    BookRepository= _BookRepository;
        //}
        private readonly IBookRepository _bookRepository;

        public BookRepositoryTest(BookRepositoryFixture fixture)
        {
            _bookRepository = fixture.BookRepository;
        }

        [Fact]
        public async Task AddAsync_ShouldAddBook_WhenInvoked()
        {
            //IBookRepository BookRepository = new BookRepository();
            List<Book> ListOfBooksBeforeAdd = await _bookRepository.GetAllAsync();
            int CountBeforeAdd = ListOfBooksBeforeAdd.Count();
            await _bookRepository.AddAsync(new Book());
            List<Book> ListOfBooksAfterAdd = await _bookRepository.GetAllAsync();
            int CountAfterAdd = ListOfBooksAfterAdd.Count();

            Assert.Equal(CountBeforeAdd+1, CountAfterAdd);
        }
    }
}