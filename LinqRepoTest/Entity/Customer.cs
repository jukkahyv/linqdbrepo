using System.Collections.Generic;

namespace LinqRepoTest.Entity {

	public class Customer : IEntryWithIntId {

		public int Id { get; set; }

		public string Name { get; set; }

		public List<Product> Products { get; set;}

	}

}
