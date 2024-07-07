namespace RoutineUtilities.Database;

/// <summary>
/// Provides a base repository class for performing CRUD operations and queries on entities.
/// </summary>
/// <typeparam name="TEntity">The type of the entity.</typeparam>
public class RepositoryBase<TEntity>(DbContext dbContext) : IDisposable where TEntity : class
{
    #region Constructor

    /// <summary>
    /// Initializes a new instance of the <see cref="RepositoryBase{TEntity}"/> class with the specified DbContext.
    /// </summary>
    /// <param name="dbContext">The DbContext to use for database operations.</param>
    private readonly DbContext _context = dbContext;

    #endregion Constructor

    #region Disposable

    /// <summary>
    /// Finalizes an instance of the <see cref="RepositoryBase{TEntity}"/> class.
    /// </summary>
    ~RepositoryBase() => Dispose();

    /// <summary>
    /// Releases all resources used by the current instance of the <see cref="RepositoryBase{TEntity}"/> class.
    /// </summary>
    public void Dispose() => GC.SuppressFinalize(this);

    #endregion Disposable

    #region Sync

    /// <summary>
    /// Inserts the specified entity into the database.
    /// </summary>
    /// <param name="entity">The entity to insert.</param>
    public void Insert(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
        _context.SaveChanges();
    }

    /// <summary>
    /// Inserts a collection of entities into the database.
    /// </summary>
    /// <param name="entities">The collection of entities to insert.</param>
    public void BatchInsert(IEnumerable<TEntity> entities)
    {
        _context.Set<TEntity>().AddRange(entities);
        _context.SaveChanges();
    }

