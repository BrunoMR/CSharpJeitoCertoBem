namespace CSharpJeitoCerto.Order.Application.Commands;

using MediatR;

public record CancelOrderCommand(Guid OrderId) : IRequest<bool>;