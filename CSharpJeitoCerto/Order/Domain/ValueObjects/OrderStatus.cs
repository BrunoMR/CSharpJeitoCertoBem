namespace CSharpJeitoCerto.Order.Domain.ValueObjects;

public enum OrderStatus
{
    WaitingProcessing,
    ProcessingPayment,
    PaymentCompleted,
    SeparatingOrder,
    WaitingStock,
    Completed,
    Canceled
}