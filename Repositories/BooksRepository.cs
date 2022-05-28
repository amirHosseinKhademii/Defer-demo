using Graph_Demo.Models;

namespace Graph_Demo.Repositories
{
    public record BooksRepository : IBooksRepository
    {
        private readonly List<Book> books = new()
        {
            new Book
                {
                    Id = Guid.NewGuid(),
                    Title = "C# in depth.",
                    Author = new Author
                    {
                        Name = "Jon Skeet"
                    }
                },
             new Book
                {
                    Id = Guid.NewGuid(),
                    Title = "C# in hotchocolate.",
                    Author = new Author
                    {
                        Name = "Amir hossein"
                    }
                }
        };


        public IEnumerable<Book> GetBooks() => books;

        public Book GetBook(Guid id) => books.Where(b => b.Id == id).SingleOrDefault();

        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public void UpdateBook(Book book)
        {
            throw new NotImplementedException();
        }

        public void DeleteBook(Book book)
        {
            throw new NotImplementedException();
        }
    }
}