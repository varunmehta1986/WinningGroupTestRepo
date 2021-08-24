using MongoDB.Driver;

namespace WinningGroupProductsAPI
{
	public class CollectionFactory
	{
		public IMongoCollection<T> GetCollection<T>(string dbConnectionString, string dbName, string collectionName) where T : class 
		{
			var settings = MongoClientSettings.FromConnectionString(dbConnectionString);
			var client = new MongoClient(settings);
			return client.GetDatabase(dbName).GetCollection<T>(collectionName);
		}
	}
}
