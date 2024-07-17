using System.ComponentModel.DataAnnotations;

namespace ApertureScienceSubjectService.Api.Models
{
    public class ProfileRequest
    {
        [Required]
        public required string ActivationCode { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email formatting")]
        public string Email { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
        public string Password { get; set; }

        [Required]
        public string FullName { get; set; }

        internal static ProfileEntity ToEntity(ProfileRequest profileRequest)
        {
            ArgumentNullException.ThrowIfNull(profileRequest, nameof(profileRequest));

            return new ProfileEntity(profileRequest.Email, profileRequest.Password, profileRequest.FullName);
        }
    }
}
