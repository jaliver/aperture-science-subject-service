namespace ApertureScienceSubjectService.Api.Services
{
    public class ActivationCodeService : IActivationCodeService
    {
        private static readonly IDictionary<string, DateTime> ActivationCodes = new Dictionary<string, DateTime>();
        private static readonly Random Rand = new();

        private const int MinimumNumberCode = 100_000;
        private const int MaximumNumberCode = 999_999;

        public string GetActivationCode()
        {
            return GenerateCode();
        }

        private static string GenerateCode()
        {
            // based on the approximate new test subjects at launch + 10%
            const int maxNumberOfIterations = 5500;

            for (var i = 0; i <= maxNumberOfIterations; i++)
            {
                var code = Rand.Next(MinimumNumberCode, MaximumNumberCode).ToString();

                if (!IsActivationCodeValid(code))
                {
                    continue;
                }

                ActivationCodes[code] = DateTime.Now;
                return code;
            }

            return BruteForceNewActivationCode();
        }

        private static bool IsActivationCodeValid(string activationCode)
        {
            if (!ActivationCodes.TryGetValue(activationCode, out var previousCodeCreationTime))
            {
                return true;
            }

            var timeSpan = DateTime.Now - previousCodeCreationTime;

            return timeSpan.TotalMinutes <= 60;
        }

        private static string BruteForceNewActivationCode()
        {
            for (var i = MinimumNumberCode; i <= MaximumNumberCode; i++)
            {
                var code = i.ToString();

                if (IsActivationCodeValid(code))
                {
                    ActivationCodes[code] = DateTime.Now;
                    return code;
                }
            }

            throw new Exception($"The service does not support more than {MaximumNumberCode - MinimumNumberCode} valid activation codes");
        }
    }
}
