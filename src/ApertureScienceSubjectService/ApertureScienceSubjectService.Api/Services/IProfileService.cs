using ApertureScienceSubjectService.Api.Models;

namespace ApertureScienceSubjectService.Api.Services
{
    public interface IProfileService
    {
        ProfileResponse Create(ProfileRequest profile);
    }
}
