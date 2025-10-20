namespace ISO9001.NonConformity.Core.Internals.RegisterNonConformityDetail
{
    public interface IRegisterNonConformityDetailInputPort
    {
        Task HandleAsync(NonConformityCreateDetailDto nonConformityDetail);

    }
}
