using ApertureScienceSubjectService.Api.Models;

namespace ApertureScienceSubjectService.Api.Services
{
    public interface IProfileService
    {
        Task<ProfileResponse> Create(ProfileRequest profile);
    }
}
