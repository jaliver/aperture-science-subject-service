using ApertureScienceSubjectService.Api.Cosmos;

namespace ApertureScienceSubjectService.Api.Extensions
{
    public static class TypeExtensions
    {
        public static CosmosEntityAttribute GetCosmosEntityAttribute(this Type type)
        {
            return (CosmosEntityAttribute)type.GetCustomAttributes(typeof(CosmosEntityAttribute), false).First();
        }
    }
}
