Example of a .NET database repository implementation that exposes CRUD operations and LINQ interface

```

/// <summary>
/// Provides CRUD operations and a LINQ interface to database.
/// </summary>
public interface IDbLinqRepository {

	/// <summary>
	/// Adds a new entity to repository.
	/// </summary>
	/// <typeparam name="T">Entity type.</typeparam>
	/// <param name="entity">The entity to be added. Cannot be null.</param>
	/// <returns>The added entity. Cannot be null.</returns>
	T Add<T>(T entity) where T : class;

	/// <summary>
	/// Find entity by ID
	/// </summary>
	/// <typeparam name="T">Entity type.</typeparam>
	/// <param name="id">Entity ID.</param>
	/// <returns>Entity matching the ID. Can be null if the entity is not found.</returns>
	T Find<T>(object id) where T : class;

	/// <summary>
	/// Initiates a LINQ query for the repository.
	/// </summary>
	/// <typeparam name="T">Entity type.</typeparam>
	/// <returns>LINQ query. Cannot be null.</returns>
	IQueryable<T> Query<T>() where T : class;

	/// <summary>
	/// Removes an entity from the repository.
	/// </summary>
	/// <typeparam name="T">Entity type.</typeparam>
	/// <param name="entity">Entity to be removed. Cannot be null.</param>
	void Remove<T>(T entity) where T : class;

	/// <summary>
	/// Saves changes, generating identity IDs.
	/// </summary>
	void SaveChanges();

}

```