namespace Domain.Enum;

public enum InvoiceStatus
{
    Draft = 1,            // Invoice is created but not yet sent
    Sent = 2,             // Invoice has been sent to the client
    PartiallyPaid = 3,    // Client has made a partial payment
    Paid = 4,             // Invoice is fully paid
    Overdue = 5,          // Invoice is past the due date
    Canceled = 6,         // Invoice has been canceled
    Refunded = 7,         // Payment has been refunded to the client
    Disputed = 8,         // Client has raised a dispute
    Processing = 9,       // Payment is currently being processed
    FailedPayment = 10,   // Payment attempt failed
    WrittenOff = 11,      // Invoice is uncollectible
    PendingApproval = 12  // Invoice is awaiting internal approval
}