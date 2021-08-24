﻿using MongoDB.Bson.Serialization.Attributes;

namespace WinningGroupProductsAPI.Models
{
	public class Fantastic
	{

		[BsonElement("name")]
		public string Name { get; set; }
		[BsonElement("type")]
		public short Type { get; set; }
		[BsonElement("value")]
		public bool Value { get; set; }
	}
}
