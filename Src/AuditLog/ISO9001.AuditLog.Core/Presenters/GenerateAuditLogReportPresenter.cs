using DigitalDoor.Reporting.Entities.Helpers;
using DigitalDoor.Reporting.Entities.Interfaces;
using DigitalDoor.Reporting.Entities.Models;
using DigitalDoor.Reporting.Entities.ValueObjects;
using DigitalDoor.Reporting.Entities.ViewModels;
using ISO9001.AuditLog.Core.Internals.GenerateAuditLogReport;
using ISO9001.Entities.Responses;

namespace ISO9001.AuditLog.Core.Presenters
{
    internal class GenerateAuditLogReportPresenter(
        IReportAsBytes reportBytes): IGenerateAuditLogReportOutputPort
    {
        public ReportViewModel ReportViewModel { get; private set; }

        public async Task Handle(IEnumerable<AuditLogResponse> auditLogResponses, string entityId, DateTime from, DateTime end)
        {
            Setup reportSetUp = new()
            {
                Page = new Format() { Orientation = Orientation.Landscape, Dimension = PageSize.A4, Background = "White" },
                Header = new Section(new Format(PageSize.A4.Height, 47) { Background = "Red"}  ),
                Body = new Section(new Format(PageSize.A4.Height, 150) { Background = "Blue"}) { Row = new Row(new Dimension(PageSize.A4.Height, 9)) },
                Footer = new Section(new Format(PageSize.A4.Height, 13) { Background = "Green"})
            };


            #region CustomerFeedbacks

            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format(210, 9)
                {
                    Margin = new(0, 0, 0, 20),

                    FontDetails = new Font("Arial", new Shade(18)),
                    TextAlignment = TextAlignment.Left,
                    Padding = new(0, 0, 0, 20)

                },
                DataColumn = new Item("NoAuditLogRecords"),
            });


            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format((int)(170 * 0.3), 7)
                {
                    Position = new(0, 20),
                    Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                    FontDetails = new Font("Arial", new Shade(14, "White"), new FontStyle(700)),
                    Background = "gray",
                    TextAlignment = TextAlignment.Center,
                    Padding = new(1, 0, 2, 0),

                },
                DataColumn = new Item("AuditLogDateTitle"),
            });

            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format((int)(170 * 0.4), 7)
                {
                    Position = new(0, 71),
                    Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                    FontDetails = new Font("Arial", new Shade(14, "White"), new FontStyle(700)),
                    Background = "gray",
                    TextAlignment = TextAlignment.Center,
                    Padding = new(1, 0, 2, 0),

                },
                DataColumn = new Item("AuditLogActionTitle"),
            });

            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format((int)(170 * 0.3), 7)
                {
                    Position = new(0, 139),
                    Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                    FontDetails = new Font("Arial", new Shade(14, "White"), new FontStyle(700)),
                    Background = "gray",
                    TextAlignment = TextAlignment.Center,
                    Padding = new(1, 0, 2, 0),

                },
                DataColumn = new Item("AuditLogPerformedByTitle"),
            });


            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format((int)(170 * 0.3), 7)
                {
                    Position = new(0, 20),
                    Margin = new(0, 0, 0, 20),
                    Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                    FontDetails = new Font("Arial", new Shade(12)),
                    Background = "white",
                    TextAlignment = TextAlignment.Center,
                    Padding = new(2, 0, 0, 0)


                },
                DataColumn = new Item("AuditLogDateColumn"),
            });

            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format((int)(170 * 0.4), 7)
                {
                    Position = new(0, 71),
                    Margin = new(0, 0, 0, 20),
                    Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                    FontDetails = new Font("Arial", new Shade(12)),
                    Background = "white",
                    TextAlignment = TextAlignment.Center,
                    Padding = new(2, 0, 0, 0)


                },
                DataColumn = new Item("AuditLogActionColumn"),
            });

            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format((int)(170 * 0.3), 7)
                {
                    Position = new(0, 139),
                    Margin = new(0, 0, 0, 20),
                    Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                    FontDetails = new Font("Arial", new Shade(12)),
                    Background = "white",
                    TextAlignment = TextAlignment.Center,
                    Padding = new(2, 0, 0, 0)
                },
                DataColumn = new Item("AuditLogPerformedByColumn"),
            });
            #endregion



            int rowIndex = 1;

            var data = new List<ColumnData>();
            //{
            //    new ColumnData { Section = SectionType.Header, Column = new Item("HeaderText"), Value = $"Audit Report – Order: {entityId}" },
            //    new ColumnData { Section = SectionType.Header, Column = new Item("HeaderSubText"), Value = $"Fecha de creación: {DateTime.UtcNow:yyyy-MM-dd}\nEstatus actual: {LatestStatus}" },
            //};

            if (auditLogResponses == null || !auditLogResponses.Any())
            {
                data.Add(new ColumnData
                {
                    Section = SectionType.Body,
                    Column = new Item("NoAuditLogRecords"),
                    Value = "No hay registros en estas fechas",
                    Row = rowIndex++
                });
            }
            else
            {
                data.AddRange(new[]
                {
                    new ColumnData { Section = SectionType.Body, Column = new Item("AuditLogDateTitle"), Value = "Fecha" , Row = rowIndex},
                    new ColumnData { Section = SectionType.Body, Column = new Item("AuditLogActionTitle"), Value = "Action" , Row = rowIndex},
                    new ColumnData { Section = SectionType.Body, Column = new Item("AuditLogPerformedByTitle"), Value = "PerformedBy" , Row = rowIndex},
                });
                rowIndex++;
                foreach (var auditlog in auditLogResponses)
                {
                    data.Add(new ColumnData { Section = SectionType.Body, Column = new Item("AuditLogDateColumn"), Value = auditlog.CreatedAt.ToString("yyyy-MM-dd") ?? "", Row = rowIndex });
                    data.Add(new ColumnData { Section = SectionType.Body, Column = new Item("AuditLogActionColumn"), Value = auditlog.Action ?? "", Row = rowIndex });
                    data.Add(new ColumnData { Section = SectionType.Body, Column = new Item("AuditLogPerformedByColumn"), Value = auditlog.PerformedBy ?? "" , Row = rowIndex });
                    rowIndex++;
                }
            }

            ReportViewModel reportModel = new ReportViewModel(reportSetUp, data);
            byte[] pdfBytes = await reportBytes.GenerateReport(reportModel);
            string folderPath = @"C:\Reports";
            string filePath = Path.Combine(folderPath, "Reporte.pdf");
            await File.WriteAllBytesAsync(filePath, pdfBytes);



        }
    }
}
