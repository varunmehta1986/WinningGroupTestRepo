using System.Collections.Generic;
using WinningGroupProductsAPI.Models;

namespace WinningGroupProductsAPI.DataManager.Interfaces
{
	public interface IProductManager
	{
		IList<Product> GetAllProducts();

		IList<Product> FilterByPrice(double minimum, double maximum);

		IList<Product> FilterByFantastic(bool isFantastic);

		IList<Product> FilterByRating(double minimum, double maximum);
	}
}
