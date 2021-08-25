using MongoDB.Driver;
using WinningGroupProductsAPI.DataManager;
using WinningGroupProductsAPI.DataManager.Interfaces;
using WinningGroupProductsAPI.Models;
using Xunit;

namespace WinningGroupProductsAPI.DataManagers.Tests
{
	public class ProductManagerTests
	{
		IMongoCollection<Product> _mongoProductCollection;
		private readonly IProductManager _productManager;

		public ProductManagerTests()
		{
			var settings = MongoClientSettings.FromConnectionString("mongodb+srv://admin:admin@cluster0.ixoor.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
			var client = new MongoClient(settings);
			_mongoProductCollection = client.GetDatabase("winnings-group-db").GetCollection<Product>("products");
			_productManager = new ProductsManager(_mongoProductCollection);
		}

		[Fact]
		[Trait("Category","Integration")]
		public void GetAll()
		{
			//arrange

			//act
			var result = _productManager.GetAllProducts();

			//assert
			Assert.NotNull(result);
			Assert.True(result.Count >= 0);
		}

		[Fact]
		[Trait("Category", "Integration")]
		public void FilterByFantastic()
		{
			//arrange

			//act
			var result = _productManager.FilterByFantastic(false);

			//assert
			Assert.NotNull(result);
			Assert.True(result.Count >= 0);
		}
		[Fact]
		[Trait("Category", "Integration")]
		public void FilterByRating()
		{
			//arrange

			//act
			var result = _productManager.FilterByRating(2.1, 3.5);

			//assert
			Assert.NotNull(result);
			Assert.True(result.Count >= 0);
		}
		[Fact]
		[Trait("Category", "Integration")]
		public void FilterByPrice()
		{
			//arrange

			//act
			var result = _productManager.FilterByPrice(10.1, 100.5);

			//assert
			Assert.NotNull(result);
			Assert.True(result.Count >= 0);
		}
	}
}
