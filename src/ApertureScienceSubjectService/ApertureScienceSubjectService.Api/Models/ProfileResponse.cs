namespace ApertureScienceSubjectService.Api.Models
{
    public class ProfileResponse
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }

        internal static ProfileResponse FromEntity(ProfileEntity profileEntity)
        {
            ArgumentNullException.ThrowIfNull(profileEntity);

            return new ProfileResponse
            {
                Id = profileEntity.Id,
                Email = profileEntity.Email,
                FullName = profileEntity.FullName
            };
        }
    }
}
