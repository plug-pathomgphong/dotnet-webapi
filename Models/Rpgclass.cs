using System.Text.Json.Serialization;

namespace dotnet_webapi.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))] // Convert Number to string name for swagger
    public enum Rpgclass
    {
        Knight = 1,
        Mage = 2,
        Cleric = 3
    }
}