namespace ISO9001.AuditLog.Core.Presenters.GenerateAuditLogReport
{
    internal class GenerateAuditLogReportPresenter(
        IReportsOutputPort outputPortReport,
        IReportsPresenter reportsPresenter) : IGenerateAuditLogReportOutputPort
    {
        public ReportViewModel ReportViewModel { get; private set; }

        public async Task Handle(IEnumerable<AuditLogResponse> auditLogResponses, string companyId)
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
                DataColumn = new Item("NoRecords"),
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
                DataColumn = new Item("AuditLogEntityIdTitle"),
            });

            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format((int)(257 * 0.15), 10)
                {
                    Position = new(0, 58.55m),
                    Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                    FontDetails = new Font("Arial", new Shade(14, "Black"), new FontStyle(700)),
                    Background = "#DCDCDC",
                    TextAlignment = TextAlignment.Center,
                    Padding = new(3, 0, 0, 0),

                },
                DataColumn = new Item("AuditLogActionTitle"),
            });

            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format((int)(257 * 0.15), 10)
                {
                    Position = new(0, 97.10m),
                    Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                    FontDetails = new Font("Arial", new Shade(14, "Black"), new FontStyle(700)),
                    Background = "#DCDCDC",
                    TextAlignment = TextAlignment.Center,
                    Padding = new(3, 0, 0, 0),

                },
                DataColumn = new Item("AuditLogPerformedByTitle"),
            });

            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format((int)(257 * 0.15), 10)
                {
                    Position = new(0, 135.65m),
                    Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                    FontDetails = new Font("Arial", new Shade(14, "Black"), new FontStyle(700)),
                    Background = "#DCDCDC",
                    TextAlignment = TextAlignment.Center,
                    Padding = new(3, 0, 0, 0),

                },
                DataColumn = new Item("AuditLogTimeStampTitle"),
            });

            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format((int)(257 * 0.15), 10)
                {
                    Position = new(0, 174.20m),
                    Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                    FontDetails = new Font("Arial", new Shade(14, "Black"), new FontStyle(700)),
                    Background = "#DCDCDC",
                    TextAlignment = TextAlignment.Center,
                    Padding = new(3, 0, 0, 0),

                },
                DataColumn = new Item("AuditLogCreatedAtTitle"),
            });

            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format((int)(257 * 0.25), 10)
                {
                    Position = new(0, 212.75m),
                    Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                    FontDetails = new Font("Arial", new Shade(14, "Black"), new FontStyle(700)),
                    Background = "#DCDCDC",
                    TextAlignment = TextAlignment.Center,
                    Padding = new(3, 0, 0, 0),

                },
                DataColumn = new Item("AuditLogDetailsTitle"),
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
                DataColumn = new Item("AuditLogEntityIdColumn"),
            });

            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format((int)(257 * 0.15), 10)
                {
                    Position = new(0, 58.55m),
                    Margin = new(0, 0, 0, 20),
                    Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                    FontDetails = new Font("Arial", new Shade(12)),
                    Background = "white",
                    TextAlignment = TextAlignment.Center,
                    Padding = new(4, 0, 0, 0),


                },
                DataColumn = new Item("AuditLogActionColumn"),
            });

            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format((int)(257 * 0.15), 10)
                {
                    Position = new(0, 97.10m),
                    Margin = new(0, 0, 0, 20),
                    Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                    FontDetails = new Font("Arial", new Shade(12)),
                    Background = "white",
                    TextAlignment = TextAlignment.Center,
                    Padding = new(4, 0, 0, 0),
                },
                DataColumn = new Item("AuditLogPerformedByColumn"),
            });

            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format((int)(257 * 0.15), 10)
                {
                    Position = new(0, 135.65m),
                    Margin = new(0, 0, 0, 20),
                    Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                    FontDetails = new Font("Arial", new Shade(12)),
                    Background = "white",
                    TextAlignment = TextAlignment.Center,
                    Padding = new(4, 0, 0, 0),
                },
                DataColumn = new Item("AuditLogTimeStampColumn"),
            });

            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format((int)(257 * 0.15), 10)
                {
                    Position = new(0, 174.20m),
                    Margin = new(0, 0, 0, 20),
                    Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                    FontDetails = new Font("Arial", new Shade(12)),
                    Background = "white",
                    TextAlignment = TextAlignment.Center,
                    Padding = new(4, 0, 0, 0),
                },
                DataColumn = new Item("AuditLogCreatedAtColumn"),
            });

            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format((int)(257 * 0.25), 10)
                {
                    Position = new(0, 212.75m),
                    Margin = new(0, 0, 0, 20),
                    Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                    FontDetails = new Font("Arial", new Shade(12)),
                    Background = "white",
                    TextAlignment = TextAlignment.Center,
                    Padding = new(4, 0, 0, 0),
                },
                DataColumn = new Item("AuditLogDetailsColumn"),
            });
            #endregion



            int rowIndex = 1;

            var data = new List<ColumnData>
            {
                new ColumnData { Section = SectionType.Header, Column = new Item("CompanyTitle"), Value = $"Compañía: {CultureInfo.CurrentCulture.TextInfo.ToTitleCase(companyId)}" },
                new ColumnData { Section = SectionType.Header, Column = new Item("Title"), Value = "Calibration Log" },
                new ColumnData { Section = SectionType.Header, Column = new Item("SubTitle"), Value = "ISO 9001:2015" },
            }
            ;

            if (auditLogResponses == null || !auditLogResponses.Any())
            {
                data.Add(new ColumnData
                {
                    Section = SectionType.Body,
                    Column = new Item("NoRecords"),
                    Value = "No hay registros en estas fechas",
                    Row = rowIndex++
                });
            }
            else
            {
                data.AddRange(new[]
                {
                    new ColumnData { Section = SectionType.Body, Column = new Item("AuditLogEntityIdTitle"), Value = "EntityId" , Row = rowIndex},
                    new ColumnData { Section = SectionType.Body, Column = new Item("AuditLogActionTitle"), Value = "Action" , Row = rowIndex},
                    new ColumnData { Section = SectionType.Body, Column = new Item("AuditLogPerformedByTitle"), Value = "PerformedBy" , Row = rowIndex},
                    new ColumnData { Section = SectionType.Body, Column = new Item("AuditLogTimeStampTitle"), Value = "TimeStamp" , Row = rowIndex},
                    new ColumnData { Section = SectionType.Body, Column = new Item("AuditLogCreatedAtTitle"), Value = "CreatedAt" , Row = rowIndex},
                    new ColumnData { Section = SectionType.Body, Column = new Item("AuditLogDetailsTitle"), Value = "Details" , Row = rowIndex}


                });
                rowIndex++;
                foreach (var auditlog in auditLogResponses)
                {
                    data.Add(new ColumnData { Section = SectionType.Body, Column = new Item("AuditLogEntityIdColumn"), Value = auditlog.EntityId ?? "", Row = rowIndex });
                    data.Add(new ColumnData { Section = SectionType.Body, Column = new Item("AuditLogActionColumn"), Value = auditlog.Action ?? "", Row = rowIndex });
                    data.Add(new ColumnData { Section = SectionType.Body, Column = new Item("AuditLogPerformedByColumn"), Value = auditlog.PerformedBy ?? "", Row = rowIndex });
                    data.Add(new ColumnData { Section = SectionType.Body, Column = new Item("AuditLogTimeStampColumn"), Value = auditlog.TimeStamp.ToString("yyyy-MM-dd HH:mm:ss") ?? "", Row = rowIndex });
                    data.Add(new ColumnData { Section = SectionType.Body, Column = new Item("AuditLogCreatedAtColumn"), Value = auditlog.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss") ?? "", Row = rowIndex });
                    data.Add(new ColumnData { Section = SectionType.Body, Column = new Item("AuditLogDetailsColumn"), Value = auditlog.Details ?? "", Row = rowIndex });
                    rowIndex++;
                }
            }
            await outputPortReport.Handle(reportSetUp, data);
            ReportViewModel = reportsPresenter.Content;
        }
    }
}
