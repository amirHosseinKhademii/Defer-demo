using Graph_Demo.Models;
using Graph_Demo.Repositories;

namespace Graph_Demo
{
    public class Query

    {
        private readonly IBooksRepository repository;

        public Query(IBooksRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IEnumerable<Book>> GetBooksAsync() => await repository.GetBooksAsync();

        public async Task<Book> GetBookAsync(Guid id) => await repository.GetBookAsync(id);
    }

}