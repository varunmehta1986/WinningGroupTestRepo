using MongoDB.Bson.Serialization.Attributes;

namespace WinningGroupProductsAPI.Models
{
	public class Attribute
	{
		[BsonElement("fantastic")]
		public Fantastic Fantastic { get; set; }
		[BsonElement("rating")]
		public Rating Rating { get; set; }
	}
}
