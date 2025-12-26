namespace ISO9001.Core.Interfaces.NonConformitys;

public interface IRegisterNonConformityInputPort
{
    Task HandleAsync(NonConformityDto nonConformityDto);
}
