using System;
using System.Collections.Generic;
using System.Linq;
using LinqRepoTest.Controllers;
using LinqRepoTest.Entity;
using LinqRepoTest.Tests.TestSupport;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinqRepoTest.Tests.Controllers {

	[TestClass]
	public class ProductApiControllerTests {

		private readonly Customer anotherCustomer = new Customer();
		private ProductsApiController controller;
		private readonly Customer customer = new Customer();
		private Product otherProduct;
		private Product ownProduct1;
		private readonly FakeDbLinqRepository repository = new FakeDbLinqRepository();

		[TestInitialize]
		public void SetUp() {

			repository.AddAndSave(anotherCustomer, customer);

			ownProduct1 = new Product(customer, "Own product 1");
			otherProduct = new Product(anotherCustomer, "Other product");

			repository.AddAndSave(
				ownProduct1, 
				new Product(customer, "Own product 2"), 
				otherProduct
			);

			controller = new ProductsApiController(new Repository.CustomerContextRepository(repository, customer.Id));

		}

		public IEnumerable<Product> CallGetProducts(int customerId, string search) {
			var result = controller.GetProducts(customerId, search);
			Assert.IsNotNull(result, "result");
			return result;
		}

		public Product CallGetProduct(int customerId, int productId) {
			return controller.GetProduct(productId);
		}

		[TestMethod]
		public void GetProducts_Own() {

			var result = CallGetProducts(customer.Id, string.Empty).ToArray();

			Assert.AreEqual(2, result.Length, "Own products returned");
			Assert.IsTrue(result.Any(p => p.Name == "Own product 1"), "Found own product");
			Assert.IsFalse(result.Any(p => p.Name == "Other product"), "Other product not present");

		}

		[TestMethod]
		public void GetProducts_Other() {

			var result = CallGetProducts(anotherCustomer.Id, string.Empty).ToArray();

			Assert.AreEqual(0, result.Length, "No products returned");

		}

		[TestMethod]
		public void GetProducts_SearchByName() {

			var result = CallGetProducts(customer.Id, "2").ToArray();

			Assert.AreEqual(1, result.Length, "One product returned");
			Assert.IsTrue(result.Any(p => p.Name == "Own product 2"), "Only product matching the name was returned");

		}

		[TestMethod]
		public void GetProduct_Own() {

			var result = controller.GetProduct(ownProduct1.Id);

			Assert.AreEqual(ownProduct1, result, "result");

		}

		[TestMethod]
		[ExpectedException(typeof(UnauthorizedAccessException))]
		public void GetProduct_Other() {

			controller.GetProduct(otherProduct.Id);

		}

	}

}
