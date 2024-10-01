using CSharpJeitoCerto.Order.Domain.Entities;

namespace CSharpJeitoCerto.Order.Domain.States;

public class CanceledState : IOrderState
{
    public void ProcessPayment(Orders order)
    {
        Console.WriteLine("Pedido cancelado. Não é possível processar o pagamento.");
    }

    public void CancelOrder(Orders order)
    {
        Console.WriteLine("Pedido já está cancelado.");
    }

    public void SeparateOrder(Orders order)
    {
        Console.WriteLine("Pedido cancelado. Não é possível separar.");
    }
}
