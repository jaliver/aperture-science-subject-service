using ApertureScienceSubjectService.Api.Models;

namespace ApertureScienceSubjectService.Api.Services
{
    public class ProfileService : IProfileService
    {
        private static readonly ICollection<ProfileEntity> Profiles = new List<ProfileEntity>();

        public ProfileResponse Create(ProfileRequest profileRequest)
        {
            var profileEntity = ProfileRequest.ToEntity(profileRequest);
            Profiles.Add(profileEntity);
            return ProfileResponse.FromEntity(profileEntity);
        }
    }
}
