using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using LinqRepoTest.Entity;
using LinqRepoTest.Repository;

namespace LinqRepoTest.Tests.TestSupport {

	public class FakeDbLinqRepository : IDbLinqRepository {

		private readonly List<IEntryWithIntId> added = new List<IEntryWithIntId>();
		private readonly Dictionary<Type, IList> entities = new Dictionary<Type, IList>();
		private int nextId;

		public TEntity Add<TEntity>(TEntity entity) where TEntity : class {

			List<TEntity>().Add(entity);

			if (entity is IEntryWithIntId) {
				added.Add((IEntryWithIntId)entity);
			}

			return entity;

		}

		public TEntity AddAndSave<TEntity>(TEntity entity) where TEntity : class {

			Add(entity);
			SaveChanges();
			return entity;

		}

		public void AddAndSave<TEntity>(params TEntity[] entities) where TEntity : class {

			foreach (var entity in entities)
				Add(entity);

			SaveChanges();

		}

		public T Find<T>(object id) where T : class {

			if (!typeof(IEntryWithIntId).IsAssignableFrom(typeof(T)) || !(id is int)) {
				throw new NotSupportedException("Only supported for IEntryWithIntId and integer Ids");
			}

			var entity = List<T>().FirstOrDefault(e => ((IEntryWithIntId)e).Id == (int)id);
			return entity;

		}

		public List<TEntity> List<TEntity>() => List<TEntity>(typeof(TEntity));

		public List<TEntity> List<TEntity>(Type t) {

			if (!entities.ContainsKey(t))
				entities.Add(t, new List<TEntity>());

			return (List<TEntity>)entities[t];

		}

		public IQueryable<T> Query<T>() where T : class {

			var t = typeof(T);

			if (entities.ContainsKey(t))
				return ((List<T>)entities[t]).AsQueryable();
			else
				return (new T[] { }).AsQueryable();

		}

		public void Remove<T>(T entity) where T : class {
			List<T>().Remove(entity);
		}

		public void SaveChanges() {

			foreach (var entity in added)
				entity.Id = nextId++;

			added.Clear();

		}

	}

}
