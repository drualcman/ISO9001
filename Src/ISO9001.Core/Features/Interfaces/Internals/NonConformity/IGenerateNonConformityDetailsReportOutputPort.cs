using ISO9001.Core.Responses;

namespace ISO9001.Core.Features.Interfaces.Internals.NonConformity;

internal interface IGenerateNonConformityDetailsReportOutputPort
{
    public ReportViewModel ReportViewModel { get; }
    Task Handle(IEnumerable<NonConformityDetailResponse> nonConformityDetailsResponses, string companyId);
}
