using Graph_Demo.Models;
using Graph_Demo.Repositories;

namespace Graph_Demo.Resolvers
{
    [ExtendObjectType(Name = "Mutation")]
    public class CardMutation
    {

        private readonly ICardRepository cardRepository;

        public CardMutation(ICardRepository cardRepository)
        {
            this.cardRepository = cardRepository;
        }

        public async Task<Boolean> CreateCardAsync(string title)
        {
            await cardRepository.CreateCardAsync(title);
            return true;
        }
    }
}