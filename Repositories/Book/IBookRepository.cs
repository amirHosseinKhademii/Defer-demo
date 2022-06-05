using Graph_Demo.Models;

namespace Graph_Demo.Repositories
{
    public interface IBooksRepository
    {
        Task<Book> GetBookAsync(Guid Id);

        Task<IEnumerable<Book>> GetBooksAsync();

        Task CreateBookAsync(Book book);

        Task UpdateBookAsync(Guid Id, string title, string author);

        Task DeleteBookAsync(Guid Id);


    }
}