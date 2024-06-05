using BookCatalog.Domain.Entities;
using BookCatalog.Domain.Enums;
using BookCatalog.Infrastructure;
using BookCatalog.Infrastructure.Context;
using BookCatalog.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookCatalog.Tests.Repositories
{
    [TestFixture]
    public class BookRepositoryTests
    {
        private BookRepository _bookRepository;
        private BookCatalogDbContext _context;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<BookCatalogDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            var factory = new TestDbContextFactory(options);
            _context = factory.CreateDbContext();
            _bookRepository = new BookRepository(factory);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [Test]
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
          
            Assert.That(result,Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(book.Id));    
            Assert.That(result.PublicationDate, Is.EqualTo(book.PublicationDate));  
            Assert.That(result.Category, Is.EqualTo(book.Category));    
            Assert.That(result.Author, Is.EqualTo(book.Author));
            Assert.That(result.Title, Is.EqualTo(book.Title));



        }
        [Test]
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
            List<Book> expectedResult = new List<Book>() { book_Two,book_One };
            // Act
            
            foreach (var book in expectedResult)
            {
                await _bookRepository.AddAsync(book);
            }
            var result = await _bookRepository.GetAllAsync();
            //Assert
            Assert.That(result, Is.EquivalentTo(expectedResult));
        }

        [Test]
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
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(book.Id));
            Assert.That(result.PublicationDate, Is.EqualTo(book.PublicationDate));
            Assert.That(result.Category, Is.EqualTo(book.Category));
            Assert.That(result.Author, Is.EqualTo(book.Author));
            Assert.That(result.Title, Is.EqualTo(book.Title));

        }

        [Test]
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
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(book.Id));
            Assert.That(result.PublicationDate, Is.EqualTo(book.PublicationDate));
            Assert.That(result.Category, Is.EqualTo(book.Category));
            Assert.That(result.Author, Is.EqualTo(book.Author));
            Assert.That(result.Title, Is.EqualTo(book.Title));

        }
        [Test]
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
            Assert.That(result, Is.Null);
        }

    }
}
