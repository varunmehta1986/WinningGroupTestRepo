using Autofac;
using Microsoft.Extensions.Configuration;
using WinningGroupProductsAPI.DataManager;
using WinningGroupProductsAPI.DataManager.Interfaces;
using WinningGroupProductsAPI.Models;

namespace WinningGroupProductsAPI
{
	internal class DependencyInjections:Module
	{
		private readonly IConfiguration _configuration;
		public DependencyInjections(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		protected override void Load(ContainerBuilder builder)
		{
			base.Load(builder);
			builder.Register(prod => new ProductsManager(new CollectionFactory().
															GetCollection<Product>(_configuration.GetConnectionString("WinningGroupDB"),
																	_configuration.GetSection("WinningsGroupDBName").Value, "products")))
												.As<IProductManager>();
		}
	}
}
