namespace ISO9001.IncidentReport.Core.Presenters.GenerateIncidentReportReport
{
    internal class GenerateIncidentReportReportPresenter(
        IReportsOutputPort outputPortReport,
        IReportsPresenter reportsPresenter,
        IReportAsBytes reportBytes) : IGenerateIncidentReportReportOutputPort
    {
        public ReportViewModel ReportViewModel { get; private set; }

        public async Task Handle(IEnumerable<IncidentReportResponse> incidentReportResponses, string companyId)
        {
            Setup reportSetUp = new()
            {
                Page = new Format() { Orientation = Orientation.Landscape, Dimension = PageSize.A4, Background = "White" },
                Header = new Section(new Format(PageSize.A4.Height, 47) { Background = "White" }),
                Body = new Section(new Format(PageSize.A4.Height, 150) { Background = "White" }) { Row = new Row(new Dimension(PageSize.A4.Height, 14)) },
                Footer = new Section(new Format(PageSize.A4.Height, 13) { Background = "White" })
            };

            reportSetUp.Header.AddColumn(new ColumnSetup
            {
                Format = new Format(40, 20)
                {
                    Margin = new(0, 0, 0, 20),
                    Position = new(25, 20),
                    FontDetails = new Font("Tahoma", new Shade(20, "#3538B0"), new FontStyle(700)),
                    TextAlignment = TextAlignment.Left,
                },
                DataColumn = new Item("CompanyTitle")
            });

            reportSetUp.Header.AddColumn(new ColumnSetup
            {
                Format = new Format(257, 20)
                {
                    Position = new(15, 20),
                    FontDetails = new Font("Arial", new Shade(30, "#575758"), new FontStyle(700)),
                    TextAlignment = TextAlignment.Right,
                    Borders = new Border(new Shade(), new Shade(), new Shade(0.5, "Gray", 0.5f), new Shade()),

                },
                DataColumn = new Item("Title")
            });

            reportSetUp.Header.AddColumn(new ColumnSetup
            {
                Format = new Format(257, 20)
                {
                    Position = new(30, 20),
                    FontDetails = new Font("Arial", new Shade(22, "#ADADAE"), new FontStyle(700)),
                    TextAlignment = TextAlignment.Right,

                },
                DataColumn = new Item("SubTitle")
            });

            #region AuditLogs

            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format(210, 9)
                {
                    Margin = new(0, 0, 0, 20),
                    FontDetails = new Font("Arial", new Shade(25)),
                    TextAlignment = TextAlignment.Left,
                    Padding = new(0, 0, 0, 20)

                },
                DataColumn = new Item("NoIncidentReportRecords"),
            });


            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format((int)(257 * 0.15), 10)
                {
                    Position = new(0, 20),
                    Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                    FontDetails = new Font("Arial", new Shade(14, "Black"), new FontStyle(700)),
                    Background = "#DCDCDC",
                    TextAlignment = TextAlignment.Center,
                    Padding = new(3, 0, 0, 0),

                },
                DataColumn = new Item("IncidentReportEntityIdTitle"),
            });

            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format((int)(257 * 0.125), 10)
                {
                    Position = new(0, 58.55m),
                    Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                    FontDetails = new Font("Arial", new Shade(14, "Black"), new FontStyle(700)),
                    Background = "#DCDCDC",
                    TextAlignment = TextAlignment.Center,
                    Padding = new(3, 0, 0, 0),

                },
                DataColumn = new Item("IncidentReportedAtTitle"),
            });

            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format((int)(257 * 0.125), 10)
                {
                    Position = new(0, 90.675m),
                    Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                    FontDetails = new Font("Arial", new Shade(14, "Black"), new FontStyle(700)),
                    Background = "#DCDCDC",
                    TextAlignment = TextAlignment.Center,
                    Padding = new(3, 0, 0, 0),

                },
                DataColumn = new Item("IncidentReportUserIdTitle"),
            });

            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format((int)(257 * 0.15), 10)
                {
                    Position = new(0, 122.8m),
                    Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                    FontDetails = new Font("Arial", new Shade(14, "Black"), new FontStyle(700)),
                    Background = "#DCDCDC",
                    TextAlignment = TextAlignment.Center,
                    Padding = new(3, 0, 0, 0),

                },
                DataColumn = new Item("IncidentReportDescriptionTitle"),
            });

            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format((int)(257 * 0.125), 10)
                {
                    Position = new(0, 161.35m),
                    Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                    FontDetails = new Font("Arial", new Shade(14, "Black"), new FontStyle(700)),
                    Background = "#DCDCDC",
                    TextAlignment = TextAlignment.Center,
                    Padding = new(3, 0, 0, 0),

                },
                DataColumn = new Item("IncidentReportAffectedProcessTitle"),
            });

            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format((int)(257 * 0.125), 10)
                {
                    Position = new(0, 193.475m),
                    Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                    FontDetails = new Font("Arial", new Shade(14, "Black"), new FontStyle(700)),
                    Background = "#DCDCDC",
                    TextAlignment = TextAlignment.Center,
                    Padding = new(3, 0, 0, 0),

                },
                DataColumn = new Item("IncidentReportSeverityTitle"),
            });

            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format((int)(257 * 0.20), 10)
                {
                    Position = new(0, 225.6m),
                    Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                    FontDetails = new Font("Arial", new Shade(14, "Black"), new FontStyle(700)),
                    Background = "#DCDCDC",
                    TextAlignment = TextAlignment.Center,
                    Padding = new(3, 0, 0, 0),

                },
                DataColumn = new Item("IncidentReportDataTitle"),
            });


            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format((int)(257 * 0.15), 10)
                {
                    Position = new(0, 20),
                    Margin = new(0, 0, 0, 20),
                    Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                    FontDetails = new Font("Arial", new Shade(12)),
                    Background = "white",
                    TextAlignment = TextAlignment.Center,
                    Padding = new(4, 0, 0, 0),


                },
                DataColumn = new Item("IncidentReportEntityIdColumn"),
            });

            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format((int)(257 * 0.125), 10)
                {
                    Position = new(0, 58.55m),
                    Margin = new(0, 0, 0, 20),
                    Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                    FontDetails = new Font("Arial", new Shade(12)),
                    Background = "white",
                    TextAlignment = TextAlignment.Center,
                    Padding = new(4, 0, 0, 0),


                },
                DataColumn = new Item("IncidentReportedAtColumn"),
            });

            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format((int)(257 * 0.125), 10)
                {
                    Position = new(0, 90.675m),
                    Margin = new(0, 0, 0, 20),
                    Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                    FontDetails = new Font("Arial", new Shade(12)),
                    Background = "white",
                    TextAlignment = TextAlignment.Center,
                    Padding = new(4, 0, 0, 0),
                },
                DataColumn = new Item("IncidentReportUserIdColumn"),
            });

            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format((int)(257 * 0.15), 10)
                {
                    Position = new(0, 122.8m),
                    Margin = new(0, 0, 0, 20),
                    Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                    FontDetails = new Font("Arial", new Shade(12)),
                    Background = "white",
                    TextAlignment = TextAlignment.Center,
                    Padding = new(4, 0, 0, 0),
                },
                DataColumn = new Item("IncidentReportDescriptionColumn"),
            });

            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format((int)(257 * 0.125), 10)
                {
                    Position = new(0, 161.35m),
                    Margin = new(0, 0, 0, 20),
                    Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                    FontDetails = new Font("Arial", new Shade(12)),
                    Background = "white",
                    TextAlignment = TextAlignment.Center,
                    Padding = new(4, 0, 0, 0),
                },
                DataColumn = new Item("IncidentReportAffectedProcessColumn"),
            });

            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format((int)(257 * 0.125), 10)
                {
                    Position = new(0, 193.475m),
                    Margin = new(0, 0, 0, 20),
                    Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                    FontDetails = new Font("Arial", new Shade(12)),
                    Background = "white",
                    TextAlignment = TextAlignment.Center,
                    Padding = new(4, 0, 0, 0),
                },
                DataColumn = new Item("IncidentReportSeverityColumn"),
            });

            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format((int)(257 * 0.20), 10)
                {
                    Position = new(0, 225.6m),
                    Margin = new(0, 0, 0, 20),
                    Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                    FontDetails = new Font("Arial", new Shade(12)),
                    Background = "white",
                    TextAlignment = TextAlignment.Center,
                    Padding = new(4, 0, 0, 0),
                },
                DataColumn = new Item("IncidentReportDataColumn"),
            });
            #endregion



            int rowIndex = 1;

            var data = new List<ColumnData>
            {
                new ColumnData { Section = SectionType.Header, Column = new Item("CompanyTitle"), Value = $"Compañía: {CultureInfo.CurrentCulture.TextInfo.ToTitleCase(companyId)}" },
                new ColumnData { Section = SectionType.Header, Column = new Item("Title"), Value = "Incident Report Log" },
                new ColumnData { Section = SectionType.Header, Column = new Item("SubTitle"), Value = "ISO 9001:2015" },
            }
            ;

            if (incidentReportResponses == null || !incidentReportResponses.Any())
            {
                data.Add(new ColumnData
                {
                    Section = SectionType.Body,
                    Column = new Item("NoIncidentReportRecords"),
                    Value = "No hay registros en estas fechas",
                    Row = rowIndex++
                });
            }
            else
            {
                data.AddRange(new[]
                {
                    new ColumnData { Section = SectionType.Body, Column = new Item("IncidentReportEntityIdTitle"), Value = "EntityId" , Row = rowIndex},
                    new ColumnData { Section = SectionType.Body, Column = new Item("IncidentReportedAtTitle"), Value = "ReportedAt" , Row = rowIndex},
                    new ColumnData { Section = SectionType.Body, Column = new Item("IncidentReportUserIdTitle"), Value = "UserId" , Row = rowIndex},
                    new ColumnData { Section = SectionType.Body, Column = new Item("IncidentReportDescriptionTitle"), Value = "Description" , Row = rowIndex},
                    new ColumnData { Section = SectionType.Body, Column = new Item("IncidentReportAffectedProcessTitle"), Value = "AffectedProcess" , Row = rowIndex},
                    new ColumnData { Section = SectionType.Body, Column = new Item("IncidentReportSeverityTitle"), Value = "Severity" , Row = rowIndex},
                    new ColumnData { Section = SectionType.Body, Column = new Item("IncidentReportDataTitle"), Value = "Data" , Row = rowIndex}



                });
                rowIndex++;
                foreach (var incidentReport in incidentReportResponses)
                {
                    data.Add(new ColumnData { Section = SectionType.Body, Column = new Item("IncidentReportEntityIdColumn"), Value = incidentReport.EntityId ?? "", Row = rowIndex });
                    data.Add(new ColumnData { Section = SectionType.Body, Column = new Item("IncidentReportedAtColumn"), Value = incidentReport.ReportedAt.ToString("yyyy-MM-dd HH:mm:ss") ?? "", Row = rowIndex });
                    data.Add(new ColumnData { Section = SectionType.Body, Column = new Item("IncidentReportUserIdColumn"), Value = incidentReport.UserId ?? "", Row = rowIndex });
                    data.Add(new ColumnData { Section = SectionType.Body, Column = new Item("IncidentReportDescriptionColumn"), Value = incidentReport.Description ?? "", Row = rowIndex });
                    data.Add(new ColumnData { Section = SectionType.Body, Column = new Item("IncidentReportAffectedProcessColumn"), Value = incidentReport.AffectedProcess ?? "", Row = rowIndex });
                    data.Add(new ColumnData { Section = SectionType.Body, Column = new Item("IncidentReportSeverityColumn"), Value = incidentReport.Severity ?? "", Row = rowIndex });
                    data.Add(new ColumnData { Section = SectionType.Body, Column = new Item("IncidentReportDataColumn"), Value = incidentReport.Data ?? "", Row = rowIndex });


                    rowIndex++;
                }
            }
            await outputPortReport.Handle(reportSetUp, data);
            ReportViewModel = reportsPresenter.Content;

            ReportViewModel reportModel = new ReportViewModel(reportSetUp, data);
            byte[] pdfBytes = await reportBytes.GenerateReport(reportModel);
            string folderPath = @"C:\Reports";
            string filePath = Path.Combine(folderPath, "ReporteIncidentReport.pdf");
            await File.WriteAllBytesAsync(filePath, pdfBytes);

        }
    }
}
