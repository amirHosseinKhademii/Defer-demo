using Graph_Demo.Models;
using Graph_Demo.Repositories;

namespace Graph_Demo.Resolvers
{
    public class Mutation
    {
        private readonly IBooksRepository repository;

        public Mutation(IBooksRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Boolean> CreateBookAsync(string title)
        {
            Book book = new()
            {
                Title = title
            };
            await repository.CreateBookAsync(book);
            return true;
        }

        public async Task<Boolean> UpdateBookAsync(Guid id, string title, string author)
        {
            await repository.UpdateBookAsync(id, title, author);
            return true;
        }

        public async Task<Boolean> DeleteBookAsync(Guid id)
        {
            await repository.DeleteBookAsync(id);
            return true;
        }
    }
}