using BookCatalog.Application.Interfaces;
using BookCatalog.Infrastructure.Context;
using BookCatalog.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

public class BookRepositoryFixture : IDisposable
{
    public IBookRepository BookRepository { get; private set; }

    public BookRepositoryFixture()
    {
        var options = new DbContextOptionsBuilder<BookCatalogDbContext>()
                        .UseInMemoryDatabase(databaseName: "TestDatabase")
                        .Options;

        var dbContextFactory = new MockDbContextFactory(options);
        BookRepository = new BookRepository(dbContextFactory);
    }

    public void Dispose()
    {
        // Cleanup if needed
    }
}

public class MockDbContextFactory : IDbContextFactory<BookCatalogDbContext>
{
    private readonly DbContextOptions<BookCatalogDbContext> _options;

    public MockDbContextFactory(DbContextOptions<BookCatalogDbContext> options)
    {
        _options = options;
    }

    public BookCatalogDbContext CreateDbContext()
    {
        return new BookCatalogDbContext(_options);
    }
}
