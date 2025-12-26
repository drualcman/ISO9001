namespace ISO9001.Core.Interfaces.NonConformitys;

public interface IRegisterNonConformity
{
    Task HandleAsync(NonConformityDto nonConformityDto);
}
