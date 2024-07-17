namespace ApertureScienceSubjectService.Api.Models
{
    public class ActivationCodeResponse
    {
        public string ActivationCode { get; set; }
        public DateTime UtcExpiresAt { get; set; }

        public static ActivationCodeResponse FromEntity(ActivationCodeEntity activationCodeEntity)
        {
            ArgumentNullException.ThrowIfNull(activationCodeEntity, nameof(activationCodeEntity));

            return new ActivationCodeResponse
            {
                ActivationCode = activationCodeEntity.ActivationCode,
                UtcExpiresAt = CalculateExpiration(activationCodeEntity)
            };
        }

        private static DateTime CalculateExpiration(ActivationCodeEntity activationCodeEntity)
        {
            var creation = DateTimeOffset.FromUnixTimeSeconds(activationCodeEntity.LastModified).DateTime;
            return creation.AddSeconds(activationCodeEntity.TimeToLiveInSeconds);
        }
    }
}
