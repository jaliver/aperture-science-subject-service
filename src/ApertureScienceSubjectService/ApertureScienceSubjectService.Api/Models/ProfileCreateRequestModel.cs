using System.ComponentModel.DataAnnotations;

namespace ApertureScienceSubjectService.Api.Models
{
    public class ProfileCreateRequestModel
    {
        [Required]
        public string ActivationCode { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email formatting")]
        public string Email { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
        public string Password { get; set; }

        [Required]
        public string FullName { get; set; }
    }
}
