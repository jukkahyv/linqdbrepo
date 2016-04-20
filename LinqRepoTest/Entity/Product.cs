namespace LinqRepoTest.Entity {

	public class Product : IEntryWithIntId, IEntityWithCustomer {

		public virtual Customer Customer { get; set; }

		public int CustomerId { get; set;}

		public int Id { get; set; }

		public string Name { get; set; }

	}

}
