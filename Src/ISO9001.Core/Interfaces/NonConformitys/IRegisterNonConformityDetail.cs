namespace ISO9001.Core.Interfaces.NonConformitys;

public interface IRegisterNonConformityDetail
{
    Task HandleAsync(NonConformityCreateDetailDto nonConformityDetail);

}
