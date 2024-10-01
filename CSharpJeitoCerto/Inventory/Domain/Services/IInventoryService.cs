using CSharpJeitoCerto.Order.Domain.Entities;

namespace CSharpJeitoCerto.Inventory.Domain.Services;

public interface IInventoryService
{
    Task<bool> ReduceInventoryAsync(List<OrderItem> items);
}