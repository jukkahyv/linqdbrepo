using System;
using System.Linq;
using LinqRepoTest.Entity;
using LinqRepoTest.Repository;

namespace LinqRepoTest {
	class Program {

		private static readonly IDbLinqRepository repository;

		static Program() {
			repository = new EfLinqRepository(new TestContext());
		}

		private static void PrintProducts() {

			var products = repository.Query<Product>().ToArray();

			foreach (var product in products) {
				Console.WriteLine("{0}: {1} for {2}", product.Id, product.Name, product.Customer.Name);
			}

		}

		static void Main(string[] args) {
			PrintProducts();
			Console.ReadLine();
		}
	}
}
