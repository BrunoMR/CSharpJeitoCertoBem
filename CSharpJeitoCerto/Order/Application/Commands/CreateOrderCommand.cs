using CSharpJeitoCerto.Order.Application.DTOs;
using CSharpJeitoCerto.Shared.Domain.ValueObjects;
using MediatR;

namespace CSharpJeitoCerto.Order.Application.Commands;

public record CreateOrderCommand(List<OrderItemDto> Items, PaymentMethod PaymentMethod, int Installments) : IRequest<Guid>;

