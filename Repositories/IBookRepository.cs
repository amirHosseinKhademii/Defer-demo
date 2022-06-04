using Graph_Demo.Models;

namespace Graph_Demo.Repositories
{
    public interface IBooksRepository
    {
        Task<Book> GetBookAsync(Guid Id);
        Task<IEnumerable<Book>> GetBooksAsync();

        Task AddBookAsync(Book book);

        void UpdateBook(Book book);

        void DeleteBook(Book book);


    }
}