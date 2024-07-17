using ApertureScienceSubjectService.Api.Cosmos;

namespace ApertureScienceSubjectService.Api.Models
{
    [CosmosEntity("Profiles", 1)]
    public class ProfileEntity : BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }

        public ProfileEntity(string email, string password, string fullName)
        {
            Email = email;
            Password = password;
            FullName = fullName;
        }
    }
}
