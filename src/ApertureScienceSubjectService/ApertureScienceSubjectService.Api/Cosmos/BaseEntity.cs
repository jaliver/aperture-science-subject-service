using Newtonsoft.Json;

namespace ApertureScienceSubjectService.Api.Cosmos
{
    public abstract class BaseEntity
    {
        [JsonProperty(PropertyName = "id")]
        public string Id
        {
            get => _id;
            init => _id = string.IsNullOrEmpty(value) ? GenerateId() : value;
        }

        [JsonProperty(PropertyName = "_ts")]
        public int LastModified { get; set; }

        [JsonProperty(PropertyName = "ttl")]
        public int TimeToLiveInSeconds
        {
            get => _timeToLiveInSeconds;
            init => _timeToLiveInSeconds = value is 0 ? GetDefaultTTL() : value;
        }

        private string _id;
        private int _timeToLiveInSeconds;

        protected BaseEntity()
        {
            if (string.IsNullOrEmpty(_id))
            {
                _id = GenerateId();
            }

            if (_timeToLiveInSeconds is 0)
            {
                _timeToLiveInSeconds = GetDefaultTTL();
            }
        }

        private static string GenerateId()
        {
            return Guid.NewGuid().ToString();
        }

        private static int GetDefaultTTL()
        {
            // 180 days
            return 180 * 60 * 60 * 24;
        }
    }
}
