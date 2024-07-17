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

        private string _id;

        protected BaseEntity()
        {
            if (string.IsNullOrEmpty(_id))
            {
                _id = GenerateId();
            }
        }

        private static string GenerateId()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
