namespace ApertureScienceSubjectService.Api.Services
{
    public interface IActivationCodeService
    {
        string GetActivationCode();
        bool IsActivationCodeValid(string activationCode);
    }
}
