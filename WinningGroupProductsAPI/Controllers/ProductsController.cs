using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WinningGroupProductsAPI.DataManager;
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
			//todo:Get complete collection
			return new OkObjectResult(_productManager.GetAllProducts());
		}

		[HttpGet]
		[Route("fantastic/{isFantastic}")]
		public IActionResult FilterByFantastic([FromRoute]bool isFantastic)
		{
			//todo: filter products by price, min/max
			return new OkObjectResult(_productManager.FilterByFantastic(isFantastic));
		}

		//	public void 
	}
}
