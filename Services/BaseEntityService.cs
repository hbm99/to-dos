using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using todos.Data;
using todos.Models;

namespace todos.Services
{
    public abstract class BaseEntityService<T> : IEntityService<T> where T : class, IEntity
    {
        private readonly MyDbContext _context;

        public BaseEntityService(MyDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Asynchronously creates a new entity.
        /// </summary>
        /// <param name="entity">The entity to create.</param>
        /// <returns>The created entity.</returns>
        public async Task<T> CreateAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Asynchronously deletes an entity by identifier.
        /// </summary>
        /// <param name="id">The identifier of the entity to delete.</param>
        /// <returns>The deleted entity.</returns>
        public async Task<T> DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity == null)
            {
                throw new Exception("Entity not found");
            }

            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Asynchronously retrieves all entities.
        /// </summary>
        /// <returns>A collection of entities.</returns>
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        /// <summary>
        /// Asynchronously retrieves an entity by identifier.
        /// </summary>
        /// <param name="id">The identifier of the entity to retrieve.</param>
        /// <returns>The retrieved entity.</returns>
        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity == null)
            {
                throw new Exception("Entity not found");
            }
            return entity;
        }

        /// <summary>
        /// Asynchronously updates an entity.
        /// </summary>
        /// <param name="id">The identifier of the entity to update.</param>
        /// <param name="updatedEntity">The updated entity.</param>
        /// <returns>The updated entity.</returns>
        public async Task<T> UpdateAsync(int id, T updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ArgumentNullException(nameof(updatedEntity));
            }

            var entity = await _context.Set<T>().FindAsync(id);
            if (entity == null)
            {
                throw new Exception("Entity not found");
            }
            updatedEntity.Id = id;
            _context.Entry(entity).CurrentValues.SetValues(updatedEntity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
