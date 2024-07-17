namespace ApertureScienceSubjectService.Api.Models
{
    public class ProfileEntity
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }

        public ProfileEntity(string email, string password, string fullName)
        {
            Id = Guid.NewGuid().ToString();
            Email = email;
            Password = password;
            FullName = fullName;
        }
    }
}
