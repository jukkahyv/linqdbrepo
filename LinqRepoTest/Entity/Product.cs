namespace LinqRepoTest.Entity {

	public class Product : IEntryWithIntId, IEntityWithCustomer {

		public Product() { }

		public Product(Customer customer, string name) {
			Customer = customer;
			CustomerId = customer.Id;
			Name = name;
		}

		public virtual Customer Customer { get; set; }

		public int CustomerId { get; set;}

		public int Id { get; set; }

		public string Name { get; set; }

	}

}
