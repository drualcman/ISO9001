namespace ISO9001.Core.Features.Interfaces.Internals.NonConformity;

public interface IRegisterNonConformityDetailInputPort
{
    Task HandleAsync(NonConformityCreateDetailDto nonConformityDetail);

}
