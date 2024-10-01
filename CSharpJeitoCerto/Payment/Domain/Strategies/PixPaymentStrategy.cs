using CSharpJeitoCerto.Order.Domain.Entities;

namespace CSharpJeitoCerto.Payment.Domain.Strategies;

public class PixPaymentStrategy : IPaymentStrategy
{
    public Task<bool> ProcessPayment(Orders order)
    {
        var discount = order.TotalValue * 0.05m;
        order.ApplyDiscount(discount);

        Console.WriteLine($"Pagamento com Pix processado com sucesso. Desconto: R$ {discount:F2}. Valor final: R$ {order.TotalValue:F2}.");

        return Task.FromResult(true);
    }
}
