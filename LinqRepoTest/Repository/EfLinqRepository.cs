using System.Data.Entity;
using System.Linq;

namespace LinqRepoTest.Repository {

	public class EfLinqRepository : IDbLinqRepository {

		private readonly TestContext context;

		public EfLinqRepository(TestContext context) {
			this.context = context;
		}

		private DbSet<T> Set<T>() where T : class {
			return context.Set<T>();
		}

		public void Add<T>(T entity) where T : class {
			Set<T>().Add(entity);
		}

		public T Find<T>(object id) where T : class {
			return Set<T>().Find(id);
		}

		public IQueryable<T> Query<T>() where T : class {
			return Set<T>();
		}

		public void Remove<T>(T entity) where T : class {
			Set<T>().Remove(entity);
		}

		public void SaveChanges() {
			context.SaveChanges();
		}

	}
}
