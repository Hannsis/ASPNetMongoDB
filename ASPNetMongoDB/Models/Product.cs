namespace ASPNetMongoDB.Models;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Product
{
    /// <summary>Produktens Id på MongoDB.</summary>
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = "";

    /// <summary>Produktens namn.</summary>
    public string Name { get; set; } = "";

    /// <summary> Antal kvar.</summary>
    public int Antal { get; set; } = 0;

    /// <summary>Produktens pris.</summary>
    public int Pris { get; set; } = 0;
}