using Graph_Demo.Models;

namespace Graph_Demo.Repositories
{
    public interface IBooksRepository
    {
        Book GetBook(Guid id);
        Task<IEnumerable<Book>> GetBooksAsync();

        void AddBook(Book book);

        void UpdateBook(Book book);

        void DeleteBook(Book book);


    }
}