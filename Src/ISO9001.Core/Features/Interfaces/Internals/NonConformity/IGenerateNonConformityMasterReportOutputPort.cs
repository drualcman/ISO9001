using ISO9001.Core.Responses;

namespace ISO9001.Core.Features.Interfaces.Internals.NonConformity;

internal interface IGenerateNonConformityMasterReportOutputPort
{
    public ReportViewModel ReportViewModel { get; }
    Task Handle(IEnumerable<NonConformityMaterResponse> nonConformityResponses, string companyId);
}
