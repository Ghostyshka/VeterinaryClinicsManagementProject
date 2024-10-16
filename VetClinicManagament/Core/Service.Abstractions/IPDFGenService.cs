using Domain.Models.Dtos;

namespace Contracts;

public interface IPDFGenService
{
    byte[] GeneratePDF(InvoiceVisitDetailsDto data);
}