
using Graph_Demo.Models;
using Graph_Demo.Repositories;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Graph_Demo.Resolvers
{
    [ExtendObjectType(Name = "Query")]
    public class BookQuery
    {
        private readonly IBooksRepository bookRepository;

        public BookQuery(IBooksRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public async Task<IEnumerable<Book>> GetBooksAsync() => await bookRepository.GetBooksAsync();


        public async Task<Book> GetBookAsync(Guid id) => await bookRepository.GetBookAsync(id);


    }
}






