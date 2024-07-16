using ApertureScienceSubjectService.Api.Models;
using ApertureScienceSubjectService.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace ApertureScienceSubjectService.Api.Controllers
{
    [ApiController]
    [Route("api/profile")]
    public class ProfileController : ControllerBase
    {
        private readonly IActivationCodeService _activationCodeService;

        public ProfileController(IActivationCodeService activationCodeService)
        {
            ArgumentNullException.ThrowIfNull(activationCodeService, nameof(activationCodeService));

            _activationCodeService = activationCodeService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] ProfileCreateRequestModel profile)
        {
            if (!_activationCodeService.IsActivationCodeValid(profile.ActivationCode))
            {
                return BadRequest(new { field = nameof(profile.ActivationCode), message = "Invalid activation code" });
            }

            throw new NotImplementedException();
        }
    }
}
