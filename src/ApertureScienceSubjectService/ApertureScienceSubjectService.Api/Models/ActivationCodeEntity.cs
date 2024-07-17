using ApertureScienceSubjectService.Api.Cosmos;

namespace ApertureScienceSubjectService.Api.Models
{
    [CosmosEntity("ActivationCodes", 1)]
    public class ActivationCodeEntity : BaseEntity
    {
        public string ActivationCode { get; set; }

        public ActivationCodeEntity(string activationCode)
        {
            ActivationCode = activationCode;
            // 60 minutes
            TimeToLiveInSeconds = 60 * 60;
        }
    }
}
