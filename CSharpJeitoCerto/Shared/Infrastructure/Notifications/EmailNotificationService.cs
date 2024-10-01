namespace CSharpJeitoCerto.Shared.Infrastructure.Notifications;

public class EmailNotificationService
{
    public Task SendEmailAsync(string email, string subject, string message)
    {
        // Aqui você pode implementar o envio real de emails (e.g., via SMTP, SendGrid)
        Console.WriteLine($"Enviando email para {email}: {subject} - {message}");
        return Task.CompletedTask;
    }

    public Task NotifyOrderStatusChangedAsync(Order.Domain.Entities.Orders orders)
    {
        string subject = $"Status do pedido {orders.Id} atualizado para {orders.Status}";
        string message = $"Olá, o status do seu pedido foi alterado para {orders.Status}. Obrigado por comprar conosco!";
        return SendEmailAsync("cliente@example.com", subject, message);
    }
}