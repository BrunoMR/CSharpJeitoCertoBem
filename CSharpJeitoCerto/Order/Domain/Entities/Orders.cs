using CSharpJeitoCerto.Order.Domain.Events;
using CSharpJeitoCerto.Order.Domain.States;
using CSharpJeitoCerto.Order.Domain.ValueObjects;
using CSharpJeitoCerto.Shared.Domain;
using CSharpJeitoCerto.Shared.Domain.ValueObjects;

namespace CSharpJeitoCerto.Order.Domain.Entities
{
    public class Orders : BaseEntity<Guid>, IAggregateRoot
    {
        private readonly List<OrderItem> _items;
        private IOrderState _currentState;
        public OrderStatus Status { get; private set; }

        public DateTime OrderDate { get; private set; }
        public decimal TotalValue { get; private set; }
        public PaymentMethod PaymentMethod { get; private set; }
        public int Installments { get; private set; }
        public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();

        private Orders()
        {
            _items = new List<OrderItem>();
            _currentState = new PendingState(); // Estado inicial
        }

        public static Orders Create(List<OrderItem> items, PaymentMethod paymentMethod, int installments = 1)
        {
            var order = new Orders
            {
                OrderDate = DateTime.UtcNow,
                PaymentMethod = paymentMethod,
                Installments = installments
            };

            order.SetItems(items);
            order.CalculateTotalValue();
            // Estado inicial já definido como "Aguardando Processamento"
            return order;
        }

        private void SetItems(List<OrderItem> items)
        {
            if (items == null || !items.Any())
                throw new ArgumentException("A ordem precisa conter ao menos um item.");

            _items.AddRange(items);
        }

        private void CalculateTotalValue()
        {
            TotalValue = _items.Sum(item => item.CalculateTotalValue());
        }

        // Métodos para interagir com o State Pattern
        public void ProcessPayment()
        {
            _currentState.ProcessPayment(this);
        }

        public void CancelOrder()
        {
            _currentState.CancelOrder(this);
        }

        public void SeparateOrder()
        {
            _currentState.SeparateOrder(this);
        }

        public void ChangeStatus(OrderStatus newStatus)
        {
            Status = newStatus;
            AddDomainEvent(new OrderStatusChangedEvent(Id, Status));
        }

        public void SetState(IOrderState newState)
        {
            _currentState = newState;
        }

        // Mantemos o método para cálculo de desconto e juros
        public void ApplyDiscount(decimal discount)
        {
            if (discount < 0 || discount > TotalValue)
                throw new ArgumentException("Desconto inválido.");

            TotalValue -= discount;
        }

        public void AddInterest(decimal interest)
        {
            if (interest < 0)
                throw new ArgumentException("Juros inválido.");

            TotalValue += interest;
        }

        public bool Cancel()
        {
            if (Status == OrderStatus.Completed)
            {
                return false;
            }

            ChangeStatus(OrderStatus.Canceled);
            return true;
        }

    }
}
