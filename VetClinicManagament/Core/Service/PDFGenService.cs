﻿using Contracts;
using Domain.Models.Dtos;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Service;

/// <summary>
/// Provides functionality to generate PDF documents for invoices.
/// </summary>
public class PDFGenService : IPDFGenService
{
    private static IContainer CellStyle(IContainer container)
    {
        return container.BorderBottom(1).BorderColor(Colors.Grey.Lighten2).PaddingVertical(5);
    }
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

                page.Header().Element(ComposeHeader);

                page.Content().Element(ComposeContent);

                page.Footer().AlignCenter().Text(x =>
                {
                    x.Span("Page ");
                    x.CurrentPageNumber();
                    x.Span(" of ");
                    x.TotalPages();
                });

                void ComposeHeader(IContainer container)
                {
                    container.Column(column =>
                    {
                        column.Item().AlignCenter().Text("Vet Clinic Name").Bold().FontSize(20);
                        column.Item().AlignCenter().Text("Invoice Report").Bold().FontSize(18);
                        column.Item().AlignCenter().Text($"Date: {DateTime.Now.ToShortDateString()}").FontSize(12);
                    });
                }

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

                        if (data.InvoiceItems.Any())
                        {
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.ConstantColumn(25);
                                    columns.RelativeColumn(2);
                                    columns.ConstantColumn(60);
                                    columns.ConstantColumn(80);
                                    columns.ConstantColumn(80);
                                });

                                table.Header(header =>
                                {
                                    header.Cell().Element(CellStyle).Text("#").Bold();
                                    header.Cell().Element(CellStyle).Text("Item Description").Bold();
                                    header.Cell().Element(CellStyle).Text("Quantity").Bold();
                                    header.Cell().Element(CellStyle).Text("Price").Bold();
                                    header.Cell().Element(CellStyle).Text("Total").Bold();

                                    header.Cell().ColumnSpan(5).PaddingTop(5).BorderBottom(1).BorderColor(Colors.Black);
                                });

                                var index = 1;
                                decimal grandTotal = 0;
                                foreach (var item in data.InvoiceItems)
                                {
                                    decimal itemTotal = item.Quantity * (decimal)item.Price;
                                    grandTotal += itemTotal;

                                    table.Cell().Element(CellStyle).Text($"{index++}");
                                    table.Cell().Element(CellStyle).Text($"{item.ItemType}");
                                    table.Cell().Element(CellStyle).Text($"{item.Quantity}");
                                    table.Cell().Element(CellStyle).Text($"{item.Price:C}");
                                    table.Cell().Element(CellStyle).Text($"{itemTotal:C}");
                                }

                                table.Footer(footer =>
                                {
                                    footer.Cell().ColumnSpan(4).AlignRight().Element(CellStyle).Text("Grand Total:").Bold();
                                    footer.Cell().Element(CellStyle).Text($"{grandTotal:C}").Bold();
                                });
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

    public byte[] GenerateVisitPDF(VisitReportDto data)
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

                page.Header().Element(ComposeHeader);
                page.Content().Element(ComposeContent);
                page.Footer().AlignCenter().Text(x =>
                {
                    x.Span("Page ");
                    x.CurrentPageNumber();
                    x.Span(" of ");
                    x.TotalPages();
                });

                void ComposeHeader(IContainer container)
                {
                    container.Column(column =>
                    {
                        column.Item().AlignCenter().Text("Vet Clinic Name").Bold().FontSize(20);
                        column.Item().AlignCenter().Text("Visit Report").Bold().FontSize(18);
                        column.Item().AlignCenter().Text($"Date: {DateTime.Now.ToShortDateString()}").FontSize(12);
                    });
                }

                void ComposeContent(IContainer container)
                {
                    container.Column(column =>
                    {
                        column.Spacing(5);
                        column.Item().Text($"Visit ID: {data.VisitId}").Bold();
                        column.Item().Text($"Date: {data.DataOfVisit.ToShortDateString()}");
                        column.Item().Text($"Client: {data.UserFullName}");
                        column.Item().Text($"Veterinarian: {data.EmployeeFullName}");
                        column.Item().Text($"Status: {data.Status}");
                        column.Item().Text($"Description: {data.Description}");

                        column.Item().LineHorizontal(1).LineColor(Colors.Grey.Medium);

                        if (data.InvoiceId.HasValue)
                        {
                            column.Item().Text("Invoice Details:").Bold();
                            column.Item().Text($"Invoice ID: {data.InvoiceId}");
                            column.Item().Text($"Created At: {data.InvoiceCreatedAt.ToShortDateString()}");
                            column.Item().Text($"Status: {data.InvoiceStatus}");

                            if (data.InvoiceItems != null && data.InvoiceItems.Any())
                            {
                                column.Item().Text("Invoice Items:").Bold();
                                column.Item().Table(table =>
                                {
                                    table.ColumnsDefinition(columns =>
                                    {
                                        columns.RelativeColumn(1);
                                        columns.RelativeColumn(1);
                                        columns.RelativeColumn(1);
                                    });

                                    table.Header(header =>
                                    {
                                        header.Cell().Text("Item Type").Bold();
                                        header.Cell().Text("Quantity").Bold();
                                        header.Cell().Text("Price").Bold();
                                    });

                                    foreach (var item in data.InvoiceItems)
                                    {
                                        table.Cell().Text(item.ItemType);
                                        table.Cell().Text(item.Quantity.ToString());
                                        table.Cell().Text(item.Price.ToString("C"));
                                    }
                                });
                            }
                        }

                        column.Item().LineHorizontal(1).LineColor(Colors.Grey.Medium);

                        if (data.TreatmentId.HasValue && data.TreatmentDescription != null)
                        {
                            column.Item().Text("Treatment Plan:").Bold();
                            column.Item().Text($"Treatment ID: {data.TreatmentId}");
                            column.Item().Text($"Description: {data.TreatmentDescription}");
                            column.Item().Text($"Start Date: {data.StartOfTreatment.ToShortDateString()}");
                            column.Item().Text($"End Date: {data.EndOfTreatment.ToShortDateString()}");
                            column.Item().Text($"In Clinic: {(data.InClinic ? "Yes" : "No")}");

                            if (data.TreatmentPlanItems != null && data.TreatmentPlanItems.Any())
                            {
                                column.Item().Table(table =>
                                {
                                    table.ColumnsDefinition(columns =>
                                    {
                                        columns.RelativeColumn(1);
                                        columns.RelativeColumn(1);
                                        columns.RelativeColumn(1);
                                        columns.RelativeColumn(1);
                                    });

                                    table.Header(header =>
                                    {
                                        header.Cell().Text("Service").Bold();
                                        header.Cell().Text("Medical").Bold();
                                        header.Cell().Text("Dosage").Bold();
                                        header.Cell().Text("Quantity").Bold();
                                    });

                                    foreach (var item in data.TreatmentPlanItems)
                                    {
                                        table.Cell().Text(item.ServiceId.ToString());
                                        table.Cell().Text(item.MedicalId.ToString());
                                        table.Cell().Text(item.Dosage);
                                        table.Cell().Text(item.Quantity.ToString());
                                    }
                                });
                            }
                        }
                    });
                }
            });
        });

        return document.GeneratePdf();
    }
}