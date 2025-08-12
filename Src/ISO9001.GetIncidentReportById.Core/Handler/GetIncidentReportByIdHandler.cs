using ISO9001.Entities.Responses;
using ISO9001.GetIncidentReportById.BusinessObjects.Interfaces;

namespace ISO9001.GetIncidentReportById.Core.Handler
{
    internal class GetIncidentReportByIdHandler(
        IGetIncidentReportByIdRepository repository): IGetIncidentReportByIdInputPort
    {
        public async Task<IncidentReportResponse> HandleAsync(string companyId, int id)
        {
            var IncidentReportExists = await repository.IncidentReportExists(companyId, id);

            if (!IncidentReportExists)
            {
                throw new KeyNotFoundException($"IncidentReport with Id '{id}' doesn't exist in the company: '{companyId}'");
            }
            else
            {
                return await repository.GetIncidentReportByIdAsync(companyId, id);
            }

        }
    }
}
