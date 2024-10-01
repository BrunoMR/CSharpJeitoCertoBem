namespace CSharpJeitoCerto.Payment.Domain.Strategies;

public class CreditCardPaymentStrategy : IPaymentStrategy
{
    private readonly int _installments;

    public CreditCardPaymentStrategy(int installments)
    {
        _installments = Math.Min(installments, 12); // Limita as parcelas a no máximo 12
    }

    public Task<bool> ProcessPayment(Order.Domain.Entities.Orders orders)
    {
        // Simulação de cálculo de juros
        decimal interest = 0;
        if (_installments > 1)
        {
            interest = orders.TotalValue * 0.02m * _installments; // Exemplo: 2% de juros por parcela
            orders.AddInterest(interest);
        }

        // Simulação de processamento de pagamento
        Console.WriteLine($"Pagamento com Cartão de Crédito processado com sucesso. Parcelado em {_installments}x. Juros aplicado: R$ {interest:F2}. Valor final: R$ {orders.TotalValue:F2}.");

        return Task.FromResult(true);
    }
}
