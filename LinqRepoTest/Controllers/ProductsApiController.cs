using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using LinqRepoTest.Entity;
using LinqRepoTest.Repository;

namespace LinqRepoTest.Controllers {

	[RoutePrefix("api/products")]
	public class ProductsApiController : ApiController {

		private readonly CustomerContextRepository repo;

		public ProductsApiController(CustomerContextRepository repo) {
			this.repo = repo;
		}

		[Route("")]
		public IEnumerable<Product> GetProducts(int customerId, string search) {
			return repo.Query<Product>().Where(p => p.CustomerId == customerId && p.Name.Contains(search));
		}

		[Route("{productId:int}")]
		public Product GetProduct(int productId) {
			return repo.Find<Product>(productId);
		}

	}
}
