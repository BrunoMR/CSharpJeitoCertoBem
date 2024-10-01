using CSharpJeitoCerto.Order.Domain.Entities;

namespace CSharpJeitoCerto.Order.Domain.States;

public class WaitingStockState : IOrderState
{
    public void ProcessPayment(Orders order)
    {
        Console.WriteLine("O pagamento já foi concluído. Não é possível processar o pagamento novamente.");
    }

    public void CancelOrder(Orders order)
    {
        Console.WriteLine("Pedido cancelado enquanto aguardava o estoque.");
        order.SetState(new CanceledState());
    }

    public void SeparateOrder(Orders order)
    {
        Console.WriteLine("Estoque ainda não foi reposto. Aguardando itens em falta.");
    }

    public void ReplenishStock(Orders order)
    {
        Console.WriteLine("Estoque reposto. Retomando separação de itens.");
        order.SetState(new SeparatingOrderState());
    }
}
