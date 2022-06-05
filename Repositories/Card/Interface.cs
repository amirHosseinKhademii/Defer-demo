using Graph_Demo.Models;

namespace Graph_Demo.Repositories
{
    public interface ICardRepository
    {
        Task<IEnumerable<Card>> GetCardsAsync();

        Task<Card> GetCardAsync(Guid id);

        Task CreateCardAsync(string title);
    }
}