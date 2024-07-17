namespace ApertureScienceSubjectService.Api.Cosmos
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CosmosEntityAttribute : Attribute
    {
        public string CollectionName { get; }
        public int SchemaVersion { get; }

        public CosmosEntityAttribute(string collectionName, int version)
        {
            CollectionName = collectionName;
            SchemaVersion = version;
        }
    }
}
