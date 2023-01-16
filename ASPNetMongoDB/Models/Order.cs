namespace ASPNetMongoDB.Models;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Order
{
    /// <summary>KundId på MongoDB.</summary>
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string KundId { get; set; } = "";

    /// <summary> Datum köpt.</summary>
    public DateTime Datum { get; set; }

    /// <summary>Varor pris.</summary>
    public List<Product> Varor { get; set; }
}