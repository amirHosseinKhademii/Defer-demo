using Graph_Demo.Models;

namespace Graph_Demo.Repositories
{
    public interface IBooksRepository
    {
        Book GetBook(Guid id);
        IEnumerable<Book> GetBooks();

        void AddBook(Book book);

        void UpdateBook(Book book);

        void DeleteBook(Book book);


    }
}