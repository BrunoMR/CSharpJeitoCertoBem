using CSharpJeitoCerto.Order.Domain.Entities;

namespace CSharpJeitoCerto.Order.Domain.States;

public class CompletedState : IOrderState
{
    public void ProcessPayment(Orders order)
    {
        Console.WriteLine("Pedido já foi concluído. Não é possível processar o pagamento novamente.");
    }

    public void CancelOrder(Orders order)
    {
        Console.WriteLine("Pedido já foi concluído e não pode ser cancelado.");
    }

    public void SeparateOrder(Orders order)
    {
        Console.WriteLine("Pedido já foi separado e concluído.");
    }
}
