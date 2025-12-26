namespace ISO9001.Core.Interfaces.Internals.NonConformity;

internal interface IGenerateNonConformityMasterReportInputPort
{
    ValueTask GenerateNonConformityMasterReportAsync(string companyId, string entityId, DateTime? from, DateTime? end);
}
