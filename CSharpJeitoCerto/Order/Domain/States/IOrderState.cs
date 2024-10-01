using CSharpJeitoCerto.Order.Domain.Entities;

namespace CSharpJeitoCerto.Order.Domain.States;

public interface IOrderState
{
    void ProcessPayment(Orders order);
    void CancelOrder(Orders order);
    void SeparateOrder(Orders order);
}
