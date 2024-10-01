using CSharpJeitoCerto.Order.Domain.Entities;

namespace CSharpJeitoCerto.Inventory.Domain.Services;

public class InventoryService : IInventoryService
{
    public Task<bool> ReduceInventoryAsync(List<OrderItem> items)
    {
        foreach (var item in items)
        {
            if (item.Products.Stock < item.Quantity)
            {
                Console.WriteLine($"Estoque insuficiente para o produto {item.Products.Name}");
                return Task.FromResult(false);
            }

            // Reduzir o estoque do produto
            item.Products.DecreaseStock(item.Quantity);
        }

        Console.WriteLine("Estoque atualizado com sucesso.");
        return Task.FromResult(true);
    }
}