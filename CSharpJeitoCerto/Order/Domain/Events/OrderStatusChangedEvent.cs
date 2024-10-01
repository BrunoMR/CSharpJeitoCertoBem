using CSharpJeitoCerto.Order.Domain.ValueObjects;
using CSharpJeitoCerto.Shared.Domain;

namespace CSharpJeitoCerto.Order.Domain.Events;

public class OrderStatusChangedEvent : IDomainEvent
{
    public Guid OrderId { get; }
    public OrderStatus Status { get; }

    public OrderStatusChangedEvent(Guid orderId, OrderStatus status)
    {
        OrderId = orderId;
        Status = status;
    }
}