    /// <summary>
    /// Updates the specified entity in the database.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    public void Update(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        _context.SaveChanges();
    }

    /// <summary>
    /// Updates a collection of entities in the database.
    /// </summary>
    /// <param name="entities">The collection of entities to update.</param>
    public void BatchUpdate(IEnumerable<TEntity> entities)
    {
        foreach (TEntity entity in entities)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }

    /// <summary>
    /// Deletes an entity by its primary key(s).
    /// </summary>
    /// <param name="id">The primary key(s) of the entity to delete.</param>
    public void DeleteById(params object[] id)
    {
        TEntity? obj = _context.Set<TEntity>().Find(id);
        if (obj != null)
        {
            _context.Entry(obj).State = EntityState.Deleted;
            _context.Set<TEntity>().Remove(obj);
            _context.SaveChanges();
        }
    }

    /// <summary>
    /// Deletes the specified entity from the database.
    /// </summary>
    /// <param name="entity">The entity to delete.</param>
    public void Delete(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Deleted;
        _context.Set<TEntity>().Remove(entity);
        _context.SaveChanges();
    }

    /// <summary>
    /// Deletes a collection of entities from the database.
    /// </summary>
    /// <param name="entities">The collection of entities to delete.</param>
    public void BatchDelete(IEnumerable<TEntity> entities)
    {
        foreach (TEntity entity in entities)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }
    }

    /// <summary>
    /// Searches for entities that match the specified expression.
    /// </summary>
    /// <param name="expression">The expression to filter entities.</param>
    /// <returns>An enumerable collection of entities that match the expression.</returns>
    public IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> expression) => [.. _context.Set<TEntity>().Where(expression ?? (x => true))];

    /// <summary>
    /// Queries the database for entities that match the specified expression.
    /// </summary>
    /// <param name="expression">The expression to filter entities.</param>
    /// <returns>An IQueryable collection of entities that match the expression.</returns>
    public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> expression) => _context.Set<TEntity>().Where(expression ?? (x => true));

    /// <summary>
    /// Gets all entities from the database.
    /// </summary>
    /// <returns>An enumerable collection of all entities.</returns>
    public IEnumerable<TEntity> All() => [.. _context.Set<TEntity>()];

    /// <summary>
    /// Gets an entity by its primary key(s).
    /// </summary>
    /// <param name="id">The primary key(s) of the entity to retrieve.</param>
    /// <returns>The entity found, or null if not found.</returns>
    public TEntity? GetById(params object[] id) => _context.Set<TEntity>().Find(id);

    /// <summary>
    /// Gets the first entity from the database.
    /// </summary>
    /// <returns>The first entity found, or null if not found.</returns>
    public TEntity? First() => _context.Set<TEntity>().FirstOrDefault();

    /// <summary>
    /// Gets the first entity that matches the specified expression.
    /// </summary>
    /// <param name="expression">The expression to filter entities.</param>
    /// <returns>The first entity that matches the expression, or null if not found.</returns>
    public TEntity? First(Expression<Func<TEntity, bool>> expression) => _context.Set<TEntity>().FirstOrDefault(expression ?? (x => true));

    /// <summary>
    /// Gets the last entity from the database.
    /// </summary>
    /// <returns>The last entity found, or null if not found.</returns>
    public TEntity? Last() => _context.Set<TEntity>().LastOrDefault();

    /// <summary>
    /// Gets the last entity that matches the specified expression.
    /// </summary>
    /// <param name="expression">The expression to filter entities.</param>
    /// <returns>The last entity that matches the expression, or null if not found.</returns>
    public TEntity? Last(Expression<Func<TEntity, bool>> expression) => _context.Set<TEntity>().LastOrDefault(expression ?? (x => true));

    /// <summary>
    /// Gets a specified number of entities that match the expression, skipping the specified number of entities.
    /// </summary>
    /// <param name="expression">The expression to filter entities.</param>
    /// <param name="skip">The number of entities to skip.</param>
    /// <param name="amount">The number of entities to take.</param>
    /// <returns>An enumerable collection of entities.</returns>
    public IEnumerable<TEntity> Some(Expression<Func<TEntity, bool>> expression, int skip, int amount) => [.. _context.Set<TEntity>().Where(expression ?? (x => true)).Skip(skip).Take(amount)];

    /// <summary>
    /// Gets all entities that match the expression, skipping the specified number of entities.
    /// </summary>
    /// <param name="expression">The expression to filter entities.</param>
    /// <param name="skip">The number of entities to skip.</param>
    /// <returns>An enumerable collection of entities.</returns>
    public IEnumerable<TEntity> Skip(Expression<Func<TEntity, bool>> expression, int skip) => [.. _context.Set<TEntity>().Where(expression ?? (x => true)).Skip(skip)];

    /// <summary>
    /// Gets a specified number of entities that match the expression.
    /// </summary>
    /// <param name="expression">The expression to filter entities.</param>
    /// <param name="amount">The number of entities to take.</param>
    /// <returns>An enumerable collection of entities.</returns>
    public IEnumerable<TEntity> Take(Expression<Func<TEntity, bool>> expression, int amount) => [.. _context.Set<TEntity>().Where(expression ?? (x => true)).Take(amount)];

    /// <summary>
    /// Gets the top entities ordered by the specified expression.
    /// </summary>
    /// <typeparam name="TKey">The type of the key to order by.</typeparam>
    /// <param name="orderExpression">The expression to order entities.</param>
    /// <param name="amount">The number of entities to take.</param>
    /// <returns>An enumerable collection of top entities.</returns>
    public IEnumerable<TEntity> Top<TKey>(Expression<Func<TEntity, TKey>> orderExpression, int amount) => [.. _context.Set<TEntity>().OrderByDescending(orderExpression).Take(amount)];

    /// <summary>
    /// Gets the bottom entities ordered by the specified expression.
    /// </summary>
    /// <typeparam name="TKey">The type of the key to order by.</typeparam>
    /// <param name="orderExpression">The expression to order entities.</param>
    /// <param name="amount">The number of entities to take.</param>
    /// <returns>An enumerable collection of bottom entities.</returns>
    public IEnumerable<TEntity> Down<TKey>(Expression<Func<TEntity, TKey>> orderExpression, int amount) => [.. _context.Set<TEntity>().OrderBy(orderExpression).Take(amount)];

    /// <summary>
    /// Gets the count of all entities in the database.
    /// </summary>
    /// <returns>The count of all entities.</returns>
    public int Count() => _context.Set<TEntity>().Count();

    /// <summary>
    /// Gets the count of entities that match the specified expression.
    /// </summary>
    /// <param name="expression">The expression to filter entities.</param>
    /// <returns>The count of entities that match the expression.</returns>
    public int Count(Expression<Func<TEntity, bool>> expression) => _context.Set<TEntity>().Count(expression ?? (x => true));

    /// <summary>
    /// Checks if any entity matches the specified expression.
    /// </summary>
    /// <param name="expression">The expression to filter entities.</param>
    /// <returns>True if any entity matches the expression; otherwise, false.</returns>
    public bool Exist(Expression<Func<TEntity, bool>> expression)
    {
        var entity = _context.Set<TEntity>().FirstOrDefault(expression ?? (x => true));
        return entity != null;
    }

    /// <summary>
    /// Checks if an entity exists by its primary key(s).
    /// </summary>
    /// <param name="id">The primary key(s) of the entity to check.</param>
    /// <returns>True if the entity exists; otherwise, false.</returns>
    public bool Exist(params object[] id)
    {
        var entity = _context.Set<TEntity>().Find(id);
        return entity != null;
    }

    /// <summary>
    /// Checks if any entity matches the specified expression.
    /// </summary>
    /// <param name="expression">The expression to filter entities.</param>
    /// <returns>True if any entity matches the expression; otherwise, false.</returns>
    public bool Any(Expression<Func<TEntity, bool>> expression) => _context.Set<TEntity>().Any(expression ?? (x => true));

    #endregion Sync

    #region Async

    /// <summary>
    /// Inserts the specified entity into the database.
    /// </summary>
    /// <param name="entity">The entity to insert.</param>
    public async Task InsertAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Inserts a collection of entities into the database.
    /// </summary>
    /// <param name="entities">The collection of entities to insert.</param>
    public async Task BatchInsertAsync(IEnumerable<TEntity> entities)
    {
        await _context.Set<TEntity>().AddRangeAsync(entities);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Updates the specified entity in the database.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    public async Task UpdateAsync(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Updates a collection of entities in the database.
    /// </summary>
    /// <param name="entities">The collection of entities to update.</param>
    public async Task BatchUpdateAsync(IEnumerable<TEntity> entities)
    {
        foreach (TEntity entity in entities)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Deletes an entity by its primary key(s).
    /// </summary>
    /// <param name="id">The primary key(s) of the entity to delete.</param>
    public async Task DeleteByIdAsync(params object[] id)
    {
        TEntity? obj = await _context.Set<TEntity>().FindAsync(id);
        if (obj != null)
        {
            _context.Entry(obj).State = EntityState.Deleted;
            _context.Set<TEntity>().Remove(obj);
            await _context.SaveChangesAsync();
        }
    }

    /// <summary>
    /// Deletes the specified entity from the database.
    /// </summary>
    /// <param name="entity">The entity to delete.</param>
    public async Task DeleteAsync(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Deleted;
        _context.Set<TEntity>().Remove(entity);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Deletes a collection of entities from the database.
    /// </summary>
    /// <param name="entities">The collection of entities to delete.</param>
    public async Task BatchDeleteAsync(IEnumerable<TEntity> entities)
    {
        foreach (TEntity entity in entities)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            _context.Set<TEntity>().Remove(entity);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Searches for entities that match the specified expression.
    /// </summary>
    /// <param name="expression">The expression to filter entities.</param>
    /// <returns>An enumerable collection of entities that match the expression.</returns>
    public async Task<IEnumerable<TEntity>> SearchAsync(Expression<Func<TEntity, bool>> expression) => await _context.Set<TEntity>().Where(expression ?? (x => true)).ToListAsync();

    /// <summary>
    /// Queries the database for entities that match the specified expression.
    /// </summary>
    /// <param name="expression">The expression to filter entities.</param>
    /// <returns>An IQueryable collection of entities that match the expression.</returns>
    public async Task<IQueryable<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> expression)
    {
        IQueryable<TEntity> entities = _context.Set<TEntity>().Where(expression ?? (x => true));
        await Task.CompletedTask;
        return entities;
    }

    /// <summary>
    /// Gets all entities from the database.
    /// </summary>
    /// <returns>An enumerable collection of all entities.</returns>
    public async Task<IEnumerable<TEntity>> AllAsync() => await _context.Set<TEntity>().ToListAsync();

    /// <summary>
    /// Gets an entity by its primary key(s).
    /// </summary>
    /// <param name="id">The primary key(s) of the entity to retrieve.</param>
    /// <returns>The entity found, or null if not found.</returns>
    public async Task<TEntity?> GetByIdAsync(params object[] id) => await _context.Set<TEntity>().FindAsync(id);

    /// <summary>
    /// Gets the first entity from the database.
    /// </summary>
    /// <returns>The first entity found, or null if not found.</returns>
    public async Task<TEntity?> FirstAsync() => await _context.Set<TEntity>().FirstOrDefaultAsync();

    /// <summary>
    /// Gets the first entity that matches the specified expression.
    /// </summary>
    /// <param name="expression">The expression to filter entities.</param>
    /// <returns>The first entity that matches the expression, or null if not found.</returns>
    public async Task<TEntity?> FirstAsync(Expression<Func<TEntity, bool>> expression) => await _context.Set<TEntity>().FirstOrDefaultAsync(expression ?? (x => true));

    /// <summary>
    /// Gets the last entity from the database.
    /// </summary>
    /// <returns>The last entity found, or null if not found.</returns>
    public async Task<TEntity?> LastAsync() => await _context.Set<TEntity>().LastOrDefaultAsync();

    /// <summary>
    /// Gets the last entity that matches the specified expression.
    /// </summary>
    /// <param name="expression">The expression to filter entities.</param>
    /// <returns>The last entity that matches the expression, or null if not found.</returns>
    public async Task<TEntity?> LastAsync(Expression<Func<TEntity, bool>> expression) => await _context.Set<TEntity>().LastOrDefaultAsync(expression ?? (x => true));

    /// <summary>
    /// Gets a specified number of entities that match the expression, skipping the specified number of entities.
    /// </summary>
    /// <param name="expression">The expression to filter entities.</param>
    /// <param name="skip">The number of entities to skip.</param>
    /// <param name="amount">The number of entities to take.</param>
    /// <returns>An enumerable collection of entities.</returns>
    public async Task<IEnumerable<TEntity>> SomeAsync(Expression<Func<TEntity, bool>> expression, int skip, int amount) => await _context.Set<TEntity>().Where(expression ?? (x => true)).Skip(skip).Take(amount).ToListAsync();

    /// <summary>
    /// Gets all entities that match the expression, skipping the specified number of entities.
    /// </summary>
    /// <param name="expression">The expression to filter entities.</param>
    /// <param name="skip">The number of entities to skip.</param>
    /// <returns>An enumerable collection of entities.</returns>
    public async Task<IEnumerable<TEntity>> SkipAsync(Expression<Func<TEntity, bool>> expression, int skip) => await _context.Set<TEntity>().Where(expression ?? (x => true)).Skip(skip).ToListAsync();

    /// <summary>
    /// Gets a specified number of entities that match the expression.
    /// </summary>
    /// <param name="expression">The expression to filter entities.</param>
    /// <param name="amount">The number of entities to take.</param>
    /// <returns>An enumerable collection of entities.</returns>
    public async Task<IEnumerable<TEntity>> TakeAsync(Expression<Func<TEntity, bool>> expression, int amount) => await _context.Set<TEntity>().Where(expression ?? (x => true)).Take(amount).ToListAsync();

    /// <summary>
    /// Gets the top entities ordered by the specified expression.
    /// </summary>
    /// <typeparam name="TKey">The type of the key to order by.</typeparam>
    /// <param name="orderExpression">The expression to order entities.</param>
    /// <param name="amount">The number of entities to take.</param>
    /// <returns>An enumerable collection of top entities.</returns>
    public async Task<IEnumerable<TEntity>> TopAsync<TKey>(Expression<Func<TEntity, TKey>> orderExpression, int amount) => await _context.Set<TEntity>().OrderByDescending(orderExpression).Take(amount).ToListAsync();

    /// <summary>
    /// Gets the bottom entities ordered by the specified expression.
    /// </summary>
    /// <typeparam name="TKey">The type of the key to order by.</typeparam>
    /// <param name="orderExpression">The expression to order entities.</param>
    /// <param name="amount">The number of entities to take.</param>
    /// <returns>An enumerable collection of bottom entities.</returns>
    public async Task<IEnumerable<TEntity>> DownAsync<TKey>(Expression<Func<TEntity, TKey>> orderExpression, int amount) => await _context.Set<TEntity>().OrderBy(orderExpression).Take(amount).ToListAsync();

    /// <summary>
    /// Gets the count of all entities in the database.
    /// </summary>
    /// <returns>The count of all entities.</returns>
    public async Task<int> CountAsync() => await _context.Set<TEntity>().CountAsync();

    /// <summary>
    /// Gets the count of entities that match the specified expression.
    /// </summary>
    /// <param name="expression">The expression to filter entities.</param>
    /// <returns>The count of entities that match the expression.</returns>
    public async Task<int> CountAsync(Expression<Func<TEntity, bool>> expression) => await _context.Set<TEntity>().CountAsync(expression ?? (x => true));

    /// <summary>
    /// Checks if any entity matches the specified expression.
    /// </summary>
    /// <param name="expression">The expression to filter entities.</param>
    /// <returns>True if any entity matches the expression; otherwise, false.</returns>
    public async Task<bool> ExistAsync(Expression<Func<TEntity, bool>> expression)
    {
        var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(expression ?? (x => true));
        return entity != null;
    }

    /// <summary>
    /// Checks if an entity exists by its primary key(s).
    /// </summary>
    /// <param name="id">The primary key(s) of the entity to check.</param>
    /// <returns>True if the entity exists; otherwise, false.</returns>
    public async Task<bool> ExistAsync(params object[] id)
    {
        var entity = await _context.Set<TEntity>().FindAsync(id);
        return entity != null;
    }

    /// <summary>
    /// Checks if any entity matches the specified expression.
    /// </summary>
    /// <param name="expression">The expression to filter entities.</param>
    /// <returns>True if any entity matches the expression; otherwise, false.</returns>
    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression) => await _context.Set<TEntity>().AnyAsync(expression ?? (x => true));

    #endregion Async
}
