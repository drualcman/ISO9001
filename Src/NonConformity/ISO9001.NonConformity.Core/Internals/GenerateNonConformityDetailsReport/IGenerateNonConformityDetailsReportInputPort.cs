namespace ISO9001.NonConformity.Core.Internals.GenerateNonConformityDetailsReport
{
    internal interface IGenerateNonConformityDetailsReportInputPort
    {
        ValueTask GenerateNonConformityDetailsReportAsync(string companyId, string nonConformityId, DateTime? from, DateTime? end);
    }
}
