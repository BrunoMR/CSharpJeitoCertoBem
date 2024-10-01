using CSharpJeitoCerto.Inventory.Domain.Services;
using CSharpJeitoCerto.Order.Domain.Entities;
using Xunit;

namespace CSharpJeitoCerto.Inventory.Tests;

public class InventoryTests
{
    [Fact]
    public async Task Should_Reduce_Inventory_When_Sufficient_Stock()
    {
        // Arrange
        var product = Products.Create("Produto A", 100.0m, 10);
        var item = OrderItem.Create(product, 2);
        var inventoryService = new InventoryService();

        // Act
        var result = await inventoryService.ReduceInventoryAsync(new List<OrderItem> { item });

        // Assert
        Assert.True(result);
        Assert.Equal(8, product.Stock); // O estoque deve ser reduzido
    }

    [Fact]
    public async Task Should_Fail_When_Insufficient_Stock()
    {
        // Arrange
        var product = Products.Create("Produto A", 100.0m, 2);
        var item = OrderItem.Create(product, 3);
        var inventoryService = new InventoryService();

        // Act
        var result = await inventoryService.ReduceInventoryAsync(new List<OrderItem> { item });

        // Assert
        Assert.False(result);
        Assert.Equal(2, product.Stock); // O estoque não deve ser alterado
    }
}