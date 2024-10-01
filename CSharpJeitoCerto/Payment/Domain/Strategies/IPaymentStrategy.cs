namespace CSharpJeitoCerto.Payment.Domain.Strategies;

public interface IPaymentStrategy
{
    Task<bool> ProcessPayment(Order.Domain.Entities.Orders orders);
}