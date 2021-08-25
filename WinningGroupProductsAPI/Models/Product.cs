using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace WinningGroupProductsAPI.Models
{
	[BsonIgnoreExtraElements]
	public class Product
	{
		[BsonElement("id")]
		[JsonPropertyName("id")]
		public int ProductId { get; set; }  //had to do this to avoid _id trying to take over. And then serializing back to id
		
		[BsonElement("sku")]
		public string Sku { get; set; }

		[BsonElement("name")]
		public string Name { get; set; }

		[BsonElement("price")]
		public double Price { get; set; }

		[BsonElement("attribute")]
		public Attribute Attribute { get; set; }
	}
}
