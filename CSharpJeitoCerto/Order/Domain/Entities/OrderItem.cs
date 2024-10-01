using CSharpJeitoCerto.Shared.Domain;

namespace CSharpJeitoCerto.Order.Domain.Entities;

public class OrderItem : BaseEntity<Guid>
{
    public Products Products { get; private set; }
    public int Quantity { get; private set; }
    public decimal UnitPrice { get; private set; }

    private OrderItem() { }

    public static OrderItem Create(Products products, int quantity)
    {
        if (products == null || quantity <= 0)
            throw new ArgumentException("Produto inválido ou quantidade inválida.");

        return new OrderItem
        {
            Products = products,
            Quantity = quantity,
            UnitPrice = products.Price
        };
    }

    public decimal CalculateTotalValue()
    {
        return UnitPrice * Quantity;
    }
}
