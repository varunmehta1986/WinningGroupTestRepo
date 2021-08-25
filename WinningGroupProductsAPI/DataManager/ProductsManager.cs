using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WinningGroupProductsAPI.DataManager.Interfaces;
using WinningGroupProductsAPI.Models;

namespace WinningGroupProductsAPI.DataManager
{
	public class ProductsManager : IProductManager
	{
		private readonly IMongoCollection<Product> _productsCollection;
		public ProductsManager(IMongoCollection<Product> productsCollection)
		{
			_productsCollection = productsCollection;
		}
		/// <summary>
		/// Method to get the products based on the fantastic attribute filter
		/// </summary>
		/// <param name="isFantastic"></param>
		/// <returns></returns>
		public IList<Product> FilterByFantastic(bool isFantastic)
		{
			var result = _productsCollection.Find(prod => prod.Attribute.Fantastic.Value == isFantastic).ToListAsync();
			return result.Result;
		}

		/// <summary>
		/// Method to filter products by price
		/// </summary>
		/// <param name="minimum"></param>
		/// <param name="maximum"></param>
		/// <returns></returns>
		public IList<Product> FilterByPrice(double minimum, double maximum)
		{
			return _productsCollection.Find(prod => prod.Price >= minimum && prod.Price <= maximum)
									.ToListAsync().Result;
		}
		/// <summary>
		/// Method to filter products by ratings 
		/// </summary>
		/// <param name="minimum"></param>
		/// <param name="maximum"></param>
		/// <returns></returns>
		public IList<Product> FilterByRating(double minimum, double maximum)
		{
			return _productsCollection.Find(prod => prod.Attribute.Rating.Value >= minimum && prod.Attribute.Rating.Value <= maximum)
									.ToListAsync().Result;
		}
		/// <summary>
		/// Method to get all the products in the collection
		/// </summary>
		/// <returns></returns>
		public IList<Product> GetAllProducts()
		{
			return _productsCollection.Find(_ => true).ToListAsync().Result;
		}
	}
}