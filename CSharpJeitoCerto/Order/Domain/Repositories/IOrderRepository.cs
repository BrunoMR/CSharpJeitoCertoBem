namespace CSharpJeitoCerto.Order.Domain.Repositories;

public interface IOrderRepository
{
    Task<Entities.Orders> GetByIdAsync(Guid orderId);
    Task AddAsync(Entities.Orders orders);
    Task UpdateAsync(Entities.Orders orders);
}