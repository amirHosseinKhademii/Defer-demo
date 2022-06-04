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


        public async Task<IEnumerable<Book>> GetBooksAsync() => await booksCollection.Find(new BsonDocument()).ToListAsync();

        public async Task<Book> GetBookAsync(Guid Id)
        {
            var filter = filterBuilder.Eq(item => item.Id, Id);
            return await booksCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task CreateBookAsync(Book book)
        {
            await booksCollection.InsertOneAsync(book);
        }

        public async Task UpdateBookAsync(Guid Id, string title)
        {
            var filter = filterBuilder.Eq(item => item.Id, Id);
            var update = Builders<Book>.Update.Set(item => item.Title, title);
            await booksCollection.UpdateOneAsync(filter, update);
        }

        public async Task DeleteBookAsync(Guid Id)
        {
            var filter = filterBuilder.Eq(item => item.Id, Id);
            await booksCollection.DeleteOneAsync(filter);
        }

    }
}