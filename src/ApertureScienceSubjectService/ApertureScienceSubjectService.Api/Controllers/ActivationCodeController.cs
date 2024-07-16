using ApertureScienceSubjectService.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApertureScienceSubjectService.Api.Controllers
{
    [ApiController]
    [Route("api/activation-code")]
    public class ActivationCodeController : ControllerBase
    {
        private readonly IActivationCodeService _activationCodeService;

        public ActivationCodeController(IActivationCodeService activationCodeService)
        {
            ArgumentNullException.ThrowIfNull(activationCodeService, nameof(activationCodeService));

            _activationCodeService = activationCodeService;
        }

        [HttpGet]
        public string Get()
        {
            return _activationCodeService.GetActivationCode();
        }
    }
}
