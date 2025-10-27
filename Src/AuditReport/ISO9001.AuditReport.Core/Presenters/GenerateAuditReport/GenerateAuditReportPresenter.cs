﻿namespace ISO9001.AuditReport.Core.Presenters.GenerateAuditReport
{
    internal class GenerateAuditReportPresenter(
        IReportAsBytes reportBytes): IGenerateAuditReportOutputPort
    {
        public byte[] PdfBytes { get; private set; }

        public async Task Handle(IEnumerable<NonConformityMaterResponse> nonConformityMaterResponses, 
            IEnumerable<IncidentReportResponse> incidentReportResponses, 
            IEnumerable<CustomerFeedbackResponse> customerFeedbackResponses, 
            string entityId, DateTime from, DateTime end)
        {
            Setup reportSetUp = new()
            {
                Page = new Format()
                {
                    Orientation = Orientation.Portrait,
                    Dimension = PageSize.A4,
                    Background = "white",
                    Padding = new(0, 0, 0, 0),
                    Margin = new(0, 0, 0, 0),
                    Position = new(0, 0, 0, 0)
                },
                Header = new Section(new Format(PageSize.A4.Width, 40)),
                Body = new Section(new Format(PageSize.A4.Width, 237)) { Row = new Row(new Dimension(PageSize.A4.Width, 9)) },
                Footer = new Section(new Format(PageSize.A4.Width, 20))
            };

            reportSetUp.Header.AddColumn(new ColumnSetup
            {
                Format = new Format(210, 20)
                {
                    Position = new(15, 0),
                    FontDetails = new Font("Arial", new Shade(25, "Black"), new FontStyle(700)),
                    TextAlignment = TextAlignment.Center
                },
                DataColumn = new Item("HeaderText")
            });
            reportSetUp.Header.AddColumn(new ColumnSetup
            {
                Format = new Format(210, 20)
                {
                    Position = new(35, 20),
                    FontDetails = new Font("Arial", new Shade(14, "Black")),
                    TextAlignment = TextAlignment.Left
                },
                DataColumn = new Item("HeaderSubText")
            });

            #region CustomerFeedbacks

            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format(210, 9)
                {
                    FontDetails = new Font("Arial", new Shade(20, "Black"), new FontStyle(700)),
                    TextAlignment = TextAlignment.Left,
                    Padding = new(0, 0, 0, 20)

                },
                DataColumn = new Item("FeedbackTitle"),
            });

            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format(210, 9)
                {
                    Margin = new(0, 0, 0, 20),

                    FontDetails = new Font("Arial", new Shade(18)),
                    Background = "white",
                    TextAlignment = TextAlignment.Left,
                    Padding = new(0, 0, 0, 20)

                },
                DataColumn = new Item("NoFeedbackRecords"),
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
                DataColumn = new Item("FeedbackDateTitle"),
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
                DataColumn = new Item("FeedbackUserIdTitle"),
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
                DataColumn = new Item("FeedbackRatingTitle"),
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
                DataColumn = new Item("FeedbackDateColumn"),
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
                DataColumn = new Item("FeedbackUserIdColumn"),
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
                DataColumn = new Item("FeedbackRatingColumn"),
            });

            #endregion

            #region NonConformities

            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format(210, 9)
                {
                    FontDetails = new Font("Arial", new Shade(20, "Black"), new FontStyle(700)),
                    TextAlignment = TextAlignment.Left,
                    Padding = new(0, 0, 0, 20)
                },
                DataColumn = new Item("NonConformityTitle"),
            });

            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format(210, 9)
                {
                    FontDetails = new Font("Arial", new Shade(18)),
                    Background = "white",
                    TextAlignment = TextAlignment.Left,
                    Padding = new(0, 0, 0, 20)

                },
                DataColumn = new Item("NoNonConformityRecords"),
            });


            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format((int)(190 * 0.20), 7)
                {
                    Position = new(0, 10),
                    Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                    FontDetails = new Font("Arial", new Shade(14, "White"), new FontStyle(700)),
                    Background = "gray",
                    TextAlignment = TextAlignment.Center,
                    Padding = new(1, 0, 2, 0)

                },
                DataColumn = new Item("NonConformityDateTitle"),
            });


            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format((int)(190 * 0.2), 7)
                {
                    Position = new(0, 48),
                    Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                    FontDetails = new Font("Arial", new Shade(14, "White"), new FontStyle(700)),
                    Background = "gray",
                    TextAlignment = TextAlignment.Center,
                    Padding = new(1, 0, 2, 0)

                },
                DataColumn = new Item("NonConformityIdTitle"),
            });


            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format((int)(190 * 0.2), 7)
                {
                    Position = new(0, 86),
                    Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                    FontDetails = new Font("Arial", new Shade(14, "White"), new FontStyle(700)),
                    Background = "gray",
                    TextAlignment = TextAlignment.Center,
                    Padding = new(1, 0, 2, 0)

                },
                DataColumn = new Item("NonConformityProcessTitle"),
            });


            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format((int)(190 * 0.25), 7)
                {
                    Position = new(0, 124),
                    Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                    FontDetails = new Font("Arial", new Shade(14, "White"), new FontStyle(700)),
                    Background = "gray",
                    TextAlignment = TextAlignment.Center,
                    Padding = new(1, 0, 2, 0)

                },
                DataColumn = new Item("NonConformityCauseTitle"),
            });


            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format((int)(190 * 0.15), 7)
                {
                    Position = new(0, 171.5m),
                    Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                    FontDetails = new Font("Arial", new Shade(14, "White"), new FontStyle(700)),
                    Background = "gray",
                    TextAlignment = TextAlignment.Center,
                    Padding = new(1, 0, 2, 0)

                },
                DataColumn = new Item("NonConformityStatusTitle"),
            });


            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format((int)(190 * 0.2), 7)
                {
                    Position = new(0, 10),
                    Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                    FontDetails = new Font("Arial", new Shade(12, "black")),
                    Background = "white",
                    TextAlignment = TextAlignment.Center,
                    Padding = new(2, 0, 0, 0)
                },
                DataColumn = new Item("NonConformityDateColumn"),
            });

            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format((int)(190 * 0.2), 7)
                {
                    Position = new(0, 48),
                    Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                    FontDetails = new Font("Arial", new Shade(10, "black")),
                    Background = "white",
                    TextAlignment = TextAlignment.Center,
                    Padding = new(1, 0, 1, 0)
                },
                DataColumn = new Item("NonConformityIdColumn"),
            });

            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format((int)(190 * 0.2), 7)
                {
                    Position = new(0, 86),
                    Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                    FontDetails = new Font("Arial", new Shade(12, "black")),
                    Background = "white",
                    TextAlignment = TextAlignment.Center,
                    Padding = new(2, 0, 0, 0)
                },
                DataColumn = new Item("NonConformityProcessColumn"),
            });

            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format((int)(190 * 0.25), 7)
                {
                    Position = new(0, 124),
                    Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                    FontDetails = new Font("Arial", new Shade(12, "black")),
                    Background = "white",
                    TextAlignment = TextAlignment.Center,
                    Padding = new(2, 0, 0, 0)
                },
                DataColumn = new Item("NonConformityCauseColumn"),
            });

            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format((int)(190 * 0.15), 7)
                {
                    Position = new(0, 171.5m),
                    Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                    FontDetails = new Font("Arial", new Shade(12, "black")),
                    Background = "white",
                    TextAlignment = TextAlignment.Center,
                    Padding = new(2, 0, 0, 0)
                },
                DataColumn = new Item("NonConformityStatusColumn"),
            });

            #endregion


            #region IncidentReports


            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format(210, 9)
                {
                    FontDetails = new Font("Arial", new Shade(20, "Black"), new FontStyle(700)),
                    TextAlignment = TextAlignment.Left,
                    Padding = new(0, 0, 0, 20)
                },
                DataColumn = new Item("IncidentReportTitle"),
            });

            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format(210, 9)
                {
                    FontDetails = new Font("Arial", new Shade(18)),
                    Background = "white",
                    TextAlignment = TextAlignment.Left,
                    Padding = new(0, 0, 0, 20)

                },
                DataColumn = new Item("NoIncidentReportsRecords"),
            });

            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format((int)(190 * 0.2), 7)
                {
                    Position = new(0, 10),
                    Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                    FontDetails = new Font("Arial", new Shade(14, "White"), new FontStyle(700)),
                    Background = "gray",
                    TextAlignment = TextAlignment.Center,
                    Padding = new(1, 0, 2, 0),

                },
                DataColumn = new Item("IncidentReportDateTitle"),
            });


            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format((int)(190 * 0.5), 7)
                {
                    Position = new(0, 48),
                    Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                    FontDetails = new Font("Arial", new Shade(14, "White"), new FontStyle(700)),
                    Background = "gray",
                    TextAlignment = TextAlignment.Center,
                    Padding = new(1, 0, 2, 0),

                },
                DataColumn = new Item("IncidentReportDescriptionTitle"),
            });

            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format((int)(190 * 0.15), 7)
                {
                    Position = new(0, 143),
                    Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                    FontDetails = new Font("Arial", new Shade(14, "White"), new FontStyle(700)),
                    Background = "gray",
                    TextAlignment = TextAlignment.Center,
                    Padding = new(1, 0, 2, 0),

                },
                DataColumn = new Item("IncidentReportProcessTitle"),
            });

            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format((int)(190 * 0.15), 7)
                {
                    Position = new(0, 171.5m),
                    Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                    FontDetails = new Font("Arial", new Shade(14, "White"), new FontStyle(700)),
                    Background = "gray",
                    TextAlignment = TextAlignment.Center,
                    Padding = new(1, 0, 2, 0),

                },
                DataColumn = new Item("IncidentReportSeverityTitle"),
            });



            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format((int)(190 * 0.2), 7)
                {
                    Position = new(0, 10),
                    Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                    FontDetails = new Font("Arial", new Shade(12)),
                    Background = "white",
                    TextAlignment = TextAlignment.Center,
                    Padding = new(2, 0, 0, 0)
                },
                DataColumn = new Item("IncidentReportDateColumn"),
            });

            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format((int)(190 * 0.5), 7)
                {
                    Position = new(0, 48),
                    Margin = new(0, 0, 0, 20),
                    Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                    FontDetails = new Font("Arial", new Shade(12)),
                    Background = "white",
                    TextAlignment = TextAlignment.Center,
                    Padding = new(2, 0, 0, 0)
                },
                DataColumn = new Item("IncidentReportDescriptionColumn"),
            });


            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format((int)(190 * 0.15), 7)
                {
                    Position = new(0, 143),
                    Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                    FontDetails = new Font("Arial", new Shade(12)),
                    Background = "white",
                    TextAlignment = TextAlignment.Center,
                    Padding = new(2, 0, 0, 0)
                },
                DataColumn = new Item("IncidentReportProcessColumn"),
            });

            reportSetUp.Body.AddColumn(new ColumnSetup
            {
                Format = new Format((int)(190 * 0.15), 7)
                {
                    Position = new(0, 171.5m),
                    Borders = new Border(new Shade(1, "Black"), BorderStyle.solid),
                    FontDetails = new Font("Arial", new Shade(12)),
                    Background = "white",
                    TextAlignment = TextAlignment.Center,
                    Padding = new(2, 0, 0, 0)
                },
                DataColumn = new Item("IncidentReportProcessColumn"),
            });
            #endregion

            var LatestNonConformity = nonConformityMaterResponses
                .OrderByDescending(nc => nc.ReportedAt) 
                .FirstOrDefault();

            string LatestStatus = LatestNonConformity != null
                ? LatestNonConformity.Status
                : "Sin registros";




            int rowIndex = 1;

            var data = new List<ColumnData>
            {
                new ColumnData { Section = SectionType.Header, Column = new Item("HeaderText"), Value = $"Audit Report – Order: {entityId}" },
                new ColumnData { Section = SectionType.Header, Column = new Item("HeaderSubText"), Value = $"Fecha de creación: {DateTime.UtcNow:yyyy-MM-dd}\nEstatus actual: {LatestStatus}" },
            };

            data.Add(new ColumnData { Section = SectionType.Body, Column = new Item("FeedbackTitle"), Value = "1. Feedback de Cliente (Feedbacks)", Row = rowIndex++ });
            if (customerFeedbackResponses == null || !customerFeedbackResponses.Any())
            {
                data.Add(new ColumnData
                {
                    Section = SectionType.Body,
                    Column = new Item("NoFeedbackRecords"),
                    Value = "No hay registros en estas fechas",
                    Row = rowIndex++
                });
            }
            else
            {
                data.AddRange(new[]
                {
                    new ColumnData { Section = SectionType.Body, Column = new Item("FeedbackDateTitle"), Value = "Fecha" , Row = rowIndex},
                    new ColumnData { Section = SectionType.Body, Column = new Item("FeedbackUserIdTitle"), Value = "UserId" , Row = rowIndex},
                    new ColumnData { Section = SectionType.Body, Column = new Item("FeedbackRatingTitle"), Value = "Rating" , Row = rowIndex},
                });
                rowIndex++;
                foreach (var feedback in customerFeedbackResponses)
                {
                    data.Add(new ColumnData { Section = SectionType.Body, Column = new Item("FeedbackDateColumn"), Value = feedback.ReportedAt.ToString("yyyy-MM-dd") ?? "", Row = rowIndex });
                    data.Add(new ColumnData { Section = SectionType.Body, Column = new Item("FeedbackUserIdColumn"), Value = feedback.CustomerId ?? "", Row = rowIndex });
                    data.Add(new ColumnData { Section = SectionType.Body, Column = new Item("FeedbackRatingColumn"), Value = feedback.Rating, Row = rowIndex });
                    rowIndex++;
                }
            }

            data.Add(new ColumnData { Section = SectionType.Body, Column = new Item("NonConformityTitle"), Value = "2. No Conformidades (NonConformities)", Row = rowIndex++ });
            if (nonConformityMaterResponses == null || !nonConformityMaterResponses.Any())
            {
                data.Add(new ColumnData
                {
                    Section = SectionType.Body,
                    Column = new Item("NoNonConformityRecords"),
                    Value = "No hay registros en estas fechas",
                    Row = rowIndex++
                });
            }
            else
            {
                data.AddRange(new[]
{
                    new ColumnData { Section = SectionType.Body, Column = new Item("NonConformityDateTitle"), Value = "Fecha" , Row = rowIndex},
                    new ColumnData { Section = SectionType.Body, Column = new Item("NonConformityIdTitle"), Value = "Id" , Row = rowIndex},
                    new ColumnData { Section = SectionType.Body, Column = new Item("NonConformityProcessTitle"), Value = "Process" , Row = rowIndex},
                    new ColumnData { Section = SectionType.Body, Column = new Item("NonConformityCauseTitle"), Value = "Cause" , Row = rowIndex},
                    new ColumnData { Section = SectionType.Body, Column = new Item("NonConformityStatusTitle"), Value = "Status" , Row = rowIndex},
                });
                rowIndex++;
                foreach (var nonConformity in nonConformityMaterResponses)
                {
                    data.Add(new ColumnData { Section = SectionType.Body, Column = new Item("NonConformityDateColumn"), Value = nonConformity.ReportedAt.ToString("yyyy-MM-dd HH:mm:ss"), Row = rowIndex });
                    data.Add(new ColumnData { Section = SectionType.Body, Column = new Item("NonConformityIdColumn"), Value = nonConformity.Id.ToString(), Row = rowIndex });
                    data.Add(new ColumnData { Section = SectionType.Body, Column = new Item("NonConformityProcessColumn"), Value = nonConformity.AffectedProcess, Row = rowIndex });
                    data.Add(new ColumnData { Section = SectionType.Body, Column = new Item("NonConformityCauseColumn"), Value = nonConformity.Cause, Row = rowIndex });
                    data.Add(new ColumnData { Section = SectionType.Body, Column = new Item("NonConformityStatusColumn"), Value = nonConformity.Status, Row = rowIndex });
                    rowIndex++;
                }
            }


            data.Add(new ColumnData { Section = SectionType.Body, Column = new Item("IncidentReportTitle"), Value = "3. Reportes de Incidencia (IncidentReports)", Row = rowIndex++ });
            if (incidentReportResponses == null || !incidentReportResponses.Any())
            {
                data.Add(new ColumnData
                {
                    Section = SectionType.Body,
                    Column = new Item("NoIncidentReportsRecords"),
                    Value = "No hay registros en estas fechas",
                    Row = rowIndex++
                });
            }
            else
            {
                data.AddRange(new[]
                {
                    new ColumnData { Section = SectionType.Body, Column = new Item("IncidentReportDateTitle"), Value = "Fecha" , Row = rowIndex},
                    new ColumnData { Section = SectionType.Body, Column = new Item("IncidentReportDescriptionTitle"), Value = "Description" , Row = rowIndex},
                    new ColumnData { Section = SectionType.Body, Column = new Item("IncidentReportProcessTitle"), Value = "Description" , Row = rowIndex},
                    new ColumnData { Section = SectionType.Body, Column = new Item("IncidentReportSeverityTitle"), Value = "Description" , Row = rowIndex},

                });
                rowIndex++;
                foreach (var incidentReport in incidentReportResponses)
                {
                    data.Add(new ColumnData { Section = SectionType.Body, Column = new Item("IncidentReportDateColumn"), Value = incidentReport.ReportedAt.ToString("yyyy-MM-dd") ?? "", Row = rowIndex });
                    data.Add(new ColumnData { Section = SectionType.Body, Column = new Item("IncidentReportDescriptionColumn"), Value = incidentReport.Description, Row = rowIndex });
                    data.Add(new ColumnData { Section = SectionType.Body, Column = new Item("IncidentReportProcessColumn"), Value = incidentReport.AffectedProcess, Row = rowIndex });
                    data.Add(new ColumnData { Section = SectionType.Body, Column = new Item("IncidentReportSeverityColumn"), Value = incidentReport.Severity, Row = rowIndex });

                    rowIndex++;
                }
            }

            ReportViewModel reportModel = new ReportViewModel(reportSetUp, data);
            byte[] pdfBytes = await reportBytes.GenerateReport(reportModel);
            PdfBytes = pdfBytes;

        }
    }
}
