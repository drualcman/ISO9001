namespace ISO9001.Core.Features.Interfaces.Internals.NonConformity;

internal interface IGenerateNonConformityMasterReportInputPort
{
    ValueTask GenerateNonConformityMasterReportAsync(string companyId, string entityId, DateTime? from, DateTime? end);
}
