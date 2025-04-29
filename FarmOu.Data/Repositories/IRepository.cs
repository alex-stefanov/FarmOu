using System.Linq.Expressions;

namespace FarmOu.Data.Repositories;

/// <summary>
/// Interface for a generic repository pattern.
/// </summary>
/// <typeparam name="TType">the entity type</typeparam>
/// <typeparam name="TId">the id type</typeparam>
public interface IRepository<TType, TId>
{
    /// <summary>
    /// Gets an entity by its ID.
    /// </summary>
    /// <param name="id">the id</param>
    TType? GetById(
        TId id);

    /// <summary>
    /// Asynchronously gets an entity by its ID.
    /// </summary>
    /// <param name="id">the id</param>
    Task<TType?> GetByIdAsync(
        TId id);

    /// <summary>
    /// Gets the first entity that matches the predicate.
    /// </summary>
    /// <param name="predicate">the predicate</param>
    TType? FirstOrDefault(
        Func<TType, bool> predicate);

    /// <summary>
    /// Asynchronously gets the first entity that matches the predicate.
    /// </summary>
    /// <param name="predicate">the predicate</param>
    Task<TType?> FirstOrDefaultAsync(
        Expression<Func<TType, bool>> predicate);

    /// <summary>
    /// Gets all entities.
    /// </summary>
    IEnumerable<TType> GetAll();

    /// <summary>
    /// Asynchronously gets all entities.
    /// </summary>
    Task<IEnumerable<TType>> GetAllAsync();

    /// <summary>
    /// Gets all entities as an IQueryable.
    /// </summary>
    IQueryable<TType> GetAllAttached();

    /// <summary>
    /// Adds a new entity.
    /// </summary>
    /// <param name="item">the new entity</param>
    void Add(
        TType item);

    /// <summary>
    /// Asynchronously adds a new entity.
    /// </summary>
    /// <param name="item">the new entity</param>
    Task AddAsync(
        TType item);

    /// <summary>
    /// Adds a range of new entities.
    /// </summary>
    /// <param name="items">the entities</param>
    void AddRange(
        TType[] items);

    /// <summary>
    /// Asynchronously adds a range of new entities.
    /// </summary>
    /// <param name="items">the entities</param>
    Task AddRangeAsync(
        TType[] items);

    /// <summary>
    /// Deletes an entity.
    /// </summary>
    /// <param name="entity">the entity</param>
    bool Delete(
        TType entity);

    /// <summary>
    /// Asynchronously deletes an entity.
    /// </summary>
    /// <param name="entity">the entity</param>
    Task<bool> DeleteAsync(
        TType entity);

    /// <summary>
    /// Updates an entity.
    /// </summary>
    /// <param name="item">the entity</param>
    bool Update(
        TType item);

    /// <summary>
    /// Asynchronously updates an entity.
    /// </summary>
    /// <param name="item">the entity</param>
    Task<bool> UpdateAsync(
        TType item);
}
