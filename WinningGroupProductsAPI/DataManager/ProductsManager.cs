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

		public IList<Product> FilterByPrice(decimal price)
		{
			throw new NotImplementedException();
		}

		public IList<Product> FilterByRating(bool ratingValue)
		{
			throw new NotImplementedException();
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
