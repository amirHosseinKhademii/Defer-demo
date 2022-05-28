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
        public IEnumerable<Book> GetBooks() => repository.GetBooks();

        public Book GetBook(Guid id) => repository.GetBook(id);
    }

}