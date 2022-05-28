using Graph_Demo.Models;
using Graph_Demo.Repositories;

namespace Graph_Demo
{
    public class Mutation

    {
        private readonly IBooksRepository repository;

        public Mutation(IBooksRepository repository)
        {
            this.repository = repository;
        }
        public async Task<Book> AddBook(Book book)
        {
            repository.AddBook(book);
            return book;
        }
    }

}