namespace ISO9001.Core.Features.Interfaces.Internals.NonConformity;

public interface IRegisterNonConformityInputPort
{
    Task HandleAsync(NonConformityDto nonConformityDto);
}
