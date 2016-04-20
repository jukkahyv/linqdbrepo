using System;
using System.Linq;
using LinqRepoTest.Entity;

namespace LinqRepoTest.Repository {

	public class CustomerContextRepository {

		private readonly int customerId;

		public IDbLinqRepository Unauthenticated { get; }

		private T CheckAccess<T>(T entity) where T : IEntityWithCustomer {

			if (entity != null && entity.CustomerId != customerId)
				throw new UnauthorizedAccessException();

			return entity;

		}

		public CustomerContextRepository(IDbLinqRepository unauthenticated, int customerId) {
			this.customerId = customerId;
			Unauthenticated = unauthenticated;
		}


		public void Add<T>(T entity) where T : class, IEntityWithCustomer {
			Unauthenticated.Add(CheckAccess(entity));
		}

		public T Find<T>(object id) where T : class, IEntityWithCustomer {
			return CheckAccess(Unauthenticated.Find<T>(id));
		}

		public IQueryable<T> Query<T>() where T : class, IEntityWithCustomer {
			return Unauthenticated.Query<T>().Where(e => e.CustomerId == customerId);
		}

		public void Remove<T>(T entity) where T : class, IEntityWithCustomer {
			Unauthenticated.Remove(CheckAccess(entity));
		}

		public void SaveChanges() {
			Unauthenticated.SaveChanges();
		}

	}
}
