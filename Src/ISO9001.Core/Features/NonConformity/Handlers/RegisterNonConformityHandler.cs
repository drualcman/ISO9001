namespace ISO9001.Core.Features.NonConformity.Handlers;

internal class RegisterNonConformityHandler
    (ICommandNonConformityRepository repository) : IRegisterNonConformity
{
    public async Task HandleAsync(NonConformityDto nonConformityDto)
    {
        await repository.RegisterNonConformityAsync(nonConformityDto);
        await repository.SaveChangesAsync();
    }
}
