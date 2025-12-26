namespace ISO9001.Core.Interfaces.NonConformitys;

public interface IRegisterNonConformityDetailInputPort
{
    Task HandleAsync(NonConformityCreateDetailDto nonConformityDetail);

}
