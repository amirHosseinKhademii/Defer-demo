using Graph_Demo.Models;

namespace Graph_Demo.Repositories
{
    public interface IBooksRepository
    {
        Task<Book> GetBookAsync(Guid Id);
        Task<IEnumerable<Book>> GetBooksAsync();

        Task CreateBookAsync(Book book);

        void UpdateBook(Book book);

        Task DeleteBookAsync(Guid Id);


    }
}