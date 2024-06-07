using BookCatalog.Domain.Entities;
using BookCatalog.Domain.Enums;
using BookCatalog.Infrastructure.Context;
using BookCatalog.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookCatalog.Infrastructure.XunitTests
{
    
    public class BookRepositoryTests:IDisposable
    {
        private BookRepository _bookRepository;
        private BookCatalogDbContext _context;

   
        public BookRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<BookCatalogDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            var factory = new TestDbContextFactory(options);
            _context = factory.CreateDbContext();
            _bookRepository = new BookRepository(factory);
        }

        

        [Fact]
        public async Task AddAsync_ShouldAddBook()
        {
            // Arrange
          

            var book = new Book
            {

                Id = 1,
                Title = "TestTitle",
                Author = "TestAuthor",
                PublicationDate = DateTime.Now,
                Category = Category.Science
            };

            // Act
            await _bookRepository.AddAsync(book);
            var result = await _bookRepository.GetByIdAsync(book.Id);

            // Assert
          
            Assert.NotNull(result);
            Assert.Equal(book.Id,result.Id );    
            Assert.Equal(book.PublicationDate,result.PublicationDate);  
            Assert.Equal(book.Category,result.Category);    
            Assert.Equal(book.Author,result.Author);
            Assert.Equal(book.Title,result.Title);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnAllBooks()
        {
            //Arrange

            var book_One = new Book
            {

                Id = 1,
                Title = "TestTitle1",
                Author = "TestAuthor1",
                PublicationDate = DateTime.Now,
                Category = Category.Science
            };

            var book_Two = new Book
            {

                Id = 2,
                Title = "TestTitle2",
                Author = "TestAuthor2",
                PublicationDate = DateTime.Now,
                Category = Category.Science
            };

            var book_Three = new Book
            {

                Id = 3,
                Title = "TestTitle2",
                Author = "TestAuthor2",
                PublicationDate = DateTime.Now,
                Category = Category.Science
            };
            List<Book> expectedResult = new List<Book>() { book_Two, book_One };
            // Act

            foreach (var book in expectedResult)
            {
                await _bookRepository.AddAsync(book);
            }

            var result = await _bookRepository.GetAllAsync();


            List<Book> expectedResult2 = new List<Book>() { book_Three, book_One };

            //Assert
            Assert.Equal(expectedResult.ToArray(),result.ToArray());
            Assert.NotEqual(expectedResult2.ToArray(),result.ToArray());
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnCorrectBook()
        {

            var book = new Book
            {

                Id = 1,
                Title = "TestTitle",
                Author = "TestAuthor",
                PublicationDate = DateTime.Now,
                Category = Category.Science
            };

            // Act
            await _bookRepository.AddAsync(book);
            var result = await _bookRepository.GetByIdAsync(book.Id);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(book.Id,result.Id );
            Assert.Equal(book.PublicationDate,result.PublicationDate);
            Assert.Equal(book.Category,result.Category);
            Assert.Equal(book.Author, result.Author);
            Assert.Equal(book.Title, result.Title);

        }

        [Fact]
        public async Task UpdateAsync_ShouldUpdateBookCorrectly()
        {

            var book = new Book
            {

                Id = 1,
                Title = "TestTitle",
                Author = "TestAuthor",
                PublicationDate = DateTime.Now,
                Category = Category.Science
            };

            // Act
            await _bookRepository.AddAsync(book);
            book.Author = "UpdatedName";
            await _bookRepository.UpdateAsync(book);
            var result = await _bookRepository.GetByIdAsync(book.Id);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(book.Id, result.Id);
            Assert.Equal(book.PublicationDate, result.PublicationDate);
            Assert.Equal(book.Category, result.Category);
            Assert.Equal(book.Author, result.Author);
            Assert.Equal(book.Title, result.Title);
        }
        [Fact]
        public async Task DeleteAsync_ShouldDeleteBook()
        {

            var book = new Book
            {

                Id = 1,
                Title = "TestTitle",
                Author = "TestAuthor",
                PublicationDate = DateTime.Now,
                Category = Category.Science
            };

            // Act
            await _bookRepository.AddAsync(book);
            await _bookRepository.DeleteAsync(book.Id);
            var result = await _bookRepository.GetByIdAsync(book.Id);

            //Assert
            Assert.Null(result);
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}
