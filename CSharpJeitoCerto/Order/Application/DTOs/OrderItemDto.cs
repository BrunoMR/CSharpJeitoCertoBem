namespace CSharpJeitoCerto.Order.Application.DTOs;

public record OrderItemDto(
    string ProductName,
    decimal Price,
    int Quantity,
    int Stock
);