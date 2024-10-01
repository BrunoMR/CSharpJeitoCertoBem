using CSharpJeitoCerto.Shared.Domain;

namespace CSharpJeitoCerto.Shared.Infrastructure.Messaging;

public class EventBus
{
    private readonly List<IDomainEvent> _domainEvents = new();

    public void Publish(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
        Console.WriteLine($"Evento publicado: {domainEvent.GetType().Name}");
    }

    public IEnumerable<IDomainEvent> GetEvents() => _domainEvents;
}
