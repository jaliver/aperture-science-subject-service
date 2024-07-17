using ApertureScienceSubjectService.Api.Cosmos;
using ApertureScienceSubjectService.Api.Models;

namespace ApertureScienceSubjectService.Api.Services
{
    public class ProfileService : IProfileService
    {
        private readonly ICosmosRepository<ProfileEntity> _profileRepository;

        public ProfileService(ICosmosRepository<ProfileEntity> profileRepository)
        {
            ArgumentNullException.ThrowIfNull(profileRepository, nameof(profileRepository));

            _profileRepository = profileRepository;
        }

        public async Task<ProfileResponse> Create(ProfileRequest profileRequest)
        {
            var profileEntity = ProfileRequest.ToEntity(profileRequest);

            var response = await _profileRepository.AddAsync(profileEntity);
            
            return ProfileResponse.FromEntity(profileEntity);
        }
    }
}
