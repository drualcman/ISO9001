namespace ISO9001.NonConformity.Core.Handlers.RegisterNonConformity
{
    internal class RegisterNonConformityHandler
        (ICommandNonConformityRepository repository) : IRegisterNonConformityInputPort
    {
        public async Task HandleAsync(NonConformityDto nonConformityDto)
        {
            await repository.RegisterNonConformityAsync(nonConformityDto);
            await repository.SaveChangesAsync();
        }
    }
}
