using System.Collections.Generic;
using System.Linq;
using LinqRepoTest.Entity;
using LinqRepoTest.Repository;

namespace LinqRepoTest.Controllers {

	public class ProductsApiController {

		private readonly CustomerContextRepository repo;

		public ProductsApiController(CustomerContextRepository repo) {
			this.repo = repo;
		}

		public IEnumerable<Product> GetProducts(int customerId, string search) {
			return repo.Query<Product>().Where(p => p.CustomerId == customerId && p.Name.Contains(search));
		}

		public Product GetProduct(int productId) {
			return repo.Find<Product>(productId);
		}

	}
}
