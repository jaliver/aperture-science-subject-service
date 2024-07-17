using ApertureScienceSubjectService.Api.Models;

namespace ApertureScienceSubjectService.Api.Services
{
    public interface IActivationCodeService
    {
        Task<ActivationCodeResponse> GetActivationCode();
        Task<bool> IsActivationCodeValid(string activationCode);
    }
}
