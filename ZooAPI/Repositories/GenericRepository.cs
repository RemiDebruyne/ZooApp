using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using System.Reflection;
using ZooAPI.Data;
using ZooCore;

namespace ZooAPI.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : BaseModel
    {
        protected readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<T?> AddAsync(T entity)
        {
            var AddedEntity = await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();

            if (AddedEntity.Entity.Id > 0)
                return AddedEntity.Entity;

            return null;
        }

        public virtual async Task<IEnumerable<T?>> GetAllAsync(Expression<Func<T, bool>> predicate)
        {
            return  _context.Set<T>().Where(predicate);
        }

        public virtual async Task<IEnumerable<T?>> GetAllAsync()

        {
            return _context.Set<T>();

        }

        public virtual async Task<T?> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefault(predicate);
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            var entityFromDb = await GetAsync(e => e.Id == entity.Id);

            var entityProperties = entity.GetType().GetProperties();

            foreach (PropertyInfo property in entityProperties)
            {
                var valeurPropriete = property.GetValue(entity, null);
                var valeurProprieteFromDb = property.GetValue(entityFromDb, null);
                if (valeurProprieteFromDb != valeurPropriete)
                    valeurProprieteFromDb = valeurPropriete;
            }

            return await _context.SaveChangesAsync() > 0;
        }

            public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);

            if (entity == null) 
                return false;

            _context.Set<T>().Remove(entity);
            return await _context.SaveChangesAsync() > 0;

        }

    }
}
