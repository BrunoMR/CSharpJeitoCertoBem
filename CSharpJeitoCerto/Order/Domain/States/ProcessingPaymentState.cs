using CSharpJeitoCerto.Order.Domain.Entities;

namespace CSharpJeitoCerto.Order.Domain.States;

public class ProcessingPaymentState : IOrderState
{
    public void ProcessPayment(Orders order)
    {
        Console.WriteLine("Pagamento já está sendo processado.");
    }

    public void CancelOrder(Orders order)
    {
        Console.WriteLine("Pedido cancelado durante o processamento de pagamento.");
        order.SetState(new CanceledState());
    }

    public void SeparateOrder(Orders order)
    {
        Console.WriteLine("Pagamento concluído, separando pedido...");
        order.SetState(new SeparatingOrderState());
    }
}
