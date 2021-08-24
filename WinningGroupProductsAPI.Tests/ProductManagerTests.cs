using MongoDB.Driver;
using Moq;
using System;
using System.Collections.Generic;
using WinningGroupProductsAPI.DataManager;
using WinningGroupProductsAPI.DataManager.Interfaces;
using WinningGroupProductsAPI.Models;
using Xunit;

namespace WinningGroupProductsAPI.Tests
{
	public class ProductManagerTests
	{
		Mock<IMongoCollection<Product>> _mongoDbMoq;

		public ProductManagerTests()
		{
			_mongoDbMoq = new Mock<IMongoCollection<Product>>();
			_mongoDbMoq.Object.InsertOne(new Product()
			{
				Sku = "370-04-2494",
				Name = "Test Name 1",
				Attribute = new Models.Attribute()
				{
					Fantastic = new Fantastic()
					{
						Value = true
					},
					Rating = new Rating()
					{
						Value = 2.2f
					}
				},
				Price = 100.12m
			});
			_mongoDbMoq.Object.InsertOne(new Product()
			{
				Sku = "370-04-2495",
				Name = "Test Name 2",
				Attribute = new Models.Attribute()
				{
					Fantastic = new Fantastic()
					{
						Value = false
					},
					Rating = new Rating()
					{
						Value = 3.4f
					}
				},
				Price = 555.12m
			});
		}

		[Fact]
		public void GetAll()
		{
			//Arrange
			var productManager = new ProductsManager(_mongoDbMoq.Object);

			//Act
			var result = productManager.GetAllProducts();

			//Asser
			Assert.NotNull(result);
			Assert.Equal(2,result.Count);
		}

		[Fact]
		public void FilterByFantastic()
		{

		}
		[Fact]
		public void FilterByRating()
		{

		}
		[Fact]
		public void FilterByPrice()
		{

		}
	}
}
