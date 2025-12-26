namespace ISO9001.Core.Features.Interfaces.Internals.NonConformity;

internal interface IGenerateNonConformityDetailsReportInputPort
{
    ValueTask GenerateNonConformityDetailsReportAsync(string companyId, string nonConformityId, DateTime? from, DateTime? end);
}
