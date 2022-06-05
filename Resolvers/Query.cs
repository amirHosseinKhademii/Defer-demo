
using Graph_Demo.Models;
using Graph_Demo.Repositories;

namespace Graph_Demo.Resolvers
{
    public class Query
    {
        private readonly IBooksRepository bookRepository;
        private readonly ICardRepository cardRepository;

        public Query(IBooksRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public async Task<IEnumerable<Book>> GetBooksAsync() => await bookRepository.GetBooksAsync();


        public async Task<Book> GetBookAsync(Guid id) => await bookRepository.GetBookAsync(id);


    }
}






