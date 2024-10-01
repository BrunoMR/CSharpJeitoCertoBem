using CSharpJeitoCerto.Order.Domain.Entities;

namespace CSharpJeitoCerto.Order.Domain.States;

public class SeparatingOrderState : IOrderState
{
    public void ProcessPayment(Orders order)
    {
        Console.WriteLine("O pagamento já foi processado. Não é possível processar o pagamento novamente.");
    }

    public void CancelOrder(Orders order)
    {
        Console.WriteLine("Pedido cancelado durante a separação de itens.");
        order.SetState(new CanceledState());
    }

    public void SeparateOrder(Orders order)
    {
        Console.WriteLine("Separando pedido...");

        var estoqueDisponivel = true;
        if (estoqueDisponivel)
        {
            Console.WriteLine("Todos os itens estão disponíveis no estoque. Pedido concluído.");
            order.SetState(new CompletedState());
        }
        else
        {
            Console.WriteLine("Alguns itens estão em falta. Aguardando reposição.");
            order.SetState(new WaitingStockState());
        }
    }
}
