namespace ISO9001.Core.Features.NonConformity.Handlers;

internal class RegisterNonConformityDetailHandler(
    ICommandNonConformityDetailRepository commandDetailRepository,
    ICommandNonConformityRepository commandMasterRepository,
    IQueryableNonConformityRepository queryRepository) : IRegisterNonConformityDetailInputPort
{
    public async Task HandleAsync(NonConformityCreateDetailDto nonConformityDetail)
    {
        bool NonConformityExists = await queryRepository.NonConformityExistsByGuidAsync(nonConformityDetail.EntityId);
        if (!NonConformityExists)
        {
            throw new InvalidOperationException("NonConformity doesn't exist");
        }
        else
        {
            await commandDetailRepository.RegisterNonConformityDetailAsync(nonConformityDetail);
            await commandMasterRepository.UpdateStatusNonConformityMasterAsync(nonConformityDetail.EntityId, nonConformityDetail.Status);
            await commandDetailRepository.SaveChangesAsync();
        }

    }
}
