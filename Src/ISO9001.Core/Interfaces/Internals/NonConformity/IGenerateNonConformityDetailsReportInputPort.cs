namespace ISO9001.Core.Interfaces.Internals.NonConformity;

internal interface IGenerateNonConformityDetailsReportInputPort
{
    ValueTask GenerateNonConformityDetailsReportAsync(string companyId, string nonConformityId, DateTime? from, DateTime? end);
}
