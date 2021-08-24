using MongoDB.Bson.Serialization.Attributes;

namespace WinningGroupProductsAPI.Models
{
	[BsonIgnoreExtraElements]
	public class Product
	{
		//[BsonElement("id")]
		//public int Id { get; set; }
		
		[BsonElement("sku")]
		public string Sku { get; set; }

		[BsonElement("name")]
		public string Name { get; set; }

		[BsonElement("price")]
		public decimal Price { get; set; }

		[BsonElement("attribute")]
		public Attribute Attribute { get; set; }
	}
}
