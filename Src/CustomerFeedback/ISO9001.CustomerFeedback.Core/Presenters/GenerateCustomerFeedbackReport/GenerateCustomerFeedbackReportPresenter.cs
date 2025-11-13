namespace ISO9001.CustomerFeedback.Core.Presenters.GenerateCustomerFeedbackReport
{
    internal class GenerateCustomerFeedbackReportPresenter(
        IReportsOutputPort outputPortReport,
        IReportsPresenter reportsPresenter) : IGenerateCustomerFeedbackOutputPort
    {
        public ReportViewModel ReportViewModel { get; private set; }
        public async Task Handle(IEnumerable<CustomerFeedbackResponse> customerFeedbackResponses, string companyId)
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

            #region CustomerFeedbacks

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
                Format = new Format((int)(257 * 0.25), 10)
                {
                    Position = new(0, 20),
                    Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                    FontDetails = new Font("Arial", new Shade(14, "Black"), new FontStyle(700)),
                    Background = "#DCDCDC",
                    TextAlignment = TextAlignment.Center,
                    Padding = new(3, 0, 0, 0),

                },
                DataColumn = new Item("CustomerFeedbackEntityIdTitle"),
            });

            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format((int)(257 * 0.25), 10)
                {
                    Position = new(0, 84.25m),
                    Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                    FontDetails = new Font("Arial", new Shade(14, "Black"), new FontStyle(700)),
                    Background = "#DCDCDC",
                    TextAlignment = TextAlignment.Center,
                    Padding = new(3, 0, 0, 0),

                },
                DataColumn = new Item("CustomerFeedbackCustomerIdTitle"),
            });

            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format((int)(257 * 0.25), 10)
                {
                    Position = new(0, 148.75m),
                    Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                    FontDetails = new Font("Arial", new Shade(14, "Black"), new FontStyle(700)),
                    Background = "#DCDCDC",
                    TextAlignment = TextAlignment.Center,
                    Padding = new(3, 0, 0, 0),

                },
                DataColumn = new Item("CustomerFeedbackRatingTitle"),
            });

            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format((int)(257 * 0.25), 10)
                {
                    Position = new(0, 212.25m),
                    Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                    FontDetails = new Font("Arial", new Shade(14, "Black"), new FontStyle(700)),
                    Background = "#DCDCDC",
                    TextAlignment = TextAlignment.Center,
                    Padding = new(3, 0, 0, 0),

                },
                DataColumn = new Item("CustomerFeedbackReportedAtTitle"),
            });

            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format((int)(257 * 0.25), 10)
                {
                    Position = new(0, 20),
                    Margin = new(0, 0, 0, 20),
                    Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                    FontDetails = new Font("Arial", new Shade(12)),
                    Background = "white",
                    TextAlignment = TextAlignment.Center,
                    Padding = new(4, 0, 0, 0),


                },
                DataColumn = new Item("CustomerFeedbackEntityIdColumn"),
            });

            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format((int)(257 * 0.25), 10)
                {
                    Position = new(0, 84.25m),
                    Margin = new(0, 0, 0, 20),
                    Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                    FontDetails = new Font("Arial", new Shade(12)),
                    Background = "white",
                    TextAlignment = TextAlignment.Center,
                    Padding = new(4, 0, 0, 0),


                },
                DataColumn = new Item("CustomerFeedbackCustomerIdColumn"),
            });

            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format((int)(257 * 0.25), 10)
                {
                    Position = new(0, 148.75m),
                    Margin = new(0, 0, 0, 20),
                    Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                    FontDetails = new Font("Arial", new Shade(12)),
                    Background = "white",
                    TextAlignment = TextAlignment.Center,
                    Padding = new(4, 0, 0, 0),
                },
                DataColumn = new Item("CustomerFeedbackRatingColumn"),
            });

            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format((int)(257 * 0.25), 10)
                {
                    Position = new(0, 212.25m),
                    Margin = new(0, 0, 0, 20),
                    Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                    FontDetails = new Font("Arial", new Shade(12)),
                    Background = "white",
                    TextAlignment = TextAlignment.Center,
                    Padding = new(4, 0, 0, 0),
                },
                DataColumn = new Item("CustomerFeedbackReportedAtColumn"),
            });
            #endregion



            int rowIndex = 1;

            var data = new List<ColumnData>
            {
                new ColumnData { Section = SectionType.Header, Column = new Item("CompanyTitle"), Value = $"Compañía: {CultureInfo.CurrentCulture.TextInfo.ToTitleCase(companyId)}" },
                new ColumnData { Section = SectionType.Header, Column = new Item("Title"), Value = "Customer Feedback Log" },
                new ColumnData { Section = SectionType.Header, Column = new Item("SubTitle"), Value = "ISO 9001:2015" },
            }
            ;

            if (customerFeedbackResponses == null || !customerFeedbackResponses.Any())
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
                    new ColumnData { Section = SectionType.Body, Column = new Item("CustomerFeedbackEntityIdTitle"), Value = "EntityId" , Row = rowIndex},
                    new ColumnData { Section = SectionType.Body, Column = new Item("CustomerFeedbackCustomerIdTitle"), Value = "CustomerId" , Row = rowIndex},
                    new ColumnData { Section = SectionType.Body, Column = new Item("CustomerFeedbackRatingTitle"), Value = "Rating" , Row = rowIndex},
                    new ColumnData { Section = SectionType.Body, Column = new Item("CustomerFeedbackReportedAtTitle"), Value = "ReportedAt" , Row = rowIndex},



                });
                rowIndex++;
                foreach (var customerFeedback in customerFeedbackResponses)
                {
                    data.Add(new ColumnData { Section = SectionType.Body, Column = new Item("CustomerFeedbackEntityIdColumn"), Value = customerFeedback.EntityId ?? "", Row = rowIndex });
                    data.Add(new ColumnData { Section = SectionType.Body, Column = new Item("CustomerFeedbackCustomerIdColumn"), Value = customerFeedback.CustomerId ?? "", Row = rowIndex });
                    data.Add(new ColumnData { Section = SectionType.Body, Column = new Item("CustomerFeedbackRatingColumn"), Value = customerFeedback.Rating, Row = rowIndex });
                    data.Add(new ColumnData { Section = SectionType.Body, Column = new Item("CustomerFeedbackReportedAtColumn"), Value = customerFeedback.ReportedAt.ToString("yyyy-MM-dd HH:mm:ss") ?? "", Row = rowIndex });
                    rowIndex++;
                }
            }
            await outputPortReport.Handle(reportSetUp, data);
            ReportViewModel = reportsPresenter.Content;
        }
    }
}
