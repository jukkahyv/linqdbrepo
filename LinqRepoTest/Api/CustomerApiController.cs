using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using LinqRepoTest.Entity;
using LinqRepoTest.Repository;

namespace LinqRepoTest.Api {

	[RoutePrefix("api/customers")]
	public class CustomerApiController : ApiController {

		private readonly CustomerContextRepository db;

		public CustomerApiController(CustomerContextRepository db) {
			this.db = db;
		}

		[Route("{customerId:int}/products")]
		public IEnumerable<Product> GetProducts(int customerId) {

			return db.Query<Product>().Where(p => p.CustomerId == customerId);

		}

	}

}
