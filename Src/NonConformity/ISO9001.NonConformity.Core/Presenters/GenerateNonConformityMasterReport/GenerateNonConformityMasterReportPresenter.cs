namespace ISO9001.NonConformity.Core.Presenters.GenerateNonConformityMasterReport
{
    internal class GenerateNonConformityMasterReportPresenter(
        IReportsOutputPort outputPortReport,
        IReportsPresenter reportsPresenter) : IGenerateNonConformityMasterReportOutputPort
    {
        public ReportViewModel ReportViewModel { get; private set; }

        public async Task Handle(IEnumerable<NonConformityMaterResponse> nonConformityResponses, string companyId)
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

            #region NonConformities

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
                DataColumn = new Item("NonConformityIdTitle"),
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
                DataColumn = new Item("NonConformityEntityIdTitle"),
            });

            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format((int)(257 * 0.15), 10)
                {
                    Position = new(0, 97.1m),
                    Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                    FontDetails = new Font("Arial", new Shade(14, "Black"), new FontStyle(700)),
                    Background = "#DCDCDC",
                    TextAlignment = TextAlignment.Center,
                    Padding = new(3, 0, 0, 0),

                },
                DataColumn = new Item("NonConformityReportedAtTitle"),
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
                DataColumn = new Item("NonConformityAffectedProcessTitle"),
            });

            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format((int)(257 * 0.15), 10)
                {
                    Position = new(0, 174.2m),
                    Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                    FontDetails = new Font("Arial", new Shade(14, "Black"), new FontStyle(700)),
                    Background = "#DCDCDC",
                    TextAlignment = TextAlignment.Center,
                    Padding = new(3, 0, 0, 0),

                },
                DataColumn = new Item("NonConformityCauseTitle"),
            });

            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format((int)(257 * 0.15), 10)
                {
                    Position = new(0, 212.75m),
                    Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                    FontDetails = new Font("Arial", new Shade(14, "Black"), new FontStyle(700)),
                    Background = "#DCDCDC",
                    TextAlignment = TextAlignment.Center,
                    Padding = new(3, 0, 0, 0),

                },
                DataColumn = new Item("NonConformityStatusTitle"),
            });

            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format((int)(257 * 0.10), 10)
                {
                    Position = new(0, 251.3m),
                    Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                    FontDetails = new Font("Arial", new Shade(14, "Black"), new FontStyle(700)),
                    Background = "#DCDCDC",
                    TextAlignment = TextAlignment.Center,
                    Padding = new(3, 0, 0, 0),

                },
                DataColumn = new Item("NonConformityDetailsCountTitle"),
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
                DataColumn = new Item("NonConformityIdColumn"),
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
                DataColumn = new Item("NonConformityEntityIdColumn"),
            });

            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format((int)(257 * 0.15), 10)
                {
                    Position = new(0, 97.1m),
                    Margin = new(0, 0, 0, 20),
                    Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                    FontDetails = new Font("Arial", new Shade(12)),
                    Background = "white",
                    TextAlignment = TextAlignment.Center,
                    Padding = new(4, 0, 0, 0),
                },
                DataColumn = new Item("NonConformityReportedAtColumn"),
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
                DataColumn = new Item("NonConformityAffectedProcessColumn"),
            });

            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format((int)(257 * 0.15), 10)
                {
                    Position = new(0, 174.2m),
                    Margin = new(0, 0, 0, 20),
                    Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                    FontDetails = new Font("Arial", new Shade(12)),
                    Background = "white",
                    TextAlignment = TextAlignment.Center,
                    Padding = new(4, 0, 0, 0),
                },
                DataColumn = new Item("NonConformityCauseColumn"),
            });

            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format((int)(257 * 0.15), 10)
                {
                    Position = new(0, 212.75m),
                    Margin = new(0, 0, 0, 20),
                    Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                    FontDetails = new Font("Arial", new Shade(12)),
                    Background = "white",
                    TextAlignment = TextAlignment.Center,
                    Padding = new(4, 0, 0, 0),
                },
                DataColumn = new Item("NonConformityStatusColumn"),
            });

            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format((int)(257 * 0.10), 10)
                {
                    Position = new(0, 251.3m),
                    Margin = new(0, 0, 0, 20),
                    Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                    FontDetails = new Font("Arial", new Shade(12)),
                    Background = "white",
                    TextAlignment = TextAlignment.Center,
                    Padding = new(4, 0, 0, 0),
                },
                DataColumn = new Item("NonConformityDetailsCountColumn"),
            });
            #endregion



            int rowIndex = 1;

            var data = new List<ColumnData>
            {
                new ColumnData { Section = SectionType.Header, Column = new Item("CompanyTitle"), Value = $"Compañía: {CultureInfo.CurrentCulture.TextInfo.ToTitleCase(companyId)}" },
                new ColumnData { Section = SectionType.Header, Column = new Item("Title"), Value = "NonConformity Master Log" },
                new ColumnData { Section = SectionType.Header, Column = new Item("SubTitle"), Value = "ISO 9001:2015" },
            }
            ;

            if (nonConformityResponses == null || !nonConformityResponses.Any())
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
                    new ColumnData { Section = SectionType.Body, Column = new Item("NonConformityIdTitle"), Value = "Id" , Row = rowIndex},
                    new ColumnData { Section = SectionType.Body, Column = new Item("NonConformityEntityIdTitle"), Value = "EntityId" , Row = rowIndex},
                    new ColumnData { Section = SectionType.Body, Column = new Item("NonConformityReportedAtTitle"), Value = "ReportedAt" , Row = rowIndex},
                    new ColumnData { Section = SectionType.Body, Column = new Item("NonConformityAffectedProcessTitle"), Value = "AffectedProcess" , Row = rowIndex},
                    new ColumnData { Section = SectionType.Body, Column = new Item("NonConformityCauseTitle"), Value = "Cause" , Row = rowIndex},
                    new ColumnData { Section = SectionType.Body, Column = new Item("NonConformityStatusTitle"), Value = "Title" , Row = rowIndex},
                    new ColumnData { Section = SectionType.Body, Column = new Item("NonConformityDetailsCountTitle"), Value = "DetailsCount" , Row = rowIndex}



                });
                rowIndex++;
                foreach (var nonConformity in nonConformityResponses)
                {
                    data.Add(new ColumnData { Section = SectionType.Body, Column = new Item("NonConformityIdColumn"), Value = nonConformity.Id.ToString() ?? "", Row = rowIndex });
                    data.Add(new ColumnData { Section = SectionType.Body, Column = new Item("NonConformityEntityIdColumn"), Value = nonConformity.EntityId.ToString() ?? "", Row = rowIndex });
                    data.Add(new ColumnData { Section = SectionType.Body, Column = new Item("NonConformityReportedAtColumn"), Value = nonConformity.ReportedAt.ToString("yyyy-MM-dd HH:mm:ss") ?? "", Row = rowIndex });
                    data.Add(new ColumnData { Section = SectionType.Body, Column = new Item("NonConformityAffectedProcessColumn"), Value = nonConformity.AffectedProcess ?? "", Row = rowIndex });
                    data.Add(new ColumnData { Section = SectionType.Body, Column = new Item("NonConformityCauseColumn"), Value = nonConformity.Cause ?? "", Row = rowIndex });
                    data.Add(new ColumnData { Section = SectionType.Body, Column = new Item("NonConformityStatusColumn"), Value = nonConformity.Status ?? "", Row = rowIndex });
                    data.Add(new ColumnData { Section = SectionType.Body, Column = new Item("NonConformityDetailsCountColumn"), Value = nonConformity.DetailsCount, Row = rowIndex });


                    rowIndex++;
                }
            }
            await outputPortReport.Handle(reportSetUp, data);
            ReportViewModel = reportsPresenter.Content;
        }
    }
}
