using CSharpJeitoCerto.Order.Domain.Entities;
using CSharpJeitoCerto.Order.Domain.States;

public class PendingState : IOrderState
{
    public void ProcessPayment(Orders order)
    {
        Console.WriteLine("Processando pagamento...");
        order.SetState(new ProcessingPaymentState());
    }

    public void CancelOrder(Orders order)
    {
        Console.WriteLine("Pedido cancelado.");
        order.SetState(new CanceledState());
    }

    public void SeparateOrder(Orders order)
    {
        Console.WriteLine("Não é possível separar o pedido. O pagamento não foi processado.");
    }
}