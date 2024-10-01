using CSharpJeitoCerto.Order.Domain.Repositories;
using CSharpJeitoCerto.Shared.Infrastructure.Database;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace CSharpJeitoCerto.Order.Infrastructure.Repositories
{
    public class OrderRepository : MongoRepository<Domain.Entities.Orders>, IOrderRepository
    {
        public OrderRepository(IMongoClient mongoClient, IOptions<DatabaseSettings> databaseSettings)
            : base(mongoClient, databaseSettings, databaseSettings.Value.OrdersCollectionName)
        {
        }
    }
}