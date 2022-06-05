
using Graph_Demo.Models;
using Graph_Demo.Repositories;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Graph_Demo.Resolvers
{
    [ExtendObjectType(Name = "Query")]
    public class QueryCard
    {

        private readonly ICardRepository cardRepository;

        public QueryCard(ICardRepository cardRepository)
        {
            this.cardRepository = cardRepository;
        }

        public async Task<IEnumerable<Card>> GetCardsAsync() => await cardRepository.GetCardsAsync();


    }
}






