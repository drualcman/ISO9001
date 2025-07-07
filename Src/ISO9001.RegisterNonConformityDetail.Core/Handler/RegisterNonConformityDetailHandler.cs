using ISO9001.Entities.Dtos;
using ISO9001.RegisterNonConformityDetail.BusinessObjects.Interfaces;

namespace ISO9001.RegisterNonConformityDetail.Core.Handler
{
    internal class RegisterNonConformityDetailHandler
        (IRegisterNonConformityDetailRepository repository) : IRegisterNonConformityDetailInputPort
    {
        public async Task HandleAsync(NonConformityCreateDetailDto nonConformityDetail)
        {
            bool NonConformityExists = await repository.NonConformityExistsByGuidAsync(nonConformityDetail.EntityId);
            if (!NonConformityExists)
            {
                throw new InvalidOperationException("NonConformity doesn't exist");
            }
            else
            {
                await repository.RegisterNonConformityDetailAsync(nonConformityDetail);
                await repository.UpdateStatusNonConformityMasterAsync(nonConformityDetail.EntityId, nonConformityDetail.Status);
                await repository.SaveChangesAsync();
            }

        }
    }
}
