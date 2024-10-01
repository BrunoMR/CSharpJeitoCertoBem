using CSharpJeitoCerto.Shared.Domain;

namespace CSharpJeitoCerto.Order.Domain.Entities;

public class Products : BaseEntity<Guid>
{
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public int Stock { get; private set; }

    private Products() { }

    public static Products Create(string name, decimal price, int stock)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Nome do produto é obrigatório.");
        if (price <= 0)
            throw new ArgumentException("Preço do produto deve ser maior que zero.");
        if (stock < 0)
            throw new ArgumentException("Estoque não pode ser negativo.");

        return new Products
        {
            Name = name,
            Price = price,
            Stock = stock
        };
    }

    public void DecreaseStock(int quantity)
    {
        if (quantity <= 0 || quantity > Stock)
            throw new ArgumentException("Quantidade inválida.");

        Stock -= quantity;
    }
}