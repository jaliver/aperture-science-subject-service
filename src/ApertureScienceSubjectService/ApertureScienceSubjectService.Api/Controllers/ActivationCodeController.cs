using Microsoft.AspNetCore.Mvc;

namespace ApertureScienceSubjectService.Api.Controllers
{
    [ApiController]
    [Route("api/activation-code")]
    public class ActivationCodeController : ControllerBase
    {
        public ActivationCodeController()
        {
        }

        [HttpGet]
        public string Get()
        {
            throw new NotImplementedException();
        }
    }
}
