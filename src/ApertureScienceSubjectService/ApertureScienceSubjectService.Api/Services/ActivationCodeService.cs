using ApertureScienceSubjectService.Api.Cosmos;
using ApertureScienceSubjectService.Api.Models;

namespace ApertureScienceSubjectService.Api.Services
{
    public class ActivationCodeService : IActivationCodeService
    {
        private readonly ICosmosRepository<ActivationCodeEntity> _activationCodeCosmosRepository;
        private static readonly Random Rand = new();

        private const int MinimumNumberCode = 100_000;
        private const int MaximumNumberCode = 999_999;

        public ActivationCodeService(ICosmosRepository<ActivationCodeEntity> activationCodeCosmosRepository)
        {
            ArgumentNullException.ThrowIfNull(activationCodeCosmosRepository, nameof(activationCodeCosmosRepository));

            _activationCodeCosmosRepository = activationCodeCosmosRepository;
        }

        public async Task<ActivationCodeResponse> GetActivationCode()
        {
            var activationCode = await GenerateCode();

            var activationCodeEntity = new ActivationCodeEntity(activationCode);

            var response = await _activationCodeCosmosRepository.AddAsync(activationCodeEntity);

            return ActivationCodeResponse.FromEntity(response);
        }

        public async Task<bool> IsActivationCodeValid(string activationCode)
        {
            var response = await _activationCodeCosmosRepository.GetAllAsync(x => x.ActivationCode.Equals(activationCode, StringComparison.InvariantCulture));
            return response.Count > 0;
        }

        private async Task<string> GenerateCode()
        {
            // based on the approximate number of new test subjects at launch times 2
            const int maxNumberOfIterations = 10_000;

            for (var i = 0; i <= maxNumberOfIterations; i++)
            {
                var activationCode = Rand.Next(MinimumNumberCode, MaximumNumberCode).ToString();

                if (await IsActivationCodeValid(activationCode))
                {
                    continue;
                }
                
                return activationCode;
            }

            throw new Exception($"We have unfortunately run out of activation codes. Please try again in an hour.");
        }
    }
}
