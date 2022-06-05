using Graph_Demo.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Graph_Demo.Repositories
{
    public record MDBCardsRepo
    {
        private const string databaseName = "graph-demo";
        private const string collectionName = "cards";
        private readonly IMongoCollection<Card> cardsCollection;

        public MDBCardsRepo(IMongoClient client)
        {
            IMongoDatabase database = client.GetDatabase(databaseName);
            cardsCollection = database.GetCollection<Card>(collectionName);
        }

        public async Task<IEnumerable<Card>> GetCardsAsync() => await cardsCollection.Find(new BsonDocument()).ToListAsync();
    }
}