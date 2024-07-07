# RepositoryBase Class

> Provides a base repository class for performing CRUD operations and queries on entities.

## Constructor

### RepositoryBase

Initializes a new instance of the `RepositoryBase` class with the specified DbContext.

#### Parameters
- `DbContext dbContext`: The DbContext to use for database operations.

## Methods

> All methods have asynchronous variation.

[[#Insert Methods]]
	[[#Insert]]
	[[#BatchInsert]]
[[#Update Methods]]
	[[#Update]]
	[[#BatchUpdate]]
[[#Delete Methods]]
	[[#DeleteById]]
	[[#Delete]]
	[[#BatchDelete]]
[[#Query Methods]]
	[[#Search]]
	[[#Query]]
	[[#All]]
	[[#GetById]]
	[[#First]]
	[[#Last]]
	[[#Some]]
	[[#Skip]]
	[[#Take]]
	[[#Top]]
	[[#Down]]
[[#Utility Methods]]
	[[#Count]]
	[[#Exist]]
	[[#Any]]
[[#Disposable Method]]
	[[#Dispose]]


### Insert Methods

#### Insert

Inserts the specified entity into the database.
##### Parameters
- `TEntity entity`: The entity to insert.

#### BatchInsert

Inserts a collection of entities into the database.
##### Parameters
- `IEnumerable<TEntity> entities`: The collection of entities to insert.

### Update Methods

#### Update

Updates the specified entity in the database.
##### Parameters
- `TEntity entity`: The entity to update.

#### BatchUpdate

Updates a collection of entities in the database.
##### Parameters
- `IEnumerable<TEntity> entities`: The collection of entities to update.

### Delete Methods

#### DeleteById

Deletes an entity by its primary key(s).
##### Parameters
- `params object[] id`: The primary key(s) of the entity to delete.

#### Delete

Deletes the specified entity from the database.
##### Parameters
- `TEntity entity`: The entity to delete.

#### BatchDelete

Deletes a collection of entities from the database.
##### Parameters
- `IEnumerable<TEntity> entities`: The collection of entities to delete.

### Query Methods

#### Search

Searches for entities that match the specified expression.
##### Parameters
- `Expression<Func<TEntity, bool>> expression`: The expression to filter entities.
##### Returns
- `IEnumerable<TEntity>`: An enumerable collection of entities that match the expression.

#### Query

Queries the database for entities that match the specified expression.
##### Parameters
- `Expression<Func<TEntity, bool>> expression`: The expression to filter entities.
##### Returns
- `IQueryable<TEntity>`: An IQueryable collection of entities that match the expression.

#### All

Gets all entities from the database.
##### Returns
- `IEnumerable<TEntity>`: An enumerable collection of all entities.

#### GetById

Gets an entity by its primary key(s).
##### Parameters
- `params object[] id`: The primary key(s) of the entity to retrieve.
##### Returns
- `TEntity?`: The entity found, or null if not found.

#### First

Gets the first entity from the database.
##### Returns
- `TEntity?`: The first entity found, or null if not found.

####  First

Gets the first entity that matches the specified expression.
##### Parameters
- `Expression<Func<TEntity, bool>> expression`: The expression to filter entities.
##### Returns
- `TEntity?`: The first entity that matches the expression, or null if not found.

#### Last

Gets the last entity from the database.
##### Returns
- `TEntity?`: The last entity found, or null if not found.

#### Last

Gets the last entity that matches the specified expression.
##### Parameters
- `Expression<Func<TEntity, bool>> expression`: The expression to filter entities.
##### Returns
- `TEntity?`: The last entity that matches the expression, or null if not found.

#### Some

Gets a specified number of entities that match the expression, skipping the specified number of entities.
##### Parameters
- `Expression<Func<TEntity, bool>> expression`: The expression to filter entities.
- `int skip`: The number of entities to skip.
- `int amount`: The number of entities to take.
##### Returns
- `IEnumerable<TEntity>`: An enumerable collection of entities.

#### Skip

Gets all entities that match the expression, skipping the specified number of entities.
##### Parameters
- `Expression<Func<TEntity, bool>> expression`: The expression to filter entities.
- `int skip`: The number of entities to skip.
##### Returns
- `IEnumerable<TEntity>`: An enumerable collection of entities.

#### Take

Gets a specified number of entities that match the expression.
##### Parameters
- `Expression<Func<TEntity, bool>> expression`: The expression to filter entities.
- `int amount`: The number of entities to take.
##### Returns
- `IEnumerable<TEntity>`: An enumerable collection of entities.

#### Top

Gets the top entities ordered by the specified expression.
##### Parameters
- `Expression<Func<TEntity, TKey>> orderExpression`: The expression to order entities.
- `int amount`: The number of entities to take.
##### Returns
- `IEnumerable<TEntity>`: An enumerable collection of top entities.

#### Down

Gets the bottom entities ordered by the specified expression.
##### Parameters
- `Expression<Func<TEntity, TKey>> orderExpression`: The expression to order entities.
- `int amount`: The number of entities to take.
##### Returns
- `IEnumerable<TEntity>`: An enumerable collection of bottom entities.

### Utility Methods

#### Count

Gets the count of all entities in the database.
##### Returns
- `int`: The count of all entities.

#### Count

Gets the count of entities that match the specified expression.
##### Parameters
- `Expression<Func<TEntity, bool>> expression`: The expression to filter entities.
##### Returns
- `int`: The count of entities that match the expression.

#### Exist

Checks if any entity matches the specified expression.
##### Parameters
- `Expression<Func<TEntity, bool>> expression`: The expression to filter entities.
##### Returns
- `bool`: True if any entity matches the expression; otherwise, false.

#### Exist

Checks if an entity exists by its primary key(s).
##### Parameters
- `params object[] id`: The primary key(s) of the entity to check.
##### Returns
- `bool`: True if the entity exists; otherwise, false.

#### Any

Checks if any entity matches the specified expression.
##### Parameters
- `Expression<Func<TEntity, bool>> expression`: The expression to filter entities.
##### Returns
- `bool`: True if any entity matches the expression; otherwise, false.

### Disposable Method

#### Dispose

Releases all resources used by the current instance of the `RepositoryBase` class.
