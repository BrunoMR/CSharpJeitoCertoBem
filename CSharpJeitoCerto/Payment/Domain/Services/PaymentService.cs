using CSharpJeitoCerto.Payment.Domain.Strategies;
using CSharpJeitoCerto.Shared.Domain.ValueObjects;

namespace CSharpJeitoCerto.Payment.Domain.Services;

public class PaymentService
{
    public async Task<bool> ProcessPayment(Order.Domain.Entities.Orders orders)
    {
        IPaymentStrategy paymentStrategy;

        if (orders.PaymentMethod == PaymentMethod.Pix)
        {
            paymentStrategy = new PixPaymentStrategy();
        }
        else if (orders.PaymentMethod == PaymentMethod.CreditCard)
        {
            paymentStrategy = new CreditCardPaymentStrategy(orders.Installments);
        }
        else
        {
            throw new NotSupportedException("Método de pagamento não suportado.");
        }

        return await paymentStrategy.ProcessPayment(orders);
    }
}
