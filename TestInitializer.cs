using System;
using System.Data.Entity;
using System.Linq;
using LinqRepoTest.Entity;

namespace LinqRepoTest {

	public class TestInitializer : DropCreateDatabaseAlways<TestContext> {

		protected override void Seed(TestContext context) {

			var customer = context.Customers.Add(new Customer { Name = "ACME" });
			var customer2 = context.Customers.Add(new Customer { Name = "Initech" });

			context.SaveChanges();

			context.Products.AddRange(Enumerable.Range(1, 100).Select(idx => new Product {
				Customer = idx % 2 == 0 ? customer : customer2,
				Name = "Product " + Guid.NewGuid(),
			}));

			context.SaveChanges();

		}

	}
}
