using ISO9001.Entities.Dtos;

namespace ISO9001.RegisterNonConformityDetail.BusinessObjects.Interfaces
{
    public interface IRegisterNonConformityDetailInputPort
    {
        Task HandleAsync(NonConformityCreateDetailDto nonConformityDetail);
    }
}
