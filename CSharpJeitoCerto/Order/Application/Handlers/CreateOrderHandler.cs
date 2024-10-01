using CSharpJeitoCerto.Order.Application.Commands;
using CSharpJeitoCerto.Order.Domain.Entities;
using CSharpJeitoCerto.Order.Domain.Repositories;
using MediatR;

namespace CSharpJeitoCerto.Order.Application.Handlers;

public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, Guid>
{
    private readonly IOrderRepository _orderRepository;

    public CreateOrderHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var items = request.Items.Select(i => OrderItem.Create(
            Products.Create(i.ProductName, i.Price, i.Stock), i.Quantity)).ToList();
        var order = Orders.Create(items, request.PaymentMethod, request.Installments);
        await _orderRepository.AddAsync(order);
        return order.Id;
    }
}
