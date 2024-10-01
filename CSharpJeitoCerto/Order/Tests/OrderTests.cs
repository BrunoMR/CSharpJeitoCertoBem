using CSharpJeitoCerto.Order.Domain.Entities;
using CSharpJeitoCerto.Order.Domain.ValueObjects;
using CSharpJeitoCerto.Shared.Domain.ValueObjects;
using Xunit;

namespace CSharpJeitoCerto.Order.Tests;

public class OrderTests
{
    [Fact]
    public void Should_Create_Order_With_Valid_Parameters()
    {
        var product = Products.Create("Product A", 50.0m, 10);
        var item = OrderItem.Create(product, 2);
        var order = Orders.Create(new List<OrderItem> { item }, PaymentMethod.Pix);

        Assert.NotNull(order);
        Assert.Equal(100.0m, order.TotalValue);
        Assert.Equal(OrderStatus.WaitingProcessing, order.Status);
    }

    [Fact]
    public void Should_Cancel_Order()
    {
        var product = Products.Create("Product A", 50.0m, 10);
        var item = OrderItem.Create(product, 2);
        var order = Orders.Create(new List<OrderItem> { item }, PaymentMethod.Pix);

        var result = order.Cancel();

        Assert.True(result);
        Assert.Equal(OrderStatus.Canceled, order.Status);
    }
}
