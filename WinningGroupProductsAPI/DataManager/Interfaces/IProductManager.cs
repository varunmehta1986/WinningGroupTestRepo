using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WinningGroupProductsAPI.Models;

namespace WinningGroupProductsAPI.DataManager.Interfaces
{
	public interface IProductManager
	{
		IList<Product> GetAllProducts();

		IList<Product> FilterByPrice(decimal price);

		IList<Product> FilterByFantastic(bool isFantastic);

		IList<Product> FilterByRating(bool ratingValue);
	}
}
