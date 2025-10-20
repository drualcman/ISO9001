namespace ISO9001.NonConformity.Core.Internals.RegisterNonConformity
{
    public interface IRegisterNonConformityInputPort
    {
        Task HandleAsync(NonConformityDto nonConformityDto);
    }
}
