using CSharpJeitoCerto.Order.Domain.Entities;
using CSharpJeitoCerto.Payment.Domain.Services;
using CSharpJeitoCerto.Shared.Domain.ValueObjects;
using Xunit;

namespace CSharpJeitoCerto.Payment.Tests;

public class PaymentTests
{
    [Fact]
    public async Task Should_Process_Payment_With_Pix()
    {
        var product = Products.Create("Product A", 50.0m, 10);
        var item = OrderItem.Create(product, 2);
        var order = Orders.Create(new List<OrderItem> { item }, PaymentMethod.Pix);

        var paymentService = new PaymentService();
        var result = await paymentService.ProcessPayment(order);

        Assert.True(result);
        Assert.Equal(95.0m, order.TotalValue); // Desconto de 5% aplicado
    }

    [Fact]
    public async Task Should_Process_Payment_With_CreditCard()
    {
        var product = Products.Create("Product A", 100.0m, 10);
        var item = OrderItem.Create(product, 1);
        var order = Orders.Create(new List<OrderItem> { item }, PaymentMethod.CreditCard, 3);

        var paymentService = new PaymentService();
        var result = await paymentService.ProcessPayment(order);

        Assert.True(result);
        Assert.Equal(106.0m, order.TotalValue); // Juros de 6% para 3 parcelas
    }
}