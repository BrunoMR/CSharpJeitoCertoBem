using CSharpJeitoCerto.Order.Application.Commands;
using CSharpJeitoCerto.Order.Domain.Repositories;
using MediatR;

namespace CSharpJeitoCerto.Order.Application.Handlers;

public class CancelOrderHandler : IRequestHandler<CancelOrderCommand, bool>
{
    private readonly IOrderRepository _orderRepository;

    public CancelOrderHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<bool> Handle(CancelOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(request.OrderId);

        if (order == null || !order.Cancel())
        {
            return false;
        }

        await _orderRepository.UpdateAsync(order);
        return true;
    }
}