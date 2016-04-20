using System.Data.Entity;
using LinqRepoTest.Entity;

namespace LinqRepoTest {

	public class TestContext : DbContext {

		public TestContext() : base("Server=.;Database=Test;Trusted_Connection=True;") {
			Database.SetInitializer(new TestInitializer());
		}

		public DbSet<Customer> Customers { get; set; }
		public DbSet<Product> Products { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder) {

			modelBuilder.Entity<Customer>()
				.HasMany(s => s.Products);

			modelBuilder.Entity<Product>()
				.HasRequired(s => s.Customer)
				.WithMany(s => s.Products)
				.HasForeignKey(s => s.CustomerId);

		}
	}

}
