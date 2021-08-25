using Microsoft.AspNetCore.Mvc;
using WinningGroupProductsAPI.DataManager.Interfaces;

namespace WinningGroupProductsAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IProductManager _productManager;
		public ProductsController(IProductManager productManager)
		{
			_productManager = productManager;
		}

		[HttpGet]
		public IActionResult GetAll()
		{
			return new OkObjectResult(_productManager.GetAllProducts());
		}

		[HttpGet]
		[Route("fantastic/{isFantastic}")]
		public IActionResult FilterByFantastic([FromRoute]bool isFantastic)
		{
			return new OkObjectResult(_productManager.FilterByFantastic(isFantastic));
		}
		[HttpGet]
		[Route("price/{minimum}/{maximum}")]
		public IActionResult FilterByPrice([FromRoute]double minimum, double maximum)
		{
			if(minimum < 0)
			{
				return new BadRequestObjectResult("Minimum price cannot be negative");
			}
			else if (minimum > maximum )
			{
				return new BadRequestObjectResult("Minimum price should be less than or equal to maximum price");
			}
			return new OkObjectResult(_productManager.FilterByPrice(minimum, maximum));
		}

		[HttpGet]
		[Route("rating/{minimum}/{maximum}")]
		public IActionResult FilterByRating([FromRoute]double minimum, double maximum)
		{
			if (minimum < 1 )
			{
				return new BadRequestObjectResult("Minimum rating value cannot be less than 1");
			}
			else if (maximum > 5)
			{
				return new BadRequestObjectResult("Maximum rating value cannot be greater than 5");
			}
			else if(minimum > maximum)
			{
				return new BadRequestObjectResult("Minimum rating should be less than or equal to maximum rating");
			}
			return new OkObjectResult(_productManager.FilterByRating(minimum, maximum));
		}
		
	}
}
