using Contracts;
using Domain.Models.Dtos;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Linq;

namespace Service;

/// <summary>
/// Provides functionality to generate PDF documents for invoices.
/// </summary>
public class PDFGenService : IPDFGenService
{
    /// <summary>
    /// Generates a PDF document based on the provided invoice visit details.
    /// </summary>
    /// <param name="data">The invoice visit details to be included in the PDF.</param>
    /// <returns>A byte array representing the generated PDF document.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="data"/> is null.</exception>
    public byte[] GeneratePDF(InvoiceVisitDetailsDto data)
    {
        if (data == null)
            throw new ArgumentNullException(nameof(data));

        var document = Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(2, Unit.Centimetre);
                page.PageColor(Colors.White);
                page.DefaultTextStyle(x => x.FontSize(14));

                // Header section
                page.Header().Element(ComposeHeader);

                // Content section
                page.Content().Element(ComposeContent);

                // Footer section
                page.Footer().AlignCenter().Text(x =>
                {
                    x.Span("Page ");
                    x.CurrentPageNumber();
                    x.Span(" of ");
                    x.TotalPages();
                });

                // Function to compose header
                void ComposeHeader(IContainer container)
                {
                    container.Column(column =>
                    {
                        column.Item().AlignCenter().Text("Vet Clinic Name").Bold().FontSize(20);
                        column.Item().AlignCenter().Text("Invoice Report").Bold().FontSize(18);
                        column.Item().AlignCenter().Text($"Date: {DateTime.Now.ToShortDateString()}").FontSize(12);
                    });
                }

                // Function to compose content
                void ComposeContent(IContainer container)
                {
                    container.Column(column =>
                    {
                        column.Spacing(5);
                        column.Item().Text($"Invoice ID: {data.InvoiceId}").Bold();
                        column.Item().Text($"Visit ID: {data.VisitId}");
                        column.Item().Text($"Visit Date: {data.VisitDate.ToShortDateString()}");
                        column.Item().Text($"Client: {data.UserName}");
                        column.Item().Text($"Veterinarian: {data.EmployeeName}");
                        column.Item().Text($"Invoice Status: {data.InvoiceStatus}");
                        column.Item().Text($"Created: {data.CreatedAt.ToShortDateString()}");
                        column.Item().Text($"Updated: {data.UpdatedAt.ToShortDateString()}");

                        column.Item().LineHorizontal(1).LineColor(Colors.Grey.Medium);

                        // Invoice items section
                        if (data.InvoiceItems.Any())
                        {
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.ConstantColumn(25); // Колонка для індексу
                                    columns.RelativeColumn(1);  // Колонка для типу елементу
                                });

                                // Заголовок таблиці
                                table.Header(header =>
                                {
                                    header.Cell().Element(CellStyle).Text("#").Bold();
                                    header.Cell().Element(CellStyle).Text("Item Description").Bold();

                                    header.Cell().ColumnSpan(2).PaddingTop(5).BorderBottom(1).BorderColor(Colors.Black);
                                });

                                // Рядки таблиці
                                var index = 1;
                                foreach (var item in data.InvoiceItems)
                                {
                                    table.Cell().Element(CellStyle).Text($"{index++}");
                                    table.Cell().Element(CellStyle).Text($"{item.ItemType}");
                                }
                            });
                        }

                        else
                        {
                            column.Item().Text("No items available").Italic().FontColor(Colors.Grey.Medium);
                        }
                    });
                }
            });
        });

        return document.GeneratePdf();
    }

    private static IContainer CellStyle(IContainer container)
    {
        return container.BorderBottom(1).BorderColor(Colors.Grey.Lighten2).PaddingVertical(5);
    }
}