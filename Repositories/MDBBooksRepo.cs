using Graph_Demo.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Graph_Demo.Repositories
{
    public record MDBBooksRepo : IBooksRepository
    {
        private const string databaseName = "graph-demo";
        private const string collectionName = "books";
        private readonly IMongoCollection<Book> booksCollection;

        private readonly FilterDefinitionBuilder<Book> filterBuilder = Builders<Book>.Filter;

        public MDBBooksRepo(IMongoClient client)
        {
            IMongoDatabase database = client.GetDatabase(databaseName);
            booksCollection = database.GetCollection<Book>(collectionName);
        }
        private readonly List<Book> books = new()
        {
            new Book
                {
                    Id = Guid.NewGuid(),
                    Title = "C# in depth.",
                    Author = new Author
                    {
                        Name = "Jon Skeet"
                    }
                },
             new Book
                {
                    Id = Guid.NewGuid(),
                    Title = "C# in hotchocolate.",
                    Author = new Author
                    {
                        Name = "Amir hossein"
                    }
                }
        };

        public async Task<IEnumerable<Book>> GetBooksAsync() => await booksCollection.Find(new BsonDocument()).ToListAsync();

        public Book GetBook(Guid id) => books.Where(b => b.Id == id).SingleOrDefault();

        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public void UpdateBook(Book book)
        {
            throw new NotImplementedException();
        }

        public void DeleteBook(Book book)
        {
            throw new NotImplementedException();
        }

    }
}