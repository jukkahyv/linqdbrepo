using System.Linq;

namespace LinqRepoTest.Repository {

	public interface IDbLinqRepository {

		void Add<T>(T entity) where T : class;

		T Find<T>(object id) where T : class;

		IQueryable<T> Query<T>() where T : class;

		void Remove<T>(T entity) where T : class;

		void SaveChanges();

	}

}
