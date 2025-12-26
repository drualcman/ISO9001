using ISO9001.Core.Responses;

namespace ISO9001.Core.Features.NonConformity.Presenters;

internal class GenerateNonConformityDetailsReportPresenter(
    IReportsOutputPort outputPortReport,
    IReportsPresenter reportsPresenter) : IGenerateNonConformityDetailsReportOutputPort
{
    public ReportViewModel ReportViewModel { get; private set; }

    public async Task Handle(IEnumerable<NonConformityDetailResponse> nonConformityDetailsResponses, string companyId)
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

        #region NonConformityDetails

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
            DataColumn = new Item("NonConformityDetailReportedAtTitle"),
        });

        reportSetUp.Body.AddColumn(new ColumnSetup
        {
            Format = new Format((int)(257 * 0.20), 10)
            {
                Position = new(0, 58.55m),
                Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                FontDetails = new Font("Arial", new Shade(14, "Black"), new FontStyle(700)),
                Background = "#DCDCDC",
                TextAlignment = TextAlignment.Center,
                Padding = new(3, 0, 0, 0),

            },
            DataColumn = new Item("NonConformityDetailReportedByTitle"),
        });

        reportSetUp.Body.AddColumn(new ColumnSetup
        {
            Format = new Format((int)(257 * 0.45), 10)
            {
                Position = new(0, 110m),
                Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                FontDetails = new Font("Arial", new Shade(14, "Black"), new FontStyle(700)),
                Background = "#DCDCDC",
                TextAlignment = TextAlignment.Center,
                Padding = new(3, 0, 0, 0),

            },
            DataColumn = new Item("NonConformityDetailDescriptionTitle"),
        });

        reportSetUp.Body.AddColumn(new ColumnSetup
        {
            Format = new Format((int)(257 * 0.20), 10)
            {
                Position = new(0, 225.65m),
                Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                FontDetails = new Font("Arial", new Shade(14, "Black"), new FontStyle(700)),
                Background = "#DCDCDC",
                TextAlignment = TextAlignment.Center,
                Padding = new(3, 0, 0, 0),

            },
            DataColumn = new Item("NonConformityDetailStatusTitle"),
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
            DataColumn = new Item("NonConformityDetailReportedAtColumn"),
        });

        reportSetUp.Body.AddColumn(new ColumnSetup
        {
            Format = new Format((int)(257 * 0.20), 10)
            {
                Position = new(0, 58.55m),
                Margin = new(0, 0, 0, 20),
                Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                FontDetails = new Font("Arial", new Shade(12)),
                Background = "white",
                TextAlignment = TextAlignment.Center,
                Padding = new(4, 0, 0, 0),


            },
            DataColumn = new Item("NonConformityDetailReportedByColumn"),
        });

        reportSetUp.Body.AddColumn(new ColumnSetup
        {
            Format = new Format((int)(257 * 0.45), 10)
            {
                Position = new(0, 110m),
                Margin = new(0, 0, 0, 20),
                Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                FontDetails = new Font("Arial", new Shade(12)),
                Background = "white",
                TextAlignment = TextAlignment.Center,
                Padding = new(4, 0, 0, 0),
            },
            DataColumn = new Item("NonConformityDetailDescriptionColumn"),
        });

        reportSetUp.Body.AddColumn(new ColumnSetup
        {
            Format = new Format((int)(257 * 0.20), 10)
            {
                Position = new(0, 225.65m),
                Margin = new(0, 0, 0, 20),
                Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                FontDetails = new Font("Arial", new Shade(12)),
                Background = "white",
                TextAlignment = TextAlignment.Center,
                Padding = new(4, 0, 0, 0),
            },
            DataColumn = new Item("NonConformityDetailStatusColumn"),
        });
        #endregion



        int rowIndex = 1;

        var data = new List<ColumnData>
        {
            new ColumnData { Section = SectionType.Header, Column = new Item("CompanyTitle"), Value = $"Compañía: {CultureInfo.CurrentCulture.TextInfo.ToTitleCase(companyId)}" },
            new ColumnData { Section = SectionType.Header, Column = new Item("Title"), Value = "NonConformity Details Log" },
            new ColumnData { Section = SectionType.Header, Column = new Item("SubTitle"), Value = "ISO 9001:2015" },
        }
        ;

        if (nonConformityDetailsResponses == null || !nonConformityDetailsResponses.Any())
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
                new ColumnData { Section = SectionType.Body, Column = new Item("NonConformityDetailReportedAtTitle"), Value = "ReportedAt" , Row = rowIndex},
                new ColumnData { Section = SectionType.Body, Column = new Item("NonConformityDetailReportedByTitle"), Value = "ReportedBy" , Row = rowIndex},
                new ColumnData { Section = SectionType.Body, Column = new Item("NonConformityDetailDescriptionTitle"), Value = "Description" , Row = rowIndex},
                new ColumnData { Section = SectionType.Body, Column = new Item("NonConformityDetailStatusTitle"), Value = "Status" , Row = rowIndex}



            });
            rowIndex++;
            foreach (var nonConformityDetail in nonConformityDetailsResponses)
            {
                data.Add(new ColumnData { Section = SectionType.Body, Column = new Item("NonConformityDetailReportedAtColumn"), Value = nonConformityDetail.ReportedAt.ToString("yyyy-MM-dd HH:mm:ss") ?? "", Row = rowIndex });
                data.Add(new ColumnData { Section = SectionType.Body, Column = new Item("NonConformityDetailReportedByColumn"), Value = nonConformityDetail.ReportedBy ?? "", Row = rowIndex });
                data.Add(new ColumnData { Section = SectionType.Body, Column = new Item("NonConformityDetailDescriptionColumn"), Value = nonConformityDetail.Description ?? "", Row = rowIndex });
                data.Add(new ColumnData { Section = SectionType.Body, Column = new Item("NonConformityDetailStatusColumn"), Value = nonConformityDetail.Status ?? "", Row = rowIndex });


                rowIndex++;
            }
        }
        await outputPortReport.Handle(reportSetUp, data);
        ReportViewModel = reportsPresenter.Content;


    }
}
