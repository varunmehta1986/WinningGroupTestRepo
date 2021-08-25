using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using WinningGroupProductsAPI.DataManager.Interfaces;
using WinningGroupProductsAPI.Models;
using Xunit;

namespace WinningGroupProductsAPI.Controllers.Tests
{
	public class ProductControllerTests
	{
		private readonly Mock<IProductManager> _productManager;
		private readonly ProductsController _controller;
		public ProductControllerTests()
		{
			_productManager  = new Mock<IProductManager>();
			_controller =  new ProductsController(_productManager.Object);
		}
		[Fact]
		[Trait("Category","Unit")]
		public void GetAll()
		{
			//arrange 
			_productManager.Setup(pm => pm.GetAllProducts()).Returns(MockProductList());
			
			//act 
			var response = _controller.GetAll();

			//assert
			Assert.NotNull(response);
			Assert.IsType<OkObjectResult>(response);
			var productList = (response as OkObjectResult).Value as IList<Product>;
			Assert.Equal(3, productList.Count);
		}

		[Fact]
		[Trait("Category", "Unit")]
		public void FilterByFantastic()
		{
			//arrange 
			_productManager.Setup(pm => pm.FilterByFantastic(true)).Returns(MockProductList().Where(p=>p.Attribute.Fantastic.Value == true).ToList());
			
			//act
			var response = _controller.FilterByFantastic(true);

			//assert
			Assert.NotNull(response);
			Assert.IsType<OkObjectResult>(response);
			var productList = (response as OkObjectResult).Value as IList<Product>;
		}

		[Theory]
		[Trait("Category", "Unit")]
		[InlineData(5,1, "Minimum rating should be less than or equal to maximum rating")]
		[InlineData(0,2, "Minimum rating value cannot be less than 1")]
		[InlineData(2,6, "Maximum rating value cannot be greater than 5")]
		public void FilterByRating_BadRequests(double minimumRating, double maximumRating, string errorMessage)
		{
			//arrange
			_productManager.Setup(pm => pm.FilterByRating(It.IsAny<double>(), It.IsAny<double>())).Returns(new List<Product>());

			//act
			var response = _controller.FilterByRating(minimumRating, maximumRating);

			//assert
			Assert.NotNull(response);
			Assert.IsType<BadRequestObjectResult>(response);
			Assert.Equal(errorMessage, (response as BadRequestObjectResult).Value);
		}

		[Theory]
		[Trait("Category", "Unit")]
		[InlineData(1,3,2)]
		[InlineData(1.1,1.2,0)]
		public void FilterByRating_OkRequests(double minimumRating, double maximumRating, int count)
		{
			//arrange
			_productManager.Setup(pm => pm.FilterByRating(It.IsAny<double>(), It.IsAny<double>())).
					Returns(MockProductList().Where(p => p.Attribute.Rating.Value>=minimumRating && p.Attribute.Rating.Value<=maximumRating).ToList());

			//act
			var response = _controller.FilterByRating(minimumRating, maximumRating);

			//assert
			Assert.NotNull(response);
			Assert.IsType<OkObjectResult>(response);
			Assert.Equal(count, ((response as OkObjectResult).Value as IList<Product>).Count);
		}

		[Theory]
		[Trait("Category", "Unit")]
		[InlineData(200.0,10.00, "Minimum price should be less than or equal to maximum price")]
		[InlineData(-100.00, 10.0, "Minimum price cannot be negative")]
		public void FilterByPrice_BadRequests(double minimumPrice, double maximumPrice, string errorMessage)
		{
			//arrange
			_productManager.Setup(pm => pm.FilterByRating(It.IsAny<double>(), It.IsAny<double>())).Returns(new List<Product>());

			//act
			var response = _controller.FilterByPrice(minimumPrice, maximumPrice);

			//assert
			Assert.NotNull(response);
			Assert.IsType<BadRequestObjectResult>(response);
			Assert.Equal(errorMessage, (response as BadRequestObjectResult).Value);
		}

		[Theory]
		[Trait("Category", "Unit")]
		[InlineData(10.0, 200.00, 2)]
		[InlineData(1000.0, 1200.00, 0)]
		public void FilterByPrice_OkRequests(double minimumPrice, double maximumPrice, int count)
		{
			//arrange
			_productManager.Setup(pm => pm.FilterByPrice(It.IsAny<double>(), It.IsAny<double>()))
				.Returns(MockProductList().Where(p => p.Price >= minimumPrice && p.Price <= maximumPrice).ToList());

			//act
			var response = _controller.FilterByPrice(minimumPrice, maximumPrice);

			//assert
			Assert.NotNull(response);
			Assert.IsType<OkObjectResult>(response);
			Assert.Equal(count, ((response as OkObjectResult).Value as IList<Product>).Count);
		}

		//dummy product data
		private IList<Product> MockProductList()
		{
			return new List<Product>()
			{
				new Product()
				{
					ProductId = 1,
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
							Value = 2.2
						}
					},
					Price = 100.12
				},
				new Product()
				{
					ProductId = 2,
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
							Value = 3.4
						}
					},
					Price = 555.12
				},
				new Product()
				{
					ProductId = 3
					Sku = "370-04-2497",
					Name = "Test Name 3",
					Attribute = new Models.Attribute()
					{
						Fantastic = new Fantastic()
						{
							Value = true
						},
						Rating = new Rating()
						{
							Value = 1.4
						}
					},
					Price = 10
				}
			};
		}
	}
}
