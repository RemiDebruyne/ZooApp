using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using System.Reflection;
using ZooAPI.Data;
using ZooCore;

namespace ZooAPI.Repositories
{
    public class AnimalRepository : IRepository<Animal>
    {
        private readonly ApplicationDbContext _context;

        public AnimalRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Animal> AddAsync(Animal entity)
        {
            var AddedEntity = await _context.Set<Animal>().AddAsync(entity);
            await _context.SaveChangesAsync();

            if (AddedEntity.Entity.Id > 0)
                return AddedEntity.Entity;

            return null;
        }

        public async Task<IEnumerable<Animal?>> GetAllAsync(Expression<Func<Animal, bool>> predicate)
        {
            return _context.Set<Animal>().Where(predicate);
        }

        public async Task<IEnumerable<Animal?>> GetAllAsync()

        {
            return _context.Set<Animal>();

        }

        public async Task<Animal?> GetAsync(Expression<Func<Animal, bool>> predicate)
        {
            return _context.Set<Animal>().FirstOrDefault(predicate);
        }

        public async Task<bool> UpdateAsync(Animal entity)
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
            var entity = await _context.Set<Animal>().FirstOrDefaultAsync(e => e.Id == id);

            if (entity == null) 
                return false;

            _context.Set<Animal>().Remove(entity);
            return await _context.SaveChangesAsync() > 0;

        }

    }
}
