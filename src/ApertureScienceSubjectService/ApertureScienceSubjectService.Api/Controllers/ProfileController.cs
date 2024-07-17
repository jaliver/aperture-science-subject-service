using ApertureScienceSubjectService.Api.Models;
using ApertureScienceSubjectService.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApertureScienceSubjectService.Api.Controllers
{
    [ApiController]
    [Route("api/profile")]
    public class ProfileController : ControllerBase
    {
        private readonly IActivationCodeService _activationCodeService;
        private readonly IProfileService _profileService;

        public ProfileController(IActivationCodeService activationCodeService, IProfileService profileService)
        {
            ArgumentNullException.ThrowIfNull(activationCodeService, nameof(activationCodeService));
            ArgumentNullException.ThrowIfNull(profileService, nameof(profileService));

            _activationCodeService = activationCodeService;
            _profileService = profileService;
        }

        [HttpPost]
        public async Task<ActionResult<ProfileResponse>> Create([FromBody] ProfileRequest profileRequest)
        {
            if (!_activationCodeService.IsActivationCodeValid(profileRequest.ActivationCode))
            {
                return BadRequest(new { field = nameof(profileRequest.ActivationCode), message = "Invalid activation code" });
            }

            var profileResponse = await _profileService.Create(profileRequest);

            return profileResponse;
        }
    }
}
