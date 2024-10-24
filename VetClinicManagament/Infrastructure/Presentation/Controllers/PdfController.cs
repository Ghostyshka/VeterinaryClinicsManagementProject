using AutoMapper;
using Contracts;
using Domain.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Presentation.Controllers.Base;

namespace Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class PdfController : BaseController
{
    private readonly IPDFGenService _pdfGenService;
    private readonly IInvoiceService _invoiceService;
    private readonly IVisitService _visitService;
    private readonly IVisitReportService _visitReportService;
    private readonly IMapper _mapper;

    public PdfController(
    IPDFGenService pdfGenService,
    IInvoiceService invoiceService,
    IVisitService visitService,
    IVisitReportService visitReportService,
    IConfiguration configuration,
    IMapper mapper,
    ILogger<PdfController> logger
) : base(configuration, logger)
    {
        _pdfGenService = pdfGenService;
        _invoiceService = invoiceService;
        _visitService = visitService;
        _visitReportService = visitReportService;
        _mapper = mapper;
    }

    [HttpGet("invoice/{invoiceId}")]
    public async Task<IActionResult> GeneratePdf(int invoiceId)
    {
        var invoice = await _invoiceService.GetInvoiceDetailsAsync(invoiceId);

        if (invoice == null)
        {
            return NotFound();
        }

        var invoiceDetailsDto = _mapper.Map<InvoiceVisitDetailsDto>(invoice);
        var pdf = _pdfGenService.GeneratePDF(invoiceDetailsDto);

        return File(pdf, "application/pdf", "GeneratedInvoice.pdf");
    }

    [HttpGet("visit/{visitId}")]
    public async Task<IActionResult> GetVisitPdf(int visitId)
    {
        var visitReport = await _visitReportService.GetVisitReportByIdAsync(visitId);

        if (visitReport == null)
            return NotFound();

        var pdfBytes = _pdfGenService.GenerateVisitPDF(visitReport);
        return File(pdfBytes, "application/pdf", $"Visit_{visitId}.pdf");
    }
}